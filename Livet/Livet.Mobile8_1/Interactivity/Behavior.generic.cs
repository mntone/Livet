using System;
using Windows.UI.Xaml;

namespace Livet.Interactivity
{
    public abstract class Behavior<T>: Behavior
        where T: DependencyObject
    {
        protected Behavior()
            : base(typeof(T))
        { }

        public sealed override Type AssociatedType
        {
            get
            {
                return this.AssociatedType;
            }
        }
    }
}
