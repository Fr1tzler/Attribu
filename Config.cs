using System.Collections.Generic;
using SFML.System;
using SFML.Window;

namespace TowerDefence
{
    public static class Config
    {
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
            "________________",
        };

        public static Vector2f[] Path =
        {
            
        };

        public static int TowerMaxLevel = 6;

        public const int TILE_SIZE = 50;

        
        public static uint ScreenWidth = VideoMode.DesktopMode.Width;
        public static uint ScreenHeight = VideoMode.DesktopMode.Height;
    }
}