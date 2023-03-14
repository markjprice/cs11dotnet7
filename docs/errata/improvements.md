**Improvements** (22 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs11dotnet7/issues) or email me at markjprice (at) gmail.com.

- [Page 69 - Raw interpolated string literals](#page-69---raw-interpolated-string-literals)
- [Page 86 - Getting text input from the user](#page-86---getting-text-input-from-the-user)
- [Page 128 - Rounding numbers](#page-128---rounding-numbers)
- [Page 149 - Writing a times table function](#page-149---writing-a-times-table-function)
- [Page 153 - Writing a function that returns a value](#page-153---writing-a-function-that-returns-a-value)
- [Page 161 - Using lambdas in function implementations](#page-161---using-lambdas-in-function-implementations)
- [Page 179 - Reviewing project packages](#page-179---reviewing-project-packages)
- [Page 200 - Talking about OOP](#page-200---talking-about-oop)
- [Page 237 - Implementing functionality using methods](#page-237---implementing-functionality-using-methods)
- [Page 241 - Defining flight passengers](#page-241---defining-flight-passengers)
- [Page 251 - Setting up a class library and console application](#page-251---setting-up-a-class-library-and-console-application)
- [Page 299 - Treating warnings as errors](#page-299---treating-warnings-as-errors)
- [Page 444 - Connecting to a database](#page-444---connecting-to-a-database)
- [Page 453 - Scaffolding models using an existing database](#page-453---scaffolding-models-using-an-existing-database)
- [Page 533 - Building websites using ASP.NET Core](#page-533---building-websites-using-aspnet-core)
- [Page 547 - Creating a class library for a Northwind database context](#page-547---creating-a-class-library-for-a-northwind-database-context)
- [Page 551 - Creating a class library for entity models using SQL Server](#page-551---creating-a-class-library-for-entity-models-using-sql-server)
- [Page 573 - Adding code to a Razor Page](#page-573---adding-code-to-a-razor-page)
- [Page 586 - Creating a Razor class library, Page 587 - Implementing a partial view to show a single employee](#page-586---creating-a-razor-class-library-page-587---implementing-a-partial-view-to-show-a-single-employee)
- [Page 601 - Setting up an ASP.NET Core MVC website](#page-601---setting-up-an-aspnet-core-mvc-website)
- [Page 654 - Making controller action methods asynchronous](#page-654---making-controller-action-methods-asynchronous)
- [Page 655 - Exercise 14.2 – Practice implementing MVC by implementing a category detail page](#page-655---exercise-142--practice-implementing-mvc-by-implementing-a-category-detail-page)

# Page 69 - Raw interpolated string literals

> Thanks to [Mahdi Jaberzadeh Ansari](https://github.com/mjza) who raised this issue on [6 March 2023](https://github.com/markjprice/cs11dotnet7/issues/36).

In the example JSON used to illustrate a raw interpolated string literal, the comma after `"calculation"` should be a colon. Since we never use the JSON, it doesn't actually matter, but it would definitely be better as valid JSON, as shown in the following code: 
```cs
var person = new { FirstName = "Alice", Age = 56 };

string json = $$"""
              {
                "first_name": "{{person.FirstName}}",
                "age": {{person.Age}},
                "calculation": {{{ 1 + 2 }}}"
              }
              """;

Console.WriteLine(json);
```
And therefore the output should be:
```
{
 "first_name": "Alice",
 "age": 56,
 "calculation": "{3}"
}
```

# Page 86 - Getting text input from the user

In Step 1, I note that the `ReadLine` method is declared to return `string?`, meaning that it could return a `null` value instead of a `string` value (including an empty one). I also note that this is treated as a warning by the compiler. 

In the next edition, I will add a note to explain that this method never actually returns `null` so there is no point in checking for that in functional code. A more useful check is `string.IsNullOrEmpty` so I will add more steps to show how to use that method and `string.IsNullOrWhiteSpace` to validate text input. 

# Page 128 - Rounding numbers

In this section, I wrote about rounding rules as taught in schools and compare them to rounding rules when using C# and .NET. In schools, children are introduced to rounding rules with positive numbers and so learn the term "rounding up" and "rounding down". I did not explicitly say that for negative numbers, those terms would be reversed which can be confusing, so those terms should be avoided. This is why the .NET API uses the enum values `AwayFromZero`, `ToZero`, `ToEven`, `ToPositiveInfinity` and `ToNegativeInfinity` for improved clarity. In the next edition I will add a note about this.

# Page 149 - Writing a times table function

In Step 4, in the `Program.Functions.cs` file, you are told to write the following code:
```cs
partial class Program
{
  static void TimesTable(byte number, byte size = 12)
  {
    WriteLine($"This is the {number} times table with {size} rows:");

    for (int row = 1; row <= size; row++)
    {
      WriteLine($"{row} x {number} = {row * number}");
    }
    WriteLine();
  }
}
```

If you use Visual Studio 2022 to create the `Program.Functions.cs` file from the **Class** project item template, then it wraps the class definition in a namespace (and imports some unnecessary namespaces), for example:
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingFunctions
{
  internal class Program
  {
  }
}
```
The namespace used by the `Program` class generated for the `Program.cs` file does not have a namespace (literally uses the `null` value for the name of its namespace), so the two `Program` classes never merge together as two `partial` definitions of a single class. 

You must delete the namespace declaration so that the `partial Program` class in the `Program.Functions.cs` file is in the same `null` namespace. 

In the next edition I will add a note explaining this, and I will change the Step 4 text to read: "In `Program.Functions.cs`, replace any existing code with new statements to define a function named `TimesTable` in the `partial Program` class, ..."

You can output the namespace of the `Program` class by getting the `Program` type information and checking if its `Namespace` property is `null`, as shown in the following code:
```cs
WriteLine($"typeof(Program).Namespace: {typeof(Program).Namespace ?? "null"}");
```

# Page 153 - Writing a function that returns a value

At the end of this section there is a note box that explains that we could use the `C` format code to format the output as currency. If you are running on a computer in a culture that uses Euros then to show the Euro currency symbol you must enable UTF-8 encoding. 

Add the following statement near the top of the code file before doing any writing to the console:

```cs
Console.OutputEncoding = System.Text.Encoding.UTF8;
```

# Page 161 - Using lambdas in function implementations

> Thanks to [Masoud Nazari](https://github.com/MAS-OUD) for raising this [issue on 8 March 2023](https://github.com/markjprice/cs11dotnet7/issues/39).

In the next edition, I will expand on the definition of **Immutability** e.g. a data value that cannot change. I will also note that C# `record` types are not necessarily immutable.

# Page 179 - Reviewing project packages

In Step 1, the instruct the reader to add references to four packages, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration"
    Version="7.0.0" />
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="7.0.0" />
  <PackageReference
    Include="Microsoft.Extensions.Configuration.FileExtensions"
    Version="7.0.0" />
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Json"
    Version="7.0.0" />
 </ItemGroup>
```

Due to transitive dependencies, you only actually need to explicitly reference two of the packages, as shown in the following markup:
```xml
<ItemGroup>
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Binder"
    Version="7.0.0" />
  <PackageReference
    Include="Microsoft.Extensions.Configuration.Json"
    Version="7.0.0" />
 </ItemGroup>
```

In Step 4, I tell Visual Studio 2022 readers to select the `appsettings.json` file and change its **Copy to Output Directory** to **Copy if newer**. To confirm this is done correctly, in the next edition, I will then tell them to review the change that was made to the project file, as shown in the following markup:
```xml
<ItemGroup>
  <None Update="appsettings.json">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

# Page 200 - Talking about OOP

In the next edition, I will add a summary table of the different categories of type and their capabilities, as well as several paragraphs of explanation. Parts of it might go at the start of Chapter 5 as an introduction but most of it is likely to go at the end of Chapter 6 as a review that brings together all the details from the two chapters.

|Type|Can be instantiated with `new`|Can be inherited from with `:`|Multiple inheritance|
|---|---|---|---|
|`class`|Yes|Yes|No|
|`sealed class`|Yes|No|No|
|`abstract class`|No|Yes|No|
|`interface`|No|Yes|Yes|
|`struct`|Yes|No|No|

For me, the terms *inherit* and *implement* are different, and in the early days of C# and .NET you could strictly apply them to classes and interfaces respectfully. *Inherit* implies some functionality that a sub class gets "for free" from its base aka super class. *Implement* implies some functionality that is NOT inherited but instead MUST be provided by the sub class. This is why **Chapter 6** is titled, **Implementing Interfaces and Inheriting Classes**.

Before C# 8, interfaces were always purely contracts i.e. there was no functionality that you could *inherit*. In those days, you could strictly use the term *implement* for an interface that represents a list of members that your type must implement, and *inherit* for classes with functionality that your type can inherit and potentially override. 

With C# 8, interfaces can now include default implementations, making them more like abstract classes, and the term *inherit* for an interface that has default implementations does make sense. But I feel uncomfortable with this capability as do many other .NET developers because it messes up what used to be a clean language design.

Classes can also have `abstract` members, for example, methods or properties without any implementation, just like an interface could have. When a sub class inherits from this class, they MUST provide an implementation of those abstract members. And the base class must be decorated with the `abstract` keyword to prevent it being instantiated using `new` because it is missing some functionality.

```cs
// To simplify the examples, I have left out access modifiers.
// Using "I" as a prefix for interfaces is a convention not a requirement.
// It is useful since only interfaces support multiple inheritance.

interface IAlpha { void M1(); } // These are both "classic" interfaces in that they are pure contracts.
interface IBeta { void M2(); } // No functionality, just the signatures of members that must be implemented.

// A type (in this example a struct) implementing an interface.
// ": IAlpha" means Gamma promises to implement all members of IAlpha.
// "void M1() { }" is that minimum implementation.
struct Gamma : IAlpha { void M1() { } } 

// A type (in this example a class) implementing two interfaces.
class Delta : IAlpha, IBeta { void M1() { } void M2() { } } 

// A sub class inheriting from a base aka super class.
// ": Delta" means inherit all members from Delta.
class Episilon : Delta { } 

// A class with one inheritable method and one abstract method that must be implemented in sub classes.
// A class with at least one abstract member must be decorated with the abstract keyword to prevent instantiation.
abstract class Zeta { void M3() { } abstract void M4(); }

// A class inheriting the M3 method but must provide an implementarion for M4.
class Eta : Zeta { void M4() { } }

// In C# 8 and later, interfaces can have default implementatations as well as members that must be implemented.
interface ITheta { void M3() { } void M4(); }

// A class inheriting the default implementation from an interface and must provide an implementation for M4.
class Iota : ITheta { void M4() { } }
```

# Page 237 - Implementing functionality using methods

> Thanks to [Masoud Nazari](https://github.com/MAS-OUD) for raising this [issue on 5 March 2023](https://github.com/markjprice/cs11dotnet7/issues/35).

In Step 4, I tell the reader to write some code that uses the `??` operator. But I do not explain how this operator works until later in the book, on page 282, as shown in the following text and code example:

"Sometimes, you want to either assign a variable to a result or use an alternative value, such as `3`, if the 
variable is `null`. You do this using the **null-coalescing operator**, `??`, as shown in the following code:
```cs
// result will be 3 if authorName?.Length is null 
int result = authorName?.Length ?? 3; 
Console.WriteLine(result);
```

In the 8th edition, I will add a similar explanation of the operator `??` to the **Chapter 3, Operating on variables** section.

# Page 241 - Defining flight passengers

> Thanks to [Masoud Nazari](https://github.com/MAS-OUD) for raising this [issue on 8 March 2023](https://github.com/markjprice/cs11dotnet7/issues/38).

In Step 1, you are told to add a new file named `FlightPatterns.cs`. If you use Visual Studio 2022, then this file will contain a class named `FlightPatterns`. 

In Step 2, you are given the complete code for that file that defines a file-scoped namespace named `Packt.Shared` with several classes like `Passenger` in it. If you define those classes inside the Visual Studio-generated `FlightPatterns` class then you will later have problems referencing the nested classes. 

In the next edition, I will add a note for Visual Studio readers to explicitly tell them to delete the class named `FlightPatterns` as well as providing the complete code for the `FlightPatterns.cs` file.

# Page 251 - Setting up a class library and console application

In Step 8, I wrote, "Run the `PeopleApp` project". 

In Chapter 1, I explain how to control which project starts when a Visual Studio 2022 solution contains multiple projects by setting the startup project. In Chapters 2 to 5, I remind the reader to set the startup project. 

In the 8th edition, I will add the same reminder to Chapter 6 as well, for example:

8. Set the `PeopleApp` project as the startup/active project:
    a) If you are using Visual Studio 2022, set the startup project for the solution to the current selection.
    b) If you are using Visual Studio Code, select `PeopleApp` as the active OmniSharp project. When you see the pop-up warning 
message saying that required assets are missing, click Yes to add them.
9. Run the `PeopleApp` project and note the result, as shown in the following output:
```
Harry was born on a Sunday.
```

# Page 299 - Treating warnings as errors

This section shows how to follow best practice and treat warnings as errors. But doing so means you must write extra code in common scenarios to fix all warnings that will now be treated as errors that prevent compilation during the build process.

So this section also shows how to disable some common warnings by adding extra code. The project is NOT designed to be run. The code in it is written only to illustrate some common warnings and how to disable them to allow a build. 

For example, one warning is caused by the compiler thinking there could be a null dereference. To disable the warning, you therefore need to check for a `null` value *even though we know that can never actually happen* as explained in the note. That extra code check is pointless if you run the console app and expect it to work correctly. 

In the next edition, I will add another note to explicitly tell the reader not to run the project. The project implementation is not written to actually function as a check if someone has entered their name because that's not the point of this section. I will also simplify the code.

Current code:
```cs
if (name == null)
{
  Console.WriteLine("You did not enter a name.");
  return;
}
```
Code in next edition:
```cs
if (name == null) return; // must check for null to remove the warning
```

# Page 444 - Connecting to a database

I wrote, "To connect to a SQLite database, we just need to know the database filename, set using the parameter `Filename`." 

In the next edition I will change this to, "To connect to a SQLite database, we just need to know the path to the database, set using the modern parameter named `Data Source` or the legacy parameter named `Filename`. The path can be relative to the current directory or an absolute path."

Throughout the rest of the book, I will replace the `Filename` parameter with `Data Source` for consistency with modern parameters. For example on pages 445, 453, 456, 464, 504, 541, and 547.

# Page 453 - Scaffolding models using an existing database

In Step 2, I show text that must be entered as a single line at the command-line, as shown in the following command formatted as in the print book:
```
dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.
EntityFrameworkCore.Sqlite --table Categories --table Products --output-
dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-
annotations --context Northwind
```

I recommend that you type from the print book or copy and paste long commands like this from the eBook into a plain text editor like Notepad. Then make sure that the whole command is properly formatted as a single line with correct spacing, before you then copy and paste it to the command-line. Copying and pasting directly from the eBook is likely to include newline characters and missing spaces and so on that break the command.

For convenience, here is the same command as a single line to make it easier to copy and paste:
```
dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace WorkingWithEFCore.AutoGen --data-annotations --context Northwind
```

# Page 533 - Building websites using ASP.NET Core

In this section, I introduce the various technologies like Razor Pages, MVC, and Blazor that are included with ASP.NET Core.

In the next edition, I will add a section with a table summarizing the file types used by these technologies because they are similar but different and if the reader does not understand some subtle but important differences, it can cause much confusion when trying to implement their own projects.

|Technology|Special filename|File extension|Directive|
|---|---|---|---|
|Razor Component (for Blazor)||`.razor`|None|
|Razor Component (for Blazor with page routing)||`.razor`|`@page`|
|Razor Page||`.cshtml`|`@page`|
|Razor View (for MVC)||`.cshtml`|None|
|Razor Layout||`.cshtml`|None|
|Razor View Start|`_ViewStart`|`.cshtml`|None|
|Razor View Imports|`_ViewImports`|`.cshtml`|None|

A **Razor Layout** file like `_MyCustomLayout.cshtml` is identical to a **Razor View**. What makes it a layout is being set as the `Layout` property of another Razor file, as shown in the following code:
```cs
@{
  Layout = "_MyCustomLayout";
}
```

> **Warning!** Be careful to use the correct file extension and directive at the top of the file or you will get unexpected behavior.

![Visual Studio 2022 Razor project item types](images/razor-file-types.png)

# Page 547 - Creating a class library for a Northwind database context

In Step 8, you write code to implement the `OnConfiguring` method so that it sets the Filename path to the SQLite database file correctly when running in both Visual Studio 2022 and at the command-line with Visual Studio Code, as shown in the following code:
```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
  if (!optionsBuilder.IsConfigured)
  {
    string dir = Environment.CurrentDirectory;
    string path = string.Empty;

    if (dir.EndsWith("net7.0"))
    {
      // Running in the <project>\bin\<Debug|Release>\net7.0 directory.
      path = Path.Combine("..", "..", "..", "..", "Northwind.db");
    }
    else
    {
      // Running in the <project> directory.
      path = Path.Combine("..", "Northwind.db");
    }

    optionsBuilder.UseSqlite($"Filename={path}");
  }
}
```

In the next edition, it will be improved in two ways. First, by defining a string value once for the database name, and second, by checking that the database file exists and throwing an exception if it does not, as shown in the following code:
```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
  string databaseName = "Northwind.db";

  if (!optionsBuilder.IsConfigured)
  {
    string dir = Environment.CurrentDirectory;
    string path = string.Empty;

    if (dir.EndsWith("net7.0"))
    {
      // Running in the <project>\bin\<Debug|Release>\net7.0 directory.
      path = Path.Combine("..", "..", "..", "..", databaseName);
    }
    else
    {
      // Running in the <project> directory.
      path = Path.Combine("..", databaseName);
    }

    path = Path.GetFullPath(path); // Convert to absolute path.
    WriteLine($"Database path: {path}");

    if (!File.Exists(path))
    {
      throw new FileNotFoundException(
        message: $"{path} not found.", fileName: path);
    }

    optionsBuilder.UseSqlite($"Filename={path}");
  }
}
```

> After converting the relative path to an absolute path, you can set a breakpoint to more easily see where the database file is expected to be, or add a statement to log that path.

The throwing of the exception is important because if the database file is missing, then the SQLite database provider will create an empty database file, and so if you test connecting to it, it works! But if you query it then you will see an exception related to missing tables because it does not have any tables! 

On page 553, we write some unit tests for this class and for SQLite the first test seems to work even when the path is actually wrong due to this issue. By adding code to throw an exception if the database file is missing, this test will now correctly fail.

In Step 11, in the `NorthwindContextExtensions.cs` file, we should also use a dynamically constructed string for the `AddNorthwindContext` method, as shown in the following code:
```cs
public static IServiceCollection AddNorthwindContext(
  this IServiceCollection services, 
  string relativePath = "..", 
  string databaseName = "Northwind.db")
{
  string path = Path.Combine(relativePath, databaseName);
  path = Path.GetFullPath(path);
  WriteLine($"Database path: {path}");

  if (!File.Exists(path))
  {
    throw new FileNotFoundException(
      message: $"{path} not found.", fileName: path);
  }

  services.AddDbContext<NorthwindContext>(options =>
  {
    // Data Source is the modern equivalent of Filename.
    options.UseSqlite($"Data Source={path}");

    options.LogTo(WriteLine, // Console
      new[] { Microsoft.EntityFrameworkCore
        .Diagnostics.RelationalEventId.CommandExecuting });
  });

  return services;
}
```

# Page 551 - Creating a class library for entity models using SQL Server

In Step 14, I tell the reader, "In the `Northwind.Common.DataContext.SqlServer` project, in `NorthwindContext.cs`, remove 
the compiler warning about the connection string."

It would be an improvement to also replace the hard-coded string value used for the database connection string with a dynamically constructed string using the `SqlConnectionStringBuilder` class, as shown in the following code:
```cs
// At the top of the NorthwindContext.cs file.
using Microsoft.Data.SqlClient; // SqlConnectionStringBuilder
```
The `OnConfiguring` method:
```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
  if (!optionsBuilder.IsConfigured)
  {
    SqlConnectionStringBuilder builder = new();

    builder.DataSource = "."; // "ServerName\InstanceName" e.g. @".\sqlexpress"
    builder.InitialCatalog = "Northwind";
    builder.IntegratedSecurity = true;
    builder.TrustServerCertificate = true;
    builder.MultipleActiveResultSets = true;
    builder.ConnectTimeout = 3; // Because we want to fail fast. Default is 15 seconds.

    optionsBuilder.UseSqlServer(builder.ConnectionString);
  }
}

```

In Step 15, in the `NorthwindContextExtensions.cs` file, we should also use a dynamically constructed string using the `SqlConnectionStringBuilder` class, as shown in the following code:
```cs
// At the top of the NorthwindContextExtensions.cs file.
using Microsoft.Data.SqlClient; // SqlConnectionStringBuilder
```
The `AddNorthwindContext` method:
```cs
public static IServiceCollection AddNorthwindContext(
  this IServiceCollection services,
  string? connectionString = null)
{
  if (connectionString == null)
  {
    SqlConnectionStringBuilder builder = new();

    builder.DataSource = "."; // "ServerName\InstanceName" e.g. @".\sqlexpress"
    builder.InitialCatalog = "Northwind";
    builder.IntegratedSecurity = true;
    builder.TrustServerCertificate = true;
    builder.MultipleActiveResultSets = true;
    builder.ConnectTimeout = 3; // Because we want to fail fast. Default is 15 seconds.

    connectionString = builder.ConnectionString;
  }

  services.AddDbContext<NorthwindContext>(options =>
  {
    options.UseSqlServer(connectionString);

    options.LogTo(WriteLine, // Console
      new[] { Microsoft.EntityFrameworkCore
        .Diagnostics.RelationalEventId.CommandExecuting });
  });

  return services;
}
```

# Page 573 - Adding code to a Razor Page

This section starts with a description of Razor Pages. The first bullet point says, "They require the `@page` directive at the top of the file."

In the next edition, I will add a warning, as shown in the following note:

> **Warning!** *Razor Pages* are different from *Razor Views* (used in ASP.NET Core MVC) but they share the same file extension `.cshtml`. When creating a *Razor View*, do NOT use the `@page` directive!

# Page 586 - Creating a Razor class library, Page 587 - Implementing a partial view to show a single employee

In these sections you create two files named `Employees.cshtml` and `_Employee.cshtml`. To make it clearer how they are related, what they do, and what their names mean, in the next edition, I will tell the reader to create the partial view that shows a single employee first and keep its name as `_Employee.cshtml`. Then I will tell the reader to create the Razor Page that uses that partial view but name it `EmployeesList.cshtml`. 

# Page 601 - Setting up an ASP.NET Core MVC website

This section starts with a description of the three parts of MVC. For views, I wrote, "**Views**: Razor files, that is, `.cshtml` files, that render data in view models into HTML web pages. Blazor uses the `.razor` file extension, but do not confuse them with Razor files!"

In the next edition, I will improve this text and add a warning:

"**Views**: *Razor View* files, that is, `.cshtml` files, that render data in view models into HTML web pages. *Razor Views* are different from *Razor Pages* but they share the same file extension `.cshtml`. When creating a *Razor Page*, it must have the `@page` directive at the top of its file. When creating a *Razor View*, do NOT use the `@page` directive! If you do, the controller will not pass the model and it will be `null`, throwing a `NullReferenceException` when you try to access any of its members. Also note that Blazor uses the `.razor` file extension, but do not confuse them with *Razor View* or *Razor Page* files! To add even more confusion, Blazor can also use the `@page` directive to allow a Blazor component to act like a page!"

# Page 654 - Making controller action methods asynchronous

In an earlier task, you imported the `Microsoft.EntityFrameworkCore` namespace so that you could use the `Include` extension method. In Step 1, I tell you to use the `ToListAsync` method to implement the `Index` action method asynchronously. If you had not previously imported the `Microsoft.EntityFrameworkCore` namespace then you would have to import it now to use the `ToListAsync` method. 

In the next edition, I will add a comment to make this more obvious, as shown in the following code:

```cs
using Microsoft.EntityFrameworkCore; // To use the Include and ToListAsync extension methods.
```

# Page 655 - Exercise 14.2 – Practice implementing MVC by implementing a category detail page

Earlier in the chapter, and in Exercise 14.2, the link generated for a category detail page looks like this:
```
https://localhost:5001/category/1
```

Although it is possible to configure a route to respond to that format of link, it would be easier if the link used the following format:
```
https://localhost:5001/home/categorydetail/1
```

In `Index.cshtml`, change how the links are generated to match the improved format, as shown in the following markup:
```xml
<a class="btn btn-primary"
  href="/home/categorydetail/@Model.Categories[c].CategoryId">View</a>
```

This would then allow you to add an action method to the `HomeController` class as shown in the following code:
```cs
public async Task<IActionResult> CategoryDetail(int? id)
{
  if (!id.HasValue)
  {
    return BadRequest("You must pass a category ID in the route, for example, /Home/CategoryDetail/6");
  }

  Category? model = await db.Categories.Include(p => p.Products)
    .SingleOrDefaultAsync(p => p.CategoryId == id);

  if (model is null)
  {
    return NotFound($"CategoryId {id} not found.");
  }

  return View(model); // pass model to view and then return result
}
```

And create a view that matches the name `CategoryDetail.cshtml`, as shown in the following markup:
```xml
@model Packt.Shared.Category 
@{
  ViewData["Title"] = "Category Detail - " + Model.CategoryName;
}
<h2>Category Detail</h2>
<div>
  <dl class="dl-horizontal">
    <dt>Category Id</dt>
    <dd>@Model.CategoryId</dd>
    <dt>Product Name</dt>
    <dd>@Model.CategoryName</dd>
    <dt>Products</dt>
    <dd>@Model.Products.Count</dd>
    <dt>Description</dt>
    <dd>@Model.Description</dd>
  </dl>
</div>
```

> Note: You could also use the simpler link format `https://localhost:5001/home/category/1` but then both the action method and the view filename must be just `Category` instead of `CategoryDetail`.

If you want to keep the original link format, then you would need to decorate the action method as shown in the following code:
```cs
[Route("category/{id}")]
public async Task<IActionResult> CategoryDetail(int? id)
```
