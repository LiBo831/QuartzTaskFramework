﻿// =================================================================== 
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
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Topshelf.Models;

namespace Topshelf.Domain.IServices
{
    public interface IPumproom_areadataoldServices
    {
        void BatchInsert(IList<Pumproom_areadataold> areadata);
        //int BatchDelete(Expression<Func<Pumproom_areadataold, bool>> @where);
    }
}
    
    
    
