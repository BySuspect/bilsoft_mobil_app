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
                case "CariHesaplar":
                    Detail = new NavigationPage(new CariHesaplarPage())
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;

                case "StokKartlari":
                    Detail = new NavigationPage(new StokKartlariPage())
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;

                case "TaksitTakip":
                    Detail = new NavigationPage(new TaksitListesiPage())
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;

                case "SatisYap":
                    Detail = new NavigationPage(new SatisYapPage())
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;

                case "CekSenetListe":
                    Detail = new NavigationPage(new CekSenetListesiPage())
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;

                case "BankaListe":
                    Detail = new NavigationPage(new BankaPage())
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;

                case "KasaListe":
                    Detail = new NavigationPage(new KasaListePage())
                    {
                        BarTextColor = Color.FromHex("#ffccff"),
                        //BarBackgroundColor = Color.Transparent
                        BarBackgroundColor = Color.FromHex("#ffa600")
                    };
                    break;

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
