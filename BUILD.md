# Building Nitrox

This document describes how to build the Nitrox project from source.

## Prerequisites

- [.NET SDK 9.0 or later](https://dotnet.microsoft.com/download)
- Subnautica installation

## Building the Project

### Automatic Game Discovery

By default, the build system will automatically try to locate your Subnautica installation using various methods:

1. Steam library discovery
2. Epic Games Store discovery
3. Discord Store discovery
4. Microsoft Store discovery
5. Environment variable `SUBNAUTICA_INSTALLATION_PATH`
6. Configuration file settings

Simply run:

```bash
dotnet build
```

### Manual Path Specification

If you have multiple Subnautica installations or the automatic discovery fails to find the correct one, you can manually specify the path to your Subnautica installation using the `SubnauticaPath` MSBuild property:

```bash
dotnet build -p:SubnauticaPath="C:\Program Files (x86)\Steam\steamapps\common\Subnautica"
```

**Linux/macOS example:**
```bash
dotnet build -p:SubnauticaPath="/home/user/.steam/steam/steamapps/common/Subnautica"
```

### Environment Variable (Alternative Method)

You can also set the `SUBNAUTICA_INSTALLATION_PATH` environment variable:

**Windows:**
```cmd
set SUBNAUTICA_INSTALLATION_PATH=C:\Program Files (x86)\Steam\steamapps\common\Subnautica
dotnet build
```

**Linux/macOS:**
```bash
export SUBNAUTICA_INSTALLATION_PATH="/home/user/.steam/steam/steamapps/common/Subnautica"
dotnet build
```

## Build Priority Order

The build system checks for the Subnautica installation in the following order:

1. **Manual MSBuild property** (`-p:SubnauticaPath="..."`) - **Highest priority**
2. **Automatic discovery** (Steam, Epic, Discord, Microsoft Store, etc.) - **Default behavior**
3. **Environment variable** (`SUBNAUTICA_INSTALLATION_PATH`) - **Fallback**

The MSBuild property will always override both automatic discovery and environment variables, giving you complete control over which Subnautica installation to use for compilation.

## Error Messages

If the build cannot find Subnautica, you'll see an error message like:

```
Failed to find the game 'Subnautica' on your machine. You can specify the path manually using: dotnet build -p:SubnauticaPath="path/to/subnautica"
```

If you specify an invalid path, you'll see:

```
The manually specified Subnautica path 'your/path' does not exist. Please verify the path is correct.
```

Or:

```
The specified path 'your/path' does not appear to be a valid Subnautica installation directory. The Subnautica executable was not found.
```

## Tips

- Make sure the path you specify contains the Subnautica executable (`Subnautica.exe` on Windows or `Subnautica` on Linux/macOS)
- The path should point to the root directory of the Subnautica installation, not to the executable itself
- Use quotes around paths that contain spaces