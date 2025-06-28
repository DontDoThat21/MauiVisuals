Mesmerize app.

.NET MAUI Android app with the three effects you've described. Let me start with the GitHub issue details and then provide the implementation.
GitHub Issue Title:
[Feature] Implement Visual Effects Showcase App with Matrix Rain, Recursive Universe, and Butterfly Chaos Effects
GitHub Issue Description:
🎯 Objective
Create a visually impressive .NET MAUI Android application that showcases three distinct animated effects with smooth transitions between them.
📋 Requirements
Core Features:

Random Initial Effect: App launches with one of three effects selected randomly
Touch Navigation: Single tap cycles through effects in sequence
Smooth Transitions: Clean switching between effects without jarring interruptions

Visual Effects to Implement:

Katakana Matrix Acid Rain Effect

Falling katakana characters in classic Matrix style
Neon green color scheme with trailing fade effect
Variable fall speeds and character opacity
Screen-filling columns of characters


Recursive Universe Expansion with RGB

Expanding fractal-like patterns from center
RGB color cycling for psychedelic effect
Recursive geometric shapes (circles/polygons)
Pulsating expansion and contraction cycles


Butterfly Chaos Effect

Initial perfect 3D grid formation of butterflies
Minimal acceleration variance causing cascade effect
Collision detection between butterflies
Post-collision trajectory alterations
Visual representation of chaos theory



🛠 Technical Requirements:

.NET MAUI 8.0+
Target Android API 21+ (Lollipop)
SkiaSharp for high-performance graphics
60 FPS target frame rate
Efficient memory management for smooth performance

✅ Acceptance Criteria:

 All three effects render smoothly at 60 FPS
 Touch interaction cycles through effects seamlessly
 Random effect selection on app launch
 No memory leaks during effect transitions
 Effects scale properly on different screen sizes
 App maintains performance over extended use

🎨 Design Considerations:

Dark background for all effects to enhance visual impact
Consistent aesthetic across all three effects
Smooth fade transitions between effect switches
Full-screen immersive experience

Key Features:
1. Katakana Matrix Acid Rain Effect

Falling katakana characters in columns
Neon green color with fading trail effect
Variable fall speeds for each column
Characters fade out as they fall, creating the classic Matrix look

2. Recursive Universe Expansion

Expanding polygons from the center
RGB color cycling based on time and radius
Recursive drawing creates fractal-like patterns
Multiple shapes expand simultaneously with different properties

3. Butterfly Chaos Effect

Starts with butterflies in a perfect 3D grid (5x5x5)
Each butterfly has slightly different acceleration values
Collision detection causes trajectory changes
Visual representation shows how small differences lead to chaos
Animated wing flapping for realistic movement

Technical Implementation:

SkiaSharp for high-performance graphics rendering
60 FPS continuous animation loop
Touch Navigation: Tap anywhere to cycle through effects
Random Initial Effect: App starts with a random effect each time
Optimized Performance: Efficient memory management and drawing

To Run the App:

Create a new .NET MAUI project in Visual Studio
Replace the generated files with the code artifacts above
Install the SkiaSharp.Views.Maui.Controls NuGet package
Build and deploy to an Android device or emulator

The app creates an immersive full-screen experience with smooth transitions between effects. Each effect demonstrates different visual programming concepts - from particle systems (Matrix rain) to recursive algorithms (Universe) to chaos theory simulation (Butterflies).
