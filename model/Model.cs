using System;
using System.Collections.Generic;
using System.Linq;
using SFML.System;

namespace TowerDefence
{ 
    class Model
    { 
        public static Clock WaveClock;
        public static int HomeHP;
        public static string[] Map;
        public static List<Mob> Wave;
        public static List<Tower> Towers;
        public static Queue<Mob> WaveQueue;
        
        public static bool TowerListChanged;
        
        public Model()
        {
            Config.Load();
            WaveClock = new Clock();
            HomeHP = Config.HomeHP;
            Map = Config.Map;
            Wave = new List<Mob>();
            Towers = new List<Tower>();
            WaveQueue = new Queue<Mob>();
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

        public static void NewWave(int WaveId)
        {
            Console.WriteLine("NEW NIGGER BORN WITH ID " + WaveId);
            switch (WaveId)
            {
                case 0:
                    for (var i = 0; i < 20; i++)
                    {
                        WaveQueue.Enqueue(new Infantryman());
                    }
                    break;
                default:
                    break;
            }

            WaveClock.Restart();
        }
        
        public static void Update(float deltaTime)
        {
            if (WaveQueue.Count != 0 && WaveClock.ElapsedTime >= Config.WaveTime)
            {
                Wave.Add(WaveQueue.Dequeue());
                WaveClock.Restart();
            }
            if (Wave.Count != 0)
            {
                foreach (var mob in Wave)
                {
                    mob.Move(deltaTime);
                    //Console.WriteLine(mob.position);
                }
            }

            // тут башни стукают по мобам и двигают табуретки
            
            foreach (var mob in Wave)
            {
                if (mob.ArrivedToBase())
                {
                    HomeHP -= mob.configs.damage;
                    mob.currHealth = 0;
                }
            }
            
            Wave = Wave
                .Where(mob => !mob.IsDead())
                .ToList();
        }
    }
}