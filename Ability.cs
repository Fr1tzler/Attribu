using SFML.System;

namespace TowerDefence
{
    public class Ability
    {
        public readonly bool isActive; // ability will be active (need mana) or passive (don't need mana)
        public readonly double baseCastRange;
        public readonly int manaCost;
        public readonly Time cooldown;
        
        public double currCastRange;
        public bool isGlobal; // ability may be global (has infinity cast range) 
        public bool inCooldown;
        public Time currCooldown; // hz nado li

        public Ability(bool _isActive, double _baseCastRange, int _manaCost, Time _cooldown)
        {
            isActive = _isActive;
            baseCastRange = _baseCastRange;
            manaCost = _manaCost;
            cooldown = _cooldown;
        }
    }

    public class Absorption : Ability
    {
        public Absorption() : base(
            true, 
            0, 
            0, 
            Time.FromMilliseconds(0)
            )
        {
            currCastRange = 0;
            isGlobal = true;
            inCooldown = false;
            currCooldown = Time.FromMilliseconds(0);
        }

        public void Absorb(Tower owner, Tower target)
        {
            target.Death();
            owner.LevelUp();
        }
    }

    public class Replacing : Ability
    {
        public Replacing() : base(
            true, 
            0, 
            0, 
            Time.FromMilliseconds(0)
            )
        {
            currCastRange = 0;
            isGlobal = true;
            inCooldown = false;
            currCooldown = Time.FromMilliseconds(0);
        }
        
        public void Replace(Tower owner, Tower target)
        {
            target.Death();
            owner.LevelUp();
        }
    }
}