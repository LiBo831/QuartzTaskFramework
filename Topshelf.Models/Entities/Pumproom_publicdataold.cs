// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_publicdataold.cs
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
/// 数据库 [WaterProject] 中表 [dbo.PumpRoom_PublicDataOld] 的实体类.
/// </summary>
namespace Topshelf.Models
{
	/// <summary>
	///PLC公共数据表
	/// </summary>
	[Serializable]
    [DbContext(typeof(SqlServerDBContext))]
	public partial class Pumproom_publicdataold : BaseModel<long>
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

        ///<summary>
		///
		///</summary>
		public string department_ids { get; set; }

        ///<summary>
		///日期
		///</summary>
		public DateTime? record_time { get; set; }

        ///<summary>
		///小时总流量
		///</summary>
		public double? hour_total_flow { get; set; }

        ///<summary>
		///日总流量
		///</summary>
		public double? day_total_flow { get; set; }

        ///<summary>
		///月总流量
		///</summary>
		public double? month_total_flow { get; set; }

        ///<summary>
		///总流量
		///</summary>
		public double? total_flow { get; set; }

        ///<summary>
		///小时电量
		///</summary>
		public double? hour_electricity { get; set; }

        ///<summary>
		///日电量
		///</summary>
		public double? day_electricity { get; set; }

        ///<summary>
		///月电量
		///</summary>
		public double? month_electricity { get; set; }

        ///<summary>
		///总电量
		///</summary>
		public double? total_electricity { get; set; }

        ///<summary>
		///小时单耗
		///</summary>
		public double? hour_unit_consumption { get; set; }

        ///<summary>
		///日单耗
		///</summary>
		public double? day_unit_consumption { get; set; }

        ///<summary>
		///月单耗
		///</summary>
		public double? month_unit_consumption { get; set; }

        ///<summary>
		///液位
		///</summary>
		public double? liquid_level { get; set; }

        ///<summary>
		///余氯
		///</summary>
		public double? chlorine { get; set; }

        ///<summary>
		///
		///</summary>
		public double? ph { get; set; }

        ///<summary>
		///浊度
		///</summary>
		public double? turbidity { get; set; }

        ///<summary>
		///温度
		///</summary>
		public double? temperature { get; set; }

        ///<summary>
		///湿度
		///</summary>
		public double? humidity { get; set; }

        ///<summary>
		///进水压力
		///</summary>
		public double? inlet_pressure { get; set; }
	}
}
