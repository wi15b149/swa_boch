using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    class MainViewModel : BaseViewModel
    {

        public Array Currencies
        {
            get { return Enum.GetValues(typeof(Currencies));  }
        }

        public Currencies SelectedCurrency
        {
            get { return selectedCurrency; }
            set { selectedCurrency = value;
                OnChange("SelectedCurrency");
                StartConvertion();
            }
        }

        private void StartConvertion()
        {
            foreach (var item in Items)
            {
                item.CalculateSalesPriceFromEuro(SelectedCurrency);
            }
        }

        private List<StockEntry> stock;
        private ObservableCollection<StockEntryVm> items = new ObservableCollection<StockEntryVm>();
        private Currencies selectedCurrency;

        public ObservableCollection<StockEntryVm> Items
        {
            get { return items; }
            set { items = value; }
        }

        public MainViewModel()
        {
            SampleManager manager = new SampleManager();
            stock = manager.CurrentStock.OnStock;

            foreach (var item in manager.CurrentStock.OnStock)
            {
                Items.Add(new StockEntryVm(item)); //Filling our viewmodel data structure
            }
        }
    }
}
