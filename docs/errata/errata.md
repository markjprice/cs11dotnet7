**Errata** (7 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs11dotnet7/issues) or email me at markjprice (at) gmail.com.

> Page numbers will be added as soon as I get my own copy of the final book. ;)

- [Page 4, 8 - Pros and cons of the .NET Interactive Notebooks extension, Downloading and installing Visual Studio Code](#page-4-8---pros-and-cons-of-the-net-interactive-notebooks-extension-downloading-and-installing-visual-studio-code)
- [Page 11 - Understanding the journey to one .NET and Understanding .NET support](#page-11---understanding-the-journey-to-one-net-and-understanding-net-support)
- [Page 37 - Getting definitions of types and their members](#page-37---getting-definitions-of-types-and-their-members)
- [Page 83 - Formatting using numbered positional arguments](#page-83---formatting-using-numbered-positional-arguments)
- [Page 86 - Getting text input from the user](#page-86---getting-text-input-from-the-user)
- [Page 188 - Running unit tests using Visual Studio Code](#page-188---running-unit-tests-using-visual-studio-code)
- [Page 244 - Init-only properties](#page-244---init-only-properties)

# Page 4, 8 - Pros and cons of the .NET Interactive Notebooks extension, Downloading and installing Visual Studio Code

The **.NET Interactive Notebooks** extension has been renamed to **Polyglot Notebooks**. It still retains its original identifier `ms-dotnettools.dotnet-interactive-vscode`. The engine is still named *.NET Interactive*.

> Read more here: https://devblogs.microsoft.com/dotnet/dotnet-interactive-notebooks-is-now-polyglot-notebooks/#why-the-name-change

# Page 11 - Understanding the journey to one .NET and Understanding .NET support

Even-numbered .NET releases like .NET 6 and .NET 8 have a support level named **Long Term Support (LTS)** with a duration of 3 years. Odd-numbered .NET releases like .NET 5 and .NET 7 had a support level named **Current** with a duration of 18 months. 

On June 6, 2022, the .NET team proposed to change the support level name from **Current** to [**Short Term Support (STS)**](https://github.com/dotnet/announcements/issues/223) to complement the existing **Long Term Support (LTS)**. I updated the drafts of my book to reflect that change.

On October 11, 2022, the .NET team changed the name again, to [**Standard Support**](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-rc-2/#support), probably because Microsoft Marketing decided that "short term" sounded too negative. My editors and I scrambled to update the final drafts of my book to reflect that change.

On October 28, 2022, the .NET team changed the name *again*, to [**Standard Term Support (STS)**](https://twitter.com/mairacw/status/1585789100879069185), probably because an initialism of **SS** is problematic and internal code and configuration was already using `sts`. Sadly, it was too late to update the PDFs that are sent to print.

*Sigh.* Such are the perils of trying to be up-to-date on release day.

# Page 37 - Getting definitions of types and their members

In Step 3, I wrote, "Click inside `int` and then right-click and choose **Go To Definition**." 

Visual Studio 2022 used to show code reverse-engineered **from metadata** for the selected type like `int` (see *Figure 1.1*), including the comments that I talk about in the book, but it now shows **Source Link** code (see *Figure 1.2*) which does not have comments.

![from metadata code](images/B18856_01_01.png)

*Figure 1.1: Go To Definition file tab generated from metadata*

![SourceLink code](images/B18856_01_02.png)

*Figure 1.2: Go To Definition file tab retrieved from embedded Source Link code*

To change back to the original Visual Studio 2022 behavior that is described in the book, please follow these steps:

1. In Visual Studio 2022, navigate to **Tools** | **Options**.
2. In the **Options** dialog, navigate to **Text Editor** | **C#** | **Advanced**.
3. In the **Go To Definition** section, clear the check box named **Enable navigation to Source Link and Embedded sources**, as shown in *Figure 1.3*.
4. Click **OK**.

![Disabling Source Link for the Go To Definition feature](images/B18856_01_03.png)

*Figure 1.3: Disabling Source Link for the Go To Definition feature*

# Page 83 - Formatting using numbered positional arguments

At the end of the section, I say, "The `Write`, `WriteLine`, and `Format` methods can have up to four numbered arguments, named `arg0`, `arg1`, `arg2`, and `arg3`." 

But the methods can only have up to *three* named arguments. I should have said, "The `Write`, `WriteLine`, and `Format` methods can have up to three numbered arguments, named `arg0`, `arg1`, and `arg2`. If you need to pass more than three values, then you cannot name the arguments using `arg0` and so on, as shown in the following code:"

```cs
// Passing three values can use named arguments.
Console.WriteLine(
 format: "{0} {1} lived in {2}.", 
 arg0: "Roger", arg1: "Cevung", arg2: "Stockholm");

// Passing four or more values cannot use named arguments.
Console.WriteLine(
 "{0} {1} lived in {2} and worked in the {3} team at {4}.", 
 "Roger", "Cevung", "Stockholm", "Education", "Optimizely");
```

# Page 86 - Getting text input from the user

In Step 3, I wrote, "For the `firstName` variable" when I should have written, "For the `age` variable".

# Page 188 - Running unit tests using Visual Studio Code

> Thanks to [kwatsonkairosmgt](https://github.com/kwatsonkairosmgt) for raising this [issue on 27 October 2022](https://github.com/markjprice/cs10dotnet6/issues/106).

In Step 1, the project name `CalculatorLibUnitTest` should be `CalculatorLibUnitTests`.

# Page 244 - Init-only properties

> Thanks to Bob Molloy for raising this issue via email.

In Step 1, I say to add a new file named `Records.cs` to the `PacktLibraryNetStandard2` project/folder. I should have said to the `PacktLibraryModern` project/folder.
