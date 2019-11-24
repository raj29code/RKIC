using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FMP.Model.Settings;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Users;
using Service.Registration;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Core.UseCases;
using Web.Api.Core.Interfaces.Services;
using Web.Api.Infrastructure.Auth;
using Web.Api.Infrastructure.Interfaces;
using Web.Api.Infrastructure.Logging;
using Web.Api.Presenters;

namespace Web.Api.Helpers
{
    public static class DependencyHelper
    {
        public static void RegisterDBConfiguration(IConfiguration config, IServiceCollection services)
        {
            //MongoDB connection string
            services.Configure<Settings>(settings =>
            {
                settings.ConnectionString = config.GetSection("MongoConnection:ConnectionString").Value;
                settings.Database = config.GetSection("MongoConnection:Database").Value;
            });

        }

        public static void RegisterServices(IServiceCollection services)
        {
            //this should be singleton through application
            services.AddSingleton<IMongoDbClient, MongoDbClient>();
            services.AddSingleton<IExchangeRefreshTokenUseCase, ExchangeRefreshTokenUseCase>();
            services.AddSingleton<ExchangeRefreshTokenPresenter, ExchangeRefreshTokenPresenter>();
            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<ITokenFactory, TokenFactory>();
            services.AddSingleton<ILoginUseCase, LoginUseCase>();
            services.AddSingleton<LoginPresenter, LoginPresenter>();
            


            CustomFieldsModule.Register(services);
            RegistrationModule.Register(services);


        }
    }
}
