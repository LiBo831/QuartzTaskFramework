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

namespace Topshelf.Domain.Services
{
    public class Pumproom_profileServices : IPumproom_profileServices
    {
        private readonly IPumproom_profileRepository _pumproom_profile;   
        public Pumproom_profileServices(IPumproom_profileRepository pumproom_profile)
        {
            _pumproom_profile = pumproom_profile;
        }


        public IList<Pumproom_profile> SelectAll() => _pumproom_profile.Get();

    }
}
    
    
    
