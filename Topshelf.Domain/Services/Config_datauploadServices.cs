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
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Topshelf.Domain.IRepository;
using Topshelf.Domain.IServices;
using Topshelf.Models;

namespace Topshelf.Domain.Services
{
    public class Config_datauploadServices : IConfig_datauploadServices
    {
        public IConfig_datauploadRepository _config_dataupload { get; set; }


        public IList<Config_dataupload> SelectAll() => _config_dataupload.Get();

        public void BatchUpdate(IList<Config_dataupload> entities) => _config_dataupload.BatchUpdate(entities);


    }
}
    
    
    
