namespace TowerDefence
{ 
    class Model
    {
        public static string[] Map;
        
        public Model()
        {
            Map = Config.Map;
        }

        public static void Update(double deltaTime) {}
    }
}