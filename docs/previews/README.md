**Previews**

Preliminary drafts of C# 11 and .NET 7 - Modern Cross-Platform Development were written and tested with .NET 7 Preview 1. Microsoft will release monthly previews until August, then two release candidates in September and October, before the general availablility (GA) release in November 2022. Each month I will add new content to this page that will then be added to the final drafts in September.

- [New content for .NET 7 Preview 2](#new-content-for-net-7-preview-2)
  - [Chapter 1](#chapter-1)
    - [Command Line Interface commands](#command-line-interface-commands)
    - [Line breaks in interpolated strings](#line-breaks-in-interpolated-strings)
  - [Chapter 5](#chapter-5)
    - [List pattern matching](#list-pattern-matching)
  - [Chapter 8](#chapter-8)
    - [Regular Expressions](#regular-expressions)
- [New content for .NET 7 Preview 3 (April)](#new-content-for-net-7-preview-3-april)
- [New content for .NET 7 Preview 4 (May)](#new-content-for-net-7-preview-4-may)
- [New content for .NET 7 Preview 5 (June)](#new-content-for-net-7-preview-5-june)
- [New content for .NET 7 Preview 6 (July)](#new-content-for-net-7-preview-6-july)
- [New content for .NET 7 Preview 7 (August)](#new-content-for-net-7-preview-7-august)
- [New content for .NET 7 Release Candidate 1 (September)](#new-content-for-net-7-release-candidate-1-september)

# New content for .NET 7 Preview 2

## Chapter 1 

### Command Line Interface commands

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

### Line breaks in interpolated strings

One of my favorite new language features because it helps with printed code!

Before C# 11, breaking an interpolated string in the middle of the double-quotes or in the middle of a curly-brace expression gives compile errors, as shown in the following code:

```cs
string message1 = $"Total number of 
    fruit is {apples.Count}.";

string message2 =
  $"Total number of fruit is {apples.Count 
    + oranges.Count}";
```

With C# 11, the above will compile. Finally!

## Chapter 5

### List pattern matching

## Chapter 8 

### Regular Expressions

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

# New content for .NET 7 Preview 3 (April)

# New content for .NET 7 Preview 4 (May)

# New content for .NET 7 Preview 5 (June)

# New content for .NET 7 Preview 6 (July)

# New content for .NET 7 Preview 7 (August)

# New content for .NET 7 Release Candidate 1 (September)
