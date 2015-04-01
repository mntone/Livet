using System;
using System.Windows;

#if WIN8
using Windows.UI.Interactivity;
using Windows.UI.Xaml;
#else
using System.Windows.Interactivity;
#endif

namespace Livet.Behaviors
{
    /// <summary>
    /// アタッチしたオブジェクトのDataContextがIDisposableである場合、Disposeします。
    /// </summary>
    public class DataContextDisposeAction : TriggerAction<FrameworkElement>
	{
        protected override void Invoke(object parameter)
        {
            var disposable = AssociatedObject.DataContext as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
