using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Utilities
{
    public class FileLib
    {
        public string _filePath { get; private set; } = string.Empty;
        public  string _savePath { get; private set; } = string.Empty;
        public string _ngSavePath { get; private set; } = string.Empty;
        private string _logPath = string.Empty;
        public string _markSaveDir { get; private set; } = string.Empty;
        private string basename_folder = "0_";
        public string CSVPath { get; set; } = string.Empty;
//        public int FolderCode { get; set; } = 1;
        public FileLib()
        {

            string csvPath = Properties.Settings.Default["CSVPath"]?.ToString() ?? "csv";
            string settingPath = Properties.Settings.Default["ImageDirName"]?.ToString() ?? "img";
            string savePath = Properties.Settings.Default["SaveImageDirName"]?.ToString() ?? "img";
            string ngSavePath = Properties.Settings.Default["NgImageDirName"]?.ToString() ?? "ng";
            string logPath = Properties.Settings.Default["LogPath"]?.ToString() ?? "log";
            string markSaveDir = Properties.Settings.Default["MarkSaveDir"]?.ToString() ?? "markImg";
            _filePath = settingPath.Contains(":\\") || settingPath.Contains(":/") ? settingPath :  Path.Combine( AppDomain.CurrentDomain.BaseDirectory,
                 settingPath);
            CSVPath = csvPath.Contains(":\\") || csvPath.Contains(":/") ? csvPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
     csvPath);
            _savePath = savePath.Contains(":\\") || savePath.Contains(":/") ? savePath  : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                 savePath);
            _ngSavePath = ngSavePath.Contains(":\\") || ngSavePath.Contains(":/") ? ngSavePath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                ngSavePath);
            _logPath = logPath.Contains(":\\") || logPath.Contains(":/") ? logPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                logPath);

            _markSaveDir = markSaveDir.Contains(":\\") || markSaveDir.Contains(":/") ? markSaveDir : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                markSaveDir);
            try
            {
                if (!Directory.Exists(_filePath))
                    Directory.CreateDirectory(_filePath);
                if (!Directory.Exists(_savePath))
                    Directory.CreateDirectory(_savePath);
                if (!Directory.Exists(_ngSavePath))
                    Directory.CreateDirectory(_ngSavePath);
                if (!Directory.Exists(_logPath))
                    Directory.CreateDirectory(_logPath);
                if (!Directory.Exists(_markSaveDir))
                    Directory.CreateDirectory(_markSaveDir);
                Console.WriteLine(_filePath);
                Console.WriteLine(_savePath);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Image? ReadImage(string imageName,bool local = false, string? manualPath = null)
        {
            Image img;
            try
            {
                img = Image.FromFile(Path.Combine(manualPath is null ? (local ? _savePath : _ngSavePath ): manualPath, imageName));
                return img;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message +$" {imageName}", "Image Load Error");
                return null;
            }
        }
        public void SaveImage(string imagePath,string name,bool ng=false, string? manualPath = null)
        {
            if (!File.Exists(imagePath))
            {
                MessageBox.Show($"Path {imagePath} Not Found", "File Error");
                return;
            }
            string savepath = Path.Combine(manualPath is null ? (ng ? _ngSavePath : _savePath) : manualPath,name);
            try
            {
                if (File.Exists(savepath))
                    File.Delete(savepath);
                var img = Image.FromFile(imagePath);
                img.Save(savepath);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message},PATH:{imagePath},TO:{savepath})");
            }
        }
        public string[] GetFolders(string search = "")
        {
            string fullpath = _filePath;
            if (!Directory.Exists(fullpath))
            {
                MessageBox.Show($"Directory {fullpath} is not exists", "Directory Not Found");
                //throw new Exception($"Directory {fullpath} is not exists");
                return new string[0];
            }
            var dirs = Directory.GetDirectories(fullpath);
            if (dirs is null)
            {
                MessageBox.Show($"Path {fullpath} Not Found", "File Error");
                return new string[0];
            }
            return search== "" ? dirs.OrderByDescending(x=>x).ToArray() : dirs.Where(x=>x.Contains(search)).OrderByDescending(x=>x).ToArray();
        }
        public async Task<string[]> GetFiles(string path,string search="")
        {
            int trycount = 0;
            var files = Directory.GetFiles(path);
            if (files is null)
            {
                MessageBox.Show($"Path {path} Not Found", "File Error");
                return new string[0];
            }
            while (files.Length < 1 && trycount <= 10)
            {
                await Task.Delay(100);
                files = Directory.GetFiles(path);
                Debug.WriteLineIf(files.Length < 1, $"Retry fetching image on: {path}, count: {trycount+1}");
                trycount += 1;
            }
            return search == "" ? files.OrderByDescending(x=>x).ToArray() : files.Where(x => x.Contains(search)).OrderByDescending(x => x).ToArray();
        }
        public async Task<string> GetTriggerImgPath(int CameraDelay= 100)
        {
            try
            {
                await Task.Delay(CameraDelay);
                string foldername = $"{DateTime.Now.ToString("yyMMdd")}";
                string[] folders = GetFolders(foldername);
                if (folders.Length < 1)
                {
                    MessageBox.Show($"No Folder with prefix {foldername} Found", "Error");
                    return string.Empty;
                }
                string latestDir = Path.Combine(folders[0], "CAM1");
                string[] img = await GetFiles(latestDir);
                if (img.Length < 1)
                    return string.Empty;
                FileInfo file = new FileInfo(img[0]);
                SaveImage(file.FullName, file.Name, true);
                return file.Name;
            }
            catch(Exception ex)
            {
                Trace.TraceError(ex.Message);
                return string.Empty;
            }
        }
        /*public async Task<string> GenerateLog(List<RecordInspectionModel> Records, string ScanCode)
        {
            if (Records.Count < 1)
                return string.Empty;
            string Log =
               /// "Content:\n" +
               /// $"Model: {Records.First().Model}\n"+
                $"{ScanCode}\n"+
                (Records.Any(x=>x.Judgement=="NG") ? "FAIL" : "PASS" )+"\n\n";
            StringBuilder sb = new StringBuilder(Log);
            foreach (var record in Records) 
            {
                if (record.Judgement=="NG")
                    sb.AppendLine(
                        $"Position: {record.Pos}\n" +
                        $"Area Inspection: {record.AreaInspection}\n" +
                        $"Judgement: {record.Judgement}\n" +
                        $"Image: {record.FileName}\n"
                    );
            }
            string filename = $"{DateTime.Now.ToString("yyyyMMdd")}_{ScanCode}.txt";
            using (StreamWriter sw = new StreamWriter(Path.Combine(_logPath, filename)))
            {
                await sw.WriteAsync(sb);
                await sw.FlushAsync();
            }

            return filename;
        }*/
<<<<<<< Updated upstream
=======
        public string GenerateLog(LogModel model)
        {
            string text = @$"[General]
Model={model.Model}
Date={model.DateTime.ToString("ddMMMyyyy HH:mm:ss")}
Status={model.Status}
SN={model.SN}

[Detail]
TopFailTool={model.TopFailTool}
TopUvFailTool={model.TopUvFailTool}
BotFailTool={model.BotFailTool}
BotUVFailTool={model.BotUVFailTool}

[Judgement]
Failure{(model.Failure==string.Empty ? "" : ("="+model.Failure) )}";
            return text;
        }

        public async Task<string> WriteLog(string scanCode, string text, string judge)
        {
            string filename = $"log_{scanCode}_{judge}.txt ";
            string[] paths = [Path.Combine(_logPath, filename), Path.Combine(Settings.Default.BackupLogPath, filename)];
            foreach (string path in paths)
            {
                if (File.Exists(path))
                    File.Delete(path);
                await File.WriteAllTextAsync(path, text);
            }
            return filename;
        }
>>>>>>> Stashed changes
    }
}
