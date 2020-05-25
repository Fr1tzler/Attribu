using SFML.Graphics;

namespace TowerDefence
{
    static class Data
    {
        const string Textures = "Data\\Textures\\";

        public static Texture Field;
        public static Texture Road;

        public static void Load()
        {
            Field = new Texture(Textures + "Field.png");
            Road = new Texture(Textures + "Road.png");
        }
    }
}