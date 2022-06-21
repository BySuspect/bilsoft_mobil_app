using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Pages
{
    [Obsolete]
    internal class MainMDPage : MasterDetailPage
    {
        public MainMDPage()
        {
            this.Master = new MainMenuPage();
            Detail = new NavigationPage(new MainContentPage())
            {
                BarTextColor = Color.FromHex("#ffccff"),
                BarBackgroundColor = Color.FromHex("#440c4d")
            };
        }
    }
}
