using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingDojo3.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 

        
        private const string showAll = "Show All";
        private List<StockEntry> stock;
        private ObservableCollection<StockEntryVm> saleitems = new ObservableCollection<StockEntryVm>(); //Vollständige Produktliste (Backup)
        private ObservableCollection<StockEntryVm> filteredSaleitems = new ObservableCollection<StockEntryVm>(); //Gefilterte Produktliste
        private string selectedSearchItem; //Auswahl Combobox
        private ObservableCollection<string> filteredList = new ObservableCollection<string>(); //Inhalt Combobox (Produktliste + ShowAll)

        private StockEntryVm selectedSalesItem; //Auswahl Datagrid
        public RelayCommand SearchBtn { get; set; }
        public RelayCommand ClearBtn { get; set; }
        

        #region Properties

        public ObservableCollection<string> FilteredList
        {
            get { return filteredList; }
            set { filteredList = value; }
        }


        public ObservableCollection<StockEntryVm> Saleitems
        {
            get { return saleitems; }
            set { saleitems = value; }
        }

        public ObservableCollection<StockEntryVm> FilteredSaleitems
        {
            get { return filteredSaleitems; }
            set { filteredSaleitems = value; }
        }

        public string SelectedSearchItem
        {
            get
            {
                return selectedSearchItem;
            }
            set
            {
                selectedSearchItem = value;
                RaisePropertyChanged();
            }
        }

        public StockEntryVm SelectedSalesItem
        {
            get
            {
                return selectedSalesItem;
            }

            set
            {
                selectedSalesItem = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public MainViewModel()
        {
            LoadData();
            SearchBtn = new RelayCommand(SearchBtnClicked);
            ClearBtn = new RelayCommand(ClearBtnClicked);
        }


        private void ClearBtnClicked()
        {            
            DeleteData(SelectedSalesItem);
            
        }
       

        private void SearchBtnClicked()
        {
            FilterData(selectedSearchItem);       
            
        }      

        public void LoadData()
        {
            SampleManager manager = new SampleManager();
            stock = manager.CurrentStock.OnStock;
            filteredList.Add(showAll);

            foreach (var item in manager.CurrentStock.OnStock)
            {
                saleitems.Add(new StockEntryVm(item)); 
                filteredSaleitems.Add(new StockEntryVm(item));
                filteredList.Add(new StockEntryVm(item).Name); 
            }
        }

        private void FilterData(string selection)
        {
            //Temporary delete

            FilteredSaleitems.Clear();

            foreach (var item in Saleitems)
            {
                if (item.Name.Equals(selection) || selection == showAll)
                {
                    FilteredSaleitems.Add(item);
                }
            }
        }

        private void DeleteData(StockEntryVm selection)
        {
            //Full Delete

            FilteredSaleitems.Remove(selection);
            Saleitems.Remove(selection);

            FilteredList.Clear();
            FilteredList.Add(showAll);

            foreach (var item in Saleitems)
            {
                FilteredList.Add(item.Name);
            }
        }


    }
}