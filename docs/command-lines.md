**Command-Lines**

To make it easier to enter commands at the prompt, this page lists all commands as a single line that can be copied and pasted.

- [Chapter 1 - Hello, C#! Welcome, .NET!](#chapter-1---hello-c-welcome-net)
  - [Page 9 - Managing Visual Studio Code extensions at the command line](#page-9---managing-visual-studio-code-extensions-at-the-command-line)
  - [Page 14 - Listing and removing versions of .NET](#page-14---listing-and-removing-versions-of-net)
  - [Page 27 - Writing code using Visual Studio Code](#page-27---writing-code-using-visual-studio-code)
  - [Page 29 - Compiling and running code using the dotnet CLI](#page-29---compiling-and-running-code-using-the-dotnet-cli)
  - [Page 36 - Cloning the book solution code repository](#page-36---cloning-the-book-solution-code-repository)
  - [Page 36 - Getting help for the dotnet tool](#page-36---getting-help-for-the-dotnet-tool)
- [Chapter 2 - Speaking C#](#chapter-2---speaking-c)
  - [Page 51 - How to output the SDK version](#page-51---how-to-output-the-sdk-version)
- [Chapter 3 -](#chapter-3--)
  - [Page 176 - Configuring trace listeners](#page-176---configuring-trace-listeners)
  - [Page 178 - Adding packages to a project in Visual Studio Code](#page-178---adding-packages-to-a-project-in-visual-studio-code)

# Chapter 1 - Hello, C#! Welcome, .NET!

## Page 9 - Managing Visual Studio Code extensions at the command line

```
code --install-extension ms-dotnettools.csharp
```

## Page 14 - Listing and removing versions of .NET

Listing all installed .NET SDKS:
```
dotnet --list-sdks
```

Listing all installed .NET runtimes:
```
dotnet --list-runtimes
```

Details of all .NET installations:
```
dotnet --info
```

Remove all but the latest .NET SDK preview:
```
dotnet-core-uninstall remove --all-previews-but-latest --sdk
```

## Page 27 - Writing code using Visual Studio Code

Creating a new **Console App** project:
```
dotnet new console
```

Creating a new **Console App** project that targets an older version:
```
dotnet new console -f net6.0
```

Creating a new **Console App** project that in a named subfolder:
```
dotnet new console -o HelloCS
```

## Page 29 - Compiling and running code using the dotnet CLI
```
dotnet run
```

## Page 36 - Cloning the book solution code repository

```
git clone https://github.com/markjprice/cs11dotnet7.git
```

## Page 36 - Getting help for the dotnet tool

Getting help for a `dotnet` command like `new`:
```
dotnet help new
```

Getting help for a project template like `console`:
```
dotnet new console -h
```

# Chapter 2 - Speaking C#

## Page 51 - How to output the SDK version

```
dotnet --version
```

# Chapter 3 - 

## Page 176 - Configuring trace listeners

Running a project with its release configuration:
```
dotnet run --configuration Release
```

Running a project with its debug configuration:
```
dotnet run --configuration Debug
```

## Page 178 - Adding packages to a project in Visual Studio Code

Adding the `Microsoft.Extensions.Configuration` package:
```
dotnet add package Microsoft.Extensions.Configuration
```

Adding the `Microsoft.Extensions.Configuration.Binder` package:
```
dotnet add package Microsoft.Extensions.Configuration.Binder
```

Adding the `Microsoft.Extensions.Configuration.FileExtensions` package:
```
dotnet add package Microsoft.Extensions.Configuration.FileExtensions
```

Adding the `Microsoft.Extensions.Configuration.Json` package:
```
dotnet add package Microsoft.Extensions.Configuration.Json
```

