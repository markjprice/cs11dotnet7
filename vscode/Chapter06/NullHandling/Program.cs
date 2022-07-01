int thisCannotBeNull = 4;
//thisCannotBeNull = null; // compile error!
WriteLine(thisCannotBeNull);

int? thisCouldBeNull = null;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

// the actual type of int? is Nullable<int>
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

// Declaring non-nullable variables and parameters

Address address = new()
{
  Building = null,
  Street = null!, // null-forgiving operator
  City = "London",
  Region = "UK"
};

WriteLine(address.Building?.Length);
WriteLine(address.Street.Length);
