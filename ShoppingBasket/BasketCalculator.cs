using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public static class BasketCalculator
    {
        public static double GetTotalPrice(ShoppingBasket items)
        {
            return items.Sum(item => item.Price);
        }

        public static double GetTotalPricePlusDelivery(double totalPrice, int itemCount)
        {
            return totalPrice + (.5 * itemCount) + 2.5;
        }

        public static double GetTotalPricePlusVat(double totalPrice)
        {
            return totalPrice * 1.2;
        }

        public static double GetTotalPriceWithDiscount(double totalPrice)
        {
            return totalPrice * .9;
        }
    }
}
