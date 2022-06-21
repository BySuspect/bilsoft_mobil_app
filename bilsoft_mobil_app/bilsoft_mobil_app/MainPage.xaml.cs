using bilsoft_mobil_app.Helper;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bilsoft_mobil_app
{
    public partial class MainPage : ContentPage
    {
        //Liste AraLine new BoxView() { HeightRequest = 1, Color = Color.LightGray, VerticalOptions = LayoutOptions.Start }
        List<SuresiGecenListeProps> SuresiGecenHatirlatmalarListe = new List<SuresiGecenListeProps>();
        public MainPage()
        {
            InitializeComponent();

            SuresiGecenHatirlatmalarListeAdder();
            foreach (var item in SuresiGecenHatirlatmalarListe)
            {
                SuresiGecenHatirlatmalarViewAdder(item.AdSoyad, item.Firma, item.Aciklama);
            }
        }

        void SuresiGecenHatirlatmalarListeAdder()
        {
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "aaaaaaa", AdSoyad = "Ahmet Ertürk", Firma = "Sancaklar iletişim" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "bbbbbbbbb", AdSoyad = "awhaha awhawh", Firma = "fghgdjdfg sehjnrsdnj" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "vvvvvvv", AdSoyad = "fdhdh jhfhg", Firma = "dshesh iletişim" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "sssssssss", AdSoyad = "awhawh awhawhwahawh", Firma = "dhsdhsdfh iletişim" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "aefsgseg", AdSoyad = "awha awhawh", Firma = "gfdjdfj sdgehse" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "gawgaw", AdSoyad = "awgawh Ertürk", Firma = "sehsejsrej sjsejsj" });
            SuresiGecenHatirlatmalarListe.Add(new SuresiGecenListeProps { Aciklama = "shhehseh", AdSoyad = "Ahmet agwagawg", Firma = "gfjgfj fgdjdf" });
        }
        void SuresiGecenHatirlatmalarViewAdder(string _adSoyad, string _firma, string _aciklama)
        {
            SuresiGecenListeView.Children.Add(new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text=_adSoyad,
                        TextColor=Color.Black,
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.StartAndExpand
                    },
                    new Label
                    {
                        Text=_firma,
                        TextColor=Color.Black,
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.CenterAndExpand
                    },
                    new Label
                    {
                        Text=_aciklama,
                        TextColor=Color.Black,
                        FontSize=12,
                        FontAttributes=FontAttributes.Bold,
                        HorizontalOptions=LayoutOptions.EndAndExpand,
                        TranslationX=-20
                    }
                },
                Orientation = StackOrientation.Horizontal
            });
            SuresiGecenListeView.Children.Add(new BoxView()
            {
                HeightRequest = 1,
                Color = Color.LightGray,
                VerticalOptions =
                LayoutOptions.Start
            });
        }
        private void btnSureGecenHatirlatmaKapat_Clicked(object sender, EventArgs e)
        {
            SuresiGecenHatirlatmaView.IsVisible = false;
        }

        private void btnpopupMenuReturnBack_Clicked(object sender, EventArgs e)
        {

        }

        private void btnPopUpMenu_Clicked(object sender, EventArgs e)
        {

        }

    }
}
