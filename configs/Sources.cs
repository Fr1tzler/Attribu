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
        public static string CurrStyle;
        
        public static Dictionary<int, Texture> TowerTextures;
        public static Dictionary<int, Texture> TileTextures;
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
            CurrStyle = "ice01" + divider;
            
            TileTextures = new Dictionary<int, Texture>()
            {
                [0] = new Texture(TexturePath + CurrStyle + "field_1.png"),
                [1] = new Texture(TexturePath + CurrStyle + "field_2.png"),
                [2] = new Texture(TexturePath + CurrStyle + "field_3.png"),
                [3] = new Texture(TexturePath + CurrStyle + "road_corn_dl.png"),
                [4] = new Texture(TexturePath + CurrStyle + "road_corn_dr.png"),
                [5] = new Texture(TexturePath + CurrStyle + "road_corn_ul.png"),
                [6] = new Texture(TexturePath + CurrStyle + "road_corn_ur.png"),
                [7] = new Texture(TexturePath + CurrStyle + "road_cross.png"),
                [8] = new Texture(TexturePath + CurrStyle + "road_horiz.png"),
                [9] = new Texture(TexturePath + CurrStyle + "road_vert.png"),
            };
            
            TowerTextures = new Dictionary<int, Texture>()
            {
                [1] = new Texture(TexturePath + "tower1.png"),
                [2] = new Texture(TexturePath + "tower2.png"),
                [3] = new Texture(TexturePath + "tower3.png"),
            };
            
            FPSfont = new Font(FontPath + "font.ttf");
        }
    }
}