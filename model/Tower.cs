using System;
using System.Collections.Generic;
using System.Numerics;
using SFML.Graphics;
using SFML.System;

namespace TowerDefence
{
    public abstract class Tower
    {
        public readonly struct Configs
        {
            public readonly string name;
            public readonly Config.Attribute baseAttribute;
            public readonly bool isMelee; // close or long-range attack 
            public readonly bool baseHaveMana; // tower may not has mana (if has passive ability)
            public readonly int maxMana;
            public readonly int baseManaRegen;
            public readonly int baseDamage;
            public readonly double baseAttackRange;
            public readonly double baseAttackTime;
            public readonly Texture texture;

            public Configs(
                string _name,
                Config.Attribute _baseAttribute,
                bool _isMelee, 
                bool _baseHaveMana,
                int _maxMana,
                int _baseManaRegen,
                int _baseDamage,
                double _baseAttackRange,
                double _baseAttackTime,
                Texture _texture)
            {
                name = _name;
                baseAttribute = _baseAttribute;
                isMelee = _isMelee;
                baseHaveMana = _baseHaveMana;
                maxMana = _maxMana;
                baseManaRegen = _baseManaRegen;
                baseDamage = _baseDamage;
                baseAttackRange = _baseAttackRange;
                baseAttackTime = _baseAttackTime;
                texture = _texture;
            }
        }

        public Configs configs;
        public Config.Attribute Attribute;

        public bool currHaveMana; // one of items will 'turn off' mana of the tower
        public int currMana;
        public int currManaRegen;
        public int currDamage;
        public double currAttackRange;
        public Time currAttackTime;
        public double modifiedAttackSpeed;
        public double effectResist;
        public double trueStrike;
        
        public Vector2i position;
        public int level;
        
        public Time lastShot;

        public List<Ability> Abilities;
        public List<Buff> Buffes;
        public List<Item> Items;

        public Tower(int towerId, Vector2i _position)
        {
            configs = Config.TowerConfigs[towerId];
            Attribute = configs.baseAttribute;
            
            currHaveMana = configs.baseHaveMana;
            currMana = 0;
            currManaRegen = configs.baseManaRegen;
            currDamage = configs.baseDamage;
            currAttackRange = configs.baseAttackRange;
            currAttackTime = Time.FromSeconds((float)configs.baseAttackTime);
            modifiedAttackSpeed = 0;
            effectResist = 0;
            trueStrike = 0;

            level = 1;
            lastShot = Time.Zero;
            position = _position;
            
            Abilities = new List<Ability>();
            Abilities.Add(new Absorption());
            Abilities.Add(new Replacing());
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
        public TheFirstTower(Vector2i _position) : base (0, _position){}
    }

    public class Windranger : Tower
    {
        public Windranger(Vector2i _position) : base (1, _position)
        {
            Abilities.Add(new FocusFire());
        }
    }
}