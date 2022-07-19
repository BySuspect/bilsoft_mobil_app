using Android.Content;
using Android.Graphics.Drawables;
using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomNumericUpDownEntry), typeof(CustomNumericEntryRenderer))]
namespace bilsoft_mobil_app.Droid
{
    public class CustomNumericEntryRenderer : EntryRenderer
    {
        public CustomNumericEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}