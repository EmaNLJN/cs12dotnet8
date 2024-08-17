WriteLine("I can run everywhere!");
WriteLine($"Os Version is {Environment.OSVersion}");

if (OperatingSystem.IsMacOS())
{
  WriteLine("I am macOS.");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10, build: 22000))
{
  WriteLine("I am Windows 11");
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10))
{
  WriteLine("I am Windows 10");
}
else if (OperatingSystem.IsLinux())
{
  WriteLine("I am Linux!");
}
else
{
  WriteLine("I am some other mysterious OS.");
}

WriteLine("Press any key to stop me.");
ReadKey(intercept: true); // do not output the key that was pressed.
