// See https://aka.ms/new-console-template for more information
#region Exploring unary operators

int a = 3;
int b = a++;
WriteLine($"a is {a}, b is {b}");

int c = 3;
int d = ++c;
WriteLine($"c is {c}, d is {d}");

int e = 11;
int f = 3;

WriteLine($"e is {e}, f is {f}");
WriteLine($"e + f = {e + f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e * f = {e * f}");
WriteLine($"e / f = {e / f}");
WriteLine($"e % f = {e % f}");

double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g / f = {g / f}");


int p = 6;
p += 3;
p -= 3;
p *= 3;
p /= 3;

string? authorName = ReadLine();

// authorName?.Length => type int|null, luego ?? 30
int maxLength = authorName?.Length ?? 30;

// es lo mismo que authorName = authorName ?? "Unknown";
// Algo parecido a javasscript: let authorName = authorName || "Unknown";
authorName ??= "Unknown";

bool q = true;
bool l = false;

WriteLine($"AND   | q     | l     ");
WriteLine($"q     | {q & q, -5} | {q & l, -5}");
WriteLine($"l     | {l & q, -5} | {l & l, -5}");
WriteLine();

WriteLine($"OR    | q     | l     ");
WriteLine($"q     | {q | q, -5} | {q | l, -5}");
WriteLine($"l     | {l | q, -5} | {l | l, -5}");
WriteLine();

WriteLine($"XOR   | q     | l     ");
WriteLine($"q     | {q ^ q, -5} | {q ^ l, -5}");
WriteLine($"l     | {l ^ q, -5} | {l ^ l, -5}");
WriteLine();

static bool DoStuff()
{
  WriteLine("I am doing some stuff.");
  return true;
}

WriteLine();
WriteLine($"q & DoStuff() = {q & DoStuff()}");
WriteLine($"l & DoStuff() = {l & DoStuff()}");

WriteLine();

int age = 50;
WriteLine($"The {nameof(age)} variable uses {sizeof(int)} bytes of memory");

char firstDigit = age.ToString()[0];

object o = "3";
int j = 4;

/*
   esto es pattern matching. nos dice si o es un int, entonces
   dentro del cuerpo if, se va a usar dicho valor con i. Esto mantiene
   cierto grado de seguridad porque ya de por si, me da a entender que i
   es int
*/
if (o is int i)
{
  WriteLine($"{i} x {j} = {i * j}");
}
else
{
  WriteLine($"o is not an int so it canno multiply");
}

#endregion

#region Pattern matching with the switch statement

var animals = new Animal?[]
{
  new Cat
  {
    Name = "Karen",
    Born = new(year: 2022, month: 8, day: 23),
    Legs = 4,
    IsDomestic = true
  },
  null,
  new Cat
  {
    Name = "Mufasa",
    Born = new(year: 1994, month: 6, day: 12)
  },
  new Spider
  {
    Name = "Sid Vicious",
    Born = DateTime.Today,
    IsPoisonous = true
  },
  new Spider
  {
    Name = "Captain Furry",
    Born = DateTime.Today
  }
};

foreach (Animal? animal in animals)
{
  string message;

  switch (animal)
  {
    // aunque when es un poco mas semantico
    // case Cat { Legs: 4 } fourLeggedCat:
    case Cat fourLeggedCat when fourLeggedCat.Legs == 4:
      message = $"The cat named {fourLeggedCat.Name} has four legs.";
      break;
    case Cat wildCat when wildCat.IsDomestic == false:
      message = $"The non-domestic cat is named {wildCat.Name}";
      break;
    case Cat cat:
      message = $"The cat is named {cat.Name}";
      break;
    default:
      message = $"{animal.Name} is a {animal.GetType().Name}";
      break;
    case Spider spider when spider.IsPoisonous:
      message = $"The {spider.Name} spider is poisonous. Run!";
      break;
    case null:
      message = "The animal is null.";
      break;
  }

  message = animal switch
  {
    Cat fourLeggedCat when fourLeggedCat.Legs == 4
      => $"The cat named {fourLeggedCat.Name} has four legs.",
    Cat wildCat when wildCat.IsDomestic == false
      => $"The non-domestic cat is named {wildCat.Name}.",
    Cat cat
      => $"The cat is named {cat.Name}.",
    Spider spider when spider.IsPoisonous
      => $"The {spider.Name} spider is poisonous. Run!",
    null
      => "The animal is null.",
    _ // default case
      => $"{animal.Name} is a {animal.GetType().Name}."
  };

  WriteLine($"switch statement: {message}");
}

#endregion
