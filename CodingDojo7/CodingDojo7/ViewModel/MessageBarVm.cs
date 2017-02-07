using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CodingDojo7.ViewModel
{
    public class MessageBarVm : ViewModelBase
    {
        private BitmapImage symbol;
        Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        private string labelCon;
        private DispatcherTimer timer;
        private Visibility visible;
        private int displayTime = 2;      


        #region Properties

        public Visibility Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                RaisePropertyChanged();
            }
        }

        public BitmapImage Symbol
        {
            get { return symbol; }
            set { symbol = value;
                RaisePropertyChanged();
            }
        }

        public string LabelCon
        {
            get { return labelCon; }
            set { labelCon = value;
                RaisePropertyChanged();
            }
        }    

        #endregion

        public MessageBarVm()
        {
            Visible = Visibility.Hidden;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, displayTime);
            timer.Tick += Timer_Tick;            
            messenger.Register<PropertyChangedMessage<ItemVm>>(this, displayMessage);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Symbol = null;
            LabelCon = "";
            Visible = Visibility.Hidden;
            timer.Stop();
        }

        private void displayMessage(PropertyChangedMessage<ItemVm> obj)
        {
            Visible = Visibility.Visible;
            Symbol = new BitmapImage(new Uri("../Images/State_Ok.png", UriKind.Relative));
            //LabelCon = obj.NewValue.Description;
            LabelCon = string.Format("Item {0} added.", obj.NewValue.Description);
            timer.Start(); 
        }
    }
}
