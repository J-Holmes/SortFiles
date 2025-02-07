using System;
using System.IO;
using Newtonsoft.Json;

class Config
{
    public string InputFolder { get; set; }
    public string OutputFolder { get; set; }
}

class Program
{
    static void Main()
    {
        string configPath = "config.json";
        if (!File.Exists(configPath))
        {
            Console.WriteLine("Config file not found.");
            return;
        }

        Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
        string inputFolder = config.InputFolder;
        string outputFolder = config.OutputFolder;

        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist.");
            return;
        }

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        string picturesFolder = Path.Combine(outputFolder, "pictures");
        string textFolder = Path.Combine(outputFolder, "text");
        string pdfFolder = Path.Combine(outputFolder, "pdf");
        string musicFolder = Path.Combine(outputFolder, "music");
        string videoFolder = Path.Combine(outputFolder, "video");
        string zipFolder = Path.Combine(outputFolder, "zip");
        string emailFolder = Path.Combine(outputFolder, "emails");
        string htmlFolder = Path.Combine(outputFolder, "html");
        string softwareDev = Path.Combine(outputFolder, "dev");
        string otherFiles = Path.Combine(outputFolder, "other");
        string fontFiles = Path.Combine(outputFolder, "fonts");
        string excelFiles = Path.Combine(outputFolder, "excel");


        Directory.CreateDirectory(picturesFolder);
        Directory.CreateDirectory(textFolder);
        Directory.CreateDirectory(pdfFolder);
        Directory.CreateDirectory(musicFolder);
        Directory.CreateDirectory(videoFolder);
        Directory.CreateDirectory(zipFolder);
        Directory.CreateDirectory(emailFolder);
        Directory.CreateDirectory(htmlFolder);
        Directory.CreateDirectory(softwareDev);
        Directory.CreateDirectory(otherFiles);
        Directory.CreateDirectory(fontFiles);
        Directory.CreateDirectory(excelFiles);


        string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).ToLower();
            string destinationFolder = extension switch
            {
                ".jpg" or ".jpeg" or ".png" or ".gif" or ".bmp" or ".tif" or 
                ".heic" or ".svg" or ".ico" or ".eps" or ".dxf" => picturesFolder,
                ".txt" or ".docx" => textFolder,
                ".pdf" => pdfFolder,
                ".mp3" or ".wav" or ".amr" or ".m4a" => musicFolder,
                ".mp4" or ".mov" or ".avi" => videoFolder,
                ".zip" => zipFolder,
                ".msg" or ".pst" => emailFolder,
                ".html" or ".webp" => htmlFolder,
                ".java" or ".h" or ".ai" or ".psd" or ".sqlite" or ".exe" or ".dll" 
                    or ".xml" or ".reg" or ".ini" or ".cab" or ".inf" or ".jsp"
                    or ".f" or ".sh" or ".gz" or ".py" or ".php" or ".icc"
                    or ".swf" or ".plist" or ".c" or ".bat" => softwareDev,
                ".ds_store" => otherFiles,
                ".ttf" or ".wim" or ".rtf" => fontFiles,
                ".xlsx" or ".csv" => excelFiles,
                _ => null
            };

            if (destinationFolder != null)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(destinationFolder, fileName);
                File.Move(file, destinationPath);
                Console.WriteLine($"Moved: {fileName} -> {destinationFolder}");
            }
        }

        Console.WriteLine("Sorting complete.");
    }
}
