using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Profile
{   
    public class CustomLabel : Label
    {
        public static readonly BindableProperty ShadowPropety = BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(CustomLabel), false);

        public bool HasShadow
        {
            get
            {
                return (bool)GetValue(ShadowPropety);
            }
            set
            {
                SetValue(ShadowPropety, value);
            }
        }
    }
}
