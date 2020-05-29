using System.Collections.Generic;
using NUnit.Framework;

namespace TowerDefence
{ 
    class Model
    {
        public static string[] Map;

        public static List<Mob> Wave;
        public static List<Tower> Towers;
        
        public Model()
        {
            Map = Config.Map;
        }

        public static void Update(float deltaTime)
        {
            /*foreach (var mob in Wave)
            {
                mob.Move(deltaTime);
            }*/
        }
    }
}