using Packt.Shared;

int? thisCannotBeNull = 4;
thisCannotBeNull = null;
WriteLine(thisCannotBeNull);

WriteLine(thisCannotBeNull);
WriteLine(thisCannotBeNull.GetValueOrDefault());

thisCannotBeNull = 7;

WriteLine(thisCannotBeNull);
WriteLine(thisCannotBeNull.GetValueOrDefault());

// esto es lo mismo que int? o sea va a ser de tipo Nullable<int>
// nullable es un struct por ende es un value type, y tiene sentido con int
// que tambien es un value type
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

Address address = new(city: "Londong")
{
  Building = null,
  Street = null!,
  Region = "UK"
};

WriteLine(address.Building?.Length);

if (address.Street is not null)
{
  WriteLine(address.Street.Length);
}

string authorName = null;
int? authorNameLength;

// esto tira una excepcion nullreference
authorNameLength = authorName.Length;

// en lugar de tirar la excepcion arriba, le asigna un null
authorNameLength = authorName?.Length;

authorNameLength = authorName?.Length ?? 25;

