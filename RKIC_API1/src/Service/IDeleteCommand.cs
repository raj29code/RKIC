
using MongoDB.Driver;

namespace Service
{
    public interface IDeleteCommand<T> : ICommand where T : class
    {
        FilterDefinition<T> FilterDefinition();
    }
}