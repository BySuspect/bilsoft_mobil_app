using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.popUplar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariEklePopup : Popup
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
        public CariEklePopup()
        {
            BindingContext = this;
            InitializeComponent();
        }

        private void stpRiskLimit_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (Convert.ToInt16(entryRiskLimit.Text) > e.NewValue)
                stpRiskLimit.Value = 1 + Convert.ToInt16(entryRiskLimit.Text);
            else
                entryRiskLimit.Text = String.Format("{0}", e.NewValue);
        }

        private void entryRiskLimit_Unfocused(object sender, FocusEventArgs e)
        {
            stpRiskLimit.Value = Convert.ToInt16(entryRiskLimit.Text);
        }

        private void entryVadeTarih_Unfocused(object sender, FocusEventArgs e)
        {
            if (Convert.ToInt16(entryVadeTarih.Text) > 31) entryVadeTarih.Text = "31";
            stpVadeTarih.Value = Convert.ToInt16(entryVadeTarih.Text);
        }

        private void stpVadeTarih_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (Convert.ToInt16(entryVadeTarih.Text) > e.NewValue)
                stpVadeTarih.Value = 1 + Convert.ToInt16(entryVadeTarih.Text);
            else
                entryVadeTarih.Text = String.Format("{0}", e.NewValue);
        }

        private void btnAddSevkAdrs_Clicked(object sender, EventArgs e)
        {
            sevkAdresEkleView.IsVisible = true;
        }

        private void btnKaydet_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAdressKaydet_Clicked(object sender, EventArgs e)
        {

        }
    }
}