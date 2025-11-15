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
    public partial class VGLWindow : UserControl
    {
        public Window ParentWindow { get; set; }
        public Visibility BackButtonVisibility
        {
            get { return (Visibility)GetValue(BackButtonVisibilityProperty);  }
            set { SetValue(BackButtonVisibilityProperty, value); }
        }
        public static readonly DependencyProperty BackButtonVisibilityProperty =
            DependencyProperty.Register(nameof(BackButtonVisibility), typeof(Visibility), typeof(VGLWindow));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(VGLWindow));

        public ICommand ButtonCommand
        {             
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register(nameof(ButtonCommand), typeof(ICommand), typeof(VGLWindow));

        public ObservableCollection<SidebarItem> SidebarItems {
            get { return (ObservableCollection<SidebarItem>)GetValue(SidebarItemsProperty); }
            set { SetValue(SidebarItemsProperty, value); }
        }
        public static readonly DependencyProperty SidebarItemsProperty =
            DependencyProperty.Register(nameof(SidebarItems), typeof(ObservableCollection<SidebarItem>), typeof(VGLWindow));
        
        public Page MainFrameContent
        {
            get { return (Page)GetValue(MainFrameContentProperty); }
            set { SetValue(MainFrameContentProperty, value); }
        }
        public static readonly DependencyProperty MainFrameContentProperty =
            DependencyProperty.Register(nameof(MainFrameContent), typeof(Page), typeof(VGLWindow));


        public VGLWindow()
        {
            InitializeComponent();

            this.Loaded += (s, e) => ParentWindow = Window.GetWindow(this);

            BackButton.IsVisibleChanged += (s, e) =>
            {
                if (BackButtonVisibility == Visibility.Visible)
                {
                    TitlebarGrid.Margin = new Thickness(32 + 15, 0, 0, 0);
                }
                else
                {
                    TitlebarGrid.Margin = new Thickness(15, 0, 0, 0);
                }
            };
        }

        private void Titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ParentWindow.WindowState = (ParentWindow.WindowState == WindowState.Maximized)
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
            else if (e.ButtonState == MouseButtonState.Pressed)
            {
                ParentWindow.DragMove();
            }
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.WindowState = WindowState.Minimized;
        }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.WindowState = (ParentWindow.WindowState == WindowState.Maximized)
                ? ParentWindow.WindowState = WindowState.Normal
                : ParentWindow.WindowState = WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.Close();
        }
    }

    public class SidebarItem
    {
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public Action? ButtonCommandParameter { get; set; }
    }
}
