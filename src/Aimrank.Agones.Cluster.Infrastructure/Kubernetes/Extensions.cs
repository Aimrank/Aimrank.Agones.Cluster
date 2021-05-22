using Aimrank.Agones.Cluster.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aimrank.Agones.Cluster.Infrastructure.Kubernetes
{
    internal static class Extensions
    {
        public static IServiceCollection AddKubernetes(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FleetSettings>(configuration.GetSection(nameof(FleetSettings)));
            services.AddScoped<IFleetService, FleetService>();
            return services;
        }
    }
}