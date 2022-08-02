using bilsoft_mobil_app.Pages;
using bilsoft_mobil_app.Pages.CariHesaplar;
using bilsoft_mobil_app.Pages.MainView;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app
{
    public partial class App : Application
    {
        [Obsolete]
        public App()
        {
            InitializeComponent();

            //Giriş
            //MainPage = new LoginPage();

            //Ana Sayfa
            //MainPage = new MainMDPage("demo","index",null);

            //Ana Sayfa 2. tip
            /*MainPage= new NavigationPage(new MainContentPage("demo", "demo"))
            {
                BarTextColor = Color.FromHex("#ffffff"),
                //BarBackgroundColor = Color.Transparent
                BarBackgroundColor = Color.FromHex("#ffa600")
            };/**/

            //Ana Sayfa 3. tip
            //MainPage = new MainPage();

            //Test Page
            //MainPage = new TestPage();
            MainPage = new NavigationPage(new CariHesaplarPage())
            {
                BarTextColor = Color.FromHex("#ffffff"),
                //BarBackgroundColor = Color.Transparent
                BarBackgroundColor = Color.FromHex("#ffa600")
            };/**/
        }
        public void SetMainPage(Page rootPage)
        {
            MainPage = rootPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
