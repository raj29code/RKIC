
using MongoDB.Driver;

namespace Service
{
    public class DeleteCommand<T> : IDeleteCommand<T> where T : class
    {
        protected DeleteCommand()
        {

        }
        public static DeleteCommand<T> WithFilter(IQuery<T> filter)
        {
            var obj = new DeleteCommand<T>();
            obj.FilterInt = filter;
            return obj;
        }

        protected IQuery<T> FilterInt;

        public FilterDefinition<T> FilterDefinition()
        {
            return FilterInt.FilterDefinition();
        }
    }
}