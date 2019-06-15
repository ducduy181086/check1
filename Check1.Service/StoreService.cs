namespace Check1.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;
    using Check1.Domain.Enums;
    using Check1.Repository;

    public class StoreService : IStoreService
    {
        private readonly IItemDataStore itemDataStore;
        private readonly IVendorDataStore vendorDataStore;
        private readonly IOrderDataStore orderDataStore;

        public StoreService(IItemDataStore itemDataStore, IVendorDataStore vendorDataStore, IOrderDataStore orderDataStore)
        {
            this.itemDataStore = itemDataStore;
            this.vendorDataStore = vendorDataStore;
            this.orderDataStore = orderDataStore;
        }

        public async Task AddItemAsync(Item item, CancellationToken cancellationToken = default(CancellationToken))
        {
            await itemDataStore.AddAsync(item, cancellationToken);
        }

        public async Task AddVendorAsync(Vendor vendor, CancellationToken cancellationToken = default(CancellationToken))
        {
            await vendorDataStore.AddAsync(vendor, cancellationToken);
        }

        public async Task<Order> BuyAsync(Order order, int vendorId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var vendor = await vendorDataStore.GetAsync(vendorId, cancellationToken);
            order.TotalPrice = 0;
            foreach (var orderDetail in order.OrderDetails)
            {
                order.TotalPrice += orderDetail.Amount * vendor.BuyPrices[orderDetail.ItemType];
            }

            await orderDataStore.AddAsync(order, cancellationToken);
            return order;
        }

        public async Task<Order> SellAsync(Order order, int vendorId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var vendor = await vendorDataStore.GetAsync(vendorId, cancellationToken);
            order.TotalPrice = 0;
            foreach (var orderDetail in order.OrderDetails)
            {
                order.TotalPrice += orderDetail.Amount * vendor.SellPrices[orderDetail.ItemType];
            }

            await orderDataStore.AddAsync(order, cancellationToken);
            return order;
        }

        public Task<IEnumerable<ItemColor>> GetAllItemColorsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Enum.GetValues(typeof(ItemColor)).Cast<ItemColor>());
        }

        public Task<IEnumerable<ItemSize>> GetAllItemSizesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Enum.GetValues(typeof(ItemSize)).Cast<ItemSize>());
        }

        public Task<IEnumerable<ItemType>> GetAllItemTypesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Enum.GetValues(typeof(ItemType)).Cast<ItemType>());
        }
    }
}