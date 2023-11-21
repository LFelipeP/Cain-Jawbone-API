using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Microsoft.Azure.Cosmos;
using Cain.Jawbone.Infra.Data.Repositories;
using cain_jawbone_domains.Interfaces;

namespace Cain.Jawbone.Infra.IoC
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new CosmosClient(configuration.GetConnectionString("CosmosDb")));

            services.AddTransient<IPageRepository, PageRepository>();

            Assembly myHandlers = AppDomain.CurrentDomain.Load("Cain.Jawbone.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}