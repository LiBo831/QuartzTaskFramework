// =================================================================== 
// 项目说明
//====================================================================
// 文件： Config_dataupload.cs
// 创 建 人: Hamberger 
// 创建日期: 2021-04-12
// 修 改 人: 
// 修改日期:
// 修改内容:
// 版    本: 1.0.0
// ===================================================================
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using Topshelf.Core;
using Topshelf.EFCore;

/// <summary>
/// 数据库 [WaterProject] 中表 [dbo.Config_DataUpload] 的实体类.
/// </summary>
namespace Grd.Models
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
    [DbContext(typeof(SqlServerDBContext))]
	public partial class Config_dataupload : BaseModel<int?>
	{			
        ///<summary>
		///
		///</summary>
        public override int? id { get; set; }

        
        ///<summary>
		///泵房编号
		///</summary>
		public string pump_id { get; set; }

        
        ///<summary>
		///泵房名称
		///</summary>
		public string pump_name { get; set; }

        
        ///<summary>
		///文件名
		///</summary>
		public string file_name { get; set; }

        
        ///<summary>
		///区域访问地址
		///</summary>
		public string visit_url_quyu { get; set; }

        
        ///<summary>
		///区域文件路径
		///</summary>
		public string file_path_quyu { get; set; }

        
        ///<summary>
		///公共访问地址
		///</summary>
		public string visit_url_gonggong { get; set; }

        
        ///<summary>
		///公共文件路径
		///</summary>
		public string file_path_gonggong { get; set; }
        
	}
}
