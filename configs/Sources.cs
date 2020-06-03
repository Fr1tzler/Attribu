using System.Collections.Generic;
using SFML.Graphics;

namespace TowerDefence
{
    static class Sources
    {
        public const string Textures = "src\\textures\\";
        public const string CurrStyle = "ice01\\";

        public static Dictionary<int, Texture> TileTextures;

        public static Image tower1;

        public static void Load()
        {
            TileTextures = new Dictionary<int, Texture>()
            {
                [0] = new Texture(Textures + CurrStyle + "field_1.png"),
                [1] = new Texture(Textures + CurrStyle + "field_2.png"),
                [2] = new Texture(Textures + CurrStyle + "field_3.png"),
                [3] = new Texture(Textures + CurrStyle + "road_corn_dl.png"),
                [4] = new Texture(Textures + CurrStyle + "road_corn_dr.png"),
                [5] = new Texture(Textures + CurrStyle + "road_corn_ul.png"),
                [6] = new Texture(Textures + CurrStyle + "road_corn_ur.png"),
                [7] = new Texture(Textures + CurrStyle + "road_cross.png"),
                [8] = new Texture(Textures + CurrStyle + "road_horiz.png"),
                [9] = new Texture(Textures + CurrStyle + "road_vert.png"),
            };
            
            tower1 = new Image(Textures + "tower1.png");
        }
    }
}