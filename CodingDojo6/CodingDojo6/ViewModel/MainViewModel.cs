using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<LegoItemVm> Items { get; set; }
        private LegoItemVm currentItem;

        public LegoItemVm CurrentItem
        {
            get { return currentItem; }
            set { currentItem = value;
                RaisePropertyChanged();
            }
        }


        public MainViewModel()
        {
            Items = new ObservableCollection<LegoItemVm>();
            DemoDataGenerator();

        }

        private void DemoDataGenerator()
        {
            Items.Add(new LegoItemVm("Ewok Village", 3000, "10+", new BitmapImage(new Uri("Images/ewok.jpg",UriKind.Relative))));
            Items.Add(new LegoItemVm("Millenium Falcon", 6000, "13+", new BitmapImage(new Uri("Images/falke.jpg", UriKind.Relative))));
            Items.Add(new LegoItemVm("Hovertank", 500, "7+", new BitmapImage(new Uri("Images/hovertank.jpg", UriKind.Relative))));
            Items.Add(new LegoItemVm("Jabbas Palast", 3000, "10+", new BitmapImage(new Uri("Images/moschee.jpg", UriKind.Relative))));
            Items.Add(new LegoItemVm("Todesstern", 7000, "18+", new BitmapImage(new Uri("Images/stern.jpg", UriKind.Relative))));

        }

    }

}