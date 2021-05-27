using System.Collections.Generic;

namespace Topshelf.Core
{
    public class ResourcesRelease
    {
        public static void ReleaseList<T>(List<T> obj) where T : class
        {
            obj.TrimExcess();
            obj.Clear();
        }
    }
}
