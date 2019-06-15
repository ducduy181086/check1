namespace Check1.Repository
{
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;

    public interface IOrderDataStore
    {
        Task AddAsync(Order order, CancellationToken cancellationToken = default(CancellationToken));
    }
}