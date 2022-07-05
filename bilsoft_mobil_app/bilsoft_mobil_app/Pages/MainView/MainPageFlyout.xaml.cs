using bilsoft_mobil_app.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bilsoft_mobil_app.Pages.MainView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {

        public ListView ListView;

        public MainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainPageFlyoutViewModel();
        }

        private class MainPageFlyoutViewModel : INotifyPropertyChanged
        {
            #region renk Bindleri
            public Color TextColor { get; set; } = Color.FromHex(AppThemeColors._textColor);
            public Color TextColorKoyu { get; set; } = Color.FromHex(AppThemeColors._textColorKoyu);
            public Color BorderColor { get; set; } = Color.FromHex(AppThemeColors._borderColor);
            public Color BackgroundColor { get; set; } = Color.FromHex(AppThemeColors._backgroundColor);
            public Color CardBackgroundColor { get; set; } = Color.FromHex(AppThemeColors._cardBackgroundColor);
            public Color ToolBarColor { get; set; } = Color.FromHex(AppThemeColors._toolbarcolor);
            #endregion
            public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}