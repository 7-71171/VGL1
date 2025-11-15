using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using VGL1.Controls;

namespace VGL1.Samples.App1
{
    public class App1ViewModel
    {
        public App1ViewModel()
        {
            var si = App.MainVM.SidebarItems;
            si.Clear();
            si.Add(new SidebarItem { Icon = "1️⃣", Name = "Year", ButtonCommandParameter = ShowYear });
            si.Add(new SidebarItem { Icon = "2️⃣", Name = "Month", ButtonCommandParameter = ShowMonth });
            si.Add(new SidebarItem { Icon = "3️⃣", Name = "Day", ButtonCommandParameter = ShowDay });
        }

        private void ShowYear()
        {
        }
        private void ShowMonth()
        {
        }
        private void ShowDay()
        {
        }
    }
}
