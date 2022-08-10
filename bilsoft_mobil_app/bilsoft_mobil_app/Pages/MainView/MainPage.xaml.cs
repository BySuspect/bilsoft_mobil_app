using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.MainView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : FlyoutPage
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public new Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
        public Color NavBarColor { get; set; } = Color.FromHex(AppThemeColors._navbarcolor);

        #endregion
        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            FlyoutPage.MenulistView.ItemSelected += (sender, e) =>
            {
                var item = e.SelectedItem as MainPageFlyoutMenuItem;
                if (item == null)
                {
                    FlyoutPage.MenulistView.SelectedItem = null;/**/
                    return;
                }

                if (item.name != null)
                {
                    FlyoutPage.MenulistView.SelectedItem = null;/**/
                    return;
                }
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;

                Detail = new NavigationPage(page)
                {
                    BarBackgroundColor = Color.FromHex(AppThemeColors._toolbarcolor)
                };
                IsPresented = false;

                FlyoutPage.MenulistView.SelectedItem = null;/**/
            };
        }
    }
}