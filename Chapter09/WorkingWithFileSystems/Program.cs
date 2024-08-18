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

#endregion