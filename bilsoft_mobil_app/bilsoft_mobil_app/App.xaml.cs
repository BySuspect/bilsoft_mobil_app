using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.Pages;
using bilsoft_mobil_app.Pages.Ajanda;
using bilsoft_mobil_app.Pages.CariHesaplar;
using bilsoft_mobil_app.Pages.MainView;
using bilsoft_mobil_app.TestArea;
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

            /*
             * --ana sayfa yenilenicek 
             * loginde girişte uygulama çöküyor bakılacak
             * cariyi incele kısmı yapılıcak
             * ana sayfadaki hatırlatma yapılacak
             */

            ////Test Verileri
            //APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI4OCIsInVuaXF1ZV9uYW1lIjoiMjU4MzRmZDQtOTAzMS00NmFkLWIxNTQtNTBlODY0ODc0NzNmIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NjA4MTAyOTAsImV4cCI6MTY2MDg1MzQ4NCwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.AXSppDRMlZoWjgFBQg6M7saARKc17LnAxn-APkC8mew";
            //APIHelper.kullaniciAdi = "demo";
            //APIHelper.subeAd = "merkez";
            ////Test Verileri End

            //Giriş
            MainPage = new LoginPage();

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
            //MainPage = new NavigationPage(new TestPage());
            /*MainPage = new NavigationPage(new Pages.MainView.MainContentPage())
            {
                BarTextColor = Color.FromHex(AppThemeColors._textColor),
                //BarBackgroundColor = Color.Transparent
                BarBackgroundColor = Color.FromHex(AppThemeColors._toolbarcolor)
            };/**/
        }
        //public void SetMainPage(Page rootPage)
        //{
        //    MainPage = rootPage;
        //}

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

/* This App Made BySoloKing  */
/* https://my.bio/bysoloking */
