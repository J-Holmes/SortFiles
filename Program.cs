﻿using System;
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
        string appleFiles = Path.Combine(outputFolder, "apple");
        string encryptedFiles = Path.Combine(outputFolder, "encrypted");
        string powerpointFiles = Path.Combine(outputFolder, "powerpoint");
        string shortcutFiles = Path.Combine(outputFolder, "shortcuts");


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
        Directory.CreateDirectory(appleFiles);
        Directory.CreateDirectory(encryptedFiles);
        Directory.CreateDirectory(powerpointFiles);
        Directory.CreateDirectory(shortcutFiles);


        string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            string extension = Path.GetExtension(file).ToLower();
            string destinationFolder = extension switch
            {
                ".jpg" or ".jpeg" or ".png" or ".gif" or ".bmp" or ".tif" or 
                ".heic" or ".svg" or ".ico" or ".eps" or ".dxf" or ".emf" => picturesFolder,
                ".txt" or ".docx" or ".doc" or ".one" or ".wpd" or ".vsd" or ".vsdx"=> textFolder,
                ".pdf" => pdfFolder,
                ".mp3" or ".wav" or ".amr" or ".m4a" or ".aif" or ".mid" or ".flac" => musicFolder,
                ".mp4" or ".mov" or ".avi" or ".wma" => videoFolder,
                ".zip" => zipFolder,
                ".msg" or ".pst" => emailFolder,
                ".html" or ".webp" or ".woff" or ".asp" or ".url" or ".xpi" => htmlFolder,
                ".java" or ".h" or ".ai" or ".psd" or ".sqlite" or ".exe" 
                    or ".dll" or ".xml" or ".reg" or ".ini" or ".cab" or ".inf" 
                    or ".jsp" or ".f" or ".sh" or ".gz" or ".py" or ".php" 
                    or ".icc" or ".swf" or ".plist" or ".c" or ".bat" or ".go"
                    or ".json" or ".pl" or ".pm" or ".jar" or ".elf" or ".accdb"
                    or ".tib" or ".class" or ".swc" or ".mdb" or ".mdl" 
                    or ".dump" or ".apk" or ".xmp" or ".db" or ".deb" => softwareDev,
                ".ds_store" => otherFiles,
                ".ttf" or ".wim" or ".rtf" => fontFiles,
                ".xlsx" or ".csv" or ".xls" => excelFiles,
                ".apple" or ".key" => appleFiles,
                ".gpg" => encryptedFiles,
                ".pptx" or ".ppt" => powerpointFiles,
                ".lnk" => shortcutFiles,
                _ => null
            };

            if (destinationFolder != null)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(destinationFolder, fileName);

                int count = 1;
                while (File.Exists(destinationPath))
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                    string fileExt = Path.GetExtension(fileName);
                    destinationPath = Path.Combine(destinationFolder, $"{fileNameWithoutExt}_{count}{fileExt}");
                    count++;
                }

                File.Move(file, destinationPath);
                Console.WriteLine($"Moved: {fileName} -> {destinationFolder}");
            }
        }

        DeleteEmptyDirectories(inputFolder);
        Console.WriteLine("Sorting complete.");
    }

    static void DeleteEmptyDirectories(string directory)
    {
        foreach (var dir in Directory.GetDirectories(directory))
        {
            DeleteEmptyDirectories(dir);
            if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
            {
                Directory.Delete(dir);
                Console.WriteLine($"Deleted empty folder: {dir}");
            }
        }
    }
}
