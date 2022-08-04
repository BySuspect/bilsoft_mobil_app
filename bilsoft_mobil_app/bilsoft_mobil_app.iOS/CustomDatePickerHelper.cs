using bilsoft_mobil_app.CustomItems;
using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace bilsoft_mobil_app.iOS
{
    public class CustomDatePickerHelper
    {
        UITextField _control;
        ICanBeValidated _element;

        public CustomDatePickerHelper(UITextField control, ICanBeValidated element)
        {
            _control = control;
            _element = element;

            _control.BorderStyle = UITextBorderStyle.RoundedRect;
            _control.ClipsToBounds = true;
            _control.Layer.MasksToBounds = true;
            UpdateBorder();
        }

        public void UpdateBorder()
        {
            _control.Layer.CornerRadius = (nfloat)_element.BorderRadius;
            _control.Layer.BorderColor = _element.BorderColor.ToCGColor();
            _control.Layer.BorderWidth = (nfloat)_element.BorderWidth;

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