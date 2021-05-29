using Aimrank.Agones.Cluster.Infrastructure.DataAccess;
using Aimrank.Agones.Cluster.Infrastructure.Kubernetes;
using Aimrank.Agones.Cluster.Infrastructure.Processing;
using Aimrank.Agones.Cluster.Infrastructure.Quartz;
using Microsoft.AspNetCore.Builder;
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
            services.AddQuartz();
            
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder)
        {
            builder.UseQuartz();
            
            return builder;
        }
    }
}