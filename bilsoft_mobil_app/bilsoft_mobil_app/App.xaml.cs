using bilsoft_mobil_app.Pages;
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
            MainPage = new MainMDPage();

            //Test Page
            //MainPage = new MainPage();
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
