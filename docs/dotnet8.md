# Seventh Edition's support for .NET 8

Microsoft will release previews of .NET 8 monthly starting in February 2023 until the final General Availability (GA) version on Tuesday, November 7, 2023.

> [Download .NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## .NET 8 Preview announcements

- February 21, 2023: [Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)
- March 14, 2023: [Announcing .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-2/)
- April 11, 2023: [Announcing .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-3/)
- May 16, 2023: [Announcing .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/)
- June 13, 2023: [Announcing .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-5/)
- July, 2023: [Announcing .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-6/)
- August, 2023: [Announcing .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-7/)
- September, 2023: [Announcing .NET 8 Release Candidate 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc-1/)
- October, 2023: [Announcing .NET 8 Release Candidate 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc-2/)
- November 7, 2023: Announcing .NET 8.0 - The Bestest .NET Yet

## Visual Studio 2022 support

To use .NET 8 previews with Visual Studio 2022, you must install version 17.6 Preview 1 or later. 

> [Download Visual Studio Preview](https://visualstudio.microsoft.com/vs/preview/#download-preview)

## All Chapters

After [downloading](https://dotnet.microsoft.com/download/dotnet/8.0) and installing .NET 8.0 SDK, follow the step-by-step instructions in the book and they should work as expected since the project file will automatically reference .NET 8.0 as the target framework. 

To upgrade a project in the GitHub repository from .NET 7.0 to .NET 8.0 just requires a target framework change in your project file.

Change this:

```xml
<TargetFramework>net7.0</TargetFramework>
```

To this:

```xml
<TargetFramework>net8.0</TargetFramework>
```

For projects that reference additional NuGet packages, use the latest NuGet package version, as shown in the rest of this page, instead of the version given in the book. You can search for the correct NuGet package version numbers yourself at the following link: https://www.nuget.org

## Chapter 4 - Writing, Debugging, and Testing Functions

For the `Instrumenting` project, the additional referenced NuGet packages should use the .NET 8.0 versions, as shown in the following markup: 

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0-*" />
  </ItemGroup>

</Project>
```

> Note the wildcard `8.0.0-*` version that will allow your projects to automatically use the latest preview and release candiate as soon as they are publicly available. Once the GA release is available in November 2023, you will need to change the versions to `8.0.0`.

For the `CalculatorLibUnitTests` project, the additional referenced NuGet packages for unit testing can use the latest versions, as shown in the following markup:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.5.0" />
    <PackageReference Include="xunit" Version="2.4.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.5" />
    <PackageReference Include="coverlet.collector" Version="3.2.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\CalculatorLib\CalculatorLib.csproj" />
  </ItemGroup>

</Project>
```

## Chapter 10 - Working with Databases Using Entity Framework Core

For the `WorkingWithEFCore` project, the additional referenced NuGet packages should use the .NET 8.0 versions, as shown in the following markup:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="8.0.0-*" />
  </ItemGroup>

</Project>
```

## Chapter 11 - Querying and Manipulating Data Using LINQ

For the `LinqWithEFCore` and `Exercise02` projects, the additional referenced NuGet package should use the .NET 8.0 version, as shown in the following markup:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0-*" />
  </ItemGroup>

</Project>
```
## Chapter 12 - Introducing Web Development Using ASP.NET Core

For the `NorthwindContextLib` project, the referenced NuGet package for SQLite should use the .NET 8.0 version, as shown in the following markup:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindEntitiesLib\NorthwindEntitiesLib.csproj" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SQLite" Version="8.0.0-*" />
  </ItemGroup>

</Project>
```

## Chapter 14 - Building Websites Using the Model-View-Controller Pattern

For the `NorthwindMvc` project, the referenced NuGet packages should use the .NET 8.0 versions, as shown in the following markup:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <None Update="app.db" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0-*" />
    
    <!-- added in Chapter 15 to call a web service -->
    <PackageReference Include="Newtonsoft.Json" Version="13.0.2" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />
  </ItemGroup>

</Project>
```

## Chapter 15 - Building and Consuming Web Services

For the `NorthwindService` project, the referenced NuGet packages should use the latest versions, as shown in the following markup:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\NorthwindContextLib\NorthwindContextLib.csproj" />

    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
    <PackageReference Include="Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore" 
                      Version="8.0.0-*" />
  </ItemGroup>

</Project>
```
