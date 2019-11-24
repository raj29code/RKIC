
using MongoDB.Driver;

namespace Service
{
    public static class MongoResultExtensions
    {
        public static bool IsSuccess(this UpdateResult updateResult)
        {
            return updateResult != null 
                   && updateResult.IsAcknowledged 
                   && updateResult.ModifiedCount > 0;
        }

        public static bool IsSuccess(this DeleteResult deleteResult)
        {
            return deleteResult != null
                   && deleteResult.IsAcknowledged
                   && deleteResult.DeletedCount > 0;
        }

    }
}
