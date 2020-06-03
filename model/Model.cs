using System;
using System.Collections.Generic;
using NUnit.Framework;
using SFML.System;

namespace TowerDefence
{ 
    class Model
    {
        public static string[] Map;

        public static List<Mob> Wave;
        public static List<Tower> Towers;

        public static bool TowerListChanged;
        
        public Model()
        {
            Config.Load();
            Map = Config.Map;
            Wave = new List<Mob>();
            Towers = new List<Tower>();
            
            TowerListChanged = false;
        }

        public static void AddTower(Vector2i position)
        {
            TowerListChanged = true;
            if (Map[position.Y][position.X] != '_')
            {
                //Console.WriteLine("unable to locate tower on " + position + " : it's not a field");
                return;
            }
            foreach (var tower1 in Towers)
            {
                if (tower1.position == position)
                {
                    //Console.WriteLine("unable to locate tower on " + position + " : tower already exists");
                    return;
                }
            }

            int towerId = MathModule.RandInt(0, Config.TowerConfigs.Count);

            switch (towerId)
            {
                case 0:
                    Towers.Add(new TheFirstTower(position));
                    break;
                case 1:
                    Towers.Add(new Windranger(position));
                    break;
                default:
                    Towers.Add(new TheFirstTower(position));
                    break;
            }
            
            Console.WriteLine("new " + Towers[Towers.Count - 1].configs.name + " has born on " + position);
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