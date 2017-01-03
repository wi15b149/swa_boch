using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ItemVm> LegoItems { get; set; }
        public ObservableCollection<ItemVm> PlayItems { get; set; }
        public ObservableCollection<ItemVm> Categories { get; set; }
        public ObservableCollection<ItemVm> Wishlist { get; set; }
        private ItemVm currentItem;
        private ItemVm currentCat;
        private RelayCommand<ItemVm> buyBtnCmd;

        public ItemVm CurrentCat
        {
            get { return currentCat; }
            set
            {
                currentCat = value;
                RaisePropertyChanged();
            }
        }

        public ItemVm CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<ItemVm> BuyBtnCmd
        {
            get
            {
                return buyBtnCmd;
            }
            set
            {
                buyBtnCmd = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            LegoItems = new ObservableCollection<ItemVm>();
            PlayItems = new ObservableCollection<ItemVm>();
            Categories = new ObservableCollection<ItemVm>();
            Wishlist = new ObservableCollection<ItemVm>();

            BuyBtnCmd = new RelayCommand<ItemVm>((p) => { Wishlist.Add(p); });
            DemoDataGenerator();

        }

        private void DemoDataGenerator()
        {
            LegoItems.Add(new ItemVm("Ewok Village", "10+", new BitmapImage(new Uri("Images/ewok.jpg", UriKind.Relative))));
            LegoItems.Add(new ItemVm("Millenium Falcon", "13+", new BitmapImage(new Uri("Images/falke.jpg", UriKind.Relative))));
            LegoItems.Add(new ItemVm("Hovertank", "7+", new BitmapImage(new Uri("Images/hovertank.jpg", UriKind.Relative))));
            LegoItems.Add(new ItemVm("Jabbas Palast", "10+", new BitmapImage(new Uri("Images/moschee.jpg", UriKind.Relative))));
            LegoItems.Add(new ItemVm("Todesstern", "18+", new BitmapImage(new Uri("Images/stern.jpg", UriKind.Relative))));

            PlayItems.Add(new ItemVm("Burg 1", "18+", new BitmapImage(new Uri("Images/pburg.jpg", UriKind.Relative))));
            PlayItems.Add(new ItemVm("Wagen 1", "5+", new BitmapImage(new Uri("Images/pwagen.jpg", UriKind.Relative))));
            PlayItems.Add(new ItemVm("Burg 2", "7+", new BitmapImage(new Uri("Images/pburg.jpg", UriKind.Relative))));
            PlayItems.Add(new ItemVm("Wagen 2", "5+", new BitmapImage(new Uri("Images/pwagen.jpg", UriKind.Relative))));

            Categories.Add(new ItemVm("my lego", "", new BitmapImage(new Uri("Images/ewok.jpg", UriKind.Relative)), LegoItems));
            Categories.Add(new ItemVm("my playmobil", "", new BitmapImage(new Uri("Images/pburg.jpg", UriKind.Relative)), PlayItems));



        }

    }

}