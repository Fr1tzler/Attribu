using System;
using System.Numerics;
using SFML.System;

namespace TowerDefence
{
    public abstract class Ability
    {
        public readonly bool isActive; // ability will be active (need mana) or passive (don't need mana)
        public readonly double baseCastRange;
        public readonly int manaCost;
        public readonly Time cooldown;
        
        public double currCastRange;
        public bool isGlobal; // ability may be global (has infinity cast range) 
        public bool inCooldown;
        public Time currCooldown; // hz nado li

        public Ability(
            bool _isActive, 
            double _baseCastRange, 
            int _manaCost, 
            Time _cooldown
            )
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
            owner.LevelUp();
            target.Death();
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
            target.Replace(owner.position);
            target.LevelUp();
            owner.Death();
        }
    }

    public class FocusFire : Ability
    {
        public double[] modBaseAttackTime;
        public FocusFire() : base(
            false, 
            0, 
            0, 
            Time.FromMilliseconds(0)
        )
        {
            currCastRange = 0;
            isGlobal = false;
            inCooldown = false;
            currCooldown = Time.FromMilliseconds(0);
            modBaseAttackTime = new[] {-0.1, -0.2, -0.3, -0.4, -0.5, -0.6};
        }

        public void DoFocusFire(Tower owner)
        {
            owner.currAttackTime += Time.FromSeconds((float)modBaseAttackTime[owner.level - 1]);
        }
    }
}