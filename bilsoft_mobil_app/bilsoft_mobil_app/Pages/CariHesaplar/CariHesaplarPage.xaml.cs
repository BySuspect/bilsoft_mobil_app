﻿using bilsoft_mobil_app.Helper.API;
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

        List<string> pickerList = new List<string> { "Hepsi", "PERSONEL", "MÜŞTERİ", "TOPTANCI", "ALICI", "SATICI", "SATIŞ" };

        ObservableCollection<CariHesaplarListItems> _listItemsSource = new ObservableCollection<CariHesaplarListItems>();

        string _aramaType = "Hepsi";

        #region main
        public CariHesaplarPage()
        {
            BindingContext = this;
            InitializeComponent();

            pickerCariListe.ItemsSource = pickerList;
            //pickerCariListe.SelectedItem = "Hepsi";
            pickerCariListe.SelectedIndex = 0;
        }
        public IEnumerable pickerItemsSource
        {
            get
            {
                return pickerList;
            }
            set
            {
                pickerList = value as List<string>;
                pickerCariListe.ItemsSource = pickerList;
            }
        }

        //Kullanım dışı
        //void pickerListeRefesh()
        //{
        //    pickerList.Clear();
        //    pickerList.Add("Hepsi");
        //    foreach (var item in popupResultHelper.cariGrupPopupListHelper)
        //    {
        //        pickerList.Add(item);
        //    }
        //    pickerCariListe.ItemsSource = pickerList;
        //    pickerCariListe.SelectedIndex = 0;
        //}
        private void CariEditButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;
        }
        private void CariAcButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;
        }
        private async void btnYeniCari_Clicked(object sender, EventArgs e)
        {
            Popup popup = new CariEklePopup();
            await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
        }

        private async void btnGruplar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Popup popup = new CariGruplarPopup(pickerList);
                await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
                pickerItemsSource = popupResultHelper.cariGrupPopupListHelper;
                pickerCariListe.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void pickerCariListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_aramaType = pickerCariListe.SelectedItem.ToString();
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
        private void Button_Clicked(object sender, EventArgs e)
        {
            GetAllData();
        }
        private async Task GetAllData()
        {
            try
            {
                APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI5MSIsInVuaXF1ZV9uYW1lIjoiYmZmMTk0NWQtNWJkNS00OGYxLWExMWEtY2I1N2RjMDI0N2MwIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NTg5MzI0NjYsImV4cCI6MTY1ODk3NTY2NSwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.QIPWYiwGKCwJSgBePR1yPMPclQ4Iysd2tVpJ_6y8lJU";
                RestClient client;
                RestRequest request;
                CariListView.ItemsSource = null;
                _listItemsSource.Clear();

                #region CariAdresler
                client = new RestClient(APIHelper.url + APIHelper.CariAdresApi + apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariAdresler = await client.ExecuteAsync(request, Method.Post);
                var dataCariAdresler = JsonConvert.DeserializeObject<RootCariAdressler>(resCariAdresler.Content);

                for (int i = 0; i < dataCariAdresler.data.Count; i++)
                {
                    _listItemsSource.Add(new CariHesaplarListItems
                    {
                        btnID = "btn" + i,
                        yetkili = dataCariAdresler.data[i].yetkili,
                        cariId = dataCariAdresler.data[i].cariId,
                        id = dataCariAdresler.data[i].id,
                        cep = dataCariAdresler.data[i].cep,
                        tel = dataCariAdresler.data[i].tel,
                        ulke = dataCariAdresler.data[i].ulke,
                        il = dataCariAdresler.data[i].il,
                        ilce = dataCariAdresler.data[i].ilce,
                        sevkAdres = dataCariAdresler.data[i].sevkAdres,
                        cariKart = dataCariAdresler.data[i].cariKart,
                        mail = dataCariAdresler.data[i].mail,
                        postaKodu = dataCariAdresler.data[i].postaKodu,
                        Bakiye = "0₺",
                        CariAd = "cariAD",
                        SIRA = i + 1
                    });
                }

                #endregion

                #region CariBanka
                client = new RestClient(APIHelper.url + APIHelper.CariBankaApi + apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariBanka = await client.ExecuteAsync(request, Method.Post);
                var dataCariBanka = JsonConvert.DeserializeObject<RootCariBanka>(resCariBanka.Content);
                #endregion

                #region CariGrup
                client = new RestClient(APIHelper.url + APIHelper.CariGrupApi + apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariGrup = await client.ExecuteAsync(request, Method.Post);
                var dataCariGrup = JsonConvert.DeserializeObject<RootCariGrup>(resCariGrup.Content);
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
                client = new RestClient(APIHelper.url + APIHelper.CariKartApi + apiTypes.getall);
                request = new RestRequest();
                request.AddHeader("Authorization", APIHelper.loginToken);
                request.AddHeader("Content-Type", "application/json");
                var resCariKartlar = await client.ExecuteAsync(request, Method.Post);
                var dataCariKartlar = JsonConvert.DeserializeObject<RootCariKartlar>(resCariKartlar.Content);
                #endregion


                List<object> test = new List<object>();
                test.Add(dataCariKartlar);
                test.Add(dataCariAdresler);
                test.Add(dataCariBanka);
                test.Add(dataCariGrup);

                /**/

                CariListView.ItemsSource = _listItemsSource;
                /*string webURL = APIHelper.loginDonemGetirAPI;
                HttpHelper httpHelper = new HttpHelper();
                APIResponse res;

                #region sunucu veri Gönderme
                await Task.Delay(100);
                res = await httpHelper.callAPI(webURL, "{}");
                // var Data = JsonConvert.DeserializeObject<RootGirisYapDonemGetir>(res.data.ToString());
                #endregion*/

            }
            catch
            {
            }

        }
        async Task<object> RequestData(string url, Method method, string token, string json)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Authorization", token);
                request.AddHeader("Content-Type", "application/json");
                return await client.ExecuteAsync(request, method);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}