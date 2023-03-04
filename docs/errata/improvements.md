**Improvements** (13 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs11dotnet7/issues) or email me at markjprice (at) gmail.com.

- [Page 86 - Getting text input from the user](#page-86---getting-text-input-from-the-user)
- [Page 128 - Rounding numbers](#page-128---rounding-numbers)
- [Page 153 - Writing a function that returns a value](#page-153---writing-a-function-that-returns-a-value)
- [Page 179 - Reviewing project packages](#page-179---reviewing-project-packages)
- [Page 251 - Setting up a class library and console application](#page-251---setting-up-a-class-library-and-console-application)
- [Page 299 - Treating warnings as errors](#page-299---treating-warnings-as-errors)
- [Page 453 - Scaffolding models using an existing database](#page-453---scaffolding-models-using-an-existing-database)
- [Page 547 - Creating a class library for a Northwind database context](#page-547---creating-a-class-library-for-a-northwind-database-context)
- [Page 551 - Creating a class library for entity models using SQL Server](#page-551---creating-a-class-library-for-entity-models-using-sql-server)
- [Page 573 - Adding code to a Razor Page](#page-573---adding-code-to-a-razor-page)
- [Page 601 - Setting up an ASP.NET Core MVC website](#page-601---setting-up-an-aspnet-core-mvc-website)
- [Page 654 - Making controller action methods asynchronous](#page-654---making-controller-action-methods-asynchronous)
- [Page 655 - Exercise 14.2 – Practice implementing MVC by implementing a category detail page](#page-655---exercise-142--practice-implementing-mvc-by-implementing-a-category-detail-page)

# Page 86 - Getting text input from the user

In Step 1, I note that the `ReadLine` method is declared to return `string?`, meaning that it could return a `null` value instead of a `string` value (including an empty one). I also note that this is treated as a warning by the compiler. 

In the next edition, I will add a note to explain that this method never actually returns `null` so there is no point in checking for that in functional code. A more useful check is `string.IsNullOrEmpty` so I will add more steps to show how to use that method and `string.IsNullOrWhiteSpace` to validate text input. 

# Page 128 - Rounding numbers

In this section, I wrote about rounding rules as taught in schools and compare them to rounding rules when using C# and .NET. In schools, children are introduced to rounding rules with positive numbers and so learn the term "rounding up" and "rounding down". I did not explicitly say that for negative numbers, those terms would be reversed which can be confusing, so those terms should be avoided. This is why the .NET API uses the enum values `AwayFromZero`, `ToZero`, `ToEven`, `ToPositiveInfinity` and `ToNegativeInfinity` for improved clarity. In the next edition I will add a note about this.

# Page 153 - Writing a function that returns a value

At the end of this section there is a note box that explains that we could use the `C` format code to format the output as currency. If you are running on a computer in a culture that uses Euros then to show the Euro currency symbol you must enable UTF-8 encoding. 

Add the following statement near the top of the code file before doing any writing to the console:

```cs
Console.OutputEncoding = System.Text.Encoding.UTF8;
```

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

> **Warning!** *Razor Pages* are different from *Razor Views* (used in ASP.NET Core MVC) but they share the same file extension `.cshtml`. When creating a *Razor View*, do NOT use the `@page` directive! If you do, the controller will not pass the model to it and the model in the view will be `null`, throwing a `NullRefertenceException` when you try to access any of its members.

# Page 601 - Setting up an ASP.NET Core MVC website

This sections starts with a description of the three parts of MVC. For views, I wrote, "Views: Razor files, that is, `.cshtml` files, that render data in view models into HTML web pages. Blazor uses the `.razor` file extension, but do not confuse them with Razor files!"

In the next edition, I will changed this text and add a warning:

"Views: *Razor View* files, that is, `.cshtml` files, that render data in view models into HTML web pages. *Razor Views* are different from *Razor Pages* but they share the same file extension `.cshtml`. When creating a *Razor Page*, you must add the `@page` directive at the top of the file. When creating a *Razor View*, do NOT use the `@page` directive! If you do, the controller will not pass the model to it and the model in the view will be `null`, throwing a `NullRefertenceException` when you try to access any of its members. Blazor uses the `.razor` file extension, but do not confuse them with *Razor View* or *Razor Page* files! Blazor can also use the `@page` directive to allow a Blazor component to act like a page!"

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
