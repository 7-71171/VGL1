using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VGL1.Controls;

namespace VGL1.Models
{
    public class DefaultValues
    {
        public string DefaultTitle { get; }
        public Visibility DefaultBackButtonVisibility { get; }
        public ObservableCollection<SidebarItem> DefaultSidebarItems { get; }

        public DefaultValues(MainViewModel vm)
        {
            DefaultTitle = "VGL1";
            DefaultBackButtonVisibility = Visibility.Collapsed;
            DefaultSidebarItems = new()
            {
                { new SidebarItem { Icon = "🏠", Name = "Home", ButtonCommandParameter = vm.OpenHomeMenu } },
                { new SidebarItem { Icon = "📜", Name = "Examples", ButtonCommandParameter = vm.OpenExamplesMenu } },
            };
        }
    }
}
