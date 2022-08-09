﻿using bilsoft_mobil_app.CustomItems;
using bilsoft_mobil_app.Helper;
using bilsoft_mobil_app.Helper.API;
using bilsoft_mobil_app.Helper.App;
using bilsoft_mobil_app.TestArea;
using Microcharts;
using Newtonsoft.Json;
using RestSharp;
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
    public partial class TestPage : ContentPage
    {
        #region renk Bindleri
        public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
        public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
        public Color Success { get; set; } = Color.FromHex(AppThemeColors._success);
        public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
        public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
        public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
        public Color Money { get; set; } = Color.FromHex(AppThemeColors._money);
        public Color MoneyBackground { get; set; } = Color.FromHex(AppThemeColors._moneyBackground);
        #endregion
        public TestPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void edtNot_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnKaydet_Clicked(object sender, EventArgs e)
        {

        }
    }
}