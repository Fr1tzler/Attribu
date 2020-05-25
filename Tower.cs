using System;
using SFML.System;

namespace TowerDefence
{
    public class Tower
    {
        public readonly Vector2i position;
        public int level;
        public readonly int baseDamage;
        public readonly double baseAttackSpeed;
        public double effectResist;
        
        public int currDamage;
        public double currAttackSpeed;
        private Time lastShot;

        
        public bool ReadyToFire()
        {
            throw new NotImplementedException();
        }

        public bool GetMaxLevel
        {
            get => level == Config.TowerMaxLevel;
        }
        
        public void LevelUp()
        {
            level++;
        }
    }
}