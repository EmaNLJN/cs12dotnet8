// All type in this file will be defined in this filed-scoped namespace.
namespace Packt.Shared;

public class Person : object
{
  #region Fields: Data or state for this person.

  public string? Name;
  public DateTimeOffset Born;
  public WondersOfTheAncientWorld FavoriteAncientWonder;
  public WondersOfTheAncientWorld BucketList;

  public List<Person> Children = new();

  public const string Species = "Homo Sapiens";

  public readonly string HomePlanet = "Earth";
  public readonly DateTime Instantiated;

  #endregion

  #region Constructors: Called when using new to instantiate a type.

  public Person()
  {
    Name = "Unknown";
    Instantiated = DateTime.Now;
  }

  public Person(string initialName, string homePlanet)
  {
    Name = initialName;
    HomePlanet = homePlanet;
    Instantiated = DateTime.Now;
  }

  #endregion
}
