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
using Topshelf.Domain.IRepository;
using Topshelf.EFCore;
using Topshelf.Infrastructure;
using Topshelf.Models;

namespace Topshelf.Domain.Repository
{
    public class Config_datauploadRepository : BaseRepository<Config_dataupload, int>, IConfig_datauploadRepository
    {
    
        public Config_datauploadRepository(IDbContextCore dbContext) 
            : base(dbContext)
        {

        }
    }
}
    
    
    
