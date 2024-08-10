// See https://aka.ms/new-console-template for more information
#region Casting numbers implicitly and explicitly

using System.Globalization;

int a = 10;
double b = a;
WriteLine($"a is {a}, b is {b}");

double c = 9.8;
int d = (int)c;
WriteLine($"c is {c}, d is {d}");

long e = 10;
int f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

// e = long.MaxValue;
e = 5_000_000_000;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");
WriteLine();
WriteLine("{0, 12} {1, 34}", "Decimal", "Binary");
WriteLine("{0, 12} {0, 34:B32}", int.MaxValue);

// representacion commplemento a dos.
for (int i = 8; i >= -8; i--)
{
  WriteLine("{0, 12} {0, 34:B32}", i);
}

WriteLine("{0, 12} {0, 34:B32}", int.MinValue);

#endregion

#region Converting with the System.Convert type

double g = 9.8;

/*
La diferencia entre castear un tipo a convertirlo, es castear dropea la parte
 de punto flotante, o sea, hay truncamiento.
 En el caso de usasr Convert, el valor se redondea para arriba.
*/

int h = ToInt32(g);
WriteLine($"g is {g}, h is {h}");

#endregion

#region Rounding numbers and the default rounding rules

double[,] doubles = {
  { 9.49, 9.5, 9.51 },
  { 10.49, 10.5, 10.51 },
  { 11.49, 11.5, 11.51 },
  { 12.49, 12.5, 12.51 },
  { -12.49, -12.5, -12.51 },
  { -11.49, -11.5, -11.51 },
  { -10.49, -10.5, -10.51 },
  { -9.49, -9.5, -9.51 }
};

// este ejemplo usa la regla de redondeo bancario - ver luego
WriteLine($"| double | ToInt32 | double | ToInt32 | double | ToInt32 |");
for (int x = 0; x < 8; x++)
{
  for (int y = 0; y < 3; y++)
  {
    Write($"| {doubles[x, y], 6} | {ToInt32(doubles[x, y]), 7}");
  }
  WriteLine("|");
}
WriteLine();

foreach (double n in doubles)
{
  WriteLine(format:
    "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
    arg0: n,
    arg1: Math.Round(value: n, digits: 0,
      mode: MidpointRounding.AwayFromZero
    )
  );
}
WriteLine();

#endregion

#region Converting from any type to a string

int number = 12;
WriteLine(number.ToString());

bool boolean = true;
WriteLine(boolean.ToString());

DateTime now = DateTime.Now;
WriteLine(now.ToString());

object me = new();
WriteLine(me.ToString());

#endregion

#region Converting from a binary object to a string
byte[] binaryObject = new byte[128]; // 128 bytes

Random.Shared.NextBytes(binaryObject);

WriteLine("Binary Object as bytes:");
for (int index = 0; index < binaryObject.Length; index++)
{
  Write($"{binaryObject[index]:X2} ");
}
WriteLine();

string encoded = ToBase64String(binaryObject);
WriteLine($"Binary Object as Base64: {encoded}");

WriteLine();
#endregion

#region Parsing from strings to numbers or dates and times

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

int friends = int.Parse("27");
DateTime birthday = DateTime.Parse("4 June 1980");

WriteLine($"I have {friends} friends to invite to my party.");
WriteLine($"My birthday is {birthday}.");
WriteLine($"My birthday is {birthday:D}.");
// Parse produce una excepcion, para evitar una excepcion, pusemos TryParse
#endregion

#region Avoiding Parse exceptions by using the TryParse method

Write("How many eggs are there? ");
string? input = ReadLine();

if (int.TryParse(input, out int count))
{
  WriteLine($"There are {count} eggs.");
}
else
{
  WriteLine("I could not parse the input.");
}

#endregion

#region Understanding the Try method naming convention

// int number = int.Parse("123");

// bool success = int.TryParse("123", out int number);

// bool success = Uri.TryCreate("https://www.google.com.ar",
//   UriKind.Absolute, out Uri? serviceUrl);
#endregion
