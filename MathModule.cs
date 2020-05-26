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

        public static int AttacksPerSecond(double baseAttackTime, int modifiedAttackSpeed)
        {
            int currAS = (int)((100 + modifiedAttackSpeed) * 0.01 / baseAttackTime);
            return Math.Max(20, Math.Min(700, currAS));
        }

        public static double AttackTime(double baseAttackTime, int addAttackSpeed)
        {
            return 1 / AttacksPerSecond(baseAttackTime, addAttackSpeed);
        }
    }
}