string name = "Samantha Jones";

int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

string firstName = name.Substring(
  startIndex: 0, length: lengthOfFirst);

string lastName = name.Substring(startIndex: name.Length - lengthOfLast,
  length: lengthOfLast);

WriteLine($"First: {firstName}, Last: {lastName}");

//Using spans.
ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..]; // ^length comienza a contar desde el ultimo,
// en este caso si lengthOfLast es 4, entonces comienza desde el final
// del arreglo y hace 4 posiciones desde la final hasta final - 4
// o sea final - 4 ... final

WriteLine($"First: {firstNameSpan}, Last: {lastNameSpan}");
