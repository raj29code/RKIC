

using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;



namespace Service
{
    public abstract class UpdateBase<T> : IUpdateCommand<T> where T : class
      
    {
        protected UpdateBase()
        {
            Updates = new List<UpdateDefinition<T>>();
            UpdateBuilder = Builders<T>.Update;
        }

        protected List<UpdateDefinition<T>> Updates;

        protected UpdateDefinitionBuilder<T> UpdateBuilder ;

        protected IQuery<T> FilterInt;

        public FilterDefinition<T> FilterDefinition()
        {
            return FilterInt.FilterDefinition();
        }

        public UpdateDefinition<T> UpdateDefinition()
        {
            return UpdateBuilder.Combine(Updates); 
        }

        public bool IsValid()
        {
            return Updates.Any();
        }

        public bool IsManyUpdate { get; protected set; }
    }

    
}