Sort Files is a utility program created to sort through post-recovery directories and organize your files. 

Currently supports these file types: .accdb, .ai, .aif, .amr, .apk, .apple, .asp, .avi, .bat, .bmp, .cab, .c, 
.class, .csv, .db, .deb, .dll, .doc, .docx, .ds_store, .dump, .dxf, .emf, .elf, .eps, .exe, .f, .flac, .gif, 
.go, .gpg, .gz, .h, .heic, .html, .icc, .ico, .inf, .ini, .jar, .java, .jpeg, .jpg, .json, .jsp, .key, .lnk, 
.m4a, .mdb, .mid, .mdl, .mov, .mp3, .mp4, .msg, .one, .pdf, .php, .plist, .pl, .pm, .png, .ppt, .pptx, .psd, 
.pst, .py, .reg, .rtf, .sh, .sqlite, .svg, .swc, .swf, .tib, .tif, .ttf, .txt, .url, .vsd, .vsdx, .wav, .webp, 
.wim, .woff, .wma, .wpd, .xls, .xlsx, .xml, .xmp, .xpi, .zip

The application is easy to expand for new file types in three steps.
1. Add a new string	 string yourFile = Path.Combine(outputFolder, "yourfolder");
2. Add new director         Directory.CreateDirectory(yourFolder);
3. Modify the switch case:  

string destinationFolder = extension switch
	{
	".yourFileType" => yourFolder,
	_ => null
	};
