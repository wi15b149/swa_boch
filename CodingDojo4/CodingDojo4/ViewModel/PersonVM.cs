using CodingDojo4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4.ViewModel
{
    public class PersonVM
    {
        
        Person Person { get; set; }

        #region Properties

        public string Firstname
        {
            get { return Person.Firstname; }
            set { Person.Firstname = value; }
        }
        public string Lastname
        {
            get { return Person.Lastname; }
            set { Person.Lastname = value; }
        }
        public int Ssn
        {
            get { return Person.Ssn; }
            set { Person.Ssn = value; }
        }
        public DateTime Birthdate
        {
            get { return Person.Birthdate; }
            set { Person.Birthdate = value; }
        }
        

        #endregion
        public PersonVM(string firstname, string lastname, int ssn, DateTime birthdate)
        {
            Person = new Person(firstname, lastname, ssn, birthdate);
        }

    }
}
