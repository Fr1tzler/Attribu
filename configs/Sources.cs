using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace TowerDefence
{
    static class Sources
    {
        public static string TexturePath;
        public static string FontPath;
        public static List<string> StyleList;
        public static string CurrStyle;
        
        public static Dictionary<int, Texture> TowerTextures;
        public static Dictionary<int, Texture> TileTextures;
        public static Dictionary<int, Texture> MobTextures;
        public static Font FPSfont;
        public static Image tower1;

        public static void Load()
        {
            var divider = "\\";
            if (Program.OSFamily == PlatformID.Unix)
            {
                divider = "/";
            }
            TexturePath = "src" + divider + "textures" + divider;
            FontPath = "src" + divider + "fonts" + divider;
            StyleList = new List<string>()
            {
                "ice00",
                "lava01",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
            };
            CurrStyle = StyleList[4] + divider;
            
            TileTextures = new Dictionary<int, Texture>()
            {
                [0] = new Texture(TexturePath + CurrStyle + "0.png"),
                [1] = new Texture(TexturePath + CurrStyle + "1.png"),
                [2] = new Texture(TexturePath + CurrStyle + "2.png"),
                [3] = new Texture(TexturePath + CurrStyle + "3.png"),
                [4] = new Texture(TexturePath + CurrStyle + "4.png"),
                [5] = new Texture(TexturePath + CurrStyle + "5.png"),
                [6] = new Texture(TexturePath + CurrStyle + "6.png"),
                [7] = new Texture(TexturePath + CurrStyle + "7.png"),
                [8] = new Texture(TexturePath + CurrStyle + "8.png"),
                [9] = new Texture(TexturePath + CurrStyle + "9.png"),
            };
            
            TowerTextures = new Dictionary<int, Texture>()
            {
                [1] = new Texture(TexturePath + "tower1.png"),
                [2] = new Texture(TexturePath + "tower2.png"),
                [3] = new Texture(TexturePath + "tower3.png"),
            };
            
            MobTextures = new Dictionary<int, Texture>()
            {
                [1] = new Texture(TexturePath + "mob0.png"),
                [2] = new Texture(TexturePath + "tower2.png"),
                [3] = new Texture(TexturePath + "tower3.png"),
            };
            
            FPSfont = new Font(FontPath + "font.ttf");
        }
    }
}