using Windows.ApplicationModel;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Livet
{
    /// <summary>
    /// UIDispatcherへのアクセスを簡易化します。
    /// </summary>
    public static class DispatcherHelper
    {
        private static CoreDispatcher _uiDispatcher;

        /// <summary>
        /// UIDispatcherを指定、または取得します。
        /// </summary>
        public static CoreDispatcher UIDispatcher
        {
            get
            {
                if (DesignMode.DesignModeEnabled)
                {
                    _uiDispatcher = Window.Current.Dispatcher;
                }
                return _uiDispatcher;
            }
            set
            {
                _uiDispatcher = value;
            }
        }
    }
}
