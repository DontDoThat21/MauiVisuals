#!/bin/bash

# Mesmerize Visual Effects App - Quick Start Script
# This script helps set up and run the visual effects app

echo "🎨 Mesmerize Visual Effects App - Quick Start"
echo "=============================================="

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET SDK is required but not found."
    echo "📥 Please install .NET 8.0 SDK from: https://dotnet.microsoft.com/download"
    exit 1
fi

echo "✅ .NET SDK found: $(dotnet --version)"

# Check if MAUI workload is installed
echo "🔍 Checking for MAUI workload..."
if dotnet workload list | grep -q "maui"; then
    echo "✅ MAUI workload is installed"
else
    echo "⚠️  MAUI workload not found"
    echo "📥 Installing MAUI workload..."
    dotnet workload install maui
    
    if [ $? -eq 0 ]; then
        echo "✅ MAUI workload installed successfully"
    else
        echo "❌ Failed to install MAUI workload"
        echo "💡 Please run: dotnet workload install maui"
        exit 1
    fi
fi

# Restore dependencies
echo "📦 Restoring project dependencies..."
dotnet restore

if [ $? -ne 0 ]; then
    echo "❌ Failed to restore dependencies"
    exit 1
fi

echo "✅ Dependencies restored"

# Build the project
echo "🔨 Building the project..."
dotnet build

if [ $? -eq 0 ]; then
    echo "✅ Build successful!"
    echo ""
    echo "🚀 Ready to run!"
    echo ""
    echo "📱 To run on Android:"
    echo "   1. Connect your Android device or start an emulator"
    echo "   2. Run: dotnet build -f net8.0-android"
    echo "   3. Run: dotnet run -f net8.0-android"
    echo ""
    echo "🎮 App Controls:"
    echo "   • Tap anywhere to cycle between effects"
    echo "   • Matrix Rain → Recursive Universe → Butterfly Effect"
    echo ""
    echo "🎯 Effects:"
    echo "   • Matrix Rain: Falling katakana characters with neon trails"
    echo "   • Recursive Universe: Expanding fractal polygons with RGB cycling"
    echo "   • Butterfly Effect: 3D physics simulation with chaos theory"
else
    echo "❌ Build failed"
    echo "💡 Make sure all MAUI dependencies are properly installed"
    exit 1
fi