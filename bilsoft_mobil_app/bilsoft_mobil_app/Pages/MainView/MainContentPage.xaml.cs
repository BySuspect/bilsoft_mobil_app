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
        private void MainViewStart()
        {
            _mainContentPageViewItemsSource = new ObservableCollection<MainContentPageViewItems>();

            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "Menü", View = "Main" });
            #region Donut Charts

            Color c1 = Color.FromHex("#FF1000"),
                c2 = Color.FromHex("#36FF00"),
                c3 = Color.FromHex("#FF00C3"),
                c4 = Color.FromHex("#003CFF");

            string t1 = "test1",
                t2 = "test2",
                t3 = "test3",
                t4 = "test4";

            int v1 = 1255,
                v2 = 2000,
                v3 = 200,
                v4 = 500;

            #region Günlük Satış Chart
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems()
            {
                Name = "Günlük Satış",
                View = "Chart",
                ChartValue1 = v1,
                ChartValue2 = v2,
                ChartValue3 = v3,
                ChartValue4 = v4,
                ChartValueColor1 = c1,
                ChartValueColor2 = c2,
                ChartValueColor3 = c3,
                ChartValueColor4 = c4,
                ChartValueName1 = t1,
                ChartValueName2 = t2,
                ChartValueName3 = t3,
                ChartValueName4 = t4,

                ChartView = new DonutChart
                {
                    Entries = new List<ChartEntry>
                    {
                        new ChartEntry(v1)
                        {
                            Label=t1,
                            Color=c1.ToSKColor(),
                            ValueLabel=t1,
                            TextColor=c1.ToSKColor(),
                            ValueLabelColor=c1.ToSKColor(),
                        },
                        new ChartEntry(v2)
                        {
                            Label=t2,
                            Color=c2.ToSKColor(),
                            ValueLabel=t2,
                            TextColor=c2.ToSKColor(),
                            ValueLabelColor=c2.ToSKColor(),
                        },
                        new ChartEntry(v3)
                        {
                            Label=t3,
                            Color=c3.ToSKColor(),
                            ValueLabel=t3,
                            TextColor=c3.ToSKColor(),
                            ValueLabelColor=c3.ToSKColor(),
                        },
                        new ChartEntry(v4)
                        {
                            Label=t4,
                            Color=c4.ToSKColor(),
                            ValueLabel=t4,
                            TextColor=c4  .ToSKColor()  ,
                            ValueLabelColor=c4.ToSKColor(),
                        }
                    },
                    IsAnimated = true,
                    AnimationDuration = TimeSpan.FromSeconds(3),
                    LabelMode = LabelMode.None,
                    GraphPosition = GraphPosition.Center,
                    BackgroundColor = SKColors.Transparent
                }
            });
            #endregion
            #region Günlük Satış Chart
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems()
            {
                Name = "Günlük Satış",
                View = "Chart",
                ChartValue1 = v1,
                ChartValue2 = v2,
                ChartValue3 = v3,
                ChartValue4 = v4,
                ChartValueColor1 = c1,
                ChartValueColor2 = c2,
                ChartValueColor3 = c3,
                ChartValueColor4 = c4,
                ChartValueName1 = t1,
                ChartValueName2 = t2,
                ChartValueName3 = t3,
                ChartValueName4 = t4,

                ChartView = new DonutChart
                {
                    Entries = new List<ChartEntry>
                    {
                        new ChartEntry(v1)
                        {
                            Label=t1,
                            Color=c1.ToSKColor(),
                            ValueLabel=t1,
                            TextColor=c1.ToSKColor(),
                            ValueLabelColor=c1.ToSKColor(),
                        },
                        new ChartEntry(v2)
                        {
                            Label=t2,
                            Color=c2.ToSKColor(),
                            ValueLabel=t2,
                            TextColor=c2.ToSKColor(),
                            ValueLabelColor=c2.ToSKColor(),
                        },
                        new ChartEntry(v3)
                        {
                            Label=t3,
                            Color=c3.ToSKColor(),
                            ValueLabel=t3,
                            TextColor=c3.ToSKColor(),
                            ValueLabelColor=c3.ToSKColor(),
                        },
                        new ChartEntry(v4)
                        {
                            Label=t4,
                            Color=c4.ToSKColor(),
                            ValueLabel=t4,
                            TextColor=c4  .ToSKColor()  ,
                            ValueLabelColor=c4.ToSKColor(),
                        }
                    },
                    IsAnimated = true,
                    AnimationDuration = TimeSpan.FromSeconds(3),
                    LabelMode = LabelMode.None,
                    GraphPosition = GraphPosition.Center,
                    BackgroundColor = SKColors.Transparent
                }
            });
            #endregion
            #region Günlük Satış Chart
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems()
            {
                Name = "Günlük Satış",
                View = "Chart",
                ChartValue1 = v1,
                ChartValue2 = v2,
                ChartValue3 = v3,
                ChartValue4 = v4,
                ChartValueColor1 = c1,
                ChartValueColor2 = c2,
                ChartValueColor3 = c3,
                ChartValueColor4 = c4,
                ChartValueName1 = t1,
                ChartValueName2 = t2,
                ChartValueName3 = t3,
                ChartValueName4 = t4,

                ChartView = new DonutChart
                {
                    Entries = new List<ChartEntry>
                    {
                        new ChartEntry(v1)
                        {
                            Label=t1,
                            Color=c1.ToSKColor(),
                            ValueLabel=t1,
                            TextColor=c1.ToSKColor(),
                            ValueLabelColor=c1.ToSKColor(),
                        },
                        new ChartEntry(v2)
                        {
                            Label=t2,
                            Color=c2.ToSKColor(),
                            ValueLabel=t2,
                            TextColor=c2.ToSKColor(),
                            ValueLabelColor=c2.ToSKColor(),
                        },
                        new ChartEntry(v3)
                        {
                            Label=t3,
                            Color=c3.ToSKColor(),
                            ValueLabel=t3,
                            TextColor=c3.ToSKColor(),
                            ValueLabelColor=c3.ToSKColor(),
                        },
                        new ChartEntry(v4)
                        {
                            Label=t4,
                            Color=c4.ToSKColor(),
                            ValueLabel=t4,
                            TextColor=c4  .ToSKColor()  ,
                            ValueLabelColor=c4.ToSKColor(),
                        }
                    },
                    IsAnimated = true,
                    AnimationDuration = TimeSpan.FromSeconds(3),
                    LabelMode = LabelMode.None,
                    GraphPosition = GraphPosition.Center,
                    BackgroundColor = SKColors.Transparent
                }
            });
            #endregion
            #region Günlük Satış Chart
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems()
            {
                Name = "Günlük Satış",
                View = "Chart",
                ChartValue1 = v1,
                ChartValue2 = v2,
                ChartValue3 = v3,
                ChartValue4 = v4,
                ChartValueColor1 = c1,
                ChartValueColor2 = c2,
                ChartValueColor3 = c3,
                ChartValueColor4 = c4,
                ChartValueName1 = t1,
                ChartValueName2 = t2,
                ChartValueName3 = t3,
                ChartValueName4 = t4,

                ChartView = new DonutChart
                {
                    Entries = new List<ChartEntry>
                    {
                        new ChartEntry(v1)
                        {
                            Label=t1,
                            Color=c1.ToSKColor(),
                            ValueLabel=t1,
                            TextColor=c1.ToSKColor(),
                            ValueLabelColor=c1.ToSKColor(),
                        },
                        new ChartEntry(v2)
                        {
                            Label=t2,
                            Color=c2.ToSKColor(),
                            ValueLabel=t2,
                            TextColor=c2.ToSKColor(),
                            ValueLabelColor=c2.ToSKColor(),
                        },
                        new ChartEntry(v3)
                        {
                            Label=t3,
                            Color=c3.ToSKColor(),
                            ValueLabel=t3,
                            TextColor=c3.ToSKColor(),
                            ValueLabelColor=c3.ToSKColor(),
                        },
                        new ChartEntry(v4)
                        {
                            Label=t4,
                            Color=c4.ToSKColor(),
                            ValueLabel=t4,
                            TextColor=c4  .ToSKColor()  ,
                            ValueLabelColor=c4.ToSKColor(),
                        }
                    },
                    IsAnimated = true,
                    AnimationDuration = TimeSpan.FromSeconds(3),
                    LabelMode = LabelMode.None,
                    GraphPosition = GraphPosition.Center,
                    BackgroundColor = SKColors.Transparent
                }
            });
            #endregion

            #endregion
            MainPageCarouselView.ItemsSource = _mainContentPageViewItemsSource;

            getCharts();
        }

        void getCharts()
        {

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
    }
}