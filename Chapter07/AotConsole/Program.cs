using System.Globalization; // to use CultureInfo.
using System.Reflection;
using System.Reflection.Emit;

WriteLine("This is an ahead-of-time (AOT) compiled console app.");
WriteLine("Current culture: {0}", CultureInfo.CurrentCulture.DisplayName);
WriteLine("OS version: {0}", Environment.OSVersion);

WriteLine("Press any key to exit.");
ReadKey(intercept: true);

// no es compatible con aot por ahora.
// AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(
//   new AssemblyName("MyAssembly"), AssemblyBuilderAccess.Run);
