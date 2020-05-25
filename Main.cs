using SFML.Graphics;

namespace TowerDefence
{
    static class Main
    {
        public static World world;


        public static void Start()
        {
            string[] Map =
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
            world = new World(Map);
        }

        public static void Update()
        {

        }

        public static void Draw(RenderTarget target)
        {
            target.Draw(world);
        }
    }
}