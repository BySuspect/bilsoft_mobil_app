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
        public DataTemplate DonutChartViewItems { get; set; }
        public DataTemplate BankaBakiyeListkViewItems { get; set; }
        public DataTemplate KasaBakiyeListkViewItems { get; set; }
        public DataTemplate _7gunCiftGrafikViewItems { get; set; }
        public DataTemplate _7gunSatisGrafikViewItems { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (((MainContentPageViewItems)item).View.ToLower())
            {
                case "main":
                    return MainViewItems;

                case "donut":
                    return DonutChartViewItems;

                case "ciftgrafik":
                    return _7gunCiftGrafikViewItems;

                case "tekgrafik":
                    return _7gunSatisGrafikViewItems;

                case "banka":
                    return BankaBakiyeListkViewItems;

                case "kasa":
                    return KasaBakiyeListkViewItems;

                default:
                    return BankaBakiyeListkViewItems;
            }
        }
    }
}
