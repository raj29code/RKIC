

using System.Collections.Generic;
using MongoDB.Driver;

namespace Service
{
    public abstract class EntityFilterBase<T>: IQuery<T> where T : class
    {
        protected List<FilterDefinition<T>> Filters;

        protected EntityFilterBase()
        {
            FilterBuilder = new FilterDefinitionBuilder<T>();
            Filters = new List<FilterDefinition<T>>();
        }

        protected FilterDefinition<T> Filter;
        protected FilterDefinitionBuilder<T> FilterBuilder { get; set; }

        public FilterDefinition<T> FilterDefinition()
        {
            return FilterBuilder.And(Filters); 
        }
    }
}