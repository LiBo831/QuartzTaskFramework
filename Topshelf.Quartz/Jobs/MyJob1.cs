using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topshelf.Quartz.Jobs
{
    public class MyJob1 : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"{DateTime.Now} - 2 - {context.CancellationToken}");
            await Task.CompletedTask;
        }
    }
}
