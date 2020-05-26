using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.System;

namespace TowerDefence
{
    public abstract class Tower
    {
        public Config.Attribute Attribute;
        
        public readonly bool isMelee; // close or long-range attack 
        public readonly bool baseHaveMana; // tower may not has mana (if has passive ability)
        public readonly int maxMana;
        public readonly int baseManaRegen;
        public readonly int baseDamage;
        public readonly double baseAttackTime;

        public bool currHaveMana; // one of items will 'turn off' mana of the tower
        public int currMana;
        public int currManaRegen;
        public int currDamage;
        public double modifiedAttackSpeed;
        public double effectResist;
        public double trueStrike;
        
        public Vector2i position;
        public int level;
        
        public Time lastShot;

        public List<Ability> Abilities;
        public List<Buff> Buffes;
        public List<Item> Items;

        public Tower(
            bool _isMelee,
            bool _baseHaveMana, 
            int _maxMana, 
            int _baseManaRegen, 
            int _baseDamage, 
            double _baseAttackTime
            )
        {
            isMelee = _isMelee;
            baseHaveMana = _baseHaveMana;
            maxMana = _maxMana;
            baseManaRegen = _baseManaRegen;
            baseDamage = _baseDamage;
            baseAttackTime = _baseAttackTime;
        }
        
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

        public void Replace(Vector2i destination)
        {
            this.position = destination;
        }
    }

    public class TheFirstTower : Tower
    {
        TheFirstTower(Vector2i _position) : base(
            true,
            false,
            0,
            0,
            1,
            1.75
            )
        {
            Attribute = Config.Attribute.Strength;
            
            currHaveMana = baseHaveMana;
            currMana = 0;
            currManaRegen = baseManaRegen;
            currDamage = baseDamage;
            modifiedAttackSpeed = 0;
            effectResist = 0;
            trueStrike = 0;

            level = 1;
            lastShot = Time.Zero;
            position = _position;
        }
    }
}