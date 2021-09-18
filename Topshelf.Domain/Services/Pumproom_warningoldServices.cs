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
using System.Collections.Generic;
using System.Threading.Tasks;
using Topshelf.Domain.IRepository;
using Topshelf.Domain.IServices;
using Topshelf.Models;

namespace Topshelf.Domain.Services
{
    public class Pumproom_warningoldServices : IPumproom_warningoldServices
    {
        public IPumproom_warningoldRepository _pumproom_warningold { get; set; }

        public async Task BatchInsertAsync(IEnumerable<Pumproom_warningold> warningdata) => await _pumproom_warningold.BatchInsertAsync(warningdata);
    }
}
    
    
    
