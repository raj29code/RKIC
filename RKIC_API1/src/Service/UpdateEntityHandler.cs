

using System.Threading.Tasks;
using MongoDB.Driver;

#pragma warning disable 1591

namespace Service
{
    public class UpdateEntityHandler<T> :
        HandlerBase<T>,
        ICommandHandler<IUpdateCommand<T>> where T : class
    {
        public UpdateEntityHandler(IMongoDbCollection<T> userProfiles) :
            base(userProfiles)
        {
        }

        public async Task<bool> Handle(IUpdateCommand<T> command)
        {
            if (!command.IsValid()) return false;

            var filter = command.FilterDefinition();
            var underStatement = command.UpdateDefinition();

            UpdateResult actionResult;
            if (command.IsManyUpdate)
                actionResult = await Collection
                    .UpdateManyAsync(filter, underStatement, new UpdateOptions {IsUpsert = true});
            else
                actionResult = await Collection
                    .UpdateOneAsync(filter, underStatement, new UpdateOptions {IsUpsert = true});

            return actionResult.IsSuccess();
        }
    }
}