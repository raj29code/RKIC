using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using RKICStudent = Web.Model.Student.Student;

namespace Service.Registration
{
    public class StudentKeyGenerator : KeyGenerator<RKICStudent>
    {
        public StudentKeyGenerator(IMongoDbCollection<RKICStudent> collection)
            : base(collection)
        {
        }

        protected override void SetID(RKICStudent maxEntity, RKICStudent newEntity)
        {

        }

        protected override SortDefinition<RKICStudent> Sort()
        {
            return Builders<RKICStudent>.Sort.Descending(o => o.firstName);
        }
    }
}
