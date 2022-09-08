using System.Collections.Generic;

namespace ConsoleApp30

{
    public class Basket
    {
        public List<Item> ItemsInBasket;

        public decimal BasketValue
        {
            get
            {
                decimal basketval = 0;
                foreach (var item in ItemsInBasket)
                {
                    basketval += item.Price;
                }
                return basketval;
            }
            set { }
        }

        public int ItemCount
        {
            get
            {
                int itemcount = 0;
                foreach (var item in ItemsInBasket)
                {
                    itemcount++;
                }
                return itemcount;
            }
            set { }
        }

        public Basket()
        {
            this.ItemsInBasket = new();
        }
        public void AddToBasket(Item i)
        {
            ItemsInBasket.Add(i);
        }

    }
}
