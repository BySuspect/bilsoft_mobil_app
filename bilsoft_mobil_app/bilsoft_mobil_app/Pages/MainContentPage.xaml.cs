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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
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

        #region Süresi Geçen Hatırlatma Veriler
        List<SuresiGecenListeProps> SuresiGecenHatirlatmalarListe = new List<SuresiGecenListeProps>();
        #endregion

        public MainContentPage()
        {
            InitializeComponent();
            try
            {
                #region
                set7gunlukSatisG();
                set7gunlukVadeG();
                Set7GunBankaHaraket();
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
                _7GunlukSatisGraph.Chart = new PointChart { Entries = entries7GunlukTahsilat, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse("#000000"), PointAreaAlpha = 255, PointMode = PointMode.Square, AnimationDuration = TimeSpan.FromSeconds(3), Margin = 30, BackgroundColor = SKColors.Transparent };
                _7GunlukVadeGelenGraph.Chart = new PointChart { Entries = entries7GunlukVadeGelen, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse("#000000"), PointAreaAlpha = 255, PointMode = PointMode.Square, AnimationDuration = TimeSpan.FromSeconds(3), BackgroundColor = SKColors.Transparent };
                #endregion

                #region 7 Günlük Banka Haraket Chart
                _7GunlukBankaHaraketGraph.Chart = new LineChart { Entries = entries7gunbankaharaket, IsAnimated = true, LabelTextSize = 30, LabelColor = SKColor.Parse("#000000"), PointAreaAlpha = 255, AnimationDuration = TimeSpan.FromSeconds(3), Margin = 30, LineSize = 5, PointSize = 30, EnableYFadeOutGradient = false };
                _7gunlukBankaHaraketPicker.ItemsSource = new List<string> { "Ziraat Bankası", "Garanti Bankası", "İş Bankası" };
                #endregion

                #region 7 Günlük Kasa Haraket Chart
                _7GunlukKasaHareketleriChart.Chart = new PointChart { Entries = entries7GunlukKasaHareketleri, IsAnimated = true, PointSize = 50f, LabelTextSize = 30, LabelColor = SKColor.Parse("#000000"), PointAreaAlpha = 255, PointMode = PointMode.Square, AnimationDuration = TimeSpan.FromSeconds(3), BackgroundColor = SKColors.Transparent };
                #endregion

                #region Süresi Geçen Hatırlatma Check
                SuresiGecenHatirlatmalarListeAdder();
                foreach (var item in SuresiGecenHatirlatmalarListe)
                {
                    SuresiGecenHatirlatmalarViewAdder(item.AdSoyad, item.Firma, item.Aciklama);
                }
                #endregion
            }
            catch (Exception e)
            {
                DisplayAlert("", e.Message, "ok");
            }
        }
        #region ChartVoidler
        void createChart()
        {
            try
            {
                #region Günlük Satış Entry
                entriesGunlukSatis = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(GSNakit))
            {
                Color= SKColor.Parse("#26c281")
            },

            new ChartEntry(Convert.ToInt32(GSKrediKarti))
            {
                Color= SKColor.Parse("#3598dc")
            },

            new ChartEntry(Convert.ToInt32(GSAcikHesap))
            {
                Color= SKColor.Parse("#ef4836")
            }
            };
                #endregion

                #region Günlük Alış Entry
                entriesGunlukAlis = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(GANakit))
            {
                Color= SKColor.Parse("#26c281")
            },

            new ChartEntry(Convert.ToInt32(GAKrediKarti))
            {
                Color= SKColor.Parse("#3598dc")
            },

            new ChartEntry(Convert.ToInt32(GAAcikHesap))
            {
                Color= SKColor.Parse("#ef4836")
            }
            };
                #endregion

                #region Günlük Tahsilat Entry
                entriesGunlukTahsilat = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(GTNakit))
            {
                Color= SKColor.Parse("#26c281")
            },

            new ChartEntry(Convert.ToInt32(GTKrediKarti))
            {
                Color= SKColor.Parse("#3598dc")
            },

            new ChartEntry(Convert.ToInt32(GTCek))
            {
                Color= SKColor.Parse("#ef4836")
            }
            };
                #endregion

                #region Günlük Ödeme Entry
                entriesGunlukOdeme = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(GONakit))
            {
                Color= SKColor.Parse("#26c281")
            },

            new ChartEntry(Convert.ToInt32(GOKrediKarti))
            {
                Color= SKColor.Parse("#3598dc")
            },

            new ChartEntry(Convert.ToInt32(GOCek))
            {
                Color= SKColor.Parse("#ef4836")
            }
            };
                #endregion

                #region 7 Günlük Satış Entry
                entries7GunlukTahsilat = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(_7GunSatisGMoney1))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunSatisGDay1,
                ValueLabel = _7GunSatisGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                TextColor=SKColor.Parse("#000000")
            },

            new ChartEntry(Convert.ToInt32(_7GunSatisGMoney2))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunSatisGDay2,
                ValueLabel=_7GunSatisGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                TextColor=SKColor.Parse("#000000")
            },

            new ChartEntry(Convert.ToInt32(_7GunSatisGMoney3))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunSatisGDay3,
                ValueLabel=_7GunSatisGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                TextColor=SKColor.Parse("#FFFF")
            },
            new ChartEntry(Convert.ToInt32(_7GunSatisGMoney4))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunSatisGDay4,
                ValueLabel=_7GunSatisGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                TextColor=SKColor.Parse("#FFFF")
            },
            new ChartEntry(Convert.ToInt32(_7GunSatisGMoney5))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunSatisGDay5,
                ValueLabel=_7GunSatisGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                TextColor=SKColor.Parse("#FFFF")
            },
            new ChartEntry(Convert.ToInt32(_7GunSatisGMoney6))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunSatisGDay6,
                ValueLabel=_7GunSatisGMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                TextColor=SKColor.Parse("#FFFF")
            },
            new ChartEntry(Convert.ToInt32(_7GunSatisGMoney7))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunSatisGDay7,
                ValueLabel=_7GunSatisGMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr")),
                TextColor=SKColor.Parse("#FFFF")
            }
            };
                #endregion

                #region 7 Günlük Vadesi Gelecek Entry
                entries7GunlukVadeGelen = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney1))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunVadeGDay1,
                ValueLabel= _7GunVadeTahsilatGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney1))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunVadeGDay1,
                ValueLabel=_7GunVadeOdemeGMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney2))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunVadeGDay2,
                ValueLabel=_7GunVadeTahsilatGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney2))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunVadeGDay2,
                ValueLabel=_7GunVadeOdemeGMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney3))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunVadeGDay3,
                ValueLabel=_7GunVadeTahsilatGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney3))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunVadeGDay3,
                ValueLabel=_7GunVadeOdemeGMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney4))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunVadeGDay4,
                ValueLabel=_7GunVadeTahsilatGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney4))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunVadeGDay4,
                ValueLabel=_7GunVadeOdemeGMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney5))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunVadeGDay5,
                ValueLabel=_7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney5))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunVadeGDay5,
                ValueLabel=_7GunVadeOdemeGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney6))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunVadeGDay6,
                ValueLabel=_7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney6))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunVadeGDay6,
                ValueLabel=_7GunVadeOdemeGMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeTahsilatGMoney7))
            {
                Color= SKColor.Parse("#67b4d8"),
                Label=_7GunVadeGDay7,
                ValueLabel=_7GunVadeTahsilatGMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunVadeOdemeGMoney7))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunVadeGDay7,
                ValueLabel=_7GunVadeOdemeGMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            }
            };
                #endregion

                #region 7 Günlük Banka Haraketleri Entry
                entries7gunbankaharaket = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris1))
            {
                Color= SKColors.Green,
                Label=_7GunBankaHaraketDay1,
                ValueLabel=_7GunBankaHaraketGiris1 + ""
            },

            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis1))
            {
                Color= SKColors.Red,
                Label=_7GunBankaHaraketDay1,
                ValueLabel=_7GunBankaHaraketCikis1 + ""
            },

            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris2))
            {
                Color= SKColors.Green,
                Label=_7GunBankaHaraketDay2,
                ValueLabel=_7GunBankaHaraketGiris2 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis2))
            {
                Color= SKColors.Red,
                Label=_7GunBankaHaraketDay2,
                ValueLabel=_7GunBankaHaraketCikis2 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris3))
            {
                Color= SKColors.Green,
                Label=_7GunBankaHaraketDay3,
                ValueLabel=_7GunBankaHaraketGiris3 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis3))
            {
                Color= SKColors.Red,
                Label=_7GunBankaHaraketDay3,
                ValueLabel=_7GunBankaHaraketCikis3 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris4))
            {
                Color= SKColors.Green,
                Label=_7GunBankaHaraketDay4,
                ValueLabel=_7GunBankaHaraketGiris4 + ""
            },new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis4))
            {
                Color= SKColors.Red,
                Label=_7GunBankaHaraketDay4,
                ValueLabel=_7GunBankaHaraketCikis4 + ""
            },

            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris5))
            {
                Color= SKColors.Green,
                Label=_7GunBankaHaraketDay5,
                ValueLabel=_7GunBankaHaraketGiris5 + ""
            },

            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis5))
            {
                Color= SKColors.Red,
                Label=_7GunBankaHaraketDay5,
                ValueLabel=_7GunBankaHaraketCikis5 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris6))
            {
                Color= SKColors.Green,
                Label=_7GunBankaHaraketDay6,
                ValueLabel=_7GunBankaHaraketGiris6 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis6))
            {
                Color= SKColors.Red,
                Label=_7GunBankaHaraketDay6,
                ValueLabel=_7GunBankaHaraketCikis6 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketGiris7))
            {
                Color= SKColors.Green,
                Label=_7GunBankaHaraketDay7,
                ValueLabel=_7GunBankaHaraketGiris7 + ""
            },
            new ChartEntry(Convert.ToInt32(_7GunBankaHaraketCikis7))
            {
                Color= SKColors.Red,
                Label=_7GunBankaHaraketDay7,
                ValueLabel=_7GunBankaHaraketCikis7 + ""
            }

            };
                #endregion

                #region 7 Günlük Kasa Haraketleri Entry
                entries7GunlukKasaHareketleri = new List<ChartEntry>
            {
            new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney1))
            {
                Color= SKColor.Parse("#3598dc"),
                Label=_7GunKasaHareketDay1,
                ValueLabel=_7GunlukKasaGirisMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney1))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunKasaHareketDay1,
                ValueLabel=_7GunlukKasaCikisMoney1.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney2))
            {
                Color= SKColor.Parse("#3598dc"),
                Label=_7GunKasaHareketDay2,
                ValueLabel=_7GunlukKasaGirisMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney2))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunKasaHareketDay2,
                ValueLabel=_7GunlukKasaCikisMoney2.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney3))
            {
                Color= SKColor.Parse("#3598dc"),
                Label=_7GunKasaHareketDay3,
                ValueLabel=_7GunlukKasaGirisMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney3))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunKasaHareketDay3,
                ValueLabel=_7GunlukKasaCikisMoney3.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney4))
            {
                Color= SKColor.Parse("#3598dc"),
                Label=_7GunKasaHareketDay4,
                ValueLabel=_7GunlukKasaGirisMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney4))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunKasaHareketDay4,
                ValueLabel=_7GunlukKasaCikisMoney4.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney5))
            {
                Color= SKColor.Parse("#3598dc"),
                Label=_7GunKasaHareketDay5,
                ValueLabel=_7GunlukKasaGirisMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },

            new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney5))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunKasaHareketDay5,
                ValueLabel=_7GunlukKasaCikisMoney5.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney6))
            {
                Color= SKColor.Parse("#3598dc"),
                Label=_7GunKasaHareketDay6,
                ValueLabel=_7GunlukKasaGirisMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney6))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunKasaHareketDay6,
                ValueLabel=_7GunlukKasaCikisMoney6.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaGirisMoney7))
            {
                Color= SKColor.Parse("#3598dc"),
                Label=_7GunKasaHareketDay7,
                ValueLabel=_7GunlukKasaGirisMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            },
            new ChartEntry(Convert.ToInt32(_7GunlukKasaCikisMoney7))
            {
                Color= SKColor.Parse("#faf602"),
                Label=_7GunKasaHareketDay7,
                ValueLabel=_7GunlukKasaCikisMoney7.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-tr"))
            }

            };
                #endregion
            }
            catch (Exception e)
            {
                DisplayAlert("", e.Message, "ok");
            }
        }
        void set7gunlukVadeG()
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
        void set7gunlukSatisG()
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
        void Set7GunBankaHaraket()
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
        private async void btnPopUpMenu_Clicked(object sender, EventArgs e)
        {
            if (!popupMenuBack.IsVisible)
            {
                btnPopUpMenu.ImageSource = "offmenuicon.png";
                popupMenuBackBox.HeightRequest = 120;
                popupMenuBack.IsVisible = true;
                btnpopupMenuReturnBack.IsVisible = true;
                btnPopUpMenuItemPanel.IsVisible = true;
                await Task.Delay(20);
                popupMenuBackBox.HeightRequest = 220;
                btnPopUpMenuItemAra.IsVisible = true;
                btnPopUpMenuItemCariIslem.IsVisible = true;
                await Task.Delay(20);
                popupMenuBackBox.HeightRequest = 320;
                btnPopUpMenuItemStokKartlarıi.IsVisible = true;
                btnPopUpMenuItemSatisYap.IsVisible = true;
                await Task.Delay(20);
                popupMenuBackBox.HeightRequest = 400;
                btnPopUpMenuItemFaturalar.IsVisible = true;
                btnPopUpMenuItemFiyatGor.IsVisible = true;
            }
            else
            {
                btnPopUpMenu.ImageSource = "menuicon.png";
                popupMenuBack.IsVisible = false;
                btnpopupMenuReturnBack.IsVisible = false;
                btnPopUpMenuItemAra.IsVisible = false;
                btnPopUpMenuItemCariIslem.IsVisible = false;
                btnPopUpMenuItemStokKartlarıi.IsVisible = false;
                btnPopUpMenuItemSatisYap.IsVisible = false;
                btnPopUpMenuItemFaturalar.IsVisible = false;
                btnPopUpMenuItemFiyatGor.IsVisible = false;
                popupMenuBackBox.HeightRequest = 100;
            }
        }

        private void btnpopupMenuReturnBack_Clicked(object sender, EventArgs e)
        {
            if (popupMenuBack.IsVisible)
            {
                btnPopUpMenu.ImageSource = "menuicon.png";
                popupMenuBack.IsVisible = false;
                btnpopupMenuReturnBack.IsVisible = false;
                btnPopUpMenuItemAra.IsVisible = false;
                btnPopUpMenuItemCariIslem.IsVisible = false;
                btnPopUpMenuItemStokKartlarıi.IsVisible = false;
                btnPopUpMenuItemSatisYap.IsVisible = false;
                btnPopUpMenuItemFaturalar.IsVisible = false;
                btnPopUpMenuItemFiyatGor.IsVisible = false;
                popupMenuBackBox.HeightRequest = 100;
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
                        TextColor=Color.Black,
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.StartAndExpand
                    },
                    new Label
                    {
                        Text=_firma,
                        TextColor=Color.Black,
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.CenterAndExpand
                    },
                    new Label
                    {
                        Text=_aciklama,
                        TextColor=Color.Black,
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
                Color = Color.LightGray,
                VerticalOptions =
                LayoutOptions.Start
            });
        }
        private void btnSureGecenHatirlatmaKapat_Clicked(object sender, EventArgs e)
        {
            SuresiGecenHatirlatmaView.IsVisible = false;
        }

        #endregion

        #region btnAnaSayfa
        private void btnAnaSayfaFaturalar_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }

        private void btnAnaSayfaKasa_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }

        private void btnAnaSayfaBanka_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }

        private void btnAnaSayfaCekSenet_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }

        private void btnAnaSayfaSatisYap_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }

        private void btnAnaSayfaTaksitTakip_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }

        private void btnAnaSayfaStokKartlari_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }

        private void btnAnaSayfaCariHesaplar_Clicked(object sender, EventArgs e)
        {
            var bt = (Button)sender;
            DisplayAlert("", bt.Text, "ok");
        }
        #endregion

    }
}