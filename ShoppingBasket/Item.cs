namespace ShoppingBasket
{
    public sealed class Item
    {
        public int Price { get { return _price; } }
        public string Name { get { return _name; } }

        private readonly int _price;
        private readonly string _name;

        public Item(string name, int price)
        {
            _price = price;
            _name = name;
        }
    }
}
