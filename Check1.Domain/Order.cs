namespace Check1.Domain
{
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public decimal TotalPrice { get; set; }
    }
}