
using System;
using System.Collections.Generic;
using System.Text;
using Service.Users.Interface;
using Microsoft.Extensions.DependencyInjection;
using RKICUser = Service.Model.User;




namespace Service.Users
{
   public class CustomFieldsModule
    {
        public static void Register(IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMongoDbCollection<RKICUser>, MongoDbCollection<RKICUser>>();
            services.AddTransient<IKeyGenerator<RKICUser>, CustomFieldsKeyGenerator>();
            services
              .AddTransient<IQueryHandler<IQuery<RKICUser>, IReadOnlyList<RKICUser>>,
                  GetCollectionHandler<RKICUser>>();
            services
                .AddTransient<ICommandHandler<ICreateCommand<RKICUser>>, CreateEntityHandler<RKICUser>>();

            services
               .AddTransient<ICommandHandler<IUpdateCommand<RKICUser>>, UpdateEntityHandler<RKICUser>>();

            services.AddTransient<IQueryHandler<IQuery<RKICUser>, bool>
    , EntityExists<RKICUser>>();


        }
    }
}
