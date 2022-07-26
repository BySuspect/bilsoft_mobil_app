using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using bilsoft_mobil_app.CustomItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;

namespace bilsoft_mobil_app.Droid
{
    public class CustomDatePickerHelper
    {
        View _control;
        ICanBeValidated _element;

        public CustomDatePickerHelper(View control, ICanBeValidated element)
        {
            _control = control;
            _element = element;
            UpdateBorder();
        }

        public void UpdateBorder()
        {
            GradientDrawable gd = new GradientDrawable();
            //gd.SetColor (_element.BackgroundColor.ToAndroid ());
            gd.SetStroke((int)_element.BorderWidth * 2, _element.BorderColor.ToAndroid());
            gd.SetCornerRadius((float)_element.BorderRadius);
            _control.SetBackground(gd);
        }

        public void UpdateBorderByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "BorderColor":
                case "BorderRadius":
                case "BorderWidth":
                    UpdateBorder();
                    break;
                default:
                    return;
            }
        }
    }
}