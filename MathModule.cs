using System;
using SFML.System;

namespace TowerDefence
{
    public static class MathModule
    {
        public static double Length(Vector2f vect)
        {
            return Math.Sqrt(vect.X * vect.X + vect.Y * vect.Y);
        }
    }
}