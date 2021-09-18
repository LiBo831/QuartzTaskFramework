using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Topshelf.Core;
using Topshelf.Domain.IServices;
using Topshelf.Models;
using static Topshelf.Core.VisitPLC;

namespace Topshelf.Quartz.Jobs
{
    public class DataStorageJob : JobExtensions, IJob
    {
        public IPumproom_profileServices _pumproom_profile { get; set; }
        public IConfig_datauploadServices _config_dataupload { get; set; }
        public IPumproom_warningoldServices _pumproom_warningold { get; set; }
        public IPumproom_areadataoldServices _pumproom_areadataold { get; set; }
        public IPumproom_publicdataoldServices _pumproom_publicdataold { get; set; }

        public async Task Execute(IJobExecutionContext context) =>
            await JobExecute(context, async () =>
        {
            var profiles = await _pumproom_profile.SelectAllAsync();
            var configs = await _config_dataupload.SelectAllAsync();
            List<Config_dataupload> _configs = new();
            foreach (var pro in profiles)
            {
                var config = configs.Find(x => x.pump_id == pro.id);
                if (config == null) { continue; }
                #region 判斷網絡
                if (!Ping(pro.network_ip)) { continue; }
                #endregion
                #region 下載文件
                string src = $"{Settings.Instance.CsvPath}{config.pump_name.Trim()}";
                bool aDnRst = DownloadFile(savepath: src,
                                           downpath: $"{config.visit_url.Trim()}{config.file_name_quyu.Trim()}",
                                           ip: pro.network_ip.Trim(), $"{config.file_name_quyu.Trim()}");

                bool pDnRst = DownloadFile(savepath: src,
                                           downpath: $"{config.visit_url.Trim()}{config.file_name_gonggong.Trim()}",
                                           ip: pro.network_ip.Trim(), $"{config.file_name_gonggong.Trim()}");

                bool wDnRst = DownloadFile(savepath: src,
                                           downpath: $"{config.visit_url.Trim()}{config.file_name_warning.Trim()}",
                                           ip: pro.network_ip.Trim(), $"{config.file_name_warning.Trim()}");
                #endregion
                #region 裝載數據
                mapper_head.id = pro.id;
                mapper_head.name = pro.pumproomname;
                mapper_head.deptId = pro.departmentids;
                #region 區域數據
                if (aDnRst)
                {
                    var operData = File.ReadAllLines($"{src}\\{config.file_name_quyu.Trim()}")
                                       .Skip(1).Select(v => csv_quyu_mapper.FromCsv(v, GaiZhou_Lie.dianliu))
                                       .Where(x => x.record_time?.Ticks > Convert.ToDateTime(config.last_time_quyu).Ticks);
                    if (operData.Any())
                    {
                        await _pumproom_areadataold.BatchInsertAsync(operData);
                        config.last_time_quyu = ((DateTime)operData.OrderByDescending(t => t.record_time).FirstOrDefault().record_time).ToString();
                    }
                }
                #endregion
                #region 公共數據
                if (pDnRst)
                {
                    var operData = File.ReadAllLines($"{src}\\{config.file_name_gonggong.Trim()}")
                                       .Skip(1).Select(v => csv_gonggong_mapper.FromCsv(v, GaiZhou_Lie.dianliu))
                                       .Where(x => x.record_time?.Ticks > Convert.ToDateTime(config.last_time_gonggong).Ticks);
                    if (operData.Any())
                    {
                        await _pumproom_publicdataold.BatchInsertAsync(operData);
                        config.last_time_gonggong = ((DateTime)operData.OrderByDescending(t => t.record_time).FirstOrDefault().record_time).ToString();
                    }
                }
                #endregion
                #region 報警數據
                if (wDnRst)
                {
                    var operData = File.ReadAllLines($"{src}\\{config.file_name_warning.Trim()}")
                                       .Skip(1).Select(v => csv_warning_mapper.FromCsv(v, ScientificNotationChange))
                                       .Where(x => x.record_time?.Ticks > Convert.ToDateTime(config.last_time_warning).Ticks);
                    if (operData.Any())
                    {
                        await _pumproom_warningold.BatchInsertAsync(operData);
                        config.last_time_warning = ((DateTime)operData.OrderByDescending(t => t.record_time).FirstOrDefault().record_time).ToString();
                    }
                }
                #endregion
                #endregion
                _configs.Add(config);
            }
            // 更新配置
            await _config_dataupload.BatchUpdateAsync(_configs);
            #region 釋放
            ResourcesRelease.ReleaseList(profiles.ToList());
            ResourcesRelease.ReleaseList(configs);
            ResourcesRelease.ReleaseList(_configs);
            #endregion
            await Task.CompletedTask;
        }, "历史数据");
    }
}
