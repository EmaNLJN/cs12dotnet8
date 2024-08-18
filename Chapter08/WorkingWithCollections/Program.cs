using System.Collections.Frozen; // to use FrozenDictionary<T, T>
using System.Collections.Immutable; // To use ImmutableDictionary<T, T>
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;

List<string> cities = new();
cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");

OutputCollection("Initial list", cities);
WriteLine($"The first city is {cities[0]}.");
WriteLine($"The last city is {cities[cities.Count - 1]}.");

cities.Insert(0, "Sydney");
OutputCollection("After inserting Sydney at index 0", cities);

cities.RemoveAt(1);
cities.Remove("Milan");
OutputCollection("After removing two cities", cities);

StringDictionary keywords = new();

keywords.Add(key: "int", value: "32-bit integer data type");

keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");

OutputCollection("Dictionary keys", keywords.Keys);
OutputCollection("Dictionary values", keywords.Values);

WriteLine("Keywords and their definitions:");
foreach (KeyValuePair<string, string> item in keywords)
{
  WriteLine($"   {item.Key}: {item.Value}");
}

string key = "long";
WriteLine($"The definition of {key} is {keywords[key]}.");

HashSet<string> names = new();

foreach (string name in new[] { "Adam", "Barry", "Charlie", "Barry" })
{
  bool added = names.Add(name);
  WriteLine($"{name} was added: {added}");
}

WriteLine($"names set: {string.Join(',', names)}.");

Queue<string> coffe = new();

coffe.Enqueue("Damir");
coffe.Enqueue("Andrea");
coffe.Enqueue("Ronald");
coffe.Enqueue("Amin");
coffe.Enqueue("Irina");

OutputCollection("Initial queue from front to back", coffe);

string served = coffe.Dequeue();
WriteLine($"Served: {served}.");

served = coffe.Dequeue();
WriteLine($"Served: {served}.");
OutputCollection("Current queue from front to back", coffe);

WriteLine($"{coffe.Peek()} is next in line.");
OutputCollection("Current queue from front to back", coffe);

PriorityQueue<string, int> vaccine = new();

vaccine.Enqueue("Pamela", 1);
vaccine.Enqueue("Rebecca", 3);
vaccine.Enqueue("Juliet", 2);
vaccine.Enqueue("Ian", 1);

OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

WriteLine("Adding Mark to queue with priority 2.");
vaccine.Enqueue("Mark", 2);

WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

// UseDictionary(keywords);
UseDictionary(keywords.AsReadOnly());
UseDictionary(keywords.ToImmutableDictionary());

ImmutableDictionary<string, string> immutableKeywords =
  keywords.ToImmutableDictionary();

ImmutableDictionary<string, string> newDictionary =
  immutableKeywords.Add(
    key: Guid.NewGuid().ToString(),
    value: Guid.NewGuid().ToString());

OutputCollection("Immutable keywords dictionary", immutableKeywords);
OutputCollection("new keywords dictionary", newDictionary);

FrozenDictionary<string, string> frozenKeywords =
  keywords.ToFrozenDictionary();

OutputCollection("Frozen keywords dictionary", frozenKeywords);

WriteLine($"Define long: {frozenKeywords["long"]}");
// C#11
int[] numbersArray11 = { 1, 3, 5 };
List<int> numbersList11 = new() { 1, 3, 5 };
Span<int> numbersSpan11 = stackalloc int[] { 1, 3, 5 };

// en c#12 se puede inicializar con [] - collection expression
int[] numbersArray12 = [1, 3, 5];
List<int> numbersList12 = [1, 3, 5];
Span<int> numbersSpan12 = [1, 3, 5];
