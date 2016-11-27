using OurFirstServer.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OurFirstServer
{
    class Program
    {
      

        static void Main(string[] args)
        {
            Server newserver = new Server("10.201.87.97", 9080);

            while (true)
            {
                Console.WriteLine("Do something");
                Thread.Sleep(2000);
            }

            
        }

       
    }
}
