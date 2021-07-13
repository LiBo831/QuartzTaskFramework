using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Topshelf.Core;

namespace Topshelf.Quartz
{
    public class JobExtensions
    {
        public INLogger _logger { get; set; }

        public async Task JobExecute(IJobExecutionContext context, Func<Task> func)
        {
            Stopwatch stopwatch = new Stopwatch();
            var jobName = context.JobDetail.Key.Name;
            string groupName = context.JobDetail.Key.Group;
            double taskSeconds = 0;
            string jobHistory = $"【{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}】【执行开始】【Job：{jobName}，组别：{groupName}】";
            try
            {
                stopwatch.Start();
                await func();//执行任务
                stopwatch.Stop();
                jobHistory += $"，【{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}】【执行成功】";
            }
            catch (Exception ex)
            {
                //JobExecutionException e2 = new JobExecutionException(ex);
                ////true  是立即重新执行任务 
                //e2.RefireImmediately = true;
                jobHistory += $"，【{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}】【执行失败:{ex.Message}】";
                _logger.Warn($"{jobName}:{ex}");
            }
            finally
            {
                taskSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 3);
                jobHistory += $"，【{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}】【执行结束】(耗时:{taskSeconds}秒)";
            }
            _logger.Info(jobHistory);
        }
    }
}
