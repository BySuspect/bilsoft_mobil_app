using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.iOS;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEditor), typeof(BorderlessEditorRenderer))]
namespace bilsoft_mobil_app.iOS
{
    public class BorderlessEditorRenderer : EditorRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;

            //Hatalı Olabilir bu normal değer: 
            //Control.BorderStyle = UITextBorderStyle.None;
            Control.Layer.BorderColor = null;
        }
    }
}