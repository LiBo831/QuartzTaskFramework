using Autofac;
using Autofac.Extras.Quartz;
using System.Collections.Specialized;

namespace Topshelf.Quartz
{
    public static class QuartzExtensions
    {
        internal static ContainerBuilder ConfigureQuartz(this ContainerBuilder builder)
        {
            var schedulerConfig = new NameValueCollection {
                {"quartz.threadPool.threadCount", "4"},
                {"quartz.scheduler.threadName", "Scheduler"}
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
