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
        ObservableCollection<MainPageFlyoutMenuItem> _listItemsSource = new ObservableCollection<MainPageFlyoutMenuItem>();
        public ListView _listViewAnaMenuler = new ListView();
        public ListView _listViewAltMenuler = new ListView();
        public ListView _listViewTest = new ListView();

        string ajandaName = "Ajanda◀",//"Ajanda▼"
               cariName = "Cari◀",//"Cari▼"
               stokName = "Stok◀",//"Stok▼"
               taksitName = "Taksit◀",//"Taksit▼"
               satisName = "Satış◀",//"Satış▼"
               kasaName = "Kasa◀",//"Kasa▼"
               bankaName = "Banka◀",//"Banka▼"
               ceksenetName = "Çek/Senet◀",//"Çek/Senet▼"
               digerName = "Diğer◀",//"Diğer▼"
               gelirgiderName = "Gelir Gider◀";//"Gelir Gider▼"

        bool caritree = false,
             stoktree = false,
             taksittree = false,
             satistree = false,
             kasatree = false,
             bankatree = false,
             ceksenettree = false,
             digertree = false,
             gelirgidertree = false;

        string openedTree = null;

        bool ListOnMenu = true;

        public MainPageFlyout()
        {
            InitializeComponent();
            BindingContext = new MainPageFlyoutViewModel();
            CreateNormalMenu();
            MenulistView.ItemSelected += listViewSelected;
        }
        void listViewSelected(object s, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainPageFlyoutMenuItem;
            if (item == null || item.name == null)
            {
                MenulistView.SelectedItem = null;/**/
                return;
            }

            #region ajanda
            if (item.name == "btnAjanda")
            {
                if (item.Title == "Ajanda◀")
                {
                    resetAltTrees();
                    ajandaName = "Ajanda▼";
                    openAjandaTree();
                    MenulistView.ScrollTo(_listItemsSource[_listItemsSource.Count - 1], ScrollToPosition.End, true);
                }
                else
                {
                    MenulistView.ScrollTo(_listItemsSource[0], ScrollToPosition.Start, true);
                    resetAltTrees();
                    closeAjandaTree();
                }
                MenulistView.SelectedItem = null;/**/
                return;
            }
            #endregion

            #region Cari Tree
            if (item.name == "btnCari")
            {
                if (item.Title == "Cari◀")
                {
                    resetAltTrees();
                    cariName = "Cari▼";
                    caritree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Stok Tree
            if (item.name == "btnStok")
            {
                if (item.Title == "Stok◀")
                {
                    resetAltTrees();
                    stokName = "Stok▼";
                    stoktree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Taksit Tree
            if (item.name == "btnTaksit")
            {
                if (item.Title == "Taksit◀")
                {
                    resetAltTrees();
                    taksitName = "Taksit▼";
                    taksittree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Satis Tree
            if (item.name == "btnSatis")
            {
                if (item.Title == "Satış◀")
                {
                    resetAltTrees();
                    satisName = "Satış▼";
                    satistree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Kasa Tree
            if (item.name == "btnKasa")
            {
                if (item.Title == "Kasa◀")
                {
                    resetAltTrees();
                    kasaName = "Kasa▼";
                    kasatree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Banka Tree
            if (item.name == "btnBanka")
            {
                if (item.Title == "Banka◀")
                {
                    resetAltTrees();
                    bankaName = "Banka▼";
                    bankatree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Cek-Senet Tree
            if (item.name == "btnCekSenet")
            {
                if (item.Title == "Çek/Senet◀")
                {
                    resetAltTrees();
                    ceksenetName = "Çek/Senet▼";
                    ceksenettree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Diger Tree
            if (item.name == "btnDiger")
            {
                if (item.Title == "Diğer◀")
                {
                    resetAltTrees();
                    digerName = "Diğer▼";
                    digertree = true;
                    openAjandaTree();
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            #region Gelir-Gider Tree
            if (item.name == "btnGelirGider")
            {
                if (item.Title == "Gelir Gider◀")
                {
                    resetAltTrees();
                    gelirgiderName = "Gelir Gider▼";
                    gelirgidertree = true;
                    openAjandaTree();
                    MenulistView.ScrollTo(_listItemsSource[_listItemsSource.Count - 1], ScrollToPosition.End, true);
                }
                else
                {
                    resetAltTrees();
                    openAjandaTree();
                }
            }
            #endregion

            MenulistView.SelectedItem = null;/**/
            return;
        }

        void openAjandaTree()
        {
            ListOnMenu = false;
            CreateNormalMenu();
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnCari",
                fontSize = 14,
                Title = cariName,
                IconSource = "users20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Cari Alt tree
            if (caritree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Cari Bakiye Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Cari Hesap Ekstre Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Cari İşlem Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Cari Mutabakat Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Cari BA-BS Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnStok",
                Title = stokName,
                fontSize = 14,
                IconSource = "dropbox20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Stok Alt tree
            if (stoktree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Stok Haraketleri Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Stok Bakiye Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Stok Fiyat Listesi",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Depo Haraket Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Depo Aktarım Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnTaksit",
                Title = taksitName,
                fontSize = 14,
                IconSource = "takvimsure20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Taksit Alt tree
            if (taksittree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Taksit Raporu Gelişmiş",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnSatis",
                Title = satisName,
                fontSize = 14,
                IconSource = "shop20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Satis Alt tree
            if (satistree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Satış Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Satış Grafiği",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnKasa",
                Title = kasaName,
                fontSize = 14,
                IconSource = "kasa20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Kasa Alt tree
            if (kasatree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Kasa Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnBanka",
                Title = bankaName,
                fontSize = 14,
                IconSource = "banka20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Banka Alt tree
            if (bankatree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Banka Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnCekSenet",
                Title = ceksenetName,
                fontSize = 14,
                IconSource = "file_dolar20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Cek-Senet Alt tree
            if (ceksenettree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Çek/Senet Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnDiger",
                Title = digerName,
                fontSize = 14,
                IconSource = "raports20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Diger Alt tree
            if (digertree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Banka Kasa Haraketleri",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Gün Sonu",
                fontSize = 14,
                IconSource = "raports20px.png",
                margin = new Thickness(30, 0, 0, 0),
                TargetType = typeof(MainContentPage)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Kar Zarar Analizi",
                fontSize = 14,
                IconSource = "raports20px.png",
                margin = new Thickness(30, 0, 0, 0),
                TargetType = typeof(MainContentPage)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnGelirGider",
                Title = gelirgiderName,
                fontSize = 14,
                IconSource = "takvimsure20px.png",
                margin = new Thickness(30, 0, 0, 0)
            });
            #region Gelir-Gider Alt tree
            if (gelirgidertree)
            {
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Gelir Gider Bakiye Raporu",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
                _listItemsSource.Add(new MainPageFlyoutMenuItem
                {
                    Title = "Gelir Gider Detaylı Rapor",
                    fontSize = 12,
                    IconSource = "raports16px.png",
                    margin = new Thickness(60, 0, 0, 0),
                    TargetType = typeof(MainContentPage)
                });
            }
            #endregion
            MenulistView.ItemsSource = null;
            MenulistView.ItemsSource = _listItemsSource;
        }
        void closeAjandaTree()
        {
            ListOnMenu = true;
            resetAltTrees();
            CreateNormalMenu();
        }

        void resetAltTrees()
        {
            caritree = false;
            stoktree = false;
            taksittree = false;
            satistree = false;
            kasatree = false;
            bankatree = false;
            ceksenettree = false;
            digertree = false;
            gelirgidertree = false;

            ajandaName = "Ajanda◀";
            cariName = "Cari◀";
            stokName = "Stok◀";
            taksitName = "Taksit◀";
            satisName = "Satış◀";
            kasaName = "Kasa◀";
            bankaName = "Banka◀";
            ceksenetName = "Çek/Senet◀";
            digerName = "Diğer◀";
            gelirgiderName = "Gelir Gider◀";
        }

        public void CreateNormalMenu()
        {
            _listItemsSource.Clear();
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Ana Sayfa",
                fontSize = 18,
                IconSource = "home32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Cari Hesaplar",
                fontSize = 18,
                IconSource = "users32px.png",
                TargetType = typeof(CariHesaplarPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Satış Yap",
                fontSize = 18,
                IconSource = "shop32px.png",
                TargetType = typeof(SatisYapPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Stok Kartları",
                fontSize = 18,
                IconSource = "dropbox32px.png",
                TargetType = typeof(StokKartlariPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Faturalar",
                fontSize = 18,
                IconSource = "edit32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "E-Fatura",
                fontSize = 18,
                IconSource = "edit32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "E-İrsaliye",
                fontSize = 18,
                IconSource = "edit32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Gelir Gider",
                fontSize = 18,
                IconSource = "grafik32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Kasa",
                fontSize = 18,
                IconSource = "kasa32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Banka",
                fontSize = 18,
                IconSource = "banka32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Çek/Senet",
                fontSize = 18,
                IconSource = "file_dolar32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Taksit Yap",
                fontSize = 18,
                IconSource = "takvimsure32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                Title = "Teklif Sipariş",
                fontSize = 18,
                IconSource = "order32px.png",
                TargetType = typeof(MainContentPage),
                margin = new Thickness(0)
            });
            _listItemsSource.Add(new MainPageFlyoutMenuItem
            {
                name = "btnAjanda",
                fontSize = 18,
                Title = ajandaName,
                IconSource = "book32px.png",
                margin = new Thickness(0)
            });

            if (ListOnMenu)
            {
                MenulistView.ItemsSource = null;
                MenulistView.ItemsSource = _listItemsSource;
            }
        }

        #region addMenuList v1.0
        /*
         public void CreateNormalMenu()
        {
            _listViewAnaMenuler.ItemsSource = new MainPageFlyoutMenuItem[]
            {
                new MainPageFlyoutMenuItem
                {
                    Title = "Ana Sayfa",
                    IconSource = "home32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Cari Hesaplar",
                    IconSource = "users32px.png",
                    TargetType = typeof(CariHesaplarPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Satış Yap",
                    IconSource = "shop32px.png",
                    TargetType = typeof(SatisYapPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Stok Kartları",
                    IconSource = "dropbox32px.png",
                    TargetType = typeof(StokKartlariPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title="Faturalar",
                    IconSource="edit32px.png",
                    TargetType=typeof(MainContentPage)
                 },
                new MainPageFlyoutMenuItem
                {
                    Title = "E-Fatura",
                    IconSource="edit32px.png",
                    TargetType=typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "E-İrsaliye",
                    IconSource = "edit32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Gelir Gider",
                    IconSource = "grafik32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Kasa",
                    IconSource = "kasa32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Banka",
                    IconSource = "banka32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Çek/Senet",
                    IconSource = "file_dolar32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Taksit Yap",
                    IconSource = "takvimsure32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    Title = "Teklif Sipariş",
                    IconSource = "order32px.png",
                    TargetType = typeof(MainContentPage)
                },
                new MainPageFlyoutMenuItem
                {
                    name = "btnAjanda",
                    Title = "Ajanda◀",
                    IconSource = "book32px.png",
                    TargetType = typeof(MainContentPage)

                }
            };
            _listViewTest.ItemsSource = _listViewAnaMenuler.ItemsSource;
            MenulistView.ItemsSource = _listViewAnaMenuler.ItemsSource;
        }
         */
        #endregion

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