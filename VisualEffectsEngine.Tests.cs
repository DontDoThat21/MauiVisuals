using SkiaSharp;
using System;
using Xunit;
using VisualEffectsApp.Core;

namespace VisualEffectsApp.Tests
{
    public class VisualEffectsEngineTests
    {
        [Fact]
        public void Engine_Should_Initialize_With_Random_Effect()
        {
            // Arrange & Act
            var engine = new VisualEffectsEngine();
            
            // Assert
            Assert.True(Enum.IsDefined(typeof(VisualEffectsEngine.EffectType), engine.CurrentEffect));
        }

        [Fact]
        public void Engine_Should_Switch_Between_All_Effects()
        {
            // Arrange
            var engine = new VisualEffectsEngine();
            var initialEffect = engine.CurrentEffect;
            
            // Act & Assert
            engine.SwitchToNextEffect();
            var secondEffect = engine.CurrentEffect;
            Assert.NotEqual(initialEffect, secondEffect);
            
            engine.SwitchToNextEffect();
            var thirdEffect = engine.CurrentEffect;
            Assert.NotEqual(secondEffect, thirdEffect);
            
            engine.SwitchToNextEffect();
            var fourthEffect = engine.CurrentEffect;
            
            // Should cycle back to initial effect after 3 switches
            Assert.Equal(initialEffect, fourthEffect);
        }

        [Fact]
        public void Engine_Should_Render_Without_Exception()
        {
            // Arrange
            var engine = new VisualEffectsEngine();
            var imageInfo = new SKImageInfo(800, 600);
            
            using var surface = SKSurface.Create(imageInfo);
            var canvas = surface.Canvas;
            
            // Act & Assert - should not throw
            engine.RenderFrame(canvas, imageInfo);
            
            // Test all effects
            engine.SwitchToNextEffect();
            engine.RenderFrame(canvas, imageInfo);
            
            engine.SwitchToNextEffect();
            engine.RenderFrame(canvas, imageInfo);
        }

        [Theory]
        [InlineData(VisualEffectsEngine.EffectType.MatrixRain)]
        [InlineData(VisualEffectsEngine.EffectType.RecursiveUniverse)]
        [InlineData(VisualEffectsEngine.EffectType.ButterflyEffect)]
        public void All_Effects_Should_Render_Successfully(VisualEffectsEngine.EffectType effectType)
        {
            // Arrange
            var engine = new VisualEffectsEngine();
            var imageInfo = new SKImageInfo(800, 600);
            
            // Navigate to specific effect
            while (engine.CurrentEffect != effectType)
            {
                engine.SwitchToNextEffect();
            }
            
            using var surface = SKSurface.Create(imageInfo);
            var canvas = surface.Canvas;
            
            // Act & Assert - should not throw
            Assert.DoesNotThrow(() => engine.RenderFrame(canvas, imageInfo));
        }
    }
}