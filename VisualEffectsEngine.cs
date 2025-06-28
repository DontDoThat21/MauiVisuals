using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VisualEffectsApp.Core
{
    public class VisualEffectsEngine
    {
        private EffectType currentEffect;
        private Random random = new Random();
        private DateTime lastFrameTime = DateTime.Now;
        
        // Matrix Rain Effect
        private List<MatrixColumn> matrixColumns = new List<MatrixColumn>();
        private string katakanaChars = "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲン";
        
        // Universe Expansion Effect
        private List<ExpandingShape> expandingShapes = new List<ExpandingShape>();
        private float universeTime = 0;
        
        // Butterfly Effect
        private List<Butterfly> butterflies = new List<Butterfly>();
        private bool butterfliesInitialized = false;

        public enum EffectType
        {
            MatrixRain,
            RecursiveUniverse,
            ButterflyEffect
        }

        public EffectType CurrentEffect => currentEffect;

        public VisualEffectsEngine()
        {
            // Select random initial effect
            var effects = Enum.GetValues<EffectType>();
            currentEffect = effects[random.Next(effects.Length)];
            
            InitializeEffects();
        }

        public void SwitchToNextEffect()
        {
            currentEffect = (EffectType)(((int)currentEffect + 1) % Enum.GetValues<EffectType>().Length);
            InitializeEffects();
        }

        private void InitializeEffects()
        {
            switch (currentEffect)
            {
                case EffectType.MatrixRain:
                    InitializeMatrixRain();
                    break;
                case EffectType.RecursiveUniverse:
                    InitializeUniverse();
                    break;
                case EffectType.ButterflyEffect:
                    InitializeButterflies();
                    break;
            }
        }

        private void InitializeMatrixRain()
        {
            matrixColumns.Clear();
        }

        private void InitializeUniverse()
        {
            expandingShapes.Clear();
            universeTime = 0;
        }

        private void InitializeButterflies()
        {
            butterflies.Clear();
            butterfliesInitialized = false;
        }

        public void RenderFrame(SKCanvas canvas, SKImageInfo info)
        {
            canvas.Clear(SKColors.Black);

            var deltaTime = (float)(DateTime.Now - lastFrameTime).TotalSeconds;
            lastFrameTime = DateTime.Now;

            switch (currentEffect)
            {
                case EffectType.MatrixRain:
                    DrawMatrixRain(canvas, info, deltaTime);
                    break;
                case EffectType.RecursiveUniverse:
                    DrawRecursiveUniverse(canvas, info, deltaTime);
                    break;
                case EffectType.ButterflyEffect:
                    DrawButterflyEffect(canvas, info, deltaTime);
                    break;
            }
        }

        private void DrawMatrixRain(SKCanvas canvas, SKImageInfo info, float deltaTime)
        {
            // Initialize columns on first frame
            if (matrixColumns.Count == 0)
            {
                int columnWidth = 20;
                int numColumns = info.Width / columnWidth;
                
                for (int i = 0; i < numColumns; i++)
                {
                    matrixColumns.Add(new MatrixColumn
                    {
                        X = i * columnWidth + columnWidth / 2,
                        Y = random.Next(-info.Height, 0),
                        Speed = random.Next(100, 400),
                        CharHistory = new List<(char ch, float opacity)>()
                    });
                }
            }

            using (var paint = new SKPaint())
            {
                paint.TextSize = 18;
                paint.Typeface = SKTypeface.FromFamilyName("monospace");
                paint.IsAntialias = true;

                foreach (var column in matrixColumns)
                {
                    // Update position
                    column.Y += column.Speed * deltaTime;
                    
                    // Add new character
                    if (column.CharHistory.Count == 0 || column.Y - column.LastCharY > 20)
                    {
                        char newChar = katakanaChars[random.Next(katakanaChars.Length)];
                        column.CharHistory.Add((newChar, 1.0f));
                        column.LastCharY = column.Y;
                    }

                    // Update and draw character history
                    for (int i = 0; i < column.CharHistory.Count; i++)
                    {
                        var (ch, opacity) = column.CharHistory[i];
                        float charY = column.Y - (column.CharHistory.Count - 1 - i) * 20;
                        
                        if (charY > info.Height + 20)
                        {
                            column.CharHistory.RemoveAt(i);
                            i--;
                            continue;
                        }

                        // Fade out older characters
                        opacity = Math.Max(0, opacity - deltaTime * 0.8f);
                        column.CharHistory[i] = (ch, opacity);

                        // Set color with acid green tint
                        byte alpha = (byte)(opacity * 255);
                        byte green = (byte)(150 + opacity * 105);
                        byte red = (byte)(opacity * 50);
                        paint.Color = new SKColor(red, green, 0, alpha);

                        // Draw character
                        canvas.DrawText(ch.ToString(), column.X, charY, paint);
                    }

                    // Reset column when it goes off screen
                    if (column.CharHistory.Count == 0)
                    {
                        column.Y = random.Next(-info.Height / 2, 0);
                        column.Speed = random.Next(100, 400);
                    }
                }
            }
        }

        private void DrawRecursiveUniverse(SKCanvas canvas, SKImageInfo info, float deltaTime)
        {
            universeTime += deltaTime;

            // Create new shapes periodically
            if (expandingShapes.Count < 5 && random.NextDouble() < 0.02)
            {
                expandingShapes.Add(new ExpandingShape
                {
                    X = info.Width / 2,
                    Y = info.Height / 2,
                    Radius = 1,
                    MaxRadius = Math.Min(info.Width, info.Height) / 2,
                    ExpansionSpeed = random.Next(50, 150),
                    Sides = random.Next(3, 8),
                    RotationSpeed = (float)(random.NextDouble() * 2 - 1),
                    HueOffset = (float)random.NextDouble() * 360
                });
            }

            using (var paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 2;
                paint.IsAntialias = true;

                // Update and draw shapes
                for (int i = expandingShapes.Count - 1; i >= 0; i--)
                {
                    var shape = expandingShapes[i];
                    
                    // Update radius
                    shape.Radius += shape.ExpansionSpeed * deltaTime;
                    shape.Rotation += shape.RotationSpeed * deltaTime;

                    // Remove if too large
                    if (shape.Radius > shape.MaxRadius)
                    {
                        expandingShapes.RemoveAt(i);
                        continue;
                    }

                    // Calculate RGB color
                    float hue = (universeTime * 50 + shape.HueOffset + shape.Radius * 0.5f) % 360;
                    SKColor color = SKColor.FromHsl(hue, 100, 50);
                    
                    // Fade based on radius
                    float opacity = 1.0f - (shape.Radius / shape.MaxRadius);
                    paint.Color = color.WithAlpha((byte)(opacity * 255));

                    // Draw recursive shapes
                    DrawRecursivePolygon(canvas, paint, shape.X, shape.Y, shape.Radius, 
                                       shape.Sides, shape.Rotation, 3);
                }
            }
        }

        private void DrawRecursivePolygon(SKCanvas canvas, SKPaint paint, float centerX, float centerY, 
                                        float radius, int sides, float rotation, int depth)
        {
            if (depth <= 0 || radius < 5) return;

            using (var path = new SKPath())
            {
                for (int i = 0; i < sides; i++)
                {
                    float angle = rotation + i * 2 * (float)Math.PI / sides;
                    float x = centerX + radius * (float)Math.Cos(angle);
                    float y = centerY + radius * (float)Math.Sin(angle);

                    if (i == 0)
                        path.MoveTo(x, y);
                    else
                        path.LineTo(x, y);

                    // Recursive call for smaller shapes
                    if (depth > 1)
                    {
                        DrawRecursivePolygon(canvas, paint, x, y, radius * 0.4f, 
                                           sides, rotation * 1.5f, depth - 1);
                    }
                }
                path.Close();
                canvas.DrawPath(path, paint);
            }
        }

        private void DrawButterflyEffect(SKCanvas canvas, SKImageInfo info, float deltaTime)
        {
            // Initialize butterflies in perfect grid on first frame
            if (!butterfliesInitialized)
            {
                butterflies.Clear();
                int gridSize = 5;
                float spacing = Math.Min(info.Width, info.Height) / (gridSize + 1);
                
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        for (int z = 0; z < gridSize; z++)
                        {
                            float posX = (x + 1) * spacing;
                            float posY = (y + 1) * spacing;
                            float posZ = z * 0.1f; // Depth factor

                            butterflies.Add(new Butterfly
                            {
                                X = posX,
                                Y = posY,
                                Z = posZ,
                                VX = 0,
                                VY = 0,
                                VZ = 0,
                                // Tiny random acceleration differences
                                AX = (float)(random.NextDouble() - 0.5) * 0.1f,
                                AY = (float)(random.NextDouble() - 0.5) * 0.1f,
                                AZ = (float)(random.NextDouble() - 0.5) * 0.01f,
                                Color = SKColor.FromHsl((float)(x * 72), 80, 60),
                                WingPhase = (float)random.NextDouble() * (float)Math.PI * 2
                            });
                        }
                    }
                }
                butterfliesInitialized = true;
            }

            // Update butterflies
            foreach (var butterfly in butterflies)
            {
                // Update velocity and position
                butterfly.VX += butterfly.AX * deltaTime;
                butterfly.VY += butterfly.AY * deltaTime;
                butterfly.VZ += butterfly.AZ * deltaTime;
                
                butterfly.X += butterfly.VX * deltaTime;
                butterfly.Y += butterfly.VY * deltaTime;
                butterfly.Z += butterfly.VZ * deltaTime;
                
                // Wing animation
                butterfly.WingPhase += deltaTime * 5;
                
                // Boundary bounce
                if (butterfly.X < 0 || butterfly.X > info.Width)
                {
                    butterfly.VX = -butterfly.VX * 0.9f;
                    butterfly.X = Math.Clamp(butterfly.X, 0, info.Width);
                }
                if (butterfly.Y < 0 || butterfly.Y > info.Height)
                {
                    butterfly.VY = -butterfly.VY * 0.9f;
                    butterfly.Y = Math.Clamp(butterfly.Y, 0, info.Height);
                }
            }

            // Check collisions
            for (int i = 0; i < butterflies.Count; i++)
            {
                for (int j = i + 1; j < butterflies.Count; j++)
                {
                    var b1 = butterflies[i];
                    var b2 = butterflies[j];
                    
                    float dx = b2.X - b1.X;
                    float dy = b2.Y - b1.Y;
                    float dz = (b2.Z - b1.Z) * 100; // Scale Z difference
                    float distSq = dx * dx + dy * dy + dz * dz;
                    
                    if (distSq < 400) // 20 pixel collision radius
                    {
                        // Elastic collision response
                        float dist = (float)Math.Sqrt(distSq);
                        dx /= dist;
                        dy /= dist;
                        
                        float v1 = b1.VX * dx + b1.VY * dy;
                        float v2 = b2.VX * dx + b2.VY * dy;
                        
                        b1.VX += (v2 - v1) * dx * 0.5f;
                        b1.VY += (v2 - v1) * dy * 0.5f;
                        b2.VX += (v1 - v2) * dx * 0.5f;
                        b2.VY += (v1 - v2) * dy * 0.5f;
                        
                        // Add some chaos
                        b1.AX += (float)(random.NextDouble() - 0.5) * 5;
                        b1.AY += (float)(random.NextDouble() - 0.5) * 5;
                        b2.AX += (float)(random.NextDouble() - 0.5) * 5;
                        b2.AY += (float)(random.NextDouble() - 0.5) * 5;
                    }
                }
            }

            // Draw butterflies (sorted by Z for depth)
            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;
                
                foreach (var butterfly in butterflies.OrderBy(b => b.Z))
                {
                    float scale = 1.0f + butterfly.Z * 0.5f;
                    float wingSpread = (float)Math.Sin(butterfly.WingPhase) * 10 * scale;
                    
                    paint.Color = butterfly.Color.WithAlpha((byte)(200 + butterfly.Z * 50));
                    
                    // Draw butterfly body
                    canvas.DrawCircle(butterfly.X, butterfly.Y, 3 * scale, paint);
                    
                    // Draw wings
                    using (var path = new SKPath())
                    {
                        // Left wing
                        path.MoveTo(butterfly.X - 2 * scale, butterfly.Y);
                        path.QuadTo(butterfly.X - 15 * scale - wingSpread, butterfly.Y - 10 * scale,
                                   butterfly.X - 10 * scale - wingSpread, butterfly.Y + 5 * scale);
                        path.QuadTo(butterfly.X - 5 * scale, butterfly.Y + 3 * scale,
                                   butterfly.X - 2 * scale, butterfly.Y);
                        
                        // Right wing
                        path.MoveTo(butterfly.X + 2 * scale, butterfly.Y);
                        path.QuadTo(butterfly.X + 15 * scale + wingSpread, butterfly.Y - 10 * scale,
                                   butterfly.X + 10 * scale + wingSpread, butterfly.Y + 5 * scale);
                        path.QuadTo(butterfly.X + 5 * scale, butterfly.Y + 3 * scale,
                                   butterfly.X + 2 * scale, butterfly.Y);
                        
                        paint.Style = SKPaintStyle.Fill;
                        canvas.DrawPath(path, paint);
                    }
                }
            }
        }

        // Helper classes
        public class MatrixColumn
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Speed { get; set; }
            public float LastCharY { get; set; }
            public List<(char ch, float opacity)> CharHistory { get; set; } = new();
        }

        public class ExpandingShape
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Radius { get; set; }
            public float MaxRadius { get; set; }
            public float ExpansionSpeed { get; set; }
            public int Sides { get; set; }
            public float Rotation { get; set; }
            public float RotationSpeed { get; set; }
            public float HueOffset { get; set; }
        }

        public class Butterfly
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
            public float VX { get; set; }
            public float VY { get; set; }
            public float VZ { get; set; }
            public float AX { get; set; }
            public float AY { get; set; }
            public float AZ { get; set; }
            public SKColor Color { get; set; }
            public float WingPhase { get; set; }
        }
    }
}