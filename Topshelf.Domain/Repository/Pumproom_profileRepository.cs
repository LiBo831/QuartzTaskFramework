// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_profile.cs
// 创 建 人: Hamberger 
// 创建时间：2021-04-09
// 修 改 人: 
// 修改日期:
// 修改内容:
// 版    本: 1.0.0
// ===================================================================
using Topshelf.EFCore;
using Topshelf.Models;
using Topshelf.Domain.IRepository;
using Topshelf.Infrastructure;

namespace Topshelf.Domain.Repository
{
    public class Pumproom_profileRepository : BaseRepository<Pumproom_profile, string>, IPumproom_profileRepository
    {
    
        public Pumproom_profileRepository(IDbContextCore dbContext) 
            : base(dbContext)
        {

        }
    }
}
    
    
    
