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
using Topshelf.Domain.IRepository;
using Topshelf.Domain.IServices;
using Topshelf.Models;

namespace Topshelf.Domain.Services
{
    public class Pumproom_warningoldServices : IPumproom_warningoldServices
    {
        private readonly IPumproom_warningoldRepository _pumproom_warningold;   
		
		public Pumproom_warningoldServices(IPumproom_warningoldRepository pumproom_warningold)
		{
			_pumproom_warningold = pumproom_warningold;
		}

        public void BatchInsert(IList<Pumproom_warningold> warningdata) => _pumproom_warningold.BatchInsert(warningdata);
    }
}
    
    
    
