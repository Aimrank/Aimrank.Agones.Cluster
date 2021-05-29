using Aimrank.Agones.Cluster.Infrastructure.DataAccess;
using Aimrank.Agones.Cluster.Infrastructure.Quartz.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using Quartz;
using System.Collections.Specialized;

namespace Aimrank.Agones.Cluster.Infrastructure.Quartz
{
    internal static class Extensions
    {
        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<ClusterContext>()
                .AddClasses(classes => classes.AssignableTo<IJob>())
                .AsSelf()
                .WithTransientLifetime());

            return services;
        }

        public static IApplicationBuilder UseQuartz(this IApplicationBuilder builder)
        {
            var schedulerConfiguration = new NameValueCollection
            {
                {"quartz.scheduler.instanceName", "Aimrank.Agones.Cluster"}
            };
            
            var schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            scheduler.JobFactory = new JobFactory(builder.ApplicationServices);
            scheduler.Start().GetAwaiter().GetResult();
            
            scheduler.ScheduleCronJob<RemoveExpiredReservationsJob>("0 0 0/2 ? * *");
            
            return builder;
        }
        
        private static void ScheduleCronJob<T>(this IScheduler scheduler, string cron) where T : class, IJob
        {
            var job = JobBuilder.Create<T>().Build();
            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithCronSchedule(cron)
                .Build();
            
            scheduler.ScheduleJob(job, trigger);
        }
    }
}