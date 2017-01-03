using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class LegoItemVm : ViewModelBase
    {
        private string description;
        private int noOfParts;
        private BitmapImage image;

        #region Properties

        public int NoOfParts
        {
            get { return noOfParts; }
            set
            {
                noOfParts = value;
                RaisePropertyChanged();
            }
        }

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

        public LegoItemVm(string description, int noOfParts, string ageRecom, BitmapImage image)
        {
            Description = description;
            NoOfParts = noOfParts;
            AgeRecom = ageRecom;
            Image = image;
        }

    }
}
