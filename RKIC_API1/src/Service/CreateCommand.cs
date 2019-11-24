

namespace Service
{
    public class CreateCommand<T> : ICreateCommand<T> where T : class
    {
        private readonly T _entity;

        public static CreateCommand<T> From(T profile)
        {
            return new CreateCommand<T>(profile);
        }

        protected CreateCommand(T entity)
        {
            _entity = entity;
        }

        public T NewEntity()
        {
            return _entity;
        }
    }

    
}