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

namespace bilsoft_mobil_app.Pages
{

    /*/ Yapılacaklar
    * Iconlar yennilenicek
    * Yan menu tasarım yenilenicek o menu ana sayfaya alınıcak
    * 
    /*/
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
        string mod = null, donemYili = null;

        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);

        public Color KrediKartiColor { get; set; } = Color.FromHex(AppThemeColors._chartKrediKartiColor);
        public Color NakitColor { get; set; } = Color.FromHex(AppThemeColors._chartNakitColor);
        public Color AcikHesapColor { get; set; } = Color.FromHex(AppThemeColors._chartAcikHesapColor);
        public Color CekColor { get; set; } = Color.FromHex(AppThemeColors._chartCekColor);
        public Color _7GunVadeTahsilatColor { get; set; } = Color.FromHex(AppThemeColors._7GunVadeTahsilatGColor);
        public Color _7GunVadeOdemeColor { get; set; } = Color.FromHex(AppThemeColors._7GunVadeOdemeGColor);
        public Color _BankaHaraketGirisColor { get; set; } = Color.FromHex(AppThemeColors._7GunBankaHaraketGirisColor);
        public Color _BankaHaraketCikisColor { get; set; } = Color.FromHex(AppThemeColors._7GunBankaHaraketCikisColor);
        public Color _KasaGirisColor { get; set; } = Color.FromHex(AppThemeColors._7GunlukKasaGirisColor);
        public Color _KasaCikisColor { get; set; } = Color.FromHex(AppThemeColors._7GunlukKasaCikisColor);
        #endregion

        #region Günlük Satış Tablo Verileri
        List<ChartEntry> entriesGunlukSatis = new List<ChartEntry>();
        double GSNakit = 525.00f;
        double GSKrediKarti = 12179.50f;
        double GSAcikHesap = 734.50f;
        #endregion

        #region Günlük Alış Tablo Verileri
        List<ChartEntry> entriesGunlukAlis = new List<ChartEntry>();
        double GANakit = 22324.50f;
        double GAKrediKarti = 5253.20f;
        double GAAcikHesap = 2041.50f;
        #endregion

        #region Günlük Tahsilat Tablo Verileri
        List<ChartEntry> entriesGunlukTahsilat = new List<ChartEntry>();
        double GTNakit = 15240.00f;
        double GTKrediKarti = 1225.00f;
        double GTCek = 132452.00f;
        #endregion

        #region Günlük Ödeme Tablo Verileri
        List<ChartEntry> entriesGunlukOdeme = new List<ChartEntry>();
        double GONakit = 130242.00f;
        double GOKrediKarti = 104450.50f;
        double GOCek = 14821.00f;
        #endregion

        #region 7Günlük Tahsilat Tablo Verileri
        List<ChartEntry> entries7GunlukTahsilat = new List<ChartEntry>();
        List<ChartEntry> entries7GunlukVadeGelen = new List<ChartEntry>();
        #endregion

        #region 7 Günlük Satış Tablo Verileri
        double _7GunSatisGMoney1, _7GunSatisGMoney2, _7GunSatisGMoney3, _7GunSatisGMoney4, _7GunSatisGMoney5, _7GunSatisGMoney6, _7GunSatisGMoney7;
        string _7GunSatisGDay1, _7GunSatisGDay2, _7GunSatisGDay3, _7GunSatisGDay4, _7GunSatisGDay5, _7GunSatisGDay6, _7GunSatisGDay7;
        #endregion

        #region 7 Günlük Vadesi Gelecek İşlemler Tablo Verileri
        double _7GunVadeOdemeGMoney1, _7GunVadeOdemeGMoney2, _7GunVadeOdemeGMoney3, _7GunVadeOdemeGMoney4, _7GunVadeOdemeGMoney5, _7GunVadeOdemeGMoney6, _7GunVadeOdemeGMoney7;
        double _7GunVadeTahsilatGMoney1, _7GunVadeTahsilatGMoney2, _7GunVadeTahsilatGMoney3, _7GunVadeTahsilatGMoney4, _7GunVadeTahsilatGMoney5, _7GunVadeTahsilatGMoney6, _7GunVadeTahsilatGMoney7;
        string _7GunVadeGDay1, _7GunVadeGDay2, _7GunVadeGDay3, _7GunVadeGDay4, _7GunVadeGDay5, _7GunVadeGDay6, _7GunVadeGDay7;
        #endregion

        #region 7 Günlük Banka Haraket Veriler
        List<ChartEntry> entries7gunbankaharaket = new List<ChartEntry>();
        double _7GunBankaHaraketGiris1, _7GunBankaHaraketGiris2, _7GunBankaHaraketGiris3, _7GunBankaHaraketGiris4, _7GunBankaHaraketGiris5, _7GunBankaHaraketGiris6, _7GunBankaHaraketGiris7;
        double _7GunBankaHaraketCikis1, _7GunBankaHaraketCikis2, _7GunBankaHaraketCikis3, _7GunBankaHaraketCikis4, _7GunBankaHaraketCikis5, _7GunBankaHaraketCikis6, _7GunBankaHaraketCikis7;
        string _7GunBankaHaraketDay1, _7GunBankaHaraketDay2, _7GunBankaHaraketDay3, _7GunBankaHaraketDay4, _7GunBankaHaraketDay5, _7GunBankaHaraketDay6, _7GunBankaHaraketDay7;
        string _7GunBankaHaraketBanka = "Tümü";
        #endregion

        #region 7 Günlük Kasa Hareket verileri
        List<ChartEntry> entries7GunlukKasaHareketleri = new List<ChartEntry>();
        double _7GunlukKasaGirisMoney1, _7GunlukKasaGirisMoney2, _7GunlukKasaGirisMoney3, _7GunlukKasaGirisMoney4, _7GunlukKasaGirisMoney5, _7GunlukKasaGirisMoney6, _7GunlukKasaGirisMoney7;
        double _7GunlukKasaCikisMoney1, _7GunlukKasaCikisMoney2, _7GunlukKasaCikisMoney3, _7GunlukKasaCikisMoney4, _7GunlukKasaCikisMoney5, _7GunlukKasaCikisMoney6, _7GunlukKasaCikisMoney7;
        string _7GunKasaHareketDay1, _7GunKasaHareketDay2, _7GunKasaHareketDay3, _7GunKasaHareketDay4, _7GunKasaHareketDay5, _7GunKasaHareketDay6, _7GunKasaHareketDay7;
        #endregion

        #region Kasa Bakiyeleri Liste Veriler
        List<BankListVeriler> BankaBakiyelerListe = new List<BankListVeriler>();
        #endregion

        #region Kasa Bakiyeleri Liste Veriler
        List<KasaBakiyeListeVeriler> KasaBakiyelerListe = new List<KasaBakiyeListeVeriler>();
        #endregion

        #region Süresi Geçen Hatırlatma Veriler
        List<SuresiGecenListeProps> SuresiGecenHatirlatmalarListe = new List<SuresiGecenListeProps>();
        #endregion

        #region popUp Menu Veriler
        UInt16 _popuptimer = 200;
        string openedPopUp;
        #endregion

        public MainContentPage()
        {
            BindingContext = this;
            InitializeComponent();
            #region start
            try
            {
                donemYili = APIHelper.secilenlogindonemYil;
                mod = APIHelper.loginMod;

                #region setDemo
                setDemo7gunlukSatisG();
                setDemo7gunlukVadeG();
                SetDemo7GunBankaHaraket();
                Set7GunKasaHaraket();
                createChart();
                #endregion

                #region Günlük Satış Chart
                GunlukSatisChart.Chart = new PieChart { Entries = entriesGunlukSatis, IsAnimated = true, AnimationDuration = TimeSpan.FromSeconds(3), LabelMode = LabelMode.None, GraphPosition = GraphPosition.Center, BackgroundColor = SKColors.Transparent };
                lblGunlukSatisNakit.Text = GSNakit.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukSatisKredi.Text = GSKrediKarti.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukSatisAcikHesap.Text = GSAcikHesap.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                #endregion

                #region Günlük Alış Chart
                GunlukAlisChart.Chart = new PieChart { Entries = entriesGunlukAlis, IsAnimated = true, AnimationDuration = TimeSpan.FromSeconds(3), LabelMode = LabelMode.None, GraphPosition = GraphPosition.Center, BackgroundColor = SKColors.Transparent };
                lblGunlukAlisNakit.Text = GANakit.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukAlisKredi.Text = GAKrediKarti.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukAlisAcikHesap.Text = GAAcikHesap.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                #endregion

                #region Günlük Tahsilat Chart
                GunlukTahsilatChart.Chart = new PieChart { Entries = entriesGunlukTahsilat, IsAnimated = true, AnimationDuration = TimeSpan.FromSeconds(3), LabelMode = LabelMode.None, GraphPosition = GraphPosition.Center, BackgroundColor = SKColors.Transparent };
                lblGunlukTahsilatNakit.Text = GTNakit.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukTahsilatKredi.Text = GTKrediKarti.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukTahsilatCek.Text = GTCek.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                #endregion

                #region Günlük Ödeme Chart
                GunlukOdemeChart.Chart = new PieChart { Entries = entriesGunlukOdeme, IsAnimated = true, AnimationDuration = TimeSpan.FromSeconds(3), LabelMode = LabelMode.None, GraphPosition = GraphPosition.AutoFill, BackgroundColor = SKColors.Transparent };
                lblGunlukOdemeNakit.Text = GONakit.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukOdemeKredi.Text = GOKrediKarti.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                lblGunlukOdemeCek.Text = GOCek.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"));
                #endregion

                #region 7 Günlük Tablolar
                _7GunlukSatisGraph.Chart = new PointChart { Entries = entries7GunlukTahsilat, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse(AppThemeColors._textColor), PointAreaAlpha = 255, PointMode = PointMode.Circle, AnimationDuration = TimeSpan.FromSeconds(3), Margin = 30, BackgroundColor = SKColors.Transparent };
                _7GunlukVadeGelenGraph.Chart = new PointChart { Entries = entries7GunlukVadeGelen, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse(AppThemeColors._textColor), PointAreaAlpha = 255, PointMode = PointMode.Circle, AnimationDuration = TimeSpan.FromSeconds(3), BackgroundColor = SKColors.Transparent };
                #endregion

                #region 7 Günlük Banka Haraket Chart
                _7GunlukBankaHaraketGraph.Chart = new LineChart { Entries = entries7gunbankaharaket, IsAnimated = true, LabelTextSize = 30, LabelColor = SKColor.Parse(AppThemeColors._textColor), PointAreaAlpha = 255, AnimationDuration = TimeSpan.FromSeconds(3), Margin = 30, LineSize = 5, PointSize = 30, EnableYFadeOutGradient = false,BackgroundColor=SKColors.Transparent };
                _7gunlukBankaHaraketPicker.ItemsSource = new List<string> { "Ziraat Bankası", "Garanti Bankası", "İş Bankası" };
                #endregion

                #region 7 Günlük Kasa Haraket Chart
                _7GunlukKasaHareketleriChart.Chart = new PointChart { Entries = entries7GunlukKasaHareketleri, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse(AppThemeColors._textColor), PointAreaAlpha = 255, PointMode = PointMode.Circle, AnimationDuration = TimeSpan.FromSeconds(3), BackgroundColor = SKColors.Transparent };
                #endregion

                #region Süresi Geçen Hatırlatma Check
                SuresiGecenHatirlatmaView.IsVisible = true;
                btnpopupMenuReturnBackground.IsVisible = true;
                SuresiGecenHatirlatmalarListeAdder();
                foreach (var item in SuresiGecenHatirlatmalarListe)
                {
                    SuresiGecenHatirlatmalarViewAdder(item.AdSoyad, item.Firma, item.Aciklama);
                }
                #endregion

                #region Banka Bakiye Liste Check
                BankaBakiyelerListe.Add(new BankListVeriler { sira = 0, Banka_Hesap = "Name1", HesapNo = "21312412", HesapBakiye = 23543654.22 });
                BankaBakiyelerListe.Add(new BankListVeriler { sira = 0, Banka_Hesap = "Name2", HesapNo = "23532623", HesapBakiye = 7643654.50 });
                BankaBakiyelerListe.Add(new BankListVeriler { sira = 0, Banka_Hesap = "Name3", HesapNo = "457457", HesapBakiye = 23554.00 });
                BankaBakiyelerListe.Add(new BankListVeriler { sira = 0, Banka_Hesap = "Name4", HesapNo = "23423523", HesapBakiye = 3432432.56 });
                for (int i = 0; i < BankaBakiyelerListe.Count; i++)
                {
                    createBankListProp(i);
                }
                #endregion

                #region Kasa Bakiye Liste Check
                KasaBakiyelerListe.Add(new KasaBakiyeListeVeriler { sira = 0, Kasa = "Name1", KasaBakiye = 23543654.22 });
                KasaBakiyelerListe.Add(new KasaBakiyeListeVeriler { sira = 1, Kasa = "Name2", KasaBakiye = 7643654.50 });
                KasaBakiyelerListe.Add(new KasaBakiyeListeVeriler { sira = 2, Kasa = "Name3",  KasaBakiye = 23554.00 });
                KasaBakiyelerListe.Add(new KasaBakiyeListeVeriler { sira = 3, Kasa = "Name4", KasaBakiye = 3432432.56 });
                for (int i = 0; i < KasaBakiyelerListe.Count; i++)
                {
                    createKasaListProp(i);
                }
                #endregion

            }
            catch (Exception e)
            {
                DisplayAlert("", e.Message, "ok");
            }
            #endregion
        }

        #region Kasa Bakiye Liste
        async Task createKasaListProp(int sira)
        {
            gridKasaBakiye.Children.Add(new Label
            {
                Text = (sira + 1).ToString(),
                FontSize = 12,
                Margin = new Thickness(-5, 5, 5, 5),
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 0, sira + 1);
            gridKasaBakiye.Children.Add(new Label
            {
                Text = KasaBakiyelerListe[sira].Kasa,
                FontSize = 12,
                Margin = new Thickness(-70, 5, 5, 5),
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 1, sira + 1);
            gridKasaBakiye.Children.Add(new Label
            {
                Text = KasaBakiyelerListe[sira].KasaBakiye.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                FontSize = 12,
                Margin = new Thickness(-20, 5, 5, -5),
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Padding = new Thickness(5),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor=Color.FromHex("#BA0c9100")
            }, 2, sira + 1);
            gridKasaBakiye.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Green,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(-10, 0)
            }, 0, sira + 1);
            gridKasaBakiye.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Green,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(-10, 0)
            }, 1, sira + 1);
            gridKasaBakiye.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Green,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(-10, 0)
            }, 2, sira + 1);

        }
        #endregion

        #region Banka Bakieler Liste
        async Task createBankListProp(int sira)
        {
            gridBankaList.Children.Add(new Label
            {
                Text = (sira + 1).ToString(),
                FontSize = 12,
                Margin = new Thickness(-5, 0, 5, 0),
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 0, sira + 1);
            gridBankaList.Children.Add(new Label
            {
                Text = BankaBakiyelerListe[sira].Banka_Hesap,
                FontSize = 12,
                Margin = new Thickness(-70, 0, 5, 0),
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 1, sira + 1);
            gridBankaList.Children.Add(new Label
            {
                Text = BankaBakiyelerListe[sira].HesapNo,
                FontSize = 12,
                Margin = new Thickness(-30, 0, -10, 0),
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 2, sira + 1);
            gridBankaList.Children.Add(new Label
            {
                Text = BankaBakiyelerListe[sira].HesapBakiye.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                FontSize = 12,
                Margin = new Thickness(-10, 0, -10, 0),
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            }, 3, sira + 1);
            gridBankaList.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Green,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(-10, 0)
            },0, sira + 1);
            gridBankaList.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Green,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(-10, 0)
            },1, sira + 1);
            gridBankaList.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Green,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(-10, 0)
            },2, sira + 1);
            gridBankaList.Children.Add(new BoxView
            {
                HeightRequest = 1,
                Color = Color.Green,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(-10, 0)
            },3, sira + 1);

        }
        #endregion

        #region ChartVoidler
        void createChart()
        {
            try
            {
                #region Günlük Satış Entry
                entriesGunlukSatis = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(GSNakit)) {
                                Color = SKColor.Parse(AppThemeColors._chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GSKrediKarti)) {
                                Color = SKColor.Parse(AppThemeColors._chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GSAcikHesap)) {
                                Color = SKColor.Parse(AppThemeColors._chartAcikHesapColor)
                        }
                };
                #endregion

                #region Günlük Alış Entry
                entriesGunlukAlis = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(GANakit)) {
                                Color = SKColor.Parse(AppThemeColors._chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GAKrediKarti)) {
                                Color = SKColor.Parse(AppThemeColors._chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GAAcikHesap)) {
                                Color = SKColor.Parse(AppThemeColors._chartAcikHesapColor)
                        }
                };
                #endregion

                #region Günlük Tahsilat Entry
                entriesGunlukTahsilat = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(GTNakit)) {
                                Color = SKColor.Parse(AppThemeColors._chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GTKrediKarti)) {
                                Color = SKColor.Parse(AppThemeColors._chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GTCek)) {
                                Color = SKColor.Parse(AppThemeColors._chartCekColor)
                        }
                };
                #endregion

                #region Günlük Ödeme Entry
                entriesGunlukOdeme = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(GONakit)) {
                                Color = SKColor.Parse(AppThemeColors._chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GOKrediKarti)) {
                                Color = SKColor.Parse(AppThemeColors._chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GOCek)) {
                                Color = SKColor.Parse(AppThemeColors._chartCekColor)
                        }
                };
                #endregion

                #region 7 Günlük Satış Entry
                entries7GunlukTahsilat = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney1)) {
                                Color = SKColor.Parse(AppThemeColors._7GunSatisGColor),
                                        Label = _7GunSatisGDay1,
                                        ValueLabel = _7GunSatisGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._textColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney2)) {
                                Color = SKColor.Parse(AppThemeColors._7GunSatisGColor),
                                        Label = _7GunSatisGDay2,
                                        ValueLabel = _7GunSatisGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._textColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney3)) {
                                Color = SKColor.Parse(AppThemeColors._7GunSatisGColor),
                                        Label = _7GunSatisGDay3,
                                        ValueLabel = _7GunSatisGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney4)) {
                                Color = SKColor.Parse(AppThemeColors._7GunSatisGColor),
                                        Label = _7GunSatisGDay4,
                                        ValueLabel = _7GunSatisGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney5)) {
                                Color = SKColor.Parse(AppThemeColors._7GunSatisGColor),
                                        Label = _7GunSatisGDay5,
                                        ValueLabel = _7GunSatisGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney6)) {
                                Color = SKColor.Parse(AppThemeColors._7GunSatisGColor),
                                        Label = _7GunSatisGDay6,
                                        ValueLabel = _7GunSatisGMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney7)) {
                                Color = SKColor.Parse(AppThemeColors._7GunSatisGColor),
                                        Label = _7GunSatisGDay7,
                                        ValueLabel = _7GunSatisGMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._textColor)
                        }
                };
                #endregion

                #region 7 Günlük Vadesi Gelecek Entry
                entries7GunlukVadeGelen = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney1)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay1,
                                        ValueLabel = _7GunVadeTahsilatGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),                                        
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney1)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay1,
                                        ValueLabel = _7GunVadeOdemeGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney2)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay2,
                                        ValueLabel = _7GunVadeTahsilatGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney2)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay2,
                                        ValueLabel = _7GunVadeOdemeGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney3)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay3,
                                        ValueLabel = _7GunVadeTahsilatGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney3)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay3,
                                        ValueLabel = _7GunVadeOdemeGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney4)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay4,
                                        ValueLabel = _7GunVadeTahsilatGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney4)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay4,
                                        ValueLabel = _7GunVadeOdemeGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney5)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay5,
                                        ValueLabel = _7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney5)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay5,
                                        ValueLabel = _7GunVadeOdemeGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney6)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay6,
                                        ValueLabel = _7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney6)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay6,
                                        ValueLabel = _7GunVadeOdemeGMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney7)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay7,
                                        ValueLabel = _7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney7)) {
                                Color = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay7,
                                        ValueLabel = _7GunVadeOdemeGMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunVadeOdemeGColor)
                        }
                };
                #endregion

                #region 7 Günlük Banka Haraketleri Entry
                entries7gunbankaharaket = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris1)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay1,
                                        ValueLabel = _7GunBankaHaraketGiris1 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis1)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay1,
                                        ValueLabel = _7GunBankaHaraketCikis1 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris2)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay2,
                                        ValueLabel = _7GunBankaHaraketGiris2 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis2)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay2,
                                        ValueLabel = _7GunBankaHaraketCikis2 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris3)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay3,
                                        ValueLabel = _7GunBankaHaraketGiris3 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis3)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay3,
                                        ValueLabel = _7GunBankaHaraketCikis3 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris4)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay4,
                                        ValueLabel = _7GunBankaHaraketGiris4 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis4)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay4,
                                        ValueLabel = _7GunBankaHaraketCikis4 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris5)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay5,
                                        ValueLabel = _7GunBankaHaraketGiris5 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis5)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay5,
                                        ValueLabel = _7GunBankaHaraketCikis5 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris6)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay6,
                                        ValueLabel = _7GunBankaHaraketGiris6 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis6)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay6,
                                        ValueLabel = _7GunBankaHaraketCikis6 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris7)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay7,
                                        ValueLabel = _7GunBankaHaraketGiris7 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis7)) {
                                Color = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay7,
                                        ValueLabel = _7GunBankaHaraketCikis7 + "",
                                        ValueLabelColor = SKColor.Parse(AppThemeColors._7GunBankaHaraketCikisColor),
                        }

                };
                #endregion

                #region 7 Günlük Kasa Haraketleri Entry
                entries7GunlukKasaHareketleri = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney1)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay1,
                                        ValueLabel = _7GunlukKasaGirisMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney1)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay1,
                                        ValueLabel = _7GunlukKasaCikisMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney2)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay2,
                                        ValueLabel = _7GunlukKasaGirisMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney2)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay2,
                                        ValueLabel = _7GunlukKasaCikisMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney3)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay3,
                                        ValueLabel = _7GunlukKasaGirisMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney3)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay3,
                                        ValueLabel = _7GunlukKasaCikisMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney4)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay4,
                                        ValueLabel = _7GunlukKasaGirisMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney4)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay4,
                                        ValueLabel = _7GunlukKasaCikisMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney5)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay5,
                                        ValueLabel = _7GunlukKasaGirisMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney5)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay5,
                                        ValueLabel = _7GunlukKasaCikisMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney6)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay6,
                                        ValueLabel = _7GunlukKasaGirisMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney6)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay6,
                                        ValueLabel = _7GunlukKasaCikisMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney7)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay7,
                                        ValueLabel = _7GunlukKasaGirisMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney7)) {
                                Color = SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(AppThemeColors._7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay7,
                                        ValueLabel = _7GunlukKasaCikisMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        }

                };
                #endregion
            }
            catch (Exception e)
            {
                DisplayAlert("", e.Message, "ok");
            }
        }
        #region chart voidler
        void setDemo7gunlukVadeG()
        {
            _7GunVadeOdemeGMoney1 = 12421.00;
            _7GunVadeOdemeGMoney2 = 23521.24;
            _7GunVadeOdemeGMoney3 = 52321.64;
            _7GunVadeOdemeGMoney4 = 12421.45;
            _7GunVadeOdemeGMoney5 = 73021.45;
            _7GunVadeOdemeGMoney6 = 16821.46;
            _7GunVadeOdemeGMoney7 = 13021.43;

            _7GunVadeTahsilatGMoney1 = 124125.21;
            _7GunVadeTahsilatGMoney2 = 23525.23;
            _7GunVadeTahsilatGMoney3 = 523523.53;
            _7GunVadeTahsilatGMoney4 = 124423.52;
            _7GunVadeTahsilatGMoney5 = 73032.00;
            _7GunVadeTahsilatGMoney6 = 1685.00;
            _7GunVadeTahsilatGMoney7 = 1307.90;

            _7GunVadeGDay1 = "10.16.2022";
            _7GunVadeGDay2 = "11.16.2022";
            _7GunVadeGDay3 = "12.16.2022";
            _7GunVadeGDay4 = "13.16.2022";
            _7GunVadeGDay5 = "14.16.2022";
            _7GunVadeGDay6 = "15.16.2022";
            _7GunVadeGDay7 = "16.16.2022";
        }
        void setDemo7gunlukSatisG()
        {
            _7GunSatisGMoney1 = 0;
            _7GunSatisGMoney2 = 0;
            _7GunSatisGMoney3 = 0;
            _7GunSatisGMoney4 = 0;
            _7GunSatisGMoney5 = 730;
            _7GunSatisGMoney6 = 1685;
            _7GunSatisGMoney7 = 1307.90;

            _7GunSatisGDay1 = "10.16.2022";
            _7GunSatisGDay2 = "11.16.2022";
            _7GunSatisGDay3 = "12.16.2022";
            _7GunSatisGDay4 = "13.16.2022";
            _7GunSatisGDay5 = "14.16.2022";
            _7GunSatisGDay6 = "15.16.2022";
            _7GunSatisGDay7 = "16.16.2022";
        }
        void SetDemo7GunBankaHaraket()
        {
            switch (_7GunBankaHaraketBanka)
            {
                case "Tümü":
                    _7GunBankaHaraketGiris1 = 50;
                    _7GunBankaHaraketGiris2 = 250;
                    _7GunBankaHaraketGiris3 = 50;
                    _7GunBankaHaraketGiris4 = 10;
                    _7GunBankaHaraketGiris5 = 50;
                    _7GunBankaHaraketGiris6 = 20;
                    _7GunBankaHaraketGiris7 = 500;

                    _7GunBankaHaraketCikis1 = 20;
                    _7GunBankaHaraketCikis2 = 0;
                    _7GunBankaHaraketCikis3 = 24;
                    _7GunBankaHaraketCikis4 = 45;
                    _7GunBankaHaraketCikis5 = 0;
                    _7GunBankaHaraketCikis6 = 77;
                    _7GunBankaHaraketCikis7 = 200;
                    break;

                default:
                    break;
            }


            _7GunBankaHaraketDay1 = "10.16.2022";
            _7GunBankaHaraketDay2 = "11.16.2022";
            _7GunBankaHaraketDay3 = "12.16.2022";
            _7GunBankaHaraketDay4 = "13.16.2022";
            _7GunBankaHaraketDay5 = "14.16.2022";
            _7GunBankaHaraketDay6 = "15.16.2022";
            _7GunBankaHaraketDay7 = "16.16.2022";
        }
        void Set7GunKasaHaraket()
        {

            _7GunlukKasaGirisMoney1 = 2550.35;
            _7GunlukKasaGirisMoney2 = 2530;
            _7GunlukKasaGirisMoney3 = 50654.65;
            _7GunlukKasaGirisMoney4 = 10565;
            _7GunlukKasaGirisMoney5 = 50675.54;
            _7GunlukKasaGirisMoney6 = 2030;
            _7GunlukKasaGirisMoney7 = 50065.20;

            _7GunlukKasaCikisMoney1 = 20325;
            _7GunlukKasaCikisMoney2 = 6430;
            _7GunlukKasaCikisMoney3 = 24364.32;
            _7GunlukKasaCikisMoney4 = 4345;
            _7GunlukKasaCikisMoney5 = 400;
            _7GunlukKasaCikisMoney6 = 76437.46;
            _7GunlukKasaCikisMoney7 = 26400.40;


            _7GunKasaHareketDay1 = "10.16.2022";
            _7GunKasaHareketDay2 = "11.16.2022";
            _7GunKasaHareketDay3 = "12.16.2022";
            _7GunKasaHareketDay4 = "13.16.2022";
            _7GunKasaHareketDay5 = "14.16.2022";
            _7GunKasaHareketDay6 = "15.16.2022";
            _7GunKasaHareketDay7 = "16.16.2022";
        }
        private void _7gunlukBankaHaraketPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btn7GunBankaCikis_Clicked(object sender, EventArgs e)
        {

        }
        private void btn7GunBankaGiris_Clicked(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion        

        #region btnAnaSayfa
        private void btnAnaSayfaFaturalar_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            //DisplayAlert("", bt.Source.ToString(), "ok");
            var test1 = Navigation.ModalStack;
            var test2 = Navigation.NavigationStack;
            try
            {
                //ResetNavigationStack();
            }
            catch
            {
                throw;
            }
        }
        public void ResetNavigationStack()
        {
            if (Navigation != null && Navigation.ModalStack.Count() > 0)
            {
                var existingPages = Navigation.ModalStack.ToList();
                foreach (var page in existingPages)
                {
                    Navigation.RemovePage(page);
                }
            }
        }
        private async void btnAnaSayfaKasa_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new KasaListePage(),this);
            await Navigation.PopAsync();
            //Navigation.PushModalAsync(new MainMDPage(mod, "KasaListe", APIHelper.secilenlogindonemYil), false);
        }

        private async void btnAnaSayfaBanka_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new BankaPage());
            //Navigation.InsertPageBefore(new MainMDPage(mod, "BankaListe", APIHelper.secilenlogindonemYil), this);
            Navigation.InsertPageBefore(new BankaPage(), this);
            await Navigation.PopAsync();
        }

        private async void btnAnaSayfaCekSenet_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new CekSenetListesiPage(),this);
            await Navigation.PopAsync();
            //Navigation.PushModalAsync(new MainMDPage(mod, "CekSenetListe", APIHelper.secilenlogindonemYil), false);
        }

        private async void btnAnaSayfaSatisYap_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new SatisYapPage(),this);
            await Navigation.PopAsync();
            //Navigation.PushModalAsync(new MainMDPage(mod, "SatisYap", APIHelper.secilenlogindonemYil), false);
        }

        private async void btnAnaSayfaTaksitTakip_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new TaksitListesiPage(),this);
            await Navigation.PopAsync();
            //Navigation.PushModalAsync(new MainMDPage(mod, "TaksitTakip", APIHelper.secilenlogindonemYil), false);
        }

        private async void btnAnaSayfaStokKartlari_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new StokKartlariPage(),this);
            await Navigation.PopAsync();
            //Navigation.PushModalAsync(new MainMDPage(mod, "StokKartlari", APIHelper.secilenlogindonemYil), false);
        }

        private async void btnAnaSayfaCariHesaplar_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new CariHesaplarPage(),this);
            await Navigation.PopAsync();
            //Navigation.PushModalAsync(new MainMDPage(mod, "CariHesaplar", APIHelper.secilenlogindonemYil), false);
        }
        #endregion


        private void btnPopUpMenu_Clicked(object sender, EventArgs e)
        {
            //Menü arka button heightrequestler sırayla
            //55-80-120-160-200-240-280-320-370
            if (!SuresiGecenHatirlatmaView.IsVisible)
            {
                switch (openedPopUp)
                {
                    case "menu":
                        #region menu
                        if (!btnpopupMenuReturnBack.IsVisible)
                        {
                            this.CancelAnimations();
                            popupMenuBack.IsVisible = true;
                            btnpopupMenuReturnBack.IsVisible = true;
                            btnpopupMenuReturnBackground.IsVisible = true;
                            //popupMenuBackBox.HeightRequest = 0;
                            popupMenuBackBox.TranslateTo(0, -45, _popuptimer);


                            //Panel 1
                            //popupMenuBackBox.HeightRequest = 80;
                            btnPopUpMenuItemPanel.IsVisible = true;
                            lblPopUpMenuItemPanel.IsVisible = true;
                            btnPopUpMenuItemPanel.TranslateTo(-2, 45, _popuptimer);
                            lblPopUpMenuItemPanel.TranslateTo(-45, 56, _popuptimer);

                            //Hızlı Arama 2
                            // popupMenuBackBox.HeightRequest = 120;
                            btnPopUpMenuItemAra.IsVisible = true;
                            lblPopUpMenuItemAra.IsVisible = true;
                            btnPopUpMenuItemAra.TranslateTo(-2, 85, _popuptimer);
                            lblPopUpMenuItemAra.TranslateTo(-62, 93, _popuptimer);

                            //Cari İşlem 3
                            // popupMenuBackBox.HeightRequest = 160;
                            btnPopUpMenuItemCariIslem.IsVisible = true;
                            lblPopUpMenuItemCariIslem.IsVisible = true;
                            btnPopUpMenuItemCariIslem.TranslateTo(-2, 125, _popuptimer);
                            lblPopUpMenuItemCariIslem.TranslateTo(-68, 134, _popuptimer);

                            //Stok Kartları 4
                            //popupMenuBackBox.HeightRequest = 200;
                            btnPopUpMenuItemStokKartlari.IsVisible = true;
                            lblPopUpMenuItemStokKartlari.IsVisible = true;
                            btnPopUpMenuItemStokKartlari.TranslateTo(-2, 165, _popuptimer);
                            lblPopUpMenuItemStokKartlari.TranslateTo(-67, 173, _popuptimer);

                            //Satış Yap 5
                            // popupMenuBackBox.HeightRequest = 240;
                            btnPopUpMenuItemSatisYap.IsVisible = true;
                            lblPopUpMenuItemSatisYap.IsVisible = true;
                            btnPopUpMenuItemSatisYap.TranslateTo(-2, 204, _popuptimer);
                            lblPopUpMenuItemSatisYap.TranslateTo(-57, 213, _popuptimer);

                            //Faturalar 6
                            // popupMenuBackBox.HeightRequest = 280;
                            btnPopUpMenuItemFaturalar.IsVisible = true;
                            lblPopUpMenuItemFaturalar.IsVisible = true;
                            btnPopUpMenuItemFaturalar.TranslateTo(-2, 245, _popuptimer);
                            lblPopUpMenuItemFaturalar.TranslateTo(-64, 255, _popuptimer);

                            //Fiyat Gör 7
                            //popupMenuBackBox.HeightRequest = 320;
                            btnPopUpMenuItemFiyatGor.IsVisible = true;
                            lblPopUpMenuItemFiyatGor.IsVisible = true;
                            btnPopUpMenuItemFiyatGor.TranslateTo(-2, 288, _popuptimer);
                            lblPopUpMenuItemFiyatGor.TranslateTo(-63, 297, _popuptimer);

                            //popupMenuBackBox.HeightRequest = 340;
                        }
                        else
                        {
                            this.CancelAnimations();
                            popupMenuBackBox.TranslateTo(0, -370, _popuptimer);
                            //Fiyat Gör 7                
                            btnPopUpMenuItemFiyatGor.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemFiyatGor.TranslateTo(100, 297, _popuptimer);

                            //Faturalar 6
                            btnPopUpMenuItemFaturalar.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemFaturalar.TranslateTo(100, 255, _popuptimer);

                            //Satış Yap 5
                            btnPopUpMenuItemSatisYap.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemSatisYap.TranslateTo(100, 213, _popuptimer);

                            //Stok Kartları 4
                            btnPopUpMenuItemStokKartlari.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemStokKartlari.TranslateTo(100, 173, _popuptimer);

                            //Cari İşlem 3
                            btnPopUpMenuItemCariIslem.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemCariIslem.TranslateTo(100, 134, _popuptimer);

                            //Hızlı Arama 2
                            btnPopUpMenuItemAra.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemAra.TranslateTo(100, 93, _popuptimer);

                            //Panel 1
                            btnPopUpMenuItemPanel.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemPanel.TranslateTo(100, 56, _popuptimer);

                            Task.Delay(((int)_popuptimer));

                            popupMenuBack.IsVisible = true;
                            btnpopupMenuReturnBack.IsVisible = false;
                            btnpopupMenuReturnBackground.IsVisible = false;
                        }
                        #endregion
                        break;

                    case "userpanel":
                        #region userpanel
                        btnpopupMenuReturnBackground.IsVisible = false;
                        btnpopupMenuReturnBack.IsVisible = false;
                        userSettingsView.TranslateTo(userSettingsView.TranslationX, -300, _popuptimer);
                        openedPopUp = "menu";
                        #endregion
                        goto default;
                    default:
                        #region default
                        openedPopUp = "menu";
                        if (!btnpopupMenuReturnBack.IsVisible)
                        {
                            this.CancelAnimations();
                            popupMenuBack.IsVisible = true;
                            btnpopupMenuReturnBack.IsVisible = true;
                            btnpopupMenuReturnBackground.IsVisible = true;
                            //popupMenuBackBox.HeightRequest = 0;
                            popupMenuBackBox.TranslateTo(0, -45, _popuptimer);


                            //Panel 1
                            //popupMenuBackBox.HeightRequest = 80;
                            btnPopUpMenuItemPanel.IsVisible = true;
                            lblPopUpMenuItemPanel.IsVisible = true;
                            btnPopUpMenuItemPanel.TranslateTo(-2, 45, _popuptimer);
                            lblPopUpMenuItemPanel.TranslateTo(-45, 56, _popuptimer);

                            //Hızlı Arama 2
                            // popupMenuBackBox.HeightRequest = 120;
                            btnPopUpMenuItemAra.IsVisible = true;
                            lblPopUpMenuItemAra.IsVisible = true;
                            btnPopUpMenuItemAra.TranslateTo(-2, 85, _popuptimer);
                            lblPopUpMenuItemAra.TranslateTo(-62, 93, _popuptimer);

                            //Cari İşlem 3
                            // popupMenuBackBox.HeightRequest = 160;
                            btnPopUpMenuItemCariIslem.IsVisible = true;
                            lblPopUpMenuItemCariIslem.IsVisible = true;
                            btnPopUpMenuItemCariIslem.TranslateTo(-2, 125, _popuptimer);
                            lblPopUpMenuItemCariIslem.TranslateTo(-68, 134, _popuptimer);

                            //Stok Kartları 4
                            //popupMenuBackBox.HeightRequest = 200;
                            btnPopUpMenuItemStokKartlari.IsVisible = true;
                            lblPopUpMenuItemStokKartlari.IsVisible = true;
                            btnPopUpMenuItemStokKartlari.TranslateTo(-2, 165, _popuptimer);
                            lblPopUpMenuItemStokKartlari.TranslateTo(-67, 173, _popuptimer);

                            //Satış Yap 5
                            // popupMenuBackBox.HeightRequest = 240;
                            btnPopUpMenuItemSatisYap.IsVisible = true;
                            lblPopUpMenuItemSatisYap.IsVisible = true;
                            btnPopUpMenuItemSatisYap.TranslateTo(-2, 204, _popuptimer);
                            lblPopUpMenuItemSatisYap.TranslateTo(-57, 213, _popuptimer);

                            //Faturalar 6
                            // popupMenuBackBox.HeightRequest = 280;
                            btnPopUpMenuItemFaturalar.IsVisible = true;
                            lblPopUpMenuItemFaturalar.IsVisible = true;
                            btnPopUpMenuItemFaturalar.TranslateTo(-2, 245, _popuptimer);
                            lblPopUpMenuItemFaturalar.TranslateTo(-64, 255, _popuptimer);

                            //Fiyat Gör 7
                            //popupMenuBackBox.HeightRequest = 320;
                            btnPopUpMenuItemFiyatGor.IsVisible = true;
                            lblPopUpMenuItemFiyatGor.IsVisible = true;
                            btnPopUpMenuItemFiyatGor.TranslateTo(-2, 288, _popuptimer);
                            lblPopUpMenuItemFiyatGor.TranslateTo(-63, 297, _popuptimer);

                            //popupMenuBackBox.HeightRequest = 340;
                        }
                        else
                        {
                            this.CancelAnimations();
                            popupMenuBackBox.TranslateTo(0, -370, _popuptimer);
                            //Fiyat Gör 7                
                            btnPopUpMenuItemFiyatGor.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemFiyatGor.TranslateTo(100, 297, _popuptimer);

                            //Faturalar 6
                            btnPopUpMenuItemFaturalar.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemFaturalar.TranslateTo(100, 255, _popuptimer);

                            //Satış Yap 5
                            btnPopUpMenuItemSatisYap.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemSatisYap.TranslateTo(100, 213, _popuptimer);

                            //Stok Kartları 4
                            btnPopUpMenuItemStokKartlari.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemStokKartlari.TranslateTo(100, 173, _popuptimer);

                            //Cari İşlem 3
                            btnPopUpMenuItemCariIslem.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemCariIslem.TranslateTo(100, 134, _popuptimer);

                            //Hızlı Arama 2
                            btnPopUpMenuItemAra.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemAra.TranslateTo(100, 93, _popuptimer);

                            //Panel 1
                            btnPopUpMenuItemPanel.TranslateTo(-2, 0, _popuptimer);
                            lblPopUpMenuItemPanel.TranslateTo(100, 56, _popuptimer);

                            Task.Delay(((int)_popuptimer));
                            popupMenuBack.IsVisible = true;
                            btnpopupMenuReturnBack.IsVisible = false;
                            btnpopupMenuReturnBackground.IsVisible = false;
                        }
                        #endregion
                        break;
                }
            }           
        }

        private void btnpopupMenuReturnBack_Clicked(object sender, EventArgs e)
        {
            switch (openedPopUp)
            {
                case "menu":
                    #region menu
                    this.CancelAnimations();
                    popupMenuBackBox.TranslateTo(0, -370, _popuptimer);
                    //Fiyat Gör 7                
                    btnPopUpMenuItemFiyatGor.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemFiyatGor.TranslateTo(100, 297, _popuptimer);

                    //Faturalar 6
                    btnPopUpMenuItemFaturalar.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemFaturalar.TranslateTo(100, 255, _popuptimer);

                    //Satış Yap 5
                    btnPopUpMenuItemSatisYap.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemSatisYap.TranslateTo(100, 213, _popuptimer);

                    //Stok Kartları 4
                    btnPopUpMenuItemStokKartlari.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemStokKartlari.TranslateTo(100, 173, _popuptimer);

                    //Cari İşlem 3
                    btnPopUpMenuItemCariIslem.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemCariIslem.TranslateTo(100, 134, _popuptimer);

                    //Hızlı Arama 2
                    btnPopUpMenuItemAra.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemAra.TranslateTo(100, 93, _popuptimer);

                    //Panel 1
                    btnPopUpMenuItemPanel.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemPanel.TranslateTo(100, 56, _popuptimer);

                    Task.Delay(((int)_popuptimer));
                    popupMenuBack.IsVisible = true;
                    btnpopupMenuReturnBack.IsVisible = false;
                    btnpopupMenuReturnBackground.IsVisible = false;
                    break;
                #endregion
                case "userpanel":
                    #region userpanel
                    this.CancelAnimations();
                    btnpopupMenuReturnBackground.IsVisible = false;
                    btnpopupMenuReturnBack.IsVisible = false;
                    userSettingsView.TranslateTo(userSettingsView.TranslationX, -300, _popuptimer);
                    #endregion
                    break;
                default:
                    #region menu
                    this.CancelAnimations();
                    popupMenuBackBox.TranslateTo(0, -370, _popuptimer);
                    //Fiyat Gör 7                
                    btnPopUpMenuItemFiyatGor.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemFiyatGor.TranslateTo(100, 297, _popuptimer);

                    //Faturalar 6
                    btnPopUpMenuItemFaturalar.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemFaturalar.TranslateTo(100, 255, _popuptimer);

                    //Satış Yap 5
                    btnPopUpMenuItemSatisYap.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemSatisYap.TranslateTo(100, 213, _popuptimer);

                    //Stok Kartları 4
                    btnPopUpMenuItemStokKartlari.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemStokKartlari.TranslateTo(100, 173, _popuptimer);

                    //Cari İşlem 3
                    btnPopUpMenuItemCariIslem.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemCariIslem.TranslateTo(100, 134, _popuptimer);

                    //Hızlı Arama 2
                    btnPopUpMenuItemAra.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemAra.TranslateTo(100, 93, _popuptimer);

                    //Panel 1
                    btnPopUpMenuItemPanel.TranslateTo(-2, 0, _popuptimer);
                    lblPopUpMenuItemPanel.TranslateTo(100, 56, _popuptimer);

                    Task.Delay(((int)_popuptimer));
                    popupMenuBack.IsVisible = true;
                    btnpopupMenuReturnBack.IsVisible = false;
                    btnpopupMenuReturnBackground.IsVisible = false;
                    #endregion

                    #region userpanel
                    this.CancelAnimations();
                    btnpopupMenuReturnBackground.IsVisible = false;
                    btnpopupMenuReturnBack.IsVisible = false;
                    userSettingsView.TranslateTo(userSettingsView.TranslationX, -300, _popuptimer);
                    #endregion
                    break;
            }
        }

        private void btnToolbarOpenpopup_Clicked(object sender, EventArgs e)
        {
            btnPopUpMenu_Clicked(null, null);
        }
        private async void btnToolbarRefesh_Clicked(object sender, EventArgs e)
        {
            if (!SuresiGecenHatirlatmaView.IsVisible)
            {
                string[] dactionbtns = APIHelper.logindonemYil.ToArray<string>();
                var result = await DisplayActionSheet("Seçili Dönem: " + APIHelper.secilenlogindonemYil, "İptal", null, dactionbtns);
                if (result != "İptal" && result != null)
                {

                }
            }
        }

        private void btnToolbarOpenUserPopup_Clicked(object sender, EventArgs e)
        {
            if (!SuresiGecenHatirlatmaView.IsVisible)
            {
                switch (openedPopUp)
                {
                    case "menu":
                        #region menu
                        this.CancelAnimations();
                        popupMenuBackBox.TranslateTo(0, -370, _popuptimer);
                        //Fiyat Gör 7                
                        btnPopUpMenuItemFiyatGor.TranslateTo(-2, 0, _popuptimer);
                        lblPopUpMenuItemFiyatGor.TranslateTo(100, 297, _popuptimer);

                        //Faturalar 6
                        btnPopUpMenuItemFaturalar.TranslateTo(-2, 0, _popuptimer);
                        lblPopUpMenuItemFaturalar.TranslateTo(100, 255, _popuptimer);

                        //Satış Yap 5
                        btnPopUpMenuItemSatisYap.TranslateTo(-2, 0, _popuptimer);
                        lblPopUpMenuItemSatisYap.TranslateTo(100, 213, _popuptimer);

                        //Stok Kartları 4
                        btnPopUpMenuItemStokKartlari.TranslateTo(-2, 0, _popuptimer);
                        lblPopUpMenuItemStokKartlari.TranslateTo(100, 173, _popuptimer);

                        //Cari İşlem 3
                        btnPopUpMenuItemCariIslem.TranslateTo(-2, 0, _popuptimer);
                        lblPopUpMenuItemCariIslem.TranslateTo(100, 134, _popuptimer);

                        //Hızlı Arama 2
                        btnPopUpMenuItemAra.TranslateTo(-2, 0, _popuptimer);
                        lblPopUpMenuItemAra.TranslateTo(100, 93, _popuptimer);

                        //Panel 1
                        btnPopUpMenuItemPanel.TranslateTo(-2, 0, _popuptimer);
                        lblPopUpMenuItemPanel.TranslateTo(100, 56, _popuptimer);

                        Task.Delay(((int)_popuptimer));
                        popupMenuBack.IsVisible = true;
                        btnpopupMenuReturnBack.IsVisible = false;
                        btnpopupMenuReturnBackground.IsVisible = false;
                        #endregion
                        goto default;

                    case "userpanel":
                        #region userpanel
                        this.CancelAnimations();
                        if (!btnpopupMenuReturnBackground.IsVisible)
                        {
                            btnpopupMenuReturnBackground.IsVisible = true;
                            btnpopupMenuReturnBack.IsVisible = true;
                            userSettingsView.TranslateTo(userSettingsView.TranslationX, -45, _popuptimer);
                        }
                        else
                        {
                            btnpopupMenuReturnBackground.IsVisible = false;
                            btnpopupMenuReturnBack.IsVisible = false;
                            userSettingsView.TranslateTo(userSettingsView.TranslationX, -300, _popuptimer);
                        }
                        #endregion
                        break;
                    default:
                        #region default
                        openedPopUp = "userpanel";
                        this.CancelAnimations();
                        if (!btnpopupMenuReturnBackground.IsVisible)
                        {
                            btnpopupMenuReturnBackground.IsVisible = true;
                            btnpopupMenuReturnBack.IsVisible = true;
                            userSettingsView.TranslateTo(userSettingsView.TranslationX, -45, _popuptimer);
                        }
                        else
                        {
                            btnpopupMenuReturnBackground.IsVisible = false;
                            btnpopupMenuReturnBack.IsVisible = false;
                            userSettingsView.TranslateTo(userSettingsView.TranslationX, -300, _popuptimer);
                        }
                        #endregion
                        break;
                }
            }
        }

        private void toolbarPopupbtnLogout_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            Navigation.PushModalAsync(new LoginPage());
        }

        #region Süresi Geçen Hatırlatmalar View
        void SuresiGecenHatirlatmalarListeAdder()
        {
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "aaaaaaa", AdSoyad = "Ahmet Ertürk", Firma = "Sancaklar iletişim" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "bbbbbbbbb", AdSoyad = "awhaha awhawh", Firma = "fghgdjdfg sehjnrsdnj" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "vvvvvvv", AdSoyad = "fdhdh jhfhg", Firma = "dshesh iletişim" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "sssssssss", AdSoyad = "awhawh awhawhwahawh", Firma = "dhsdhsdfh iletişim" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "aefsgseg", AdSoyad = "awha awhawh", Firma = "gfdjdfj sdgehse" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "gawgaw", AdSoyad = "awgawh Ertürk", Firma = "sehsejsrej sjsejsj" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "shhehseh", AdSoyad = "Ahmet agwagawg", Firma = "gfjgfj fgdjdf" });
        }
        void SuresiGecenHatirlatmalarViewAdder(string _adSoyad, string _firma, string _aciklama)
        {
            SuresiGecenListeView.Children.Add(new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text=_adSoyad,
                        TextColor=Color.FromHex(AppThemeColors._textColor),
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.StartAndExpand
                    },
                    new Label
                    {
                        Text=_firma,
                        TextColor=Color.FromHex(AppThemeColors._textColor),
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.CenterAndExpand
                    },
                    new Label
                    {
                        Text=_aciklama,
                        TextColor=Color.FromHex(AppThemeColors._textColor),
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.EndAndExpand,
                        TranslationX=-20
                    }
                },
                Orientation = StackOrientation.Horizontal
            });
            SuresiGecenListeView.Children.Add(new BoxView()
            {
                HeightRequest = 1,
                Color = Color.White,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(-20, 0, -20, 0)
            });
        }
        private void btnSureGecenHatirlatmaKapat_Clicked(object sender, EventArgs e)
        {
            SuresiGecenHatirlatmaView.IsVisible = false;
            btnpopupMenuReturnBackground.IsVisible = false;
        }

        #endregion

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}