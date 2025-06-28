using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualEffectsApp.Core;

namespace VisualEffectsApp
{
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
            
            // Request next frame
            canvasView.InvalidateSurface();
        }

        private void OnCanvasTapped(object sender, EventArgs e)
        {
            // Cycle to next effect
            visualEngine.SwitchToNextEffect();
        }
    }
}