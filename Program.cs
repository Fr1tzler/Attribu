using System;
using SFML.Graphics;
using SFML.Window;

namespace TowerDefence
{
    class Program
    {
        public static RenderWindow window;

        static void Main(string[] args)
        {
            window = new RenderWindow(new VideoMode(800, 800), "Tower Defence");
            window.SetVerticalSyncEnabled(true);
            window.Closed += Window_Closed;
            window.Resized += Window_Resized;

            TowerDefence.Main.Start();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                TowerDefence.Main.Update();
                window.Clear(Color.Black);
                TowerDefence.Main.Draw(window);
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e) => window.Close();
        
        private static void Window_Resized(object sender, SizeEventArgs e) => window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
    }
}