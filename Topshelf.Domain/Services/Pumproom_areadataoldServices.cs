// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_areadataold.cs
// 创 建 人: Hamberger 
// 创建时间：2021-04-09
// 修 改 人: 
// 修改日期:
// 修改内容:
// 版    本: 1.0.0
// ===================================================================
using Topshelf.Domain.IServices;
using Topshelf.Domain.IRepository;
using System.Collections.Generic;
using Topshelf.Models;
using System.Threading.Tasks;

namespace Topshelf.Domain.Services
{
    public class Pumproom_areadataoldServices : IPumproom_areadataoldServices
    {
        public IPumproom_areadataoldRepository _pumproom_areadataold { get; set; }
        public async Task BatchInsertAsync(IEnumerable<Pumproom_areadataold> areadata) =>  await _pumproom_areadataold.BatchInsertAsync(areadata);
    }
}
    
    
    
