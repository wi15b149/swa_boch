using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo7.ViewModel
{
    public class OverviewVm : ViewModelBase
    {
        public ObservableCollection<ItemVm> Items { get; set; }
        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();

        public OverviewVm()
        {
            Items = new ObservableCollection<ItemVm>();

            //Demodata
            Items.Add(new ItemVm("Auto", "10+", new BitmapImage(new Uri("Images/stern.jpg", UriKind.Relative))));

            messenger.Register<PropertyChangedMessage<ItemVm>>(this, updateList);
            

        }

        private void updateList(PropertyChangedMessage<ItemVm> obj)
        {
            Items.Add(obj.NewValue);
        }
    }
}
