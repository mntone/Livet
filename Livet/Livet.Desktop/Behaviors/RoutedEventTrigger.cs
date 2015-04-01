using System;
using System.Windows;

#if WINRT
using Windows.UI.Interactivity;
using Windows.UI.Xaml;
#else
using System.Windows.Interactivity;
#endif

namespace Livet.Behaviors
{
    //http://joyfulwpf.blogspot.com/2009/05/mvvm-invoking-command-on-attached-event.html

    /// <summary>
    /// 添付イベントに対応したイベントトリガーです。
    /// </summary>
    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        /// <summary>
        /// 対象のRoutedEventを取得、または設定します。
        /// </summary>
        public RoutedEvent RoutedEvent { get; set; }

        protected override void OnAttached()
        {
            var behavior = AssociatedObject as Behavior;
            var associatedElement = AssociatedObject as FrameworkElement;

            if (behavior != null)
            {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }
            if (associatedElement == null)
            {
                throw new ArgumentException("Routed Event trigger can only be associated to framework elements");
            }
            if (RoutedEvent != null)
            {
#if WIN8
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent), false);
#else
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(OnRoutedEvent));
#endif
            }
        }
        void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            base.OnEvent(args);
        }
        protected override string GetEventName()
        {
#if WIN8
            return RoutedEvent.ToString();
#else
            return RoutedEvent.Name;
#endif
        }
    }

}
