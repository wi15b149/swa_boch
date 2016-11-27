using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System;

namespace CodingDojo4.ViewModel
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
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        public RelayCommand AddBtnCmd  { get; set; }
        public RelayCommand LoadBtnCmd { get; set; }
        public RelayCommand SaveBtnCmd { get; set; }
        private ObservableCollection<PersonVM> persons = new ObservableCollection<PersonVM>();

        public string NewFirstname { get; set; }
        public string NewLastname { get; set; }
        public int NewSsn { get; set; }
        public DateTime NewBirthdate { get; set; }


        public ObservableCollection<PersonVM> Persons
        {
            get { return persons; }
            set { persons = value; }
        }

        public PersonVM Person { get; set; }

        public MainViewModel()
        {            
            Persons.Add(new PersonVM("Michi", "Boch", 123, new System.DateTime(2016,11,11)));
            AddBtnCmd = new RelayCommand(AddBtnClicked);
        }

        private void AddBtnClicked()
        {
            Persons.Add(new PersonVM(NewFirstname, NewLastname, NewSsn, NewBirthdate));
        }
    }
}