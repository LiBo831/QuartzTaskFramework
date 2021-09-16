using Autofac;
using Autofac.Extras.Quartz;
using System.Collections.Specialized;

namespace Topshelf.Quartz
{
    public static class QuartzExtensions
    {
        internal static ContainerBuilder ConfigureQuartz(this ContainerBuilder builder)
        {
            var schedulerConfig = new NameValueCollection
            {
                { "quartz.scheduler.instanceName", "Scheduler" },
                { "quartz.threadPool.maxConcurrency", "10" },
                { "quartz.jobStore.type", "Quartz.Simpl.RAMJobStore, Quartz" }
            };
            builder.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = _ => schedulerConfig,
                JobScopeConfigurator = (builder, tag) =>
                {
                    builder.Register(_ => new Core.NLogger())
                           .AsImplementedInterfaces()
                           .InstancePerMatchingLifetimeScope(tag);
                }
            });
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(JobService).Assembly) { AutoWireProperties = true });
            return builder;
        }
    }
}
