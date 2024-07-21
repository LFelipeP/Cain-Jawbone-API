using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Microsoft.Azure.Cosmos;
using Cain.Jawbone.Infra.Data.Repositories;
using Cain.Jawbone.Domain.Interfaces;
using Cain.Jawbone.Infra.Data.Contexts.Interfaces;
using Cain.Jawbone.Infra.Data.Contexts;

namespace Cain.Jawbone.Infra.IoC
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton(new CosmosClient(configuration.GetConnectionString("CosmosDb")));
            services.AddTransient<IPageContext, PageContext>();
            services.AddSingleton<IPageRepository, PageRepository>();


            Assembly myHandlers = AppDomain.CurrentDomain.Load("Cain.Jawbone.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

            return services;
        }
    }
}