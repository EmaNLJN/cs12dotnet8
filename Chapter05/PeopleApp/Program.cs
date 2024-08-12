using Packt.Shared;

ConfigureConsole();

Person bob = new();

WriteLine(bob);

bob.Name = "Bob Smith";

bob.Born = new DateTimeOffset(
  year: 1965, month: 12, day: 22,
  hour: 16, minute: 28, second: 0,
  offset: TimeSpan.FromHours(-5));

WriteLine(format: "{0} was born on {1:D}.",
  arg0: bob.Name, arg1: bob.Born);

Person alice = new()
{
  Name = "Alice Jones",
  Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero)
};

WriteLine(format: "{0} was born on {1:d}.",
  arg0: alice.Name, arg1: alice.Born);


bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

WriteLine(
  format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
  arg0: bob.Name,
  arg1: bob.FavoriteAncientWonder,
  arg2: (int)bob.FavoriteAncientWonder);

bob.BucketList =
  WondersOfTheAncientWorld.HangingGardensOfBabylon
  | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");

Person alfred = new ();
alfred.Name = "Alfred";
bob.Children.Add(alfred);

bob.Children.Add(new Person { Name = "Bella" });

bob.Children.Add(new() { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");

for (int childrenIndex = 0; childrenIndex < bob.Children.Count; childrenIndex++)
{
  WriteLine($"> {bob.Children[childrenIndex].Name}");
}

