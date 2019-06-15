namespace Check1.Repository
{
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;

    public interface IVendorDataStore
    {
        Task AddAsync(Vendor vendor, CancellationToken cancellationToken = default(CancellationToken));

        Task<Vendor> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
    }
}