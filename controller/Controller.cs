using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;

namespace TowerDefence
{
    public static class Controller
    {
        public static Vector2f MousePosition;

        public static Vector2i NormalizedMousePosition;

        public static Queue<Vector2f> MouseClicks = new Queue<Vector2f>();

        private static bool pressM;
        
        public static void Update()
        {
            if (Model.HomeHP <= 0)
            {
                Program.currentState = 2;
                return;
            }
            if (MouseClicks.Count > 0)
            {
                var click = MouseClicks.Dequeue();
                if (Keyboard.IsKeyPressed(Keyboard.Key.N))
                {
                    var clickOnBoard = GetRectangleCoordinates(click);
                    if (MathModule.CorrectVector(clickOnBoard))
                        Model.AddTower(clickOnBoard);
                }
            }

            if (pressM == false)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.M))
                {
                    pressM = true;
                    Model.NewWave(0);
                }
            }
            else if (!Keyboard.IsKeyPressed(Keyboard.Key.M))
            {
                pressM = false;
            } 
            
            MousePosition = (Vector2f) Mouse.GetPosition();
            NormalizedMousePosition = GetRectangleCoordinates(MousePosition);
        }

        public static bool Click => Mouse.IsButtonPressed(Mouse.Button.Left);

        public static Vector2i GetRectangleCoordinates(Vector2f input)
        {
            input.Y += 15;
            var result = new Vector2f();
            var rectangleCoordiantes = MathModule.ReverseViewTransform(input - Config.PositionShift);
            result.X = MathModule.NormalizePoint(rectangleCoordiantes.X);
            result.Y = MathModule.NormalizePoint(rectangleCoordiantes.Y);
            return (Vector2i) result;
        }
    }
}