using System;
using Xamarin.Forms;

namespace ValidationsXFSample.Helpers.Behaviours
{
    public class EntryLineValidationBehaviour : BehaviorBase<Entry>
    {
        #region StaticFields
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EntryLineValidationBehaviour), true, BindingMode.Default, null, (bindable, oldValue, newValue) => OnIsValidChanged(bindable, newValue));
        #endregion
        #region Properties
        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }
        #endregion
        #region StaticMethods
        private static void OnIsValidChanged(BindableObject bindable, object newValue)
        {
            if (bindable is EntryLineValidationBehaviour IsValidBehavior &&
                 newValue is bool IsValid)
            {
                IsValidBehavior.AssociatedObject.PlaceholderColor = IsValid ? Color.Default : Color.Red;
            }
        }

        #endregion
    }
}