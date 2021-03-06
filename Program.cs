﻿using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TowerDefence
{
    class Program
    {
        public static PlatformID OSFamily = Environment.OSVersion.Platform;
        public static RenderWindow window;
        public static int currentState;
        /*
         * 0 - main scene
         * 1 - menu
         * 2 - end of game
         */

        static void Main(string[] args)
        {

            window = new RenderWindow(new VideoMode(Config.ScreenWidth, Config.ScreenHeight), 
                "The Attribu", Styles.Fullscreen);
            window.SetMouseCursorVisible(true);
            window.SetVerticalSyncEnabled(true);
            window.Closed += Window_Closed;
            window.Resized += Window_Resized;
            window.MouseButtonPressed += Mouse_Handler;
            
            var world = new World(Config.Map);
            var model = new Model();
            
            var time = DateTime.Now;
            var frameCount = 0;
            
            var FPS = new Text()
            {
                Position = new Vector2f(0, 0),
                FillColor = Color.White,
                CharacterSize = 40,
                Font = Sources.FPSfont
            };
            var HomeHP = new Text()
            {
                Position = new Vector2f(0, 100),
                FillColor = Color.White,
                CharacterSize = 40,
                Font = Sources.FPSfont
            };
            
            var gameoverScreen = new GameOver();
            
            while (window.IsOpen)
            {
                frameCount++;
                
                window.DispatchEvents();
                window.Clear(Color.Black);
                switch (currentState)
                {
                    case 0:
                        Controller.Update();
                        Model.Update(0.1f);
                        world.Update();
                        
                        window.Draw(world);

                        if ((DateTime.Now - time).TotalSeconds > 0.1)
                        {
                            time = DateTime.Now;
                            FPS.DisplayedString = frameCount*10 + "";
                            frameCount = 0;
                        }

                        HomeHP.DisplayedString = Model.HomeHP + "";
                        window.Draw(FPS);
                        window.Draw(HomeHP);
                        
                        break;
                    case 2:
                        //Console.WriteLine("YOU RE FUCKING DEAD NIGGA");
                        window.Draw(gameoverScreen);
                        break;
                    default:
                        break;
                }
                window.Display();
                        
            }
        }

        private static void Mouse_Handler(object sender, MouseButtonEventArgs e) =>
            Controller.MouseClicks.Enqueue((Vector2f) Mouse.GetPosition());
        
        private static void Window_Closed(object sender, EventArgs e) => window.Close();

        private static void Window_Resized(object sender, SizeEventArgs e) =>
            window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
    }
}