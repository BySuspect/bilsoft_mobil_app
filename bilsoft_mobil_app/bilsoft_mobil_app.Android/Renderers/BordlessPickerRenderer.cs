using Android.Content;
using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessPicker), typeof(BordlessPickerRenderer))]
namespace bilsoft_mobil_app.Droid
{
    public class BordlessPickerRenderer : PickerRenderer
    {
        public BordlessPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }

    }
}
