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

        public static double AttacksPerSecond(double baseAttackTime, int modifiedAttackSpeed)
        {
            double currAttackSpeed = (100 + modifiedAttackSpeed) / baseAttackTime;
            return Math.Max(20, Math.Min(700, currAttackSpeed)) * 0.01;
        }

        public static Time AttackTime(double baseAttackTime, int addAttackSpeed)
        {
            return Time.FromSeconds((float)(1 / AttacksPerSecond(baseAttackTime, addAttackSpeed)));
        }

        public static double PhysDamageModificator(int armor)
        {
            return 1 - 0.052 * armor / (0.9 + 0.048 * Math.Abs(armor));
        }

        public static double MagDamageModificator(double magicalResist)
        {
            return magicalResist;
        }

        public static double EffectDurationModificator(double effectResist)
        {
            return effectResist;
        }
    }
}