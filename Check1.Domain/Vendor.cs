namespace Check1.Domain
{
    using System.Collections.Generic;

    using Check1.Domain.Enums;

    public class Vendor
    {
        public Vendor()
        {
            BuyPrices = new Dictionary<ItemType, decimal>();
            SellPrices = new Dictionary<ItemType, decimal>();
        }

        public int Id { get; set; }

        public IDictionary<ItemType, decimal> BuyPrices { get; set; }

        public IDictionary<ItemType, decimal> SellPrices { get; set; }
    }
}