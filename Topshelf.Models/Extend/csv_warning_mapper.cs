using System;
using static Topshelf.Core.VisitPLC;

namespace Topshelf.Models
{
    public class csv_warning_mapper
    {
        public static string id = default;
        public static string name = default;
        public static string deptId = default;

		// 處理數據邏輯，後期可能用來造假
		public static Pumproom_warningold FromCsv(string csvLine)
		{
			string[] values = csvLine.Split(',');
			Pumproom_warningold warningValues = new Pumproom_warningold();
			warningValues.record_time = Convert.ToDateTime(Convert.ToDateTime(values[1].Trim()).ToShortDateString() + " " + values[2].Trim().PadLeft(8, '0')).AddHours(-1);
			warningValues.dimian = ChangeDataToD(values[3]);
			warningValues.menjin = ChangeDataToD(values[4]);
			warningValues.yiqquchaoya = ChangeDataToD(values[5]);
			warningValues.erquchaoya = ChangeDataToD(values[6]);
			warningValues.sanquchaoya = ChangeDataToD(values[7]);
			warningValues.siquchaoya = ChangeDataToD(values[8]);
			warningValues.jinshuidiya = ChangeDataToD(values[9]);
			warningValues.yibiangu = ChangeDataToD(values[10]);
			warningValues.erbiangu = ChangeDataToD(values[11]);
			warningValues.sanbiangu = ChangeDataToD(values[12]);
			warningValues.sibiangu = ChangeDataToD(values[13]);
			warningValues.gaowen = ChangeDataToD(values[14]);
			warningValues.diwen = ChangeDataToD(values[15]);
			warningValues.chaoshi = ChangeDataToD(values[16]);
			warningValues.yanwu = ChangeDataToD(values[17]);
			warningValues.gaoshuiwei = ChangeDataToD(values[18]);
			warningValues.dishuiwei = ChangeDataToD(values[19]);
			warningValues.diandongfa = ChangeDataToD(values[20]);
			warningValues.paigu = ChangeDataToD(values[21]);
			warningValues.duandian = ChangeDataToD(values[22]);
			//
			warningValues.pump_id = id;
			warningValues.pump_name = name;
			warningValues.department_ids = deptId;
			return warningValues;
		}
	}
}
