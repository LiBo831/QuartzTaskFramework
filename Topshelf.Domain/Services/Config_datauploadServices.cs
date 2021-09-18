// =================================================================== 
// 项目说明
//====================================================================
// 文件： Config_dataupload.cs
// 创 建 人: Hamberger 
// 创建时间：2021-04-13
// 修 改 人: 
// 修改日期:
// 修改内容:
// 版    本: 1.0.0
// ===================================================================
using System.Collections.Generic;
using System.Threading.Tasks;
using Topshelf.Domain.IRepository;
using Topshelf.Domain.IServices;
using Topshelf.Models;

namespace Topshelf.Domain.Services
{
    public class Config_datauploadServices : IConfig_datauploadServices
    {
        public IConfig_datauploadRepository _config_dataupload { get; set; }


        public async Task<List<Config_dataupload>> SelectAllAsync() => await _config_dataupload.GetAsync();

        public async Task BatchUpdateAsync(IList<Config_dataupload> entities) => await _config_dataupload.BatchUpdateAsync(entities);


    }
}
    
    
    
