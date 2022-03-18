# Previews

Preliminary drafts of *C# 11 and .NET 7 - Modern Cross-Platform Development* were written and tested with **.NET 7 Preview 1**. Microsoft will release monthly previews until August, then two release candidates in September and October, before the general availablility (GA) release in November 2022. Each month I will add new content to this page that will then be added to the final drafts in September.

- [Previews](#previews)
- [Chapter 1 - Hello, C#! Welcome, .NET!](#chapter-1---hello-c-welcome-net)
  - [Command Line Interface commands](#command-line-interface-commands)
  - [Line breaks in interpolated strings](#line-breaks-in-interpolated-strings)
- [Chapter 5 - Building Your Own Types with Object-Oriented Programming](#chapter-5---building-your-own-types-with-object-oriented-programming)
  - [List pattern matching](#list-pattern-matching)
- [Chapter 8 - Working with Common .NET Types](#chapter-8---working-with-common-net-types)
  - [More efficient regular expressions](#more-efficient-regular-expressions)

# Chapter 1 - Hello, C#! Welcome, .NET!

## Command Line Interface commands

In .NET 7 Preview 2 and later, `dotnet` commands do not need to be prefixed with hyphens.

For example, to list the currently installed templates before:

```
dotnet new --list
```

After:

```
dotnet new list
```

> **Note:** Since I want to ensure that .NET 6 developers can follow the examples in the book, and Microsoft will support the use of hyphenated commands for a while, the book will continue to use the hyphenated commands but with a note that they are optional in .NET 7 and later.

## Line breaks in interpolated strings

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

# Chapter 5 - Building Your Own Types with Object-Oriented Programming

## List pattern matching

Any type that has an indexer, and `Length` and `Count` properties (like arrays and any type that implements `ICollection`) can use list pattern matches.

```cs
int[] numbers = { 1, 2, 3, 5, 7, 11 };

string message = numbers switch
{
  [ 1, 2, 3, 5, 7, 11 ] => "This is an exact match.",
  [ 1, 2, _, _, 7, _ ]  => "This is a wildcard match.",
  [1, 2, .., 11]        => "This is a slice match.",
  _                     => "This is NOT a match." 
};
```

To use slice matches, the type must have an indexer that accepts a `Range` parameter, or implements a `Slice(int, int)` method.

# Chapter 8 - Working with Common .NET Types

## More efficient regular expressions

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
