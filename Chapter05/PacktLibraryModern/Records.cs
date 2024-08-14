namespace Packt.Shared;

public class ImmutablePerson
{
  public string? FirstName { get; init; }
  public string? LastName { get; init; }
}

public record ImmutableVehicle
{
  public int Wheels { get; init; }
  public string? Color { get; init; }
  public string? Brand { get; init; }
}

/*
 Esta es una sintaxis simple que define un record
 que genera automaticamente las propiedades, constructor
 y deconstructor - se llama positional data members in records
*/
public record ImmutableAnimal(string Name, string Species);
