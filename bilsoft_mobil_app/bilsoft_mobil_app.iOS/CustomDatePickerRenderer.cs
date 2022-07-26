using System;
using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace bilsoft_mobil_app.iOS
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        CustomDatePickerHelper _helper;

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element is ICanBeValidated)
            {
                _helper = new CustomDatePickerHelper(Control, Element as ICanBeValidated);
                Control.Text = (Element as CustomDatePicker).PlaceHolder;
                (Element as ICanBeValidated).ValidateChange = (obj) =>
                {
                    if (!obj)
                        Control.Text = (Element as CustomDatePicker).PlaceHolder;
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            _helper.UpdateBorderByPropertyName(e.PropertyName);
        }
    }
}