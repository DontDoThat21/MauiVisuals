# Mesmerize - Visual Effects Showcase App

A visually impressive .NET MAUI Android application that showcases three distinct animated effects with smooth transitions between them.

## Features

### 🎯 Core Features
- **Random Initial Effect**: App launches with one of three effects selected randomly
- **Touch Navigation**: Single tap cycles through effects in sequence  
- **Smooth Transitions**: Clean switching between effects without jarring interruptions
- **60 FPS Performance**: Optimized for smooth real-time rendering

### 🎨 Visual Effects

#### 1. Katakana Matrix Rain Effect
- Falling katakana characters in classic Matrix style
- Neon green color scheme with trailing fade effect
- Variable fall speeds and character opacity
- Screen-filling columns of characters

#### 2. Recursive Universe Expansion
- Expanding fractal-like patterns from center
- RGB color cycling for psychedelic effect
- Recursive geometric shapes (polygons)
- Pulsating expansion and contraction cycles

#### 3. Butterfly Chaos Effect
- Initial perfect 3D grid formation of butterflies (5x5x5)
- Minimal acceleration variance causing cascade effect
- Collision detection between butterflies
- Post-collision trajectory alterations
- Visual representation of chaos theory

## Technical Implementation

### 🛠 Technology Stack
- **.NET MAUI 8.0+**
- **Target Android API 21+** (Lollipop)
- **SkiaSharp** for high-performance graphics rendering
- **C#** with modern language features

### 📁 Project Structure
```
VisualEffectsApp/
├── VisualEffectsApp.csproj      # MAUI project configuration
├── MauiProgram.cs               # App startup and configuration
├── App.xaml / App.xaml.cs       # Application entry point
├── MainPage.xaml                # Main UI with SkiaSharp canvas
├── MainPage.xaml.cs             # UI event handling
├── VisualEffectsEngine.cs       # Core effects rendering engine
└── Resources/                   # App icons, fonts, and assets
    ├── AppIcon/
    ├── Splash/
    ├── Fonts/
    └── Styles/
```

### 🎯 Key Components

#### VisualEffectsEngine.cs
The core rendering engine that implements all three visual effects:
- **Matrix Rain**: Katakana character particles with physics simulation
- **Recursive Universe**: Fractal polygon generation with HSL color cycling
- **Butterfly Effect**: 3D particle physics with collision detection

#### MainPage Integration
- SkiaSharp canvas for hardware-accelerated rendering
- Touch gesture recognition for effect switching
- 60 FPS animation loop with delta time calculations

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 or Visual Studio Code
- .NET 8.0 SDK
- .NET MAUI workload installed
- Android SDK (for Android deployment)

### Installation
1. **Install .NET MAUI Workload**:
   ```bash
   dotnet workload install maui
   ```

2. **Clone the Repository**:
   ```bash
   git clone https://github.com/DontDoThat21/MauiVisuals.git
   cd MauiVisuals
   ```

3. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

4. **Build the Project**:
   ```bash
   dotnet build
   ```

### 📱 Running the App

#### Android Emulator
```bash
dotnet build -f net8.0-android
dotnet run -f net8.0-android
```

#### Android Device
1. Enable Developer Options and USB Debugging on your device
2. Connect device via USB
3. Run the app:
   ```bash
   dotnet build -f net8.0-android
   dotnet run -f net8.0-android
   ```

### 🎮 Usage
1. **Launch** the app - it will start with a random effect
2. **Tap anywhere** on the screen to cycle to the next effect
3. **Enjoy** the mesmerizing visual effects:
   - Matrix Rain → Recursive Universe → Butterfly Effect → (repeat)

## 🔧 Configuration

### Performance Tuning
The effects are optimized for 60 FPS performance, but you can adjust various parameters in `VisualEffectsEngine.cs`:

- **Matrix Rain**: Column count, fall speed, fade rate
- **Recursive Universe**: Shape count, expansion speed, recursion depth
- **Butterfly Effect**: Grid size, collision sensitivity, chaos factors

### Visual Customization
- **Colors**: Modify HSL values in the respective effect methods
- **Shapes**: Adjust polygon sides, sizes, and patterns
- **Physics**: Tweak acceleration, velocity, and collision responses

## 🏗 Architecture

### Clean Separation of Concerns
- **UI Layer**: XAML/C# for interface and gestures
- **Engine Layer**: Pure SkiaSharp rendering logic
- **Effects Layer**: Individual effect implementations

### Performance Optimizations
- **Delta Time Calculations**: Smooth animation regardless of frame rate
- **Object Pooling**: Efficient memory management for particles
- **Culling**: Off-screen objects are removed from processing
- **Hardware Acceleration**: SkiaSharp leverages GPU rendering

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-effect`)
3. Commit your changes (`git commit -m 'Add amazing effect'`)
4. Push to the branch (`git push origin feature/amazing-effect`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🎯 Future Enhancements

- **Additional Effects**: Particle systems, fluid dynamics, fractals
- **Audio Integration**: Reactive visuals based on music
- **Customization UI**: User controls for effect parameters
- **iOS Support**: Extend to iOS platform
- **Desktop Support**: Windows/macOS versions

## 🔗 Resources

- [.NET MAUI Documentation](https://docs.microsoft.com/en-us/dotnet/maui/)
- [SkiaSharp Documentation](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/)
- [Android Development Guide](https://developer.android.com/guide)

---

**Created with ❤️ for the visual effects community**
