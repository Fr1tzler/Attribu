using System.Collections.Generic;
using SFML.System;
using SFML.Window;

namespace TowerDefence
{
    public static class Config
    {
        public enum Attribute
        {
            Strength,
            Agility,
            Intelligence
        }
        
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

        public static Vector2i[] Path =
        {
            new Vector2i(2, 1),
            new Vector2i(2, 6),
            new Vector2i(13, 6),
            new Vector2i(13, 2),
            new Vector2i(9, 2),
            new Vector2i(9, 13),
            new Vector2i(13, 13),
            new Vector2i(13, 9),
            new Vector2i(2, 9),
            new Vector2i(2, 13),
            new Vector2i(6, 13),
            new Vector2i(6, 0)
        };

        public static int TowerMaxLevel = 6;

        public const int TILE_SIZE = 50;

        
        public static uint ScreenWidth = VideoMode.DesktopMode.Width;
        public static uint ScreenHeight = VideoMode.DesktopMode.Height;
    }
}