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
using System;
using System.Linq.Expressions;

namespace Topshelf.Domain.Services
{
    public class Pumproom_areadataoldServices : IPumproom_areadataoldServices
    {
        private readonly IPumproom_areadataoldRepository _pumproom_areadataold;
        public Pumproom_areadataoldServices(IPumproom_areadataoldRepository pumproom_areadataold)
        {
            _pumproom_areadataold = pumproom_areadataold;
        }

        public void BatchInsert(IList<Pumproom_areadataold> areadata) => _pumproom_areadataold.BatchInsert(areadata);

        //public int BatchDelete(Expression<Func<Pumproom_areadataold, bool>> @where) => _pumproom_areadataold.Delete(@where);
    }
}
    
    
    
