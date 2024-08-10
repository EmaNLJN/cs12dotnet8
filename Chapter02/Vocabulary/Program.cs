// See https://aka.ms/new-console-template for more information
// #error version

// #region Three variables that store the number 2 million.

// int decimalNotation = 2_000_000;
// int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
// int hexadecimalNotation = 0x_001E_8480;

// #endregion

// WriteLine($"Computer named {Env.MachineName} says \"No.\"");

// WriteLine();

// WriteLine("Hello Ahmed");

// WriteLine(
//   "Temperature on {0:D} is {1}°C", DateTime.Today, 23.4
// );

using System.Reflection;

Assembly? myApp = Assembly.GetEntryAssembly();

if (myApp is null) return;

foreach (AssemblyName name in myApp.GetReferencedAssemblies())
{
  Assembly a = Assembly.Load(name);

  int methodCount = 0;

  foreach (TypeInfo t in a.DefinedTypes)
  {
    methodCount += t.GetMethods().Length;
  }

  WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.",
    arg0: a.DefinedTypes.Count(),
    arg1: methodCount,
    arg2: name.Name
  );
}

/*
  Dynamic types are most useful when interoperating with non-.NET systems. For example,
  you might need to work with a class library written in F#, Python, or some JavaScript.
  You might also need to interop with technologies like the Component Object Model (COM),
  for example, when automating Excel or Word.
*/
dynamic something;

something = new[] { 3, 5, 7 };

something = 12;

WriteLine(something.GetType());

/*
  using target-typed new to instantiate objects
*/
DateTime timeNow = new();

WriteLine($"Horario actual: {timeNow}");

/* nullish type */
string? firstName = ReadLine();
WriteLine($"Nombre: {firstName}");
// null-forgiving operator
string age = ReadLine()!;
WriteLine($"Este valor jamas sera nulo: {age}");


WriteLine("Press any key combination: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
  arg0: key.Key,
  arg1: key.KeyChar,
  arg2: key.Modifiers
);