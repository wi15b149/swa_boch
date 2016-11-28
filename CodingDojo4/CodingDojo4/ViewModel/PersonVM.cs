using CodingDojo4.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4.ViewModel
{
    public class PersonVM  : ViewModelBase
    {
        
        Person Person { get; set; }

        #region Properties

        public string Firstname
        {
            get { return Person.Firstname; }
            set { Person.Firstname = value;
                RaisePropertyChanged();
            }
        }
        public string Lastname
        {
            get { return Person.Lastname; }
            set { Person.Lastname = value;
                RaisePropertyChanged();
            }
        }
        public int Ssn
        {
            get { return Person.Ssn; }
            set { Person.Ssn = value;
                RaisePropertyChanged();
            }
        }
        public DateTime Birthdate
        {
            get { return Person.Birthdate; }
            set { Person.Birthdate = value;
                RaisePropertyChanged();
            }
        }
        

        #endregion

        public PersonVM(string firstname, string lastname, int ssn, DateTime birthdate)
        {
            Person = new Person(firstname, lastname, ssn, birthdate);
        }

    }
}
