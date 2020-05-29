using SFML.System;
using SFML.Window;

namespace TowerDefence
{
    public static class Controller
    {
        public static Vector2f MousePosition => (Vector2f) Mouse.GetPosition();
        public static bool Click => Mouse.IsButtonPressed(Mouse.Button.Left);
    }
}