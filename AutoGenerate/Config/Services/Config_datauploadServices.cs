// =================================================================== 
// 项目说明
//====================================================================
// 文件： Config_dataupload.cs
// 创 建 人: Hamberger 
// 创建时间：2021-04-12
// 修 改 人: 
// 修改日期:
// 修改内容:
// 版    本: 1.0.0
// ===================================================================
using System.Collections.Generic;
using Topshelf.Domain.IRepository;
using Topshelf.Domain.IServices;
using Topshelf.Models;

namespace Topshelf.Domain.Services
{
    public class Config_datauploadServices : IConfig_datauploadServices
    {
        private readonly IConfig_datauploadRepository _config_dataupload;   
		
		public Config_datauploadServices(IConfig_datauploadRepository config_dataupload)
		{
			_config_dataupload; = config_dataupload;
		}
        
    }
}
    
    
    
