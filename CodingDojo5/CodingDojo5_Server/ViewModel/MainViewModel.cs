using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;

namespace CodingDojo5_Server.ViewModel
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
        
        private const int port = 10100;
        private const string ip = "127.0.0.1";
        private bool isConnected = false;


        #region ChatProperties
        public RelayCommand StartBtnCmd { get; set; }
        public RelayCommand StopBtnCmd { get; set; }
        public RelayCommand DropUserCmd { get; set; }
        public RelayCommand SaveToLogCmd { get; set; }
        public ObservableCollection<string> Users { get; set; }
        public string SelectedUser { get; set; }

        public ObservableCollection<string> Messages { get; set; }

        #endregion

        #region LogProperties

        public RelayCommand ShowLogCmd { get; set; }
        public RelayCommand DropLogCmd { get; set; }
        public ObservableCollection<string> LogFiles { get; set; }
        public ObservableCollection<string> LogMessages { get; set; }
        public string SelectedLogFile { get; set; }

        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Messages = new ObservableCollection<string>();
            Users = new ObservableCollection<string>();
            LogMessages = new ObservableCollection<string>();

            StartBtnCmd = new RelayCommand(StartBtnClicked, ()=> { return !isConnected; });
            StopBtnCmd = new RelayCommand(StopBtnClicked, ()=> { return isConnected; });
            DropUserCmd = new RelayCommand(DropBtnClicked, () => { return SelectedUser != null; });
            SaveToLogCmd = new RelayCommand(SaveBtnClicked, () => { return Messages.Count >= 1; });

            ShowLogCmd = new RelayCommand(ShowLogBtnClicked, () => { return SelectedLogFile != null; });
            DropLogCmd = new RelayCommand(DropLogBtnClicked, () => { return SelectedLogFile != null; });
        }

        private void DropLogBtnClicked()
        {
            throw new NotImplementedException();
        }

        private void ShowLogBtnClicked()
        {
            throw new NotImplementedException();
        }

        private void SaveBtnClicked()
        {
            throw new NotImplementedException();
        }

        private void DropBtnClicked()
        {
            throw new NotImplementedException();
        }

        private void StopBtnClicked()
        {
            throw new NotImplementedException();
        }

        private void StartBtnClicked()
        {
            throw new NotImplementedException();
        }
    }
}