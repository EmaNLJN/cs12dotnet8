using Packt.Shared;

Person harry = new()
{
  Name = "Harry",
  Born = new(year: 2001, month: 3, day: 25,
    hour: 0, minute: 0, second: 0,
    offset: TimeSpan.Zero)
};

harry.WriteToConsole();

Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

lamech.Marry(adah);

// Person.Marry(lamech, zillah);
if (lamech + zillah)
{
  WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}

lamech.OutputSpouses();
adah.OutputSpouses();

Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

Person baby3 = lamech * adah;
baby3.Name = "Jubal";

Person baby4 = zillah * lamech;
baby4.Name = "Naamah";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

for(int i = 0; i < lamech.Children.Count; i++)
{
  WriteLine(format: "  {0}'s child #{1} is named \"{2}\".",
  arg0: lamech.Name, arg1: i,
  arg2: lamech.Children[i].Name);
}

// non-generic lookup collection
System.Collections.Hashtable lookUpObject = new();
lookUpObject.Add(key: 1, value: "Alpha");
lookUpObject.Add(key: 2, value: "Beta");
lookUpObject.Add(key: 3, value: "Gamma");
lookUpObject.Add(key: harry, value: "Delta");

int key = 2; // look up the value that has 2 as its key.

WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookUpObject[key]);

WriteLine(format: "Key {0} has value: {1}",
  arg0: harry,
  arg1: lookUpObject[harry]);

Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;

WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupIntString[key]);

// asign the method(s) to the Shout event delegate
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;

harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

// repasar events y delegate, es un tema un poco complejo
Person?[] people =
{
  null,
  new() { Name = "Simon" },
  new() { Name = "Jenny" },
  new() { Name = "Adam" },
  new() { Name = null },
  new() { Name = "Richard" }
};

OutputPeopleNames(people, "Initial list of people:");

Array.Sort(people);

OutputPeopleNames(people,
  "After sorting using Person's IComparable implementation:");

Array.Sort(people, new PersonComparer());

OutputPeopleNames(people,
  "After sorting using PersonComparer's IComparer implementation:");

int a = 3;
int b = 3;

WriteLine();
WriteLine($"a: {a}, b: {b}");
WriteLine($"a == b: {a == b}");
WriteLine();

Person p1 = new() { Name = "Kevin" };
Person p2 = new() { Name = "Kevin" };

WriteLine($"p1: {p1}, p2: {p2}");
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1 == p2: {p1 == p2}");

Person p3 = p1;
WriteLine($"p3: {p3}");
WriteLine($"p3.Name: {p3.Name}");
WriteLine($"p1 == p3: {p1 == p3}");

WriteLine();
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1.Name == p2.Name: {p1.Name == p2.Name}");

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;

WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

DisplacementVector dv4 = new();
WriteLine($"({dv4.X}, {dv4.Y})");

DisplacementVector dv5 = new(3, 5);
WriteLine($"dv1.Equals(dv5): {dv1.Equals(dv5)}");
// no tiene == overload porque no lo soporta los struct
// WriteLine($"div1 == dv5: {dv1 == dv5}");
// pero si uso el keyword record, puedo el operador de igualidad
WriteLine($"div1 == dv5: {dv1 == dv5}");

// Tema a profundizar Manejo de memoria, IDisponsable

