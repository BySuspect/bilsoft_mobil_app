using bilsoft_mobil_app.Helper.App;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace bilsoft_mobil_app.Pages.MainView
{
    public class MainPageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MainViewItems { get; set; }
        public DataTemplate MainChartsItems { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (((MainContentPageViewItems)item).View.ToLower())
            {
                case "main":
                    return MainViewItems;
                    break;

                case "chart":
                    return MainChartsItems;
                    break;

                default:
                    return MainChartsItems;
                    break;
            }
        }
    }
}
