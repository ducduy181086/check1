namespace Check1.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Check1.Domain;

    public class VendorDataStore : IVendorDataStore
    {
        private readonly ICollection<Vendor> vendors;

        public VendorDataStore(ICollection<Vendor> vendors)
        {
            this.vendors = vendors;
        }

        public Task AddAsync(Vendor vendor, CancellationToken cancellationToken = default(CancellationToken))
        {
            vendors.Add(vendor);
            return Task.CompletedTask;
        }

        public Task<Vendor> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var vendor = vendors.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(vendor);
        }
    }
}