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
    public class DataStorageJob : IJob
    {
        private readonly INLogger _logger;
        private readonly IPumproom_profileServices _pumproom_profile;
        private readonly IConfig_datauploadServices _config_dataupload;
        private readonly IPumproom_warningoldServices _pumproom_warningold;
        private readonly IPumproom_areadataoldServices _pumproom_areadataold;
        private readonly IPumproom_publicdataoldServices _pumproom_publicdataold;
        

        public DataStorageJob(INLogger logger, 
                              IPumproom_profileServices pumproom_profile, 
                              IConfig_datauploadServices config_dataupload,
                              IPumproom_warningoldServices pumproom_warningold,
                              IPumproom_areadataoldServices pumproom_areadataold,
                              IPumproom_publicdataoldServices pumproom_publicdataold)
        {
            _logger = logger;
            _pumproom_profile = pumproom_profile;
            _config_dataupload = config_dataupload;
            _pumproom_warningold = pumproom_warningold;
            _pumproom_areadataold = pumproom_areadataold;
            _pumproom_publicdataold = pumproom_publicdataold;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var profiles = _pumproom_profile.SelectAll();
                var configs = _config_dataupload.SelectAll().ToList();
                List<Config_dataupload> _configs = new List<Config_dataupload>();
                foreach (var pro in profiles)
                {    
                    // 網絡不通忽略
                    if (!Ping(pro.network_ip)) { continue; }
                    var config = configs.Find(x => x.pump_id == pro.id);
                    #region 先下載數據
                    bool aDnRst = DownloadFile(savepath: $"{Settings.Instance.CsvPath}{config.pump_name.Trim()}\\{config.file_name_quyu.Trim()}",
                           downpath: $"{config.visit_url.Trim()}{config.file_name_quyu.Trim()}",
                           ip: pro.network_ip.Trim());
                    bool pDnRst = DownloadFile(savepath: $"{Settings.Instance.CsvPath}{config.pump_name.Trim()}\\{config.file_name_gonggong.Trim()}",
                                               downpath: $"{config.visit_url.Trim()}{config.file_name_gonggong.Trim()}",
                                               ip: pro.network_ip.Trim());
                    bool wDnRst = DownloadFile(savepath: $"{Settings.Instance.CsvPath}{config.pump_name.Trim()}\\{config.file_name_warning.Trim()}",
                                               downpath: $"{config.visit_url.Trim()}{config.file_name_warning.Trim()}",
                                               ip: pro.network_ip.Trim());
                    #endregion
                    #region 區域數據
                    if (aDnRst)
                    {
                        csv_quyu_mapper.id = pro.id;
                        csv_quyu_mapper.name = pro.pumproomname;
                        csv_quyu_mapper.deptId = pro.departmentids;
                        string savepath = $"{Settings.Instance.CsvPath}{config.pump_name.Trim()}\\{config.file_name_quyu.Trim()}";
                        var datas = File.ReadAllLines(savepath).Skip(1).Select(v => csv_quyu_mapper.FromCsv(v)).ToList();
                        var operData = datas.Where(x => x.record_time?.Ticks > Convert.ToDateTime(config.last_time_quyu).Ticks).ToList();
                        if (operData.Count > 0)
                        {
                            _pumproom_areadataold.BatchInsert(operData);
                            config.last_time_quyu = operData.OrderByDescending(t => t.record_time).FirstOrDefault().record_time.ToString();
                        }
                    }
                    #endregion
                    #region 公共數據
                    if (pDnRst)
                    {
                        csv_gonggong_mapper.id = pro.id;
                        csv_gonggong_mapper.name = pro.pumproomname;
                        csv_gonggong_mapper.deptId = pro.departmentids;
                        string savepath = $"{Settings.Instance.CsvPath}{config.pump_name.Trim()}\\{config.file_name_gonggong.Trim()}";
                        var datas = File.ReadAllLines(savepath).Skip(1).Select(v => csv_gonggong_mapper.FromCsv(v)).ToList();
                        var operData = datas.Where(x => x.record_time?.Ticks > Convert.ToDateTime(config.last_time_gonggong).Ticks).ToList();
                        if (operData.Count > 0)
                        {
                            _pumproom_publicdataold.BatchInsert(datas);
                            config.last_time_gonggong = operData.OrderByDescending(t => t.record_time).FirstOrDefault().record_time.ToString();
                        }
                    }
                    #endregion
                    #region 報警數據
                    if (wDnRst)
                    {
                        csv_warning_mapper.id = pro.id;
                        csv_warning_mapper.name = pro.pumproomname;
                        csv_warning_mapper.deptId = pro.departmentids;
                        string savepath = $"{Settings.Instance.CsvPath}{config.pump_name.Trim()}\\{config.file_name_warning.Trim()}";
                        var datas = File.ReadAllLines(savepath).Skip(1).Select(v => csv_warning_mapper.FromCsv(v)).ToList();
                        var operData = datas.Where(x => x.record_time?.Ticks > Convert.ToDateTime(config.last_time_warning).Ticks).ToList();
                        if (operData.Count > 0)
                        {
                            _pumproom_warningold.BatchInsert(datas);
                            config.last_time_warning = operData.OrderByDescending(t => t.record_time).FirstOrDefault().record_time.ToString();
                        }
                    }
                    #endregion
                    _configs.Add(config);
                }
                // 更新配置
                _config_dataupload.BatchUpdateSaveChange(_configs);
                _logger.Info("PLC数据已存入数据库");
            }
            catch(Exception ex)
            {
                _logger.Warn(ex.ToString());
            }
            await Task.CompletedTask;
        }
    }
}
