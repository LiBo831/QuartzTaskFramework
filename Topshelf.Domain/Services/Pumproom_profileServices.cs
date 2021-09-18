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
using Topshelf.Domain.IServices;
using Topshelf.Domain.IRepository;
using Topshelf.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Topshelf.Domain.Services
{
    public class Pumproom_profileServices : IPumproom_profileServices
    {
        public IPumproom_profileRepository _pumproom_profile { get; set; }
        public async Task<IList<Pumproom_profile>> SelectAllAsync() => await _pumproom_profile.GetAsync();

    }
}
    
    
    
