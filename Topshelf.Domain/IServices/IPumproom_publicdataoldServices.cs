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
using System.Collections.Generic;
using Topshelf.Models;

namespace Topshelf.Domain.IServices
{
    public interface IPumproom_publicdataoldServices
    {
        void BatchInsert(IList<Pumproom_publicdataold> publicdata);
    }
}
    
    
    
