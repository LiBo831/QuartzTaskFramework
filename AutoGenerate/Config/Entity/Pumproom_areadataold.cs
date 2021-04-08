// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_areadataold.cs
// 创 建 人: Hamberger 
// 创建日期: 2021-04-09
// 修 改 人: 
// 修改日期:
// 修改内容:
// 版    本: 1.0.0
// ===================================================================
using Grd.Core;
using Grd.EFCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

/// <summary>
/// 数据库 [WaterProject] 中表 [dbo.PumpRoom_AreaDataOld] 的实体类.
/// </summary>
namespace Grd.Models
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
    [DbContext(typeof(SqlServerDBContext))]
	public partial class Pumproom_areadataold : BaseModel<long?>
	{			
        ///<summary>
		///标识
		///</summary>
        public override long? id { get; set; }

        
        ///<summary>
		///泵房编号
		///</summary>
		public string pump_id { get; set; }

        
        ///<summary>
		///泵房名称
		///</summary>
		public string pump_name { get; set; }

        
        ///<summary>
		///区域
		///</summary>
		public int? area { get; set; }

        
        ///<summary>
		///记录编号
		///</summary>
		public string record_code { get; set; }

        
        ///<summary>
		///日期
		///</summary>
		public DateTime? record_time { get; set; }

        
        ///<summary>
		///压力
		///</summary>
		public double? pressure { get; set; }

        
        ///<summary>
		///频率
		///</summary>
		public double? frequency { get; set; }

        
        ///<summary>
		///小时流量
		///</summary>
		public double? hour_flow { get; set; }

        
        ///<summary>
		///日流量
		///</summary>
		public double? day_flow { get; set; }

        
        ///<summary>
		///
		///</summary>
		public double? month_flow { get; set; }

        
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
		///
		///</summary>
		public double? month_electricity { get; set; }

        
        ///<summary>
		///
		///</summary>
		public double? total_electricity { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string departmentids { get; set; }
        
	}
}
