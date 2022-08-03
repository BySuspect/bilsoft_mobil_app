using Android.App;
using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Helper.JSONHelpers.RootCari;
using bilsoft_mobil_app.Helper.Veriler;
using bilsoft_mobil_app.Pages.CariHesaplar;
using bilsoft_mobil_app.Pages.popUplar;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APIHelper = bilsoft_mobil_app.Helper.API.APIHelper;
using APIResponse = bilsoft_mobil_app.Helper.API.APIResponse;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CariHesaplarPage : ContentPage
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


        ObservableCollection<CariHesaplarPickerItems> _pickerlistItemsSource = new ObservableCollection<CariHesaplarPickerItems>();
        ObservableCollection<CariHesaplarListItems> _listItemsSource = new ObservableCollection<CariHesaplarListItems>();


        #region main
        public CariHesaplarPage()
        {

            //Test Verileri
            APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI4OCIsInVuaXF1ZV9uYW1lIjoiMGMwNjNmY2QtNWY2Mi00Y2MzLTk4ODAtOWE5ZTg3N2Q5ZjllIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NTk1MDY0NzEsImV4cCI6MTY1OTU0OTY2OCwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.WDWTKuPCOBFisIp6qMg9oaGM8UlO52BFRBsMKL0puVw";
            APIHelper.kullaniciAdi = "demo";
            APIHelper.subeAd = "merkez";
            //Test Verileri End

            popupResultHelper.cariGrupPopupListHelper.AddRange(new string[] { "Hepsi", "PERSONEL", "MÜŞTERİ", "TOPTANCI", "ALICI", "SATICI", "SATIŞ" });
            BindingContext = this;
            InitializeComponent();
            pickerCariListe.SelectedIndex = 0;
            //pickerCariListe.SelectedItem = "Hepsi";
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await GetAllData();
        }
        public IEnumerable pickerItemsSource
        {
            get
            {
                return popupResultHelper.cariGrupPopupListHelper;
            }
            set
            {
                popupResultHelper.cariGrupPopupListHelper = value as List<string>;
                pickerCariListe.ItemsSource = value as List<string>;
            }
        }

        //Kullanım dışı
        //void pickerListeRefesh()
        //{
        //    popupResultHelper.cariGrupPopupListHelper.Clear();
        //    popupResultHelper.cariGrupPopupListHelper.Add("Hepsi");
        //    foreach (var item in popupResultHelper.cariGrupPopupListHelper)
        //    {
        //        popupResultHelper.cariGrupPopupListHelper.Add(item);
        //    }
        //    pickerCariListe.ItemsSource = popupResultHelper.cariGrupPopupListHelper;
        //    pickerCariListe.SelectedIndex = 0;
        //}
        private async void CariEditButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;

            var _list = new List<CariHesaplarListItems>();
            foreach (var item in _listItemsSource)
            {
                if (item.btnId == btn.AutomationId)
                {
                    _list.Add(item);
                    break;
                }
            }

            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            await Navigation.PushAsync(new CariEklePage("Edit", _list), true);
            //Popup popup = new CariEklePopup("Yeni", null);
            //await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
            GetAllData();
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }
        private void CariAcButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;
        }
        private async void btnYeniCari_Clicked(object sender, EventArgs e)
        {
            Loodinglayout.IsVisible = true;
            LoodingActivity.IsRunning = true;
            await Navigation.PushAsync(new CariEklePage("Yeni", null), true);
            //Popup popup = new CariEklePopup("Yeni", null);
            //await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
            GetAllData();
            Loodinglayout.IsVisible = false;
            LoodingActivity.IsRunning = false;
        }

        private async void btnGruplar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Popup popup = new CariGruplarPopup();
                await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
                GetAllData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pickerCariListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (pickerCariListe.SelectedItem)
            {
                case "Hepsi":
                    CariListView.ItemsSource = _listItemsSource;
                    break;

                default:
                    if (pickerCariListe.SelectedItem != null)
                        CariListView.ItemsSource = new ObservableCollection<CariHesaplarListItems>(_listItemsSource.Where(x => x.grup.ToLower().StartsWith(pickerCariListe.SelectedItem.ToString().ToLower())).ToList());
                    break;
            }
        }

        private async void btnMahsupFisi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CariHesapMahsupFisiPage(), true);
        }

        private async void btnRaporlar_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayActionSheet("Raporlar", "iptal", "iptal", new string[] { "Cari Ekstre", "Cari İşlem Raporu", "Cari Rapor", "BA-BS Raporu", "Cari Mutabakat Raporu" });
            switch (res)
            {
                case "Cari Ekstre":
                    break;

                case "Cari İşlem Raporu":
                    break;

                case "Cari Rapor":
                    break;

                case "BA-BS Raporu":
                    break;

                case "Cari Mutabakat Raporu":
                    break;

                default:
                    break;
            }
        }
        private async Task GetAllData()
        {
            try
            {
                Loodinglayout.IsVisible = true;
                LoodingActivity.IsRunning = true;

                RestClient client;
                RestRequest request;


                _pickerlistItemsSource.Clear();
                popupResultHelper.cariGrupPopupListHelper.Clear();
                popupResultHelper.cariGrupPopupListHelper.Add("Hepsi");

                CariListView.ItemsSource = null;
                _listItemsSource.Clear();

                #region CariAdresler //Kapalı
                //client = new RestClient(APIHelper.url + APIHelper.CariAdresApi + apiTypes.getall);
                //request = new RestRequest();
                //request.AddHeader("Authorization", APIHelper.loginToken);
                //request.AddHeader("Content-Type", "application/json");
                //var resCariAdresler = await client.ExecuteAsync(request, Method.Post);
                //var dataCariAdresler = JsonConvert.DeserializeObject<RootCariAdressler>(resCariAdresler.Content);

                //Yanlis listeleme
                //for (int i = 0; i < dataCariAdresler.data.Count; i++)
                //{
                //    _listItemsSource.Add(new CariHesaplarListItems
                //    {
                //        btnID = "btn" + i,
                //        yetkili = dataCariAdresler.data[i].yetkili,
                //        cariId = dataCariAdresler.data[i].cariId,
                //        id = dataCariAdresler.data[i].id,
                //        cep = dataCariAdresler.data[i].cep,
                //        tel = dataCariAdresler.data[i].tel,
                //        ulke = dataCariAdresler.data[i].ulke,
                //        il = dataCariAdresler.data[i].il,
                //        ilce = dataCariAdresler.data[i].ilce,
                //        sevkAdres = dataCariAdresler.data[i].sevkAdres,
                //        cariKart = dataCariAdresler.data[i].cariKart,
                //        mail = dataCariAdresler.data[i].mail,
                //        postaKodu = dataCariAdresler.data[i].postaKodu,
                //        Bakiye = "---------₺",
                //        CariAd = "---------",
                //        SIRA = i + 1
                //    });
                //}

                #endregion

                #region CariBanka //Kapalı
                //client = new RestClient(APIHelper.url + APIHelper.CariBankaApi + apiTypes.getall);
                //request = new RestRequest();
                //request.AddHeader("Authorization", APIHelper.loginToken);
                //request.AddHeader("Content-Type", "application/json");
                //var resCariBanka = await client.ExecuteAsync(request, Method.Post);
                //var dataCariBanka = JsonConvert.DeserializeObject<RootCariBanka>(resCariBanka.Content);
                #endregion

                #region CariGrup
                client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariGrupApi + APIHelper.apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariGrup = await client.ExecuteAsync(request, Method.Post);
                var dataCariGrup = JsonConvert.DeserializeObject<RootCariGrup>(resCariGrup.Content);

                for (int i = 0; i < dataCariGrup.data.Count(); i++)
                {
                    _pickerlistItemsSource.Add(new CariHesaplarPickerItems
                    {
                        grupAd = dataCariGrup.data[i].grup,
                        ID = dataCariGrup.data[i].id,
                        kullaniciAd = dataCariGrup.data[i].kullaniciAdi,
                        subeAd = dataCariGrup.data[i].subeAdi
                    });
                }

                _pickerlistItemsSource = new ObservableCollection<CariHesaplarPickerItems>(_pickerlistItemsSource.OrderBy(i => i.ID));

                foreach (var item in _pickerlistItemsSource)
                {
                    popupResultHelper.cariGrupPopupListHelper.Add(item.grupAd);
                }

                #endregion

                #region CariIsl //Apide kapalı
                //client = new RestClient(APIHelper.url + APIHelper.CariIslApi + apiTypes.getall);
                //request = new RestRequest();
                //request.AddHeader("Authorization", APIHelper.loginToken);
                //request.AddHeader("Content-Type", "application/json");
                //var resCariIsl = await client.ExecuteAsync(request, Method.Post);
                //var dataCariIsl = JsonConvert.DeserializeObject<RootCariIsl>(resCariIsl.Content);
                #endregion

                #region CariKartlar
                client = new RestClient(APIHelper.url + APIHelper.CariApiler.CariKartApi + APIHelper.apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariKartlar = await client.ExecuteAsync(request, Method.Post);
                var dataCariKartlar = JsonConvert.DeserializeObject<RootCariKartlar>(resCariKartlar.Content);

                string test = "";

                for (int i = 0; i < dataCariKartlar.data.Count; i++)
                {
                    if (dataCariKartlar.data[i].grup == null) dataCariKartlar.data[i].grup = dataCariKartlar.data[i].yetkili + "=Null";
                    test += dataCariKartlar.data[i].grup + "\n";
                    _listItemsSource.Add(new CariHesaplarListItems
                    {
                        id = dataCariKartlar.data[i].id,
                        bakiye = "#₺",
                        btnId = "btn&" + i,
                        SIRA = i + 1,
                        adres = dataCariKartlar.data[i].adres,
                        cariad = dataCariKartlar.data[i].faturaUnvan,
                        cariKod = dataCariKartlar.data[i].cariKod,
                        cep = dataCariKartlar.data[i].cep,
                        faturaAdres = dataCariKartlar.data[i].faturaAdres,
                        faturaIl = dataCariKartlar.data[i].faturaIl,
                        faturaIlce = dataCariKartlar.data[i].faturaIlce,
                        faturaUnvan = dataCariKartlar.data[i].faturaUnvan,
                        fax = dataCariKartlar.data[i].fax,
                        grup = dataCariKartlar.data[i].grup,
                        mail = dataCariKartlar.data[i].mail,
                        kullaniciAdi = dataCariKartlar.data[i].kullaniciAdi,
                        postakodu = dataCariKartlar.data[i].postakodu,
                        riskIslemi = dataCariKartlar.data[i].riskIslemi,
                        riskLimiti = dataCariKartlar.data[i].riskLimiti,
                        sevkAdresi = dataCariKartlar.data[i].sevkAdresi,
                        subeAdi = dataCariKartlar.data[i].subeAdi,
                        tel = dataCariKartlar.data[i].tel,
                        ticaretsicilno = dataCariKartlar.data[i].ticaretsicilno,
                        vergiDairesi = dataCariKartlar.data[i].vergiDairesi,
                        vergiNo = dataCariKartlar.data[i].vergiNo,
                        webAdresi = dataCariKartlar.data[i].webAdresi,
                        yetkili = dataCariKartlar.data[i].yetkili,
                        varsayilanVadeGunu = dataCariKartlar.data[i].varsayilanVadeGunu,
                        faturaUlke = dataCariKartlar.data[i].faturaUlke,
                    });
                }

                ///test içindi
                //await DisplayAlert("", test, "Ok");
                #endregion


                //List<object> test = new List<object>();
                //test.Add(dataCariKartlar);
                //test.Add(dataCariAdresler);
                //test.Add(dataCariBanka);
                //test.Add(dataCariGrup);

                /**/

                pickerItemsSource = new List<string>(popupResultHelper.cariGrupPopupListHelper);
                pickerCariListe.SelectedIndex = 0;
                CariListView.ItemsSource = _listItemsSource;

                Loodinglayout.IsVisible = false;
                LoodingActivity.IsRunning = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.InnerException + "\n" + ex.Data);
                Console.WriteLine("");
                Console.WriteLine("");

                throw new Exception(ex.Message);
            }

        }


        #endregion
        /*Old Create List
        void CreateList(int count)
        {

            //Main Frame
            Frame mainFrame = new Frame
            {
                CornerRadius = 15,
                BackgroundColor = Color.FromHex(AppThemeColors._backgroundColor),
                BorderColor = Color.FromHex(AppThemeColors._borderColor),
                Margin = new Thickness(-15, 0, -15, 0),
            };

            //Main StackLayout
            StackLayout mainStacklayout = new StackLayout();
            Label lblCount = new Label
            {
                Text = (count + 1) + ".",
                FontSize = 18,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(-5, -10, -5, -5)
            };

            //List Grid
            Grid ListGrid = new Grid
            {
                RowDefinitions =
                {
                new RowDefinition { Height = new GridLength(25) }
                },
                ColumnDefinitions =
                {
                new ColumnDefinition(){ Width = GridLength.Star},
                new ColumnDefinition(){ Width = new GridLength(135)}
                }
            };

            //Cari Adı
            FormattedString caristring = new FormattedString
            {
                Spans =
                {
                    new Span
                    {
                        Text="Cari Adı: ",
                        TextColor=Color.LightGray,
                        FontSize=12
                    },
                    new Span
                    {
                        Text="Mutlu Market"
                    }
                }
            };
            StackLayout cariadlayout = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        FontSize = 16,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        FormattedText = caristring
                    }
                }
            };

            //Bakiye text Label
            Label lblbakiyetext = new Label
            {
                FontSize = 12,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Text = "Bakiye: "
            };

            //Para Label
            Label lblpara = new Label
            {
                FontSize = 12,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Text = "1.254.125.125,43₺",
                BackgroundColor = Color.Green,
                TranslationY = -10
            };

            //Cari Adı
            FormattedString yetkilistring = new FormattedString
            {
                Spans =
                {
                    new Span
                    {
                        Text="Yetkili Adı: ",
                        TextColor=Color.LightGray,
                        FontSize=12
                    },
                    new Span
                    {
                        Text="Veli Mutlu"
                    }
                }
            };
            StackLayout yetkiliadlayout = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        FontSize = 16,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        FormattedText = yetkilistring
                    }
                }
            };


            //Sabit Tel
            FormattedString sabittelstring = new FormattedString
            {
                Spans =
                {
                    new Span
                    {
                        Text="Sabit Tel: ",
                        TextColor=Color.LightGray,
                        FontSize=12
                    },
                    new Span
                    {
                        Text="0212 222 43 23"
                    }
                }
            };
            StackLayout sabitTellayout = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        FontSize = 16,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        FormattedText = sabittelstring
                    }
                }
            };

            //Edit Buttıon
            Button btncariedit = new Button
            {
                AutomationId = "CARIEDIT" + count,
                Text = "Düzenle",
                ImageSource = "info24px.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                CornerRadius = 15,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                BorderColor = Color.FromHex(AppThemeColors._borderColor),
                BorderWidth = 1,
                BackgroundColor = Color.Transparent,
                HeightRequest = 25,
                Padding = new Thickness(5, 0, 10, 0)
            };

            //Cep Tel
            StackLayout cepTellayout = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        FontSize = 16,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        FormattedText = new FormattedString
                        {
                            Spans =
                            {
                                new Span
                                {
                                    Text="Cep Tel: ",
                                    TextColor=Color.LightGray,
                                    FontSize=12
                                },
                                new Span
                                {
                                    Text="0543 232 41 26"
                                }
                            }
                        }
                    }
                }
            };

            //Cariyi ac button
            Button btncariac = new Button
            {
                AutomationId = "CARIAC" + count,
                Text = "Cariyi Aç",
                ImageSource = "info24px.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                CornerRadius = 15,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                BackgroundColor = Color.FromHex(AppThemeColors._success),
                BorderColor = Color.FromHex(AppThemeColors._borderColor),
                BorderWidth = 1,
                HeightRequest = 25,
                Padding = new Thickness(5, 0, 10, 0)
            };

            //Ekleme
            btncariac.Clicked += CariAcButton_Clicked;
            btncariedit.Clicked += CariEditButton_Clicked;
            ListGrid.Children.Add(cariadlayout, 0, 0);
            ListGrid.Children.Add(yetkiliadlayout, 0, 1);
            ListGrid.Children.Add(lblbakiyetext, 1, 0);
            ListGrid.Children.Add(lblpara, 1, 1);
            ListGrid.Children.Add(sabitTellayout, 0, 2);
            ListGrid.Children.Add(btncariedit, 1, 2);
            ListGrid.Children.Add(cepTellayout, 0, 3);
            ListGrid.Children.Add(btncariac, 1, 3);
            mainStacklayout.Children.Add(lblCount);
            mainStacklayout.Children.Add(ListGrid);
            mainFrame.Content = mainStacklayout;
            MainListView.Children.Add(mainFrame);
        }
        /**/

        #region Test Area
        private async void Button_Clicked(object sender, EventArgs e)
        {

        }
        #endregion

    }
}