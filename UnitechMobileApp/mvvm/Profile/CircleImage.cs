using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UnitechMobileApp.mvvm.Profile
{
    public class CircleImage : Image
    {
        public static readonly BindableProperty TagProperty = BindableProperty.Create(nameof(Tag), typeof(object), typeof(CircleImage));
        public static readonly BindableProperty AvatarPathProperty = BindableProperty.Create(nameof(AvatarPath), typeof(object), typeof(CircleImage));

        public object Tag
        {
            get
            {
                return GetValue(TagProperty);
            }
            set
            {
                SetValue(TagProperty, value);
            }
        }

        public object AvatarPath
        {
            get
            {
                return GetValue(AvatarPathProperty);
            }
            set
            {
                SetValue(AvatarPathProperty, value);
            }
        }

    }
}
