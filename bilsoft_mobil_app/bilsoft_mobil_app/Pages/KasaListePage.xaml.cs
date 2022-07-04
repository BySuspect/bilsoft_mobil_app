using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KasaListePage : ContentPage
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
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);

        #endregion

        #region popUp Menu Veriler
        UInt16 _popuptimer = 200;
        string openedPopUp;
        #endregion
        public KasaListePage()
        {
            BindingContext = this;
            InitializeComponent();

            MainListView.Children.Clear();

            for (int i = 0; i < 10; i++)
            {
                CreateList(i);
            }
        }
        private void ListDeleteButton_Clicked(object sender, EventArgs e)
        {

        }
        private void ListAcButton_Clicked(object sender, EventArgs e)
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
                                    Text = (count + 1)+"." ,
                                    FontSize = 18
                                }
                            }
                        }
                    },
                    new Label
                    {
                        FontSize = 18,
                        TextColor = Color.FromHex(AppThemeColors._textColor),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        Margin = new Thickness(-50, -10, 0, 1),
                        FormattedText = new FormattedString
                        {
                            Spans =
                            {
                                new Span
                                {
                                    Text = "Varsayılan Kasa"
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
                new RowDefinition { Height = new GridLength(35) }
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
                                    Text = "Açıklama: ",
                                    TextColor = Color.LightGray,
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text = "Kasa"
                                }
                            }
                        }
                    }
                }
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
                                    Text = "Bakiye: ",
                                    TextColor = Color.LightGray,
                                    FontSize = 12
                                },
                                new Span
                                {
                                    Text="0,0₺"
                                }
                            }
                        }
                    }
                }
            };

            //Stok ac
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
            btnStokAc.Clicked += ListAcButton_Clicked;

            //edit
            ImageButton btnEdit = new ImageButton
            {
                AutomationId = "LISTEAC" + count,
                Source = "edit32px.png",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                CornerRadius = 15,
                BackgroundColor = Color.Red,
                HeightRequest = 35,
                Padding = new Thickness(5),
            };
            btnEdit.Clicked += ListDeleteButton_Clicked;

            //Ekleme
            mainStacklayout.Children.Add(titlelayout);
            mainStacklayout.Children.Add(new BoxView { Color = Color.FromHex(AppThemeColors._borderColor), HeightRequest = 1, Margin = new Thickness(-20, 0) });
            mainStacklayout.Children.Add(ListGrid);
            ListGrid.Children.Add(stokadlayout, 0, 0);
            ListGrid.Children.Add(bakiyelayout, 0, 1);
            ListGrid.Children.Add(btnStokAc, 1, 0);
            ListGrid.Children.Add(btnEdit, 1, 1);
            mainFrame.Content = mainStacklayout;
            MainListView.Children.Add(mainFrame);
        }

        #region popup voidler
        private void btnPopUpMenu_Clicked(object sender, EventArgs e)
        {
            //Menü arka button heightrequestler sırayla
            //55-80-120-160-200-240-280-320-370
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
            string[] dactionbtns = APIHelper.logindonemYil.ToArray<string>();
            var result = await DisplayActionSheet("Seçili Dönem: " + APIHelper.secilenlogindonemYil, "İptal", null, dactionbtns);
            if (result != "İptal" && result != null)
            {

            }
        }

        private void btnToolbarOpenUserPopup_Clicked(object sender, EventArgs e)
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

        private void toolbarPopupbtnLogout_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            Navigation.PushModalAsync(new LoginPage());
        }
        #endregion
    }
}