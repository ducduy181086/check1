namespace Check1.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;

    public class ItemDataStore : IItemDataStore
    {
        private readonly ICollection<Item> items;

        public ItemDataStore(ICollection<Item> items)
        {
            this.items = items;
        }

        public Task AddAsync(Item item, CancellationToken cancellationToken = default(CancellationToken))
        {
            items.Add(item);
            return Task.CompletedTask;
        }
    }
}