using System;
using Windows.UI.Xaml;

namespace Livet.UITest
{
    public sealed partial class MainPage : Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new PageViewModel();

            this.Unloaded += (sender, e) =>
            {
                var vm = this.DataContext as IDisposable;
                if (vm != null)
                {
                    vm.Dispose();
                }
            };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), DateTime.Now.ToBinary());
        }
    }
}
