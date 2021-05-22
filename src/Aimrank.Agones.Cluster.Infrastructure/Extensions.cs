using Aimrank.Agones.Cluster.Infrastructure.DataAccess;
using Aimrank.Agones.Cluster.Infrastructure.Kubernetes;
using Aimrank.Agones.Cluster.Infrastructure.Processing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Aimrank.Agones.Cluster.Migrator")]

namespace Aimrank.Agones.Cluster.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccess(configuration);
            services.AddProcessing();
            services.AddKubernetes(configuration);
            
            return services;
        }
    }
}