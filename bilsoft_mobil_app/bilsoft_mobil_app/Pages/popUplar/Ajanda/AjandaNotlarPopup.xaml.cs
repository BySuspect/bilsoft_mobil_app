using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.popUplar.Ajanda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjandaNotlarPopup : Popup
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color Success { get; set; } = Color.FromHex(AppThemeColors._success);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color Money { get; set; } = Color.FromHex(AppThemeColors._money);
        public Color MoneyBackground { get; set; } = Color.FromHex(AppThemeColors._moneyBackground);
        #endregion
        public AjandaNotlarPopup()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void edtNot_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 250)
            {
                lblNotLength.TextColor = Color.Red;
                if (e.NewTextValue.Length > 250)
                {
                    edtNot.Text = e.NewTextValue.Remove(250);
                }
            }
            else if (e.NewTextValue.Length < 250) lblNotLength.TextColor = Color.Default;
            lblNotLength.Text = "250/" + e.NewTextValue.Length.ToString();
        }

        private void btnKaydet_Clicked(object sender, EventArgs e)
        {

        }
    }
}