using System;
using System.Numerics;
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
            return Time.FromSeconds((float) (1 / AttacksPerSecond(baseAttackTime, addAttackSpeed)));
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

        public static Vector2f ViewTransform(float x, float y) =>
            new Vector2f(Config.ScreenWidth / 32 * (x - y), Config.ScreenHeight / 32 * (x + y));

        public static Vector2f ViewTransform(Vector2f vect) => ViewTransform(vect.X, vect.Y);
        
        public static Vector2f ReverseViewTransform(float x, float y) => new Vector2f(
            (float)Math.Ceiling(x * 16 / Config.ScreenWidth + y * 16 / Config.ScreenHeight), 
            (float)Math.Ceiling(-x * 16 / Config.ScreenWidth + y * 16 / Config.ScreenHeight));

        public static Vector2f ReverseViewTransform(Vector2f vect) => ReverseViewTransform(vect.X, vect.Y);
    }
}