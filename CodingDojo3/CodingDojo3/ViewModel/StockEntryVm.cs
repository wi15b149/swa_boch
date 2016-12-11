using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    public class StockEntryVm : ViewModelBase
    {
        private StockEntry stockEntry;
        private double salespriceInEuro;
        /*private string category;
        private double purchaseprice;
        private int stock;*/

        public int Stock
        {
            get { return stockEntry.Amount; }
            set { stockEntry.Amount = value;
                RaisePropertyChanged();
            }
        }


        public string Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                RaisePropertyChanged();
            }
        }


        public string Category
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                RaisePropertyChanged();
            }
        }


        public double SalesPrice
        {
            get { return stockEntry.SoftwarePackage.SalesPrice; }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                RaisePropertyChanged();
            }
        }
        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                RaisePropertyChanged();
            }
        }


        public StockEntryVm(StockEntry entry)
        {
            stockEntry = entry;
            salespriceInEuro = entry.SoftwarePackage.SalesPrice;
        }

        public StockEntryVm()
      
        {
            stockEntry = new StockEntry();
            stockEntry.SoftwarePackage = new Software("");
            stockEntry.SoftwarePackage.Category = new Group();
            stockEntry.SoftwarePackage.Category.Name = "dummy";
        }    
        
        public override string ToString()
        {
            return Name;
        }

    }
}
