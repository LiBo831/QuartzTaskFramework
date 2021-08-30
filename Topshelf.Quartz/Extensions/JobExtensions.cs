using Newtonsoft.Json;
using Quartz;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Topshelf.Core;

namespace Topshelf.Quartz
{
    public class JobExtensions
    {
        public INLogger _logger { get; set; }

        public async Task JobExecute(IJobExecutionContext context, Func<Task> func, string outline = "")
        {
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();
                await func();
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                _logger.Warn($" {context.JobDetail.Key.Name} : {ex} ");
                HttpHelper.PostResponseAsync(Settings.Instance.HeartbeatAddress,
                    JsonConvert.SerializeObject(new
                    {
                        AppId = Settings.Instance.HeartbeatAppId,
                        BeatTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo),
                        HeartState = "1",
                        PassWord = "grd666"
                    }));
            }
            finally
            {
                var taskSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 3);
                if (!string.IsNullOrEmpty(outline))
                    _logger.Info($"{outline}操作完成!___任务耗时 : {taskSeconds} 秒");
            }
        }
    }
}
