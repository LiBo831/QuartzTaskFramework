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
using System.Threading.Tasks;
using Topshelf.Models;

namespace Topshelf.Domain.IServices
{
    public interface IConfig_datauploadServices
    {
        Task<List<Config_dataupload>> SelectAllAsync();
        Task BatchUpdateAsync(IList<Config_dataupload> entities);
    }
}
    
    
    
