using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;

namespace CodingDojo5.ViewModel
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
        #region Properties
        public string ChatName { get; set; }
        public string Message { get; set; }

        public ObservableCollection<string> ReceivedMessages { get; set; }
        public RelayCommand ConnectBtnCmd { get; set; }
        public RelayCommand SendBtnCmd { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Message = "";
            ReceivedMessages = new ObservableCollection<string>();
            ConnectBtnCmd = new RelayCommand(ConnectBtnClicked);
            SendBtnCmd = new RelayCommand(SendBtnClicked);
        }

        private void SendBtnClicked()
        {
            throw new NotImplementedException();
        }

        private void ConnectBtnClicked()
        {
            throw new NotImplementedException();
        }
    }
}