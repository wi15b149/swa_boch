using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;

namespace CodingDojo7.ViewModel
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

        private ViewModelBase currentDetailView;
        private ViewModelBase messageView;

        public ViewModelBase MessageView
        {
            get { return messageView; }
            set { messageView = value;
                RaisePropertyChanged();
            }
        }
        
        public ViewModelBase CurrentDetailView
        {
            get { return currentDetailView; }
            set { currentDetailView = value;
                RaisePropertyChanged();
            }
        }



        public RelayCommand Switch2MyToys { get; set; }
        public RelayCommand Switch2Overview { get; set; }

        public MainViewModel()
        {
            CurrentDetailView = SimpleIoc.Default.GetInstance<MyToysVm>();
            MessageView = SimpleIoc.Default.GetInstance<MessageBarVm>();
            Switch2MyToys = new RelayCommand(() => { CurrentDetailView = SimpleIoc.Default.GetInstance<MyToysVm>(); });
            Switch2Overview = new RelayCommand(() => { CurrentDetailView = SimpleIoc.Default.GetInstance<OverviewVm>(); });

           

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

       
    }
}