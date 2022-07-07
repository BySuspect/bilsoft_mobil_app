using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FaturalarPage : ContentPage
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
        public FaturalarPage()
        {
            //BindingContext = this;
            InitializeComponent();
            BindingContext = new ListViewModel();
            //MainListView.Children.Clear();
            for (int i = 0; i < 10; i++)
            {
                CreateList(i);
            }
        }

        private void AcButton_Clicked(object sender, EventArgs e)
        {

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
                        FontSize = 18,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Margin = new Thickness(-5,-10,-5,1),
                        FormattedText = new FormattedString
                        {
                            Spans =
                            {
                                new Span
                                {
                                    Text = "Ünvan: ",
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

            //Stok Adı
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
                                    Text = "Tutar: ",
                                    TextColor = Color.LightGray,
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text = "1179,4"
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
                Text = "Tahsilat: "
            };

            //Bakiye
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
                                    Text = "Kalan: ",
                                    TextColor = Color.LightGray,
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text="0"
                                }
                            }
                        }
                    }
                }
            };

            //Fiyat
            Label lblfiyat = new Label
            {
                FontSize = 16,
                TranslationY = -10,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.FromHex(AppThemeColors._money),
                BackgroundColor = Color.FromHex(AppThemeColors._moneyBackground),
                Text = "1.179,40₺"
            };

            //Stok ac
            ImageButton btnAc = new ImageButton
            {
                AutomationId = "STOKAC" + count,
                Source = "search24px.png",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                CornerRadius = 15,
                BackgroundColor = Color.FromHex(AppThemeColors._success),
                HeightRequest = 35,
                Padding = new Thickness(5),
            };
            btnAc.Clicked += AcButton_Clicked;

            //Ekleme
            mainStacklayout.Children.Add(titlelayout);
            mainStacklayout.Children.Add(new BoxView { Color = Color.FromHex(AppThemeColors._borderColor), HeightRequest = 1, Margin = new Thickness(-20, 0) });
            mainStacklayout.Children.Add(ListGrid);
            ListGrid.Children.Add(stokadlayout, 0, 0);
            ListGrid.Children.Add(lblFiyat, 1, 0);
            ListGrid.Children.Add(bakiyelayout, 0, 1);
            ListGrid.Children.Add(lblfiyat, 1, 1);
            ListGrid.Children.Add(btnAc, 1, 0);
            Grid.SetRowSpan(btnAc, 2);
            mainFrame.Content = mainStacklayout;
            //MainListView.Children.Add(mainFrame);
        }
        private class ListViewModel : INotifyPropertyChanged
        {
            #region renk Bindleri
            public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
            public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
            public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
            public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
            public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
            public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
            #endregion
            public ObservableCollection<FaturaListVeriler> MenuItems { get; set; }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}