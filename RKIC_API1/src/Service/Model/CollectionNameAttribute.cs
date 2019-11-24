using System;
using System.Collections.Generic;
using System.Text;

namespace FMP.Service.Model
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionNameAttribute : Attribute
    {
        public string Name { get; }

        public CollectionNameAttribute(string collectionName)
        {
            Name = collectionName;
        }
    }
}
