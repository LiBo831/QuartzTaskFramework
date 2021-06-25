using System;

namespace Topshelf.Models
{
    public class csv_gonggong_mapper : mapper_head
	{
		// 處理數據邏輯，後期可能用來造假
		public static Pumproom_publicdataold FromCsv(string csvLine, Func<string, Func<string, double>, double> lie)
		{
			string[] values = csvLine.Split(',');
			Pumproom_publicdataold publicValues = new Pumproom_publicdataold();
			publicValues.pump_id = id;
			publicValues.pump_name = name;
			publicValues.department_ids = deptId;
			publicValues.record_time = Convert.ToDateTime(Convert.ToDateTime(values[1].Trim()).ToShortDateString() + " " + values[2].Trim().PadLeft(8, '0')).AddHours(-1);
			int idx = 0;
			Array.ForEach(publicValues.GetType().GetProperties(), p =>
			{
				if (idx > 4)
				{
					string vle = values[idx - 2].Trim();
					if (p.Name.Contains("electricity"))
						p.SetValue(publicValues, lie(vle, Core.VisitPLC.ScientificNotationChange));
					else
						p.SetValue(publicValues, Core.VisitPLC.ScientificNotationChange(vle));
				}
				idx++;
			});
			return publicValues;
		}

	}
}
