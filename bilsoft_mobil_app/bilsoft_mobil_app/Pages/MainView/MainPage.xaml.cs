using bilsoft_mobil_app.Helper;
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
        public MainPage()
        {
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