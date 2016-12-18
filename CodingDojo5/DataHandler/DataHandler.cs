using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    public class DataHandler
    {
        private const string folder = @"Files/";
        private const string extension = ".txt";


        public String[] Load(string name)
        {

            String[] lines = File.ReadAllLines(folder + name);
            return lines;
        }

        public void Save(List<string> data)
        {
            //Erstellt eine neue Datei, schreibt das angegebene Zeichenfolgenarray in die Datei und schließt die Datei dann.
            File.WriteAllLines(folder + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToFileTimeUtc() + extension, data.ToArray());
        }

        public string[] QueryFilesFromFolder()
        {
            if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }

            //Macht Instanzmethoden zum Erstellen, Verschieben und Auflisten von Verzeichnissen und Unterverzeichnissen verfügbar
            DirectoryInfo info = new DirectoryInfo(folder);

            //Gibt eine Dateiliste des aktuellen Verzeichnisses zurück.
            var result = info.GetFiles("*" + extension);
            string[] temp = new string[result.Length];
            int i = 0;
            foreach (var item in result)
            {
                temp[i] = item.Name;
                i++;
            }
            return temp;
        }

        public void Delete(string name)
        {
            if (File.Exists(folder + name))
            {
                File.Delete(folder + name);
            }
        }

        public bool CheckIfFileExists(string name)
        {
            return File.Exists(folder + name + extension);
        }
    }
}
