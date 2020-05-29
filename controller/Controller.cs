using System;
using SFML.System;
using SFML.Window;

namespace TowerDefence
{
    public static class Controller
    {
        public static Vector2f MousePosition;

        public static Vector2i NormalizedMousePosition;

        public static void Update()
        {
            MousePosition = (Vector2f) Mouse.GetPosition();
            MousePosition.Y += 20;
            var rectangleCoordiantes = MathModule.ReverseViewTransform(MousePosition - Config.PositionShift);
            NormalizedMousePosition.X = MathModule.NormalizePoint(rectangleCoordiantes.X);
            NormalizedMousePosition.Y = MathModule.NormalizePoint(rectangleCoordiantes.Y);
        }
        public static bool Click => Mouse.IsButtonPressed(Mouse.Button.Left);
    }
}