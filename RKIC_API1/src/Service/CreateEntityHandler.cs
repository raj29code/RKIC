

#pragma warning disable 1591
using System.Threading.Tasks;

namespace Service
{
    public class CreateEntityHandler<T> :
        HandlerBase<T>,
        ICommandHandler<ICreateCommand<T>> where T : class
    {
        private readonly IKeyGenerator<T> _keyGenerator;

        public CreateEntityHandler(
            IMongoDbCollection<T> userProfiles,
            IKeyGenerator<T> keyGenerator) :
            base(userProfiles)
        {
            _keyGenerator = keyGenerator;
        }

        public async Task<bool> Handle(ICreateCommand<T> command)
        {
            await _keyGenerator.Generate(command.NewEntity());

            await Collection.InsertOneAsync(command.NewEntity());
            return true;
        }
    }
}