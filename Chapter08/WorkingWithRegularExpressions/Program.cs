using System.Text.RegularExpressions; // to use regex
Write("Enter your age:");
string input = ReadLine()!;
Regex ageChecker = DigitsOnly();
WriteLine(ageChecker.IsMatch(input) ? "Thank you!" :
  $"This is not a valid age: {input}");

// raw strin literal
string films = """
"Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"
""";

WriteLine($"Films to split: {films}");

string[] filmsDumb = films.Split(',');
WriteLine("Splitting with string.Split method:");
foreach (string film in filmsDumb)
{
  WriteLine($"   {film}");
}

Regex csv = CommaSeparator();

MatchCollection filmsSmart = csv.Matches(films);

WriteLine("Splitting with regular expression:");
foreach (Match film in filmsSmart)
{
  WriteLine($"   {film.Groups[2].Value}");
}
// aprender un poco mas sobre los improvments que se hacen para regex en .net 7
