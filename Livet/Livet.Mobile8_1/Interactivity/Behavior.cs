using Microsoft.Xaml.Interactivity;
using System;
using System.Reflection;
using Windows.UI.Xaml;

namespace Livet.Interactivity
{
    public abstract class Behavior: DependencyObject, IBehavior
    {
        private readonly Type _associatedType;

        private DependencyObject _associatedObject;

        protected Behavior(Type associatedType)
            : base()
        {
            this._associatedType = associatedType;
        }

        public void Attach(DependencyObject dependencyObject)
        {
            if (this.AssociatedObject != dependencyObject)
            {
                if (this.AssociatedObject != null)
                {
                    // TODO: message
                    throw new InvalidOperationException();
                }

                if (dependencyObject != null)
                {
                    throw new ArgumentNullException("dependencyObject");
                }

                if (!this.AssociatedType.GetTypeInfo().IsAssignableFrom(dependencyObject.GetType().GetTypeInfo()))
                {
                    // TODO: message
                    throw new InvalidOperationException();
                }

                this._associatedObject = dependencyObject;
                this.OnAssociatedObjectChanged();

                this.OnAttached();
            }
        }

        protected virtual void OnAttached()
        { }

        public void Detach()
        {
            this.OnDetaching();
            this._associatedObject = null;
            this.OnAssociatedObjectChanged();
        }

        protected virtual void OnDetaching()
        { }

        
        public EventHandler AssociatedObjectChanged;

        private void OnAssociatedObjectChanged()
        {
            if (this.AssociatedObjectChanged != null)
            {
                this.AssociatedObjectChanged(this, EventArgs.Empty);
            }
        }

        public bool IsEnabled
        {
            get { return (bool)this.GetValue(IsEnabledProperty); }
            set { this.SetValue(IsEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register("IsEnabled", typeof(bool), typeof(Action), new PropertyMetadata(0));

        public virtual DependencyObject AssociatedObject
        {
            get
            {
                return this._associatedObject;
            }
        }

        public virtual Type AssociatedType
        {
            get
            {
                return this._associatedType;
            }
        }
    }
}