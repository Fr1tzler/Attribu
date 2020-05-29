using System.Collections.Generic;

namespace TowerDefence
{ 
    class Model
    {
        public static string[] Map;

        public List<Mob> Wave;
        public List<Tower> Towers;
        
        public Model()
        {
            Map = Config.Map;
        }

        public static void Update(double deltaTime)
        {
            
        }
    }
}