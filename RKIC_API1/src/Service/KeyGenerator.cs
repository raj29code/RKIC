

using System.Threading.Tasks;
using MongoDB.Driver;



namespace Service
{
    public abstract class KeyGenerator<T> : IKeyGenerator<T>
    {
        private readonly IMongoDbCollection<T> _collection;

        protected KeyGenerator(IMongoDbCollection<T> collection)
        {
            _collection = collection;
        }

        public async Task Generate(T entity)
        {
            var options = new FindOptions<T, T>
            {
                Limit = 1,
                Sort = Sort()
            };

            var max = (await _collection.Collection.FindAsync(FilterDefinition<T>.Empty, options)).FirstOrDefault();

            SetID(max, entity);
        }

        protected abstract void SetID(T maxEntity, T newEntity);

        protected abstract SortDefinition<T> Sort();
    }
}