using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace TowerDefence
{
    public abstract class Mob
    {
        public readonly struct Configs
        {
            public readonly string name;
        
            public readonly int baseHealth;
            public readonly double baseSpeed;
            public readonly int damage;
            public readonly int baseMagicalResist;
            public readonly int baseArmor;
            public readonly double evasion;
            public readonly Texture texture;
            
            public Configs(
                string _name,
                int _baseHealth,
                double _baseSpeed,
                int _damage,
                int _baseMagicalResist,
                int _baseArmor,
                double _evasion,
                Texture _texture
                )
            {
                name = _name;
                baseHealth = _baseHealth;
                baseSpeed = _baseSpeed;
                damage = _damage;
                baseMagicalResist = _baseMagicalResist;
                baseArmor = _baseArmor;
                evasion = _evasion;
                texture = _texture;
            }
        }

        public Configs configs;
        
        public int currHealth;
        public double currSpeed;
        public int currMagicalResist;
        public int currArmor;

        public Vector2f position;
        public Vector2f destination;
        public Vector2f shift;
        
        public List<Ability> Abilities;
        public List<Buff> Buffes;
        public int currentDestination;

        public Mob(int mobId)
        {
            configs = Config.MobConfigs[mobId];
            
            currHealth = configs.baseHealth;
            currSpeed = configs.baseSpeed;
            currMagicalResist = configs.baseMagicalResist;
            currArmor = configs.baseArmor;
            position = Config.Path[0];
            destination = Config.Path[1];

            shift = new Vector2f(0, 0);
            currentDestination = 1;
        }
        
        public bool Arrived
        {
            get => MathModule.Length(position - destination) <= 10e-6;
        }

        public bool ArrivedToBase()
        {
            return MathModule.Length(position - Config.Path[Config.Path.Length - 1]) <= 10e-6;
        }
        
        public void Move(float deltaTime)
        {
            var delta = destination - position;
            var deltaLength = MathModule.Length(delta);
            position += delta * (float) (Math.Min(currSpeed / deltaLength, 1));
            if (Arrived)
            {
                if (currentDestination == Config.Path.Length - 1)
                {
                    return;
                    // чёто добавить
                }
                currentDestination++;
                destination = Config.Path[currentDestination];
            }
        }

        public bool IsDead()
        {
            return currHealth <= 0;
        }
    }

    public class Infantryman : Mob
    {
        public Infantryman() : base(1){}
    }
}