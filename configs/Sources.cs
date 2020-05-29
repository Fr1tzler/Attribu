using SFML.Graphics;

namespace TowerDefence
{
    static class Sources
    {
        const string Textures = "src\\Textures\\";

        public static Texture Field;
        public static Texture Road;

        public static void Load()
        {
            Field = new Texture(Textures + "Field.png");
            Road = new Texture(Textures + "Road.png");
        }
    }
}