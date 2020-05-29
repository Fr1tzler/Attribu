using System.Collections.Generic;

namespace TowerDefence
{ 
    class Model
    {
        public static List<Mob> Wave;
        public List<Tower> Towers;
        
        public Model()
        {
            Wave = new List<Mob>();
            Towers = new List<Tower>();
        }

        public static void Update(float deltaTime)
        {
            foreach (var mob in Wave)
            {
                if (Wave.Count == 0)
                    break; 
                mob.Move(deltaTime);
                if (mob.Arrived)
                    mob.currentPathDestinaton++;
            }
        }
    }
}