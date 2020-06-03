using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TowerDefence
{
    public static class Config
    {
        /// <summary>
        /// Tower configurations
        /// </summary>
        public enum Attribute
        {
            Strength,
            Agility,
            Intelligence
        }

        public static Color[] AttributeColor = // poka net textur
        {
            Color.Red, Color.Green, Color.Blue,
        };

        public static Dictionary<int, Tower.Configs> TowerConfigs;


        public static int TowerMaxLevel = 6;
        public static int BaseMeleeAttackRadius = 2;
        public static int BaseRangeAttackRadius = 3;

        /// <summary>
        /// Mob configurations
        /// </summary>
        /// 
        public static Dictionary<int, Mob.Configs> MobConfigs;

        public static Dictionary<int, List<int>> WaveConfigs = new Dictionary<int, List<int>>();

        public static void LoadWave(int waveId)
        {
            WaveConfigs[waveId] = new List<int>();
            WaveConfigs[waveId].Add(0);
        }

        public static Vector2f[] Path =
        {
            new Vector2f(2, 1),
            new Vector2f(2, 6),
            new Vector2f(13, 6),
            new Vector2f(13, 2),
            new Vector2f(9, 2),
            new Vector2f(9, 13),
            new Vector2f(13, 13),
            new Vector2f(13, 9),
            new Vector2f(2, 9),
            new Vector2f(2, 13),
            new Vector2f(6, 13),
            new Vector2f(6, 0)
        };

        /// <summary>
        /// World configurations
        /// </summary>
        public static int HomeHP = 50;
        public static Time WaveTime = Time.FromSeconds(0.5f);
        public static string[] Map =
        {
            "________________",
            "______r_________",
            "__r___r__rrrrr__",
            "__r___r__r___r__",
            "__r___r__r___r__",
            "__r___r__r___r__",
            "__rrrrrrrrrrrr__",
            "______r__r______",
            "______r__r______",
            "__rrrrrrrrrrrr__",
            "__r___r__r___r__",
            "__r___r__r___r__",
            "__r___r__r___r__",
            "__rrrrr__rrrrr__",
            "________________",
            "________________"
        };

        public const int TILE_SIZE = 50;

        public static uint ScreenWidth = VideoMode.DesktopMode.Width;
        public static uint ScreenHeight = VideoMode.DesktopMode.Height;
        public static Vector2f PositionShift = new Vector2f(ScreenWidth / 2, 10);

        public static void Load()
        {
            TowerConfigs =
                new Dictionary<int, Tower.Configs>()
                {
                    [0] = new Tower.Configs(
                        "Fritzler",
                        Attribute.Strength,
                        true,
                        false,
                        0,
                        0,
                        1,
                        2,
                        1.7,
                        Sources.TowerTextures[1]),
                    [1] = new Tower.Configs(
                        "Windranger",
                        Attribute.Intelligence,
                        true,
                        false,
                        0,
                        0,
                        1,
                        2,
                        1.7,
                        Sources.TowerTextures[3]),
                };
            MobConfigs =
                new Dictionary<int, Mob.Configs>()
                {
                    [1] = new Mob.Configs(
                        "Infantryman",
                        3,
                        0.005,
                        1,
                        0,
                        0,
                        0,
                        Sources.MobTextures[1]
                    ),
                };
        }
    }
}