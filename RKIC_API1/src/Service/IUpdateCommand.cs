

using MongoDB.Driver;



namespace Service
{
    public interface IUpdateCommand<T> : ICommand where T: class
    {
        FilterDefinition<T> FilterDefinition();

        UpdateDefinition<T> UpdateDefinition();

        bool IsValid();

        bool IsManyUpdate { get; }
    }
}