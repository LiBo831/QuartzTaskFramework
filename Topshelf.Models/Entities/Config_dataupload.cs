// =================================================================== 
// 项目说明
//====================================================================
// 文件： Config_dataupload.cs
// 创 建 人: Hamberger 
// 创建日期: 2021-04-13
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
namespace Topshelf.Models
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
    [DbContext(typeof(SqlServerDBContext))]
	public partial class Config_dataupload : BaseModel<int>
	{			
        ///<summary>
		///标识
		///</summary>
        public override int id { get; set; }

        ///<summary>
		///泵房编号
		///</summary>
		public string pump_id { get; set; }

        ///<summary>
		///泵房名称
		///</summary>
		public string pump_name { get; set; }

        ///<summary>
		///访问地址
		///</summary>
		public string visit_url { get; set; }

        ///<summary>
		///区域文件名称
		///</summary>
		public string file_name_quyu { get; set; }

		///<summary>
		///上次区域数据上传最新时间节点
		///</summary>
		public string last_time_quyu { get; set; }

		///<summary>
		///公共文件名称
		///</summary>
		public string file_name_gonggong { get; set; }

        ///<summary>
		///上次公共数据上传最新时间节点
		///</summary>
		public string last_time_gonggong { get; set; }

		///<summary>
		///报警文件名称
		///</summary>
		public string file_name_warning { get; set; }

		///<summary>
		///上次报警数据上传最新时间节点
		///</summary>
		public string last_time_warning { get; set; }
	}
}
