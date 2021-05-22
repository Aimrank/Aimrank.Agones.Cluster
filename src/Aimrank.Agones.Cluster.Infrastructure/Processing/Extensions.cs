using Aimrank.Agones.Cluster.Core.Entities;
using Aimrank.Agones.Cluster.Infrastructure.DataAccess;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aimrank.Agones.Cluster.Infrastructure.Processing
{
    internal static class Extensions
    {
        public static IServiceCollection AddProcessing(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ClusterContext), typeof(SteamToken));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehavior<,>));

            return services;
        }
    }
}