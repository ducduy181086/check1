namespace Check1.Service
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;
    using Check1.Domain.Enums;

    public interface IStoreService
    {
        Task AddItemAsync(Item item, CancellationToken cancellationToken = default(CancellationToken));

        Task AddVendorAsync(Vendor vendor, CancellationToken cancellationToken = default(CancellationToken));

        Task<Order> BuyAsync(Order order, int vendorId, CancellationToken cancellationToken = default(CancellationToken));

        Task<Order> SellAsync(Order order, int vendorId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<ItemColor>> GetAllItemColorsAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<ItemSize>> GetAllItemSizesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<ItemType>> GetAllItemTypesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}