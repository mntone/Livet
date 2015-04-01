using System.Windows;

#if WIN8_1 || WINPHONE8_1
using Livet.Interactivity;
using Windows.UI.Xaml;
#elif WIN8
using Windows.UI.Interactivity;
using Windows.UI.Xaml;
#else
using System.Windows.Interactivity;
#endif

namespace Livet.Behaviors
{
    /// <summary>
    /// 引数を一つだけ持つメソッドに対応したCallMethodActionです。
    /// </summary>
#if WIN8_1 || WINPHONE8_1
    public class LivetCallMethodAction : Action
#elif WIN8
    public class LivetCallMethodAction : TriggerAction<FrameworkElement>
#else
    public class LivetCallMethodAction : TriggerAction<DependencyObject>
#endif
    {
        private MethodBinder _method = new MethodBinder();
        private MethodBinderWithArgument _callbackMethod = new MethodBinderWithArgument();

        private bool _parameterSet;

        /// <summary>
        /// メソッドを呼び出すオブジェクトを指定、または取得します。
        /// </summary>
        public object MethodTarget
        {
            get { return GetValue(MethodTargetProperty); }
            set { SetValue(MethodTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodTargetProperty =
            DependencyProperty.Register("MethodTarget", typeof(object), typeof(LivetCallMethodAction), new PropertyMetadata(null));

        /// <summary>
        /// 呼び出すメソッドの名前を指定、または取得します。
        /// </summary>
        public string MethodName
        {
            get { return (string)GetValue(MethodNameProperty); }
            set { SetValue(MethodNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodNameProperty =
            DependencyProperty.Register("MethodName", typeof(string), typeof(LivetCallMethodAction), new PropertyMetadata(null));


        /// <summary>
        /// 呼び出すメソッドに渡す引数を指定、または取得します。
        /// </summary>
        public object MethodParameter
        {
            get { return GetValue(MethodParameterProperty); }
            set { SetValue(MethodParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodParameterProperty =
            DependencyProperty.Register("MethodParameter", typeof(object), typeof(LivetCallMethodAction), new PropertyMetadata(null,OnMethodParameterChanged));

        private static void OnMethodParameterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var thisReference = (LivetCallMethodAction)sender;

            thisReference._parameterSet = true;
        }

#if WIN8_1 || WINPHONE8_1
        public override object Execute(object sender, object parameter)
#else
        protected override void Invoke(object parameter)
#endif
        {
#if WIN8_1 || WINPHONE8_1
            if (MethodTarget == null)
            {
                return true;
            }

            if (MethodName == null)
            {
                return true;
            }
#else
            if (MethodTarget == null) return;
            if (MethodName == null) return;
#endif

            if (!_parameterSet)
            {
                _method.Invoke(MethodTarget, MethodName);
            }
            else
            {
                _callbackMethod.Invoke(MethodTarget, MethodName, MethodParameter);
            }

#if WIN8_1 || WINPHONE8_1
            return true;
#endif
        }
    }
}
