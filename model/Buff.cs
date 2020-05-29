using SFML.System;

namespace TowerDefence
{
    public abstract class Buff
    {
        public readonly bool isDebuff;
        public readonly bool haveDuration;
        public readonly Time duration;

        public abstract void ToBuff();

        public Buff(
            bool _isDebuff,
            bool _haveDuration,
            Time _duration
            )
        {
            isDebuff = _isDebuff;
            haveDuration = _haveDuration;
            duration = _duration;
        }
    }
}