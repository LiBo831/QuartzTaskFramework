﻿using Autofac;
using Topshelf.Core;

namespace Topshelf.Quartz
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ContainerBuilder().ConfigureQuartz().ConfigureSelf().Build();
            HostFactory.Run(x =>
            {
                x.UseNLog();
                x.Service<JobService>(s =>
                {
                    s.ConstructUsing(name => new JobService(container));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.StartAutomaticallyDelayed();

                x.SetDisplayName(Settings.Instance.ServiceDisplayName);
                x.SetServiceName(Settings.Instance.ServiceName);
                x.SetDescription(Settings.Instance.ServiceDescription);
            });
        }
    }
}
