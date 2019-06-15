namespace Check1.Repository
{
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;

    public interface IItemDataStore
    {
        Task AddAsync(Item item, CancellationToken cancellationToken = default(CancellationToken));
    }
}