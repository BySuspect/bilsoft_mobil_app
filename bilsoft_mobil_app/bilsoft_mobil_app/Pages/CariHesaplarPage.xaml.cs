using bilsoft_mobil_app.Helper;
using bilsoft_mobil_app.Pages.popUplar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        ObservableCollection<CariGuruplarListVeriler> pickerSearchItemsSource;
        List<string> pickerDefaultList = new List<string> { "Hepsi", "PERSONEL", "MÜŞTERİ", "TOPTANCI", "ALICI", "SATICI", "SATIŞ" };
        public CariHesaplarPage()
        {
            BindingContext = this;
            InitializeComponent();

            pickerCariListe.ItemsSource = pickerDefaultList;
            pickerCariListe.SelectedItem = "Hepsi";
            //pickerCariListe.SelectedIndex = 0;

            MainListView.Children.Clear();
            for (int i = 0; i < 10; i++)
            {
                CreateList(i);
            }
        }
        void pickerListeRefesh()
        {
            pickerDefaultList.Clear();
            pickerDefaultList.Add("Hepsi");
            foreach (var item in pickerSearchItemsSource)
            {
                pickerDefaultList.Add(item.GrupAd);
            }
            pickerCariListe.ItemsSource = pickerDefaultList;
            //pickerCariListe.SelectedIndex = 0;
        }
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

        private void btnYeniCari_Clicked(object sender, EventArgs e)
        {
            Popup popup = new CariEklePopup();
            App.Current.MainPage.Navigation.ShowPopup(popup);
        }

        private async void btnGruplar_Clicked(object sender, EventArgs e)
        {
            Popup popup = new CariGruplarPopup();
            object res = await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
            pickerSearchItemsSource = res as ObservableCollection<CariGuruplarListVeriler>;
            pickerListeRefesh();
        }

        private void pickerCariListe_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void pickerCariListe_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}