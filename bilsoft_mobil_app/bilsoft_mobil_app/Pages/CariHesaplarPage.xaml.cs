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
        public CariHesaplarPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;
        }
        private void CariAcButton_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var test = btn.AutomationId;
        }
        async Task CreateList(int count)
        {
            MainListView.Children.Clear();

            //Main Frame
            Frame mainFrame = new Frame
            {
                CornerRadius = 15,
                BackgroundColor = Color.FromHex(AppThemeColors._backgroundColor),
                BorderColor = Color.FromHex(AppThemeColors._borderColor),
                Margin = new Thickness(-15, 0, -15, 0)
            };

            //Main StackLayout
            StackLayout mainStacklayout = new StackLayout();
            Label Count = new Label
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
                new RowDefinition { Height = new GridLength(50) }
                },
                ColumnDefinitions =
                {
                new ColumnDefinition(),
                new ColumnDefinition(){ Width = new GridLength(135)}
                }
            };

            //Cari Adı
            StackLayout cariadlayout = new StackLayout();
            cariadlayout.Children.Add(new Label
            {
                FontSize = 16,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                FormattedText =
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
                }
            });

            //Bakiye text Label
            Label lblbakiyetext = new Label
            {
                FontSize=12,
                TextColor=Color.FromHex(AppThemeColors._textColor),
                Text="Bakiye: "
            };

            //Para Label
            Label lblpara = new Label
            {
                FontSize = 12,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                Text = "1.254.125.125,43₺"
            };

            //Cari Adı
            StackLayout yetkiliadlayout = new StackLayout();
            cariadlayout.Children.Add(new Label
            {
                FontSize = 16,
                TextColor = Color.FromHex(AppThemeColors._textColor),
                FormattedText =
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
                            Text="Hasan Mutlu"
                        }
                    }
                }
            });


            MainListView.Children.Add(mainFrame);
        }
    }
}