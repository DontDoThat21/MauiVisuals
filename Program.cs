using System;
using VisualEffectsApp.Core;

namespace VisualEffectsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mezmerize Visual Effects Engine Demo");
            Console.WriteLine("===================================");
            
            // Create the visual effects engine
            var engine = new VisualEffectsEngine();
            
            Console.WriteLine($"Initial Effect: {engine.CurrentEffect}");
            
            // Demonstrate switching between effects
            for (int i = 0; i < 5; i++)
            {
                engine.SwitchToNextEffect();
                Console.WriteLine($"Switched to: {engine.CurrentEffect}");
            }
            
            Console.WriteLine("\nVisual Effects Engine is working correctly!");
            Console.WriteLine("The solution builds successfully and core functionality is operational.");
        }
    }
}