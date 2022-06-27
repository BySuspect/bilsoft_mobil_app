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

namespace bilsoft_mobil_app.Pages
{

    /*/ Yapılacaklar
    *-- splash screen yapılacak
    *-- grafiklerin renkleri birbirine uyumlu yapılacak.    
    *-- 7gün satış,7gün vade,7günlük kasa,kasa bakiyeleri,banka bakiyeleri font renkleri beyaz yapılacak.
    * toolbara dönem yılı seçme, kullanıcı menüsü eklencek.
    * toolbar menüleri senkronize edilicek aynı anda açılmayacak
    * yan menü tasarımı yapılacak.
    /*/
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
        string mod = null, donemYili = null;
        
        #region Renkler
        const string _chartKrediKartiColor = "#3706FF";
        const string _chartNakitColor = "#FF0665";
        const string _chartAcikHesapColor = "#29ba4d";
        const string _chartCekColor = _chartAcikHesapColor;
        const string _7GunSatisGColor = "#ffffff";
        const string _7GunVadeTahsilatGColor = "#009c4e";
        const string _7GunVadeOdemeGColor = "#003b99";
        const string _7GunBankaHaraketGirisColor = "#009c4e";
        const string _7GunBankaHaraketCikisColor = "#003b99";
        const string _7GunlukKasaGirisColor = "#009c4e";
        const string _7GunlukKasaCikisColor = "#003b99";

        const string _borderColor = "#7AEC5E0F";
        const string _backgroundColor = "#ffa600";
        const string _cardBackgroundColor = "#7AFF6701";

        const string _textColor = "#FFFFFF";
        const string _textColorKoyu = "#101010";
        const string _textColorWhite = "#FFFFFF";
        const string _textColorBlack = "#FFFFFF";

        #endregion

        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(_textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(_textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(_borderColor);
        public Color BackgroundColor { get; set; } = Color.FromHex(_backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(_cardBackgroundColor);

        public Color KrediKartiColor { get; set; } = Color.FromHex(_chartKrediKartiColor);
        public Color NakitColor { get; set; } = Color.FromHex(_chartNakitColor);
        public Color AcikHesapColor { get; set; } = Color.FromHex(_chartAcikHesapColor);
        public Color CekColor { get; set; } = Color.FromHex(_chartCekColor);
        public Color _7GunVadeTahsilatColor { get; set; } = Color.FromHex(_7GunVadeTahsilatGColor);
        public Color _7GunVadeOdemeColor { get; set; } = Color.FromHex(_7GunVadeOdemeGColor);
        public Color _BankaHaraketGirisColor { get; set; } = Color.FromHex(_7GunBankaHaraketGirisColor);
        public Color _BankaHaraketCikisColor { get; set; } = Color.FromHex(_7GunBankaHaraketCikisColor);
        public Color _KasaGirisColor { get; set; } = Color.FromHex(_7GunlukKasaGirisColor);
        public Color _KasaCikisColor { get; set; } = Color.FromHex(_7GunlukKasaCikisColor);
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

        
        public MainContentPage(string _mod, string _donemYil)
        {
            BindingContext = this;
            InitializeComponent();
            try
            {
                donemYili = _donemYil;
                mod = _mod;

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
                _7GunlukSatisGraph.Chart = new PointChart { Entries = entries7GunlukTahsilat, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse(_textColor), PointAreaAlpha = 255, PointMode = PointMode.Circle, AnimationDuration = TimeSpan.FromSeconds(3), Margin = 30, BackgroundColor = SKColors.Transparent };
                _7GunlukVadeGelenGraph.Chart = new PointChart { Entries = entries7GunlukVadeGelen, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse(_textColor), PointAreaAlpha = 255, PointMode = PointMode.Circle, AnimationDuration = TimeSpan.FromSeconds(3), BackgroundColor = SKColors.Transparent };
                #endregion

                #region 7 Günlük Banka Haraket Chart
                _7GunlukBankaHaraketGraph.Chart = new LineChart { Entries = entries7gunbankaharaket, IsAnimated = true, LabelTextSize = 30, LabelColor = SKColor.Parse(_textColor), PointAreaAlpha = 255, AnimationDuration = TimeSpan.FromSeconds(3), Margin = 30, LineSize = 5, PointSize = 30, EnableYFadeOutGradient = false,BackgroundColor=SKColors.Transparent };
                _7gunlukBankaHaraketPicker.ItemsSource = new List<string> { "Ziraat Bankası", "Garanti Bankası", "İş Bankası" };
                #endregion

                #region 7 Günlük Kasa Haraket Chart
                _7GunlukKasaHareketleriChart.Chart = new PointChart { Entries = entries7GunlukKasaHareketleri, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse(_textColor), PointAreaAlpha = 255, PointMode = PointMode.Circle, AnimationDuration = TimeSpan.FromSeconds(3), BackgroundColor = SKColors.Transparent };
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
        }

        #region Kasa Bakiye Liste
        async Task createKasaListProp(int sira)
        {
            gridKasaBakiye.Children.Add(new Label
            {
                Text = (sira + 1).ToString(),
                FontSize = 12,
                Margin = new Thickness(-5, 5, 5, 5),
                TextColor = Color.FromHex(_textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 0, sira + 1);
            gridKasaBakiye.Children.Add(new Label
            {
                Text = KasaBakiyelerListe[sira].Kasa,
                FontSize = 12,
                Margin = new Thickness(-70, 5, 5, 5),
                TextColor = Color.FromHex(_textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 1, sira + 1);
            gridKasaBakiye.Children.Add(new Label
            {
                Text = KasaBakiyelerListe[sira].KasaBakiye.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                FontSize = 12,
                Margin = new Thickness(0, 5, 5, -5),
                TextColor = Color.FromHex(_textColor),
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
                Margin = new Thickness(-5, 5, 5, 5),
                TextColor = Color.FromHex(_textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 0, sira + 1);
            gridBankaList.Children.Add(new Label
            {
                Text = BankaBakiyelerListe[sira].Banka_Hesap,
                FontSize = 12,
                Margin = new Thickness(-70, 5, 5, 5),
                TextColor = Color.FromHex(_textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 1, sira + 1);
            gridBankaList.Children.Add(new Label
            {
                Text = BankaBakiyelerListe[sira].HesapNo,
                FontSize = 12,
                Margin = new Thickness(-30, 5, -10, 5),
                TextColor = Color.FromHex(_textColor),
                Padding = new Thickness(0, 5),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            }, 2, sira + 1);
            gridBankaList.Children.Add(new Label
            {
                Text = BankaBakiyelerListe[sira].HesapBakiye.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                FontSize = 12,
                Margin = new Thickness(-10, 5, -10, 5),
                TextColor = Color.FromHex(_textColor),
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
                                Color = SKColor.Parse(_chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GSKrediKarti)) {
                                Color = SKColor.Parse(_chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GSAcikHesap)) {
                                Color = SKColor.Parse(_chartAcikHesapColor)
                        }
                };
                #endregion

                #region Günlük Alış Entry
                entriesGunlukAlis = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(GANakit)) {
                                Color = SKColor.Parse(_chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GAKrediKarti)) {
                                Color = SKColor.Parse(_chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GAAcikHesap)) {
                                Color = SKColor.Parse(_chartAcikHesapColor)
                        }
                };
                #endregion

                #region Günlük Tahsilat Entry
                entriesGunlukTahsilat = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(GTNakit)) {
                                Color = SKColor.Parse(_chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GTKrediKarti)) {
                                Color = SKColor.Parse(_chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GTCek)) {
                                Color = SKColor.Parse(_chartCekColor)
                        }
                };
                #endregion

                #region Günlük Ödeme Entry
                entriesGunlukOdeme = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(GONakit)) {
                                Color = SKColor.Parse(_chartNakitColor)
                        },

                        new ChartEntry(Convert.ToInt32(GOKrediKarti)) {
                                Color = SKColor.Parse(_chartKrediKartiColor)
                        },

                        new ChartEntry(Convert.ToInt32(GOCek)) {
                                Color = SKColor.Parse(_chartCekColor)
                        }
                };
                #endregion

                #region 7 Günlük Satış Entry
                entries7GunlukTahsilat = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney1)) {
                                Color = SKColor.Parse(_7GunSatisGColor),
                                        Label = _7GunSatisGDay1,
                                        ValueLabel = _7GunSatisGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_textColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney2)) {
                                Color = SKColor.Parse(_7GunSatisGColor),
                                        Label = _7GunSatisGDay2,
                                        ValueLabel = _7GunSatisGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_textColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney3)) {
                                Color = SKColor.Parse(_7GunSatisGColor),
                                        Label = _7GunSatisGDay3,
                                        ValueLabel = _7GunSatisGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney4)) {
                                Color = SKColor.Parse(_7GunSatisGColor),
                                        Label = _7GunSatisGDay4,
                                        ValueLabel = _7GunSatisGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney5)) {
                                Color = SKColor.Parse(_7GunSatisGColor),
                                        Label = _7GunSatisGDay5,
                                        ValueLabel = _7GunSatisGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney6)) {
                                Color = SKColor.Parse(_7GunSatisGColor),
                                        Label = _7GunSatisGDay6,
                                        ValueLabel = _7GunSatisGMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_textColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunSatisGMoney7)) {
                                Color = SKColor.Parse(_7GunSatisGColor),
                                        Label = _7GunSatisGDay7,
                                        ValueLabel = _7GunSatisGMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_textColor)
                        }
                };
                #endregion

                #region 7 Günlük Vadesi Gelecek Entry
                entries7GunlukVadeGelen = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney1)) {
                                Color = SKColor.Parse(_7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay1,
                                        ValueLabel = _7GunVadeTahsilatGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeTahsilatGColor),                                        
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney1)) {
                                Color = SKColor.Parse(_7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay1,
                                        ValueLabel = _7GunVadeOdemeGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeOdemeGColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney2)) {
                                Color = SKColor.Parse(_7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay2,
                                        ValueLabel = _7GunVadeTahsilatGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney2)) {
                                Color = SKColor.Parse(_7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay2,
                                        ValueLabel = _7GunVadeOdemeGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney3)) {
                                Color = SKColor.Parse(_7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay3,
                                        ValueLabel = _7GunVadeTahsilatGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney3)) {
                                Color = SKColor.Parse(_7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay3,
                                        ValueLabel = _7GunVadeOdemeGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney4)) {
                                Color = SKColor.Parse(_7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay4,
                                        ValueLabel = _7GunVadeTahsilatGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney4)) {
                                Color = SKColor.Parse(_7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay4,
                                        ValueLabel = _7GunVadeOdemeGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeOdemeGColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney5)) {
                                Color = SKColor.Parse(_7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay5,
                                        ValueLabel = _7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeTahsilatGColor)
                        },

                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney5)) {
                                Color = SKColor.Parse(_7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay5,
                                        ValueLabel = _7GunVadeOdemeGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney6)) {
                                Color = SKColor.Parse(_7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay6,
                                        ValueLabel = _7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney6)) {
                                Color = SKColor.Parse(_7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay6,
                                        ValueLabel = _7GunVadeOdemeGMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeOdemeGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney7)) {
                                Color = SKColor.Parse(_7GunVadeTahsilatGColor),
                                        Label = _7GunVadeGDay7,
                                        ValueLabel = _7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeTahsilatGColor)
                        },
                        new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney7)) {
                                Color = SKColor.Parse(_7GunVadeOdemeGColor),
                                        Label = _7GunVadeGDay7,
                                        ValueLabel = _7GunVadeOdemeGMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                                        ValueLabelColor = SKColor.Parse(_7GunVadeOdemeGColor)
                        }
                };
                #endregion

                #region 7 Günlük Banka Haraketleri Entry
                entries7gunbankaharaket = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris1)) {
                                Color = SKColor.Parse(_7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay1,
                                        ValueLabel = _7GunBankaHaraketGiris1 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketGirisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis1)) {
                                Color = SKColor.Parse(_7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay1,
                                        ValueLabel = _7GunBankaHaraketCikis1 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketCikisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris2)) {
                                Color = SKColor.Parse(_7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay2,
                                        ValueLabel = _7GunBankaHaraketGiris2 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis2)) {
                                Color = SKColor.Parse(_7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay2,
                                        ValueLabel = _7GunBankaHaraketCikis2 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris3)) {
                                Color = SKColor.Parse(_7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay3,
                                        ValueLabel = _7GunBankaHaraketGiris3 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis3)) {
                                Color = SKColor.Parse(_7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay3,
                                        ValueLabel = _7GunBankaHaraketCikis3 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris4)) {
                                Color = SKColor.Parse(_7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay4,
                                        ValueLabel = _7GunBankaHaraketGiris4 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis4)) {
                                Color = SKColor.Parse(_7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay4,
                                        ValueLabel = _7GunBankaHaraketCikis4 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketCikisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris5)) {
                                Color = SKColor.Parse(_7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay5,
                                        ValueLabel = _7GunBankaHaraketGiris5 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketGirisColor),
                        },

                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis5)) {
                                Color = SKColor.Parse(_7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay5,
                                        ValueLabel = _7GunBankaHaraketCikis5 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris6)) {
                                Color = SKColor.Parse(_7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay6,
                                        ValueLabel = _7GunBankaHaraketGiris6 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis6)) {
                                Color = SKColor.Parse(_7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay6,
                                        ValueLabel = _7GunBankaHaraketCikis6 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketCikisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris7)) {
                                Color = SKColor.Parse(_7GunBankaHaraketGirisColor),
                                        Label = _7GunBankaHaraketDay7,
                                        ValueLabel = _7GunBankaHaraketGiris7 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketGirisColor),
                        },
                        new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis7)) {
                                Color = SKColor.Parse(_7GunBankaHaraketCikisColor),
                                        Label = _7GunBankaHaraketDay7,
                                        ValueLabel = _7GunBankaHaraketCikis7 + "",
                                        ValueLabelColor = SKColor.Parse(_7GunBankaHaraketCikisColor),
                        }

                };
                #endregion

                #region 7 Günlük Kasa Haraketleri Entry
                entries7GunlukKasaHareketleri = new List<ChartEntry> {
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney1)) {
                                Color = SKColor.Parse(_7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay1,
                                        ValueLabel = _7GunlukKasaGirisMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney1)) {
                                Color = SKColor.Parse(_7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay1,
                                        ValueLabel = _7GunlukKasaCikisMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney2)) {
                                Color = SKColor.Parse(_7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay2,
                                        ValueLabel = _7GunlukKasaGirisMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney2)) {
                                Color = SKColor.Parse(_7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay2,
                                        ValueLabel = _7GunlukKasaCikisMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney3)) {
                                Color = SKColor.Parse(_7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay3,
                                        ValueLabel = _7GunlukKasaGirisMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney3)) {
                                Color = SKColor.Parse(_7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay3,
                                        ValueLabel = _7GunlukKasaCikisMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney4)) {
                                Color = SKColor.Parse(_7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay4,
                                        ValueLabel = _7GunlukKasaGirisMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney4)) {
                                Color = SKColor.Parse(_7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay4,
                                        ValueLabel = _7GunlukKasaCikisMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney5)) {
                                Color = SKColor.Parse(_7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay5,
                                        ValueLabel = _7GunlukKasaGirisMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },

                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney5)) {
                                Color = SKColor.Parse(_7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay5,
                                        ValueLabel = _7GunlukKasaCikisMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney6)) {
                                Color = SKColor.Parse(_7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay6,
                                        ValueLabel = _7GunlukKasaGirisMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney6)) {
                                Color = SKColor.Parse(_7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaCikisColor),
                                        Label = _7GunKasaHareketDay6,
                                        ValueLabel = _7GunlukKasaCikisMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney7)) {
                                Color = SKColor.Parse(_7GunlukKasaGirisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaGirisColor),
                                        Label = _7GunKasaHareketDay7,
                                        ValueLabel = _7GunlukKasaGirisMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
                        },
                        new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney7)) {
                                Color = SKColor.Parse(_7GunlukKasaCikisColor),
                                        ValueLabelColor=SKColor.Parse(_7GunlukKasaCikisColor),
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
        #region popup voidler
        private void btnPopUpMenu_Clicked(object sender, EventArgs e)
        {
            //Menü arka button heightrequestler sırayla
            //55-80-120-160-200-240-280-320-370

            if (!btnpopupMenuReturnBack.IsVisible)
            {
                this.CancelAnimations();
                popupMenuBack.IsVisible = true;
                btnpopupMenuReturnBack.IsVisible = true;
                btnpopupMenuReturnBackground.IsVisible=true;
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

                /*//popupMenuBackBox.HeightRequest = 320;
                btnPopUpMenuItemFaturalar.IsVisible = false;
                lblPopUpMenuItemFaturalar.IsVisible = false;
                //popupMenuBackBox.HeightRequest = 280;
                btnPopUpMenuItemSatisYap.IsVisible = false;
                lblPopUpMenuItemSatisYap.IsVisible = false;
                //popupMenuBackBox.HeightRequest = 240;
                btnPopUpMenuItemStokKartlari.IsVisible = false;
                lblPopUpMenuItemStokKartlari.IsVisible = false;
                //popupMenuBackBox.HeightRequest = 200;
                btnPopUpMenuItemCariIslem.IsVisible = false;
                lblPopUpMenuItemCariIslem.IsVisible = false;
                //popupMenuBackBox.HeightRequest = 160;
                btnPopUpMenuItemAra.IsVisible = false;
                lblPopUpMenuItemAra.IsVisible = false;
                btnPopUpMenuItemPanel.IsVisible = false;
                lblPopUpMenuItemPanel.IsVisible = false;
                btnPopUpMenuItemFiyatGor.IsVisible = false;
                lblPopUpMenuItemFiyatGor.IsVisible = false;*/
                //popupMenuBackBox.HeightRequest = 120;
                //popupMenuBackBox.HeightRequest = 80;
                //popupMenuBackBox.HeightRequest = 0;
                popupMenuBack.IsVisible = true;
                btnpopupMenuReturnBack.IsVisible = false;
                btnpopupMenuReturnBackground.IsVisible = false;
            }
            #region old v3 kapanma buglu
            /*
             //Menü arka button heightrequestler sırayla
            //55-80-120-160-200-240-280-320-340

            if (!popupMenuBack.IsVisible)
            {
                this.CancelAnimations();
                btnPopUpMenu.ImageSource = "offmenuicon.png";
                btnPopUpMenu.BackgroundColor = Color.FromHex("#36c6d3");
                popupMenuBack.IsVisible = true;
                btnpopupMenuReturnBack.IsVisible = true;
                popupMenuBackBox.HeightRequest = 55;


                //Panel 1
                popupMenuBackBox.HeightRequest = 80;
                btnPopUpMenuItemPanel.IsVisible = true;
                lblPopUpMenuItemPanel.IsVisible = true;
                btnPopUpMenuItemPanel.TranslateTo(-2, 45, _popuptimer);
                lblPopUpMenuItemPanel.TranslateTo(-45, 56, _popuptimer);

                //Hızlı Arama 2
                popupMenuBackBox.HeightRequest = 120;
                btnPopUpMenuItemAra.IsVisible = true;
                lblPopUpMenuItemAra.IsVisible = true;
                btnPopUpMenuItemAra.TranslateTo(-2, 85, _popuptimer);
                lblPopUpMenuItemAra.TranslateTo(-62, 93, _popuptimer);

                //Cari İşlem 3
                popupMenuBackBox.HeightRequest = 160;
                btnPopUpMenuItemCariIslem.IsVisible = true;
                lblPopUpMenuItemCariIslem.IsVisible = true;
                btnPopUpMenuItemCariIslem.TranslateTo(-2, 125, _popuptimer);
                lblPopUpMenuItemCariIslem.TranslateTo(-68, 134, _popuptimer);

                //Stok Kartları 4
                popupMenuBackBox.HeightRequest = 200;
                btnPopUpMenuItemStokKartlari.IsVisible = true;
                lblPopUpMenuItemStokKartlari.IsVisible = true;
                btnPopUpMenuItemStokKartlari.TranslateTo(-2, 165, _popuptimer);
                lblPopUpMenuItemStokKartlari.TranslateTo(-67, 173, _popuptimer);

                //Satış Yap 5
                popupMenuBackBox.HeightRequest = 240;
                btnPopUpMenuItemSatisYap.IsVisible = true;
                lblPopUpMenuItemSatisYap.IsVisible = true;
                btnPopUpMenuItemSatisYap.TranslateTo(-2, 204, _popuptimer);
                lblPopUpMenuItemSatisYap.TranslateTo(-57, 213, _popuptimer);

                //Faturalar 6
                popupMenuBackBox.HeightRequest = 280;
                btnPopUpMenuItemFaturalar.IsVisible = true;
                lblPopUpMenuItemFaturalar.IsVisible = true;
                btnPopUpMenuItemFaturalar.TranslateTo(-2, 245, _popuptimer);
                lblPopUpMenuItemFaturalar.TranslateTo(-64, 255, _popuptimer);

                //Fiyat Gör 7
                popupMenuBackBox.HeightRequest = 320;
                btnPopUpMenuItemFiyatGor.IsVisible = true;
                lblPopUpMenuItemFiyatGor.IsVisible = true;
                btnPopUpMenuItemFiyatGor.TranslateTo(-2, 288, _popuptimer);
                lblPopUpMenuItemFiyatGor.TranslateTo(-63, 297, _popuptimer);

                popupMenuBackBox.HeightRequest = 340;
            }
            else
            {
                this.CancelAnimations();
                //Fiyat Gör 7
                btnPopUpMenuItemFiyatGor.TranslateTo(-2, 0, _popuptimer);
                lblPopUpMenuItemFiyatGor.TranslateTo(0, 0, _popuptimer);
                btnPopUpMenuItemFiyatGor.IsVisible = false;
                lblPopUpMenuItemFiyatGor.IsVisible = false;
                popupMenuBackBox.HeightRequest = 320;

                //Faturalar 6
                btnPopUpMenuItemFaturalar.TranslateTo(-2, 0, _popuptimer);
                lblPopUpMenuItemFaturalar.TranslateTo(0, 0, _popuptimer);
                btnPopUpMenuItemFaturalar.IsVisible = false;
                lblPopUpMenuItemFaturalar.IsVisible = false;
                popupMenuBackBox.HeightRequest = 280;

                //Satış Yap 5
                btnPopUpMenuItemSatisYap.TranslateTo(-2, 0, _popuptimer);
                lblPopUpMenuItemSatisYap.TranslateTo(0, 0, _popuptimer);
                btnPopUpMenuItemSatisYap.IsVisible = false;
                lblPopUpMenuItemSatisYap.IsVisible = false;
                popupMenuBackBox.HeightRequest = 240;

                //Stok Kartları 4
                btnPopUpMenuItemStokKartlari.TranslateTo(-2, 0, _popuptimer);
                lblPopUpMenuItemStokKartlari.TranslateTo(0, 0, _popuptimer);
                btnPopUpMenuItemStokKartlari.IsVisible = false;
                lblPopUpMenuItemStokKartlari.IsVisible = false;
                popupMenuBackBox.HeightRequest = 200;

                //Cari İşlem 3
                btnPopUpMenuItemCariIslem.TranslateTo(-2, 0, _popuptimer);
                lblPopUpMenuItemCariIslem.TranslateTo(0, 0, _popuptimer);
                btnPopUpMenuItemCariIslem.IsVisible = false;
                lblPopUpMenuItemCariIslem.IsVisible = false;
                popupMenuBackBox.HeightRequest = 160;

                //Hızlı Arama 2
                btnPopUpMenuItemAra.TranslateTo(-2, 0, _popuptimer);
                lblPopUpMenuItemAra.TranslateTo(0, 0, _popuptimer);
                btnPopUpMenuItemAra.IsVisible = false;
                lblPopUpMenuItemAra.IsVisible = false;
                popupMenuBackBox.HeightRequest = 120;

                //Panel 1
                popupMenuBackBox.HeightRequest = 80;
                btnPopUpMenuItemPanel.IsVisible = false;
                lblPopUpMenuItemPanel.IsVisible = false;
                btnPopUpMenuItemPanel.TranslateTo(-2, 0, _popuptimer);
                lblPopUpMenuItemPanel.TranslateTo(0, 0, _popuptimer);

                await Task.Delay(500);

                popupMenuBackBox.HeightRequest = 55;
                btnPopUpMenu.ImageSource = "menuicon.png";
                btnPopUpMenu.BackgroundColor = Color.FromHex("#9A36c6d3");
                popupMenuBack.IsVisible = false;
                btnpopupMenuReturnBack.IsVisible = false;
            }
             */
            #endregion
            #region old v2 bugfix
            //Menü arka button heightrequestler sırayla
            //55-80-120-160-200-240-280-320-340
            /*
            if (!popupMenuBack.IsVisible)
            {
                btnPopUpMenu.ImageSource = "offmenuicon.png";
                btnPopUpMenu.BackgroundColor = Color.FromHex("#36c6d3");
                popupMenuBack.IsVisible = true;
                btnpopupMenuReturnBack.IsVisible = true;

                popupMenuBackBox.HeightRequest = 55;
                popupMenuBackBox.HeightRequest = 80;
                //Panel
                btnPopUpMenuItemPanel.IsVisible = true;
                lblPopUpMenuItemPanel.IsVisible = true;

                popupMenuBackBox.HeightRequest = 120;
                //Hızlı Arama
                btnPopUpMenuItemAra.IsVisible = true;
                lblPopUpMenuItemAra.IsVisible = true;

                popupMenuBackBox.HeightRequest = 160;
                //Cari İşlem
                btnPopUpMenuItemCariIslem.IsVisible = true;
                lblPopUpMenuItemCariIslem.IsVisible = true;

                popupMenuBackBox.HeightRequest = 200;
                //Stok Kartları
                btnPopUpMenuItemStokKartlari.IsVisible = true;
                lblPopUpMenuItemStokKartlari.IsVisible = true;

                popupMenuBackBox.HeightRequest = 240;
                //Satış Yap
                btnPopUpMenuItemSatisYap.IsVisible = true;
                lblPopUpMenuItemSatisYap.IsVisible = true;

                popupMenuBackBox.HeightRequest = 280;
                //Faturalar
                btnPopUpMenuItemFaturalar.IsVisible = true;
                lblPopUpMenuItemFaturalar.IsVisible = true;
                popupMenuBackBox.HeightRequest = 320;
                //Fiyat Gör
                btnPopUpMenuItemFiyatGor.IsVisible = true;
                lblPopUpMenuItemFiyatGor.IsVisible = true;

                popupMenuBackBox.HeightRequest = 340;
            }
            else
            {
                btnPopUpMenu.ImageSource = "menuicon.png";
                btnPopUpMenu.BackgroundColor = Color.FromHex("#9A36c6d3");
                popupMenuBack.IsVisible = false;
                btnpopupMenuReturnBack.IsVisible = false;
                btnPopUpMenuItemPanel.IsVisible = false;
                lblPopUpMenuItemPanel.IsVisible = false;
                btnPopUpMenuItemAra.IsVisible = false;
                lblPopUpMenuItemAra.IsVisible = false;
                btnPopUpMenuItemCariIslem.IsVisible = false;
                lblPopUpMenuItemCariIslem.IsVisible = false;
                btnPopUpMenuItemStokKartlari.IsVisible = false;
                lblPopUpMenuItemStokKartlari.IsVisible = false;
                btnPopUpMenuItemSatisYap.IsVisible = false;
                lblPopUpMenuItemSatisYap.IsVisible = false;
                btnPopUpMenuItemFaturalar.IsVisible = false;
                lblPopUpMenuItemFaturalar.IsVisible = false;
                btnPopUpMenuItemFiyatGor.IsVisible = false;
                lblPopUpMenuItemFiyatGor.IsVisible = false;
                popupMenuBackBox.HeightRequest = 55;
            }*/
            #endregion
            #region old v1 buglu olan
            //Menü arka button heightrequestler sırayla
            //55-100-150-200-240-280-330-380
            /*
            if (!popupMenuBack.IsVisible)
            {
                btnPopUpMenu.ImageSource = "offmenuicon.png";
                btnPopUpMenu.BackgroundColor = Color.FromHex("#36c6d3");
                popupMenuBack.IsVisible = true;
                btnpopupMenuReturnBack.IsVisible = true;

                popupMenuBackBox.HeightRequest = 100;
                btnPopUpMenuItemPanel.IsVisible = true;
                lblPopUpMenuItemPanel.IsVisible = true;
                
                await Task.Delay(50);

                popupMenuBackBox.HeightRequest = 150;
                btnPopUpMenuItemAra.IsVisible = true;
                lblPopUpMenuItemAra.IsVisible = true;

                await Task.Delay(50);

                popupMenuBackBox.HeightRequest = 200;
                btnPopUpMenuItemCariIslem.IsVisible = true;
                lblPopUpMenuItemCariIslem.IsVisible = true;

                await Task.Delay(50);

                popupMenuBackBox.HeightRequest = 240;
                btnPopUpMenuItemStokKartlari.IsVisible = true;
                lblPopUpMenuItemStokKartlari.IsVisible = true;

                await Task.Delay(50);

                popupMenuBackBox.HeightRequest = 280;
                btnPopUpMenuItemSatisYap.IsVisible = true;
                lblPopUpMenuItemSatisYap.IsVisible = true;

                await Task.Delay(50);

                popupMenuBackBox.HeightRequest = 330;
                btnPopUpMenuItemFaturalar.IsVisible = true;
                lblPopUpMenuItemFaturalar.IsVisible = true;

                await Task.Delay(50);

                popupMenuBackBox.HeightRequest = 380;
                btnPopUpMenuItemFiyatGor.IsVisible = true;
                lblPopUpMenuItemFiyatGor.IsVisible = true;

            }
            else
            {
                btnPopUpMenu.ImageSource = "menuicon.png";
                btnPopUpMenu.BackgroundColor = Color.FromHex("#9A36c6d3");
                popupMenuBack.IsVisible = false;
                btnpopupMenuReturnBack.IsVisible = false;
                btnPopUpMenuItemPanel.IsVisible = false;
                lblPopUpMenuItemPanel.IsVisible = false;
                btnPopUpMenuItemAra.IsVisible = false;
                lblPopUpMenuItemAra.IsVisible = false;
                btnPopUpMenuItemCariIslem.IsVisible = false;
                lblPopUpMenuItemCariIslem.IsVisible = false;
                btnPopUpMenuItemStokKartlari.IsVisible = false;
                lblPopUpMenuItemStokKartlari.IsVisible = false;
                btnPopUpMenuItemSatisYap.IsVisible = false;
                lblPopUpMenuItemSatisYap.IsVisible = false;
                btnPopUpMenuItemFaturalar.IsVisible = false;
                lblPopUpMenuItemFaturalar.IsVisible = false;
                btnPopUpMenuItemFiyatGor.IsVisible = false;
                lblPopUpMenuItemFiyatGor.IsVisible = false;
                popupMenuBackBox.HeightRequest = 55;
            }*/
            #endregion
        }

        private void btnpopupMenuReturnBack_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btnToolbarOpenpopup_Clicked(object sender, EventArgs e)
        {
            btnPopUpMenu_Clicked(null, null);
        }
        private void btnToolbarRefesh_Clicked(object sender, EventArgs e)
        {

        }

        private void btnToolbarOpenUserPopup_Clicked(object sender, EventArgs e)
        {
            userSettingsView.CancelAnimations();
            if (!btnpopupMenuReturnBackground.IsVisible)
            {
                btnpopupMenuReturnBackground.IsVisible = true;
                btnpopupMenuReturnBack.IsVisible = true;
                userSettingsView.TranslateTo(0, -45, _popuptimer);
            }
            else
            {
                btnpopupMenuReturnBackground.IsVisible = false;
                btnpopupMenuReturnBack.IsVisible = false;
                userSettingsView.TranslateTo(0, -300, _popuptimer);
            }
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
                        TextColor=Color.FromHex(_textColor),
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.StartAndExpand
                    },
                    new Label
                    {
                        Text=_firma,
                        TextColor=Color.FromHex(_textColor),
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.CenterAndExpand
                    },
                    new Label
                    {
                        Text=_aciklama,
                        TextColor=Color.FromHex(_textColor),
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
        #endregion

        #region btnAnaSayfa
        private void btnAnaSayfaFaturalar_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }

        private void btnAnaSayfaKasa_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }

        private void btnAnaSayfaBanka_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }

        private void btnAnaSayfaCekSenet_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }

        private void btnAnaSayfaSatisYap_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }

        private void btnAnaSayfaTaksitTakip_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }

        private void btnAnaSayfaStokKartlari_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }

        private void btnAnaSayfaCariHesaplar_Clicked(object sender, EventArgs e)
        {
            var bt = (ImageButton)sender;
            DisplayAlert("", bt.Source.ToString(), "ok");
        }
        #endregion

    }
}