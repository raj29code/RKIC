

using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Service
{
    public class GetCollectionHandler<T> :
        HandlerBase<T>,
        IQueryHandler<IQuery<T>, IReadOnlyList<T>> where T : class
    {
        public GetCollectionHandler(IMongoDbCollection<T> userProfiles) :
            base(userProfiles)
        {
        }

        public async Task<IReadOnlyList<T>> Handle(IQuery<T> query)
        {
            var profile = await Collection.Find(
                query.FilterDefinition()
            ).ToListAsync();

            return profile;
        }
    }

    public class GetListHandler<T> :
        HandlerBase<T>,
        IQueryHandler<IQuery<T>, List<T>> where T : class
    {
        public GetListHandler(IMongoDbCollection<T> userProfiles) :
            base(userProfiles)
        {
        }

        public async Task<List<T>> Handle(IQuery<T> query)
        {
            var profile = await Collection.Find(
                query.FilterDefinition()
            ).ToListAsync();

            return profile;
        }
    }
}