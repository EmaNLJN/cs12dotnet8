using Spectre.Console; // to use table.

#region  Handling cross-platform environments and filesystems

SectionTitle("Handling cross-platform environments and filesystems");

// Create a Spectre Console table.
Table table = new();

// Add two columns with markups for colos.
table.AddColumn("[blue]MEMBER[/]");
table.AddColumn("[blue]VALUE[/]");

// add rows.
table.AddRow("Path.PathSeparator", PathSeparator.ToString());
table.AddRow("Path.DirectorySeparatorChar",
  DirectorySeparatorChar.ToString());
table.AddRow("Directory.GetCurrentDirectory()",
  GetCurrentDirectory());
table.AddRow("Environment.CurrentDirectory", CurrentDirectory);
table.AddRow("Environment.SystemDirectory", SystemDirectory);
table.AddRow("Path.GetTempPath()", GetTempPath());
table.AddRow("");
table.AddRow("GetFoldeerPath(SpecialFolder", "");
table.AddRow("   .System)", GetFolderPath(SpecialFolder.System));
table.AddRow("   .ApplicationData)",
  GetFolderPath(SpecialFolder.ApplicationData));
table.AddRow("   .MyDocuments)",
  GetFolderPath(SpecialFolder.MyDocuments));
table.AddRow("   .Personal)",
  GetFolderPath(SpecialFolder.Personal));

// render the table to the console
AnsiConsole.Write(table);

// no funciona, problemas de permisos.
// SectionTitle("Managing drives");

// Table drives = new();

// drives.AddColumn("[blue]NAME[/]");
// drives.AddColumn("[blue]TYPE[/]");
// drives.AddColumn("[blue]FORMAT[/]");
// drives.AddColumn(new TableColumn(
//   "[blue]SIZE (BYTES)[/]").RightAligned());
// drives.AddColumn(new TableColumn(
//   "[blue]FREE SPACE[/]").RightAligned());

// foreach (DriveInfo drive in DriveInfo.GetDrives())
// {
//   if (drive.IsReady)
//   {
//     drives.AddRow(drive.Name, drive.DriveType.ToString(),
//       drive.DriveFormat, drive.TotalSize.ToString("N0"),
//       drive.AvailableFreeSpace.ToString("N0"));
//   }
//   else
//   {
//     drives.AddRow(drive.Name, drive.DriveType.ToString(),
//       string.Empty, string.Empty, string.Empty);
//   }
// }

// AnsiConsole.Write(drives);

SectionTitle("Managing directories");

string newFolder = Combine(
  GetFolderPath(SpecialFolder.Personal), "NewFolder");

WriteLine($"Working with: {newFolder}");
WriteLine($"Does it exist? {Path.Exists(newFolder)}");

WriteLine("Creating it...");
CreateDirectory(newFolder);

WriteLine($"Does it exist? {Path.Exists(newFolder)}");
Write("Confirm the directory exists, and then press any key.");
ReadKey(intercept: true);

WriteLine("Deleting it...");
Delete(newFolder, recursive: true);
WriteLine($"Does it exist? {Path.Exists(newFolder)}");

SectionTitle("Managing files");

string dir = Combine(
  GetFolderPath(SpecialFolder.Personal), "OutputFiles");

CreateDirectory(dir);

// Define file paths.
string textFile = Combine(dir, "Dummy.txt");
string backupFile = Combine(dir, "Dummy.bak");
WriteLine($"Working with: {textFile}");
WriteLine($"Does it exists? {File.Exists(textFile)}");

StreamWriter textWriter = File.CreateText(textFile);
textWriter.WriteLine("Hello, C#!");
textWriter.Close();
WriteLine($"Does it exist? {File.Exists(textFile)}");

File.Copy(sourceFileName: textFile,
  destFileName: backupFile, overwrite: true);

WriteLine(
  $"Does {backupFile} exist? {File.Exists(backupFile)}"
);

Write("Confirm the files exist, and then press any key.");
ReadKey(intercept: true);

File.Delete(textFile);
WriteLine($"Does it exist? {File.Exists(textFile)}");

WriteLine($"Reading contents of {backupFile}");
StreamReader textReader = File.OpenText(backupFile);
WriteLine(textReader.ReadToEnd());
textReader.Close();

SectionTitle("Managing paths");

WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
WriteLine($"File Name: {GetFileName(textFile)}");
WriteLine("File Name without Extension: {0}",
  GetFileNameWithoutExtension(textFile));
WriteLine($"File Extension: {GetExtension(textFile)}");
WriteLine($"Random File Name: {GetRandomFileName()}");
WriteLine($"Temporary File Name: {GetTempFileName()}");

SectionTitle("Getting file information");

FileInfo info = new(backupFile);
WriteLine($"{backupFile}");
WriteLine($"   Contains {info.Length} bytes.");
WriteLine($"   Last accessed: {info.LastAccessTime}.");
WriteLine($"   Has readonly set to {info.IsReadOnly}.");

#endregion

// Recien comienzo "Reading and writing with streams"
