using System;

namespace Topshelf.Core
{
    public static class GaiZhou_Lie
    {
        public static double dianliu(string vle, Func<string, double> conversion) => conversion(vle) * 20;
    }
}
