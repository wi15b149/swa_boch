using CodingDojo4.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataProvider
{
    public class DataHandler
    {
        private string path;
        private const string filename = @"Personendaten.csv";

        public DataHandler(string path)
        {
            this.path = path;
        }

       
        public List<Person> Load()
        {
            List<Person> temp = new List<Person>();
            string[] lines = File.ReadAllLines(path + filename);
            foreach (var item in lines)
            {
                var values = item.Split(';');                
                temp.Add(new Person(values[0], values[1], int.Parse(values[2]), DateTime.ParseExact(values[3], "dd.MM.yyyy hh:mm:ss",
                                  CultureInfo.InvariantCulture)));
            }
            return temp;
        }

        public void Save(Person person)
        {
            File.AppendAllText(path + filename, string.Format("{0};{1};{2};{3}\r\n",
                person.Firstname, person.Lastname, person.Ssn, person.Birthdate));            
        }

        public void Delete()
        {
            if (File.Exists(path + filename))
            {
                File.Delete(path + filename);
            }
        }

        public bool CheckIfFileExists()
        {
            return File.Exists(path + filename);
        }
    }
}
