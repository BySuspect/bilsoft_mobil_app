using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Pages
{
    [Obsolete]
    internal class MainMDPage : MasterDetailPage
    {
        public MainMDPage(string mod, string page)
        {
            this.Master = new MainMenuPage();
            switch (page)
            {
                case "index":
                    goto default;
                default:
                    Detail = new NavigationPage(new MainContentPage(mod, mod))
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;
            }
        }
    }
}
