using System;
using Xamarin.Forms;

namespace ValidationsXFSample.Helpers.Behaviours
{
    public class BehaviorBase<T> : Behavior<T>
    where T : BindableObject
    {
        #region Properties
        public T AssociatedObject
        {
            get;
            private set;
        }
        #endregion
        #region NormalMethods
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }
        #endregion
        #region Overrides
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
        #endregion
    }
}