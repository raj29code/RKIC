
using MongoDB.Driver;

namespace Service
{
    public abstract class HandlerBase<T> where T : class
    {
        private readonly IMongoDbCollection<T> _collection;

        protected IMongoCollection<T> Collection => _collection.Collection;

        protected HandlerBase(IMongoDbCollection<T> collection)
        {
            _collection = collection;
        }
    }
}
