Sort Files is a utility program created to sort through post-recovery directories and organize your files. 

Currently supports these file types: .ai, .amr, .avi, .bmp, .cab, .dll, .docx, .DS_Store, .exe, .f, .font, 
.gif, .gz, .heic, .html, .ico, .inf, .ini, .java, .jpeg, .jpg, .m4a, .mov, .mp3, .msg, .pdf, .plist, .png, 
.psd, .reg, .rtf, .sh, .swf, .txt, .tif, .ttf, .wav, .webp, .wim, .xml, .xlsx, .zip

The application is easy to expand for new file types in three steps.
1. Add a new string	 string yourFile = Path.Combine(outputFolder, "yourfolder");
2. Add new director         Directory.CreateDirectory(yourFolder);
3. Modify the switch case:  

string destinationFolder = extension switch
	{
	".yourFileType" => yourFolder,
	_ => null
	};
