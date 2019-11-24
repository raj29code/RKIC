

using System.Threading.Tasks;
using MongoDB.Driver;



namespace Service
{
    public class EntityExists<T> :
        HandlerBase<T>,
        IQueryHandler<IQuery<T>, bool> where T : class
    {
        public EntityExists(IMongoDbCollection<T> userProfiles) :
            base(userProfiles)
        { }

        public async Task<bool> Handle(IQuery<T> query)
        {
            var exists = await Collection.Find(
                query.FilterDefinition()).AnyAsync();

            return exists;
        }
    }
}