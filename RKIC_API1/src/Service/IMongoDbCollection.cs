
using MongoDB.Driver;

namespace Service
{
    public interface IMongoDbCollection<T>
    {
        IMongoCollection<T> Collection { get; }
    }
}