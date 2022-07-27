using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Pages.popUplar.CariHesaplar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariHesapMahsupFisiPage : ContentPage
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
        string borcSecilenCari = "", alacakSecilenCari = "";
        public CariHesapMahsupFisiPage()
        {
            InitializeComponent();
            BindingContext = this;
            pickerDate.PlaceHolder = "  " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }

        private async void btnCariAlacaklandirilacak_Clicked(object sender, EventArgs e)
        {
            Popup popup = new CariMahsupFisiPopup();
            await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
        }

        private void ListCari_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var _item = (sender as ListView).SelectedItem as CariMahsupFisiPopupVeriler;
        }

        private async void btnCariBorclandirilacak_Clicked(object sender, EventArgs e)
        {
            Popup popup = new CariMahsupFisiPopup();
            await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
        }
    }
}