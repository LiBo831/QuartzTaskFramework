using System;
using static Topshelf.Core.VisitPLC;
using static Topshelf.Core.GaiZhou_Lie;

namespace Topshelf.Models
{
    public class csv_quyu_mapper
    {
		public static string id = default;
		public static string name = default;
		public static string deptId = default;

		// 處理數據邏輯，後期可能用來造假
		public static Pumproom_areadataold FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
			Pumproom_areadataold areaValues = new Pumproom_areadataold();
			var currentTime = Convert.ToDateTime(Convert.ToDateTime(values[1].Trim()).ToShortDateString() + " " + values[2].Trim().PadLeft(8, '0')).AddHours(-1);
			areaValues.record_time = currentTime;
			areaValues.pressure = ChangeDataToD(values[3]);
			areaValues.frequency1 = ChangeDataToD(values[4]);
			areaValues.frequency2 = ChangeDataToD(values[5]);
			areaValues.frequency3 = ChangeDataToD(values[6]);
			areaValues.frequency4 = ChangeDataToD(values[7]);
			areaValues.hour_flow = ChangeDataToD(values[8]);
			areaValues.day_flow = ChangeDataToD(values[9]);
			areaValues.area = Convert.ToInt32(values[10].Trim());
			areaValues.month_flow = ChangeDataToD(values[11]);
			areaValues.total_flow = ChangeDataToD(values[12]);
			areaValues.hour_electricity = dianliu(ChangeDataToD(values[13]));       // lie	
			areaValues.day_electricity = dianliu(ChangeDataToD(values[14]));        // lie
			areaValues.month_electricity = dianliu(ChangeDataToD(values[15]));      // lie
			areaValues.total_electricity = dianliu(ChangeDataToD(values[16]));      // lie
			//
			areaValues.pump_id = id;
			areaValues.pump_name = name;
			areaValues.department_ids = deptId;
			return areaValues;
        }
	}
}
