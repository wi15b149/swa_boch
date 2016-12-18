using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;
using CodingDojo5_Server.Communication;
using DataHandling;
using System.Linq;

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
        private Server server;
        private const int port = 10100;
        private const string ip = "127.0.0.1";
        private bool isConnected = false;
        public DataHandler dHandler { get; set; }

        #region ChatProperties
        public RelayCommand StartBtnCmd { get; set; }
        public RelayCommand StopBtnCmd { get; set; }
        public RelayCommand DropUserCmd { get; set; }
        public RelayCommand SaveToLogCmd { get; set; }
        public ObservableCollection<string> Users { get; set; }
        public string SelectedUser { get; set; }

        public ObservableCollection<string> Messages { get; set; }

        public int NoOfReceivedMessages
        {
            get
            {
                return Messages.Count;
            }
        }

        #endregion

        #region LogProperties

        public RelayCommand ShowLogCmd { get; set; }
        public RelayCommand DropLogCmd { get; set; }
        public ObservableCollection<string> LogFiles
        {
            get
            {
                return new ObservableCollection<string>(dHandler.QueryFilesFromFolder());
            }
        }
        public ObservableCollection<string> LogMessages { get; set; }
        public string SelectedLogFile { get; set; }

        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            dHandler = new DataHandler();
            Messages = new ObservableCollection<string>();
            Users = new ObservableCollection<string>();
            LogMessages = new ObservableCollection<string>();
            //LogFiles = new ObservableCollection<string>();

            StartBtnCmd = new RelayCommand(StartBtnClicked, ()=> { return !isConnected; });
            StopBtnCmd = new RelayCommand(StopBtnClicked, ()=> { return isConnected; });
            DropUserCmd = new RelayCommand(DropBtnClicked, () => { return SelectedUser != null; });
            SaveToLogCmd = new RelayCommand(SaveBtnClicked, () => { return Messages.Count >= 1; });

            ShowLogCmd = new RelayCommand(ShowLogBtnClicked, () => { return SelectedLogFile != null; });
            DropLogCmd = new RelayCommand(DropLogBtnClicked, () => { return SelectedLogFile != null; });
        }

        private void DropLogBtnClicked()
        {
            dHandler.Delete(SelectedLogFile);
            RaisePropertyChanged("LogFiles"); //to update the list in the log section},
        }

        private void ShowLogBtnClicked()
        {
            LogMessages = new ObservableCollection<string>(dHandler.Load(SelectedLogFile));
            RaisePropertyChanged("LogMessages");
        }

        private void SaveBtnClicked()
        {
            dHandler.Save(Messages.ToList());
            RaisePropertyChanged("LogFiles"); //to update the list in the log section
        }

        private void DropBtnClicked()
        {
            server.DisconnectSpecificClient(SelectedUser);
            Users.Remove(SelectedUser); // remove from GUI listbox
        }

        private void StopBtnClicked()
        {
            server.StopAccepting();
            isConnected = false;
        }

        private void StartBtnClicked()
        {
            server = new Server(ip, port, UpdateGuiWithNewMessage);
            server.StartAccepting();
            isConnected = true;
        }

        private void UpdateGuiWithNewMessage(string message)
        {
            //switch thread to GUI thread to write to GUI
            App.Current.Dispatcher.Invoke(() =>
            {
                string name = message.Split(':')[0];
                if (!Users.Contains(name))
                {//not in list => add it
                    Users.Add(name);
                }
                //write message
                Messages.Add(message);
                //do this to inform the GUI about the update of the received message counter!
                RaisePropertyChanged("NoOfReceivedMessages");
            });
        }
    }
}