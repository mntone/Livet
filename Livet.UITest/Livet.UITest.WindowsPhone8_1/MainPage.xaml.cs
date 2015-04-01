using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Livet.UITest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.DataContext = new PageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        { }

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