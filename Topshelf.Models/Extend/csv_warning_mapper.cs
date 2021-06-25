using System;

namespace Topshelf.Models
{
	public class csv_warning_mapper : mapper_head
	{
		// 處理數據邏輯，後期可能用來造假
		public static Pumproom_warningold FromCsv(string csvLine, Func<string, double> snc)
		{
			string[] values = csvLine.Split(',');
			Pumproom_warningold warningValues = new Pumproom_warningold();
			warningValues.pump_id = id;
			warningValues.pump_name = name;
			warningValues.department_ids = deptId;
			warningValues.record_time = Convert.ToDateTime(Convert.ToDateTime(values[1].Trim()).ToShortDateString() + " " + values[2].Trim().PadLeft(8, '0')).AddHours(-1);
			int idx = 0;
			Array.ForEach(warningValues.GetType().GetProperties(), p =>
			{
				if (idx > 4)
					p.SetValue(warningValues, snc(values[idx - 2].Trim()));
				idx++;
			});
			return warningValues;
		}
	}
}
