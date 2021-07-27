using Quartz;
using System.Threading.Tasks;

namespace Topshelf.Quartz.Jobs
{
    public class OpcCollectionJob : JobExtensions, IJob
    {
        public async Task Execute(IJobExecutionContext context) => 
            await JobExecute(context, async () =>
        {
            await Task.CompletedTask;
        });

    }
}
