using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OurFirstServer.Klassen
{
    public delegate void Informer(string message, Socket initiator);
}
