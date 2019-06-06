using MongoDB.Driver;
using RealEstate.Properties;

namespace RealEstate
{
    public class RealEstateContext
    {
        public IMongoDatabase Database;

        public RealEstateContext()
        {
            var client = new MongoClient(Settings.Default.RealEstateConnectionString);
            Database = client.GetDatabase(Settings.Default.RealEstateDatabaseName);
        }
    }
}