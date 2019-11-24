

using System.Threading.Tasks;
using MongoDB.Driver;

namespace Service
{
    public class GetHandler<T> :
        HandlerBase<T>,
        IQueryHandler<IQuery<T>, T> where T : class
    {
        public GetHandler(IMongoDbCollection<T> userProfiles) :
            base(userProfiles)
        {
        }

        public async Task<T> Handle(IQuery<T> query)
        {
            var profile = await Collection.Find(
                    query.FilterDefinition())
                .SingleOrDefaultAsync();

            return profile;
        }
    }
}