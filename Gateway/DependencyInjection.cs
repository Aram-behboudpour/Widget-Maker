using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using oc.TSB.Infrastructure;
using System.Reflection;

namespace oc.TSB.Gateway
{
    public static class DependencyInjection : object
    {
        static DependencyInjection()
        {
        }

        public static void ConfigureServices
          (Microsoft.Extensions.Configuration.IConfiguration configuration,
          Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            //**************************************************
            services.AddTransient
                 <Microsoft.AspNetCore.Http.IHttpContextAccessor,
                 Microsoft.AspNetCore.Http.HttpContextAccessor>();

            //services.AddTransient
            //    (serviceType: typeof(Logging.ILogger<>),
            //    implementationType: typeof(Logging.NLogAdapter<>));
            // **************************************************

            // **************************************************
            // AddMediatR -> Extension Method -> using MediatR;
            // GetTypeInfo -> Extension Method -> using System.Reflection;
            services.AddMediatR
                (typeof(oc.TSB.Application.Features.Processes.MappingProfile).GetTypeInfo().Assembly);

            // AddValidatorsFromAssembly -> Extension Method -> using FluentValidation;
            //services.AddValidatorsFromAssembly
            //    (assembly: typeof(Application.Features.Admins.Commands.CreateLoginCommandValidator).Assembly);

            services.AddTransient
                (typeof(MediatR.IPipelineBehavior<,>), typeof(Faraz.Mediator.ValidationBehavior<,>));
            // **************************************************

            // **************************************************
            // using Microsoft.Extensions.DependencyInjection;
            services.AddAutoMapper
                (profileAssemblyMarkerTypes: typeof(oc.TSB.Application.Features.Processes.MappingProfile));
            // **************************************************

            // **************************************************
            services.AddTransient<oc.TSB.Infrastructure.IUnitOfWork,
                oc.TSB.Infrastructure.UnitOfWork>(current =>
            {
                string databaseConnectionString =
                   configuration
                   .GetSection(key: "ApplicationSettings")
                   .GetSection(key: "ConnectionStrings")
                   .GetSection(key: "CommandsConnectionString")
                   .Value;

                string databaseProviderString =
                   configuration
                   .GetSection(key: "ApplicationSettings")
                   .GetSection(key: "CommandsDatabaseProvider")
                   .Value;

                Faraz.Persistance.Enums.Provider databaseProvider =
                (Faraz.Persistance.Enums.Provider)
                System.Convert.ToInt32(databaseProviderString);

                Faraz.Persistance.Options options =
                new Faraz.Persistance.Options
                {
                    Provider = databaseProvider,
                    ConnectionString = databaseConnectionString,
                };

                return new oc.TSB.Infrastructure.UnitOfWork(options: options);
            });
            //**************************************************
            services.AddTransient<oc.TSB.Infrastructure.IQueryUnitOfWork,
                oc.TSB.Infrastructure.QueryUnitOfWork>(current =>
            {
                string databaseConnectionString =
                   configuration
                   .GetSection(key: "ApplicationSettings")
                   .GetSection(key: "ConnectionStrings")
                   .GetSection(key: "QueriesConnectionString")
                   .Value;

                string databaseProviderString =
                   configuration
                   .GetSection(key: "ApplicationSettings")
                   .GetSection(key: "QueriesDatabaseProvider")
                   .Value;

                Faraz.Persistance.Enums.Provider databaseProvider =
                (Faraz.Persistance.Enums.Provider)
                System.Convert.ToInt32(databaseProviderString);

                Faraz.Persistance.Options options =
                new Faraz.Persistance.Options
                {
                    Provider = databaseProvider,
                    ConnectionString = databaseConnectionString,
                };

                return new oc.TSB.Infrastructure.QueryUnitOfWork(options: options);
            });
            //**************************************************
            //**************************************************
        }

    }
}
