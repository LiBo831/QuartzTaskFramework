// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_publicdataold.cs
// 创 建 人: Hamberger 
// 创建时间：2021-04-09
// 修 改 人: 
// 修改日期:
// 修改内容:
// 版    本: 1.0.0
// ===================================================================
using System;
using Grd.Code;
using Grd.Model;
using Grd.Utility;
using Grd.IRepository;
using System.Collections.Generic;

namespace Grd.Repository
{
    public class Pumproom_publicdataoldRepository : BaseRepository<Pumproom_publicdataold, long>, IPumproom_publicdataoldRepository
    {
    
        public Pumproom_publicdataoldRepository(IDbContextCore dbContext) 
            : base(dbContext)
        {

        }
    }
}
    
    
    
