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

            var model = new Model();
            var world = new World(Model.Map);
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                Model.Update(0.1);
                window.Clear(Color.Black);
                window.Draw(world);
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e) => window.Close();

        private static void Window_Resized(object sender, SizeEventArgs e) =>
            window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
    }
}