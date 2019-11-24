

using System.Reflection;
using FMP.Model;
using FMP.Service.Model;
using MongoDB.Driver;

namespace Service
{
    public class MongoDbCollection<T> : IMongoDbCollection<T>
    {
        private readonly IMongoDbClient _mongoDbClient;

        public MongoDbCollection(IMongoDbClient mongoDbClient)
        {
            _mongoDbClient = mongoDbClient;
        }
        public IMongoCollection<T> Collection => GetCollection();

        public string GetCollectionName()
        {
            if (typeof(T).IsGenericType)
            {
                return typeof(T).GetGenericArguments()[0].Name;
            }

            var la = typeof(T).GetCustomAttribute<CollectionNameAttribute>();

            return la != null ? la.Name : typeof(T).Name;
        }


        public IMongoCollection<T> GetCollection() => _mongoDbClient.Database.GetCollection<T>(GetCollectionName());
    }
}