using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using VisualEffectsApp.Core;

namespace VisualEffectsApp;

public partial class MainPage : ContentPage
{
    private VisualEffectsEngine visualEngine;
    
    public MainPage()
    {
        InitializeComponent();
        visualEngine = new VisualEffectsEngine();
    }

    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        visualEngine.RenderFrame(args.Surface.Canvas, args.Info);
    }

    private void OnCanvasTapped(object sender, EventArgs e)
    {
        // Cycle to next effect
        visualEngine.SwitchToNextEffect();
    }
}