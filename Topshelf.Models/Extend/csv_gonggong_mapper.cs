using System;
using static Topshelf.Core.VisitPLC;
using static Topshelf.Core.GaiZhou_Lie;

namespace Topshelf.Models
{
    public class csv_gonggong_mapper
    {
		public static string id = default;
		public static string name = default;
		public static string deptId = default;

		// 處理數據邏輯，後期可能用來造假
		public static Pumproom_publicdataold FromCsv(string csvLine)
		{
			string[] values = csvLine.Split(',');
			Pumproom_publicdataold publicValues = new Pumproom_publicdataold();
			publicValues.record_time = Convert.ToDateTime(Convert.ToDateTime(values[1].Trim()).ToShortDateString() + " " + values[2].Trim().PadLeft(8, '0')).AddHours(-1);
			publicValues.hour_total_flow = ChangeDataToD(values[3]);
			publicValues.day_total_flow = ChangeDataToD(values[4]);
			publicValues.month_total_flow = ChangeDataToD(values[5]);
			publicValues.total_flow = ChangeDataToD(values[6]);
			publicValues.hour_electricity = dianliu(ChangeDataToD(values[7]));      // lie
			publicValues.day_electricity = dianliu(ChangeDataToD(values[8]));       // lie
			publicValues.month_electricity = dianliu(ChangeDataToD(values[9]));     // lie
			publicValues.hour_unit_consumption = ChangeDataToD(values[10]);
			publicValues.day_unit_consumption = ChangeDataToD(values[11]);
			publicValues.month_unit_consumption = ChangeDataToD(values[12]);
			publicValues.total_electricity = dianliu(ChangeDataToD(values[13]));    // lie
			publicValues.liquid_level = ChangeDataToD(values[14]);
			publicValues.chlorine = ChangeDataToD(values[15]);
			publicValues.ph = ChangeDataToD(values[16]);
			publicValues.turbidity = ChangeDataToD(values[17]);
			publicValues.temperature = ChangeDataToD(values[18]);
			publicValues.humidity = ChangeDataToD(values[19]);
			publicValues.inlet_pressure = ChangeDataToD(values[20]);
			//
			publicValues.pump_id = id;
			publicValues.pump_name = name;
			publicValues.department_ids = deptId;
			return publicValues;
		}

	}
}
