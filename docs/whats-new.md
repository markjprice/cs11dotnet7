**What's New in the 7th Edition**

There are hundreds of minor fixes and improvements throughout the 7th edition; too many to list individually. All errata and improvements listed [here](https://github.com/markjprice/cs10dotnet6/blob/main/docs/errata/README.md) have been made to the 7th edition. 

The main new sections in C# 11 and .NET 7, 7th edition compared to C# 10 and .NET 6 6th edition are shown below.

# Chapter 1

- Understanding .NET support: explains that *Current* support is now renamed *Standard Term Support (STS)*.

# Chapter 2

- Raw string literals and Raw interpolated string literals: new C# 11 features.

# Chapter 3

- Storing multiple values in an array: not a new feature but previous editions didn't really cover arrays.
- List pattern matching with arrays: a new C# 11 feature.

# Chapter 4

- Understanding top-level programs and functions: I explain in detail how top-level programs work with separate files for `partial Program` class since I use that technique throughout the book.
- Most of the function examples have been improved based on reader feedback, for example, going beyond supported ranges to see when exceptions and overflows occur.
- A brief aside about the correct usage of the terms *arguments* and *parameters*.
- Hot reloading during development.
- Logging information about your source code.

# Chapter 5

- Avoiding a namespace conflict with a using alias, and Renaming a type with a using alias. Not new but useful for readers to know.
- Requiring properties to be set during instantiation: the new C# 11 `required` keyword.

# Chapter 6

- Checking for `null` in method parameters: explains the story behind `!!` in C# 11.
- Treating warnings as errors: added for good practice.
- Understanding warning waves.

# Chapter 7

- Viewing source links with Visual Studio 2022: explain differences between viewing source links and decompiling, with `Enumerable.Count` method as an example which then helps to understand later why `Count()` can be inefficient.

# Chapter 8

- Activating regular expression syntax coloring: the new `[StringSyntax]` attribute introduced in .NET 7.
- Improving regular expression performance with source generators.

# Chapter 9

- Working with Tar archives. New in .NET 7.

# Chapter 10

- Customizing the reverse engineering templates: I just mention that this is possible because it's interesting but too advanced for this book.
- More efficient updates and deletes. Uses new methods in EF Core 7.

# Chapter 11

- Sorting by the item itself. Uses new methods in .NET 7.
- Be careful with Count! A section about the `Count()` method implementation and how it can be tricky to work with efficiently.
- Paging with LINQ. A new section for the book but not a new LINQ feature. Just helpful to cover before getting into web development.

# Chapter 13

- Enabling request decompression support.
- Enabling HTTP/3 support.

# Chapter 14

- Using output caching. Output caching was added in ASP.NET Core 7.

# Chapter 15

- Support for logging additional request headers in W3CLogger.
- Enabling HTTP/3 support for HttpClient.

# Chapter 16

- Enabling location change event handling.