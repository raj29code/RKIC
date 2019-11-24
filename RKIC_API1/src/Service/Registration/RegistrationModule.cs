using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Service.Registration.Interface;
using RKICStudent = Web.Model.Student.Student;
using System.Text;

namespace Service.Registration
{
   public class RegistrationModule
    {
        public static void Register(IServiceCollection services)
        {

            services.AddTransient<IStudentRegistration, RegistrationService>();
            services.AddTransient<IMongoDbCollection<RKICStudent>, MongoDbCollection<RKICStudent>>();
            services.AddTransient<IKeyGenerator<RKICStudent>, StudentKeyGenerator>();
            services
              .AddTransient<IQueryHandler<IQuery<RKICStudent>, IReadOnlyList<RKICStudent>>,
                  GetCollectionHandler<RKICStudent>>();
            services.AddTransient<IQueryHandler<IQuery<RKICStudent>, RKICStudent>
         , GetHandler<RKICStudent>>();
            services
                .AddTransient<ICommandHandler<ICreateCommand<RKICStudent>>, CreateEntityHandler<RKICStudent>>();

            services
               .AddTransient<ICommandHandler<IUpdateCommand<RKICStudent>>, UpdateEntityHandler<RKICStudent>>();

            services.AddTransient<IQueryHandler<IQuery<RKICStudent>, bool>
    , EntityExists<RKICStudent>>();


        }
    }
}
