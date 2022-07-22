using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.popUplar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariGruplarPopup : Popup
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
        ObservableCollection<CariGuruplarListVeriler> _listItemsSource = new ObservableCollection<CariGuruplarListVeriler>();

        List<string> GrupListNames = new List<string> { "PERSONEL", "MÜŞTERİ", "TOPTANCI", "ALICI", "SATIŞ" };
        public CariGruplarPopup()
        {
            BindingContext = this;
            InitializeComponent();
            for (int i = 0; i < GrupListNames.Count(); i++)
            {
                RefeshList(i, GrupListNames[i]);
            }
            GrupListView.ItemsSource = _listItemsSource;
        }
        void RefeshList(int i, string name)
        {
            _listItemsSource.Add(new CariGuruplarListVeriler
            {
                ID = "grup" + i,
                Sira = i + 1,
                GrupAd = name
            });
        }
        async Task DeleteOnList(string id)
        {
            try
            {
                foreach (var item in _listItemsSource)
                {
                    if (item.ID == id)
                    {
                        GrupListNames.RemoveAt(item.Sira - 1);
                        break;
                    }
                }
                _listItemsSource.Clear();
                for (int i = 0; i < GrupListNames.Count(); i++)
                {
                    RefeshList(i, GrupListNames[i]);
                }
                if (_listItemsSource.Count > 0) GrupListView.ItemsSource = _listItemsSource;
                else GrupListView.ItemsSource = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        async Task AddOnList(string Name)
        {
            GrupListNames.Add(Name);
            _listItemsSource.Clear();
            for (int i = 0; i < GrupListNames.Count(); i++)
            {
                RefeshList(i, GrupListNames[i]);
            }
            if (_listItemsSource.Count > 0) GrupListView.ItemsSource = _listItemsSource;
            else GrupListView.ItemsSource = null;
        }
        private async void YeniGrupKaydet_Clicked(object sender, EventArgs e)
        {
            if (entryYeniGrup.Text != "")
            {
                entryYeniGrup.Unfocus();
                await AddOnList(entryYeniGrup.Text);
                YeniGrupView.IsVisible = false;
                entryYeniGrup.Text = "";
            }
            entryYeniGrup.Unfocus();
        }

        private void YeniGrupIptal_Clicked(object sender, EventArgs e)
        {
            entryYeniGrup.Unfocus();
            YeniGrupView.IsVisible = false;
            entryYeniGrup.Text = "";
        }

        private void btnYeniGrup_Clicked(object sender, EventArgs e)
        {
            YeniGrupView.IsVisible = true;
        }

        private void csbArama_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
                GrupListView.ItemsSource = _listItemsSource.Where(x => x.GrupAd.ToLower().StartsWith(e.NewTextValue.ToLower())).OrderBy(x => x).ToList();
            else
                GrupListView.ItemsSource = _listItemsSource;
            Console.WriteLine(csbArama.Text);
            csbArama.Unfocus();
        }

        private void csbArama_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(csbArama.Text);
            csbArama.Unfocus();
            entryYeniGrup.Unfocus();
        }

        private void btnListEdit_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnListDelete_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            await DeleteOnList(btn.AutomationId);
        }

        private void btnDismissPopUp_Clicked(object sender, EventArgs e)
        {
            Dismiss(_listItemsSource);
        }
    }
}