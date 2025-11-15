using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGL1.Models;

namespace VGL1.Menus
{
    public class HomeViewModel : ViewModelBase
    {
        public Dictionary<string, int> ReflectionCount { get; set; } = [];
        public HomeViewModel()
        {
            ReflectionCount["Class"] = Search.ReflectionCount(Search.ReflectionSearchType.CLASS);
            ReflectionCount["Field"] = Search.ReflectionCount(Search.ReflectionSearchType.FIELD);
            ReflectionCount["Property"] = Search.ReflectionCount(Search.ReflectionSearchType.PROPERTY);
            ReflectionCount["Interface"] = Search.ReflectionCount(Search.ReflectionSearchType.INTERFACE);
            ReflectionCount["Event"] = Search.ReflectionCount(Search.ReflectionSearchType.EVENT);
        }
    }
}
