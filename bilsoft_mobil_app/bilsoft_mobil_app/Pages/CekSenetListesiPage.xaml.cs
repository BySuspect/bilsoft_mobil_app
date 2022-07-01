using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CekSenetListesiPage : ContentPage
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
        public CekSenetListesiPage()
        {
            BindingContext = this;
            InitializeComponent();
            pickerArama.ItemsSource = new List<string> { "Tarihi Eskiden Yeniye", "Tarihi Yeniden Eskiye", "Vade Eskiden Yeniye", "Vade Yeniden Eskiye" };
            MainListView.Children.Clear();
            for (int i = 0; i < 10; i++)
            {
                CreateList(i);
            }
        }

        private void pickerCariListe_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            //Title
            StackLayout titlelayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label
                    {
                        Text = (count + 1) + ".",
                        FontSize = 18,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalOptions = LayoutOptions.Start,
                        Margin = new Thickness(-5, -10, -5, -5)
                    },
                    new Label
                    {
                        FontSize = 18,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Margin = new Thickness(0, -10, 0, 1),
                        FormattedText = new FormattedString
                        {
                            Spans =
                            {
                                new Span
                                {
                                    Text = "Durumu: ",
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text = "BEKLEMEDE"
                                }
                            }
                        }
                    }
                }
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

            //Adı
            StackLayout stokadlayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
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
                                    Text = "Firma: ",
                                    TextColor = Color.LightGray,
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text = "Sancak İletişim"
                                }
                            }
                        }
                    }
                }
            };

            //Fiyat
            Label lblFiyat = new Label
            {
                FontSize = 12,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Text = "Tutar: "
            };

            //Tarih
            StackLayout bakiyelayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
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
                                    Text = "Tarih: ",
                                    TextColor = Color.LightGray,
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text="30.06.2022"
                                }
                            }
                        }
                    }
                }
            };

            //Vade
            StackLayout Vadelayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
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
                                    Text = "Vade: ",
                                    TextColor = Color.LightGray,
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text="30.06.2022"
                                }
                            }
                        }
                    }
                }
            };

            //Tutar
            Label lblfiyat = new Label
            {
                FontSize = 16,
                TranslationY = -10,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.FromHex(AppThemeColors._money),
                BackgroundColor = Color.FromHex(AppThemeColors._moneyBackground),
                Text = "200000"
            };

            //ac button
            ImageButton btnStokAc = new ImageButton
            {
                AutomationId = "LISTEAC" + count,
                Source = "search24px.png",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                CornerRadius = 15,
                BackgroundColor = Color.FromHex(AppThemeColors._success),
                HeightRequest = 35,
                Padding = new Thickness(5),
            };

            //Ekleme
            mainStacklayout.Children.Add(titlelayout);
            mainStacklayout.Children.Add(new BoxView { Color = Color.FromHex(AppThemeColors._borderColor), HeightRequest = 1, Margin = new Thickness(-20, 0) });
            mainStacklayout.Children.Add(ListGrid);
            ListGrid.Children.Add(stokadlayout, 0, 0);
            ListGrid.Children.Add(lblFiyat, 1, 0);
            ListGrid.Children.Add(bakiyelayout, 0, 1);
            ListGrid.Children.Add(lblfiyat, 1, 1);
            ListGrid.Children.Add(Vadelayout, 0, 2);
            ListGrid.Children.Add(btnStokAc, 1, 0);
            Grid.SetRowSpan(btnStokAc, 3);
            mainFrame.Content = mainStacklayout;
            MainListView.Children.Add(mainFrame);
        }
    }
}