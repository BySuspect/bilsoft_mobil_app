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
using Org.Apache.Http.Conn;
using Timer = System.Timers.Timer;
using static Android.Content.ClipData;

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


            //Kasa Bakiyeleri
            #region Kasa Bakiyeleri
            var _kasaList = new ObservableCollection<KasaBakiyeListeVeriler>();
            var KasaListItems = await getKasaList();

            foreach (var item in KasaListItems)
            {
                _kasaList.Add(new KasaBakiyeListeVeriler
                {
                    sira = item.sira,
                    Kasa = item.Kasa,
                    KasaBakiye = item.KasaBakiye,
                });
            }

            MainContentPageViewItems kasaBakiyeView = new MainContentPageViewItems()
            {
                Name = "Kasa Bakiyeleri",
                View = "Kasa",
                KasaBakiyeleriList = _kasaList,
            };

            _mainContentPageViewItemsSource.Add(kasaBakiyeView);


            #endregion

            //Yuvarlak Chart olan sayfalar
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

            //Ana navigasyon görünümü
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems() { Name = "Menü", View = "Main" });

            //7 günlük tablolar
            #region 7 Gun Grafik Charts

            var CiftGrafikchartVerileriList = await get7gunGrafikItems();

            Color grafikC1 = Color.FromHex("#00FF00"),
                  grafikC2 = Color.FromHex("#FF0000");

            var TekGrafikchartVerileriList = await get7gunSatisVeriler();

            //7 günlük satış tablo
            _mainContentPageViewItemsSource.Add(new MainContentPageViewItems()
            {
                Name = TekGrafikchartVerileriList.Name,
                View = "tekgrafik",
                ChartView = new LineChart
                {
                    AnimationDuration = TimeSpan.FromSeconds(3),
                    EnableYFadeOutGradient = true,
                    IsAnimated = true,
                    LabelTextSize = 30,
                    LabelColor = SKColors.White,
                    BackgroundColor = SKColors.Transparent,
                    LineMode = LineMode.Straight,
                    PointMode = PointMode.None,
                    ValueLabelOrientation = Microcharts.Orientation.Horizontal,
                    Entries = new[]
                    {
                        new ChartEntry(TekGrafikchartVerileriList.GValue1)
                        {
                            Label = TekGrafikchartVerileriList.Label1,
                            ValueLabel = TekGrafikchartVerileriList.GValue1.ToString(),
                            ValueLabelColor=grafikC1.ToSKColor(),
                            TextColor=SKColors.White,
                            Color = grafikC1.ToSKColor()
                        },
                        new ChartEntry(TekGrafikchartVerileriList.GValue2)
                        {
                            Label = TekGrafikchartVerileriList.Label2,
                            ValueLabel = TekGrafikchartVerileriList.GValue2.ToString(),
                            ValueLabelColor=grafikC1.ToSKColor(),
                            TextColor=SKColors.White,
                            Color = grafikC1.ToSKColor()
                        },
                        new ChartEntry(TekGrafikchartVerileriList.GValue3)
                        {
                            Label = TekGrafikchartVerileriList.Label3,
                            ValueLabel = TekGrafikchartVerileriList.GValue3.ToString(),
                            ValueLabelColor=grafikC1.ToSKColor(),
                            TextColor=SKColors.White,
                            Color = grafikC1.ToSKColor()
                        },
                        new ChartEntry(TekGrafikchartVerileriList.GValue4)
                        {
                            Label = TekGrafikchartVerileriList.Label4,
                            ValueLabel = TekGrafikchartVerileriList.GValue4.ToString(),
                            ValueLabelColor=grafikC1.ToSKColor(),
                            TextColor=SKColors.White,
                            Color = grafikC1.ToSKColor()
                        },
                        new ChartEntry(TekGrafikchartVerileriList.GValue5)
                        {
                            Label = TekGrafikchartVerileriList.Label5,
                            ValueLabel = TekGrafikchartVerileriList.GValue5.ToString(),
                            ValueLabelColor=grafikC1.ToSKColor(),
                            TextColor=SKColors.White,
                            Color = grafikC1.ToSKColor()
                        },
                        new ChartEntry(TekGrafikchartVerileriList.GValue6)
                        {
                            Label = TekGrafikchartVerileriList.Label6,
                            ValueLabel = TekGrafikchartVerileriList.GValue6.ToString(),
                            ValueLabelColor=grafikC1.ToSKColor(),
                            TextColor=SKColors.White,
                            Color = grafikC1.ToSKColor()
                        },
                        new ChartEntry(TekGrafikchartVerileriList.GValue7)
                        {
                            Label = TekGrafikchartVerileriList.Label7,
                            ValueLabel = TekGrafikchartVerileriList.GValue7.ToString(),
                            ValueLabelColor=grafikC1.ToSKColor(),
                            TextColor=SKColors.White,
                            Color = grafikC1.ToSKColor()
                        }
                    },
                },
            });

            //7 günlük çift tablolar
            foreach (var item in CiftGrafikchartVerileriList)
            {
                _mainContentPageViewItemsSource.Add(new MainContentPageViewItems()
                {
                    Name = item.Name,
                    View = "ciftGrafik",
                    GirisLabel = item.Glabel,
                    CikisLabel = item.Clabel,
                    Bool1 = item.Bool1,
                    BankaListeSource = item.BankaListeSource,
                    BankaPickerIndex = 0,
                    ChartView = new LineChart
                    {
                        AnimationDuration = TimeSpan.FromSeconds(3),
                        EnableYFadeOutGradient = true,
                        IsAnimated = true,
                        LabelTextSize = 30,
                        LabelColor = SKColors.White,
                        BackgroundColor = SKColors.Transparent,
                        LineMode = LineMode.Straight,
                        PointMode = PointMode.None,
                        ValueLabelOrientation = Microcharts.Orientation.Horizontal,
                        Entries = new[]
                        {
                            new ChartEntry(item.GValue1)
                            {
                                Label = item.Label1,
                                ValueLabel = item.GValue1.ToString(),
                                ValueLabelColor=grafikC1.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC1.ToSKColor()
                            },
                            new ChartEntry(item.GValue2)
                            {
                                Label = item.Label2,
                                ValueLabel = item.GValue2.ToString(),
                                ValueLabelColor=grafikC1.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC1.ToSKColor()
                            },
                            new ChartEntry(item.GValue3)
                            {
                                Label = item.Label3,
                                ValueLabel = item.GValue3.ToString(),
                                ValueLabelColor=grafikC1.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC1.ToSKColor()
                            },
                            new ChartEntry(item.GValue4)
                            {
                                Label = item.Label4,
                                ValueLabel = item.GValue4.ToString(),
                                ValueLabelColor=grafikC1.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC1.ToSKColor()
                            },
                            new ChartEntry(item.GValue5)
                            {
                                Label = item.Label5,
                                ValueLabel = item.GValue5.ToString(),
                                ValueLabelColor=grafikC1.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC1.ToSKColor()
                            },
                            new ChartEntry(item.GValue6)
                            {
                                Label = item.Label6,
                                ValueLabel = item.GValue6.ToString(),
                                ValueLabelColor=grafikC1.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC1.ToSKColor()
                            },
                            new ChartEntry(item.GValue7)
                            {
                                Label = item.Label7,
                                ValueLabel = item.GValue7.ToString(),
                                ValueLabelColor=grafikC1.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC1.ToSKColor()
                            }
                        },
                    },
                    ChartView2 = new LineChart
                    {
                        AnimationDuration = TimeSpan.FromSeconds(3),
                        EnableYFadeOutGradient = true,
                        IsAnimated = true,
                        LabelTextSize = 30,
                        LabelColor = SKColors.White,
                        BackgroundColor = SKColors.Transparent,
                        LineMode = LineMode.Straight,
                        PointMode = PointMode.None,
                        ValueLabelOrientation = Microcharts.Orientation.Horizontal,
                        Entries = new[]
                        {
                            new ChartEntry(item.CValue1)
                            {
                                Label = item.Label1,
                                ValueLabel=item.CValue1.ToString(),
                                ValueLabelColor=grafikC2.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC2.ToSKColor()
                            },
                            new ChartEntry(item.CValue2)
                            {
                                Label = item.Label2,
                                ValueLabel=item.CValue2.ToString(),
                                ValueLabelColor=grafikC2.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC2.ToSKColor()
                            },
                            new ChartEntry(item.CValue3)
                            {
                                Label = item.Label3,
                                ValueLabel=item.CValue3.ToString(),
                                ValueLabelColor=grafikC2.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC2.ToSKColor()
                            },
                            new ChartEntry(item.CValue4)
                            {
                                Label = item.Label4,
                                ValueLabel=item.CValue4.ToString(),
                                ValueLabelColor=grafikC2.ToSKColor(),
                                TextColor=SKColors.Red,
                                Color = grafikC2.ToSKColor()
                            },
                            new ChartEntry(item.CValue5)
                            {
                                Label = item.Label5,
                                ValueLabel=item.CValue5.ToString(),
                                ValueLabelColor=grafikC2.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC2.ToSKColor()
                            },
                            new ChartEntry(item.CValue6)
                            {
                                Label = item.Label6,
                                ValueLabel=item.CValue6.ToString(),
                                ValueLabelColor=grafikC2.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC2.ToSKColor()
                            },
                            new ChartEntry(item.CValue7)
                            {
                                Label = item.Label7,
                                ValueLabel=item.CValue7.ToString(),
                                ValueLabelColor=grafikC2.ToSKColor(),
                                TextColor=SKColors.White,
                                Color = grafikC2.ToSKColor()
                            }
                        },
                    }
                });
            }

            #endregion

            //Banka Bakiyeleri
            #region Banka Bakiyeleri
            var _bankaList = new ObservableCollection<BankListVeriler>();
            var bankaListItems = await getBankaList();

            foreach (var item in bankaListItems)
            {
                _bankaList.Add(new BankListVeriler
                {
                    sira = item.sira,
                    Banka_Hesap = item.Banka_Hesap,
                    HesapNo = item.HesapNo,
                    HesapBakiye = item.HesapBakiye,
                });
            }

            MainContentPageViewItems bankaBakiyeView = new MainContentPageViewItems()
            {
                Name = "Banka Bakiyeleri",
                View = "Banka",
                BankaBakiyeleriList = _bankaList,
            };

            _mainContentPageViewItemsSource.Add(bankaBakiyeView);
            #endregion

            MainPageCarouselView.ItemsSource = _mainContentPageViewItemsSource;

            //Bozuluyor
            MainPageCarouselView.Position = 5;

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
        async Task<List<_7gunGrafikItems>> get7gunGrafikItems()
        {
            return new List<_7gunGrafikItems>
            {
                new _7gunGrafikItems
                {
                    Name="7 Günlük Vadesi Gelecek İşlemler",
                    Glabel="Tahsilat",
                    Clabel="Ödeme",
                    Bool1=false,

                    Label1 = "17.08.2022",
                    GValue1 = 12000,
                    CValue1 = 50,
                    Label2 = "16.08.2022",
                    GValue2 = 2640,
                    CValue2 = 125,
                    Label3 = "16.08.2022",
                    GValue3 = 0,
                    CValue3 = 0,
                    Label4 = "16.08.2022",
                    GValue4 = 0,
                    CValue4 = 0,
                    Label5 = "16.08.2022",
                    GValue5 = 4555,
                    CValue5 = 430,
                    Label6 = "16.08.2022",
                    GValue6 = 0,
                    CValue6 = 0,
                    Label7 = "16.08.2022",
                    GValue7 = 2350,
                    CValue7 = 534,
                },
                new _7gunGrafikItems
                {
                    Name="7 Günlük Banka Haraketleri",
                    Glabel="Giriş",
                    Clabel="Çıkış",
                    Bool1=true,
                    BankaListeSource = new List<string>
                    {
                        "Tümü",
                        "Ziraat Bankası",
                        "Garanti Bankası",
                        "TC İş Bankası"
                    },

                    Label1 = "17.08.2022",
                    GValue1 = 12000,
                    CValue1 = 50,
                    Label2 = "16.08.2022",
                    GValue2 = 2640,
                    CValue2 = 125,
                    Label3 = "16.08.2022",
                    GValue3 = 0,
                    CValue3 = 0,
                    Label4 = "16.08.2022",
                    GValue4 = 0,
                    CValue4 = 0,
                    Label5 = "16.08.2022",
                    GValue5 = 4555,
                    CValue5 = 430,
                    Label6 = "16.08.2022",
                    GValue6 = 0,
                    CValue6 = 0,
                    Label7 = "16.08.2022",
                    GValue7 = 2350,
                    CValue7 = 534,
                },
                new _7gunGrafikItems
                {
                    Name="7 Günlük Kasa Haraketleri",
                    Glabel="Giriş",
                    Clabel="Çıkış",
                    Bool1=false,

                    Label1 = "17.08.2022",
                    GValue1 = 12000,
                    CValue1 = 50,
                    Label2 = "16.08.2022",
                    GValue2 = 2640,
                    CValue2 = 125,
                    Label3 = "16.08.2022",
                    GValue3 = 0,
                    CValue3 = 0,
                    Label4 = "16.08.2022",
                    GValue4 = 0,
                    CValue4 = 0,
                    Label5 = "16.08.2022",
                    GValue5 = 4555,
                    CValue5 = 430,
                    Label6 = "16.08.2022",
                    GValue6 = 0,
                    CValue6 = 0,
                    Label7 = "16.08.2022",
                    GValue7 = 2350,
                    CValue7 = 534,
                },
            };
        }
        async Task<_7gunGrafikItems> get7gunSatisVeriler()
        {
            return new _7gunGrafikItems
            {
                Name = "7 Günlük Satış",

                Label1 = "17.08.2022",
                GValue1 = 12000,
                Label2 = "16.08.2022",
                GValue2 = 2640,
                Label3 = "16.08.2022",
                GValue3 = 0,
                Label4 = "16.08.2022",
                GValue4 = 0,
                Label5 = "16.08.2022",
                GValue5 = 4555,
                Label6 = "16.08.2022",
                GValue6 = 0,
                Label7 = "16.08.2022",
                GValue7 = 2350,
            };
        }
        async Task<List<BankListVeriler>> getBankaList()
        {
            return new List<BankListVeriler>
            {
                new BankListVeriler
                {
                    sira=1,
                    Banka_Hesap="Ziraat Bankası",
                    HesapNo="33325612532623",
                    HesapBakiye=124125125,
                },
                new BankListVeriler
                {
                    sira=2,
                    Banka_Hesap="Garanti Bankası",
                    HesapNo="33325612532623",
                    HesapBakiye=124125125,
                },
                new BankListVeriler
                {
                    sira=3,
                    Banka_Hesap="TC İş Bankası",
                    HesapNo="33325612532623",
                    HesapBakiye=124125125,
                },
            };
        }
        async Task<List<KasaBakiyeListeVeriler>> getKasaList()
        {
            return new List<KasaBakiyeListeVeriler>
            {
                new KasaBakiyeListeVeriler
                {
                    sira=1,
                    Kasa="Varsayılan Kasa",
                    KasaBakiye=124125125,
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
            testedt.Text = "";
            DateTime[] last7Days = Enumerable.Range(0, 7).Select(i => DateTime.Now.Date.AddDays(-i)).ToArray();

            foreach (var day in last7Days)
                Console.WriteLine($"{day:yyyy-MM-dd}"); // Any manipulations with days go here
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
    public class _7gunGrafikItems
    {
        public string Name { get; set; }
        public string Glabel { get; set; }
        public string Clabel { get; set; }
        public int GValue1 { get; set; }
        public int CValue1 { get; set; }
        public string Label1 { get; set; }
        public int GValue2 { get; set; }
        public int CValue2 { get; set; }
        public string Label2 { get; set; }
        public int GValue3 { get; set; }
        public int CValue3 { get; set; }
        public string Label3 { get; set; }
        public int GValue4 { get; set; }
        public int CValue4 { get; set; }
        public string Label4 { get; set; }
        public int GValue5 { get; set; }
        public int CValue5 { get; set; }
        public string Label5 { get; set; }
        public int GValue6 { get; set; }
        public int CValue6 { get; set; }
        public string Label6 { get; set; }
        public int GValue7 { get; set; }
        public int CValue7 { get; set; }
        public string Label7 { get; set; }


        #region opsiyonel
        public bool Bool1 { get; set; }
        public List<string> BankaListeSource { get; set; }
        #endregion
    }
}