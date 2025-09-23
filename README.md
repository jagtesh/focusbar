# FocusBar - Cross-Platform Focus Timer

A cross-platform focus bar application that helps you stay focused on your current task. Displays an always-on-top window with a timer and task description.

## Features

- **Always-on-top focus bar** - Stays visible above all other windows
- **Timer functionality** - Track time spent on tasks with start/stop/reset controls
- **Task description** - Text field to describe what you're focusing on
- **Cross-platform** - Runs on Windows, macOS, and Linux
- **Minimal UI** - Clean, distraction-free interface

## Migration from Legacy Version

This is a modern .NET 8 rewrite of the original Windows-only .NET Framework application. Key improvements:

- **Cross-platform compatibility** using Eto.Forms
- **Modern .NET 8** instead of legacy .NET Framework 4.5
- **Simplified codebase** without Windows Shell dependencies
- **Maintained core functionality** while improving portability

## Requirements

- .NET 8 or later
- On Linux: GTK 3.24+ (for GUI)
- On Windows: No additional requirements
- On macOS: macOS 10.12+ (for GUI)

## Building

```bash
cd FocusBar.Modern
dotnet build
```

## Running

```bash
cd FocusBar.Modern
dotnet run --project FocusBar
```

## Platform-Specific Notes

### Linux
Uses GTK3 backend. The application will attempt to position itself at the top of the screen.

### Windows
Will use WPF backend when Eto.Platform.Wpf package is installed.

### macOS
Will use Cocoa backend when Eto.Platform.Mac64 package is installed.

## Original Legacy Project

The original Windows-only version can be found in the `FocusBar.Old/` directory:
- `FocusBar.Old/FocusBarWin/` - Legacy WinForms application 
- `FocusBar.Old/ShellBasics/` - Legacy Windows Shell integration library
- `FocusBar.Old/FocusBarWin.sln` - Legacy Visual Studio solution

This legacy code used Windows Shell APIs for desktop toolbar functionality and was limited to Windows only.