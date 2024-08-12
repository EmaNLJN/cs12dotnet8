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

  #endregion
}
