﻿using bilsoft_mobil_app.Helper.API;
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
             * cariyi incele kısmı yapılıcak
             * ana sayfadaki hatırlatma düzenlenicek ana sayfa tekrar yapılıcak
             */

            //Test Verileri
            /*APIHelper.loginToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI4OCIsInVuaXF1ZV9uYW1lIjoiZDAzMDM1OGYtYmUwOC00YTEzLTlhMjQtMjZhM2ZhYzQzZTY5IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImRlbW8iLCJuYmYiOjE2NjAxMTQ4MjUsImV4cCI6MTY2MDE1ODAyNCwiaXNzIjoid3d3LmJpbHNvZnQuY29tIiwiYXVkIjoid3d3LmJpbHNvZnQuY29tIn0.8sXOnaK9gWdO-L-3qhAKZCb9roS4OQpns6PurfZ-J5o";
            APIHelper.kullaniciAdi = "demo";
            APIHelper.subeAd = "merkez";*/
            //Test Verileri End

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
            MainPage = new MainPage();

            //Test Page
            //MainPage = new NavigationPage(new TestPage());
            /*MainPage = new NavigationPage(new MainContentPage())
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

/* This App Made BySoloKing  */
/* https://my.bio/bysoloking */
