using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class ItemVm : ViewModelBase
    {
        private string description;
        private BitmapImage image;
        
        
        #region Properties


        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged();
            }
        }

        public string AgeRecom { get; set; }
        public ObservableCollection<ItemVm> Items { get; set; }

        public BitmapImage Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        #endregion

        public ItemVm(string description, string ageRecom, BitmapImage image)
        {
            Description = description;
            AgeRecom = ageRecom;
            Image = image;
        }

        public ItemVm(string description, string ageRecom, BitmapImage image, ObservableCollection<ItemVm> items)
        {
            this.description = description;
            this.image = image;
            AgeRecom = ageRecom;
            Items = items;
        }
    }
}
