namespace TowerDefence
{
    public class Mob
    {
        public readonly string className;
        
        public readonly int baseHealth;
        public readonly int baseSpeed;
        public readonly int damage;
        public readonly int baseMagicalResist;
        public readonly int basePhysicalResist;
        
        public int currHealth;
        public int currSpeed;
        public int currMagicalResist;
        public int currPhysicalResist;
    }
}