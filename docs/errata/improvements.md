**Improvements** (4 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs11dotnet7/issues) or email me at markjprice (at) gmail.com.

- [Page 128 - Rounding numbers](#page-128---rounding-numbers)
- [Page 153 - Writing a function that returns a value](#page-153---writing-a-function-that-returns-a-value)
- [Page 179 - Reviewing project packages](#page-179---reviewing-project-packages)
- [Page 453 - Scaffolding models using an existing database](#page-453---scaffolding-models-using-an-existing-database)

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
