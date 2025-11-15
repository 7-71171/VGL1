using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VGL1.Models;
using VGL1.Samples.App1;

namespace VGL1.Menus
{
    public class ExamplesViewModel :ViewModelBase
    {
        private string _appIdInput;
        public string AppIdInput
        {
            get => _appIdInput;
            set => SetProperty(ref _appIdInput, value);
        }
        public ICommand ExecuteCommand { get; }
        public ObservableCollection<AppItem> AppItems { get; }
        public ExamplesViewModel()
        {
            ExecuteCommand = new RelayCommand<object>(Execute);
            AppItems =
            [
                new AppItem { AppId = 1, AppName = "Calender", AppDescription = "シンプルなカレンダー", AppType = typeof(App1) },
                new AppItem { AppId = 2, AppName = "Example App 2", AppDescription = "This is the second example app." },
                new AppItem { AppId = 3, AppName = "Example App 3", AppDescription = "This is the third example app." }
            ];
        }

        private void Execute(object? parameter)
        {
            if (int.TryParse(AppIdInput, out int appId))
            {
                var app = AppItems.FirstOrDefault(a => a.AppId == appId);
                if (app is not null)
                {
                    object instance = Activator.CreateInstance(app.AppType)!;
                    if (instance is Page p)
                    {
                        var vm = App.MainVM;
                        var d = new DefaultValues(vm);
                        vm.Title = $"{d.DefaultTitle}  >  App {app.AppId} ({app.AppName})";
                        vm.BackButtonVisibility = Visibility.Visible;
                        vm.MainFrameContent = p;
                    }
                }
                else
                {
                    MessageBox.Show("存在しない");
                }
            }
            else
            {
                // Handle invalid input
            }
        }
    }

    public class  AppItem
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public string AppDescription { get; set; }
        public Type AppType { get; set; }
    }
}
