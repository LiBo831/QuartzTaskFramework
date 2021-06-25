using System;

namespace Topshelf.Models
{
	public class csv_quyu_mapper : mapper_head
	{
		// 處理數據邏輯，後期可能用來造假
		public static Pumproom_areadataold FromCsv(string csvLine, Func<string, Func<string, double>, double> lie)
		{
			string[] values = csvLine.Split(',');
			Pumproom_areadataold areaValues = new Pumproom_areadataold();
			areaValues.pump_id = id;
			areaValues.pump_name = name;
			areaValues.department_ids = deptId;
			areaValues.record_time = Convert.ToDateTime(Convert.ToDateTime(values[1].Trim()).ToShortDateString() + " " + values[2].Trim().PadLeft(8, '0')).AddHours(-1);
			int idx = 0;
			Array.ForEach(areaValues.GetType().GetProperties(), p =>
			{
				if (idx > 4)
				{
					string vle = values[idx - 2].Trim();
					if (p.Name.Contains("electricity"))
						p.SetValue(areaValues, lie(vle, Core.VisitPLC.ScientificNotationChange));
					else if (p.Name.Contains("area"))
						p.SetValue(areaValues, Convert.ToInt32(vle));
					else
						p.SetValue(areaValues, Core.VisitPLC.ScientificNotationChange(vle));
				}
				idx++;
			});
			return areaValues;
		}
	}
}
