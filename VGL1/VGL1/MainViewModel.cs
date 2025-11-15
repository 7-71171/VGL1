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
        /// <summary>
        /// ウィンドウタイトル
        /// </summary>
        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// 戻るボタン表示状態
        /// </summary>
        private Visibility _backButtonVisibility;
        public Visibility BackButtonVisibility
        {
            get => _backButtonVisibility;
            set => SetProperty(ref _backButtonVisibility, value);
        }

        /// <summary>
        /// サイドバー項目
        /// </summary>
        private ObservableCollection<SidebarItem> _sidebarItems;
        public ObservableCollection<SidebarItem> SidebarItems
        {
            get => _sidebarItems;
            set => SetProperty(ref _sidebarItems, value);
        }

        /// <summary>
        /// ボタンコマンド
        /// </summary>
        public ICommand? ButtonCommand { get; }

        /// <summary>
        /// メインコンテンツフレーム
        /// </summary>
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
                // 戻るボタン用
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
            MainFrameContent = d.DefaultMainFrameContent;
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
