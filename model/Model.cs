using System;
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
            Wave = new List<Mob>();
            Towers = new List<Tower>();
        }

        public static void AddTower(Tower tower)
        {
            if (Map[tower.position.Y][tower.position.X] != '_')
            {
                Console.WriteLine("unable to locate tower on " + tower.position + " : it's not a field");
                return;
            }
            foreach (var tower1 in Towers)
            {
                if (tower1.position == tower.position)
                {
                    Console.WriteLine("unable to locate tower on " + tower.position + " : tower already exists");
                    return;
                }
            }
            Towers.Add(tower);
            Console.WriteLine("new tower has born on" + tower.position);
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