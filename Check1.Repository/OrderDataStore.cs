namespace Check1.Repository
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;

    public class OrderDataStore : IOrderDataStore
    {
        private readonly ICollection<Order> orders;

        public OrderDataStore(ICollection<Order> orders)
        {
            this.orders = orders;
        }

        public Task AddAsync(Order order, CancellationToken cancellationToken = default(CancellationToken))
        {
            orders.Add(order);
            return Task.CompletedTask;
        }
    }
}