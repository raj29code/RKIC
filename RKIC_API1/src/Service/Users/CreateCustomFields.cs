
using MongoDB.Driver;
using RKICUser = Service.Model.User;

namespace Service.Users
{
    public class CustomFieldsKeyGenerator: KeyGenerator<RKICUser>
    {
        public CustomFieldsKeyGenerator(IMongoDbCollection<RKICUser> collection)
            : base(collection)
        {
        }

        protected override void SetID(RKICUser maxEntity, RKICUser newEntity)
        {
           
        }

        protected override SortDefinition<RKICUser> Sort()
        {
            return Builders<RKICUser>.Sort.Descending(o => o.FirstName);
        }
    }

}