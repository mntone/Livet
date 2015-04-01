using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Livet.UITest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new PageViewModel();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as IDisposable;
            if (vm != null)
            {
                vm.Dispose();
            }
        }
    }
}