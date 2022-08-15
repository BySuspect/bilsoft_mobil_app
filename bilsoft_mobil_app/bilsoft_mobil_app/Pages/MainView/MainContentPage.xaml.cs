using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using bilsoft_mobil_app.Helper;
using Xamarin.Essentials;
using Android.Content.Res;
using bilsoft_mobil_app.Pages.MainView;
using Xamarin.CommunityToolkit.Extensions;
using bilsoft_mobil_app.Helper.Veriler;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.API;
using RestSharp;
using Newtonsoft.Json;
using bilsoft_mobil_app.Helper.JSONHelpers.RootAjanda;
using bilsoft_mobil_app.Pages.Ajanda;
using System.Collections.ObjectModel;
using Microcharts.Forms;
using SkiaSharp.Views.Forms;
using System.Net.Http.Headers;
using Xamarin.CommunityToolkit.Markup;

namespace bilsoft_mobil_app.Pages.MainView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
        public Color NavBarColor { get; set; } = Color.FromHex(AppThemeColors._navbarcolor);
        #endregion

        public ObservableCollection<MainContentPageViewItems> _mainContentPageViewItemsSource { get; set; }
        public MainContentPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MainViewStart();
        }
        #region Main Content
        private async void MainViewStart()
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;

            _mainContentPageViewItemsSource = new ObservableCollection<MainContentPageViewItems>();

            #region Grafikler

            #endregion

            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "Menü", View = "Main" });

            #region Donut Charts

            var DonutchartVerileriList = await getChartsDonut();

            Color donutC1 = Color.FromHex("#00C321"),
                  donutC2 = Color.FromHex("#005AD4"),
                  donutC3 = Color.FromHex("#D90000"),
                  donutC4 = Color.Gray;

            foreach (var item in DonutchartVerileriList)
            {
                _mainContentPageViewItemsSource.Add(new MainContentPageViewItems()
                {
                    Name = item.Name,
                    View = "Donut",
                    ChartValue1 = item.Money1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                    ChartValue2 = item.Money2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                    ChartValue3 = item.Money3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                    ChartValue4 = item.Money4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                    ChartValueColor1 = donutC1,
                    ChartValueColor2 = donutC2,
                    ChartValueColor3 = donutC3,
                    ChartValueColor4 = donutC4,
                    ChartValueName1 = item.Label1,
                    ChartValueName2 = item.Label2,
                    ChartValueName3 = item.Label3,
                    ChartValueName4 = item.Label4,

                    ChartView = new DonutChart
                    {
                        Entries = new List<ChartEntry>
                        {
                            new ChartEntry(item.Value1)
                            {
                                Color=donutC1.ToSKColor(),
                            },
                            new ChartEntry(item.Value2)
                            {
                                Color=donutC2.ToSKColor(),
                            },
                            new ChartEntry(item.Value3)
                            {
                                Color=donutC3.ToSKColor(),
                            },
                            new ChartEntry(item.Value4)
                            {
                                Color=donutC4.ToSKColor(),
                            }
                        },
                        IsAnimated = true,
                        AnimationDuration = TimeSpan.FromSeconds(3),
                        LabelMode = LabelMode.None,
                        GraphPosition = GraphPosition.Center,
                        BackgroundColor = SKColors.Transparent,
                    }
                });
            }

            #endregion

            MainPageCarouselView.ItemsSource = _mainContentPageViewItemsSource;
            MainPageCarouselView.Position = 0;

            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        async Task<List<donutChartItems>> getChartsDonut()
        {
            return new List<donutChartItems>
            {
                new donutChartItems
                {
                    Name="Günlük Satış",
                    Label1="Nakit",
                    Value1=67,
                    Money1=67.00,
                    Label2="Kredi Kartı",
                    Value2=1179,
                    Money2=1179.40,
                    Label3="Açık Hesap",
                    Value3=73,
                    Money3=73.50,
                    Label4="Yok",
                    Value4=0,
                    Money4=0.00,
                },

                new donutChartItems
                {
                    Name="Günlük Alış",
                    Label1="Nakit",
                    Value1=223,
                    Money1=223.00,
                    Label2="Kredi Kartı",
                    Value2=559,
                    Money2=1179.40,
                    Label3="Açık Hesap",
                    Value3=2041,
                    Money3=2041.40,
                    Label4="Yok",
                    Value4=0,
                    Money4=0.00,
                },

                new donutChartItems
                {
                    Name="Günlük Tahsilat",
                    Label1="Çek",
                    Value1=132,
                    Money1=132.00,
                    Label2="Nakit",
                    Value2=150,
                    Money2=150.00,
                    Label3="Kredi Kartı",
                    Value3=125,
                    Money3=125.00,
                    Label4="Yok",
                    Value4=0,
                    Money4=0.00,
                },

                new donutChartItems
                {
                    Name="Günlük Ödeme",
                    Label1="Çek",
                    Value1=148,
                    Money1=148.00,
                    Label2="Nakit",
                    Value2=130,
                    Money2=130.00,
                    Label3="Kredi Kartı",
                    Value3=100,
                    Money3=100.00,
                    Label4="Yok",
                    Value4=0,
                    Money4=0.00,
                },
            };
        }
        #endregion

        #region mainView Navigation
        private void btnNavHome_Tapped(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainContentPage(), this);
            Navigation.PopAsync(false);
        }

        #region Kullanıcı Ayarları Menü
        private void btnNavSettings_Tapped(object sender, EventArgs e)
        {
            UserPopup.IsVisible = true;
            userSettingsViewBack.IsVisible = true;
            UserPopupbtnLogout.TranslateTo/*        */(0, 0, 120);
            UserPopupbtnFirmaInfo.TranslateTo/*     */(0, 0, 140);
            UserPopupbtnYetkiAyarlari.TranslateTo/* */(0, 0, 160);
            UserPopupbtnMailAyarlari.TranslateTo/*  */(0, 0, 180);
        }
        private async void btnNavSettingsClose_Tapped(object sender, EventArgs e)
        {
            userSettingsViewBack.IsVisible = false;
            _ = UserPopupbtnLogout.TranslateTo/*        */(300, 0, 120);
            _ = UserPopupbtnFirmaInfo.TranslateTo/*     */(300, 0, 140);
            _ = UserPopupbtnYetkiAyarlari.TranslateTo/* */(300, 0, 160);
            _ = UserPopupbtnMailAyarlari.TranslateTo/*  */(300, 0, 180);
            await Task.Delay(100);
            UserPopup.IsVisible = false;
        }
        private void UserPopupbtnMailAyarlari_Tapped(object sender, EventArgs e)
        {

        }
        private void UserPopupbtnYetkiAyarlari_Tapped(object sender, EventArgs e)
        {

        }
        private void UserPopupbtnFirmaInfo_Tapped(object sender, EventArgs e)
        {

        }
        private async void UserPopupbtnLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Clear();
            await Navigation.PushModalAsync(new LoginPage());
        }
        #endregion

        #region Hızlı Menü
        private void btnNavMenu_Tapped(object sender, EventArgs e)
        {
            MenuPopup.IsVisible = true;
            popupMenuBack.IsVisible = true;
            PopUpMenuItemPanel.TranslateTo/*       */(0, 0, 120);
            PopUpMenuItemCariArama.TranslateTo/*   */(0, 0, 140);
            PopUpMenuItemCariIslemler.TranslateTo/**/(0, 0, 160);
            PopUpMenuItemStokKartlar.TranslateTo/* */(0, 0, 180);
            PopUpMenuItemSatisYap.TranslateTo/*    */(0, 0, 200);
            PopUpMenuItemFaturalar.TranslateTo/*   */(0, 0, 220);
            PopUpMenuItemFiyatGor.TranslateTo/*    */(0, 0, 240);
        }

        private async void btnPopupMenuClose_Tapped(object sender, EventArgs e)
        {
            popupMenuBack.IsVisible = false;
            _ = PopUpMenuItemPanel.TranslateTo/*       */(-300, 0, 120);
            _ = PopUpMenuItemCariArama.TranslateTo/*   */(-300, 0, 140);
            _ = PopUpMenuItemCariIslemler.TranslateTo/**/(-300, 0, 160);
            _ = PopUpMenuItemStokKartlar.TranslateTo/* */(-300, 0, 180);
            _ = PopUpMenuItemSatisYap.TranslateTo/*    */(-300, 0, 200);
            _ = PopUpMenuItemFaturalar.TranslateTo/*   */(-300, 0, 220);
            _ = PopUpMenuItemFiyatGor.TranslateTo/*    */(-300, 0, 240);
            await Task.Delay(150);
            MenuPopup.IsVisible = false;
        }

        #region popup menu items
        private void btnPopUpMenuItemPanel_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemCariArama_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemCariIslemler_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemStokKartlar_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemSatisYap_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemFaturalar_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }

        private void btnPopUpMenuItemFiyatGor_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("", sender.ToString(), "ok");
        }
        #endregion

        #endregion

        #endregion

        int test = 0;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            this.Title = test + "";
            test++;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var DonutchartVerileriList = await getChartsDonut();
            testedt.Text = "";
            foreach (var item in DonutchartVerileriList)
            {
                testedt.Text += "\n" + item.Money1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                testedt.Text += "\n" + item.Money2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                testedt.Text += "\n" + item.Money3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                testedt.Text += "\n" + item.Money4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
            }
            MainViewStart();
        }
    }
    public class donutChartItems
    {
        public string Name { get; set; }
        public int Value1 { get; set; }
        public double Money1 { get; set; }
        public string Label1 { get; set; }
        public int Value2 { get; set; }
        public double Money2 { get; set; }
        public string Label2 { get; set; }
        public int Value3 { get; set; }
        public double Money3 { get; set; }
        public string Label3 { get; set; }
        public int Value4 { get; set; }
        public double Money4 { get; set; }
        public string Label4 { get; set; }
    }
}