using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VGL1.Controls
{
    /// <summary>
    /// Sidebar.xaml の相互作用ロジック
    /// </summary>
    public partial class Sidebar : UserControl
    {
        public Visibility BackButtonVisibility
        {
            get { return (Visibility)GetValue(BackButtonVisibilityProperty);  }
            set { SetValue(BackButtonVisibilityProperty, value); }
        }
        public static readonly DependencyProperty BackButtonVisibilityProperty =
            DependencyProperty.Register(nameof(BackButtonVisibility), typeof(Visibility), typeof(Sidebar));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(Sidebar));

        public ICommand ButtonCommand
        {             
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register(nameof(ButtonCommand), typeof(ICommand), typeof(Sidebar));

        public ObservableCollection<SidebarItem> Items {
            get { return (ObservableCollection<SidebarItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(ObservableCollection<SidebarItem>), typeof(Sidebar));
        public Sidebar()
        {
            InitializeComponent();

            BackButton.IsVisibleChanged += (s, e) =>
            {
                var w = Window.GetWindow(this) as MainWindow;
                if (w is not null)
                {
                    if (BackButtonVisibility == Visibility.Visible)
                    {
                        w.TitlebarGrid.Margin = new Thickness(32 + 15, 0, 0, 0);
                    }
                    else
                    {
                        w.TitlebarGrid.Margin = new Thickness(15, 0, 0, 0);
                    }
                }
            };
        }
    }

    public class SidebarItem
    {
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public Action? ButtonCommandParameter { get; set; }
    }
}
