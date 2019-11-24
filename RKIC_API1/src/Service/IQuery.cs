

using MongoDB.Driver;


namespace Service
{
    public interface IQuery<T> : IQuery where T : class
    {
        FilterDefinition<T> FilterDefinition();
    }
}