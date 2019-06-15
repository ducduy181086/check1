namespace Check1.Repository.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Check1.Domain;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ItemDataStoreTest
    {
        [TestMethod]
        public async Task AddAsyncTest()
        {
            var dataStore = new ItemDataStore(new List<Item>());
            await dataStore.AddAsync(new Item { Id = 1, Name = "Test1" });
        }
    }
}