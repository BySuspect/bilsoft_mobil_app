using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.popUplar.CariHesaplar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariMahsupFisiPopup : Popup
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color Success { get; set; } = Color.FromHex(AppThemeColors._success);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color Money { get; set; } = Color.FromHex(AppThemeColors._money);
        public Color MoneyBackground { get; set; } = Color.FromHex(AppThemeColors._moneyBackground);
        #endregion

        public CariMahsupFisiPopup()
        {
            InitializeComponent();
            BindingContext = this;

        }

        private void pickerCariListe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void entryCariArama_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}