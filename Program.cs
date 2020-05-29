using System;
using SFML.Graphics;
using SFML.Window;

namespace TowerDefence
{
    class Program
    {
        public static RenderWindow window;
        public static int currentState;
        /*
         * 0 - main scene
         * 1 - menu
         */
        static void Main(string[] args)
        {
            window = new RenderWindow(new VideoMode(Config.ScreenWidth, Config.ScreenHeight), "Tower Defence", Styles.Fullscreen);
            window.SetMouseCursorVisible(false);
            window.SetVerticalSyncEnabled(true);
            window.Closed += Window_Closed;
            window.Resized += Window_Resized;

            var model = new Model();
            var world = new World(Config.Map);
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black);
                
                Controller.Update();
                Model.Update(0.1f);
                world.Update();
                
                window.Draw(world);
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e) => window.Close();

        private static void Window_Resized(object sender, SizeEventArgs e) =>
            window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
    }
}