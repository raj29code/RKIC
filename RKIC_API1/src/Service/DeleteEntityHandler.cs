

using System.Threading.Tasks;

namespace Service
{
    public class DeleteEntityHandler<T> :
        HandlerBase<T>,
        ICommandHandler<IDeleteCommand<T>> where T : class
    {
        public DeleteEntityHandler(IMongoDbCollection<T> collection) :
            base(collection)
        {
        }

        public async Task<bool> Handle(IDeleteCommand<T> command)
        {
            var filter = command.FilterDefinition();

            var actionResult = await Collection
                .DeleteOneAsync(filter);

            return actionResult.IsSuccess();
        }
    }
}