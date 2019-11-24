

using FMP.Model.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
#pragma warning disable 1591

namespace Service
{
    public class MongoDbClient : IMongoDbClient
    {
        /// <summary>
        /// FMP Database Initialization
        /// </summary>
        /// <param name="settings"></param>
        public MongoDbClient(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            Database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoDatabase Database { get; }
    }
}
