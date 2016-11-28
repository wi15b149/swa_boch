using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System;
using System.IO;
using System.Globalization;

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
        
        private string newFirstname;
        private string newLastname="";
        private int newSsn;
        private DateTime newBirthdate;

        public DateTime NewBirthdate
        {
            get { return newBirthdate; }
            set { newBirthdate = value; }
        }


        public int NewSsn
        {
            get { return newSsn; }
            set { newSsn = value; }
        }


        public string NewLastname
        {
            get { return newLastname; }
            set { newLastname = value; }
        }


        public string NewFirstname
        {
            get { return newFirstname; }
            set { newFirstname = value; }
        }


        public ObservableCollection<PersonVM> Persons
        {
            get { return persons; }
            set { persons = value; }
        }

        public PersonVM Person { get; set; }

        public MainViewModel()
        {
           
            //Testdaten     
            LoadTestData();

            AddBtnCmd = new RelayCommand(AddBtnClicked/*, () => { return newLastname.Length > 2; }*/);
            SaveBtnCmd = new RelayCommand(SaveBtnClicked, SaveBtnCanExecute);
            LoadBtnCmd = new RelayCommand(LoadBtnClicked, () => { return File.Exists("Personendaten.csv"); });
        }
        

        private bool SaveBtnCanExecute()
        {
            return persons.Count > 0;
        }

        private void LoadBtnClicked()
        {
            LoadFromCSV();
        }

        private void SaveBtnClicked()
        {
            SaveToCSV();
        }

        private void AddBtnClicked()
        {
            Persons.Add(new PersonVM(NewFirstname, NewLastname, NewSsn, NewBirthdate));
        }

        public void LoadTestData()
        {
            Persons.Add(new PersonVM("Michi", "Boch", 1234, new DateTime(1990, 11, 11)));
            Persons.Add(new PersonVM("Han", "Solo", 1111, new DateTime(1976, 12, 1)));
        }

        private void SaveToCSV()
        {
            if (persons != null)
            {
                string data = "";
                foreach (var item in persons)
                {
                    data += item.Firstname + ";"
                        + item.Lastname + ";"
                        + item.Ssn + ";"
                        + item.Birthdate
                        + ";\n";
                }

                File.WriteAllText("Personendaten.csv", data);
            }

        }
        private void LoadFromCSV()
        {

            var reader = new StreamReader(File.OpenRead(@"Personendaten.csv"));
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                persons.Add(new PersonVM(values[0], values[1], int.Parse(values[2]), DateTime.ParseExact(values[3], "dd.MM.yyyy hh:mm:ss",
                                  CultureInfo.InvariantCulture)));
            }

        }
    }
}