using Autofac;
using Quartz;
using System;
using System.Threading;
using System.Threading.Tasks;
using Topshelf.Core;

namespace Topshelf.Quartz
{
    public class JobService
    {
        IScheduler sched;
        CancellationTokenSource cts;
        readonly IContainer container;

        public JobService(IContainer _c) => container = _c;

        public async Task InitSchedule()
        {
            cts = new();
            sched = container.Resolve<IScheduler>();
            Settings.Instance.JobList.ForEach(async ijob => {
                var job = JobBuilder.Create(Type.GetType($"{Settings.Instance.JobNamespceFormat}.{ijob.JobName}"))
                    .WithIdentity(ijob.JobName, Settings.Instance.ServiceName).Build();
                var trigger = TriggerBuilder.Create()
                    .WithCronSchedule(ijob.Cron).Build();
                await sched.ScheduleJob(job, trigger, cts.Token);
            });
            await sched.Start();
        }

        public async void Start() => await InitSchedule();

        public async void Stop()
        {
            cts.Cancel();
            await sched.Shutdown();
        }
    }
}
