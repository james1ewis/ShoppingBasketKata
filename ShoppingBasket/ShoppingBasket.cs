using System.Collections.Generic;

namespace ShoppingBasket
{
    public sealed class ShoppingBasket : IEnumerable<Item>
    {
        public int NumberOfItems { get { return _items.Count; } }

        private readonly ICollection<Item> _items;

        public ShoppingBasket()
        {
            _items = new List<Item>();
        }

        private ShoppingBasket(Item head, ICollection<Item> tail)
        {
            tail.Add(head);
            _items = new List<Item>(tail);
        }
        
        public ShoppingBasket AddItem(Item item)
        {
            return new ShoppingBasket(item, _items);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
