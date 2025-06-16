using FVMI_INSPECTION.TCP;

namespace FVMI_INSPECTION
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
         {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            FVMITcpClient process = new FVMITcpClient();
            process.WriteCommand("MR2100", 0).RunSynchronously();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm() { WindowState= FormWindowState.Maximized} );
        }
    }
}