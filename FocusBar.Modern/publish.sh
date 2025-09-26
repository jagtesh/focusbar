#!/bin/bash

# Build and publish FocusBar for different platforms

# Clean previous builds
dotnet clean

# Publish for Linux x64
echo "Publishing for Linux x64..."
dotnet publish -c Release -r linux-x64 --self-contained false -o publish/linux-x64

# Publish for Windows x64
echo "Publishing for Windows x64..."
dotnet publish -c Release -r win-x64 --self-contained false -o publish/win-x64

# Publish for macOS x64
echo "Publishing for macOS x64..."
dotnet publish -c Release -r osx-x64 --self-contained false -o publish/osx-x64

# Publish for macOS ARM64
echo "Publishing for macOS ARM64..."
dotnet publish -c Release -r osx-arm64 --self-contained false -o publish/osx-arm64

echo "All builds completed. Check publish/ directory for outputs."