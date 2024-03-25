using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.TCP
{
    public class FVMITcpClient
    {
        private IPAddress _address;
        private int _port;
        private TcpClient client = new TcpClient();
        private bool log = false;
        private int GeneralDelay = 0;
        public bool isRunning
        {
            get => client.Client.Connected;
        }
        public FVMITcpClient()
        {
            string? ipAddress = Properties.Settings.Default["ServerIpAddress"].ToString();
            string? port = Properties.Settings.Default["ServerPort"].ToString();
            if (ipAddress is null || port is null)
                throw new Exception("Ip Address/Port is not configured yet");
            _address = IPAddress.Parse(ipAddress);
            _port = int.Parse(port);
            log = bool.Parse(Properties.Settings.Default["TcpLog"].ToString() ?? "false");
            string? generalDelay = Properties.Settings.Default["GeneralDelay"].ToString() ?? "0";
            GeneralDelay = int.Parse(generalDelay);
        }
        public void SetIpAddress(string ipAddress)
        {
            _address = IPAddress.Parse(ipAddress);
        }
        public void SetPort(int port)
        {
            _port = port;
        }
        public async Task Connect()
        {
            client = new TcpClient();
            try
            {
                await client.ConnectAsync(_address, _port);
            }
            catch (SocketException ex) {
                Trace.WriteLineIf(log, $"Connect Issue: {ex.Message} {ex.InnerException?.Message}");
            }
            catch(Exception ex)
            {
                Trace.WriteLineIf(log, $"Connect Exception: {ex.Message} {ex.InnerException?.Message}");
            }
        }
        public async Task<string> GetMessage(string logCommand)
        {
            Trace.WriteLineIf(log, $"Reading {logCommand}...");
            if (!isRunning)
            {
                await Connect();
                return string.Empty;
            }

            byte[] buffer = new byte[512];
            var stream = client.GetStream();
            await stream.ReadAsync(buffer, 0, buffer.Length);
            string msg = Encoding.ASCII.GetString(buffer);
            Trace.WriteLineIf(log, $"Result From {logCommand}: {msg}");
            return msg.Trim();
        }
        public async Task<string> SendCommand(string cmd)
        {
            if (!isRunning)
                await Connect();
            Trace.WriteLineIf(log, $"Writing Command {cmd}");
            byte[] buffer = Encoding.ASCII.GetBytes($"{cmd}\r\n");
            string result = string.Empty;
            int tryCount = 0;
            do
            {
                tryCount = tryCount + 1;
                try
                {
                    Debug.WriteLineIf(log, $"Writing {cmd} Command, Count: {tryCount + 1}");
                    await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
                    await client.GetStream().FlushAsync();
                    result = await GetMessage(cmd);
                }
                catch (Exception ex)
                {
                    Debug.WriteLineIf(log, $"Error Writing {cmd} Command, Count: {tryCount + 1} : {ex.Message} {ex.InnerException?.Message}");
                }
            }
            while ((result.ToUpper().Contains("E1") || string.IsNullOrEmpty(result)) && tryCount < 10);

            result = result.Replace("\r", "").Replace("\n", "").Replace("\0", "");
            return result;
        }
        public async Task<string> ReadCommand(string nameCommand) => await SendCommand($"RD {nameCommand}");
        public async Task<string> WriteCommand(string nameCommand, object value) => await SendCommand($"WR {nameCommand} {value}");
        //public async IAsyncEnumerable<string> PushCommand(string cmd,params string[] values)
        //{
        //    if (!isRunning) await Connect();
        //    for (int i=0;i<values.Length;i++)
        //    {
        //        var res = await SendCommand($"{cmd} {values[i]}");
        //        yield return res;
        //    }

        //}
        public async Task<string[]> PushCommand(string cmd,int _GeneralDelay=-1, params string[] values)
        {
            int delay = _GeneralDelay == -1 ? GeneralDelay : _GeneralDelay;
            string[] results = new string[values.Length];
            if (!isRunning) await Connect();
            for (int i = 0; i < values.Length; i++)
            {
                results[i] = await SendCommand($"WR {cmd} {values[i]}");
                if (results[i] == string.Empty || results[i].Contains("E1"))
                {
                    Trace.WriteLine($"Push Command Fail, result :");
                    for (int j = 0; j < i; j++)
                        Trace.WriteLine($"{cmd} {values[j]} : {results[j]}");
                }
                await Task.Delay(delay);
            }
            return results;

        }
        public async Task<string[]> MonitorCommand(string cmd, string targetResult = "ok", CancellationToken? cToken = null)
        {
            string result = string.Empty;
            do
            {
                result = await SendCommand($"RD {cmd}");
                result = result.Replace("\r", "").Replace("\n", "").Replace("\0", "");
            }
            while (result.ToLower() != targetResult && (cToken is null || !cToken.Value.IsCancellationRequested));
            return new string[] { cmd, result };
        }
        public async IAsyncEnumerable<string> MonitorCommand(string[] commands, string targetResult = "ok", CancellationToken? cToken = null)
        {

            string result;
            foreach (var cmd in commands)
            {
                do
                {
                    result = await SendCommand($"RD {cmd}");
                    result = result.Replace("\r", "").Replace("\n", "").Replace("\0", "");
                }
                while (result.ToLower() != targetResult && (cToken is null || !cToken.Value.IsCancellationRequested));
                yield return result;
            }
        }
        public void Disconnect()
        {
            client.Client.Close();
            client.Close();
        }
        public async Task Reconnect()
        {
            Disconnect();
            await Connect();
        }
        public async Task<decimal> LoadValue(string command, decimal defaultValue=0)
        {
            if (isRunning)
            {
                Connect();
                return defaultValue;
            }
            string res;
            decimal value;
            res = await SendCommand(command);
            string[] spl = res.Split("\n");
            if (spl.Length > 1)
            {
                if (spl[1] != string.Empty)
                {
                    Debug.WriteLine($"{command} reading resulting multiline value\nvalue: {res}\nRestarting Connection");
                    Reconnect();
                    await Task.Delay(GeneralDelay);
                    return defaultValue;
                }
            }
            bool s = decimal.TryParse(res.Replace("+", "").Replace("\r", "").Replace("\n", ""), out value);
            return s ? value : defaultValue;
        }
    }
}
