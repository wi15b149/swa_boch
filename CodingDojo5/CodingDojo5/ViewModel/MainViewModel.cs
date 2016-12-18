using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System;
using CodingDojo5.Communication;
using System.Windows.Input;

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
        private Client client;
        private bool isConnected = false;
        
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
            ConnectBtnCmd = new RelayCommand(ConnectBtnClicked, ()=> { return !isConnected; });
            SendBtnCmd = new RelayCommand(SendBtnClicked, () => { return (Message.Length>=1 && isConnected); });
        }

        private void SendBtnClicked()
        {
            client.Send(ChatName + ": " + Message);
            //write own message to GUI
            ReceivedMessages.Add("YOU: " + Message);
        }

        private void ConnectBtnClicked()
        {
            isConnected = true;
            client = new Client("127.0.0.1", 10100, new Action<string>(NewMessageReceived), ClientDissconnected);
        }

        private void ClientDissconnected()
        {
            isConnected = false;
            //do this to force the update of the button visibility otherwise change is done after focus change (clicking into gui)
            CommandManager.InvalidateRequerySuggested();
        }

        private void NewMessageReceived(string message)
        {
            //write new message in Collection to display in GUI
            //switch thread to GUI thread to avoid problems
            App.Current.Dispatcher.Invoke(() =>
            {
                ReceivedMessages.Add(message);
            });
        }
    }
}