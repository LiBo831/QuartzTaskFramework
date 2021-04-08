// =================================================================== 
// 项目说明
//====================================================================
// 文件： Pumproom_profile.cs
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
/// 数据库 [WaterProject] 中表 [dbo.PumpRoom_Profile] 的实体类.
/// </summary>
namespace Grd.Models
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
    [DbContext(typeof(SqlServerDBContext))]
	public partial class Pumproom_profile : BaseModel<string>
	{			
        ///<summary>
		///
		///</summary>
        public override string id { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string pumproomname { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string network_ip { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string address { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string longitude { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string latitude { get; set; }

        
        ///<summary>
		///
		///</summary>
		public int? area_total { get; set; }

        
        ///<summary>
		///
		///</summary>
		public int? pump_total { get; set; }

        
        ///<summary>
		///
		///</summary>
		public int? equipment_total { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string watermax { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string description { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string remark { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string category { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string departmentid { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string departmentids { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string opc { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string methodname { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string cameraip { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string photo { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string overlaystatus { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string overlaycategoryid { get; set; }

        
        ///<summary>
		///
		///</summary>
		public string camerahisip { get; set; }
        
	}
}
