// See https://aka.ms/new-console-template for more information
#region Looping with the while statement

int x = 0;
while (x < 10)
{
  WriteLine(x);
  x++;
}
#endregion

#region Looping with the do statement

string? actualPassword = "1234";
string? password;

do
{
  Write("Enter your password: (hint: 1234)");
  password = ReadLine();
}
while (password != actualPassword);

WriteLine("Correct!");

#endregion

#region Looping with the for statement

for (int y = 1; y <= 10; y++)
{
  WriteLine(y);
}

WriteLine();

for (int y = 0; y <= 10; y += 3)
{
  WriteLine(y);
}

#endregion

#region Looping with the foreach statement

string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
  WriteLine($"{name} has {name.Length} characters.");
}

#endregion
