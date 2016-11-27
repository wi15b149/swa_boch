using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    public class StockEntryVm
    {
        private StockEntry stockEntry;
        private double salespriceInEuro;
        /*private string category;
        private double purchaseprice;
        private int stock;*/

        public int Stock
        {
            get { return stockEntry.Amount; }
            set { stockEntry.Amount = value; }
        }


        public string Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
            }
        }


        public string Category
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
            }
        }


        public double SalesPrice
        {
            get { return stockEntry.SoftwarePackage.SalesPrice; }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
            }
        }
        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
            }
        }


        public StockEntryVm(StockEntry entry)
        {
            stockEntry = entry;
            salespriceInEuro = entry.SoftwarePackage.SalesPrice;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
