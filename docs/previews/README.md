# Previews

Preliminary drafts of C# 11 and .NET 7 - Modern Cross-Platform Development were written and tested with .NET 7 Preview 1. Microsoft will release monthly previews until August, then two release candidates in September and October, before the general availablility (GA) release in November 2022. Each month I will add new content to this page that will then be added to the final drafts in September.

## New content for .NET 7 Preview 2

### Chapter 1 - Command Line Interface commands

In .NET 7 Preview 2 and later, `dotnet` commands do not need to be prefixed with hyphens.

For example, to list the currently installed templates before:

```
dotnet new --list
```

After:

```
dotnet new list
```

> Since I want to ensure that .NET 6 developers can follow the examples in the book, and Microsoft will support the use of hyphenated commands for a while, the book will continue to use the hyphenated commands but with a note that they are optional in .NET 7 and later.

### Chapter 8 - Regular Expressions

In .NET 7 Preview 2 and later, you can use a more efficient Regex source generator.

Before:

```cs
public class Foo
{
  public Regex regex = new Regex(@"abc|def", RegexOptions.IgnoreCase);

  public bool Bar(string input)
  {
    bool isMatch = regex.IsMatch(input);
    // ..
  }
}
```

After:

```cs
public partial class Foo  // <-- Make the class a partial class
{
  [RegexGenerator(@"abc|def", RegexOptions.IgnoreCase)] // <-- Add the RegexGenerator attribute and pass in your pattern and options
  public static partial Regex MyRegex(); //  <-- Declare the partial method, which will be implemented by the source generator

  public bool Bar(string input)
  {
    bool isMatch = MyRegex().IsMatch(input); // <-- Use the generated engine by invoking the partial method.
    // ..
  }
}
```
