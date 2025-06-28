using System;

namespace VisualEffectsApp
{
    // Simplified stub for non-MAUI environment
    public class Application
    {
        public object MainPage { get; set; }
    }
    
    public partial class App : Application
    {
        public App()
        {
            // Simplified initialization without MAUI dependencies
            MainPage = new MainPage();
        }
    }
}