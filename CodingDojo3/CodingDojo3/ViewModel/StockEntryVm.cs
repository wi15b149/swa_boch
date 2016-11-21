﻿using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    class StockEntryVm : BaseViewModel
    {
        private StockEntry stockEntry;
        private double salespriceInEuro;
        /*private string category;
        private double purchaseprice;
        private int stock;*/

        public string Stock
        {
            get {
                if (stockEntry.Amount < 10)
                {
                    return "rot";
                } else if (stockEntry.Amount>= 10 && stockEntry.Amount < 20)
                {
                    return "orange";
                }
                 else
                {
                    return "grün";
                }
               
            }
        }


        public string Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                OnChange("Name");
            }
        }
        

        public string Category
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set { stockEntry.SoftwarePackage.Category.Name = value;
                OnChange("Category"); }
        }


        public double SalesPrice
        {
            get { return stockEntry.SoftwarePackage.SalesPrice; }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                OnChange("SalesPrice");
            }
        }
        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                OnChange("PurchasePrice");
            }
        }


        public StockEntryVm(StockEntry entry)
        {
            stockEntry = entry;
            salespriceInEuro = entry.SoftwarePackage.SalesPrice;
        }

        public void CalculateSalesPriceFromEuro(Currencies currency)
        {
            this.SalesPrice = CurrencyConverter.ConvertFromEuroTo(currency, salespriceInEuro);
        }

    }
}