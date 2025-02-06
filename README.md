Sort Files is a utility program created to sort through post-recovery directories and organize your files. 

The application is easy to expand for new file types in three steps.
1. Add a new string	 string yourFile = Path.Combine(outputFolder, "yourfolder");
2. Add new director         Directory.CreateDirectory(yourFolder);
3. Modify the switch case:  

string destinationFolder = extension switch
	{
	".yourFileType" => yourFolder,
	_ => null
	};
