// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_warningold.cs
// 创 建 人: Hamberger 
// 创建时间：2021-04-14
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
    public class Pumproom_warningoldRepository : BaseRepository<Pumproom_warningold, long>, IPumproom_warningoldRepository
    {
    
        public Pumproom_warningoldRepository(IDbContextCore dbContext) 
            : base(dbContext)
        {

        }
    }
}
    
    
    
