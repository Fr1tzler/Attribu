using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.System;

namespace TowerDefence
{
    public class Tower
    {
        public readonly Vector2i position;
        public int level;
        public readonly bool baseHaveMana; // tower may not has mana (if has passive ability)
        public readonly int maxMana;
        public readonly int baseManaRegen;
        public readonly int baseDamage;
        public readonly double baseAttackSpeed;

        public bool currHaveMana; // one of items will 'turn off' mana of the tower
        public int currMana;
        public int currManaRegen;
        public int currDamage;
        public double currAttackSpeed;
        public double effectResist;
        public double trueStrike;
        private Time lastShot;

        public List<Ability> Abilities;

        
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

        public void Death()
        {
            
        }
    }
}