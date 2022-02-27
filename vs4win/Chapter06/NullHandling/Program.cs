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

Address address = new();
address.Building = null;
address.Street = null!; // null-forgiving operator
address.City = "London";
address.Region = "UK";

WriteLine(address.Building?.Length);
WriteLine(address.Street.Length);
