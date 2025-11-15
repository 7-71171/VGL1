using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VGL1.Controls;

namespace VGL1.Models
{
    public class DefaultValues
    {
        public string DefaultTitle { get; } = "VGL1";
        public Visibility DefaultBackButtonVisibility { get; } = Visibility.Collapsed;
        public ObservableCollection<SidebarItem> DefaultSidebarItems { get; }
        public Page DefaultMainFrameContent { get; } = new Menus.Home();

        public DefaultValues(MainViewModel vm)
        {
            DefaultSidebarItems = new()
            {
                { new SidebarItem { Icon = "🏠", Name = "Home", ButtonCommandParameter = vm.OpenHomeMenu } },
                { new SidebarItem { Icon = "📜", Name = "Examples", ButtonCommandParameter = vm.OpenExamplesMenu } },
            };
        }
    }
}
