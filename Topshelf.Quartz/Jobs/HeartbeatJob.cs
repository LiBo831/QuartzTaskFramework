using Newtonsoft.Json;
using Quartz;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Topshelf.Core;

namespace Topshelf.Quartz.Jobs
{
    public class HeartbeatJob : IJob
    {
        public INLogger _logger { get; set; }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                #region 接口调用说明
                //发送数据格式：
                //application / json
                //数据为json格式，如下：
                //{
                //"AppId" : "1203",
                //"BeatTime" : "2021-09-08 12:35:36",
                //"HeartState" : "0",
                //"Password" : "grd666"
                //}
                //其中：AppId为徐分配的各系统代码；HeartState = 0为正常；Password为固定值
                #endregion
                var result = HttpHelper.PostResponseAsync(Settings.Instance.HeartbeatAddress,
                    JsonConvert.SerializeObject(new
                    {
                        AppId = Settings.Instance.HeartbeatAppId,
                        BeatTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo),
                        HeartState = "0",
                        PassWord = "grd666"
                    }));
            }
            catch (Exception ex)
            {
                _logger.Fatal($" {context.JobDetail.Key.Name} : {ex} ");
            }
            await Task.CompletedTask;
        }
    }
}
