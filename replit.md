# Overview

This is a minimal .NET 7.0 C# console application. The project is currently a bare-bones template with no application logic implemented yet. It serves as a starting point for building a C# application on the .NET 7.0 framework.

The project uses the standard MSBuild/NuGet package management system with PackageReference style dependencies, though no external packages have been added yet.

# User Preferences

Preferred communication style: Simple, everyday language.

# System Architecture

## Project Structure

- **main.csproj** - The main project file defining the .NET 7.0 target framework
- **Main.cs** (expected) - Entry point for the application (not yet visible in repository, needs to be created)
- **bin/** - Compiled output directory
- **obj/** - Intermediate build files and NuGet restore cache

## Runtime Configuration

- **Target Framework**: .NET 7.0 (netcoreapp7.0)
- **Output Type**: Console application (produces main.dll)
- **Build Configuration**: Debug mode currently configured

## Build System

The project uses:
- MSBuild for compilation
- NuGet for package management with PackageReference style
- Packages are cached in `/home/runner/workspace/.cache/.nuget/packages/`
- Package sources: Official NuGet gallery (https://api.nuget.org/v3/index.json)

# External Dependencies

## NuGet Packages

Currently no external NuGet packages are installed. The project only depends on the base .NET 7.0 runtime (`Microsoft.NETCore.App` version 7.0.0).

## Package Management

- Package restore configuration is set up via NuGet.Config
- Warning NU1605 is configured to be treated as an error (catches dependency downgrades)
- Asset target fallback is enabled for .NET Framework compatibility (net461 through net481)

When adding packages, use the standard `dotnet add package <PackageName>` command or add `<PackageReference>` entries to main.csproj.