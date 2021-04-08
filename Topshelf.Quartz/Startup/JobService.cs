﻿using Autofac;
using Quartz;
using System;
using System.Threading;
using System.Threading.Tasks;
using Topshelf.Core;

namespace Topshelf.Quartz
{
    class JobService
    {
        private IScheduler sched;
        private CancellationTokenSource cts;
        private IContainer container;

        public JobService(IContainer Container)
        {
            container = Container;
        }

        public async Task InitSchedule()
        {
            cts = new CancellationTokenSource();
            sched = container.Resolve<IScheduler>();
            foreach (var ijob in Settings.Instance.JobList)
            {
                var job = JobBuilder.Create(Type.GetType($"{Settings.Instance.JobNamespceFormat}.{ijob.JobName}"))
                    .WithIdentity(ijob.JobName, Settings.Instance.ServiceName).Build();
                var trigger = TriggerBuilder.Create()
                    .WithCronSchedule(ijob.Cron).Build();
                await sched.ScheduleJob(job, trigger, cts.Token).ConfigureAwait(true);
            }
            await sched.Start().ConfigureAwait(true);
        }

        public async Task Start()
        {
            await InitSchedule();
        }

        public void Stop()
        {
            cts.Cancel();
            sched.Shutdown(true);
            container?.Dispose();
        }
    }
}