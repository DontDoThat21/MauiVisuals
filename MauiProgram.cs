using System;

namespace VisualEffectsApp
{
    // Simplified stub for non-MAUI environment
    public class MauiApp
    {
        public static MauiApp CreateBuilder() => new MauiApp();
        public MauiApp UseMauiApp<T>() => this;
        public MauiApp UseSkiaSharp() => this;
        public MauiApp ConfigureFonts(Action<object> configure) => this;
        public MauiApp Build() => this;
    }
    
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    // Font configuration stub
                });

            return builder.Build();
        }
    }
}