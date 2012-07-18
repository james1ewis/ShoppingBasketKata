using Microsoft.VisualStudio.TestTools.UnitTesting;
using SB = ShoppingBasket;

namespace ShoppingBasketTest
{
    [TestClass]
    public class ShoppingBasketTest
    {
        private SB.ShoppingBasket sut = new SB.ShoppingBasket();

        [TestMethod]
        public void EmptyBasketShouldReturnZeroForTheTotalPrice()
        {            
            var total = SB.BasketCalculator.GetTotalPrice(sut);
            Assert.IsTrue(total == 0);
        }

        [TestMethod]
        public void GetTotalPriceShouldReturnTheSumPriceOfEverythingAddedToTheBasket()
        {
            var item1 = new SB.Item("Item1", 50);
            var item2 = new SB.Item("Item2", 45);

            sut = sut.AddItem(item1).AddItem(item2);

            var totalPrice = SB.BasketCalculator.GetTotalPrice(sut);
            
            Assert.AreEqual(item2.Price + item1.Price, totalPrice);
        }

        [TestMethod]
        public void GetTotalPricePlusDeliveryShouldReturnTheTotalPricePlusTheDeliveryCharges()
        {
            var item1 = new SB.Item("Item1", 50);

            sut = sut.AddItem(item1);

            var totalPricePlusDelivery = 
                SB.BasketCalculator.GetTotalPricePlusDelivery(
                    SB.BasketCalculator.GetTotalPrice(sut), sut.NumberOfItems);

            Assert.AreEqual(item1.Price + 0.5 + 2.5, totalPricePlusDelivery);
        }

        [TestMethod]
        public void GetTotalPricePlusVatShouldreturnTheTotalPricePlusDeliveryMultipliedByTheVat()
        {
            var item1 = new SB.Item("Item1", 50);

            sut = sut.AddItem(item1);

            var totalPricePlusDelivery = 
                SB.BasketCalculator.GetTotalPricePlusVat(
                    SB.BasketCalculator.GetTotalPricePlusDelivery(
                        SB.BasketCalculator.GetTotalPrice(sut), sut.NumberOfItems));

            Assert.AreEqual((item1.Price + 0.5 + 2.5) * 1.2, totalPricePlusDelivery);
        }

        [TestMethod]
        public void GetTotalPriceWithDiscountShouldDiscountTheTotalPrice()
        {
            var item = new SB.Item("item1", 200);

            sut = sut.AddItem(item);

            var totalPriceWithDiscount =
                SB.BasketCalculator.GetTotalPriceWithDiscount(
                    SB.BasketCalculator.GetTotalPrice(sut));

            Assert.AreEqual(item.Price * .9, totalPriceWithDiscount);
        }
    }
}
