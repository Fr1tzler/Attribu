using System;
using System.Collections.Generic;
using SFML.System;

namespace TowerDefence
{
    public class Mob
    {
        public readonly string className;
        
        public readonly int baseHealth;
        public readonly int baseSpeed;
        public readonly int damage;
        public readonly int baseMagicalResist;
        public readonly int baseArmor;
        public readonly double evasion;
        
        public int currHealth;
        public int currSpeed;
        public int currMagicalResist;
        public int currArmor;

        public Vector2f position;
        public Vector2f destination;
        public Vector2f shift;
        
        public List<Ability> Abilities;
        //public List<Buff> Buffes; // in future versions
        
        public bool Arrived
        {
            get => MathModule.Length(position - destination) <= 10e-6;
        }
        
        public void Move()
        {
            var delta = destination - position;
            var deltaLength = MathModule.Length(delta);
            position += delta * (float) (Math.Min(currSpeed / deltaLength, 1));
        }
    }
}