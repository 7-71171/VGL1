using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VGL1.Models
{
    public class Search
    {
        public enum ReflectionSearchType
        {
            CLASS = 0,
            FIELD = 1,
            PROPERTY = 2,
            INTERFACE = 3,
            EVENT = 4,
        }

        public static int ReflectionCount(ReflectionSearchType type)
        {
            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
            switch (type)
            {
                case ReflectionSearchType.CLASS:
                    return allTypes.Count(t => t.IsClass);
                case ReflectionSearchType.FIELD:
                    return allTypes.Where(t => t.IsClass)
                                    .Select(t => t.GetFields())
                                    .Count();
                case ReflectionSearchType.PROPERTY:
                    return allTypes.Select(t => t.GetProperties())
                                    .Count();
                case ReflectionSearchType.INTERFACE:
                    return allTypes.Count(t => t.IsInterface);
                case ReflectionSearchType.EVENT:
                    return allTypes.Select(t => t.GetEvents())
                                    .Count();
                default:
                    return 0;
            }
        }
    }
}
