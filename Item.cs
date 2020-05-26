namespace TowerDefence
{
    public abstract class Item
    {
        public readonly int price;

        public abstract void ToAffect();

        public Item(
            int _price
            )
        {
            price = _price;
        }
    }
}