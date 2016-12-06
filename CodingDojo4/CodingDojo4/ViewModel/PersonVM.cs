using CodingDojo4.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4.ViewModel
{
    public class PersonVM : ViewModelBase
    {

        private Person person;

        #region Properties

        public string Firstname
        {
            get { return person.Firstname; }
            set
            {
                person.Firstname = value;
                RaisePropertyChanged();
            }
        }
        public string Lastname
        {
            get { return person.Lastname; }
            set
            {
                person.Lastname = value;
                RaisePropertyChanged();
            }
        }
        public int Ssn
        {
            get { return person.Ssn; }
            set
            {
                person.Ssn = value;
                RaisePropertyChanged();
            }
        }
        public DateTime Birthdate
        {
            get { return person.Birthdate; }
            set
            {
                person.Birthdate = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        public PersonVM(string firstname, string lastname, int ssn, DateTime birthdate)
        {
            person = new Person(firstname, lastname, ssn, birthdate);
        }

        public Person GetPerson()
        {
            return person;
        }
    }
}
