
using MongoDB.Driver;

namespace Service
{
#pragma warning disable 1591
    public interface IMongoDbClient
    {
        IMongoDatabase Database { get; }
    }
}