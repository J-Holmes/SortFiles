Sort Files is a utility program created to sort through post-recovery directories and organize your files. The application is easy to expand for new file types in three steps.

1. Add a new string         string yourFile = Path.Combine(outputFolder, "yourfolder");
2. Add new director         Directory.CreateDirectory(yourFolder);
3. Modify the switch case:  string destinationFolder = extension switch
                                    {
                                        ".jpg" or ".jpeg" or ".png" or ".gif" or ".bmp" or ".tif" or ".heic" or ".svg" or ".ico" => picturesFolder,
                                        ".txt" or ".docx" => textFolder,
                                        ".pdf" => pdfFolder,
                                        ".mp3" or ".wav" or ".amr" or ".m4a" => musicFolder,
                                        ".mp4" or ".mov" or ".avi" => videoFolder,
                                        ".zip" => zipFolder,
                                        ".msg" or ".pst" => emailFolder,
                                        ".html" or ".webp" => htmlFolder,
                                        ".java" or ".h" or ".ai" or ".psd" or ".sqlite" or ".exe" or ".dll" 
                                            or ".xml" or ".reg" or ".ini" or ".cab" or ".inf" 
                                            or ".f" or ".sh" or ".gz" or ".py" 
                                            or ".swf" or ".plist" => softwareDev,
                                        ".DS_Store" => otherFiles,
                                        ".ttf" or ".wim" or ".rtf" => fontFiles,
                                        ".xlsx" => excelFiles,
                                        ".yourFileType" => yourFolder,
                                        _ => null
                                    };
