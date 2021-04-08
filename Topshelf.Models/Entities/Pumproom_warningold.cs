// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_warningold.cs
// 创 建 人: Hamberger 
// 创建日期: 2021-04-14
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
/// 数据库 [WaterProject] 中表 [dbo.PumpRoom_WarningOld] 的实体类.
/// </summary>
namespace Topshelf.Models
{
	/// <summary>
	///PLC报警数据表
	/// </summary>
	[Serializable]
    [DbContext(typeof(SqlServerDBContext))]
	public partial class Pumproom_warningold : BaseModel<long>
	{			
        ///<summary>
		///
		///</summary>
        public override long id { get; set; }

        ///<summary>
		///泵房编号
		///</summary>
		public string pump_id { get; set; }

        ///<summary>
		///泵房名称
		///</summary>
		public string pump_name { get; set; }

		/// <summary>
		/// 部门编号
		/// </summary>
		public string department_ids { get; set; }

		///<summary>
		///记录时间
		///</summary>
		public DateTime? record_time { get; set; }

        ///<summary>
		///
		///</summary>
		public double? dimian { get; set; }

        ///<summary>
		///
		///</summary>
		public double? menjin { get; set; }

        ///<summary>
		///
		///</summary>
		public double? yiqquchaoya { get; set; }

        ///<summary>
		///
		///</summary>
		public double? erquchaoya { get; set; }

        ///<summary>
		///
		///</summary>
		public double? sanquchaoya { get; set; }

        ///<summary>
		///
		///</summary>
		public double? siquchaoya { get; set; }

        ///<summary>
		///
		///</summary>
		public double? jinshuidiya { get; set; }

        ///<summary>
		///
		///</summary>
		public double? yibiangu { get; set; }

        ///<summary>
		///
		///</summary>
		public double? erbiangu { get; set; }

        ///<summary>
		///
		///</summary>
		public double? sanbiangu { get; set; }

        ///<summary>
		///
		///</summary>
		public double? sibiangu { get; set; }

        ///<summary>
		///
		///</summary>
		public double? gaowen { get; set; }

        ///<summary>
		///
		///</summary>
		public double? diwen { get; set; }

        ///<summary>
		///
		///</summary>
		public double? chaoshi { get; set; }

        ///<summary>
		///
		///</summary>
		public double? yanwu { get; set; }

        ///<summary>
		///
		///</summary>
		public double? gaoshuiwei { get; set; }

        ///<summary>
		///
		///</summary>
		public double? dishuiwei { get; set; }

        ///<summary>
		///
		///</summary>
		public double? diandongfa { get; set; }

        ///<summary>
		///
		///</summary>
		public double? paigu { get; set; }

        ///<summary>
		///
		///</summary>
		public double? duandian { get; set; }
	}
}
