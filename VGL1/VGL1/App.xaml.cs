using System.Configuration;
using System.Data;
using System.Windows;

namespace VGL1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainViewModel MainVM { get; } = new();
    }

}
