using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VGL1.Controls;
using VGL1.Models;

namespace VGL1
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand? ButtonCommand { get; }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private Visibility _backButtonVisibility;
        public Visibility BackButtonVisibility
        {
            get => _backButtonVisibility;
            set => SetProperty(ref _backButtonVisibility, value);
        }

        private ObservableCollection<SidebarItem> _sidebarItems;
        public ObservableCollection<SidebarItem> SidebarItems
        {
            get => _sidebarItems;
            set => SetProperty(ref _sidebarItems, value);
        }

        private Page _mainFrameContent;
        public Page MainFrameContent
        {
            get => _mainFrameContent;
            set => SetProperty(ref _mainFrameContent, value);
        }

        public MainViewModel()
        {
            ButtonCommand = new RelayCommand<Action>(param =>
            {
                if (param is null)
                {
                    OpenHomeMenu();
                }
                else
                {
                    param?.Invoke();
                }
            });

            SetDefaultView();
        }

        public void SetDefaultView()
        {
            var d = new DefaultValues(this);
            Title = d.DefaultTitle;
            BackButtonVisibility = d.DefaultBackButtonVisibility;
            SidebarItems = d.DefaultSidebarItems;
            MainFrameContent = new Menus.Home();
        }

        public void OpenHomeMenu()
        {
            SetDefaultView();
        }

        public void OpenExamplesMenu()
        {
            var d = new DefaultValues(this);
            Title = d.DefaultTitle + "  >  Examples";
            BackButtonVisibility = Visibility.Visible;
            MainFrameContent = new Menus.Examples();
        }
    }
}
