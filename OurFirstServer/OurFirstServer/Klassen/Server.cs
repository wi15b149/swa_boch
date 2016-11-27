using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OurFirstServer.Klassen
{
    class Server
    {
        private Socket serverSocket;
        private List<ClientHändler> clients = new List<ClientHändler>();
        public Informer inform;

        public List<ClientHändler> Clients
        {
            get { return clients; }
            set { clients = value; }
        }


        public Socket ServerSocket
        {
            get { return serverSocket; }
            set { serverSocket = value; }
        }


        public Server(string ipaddress, int port)
        {
            inform = SendToAllClients;
            serverSocket = new Socket(AddressFamily.InterNetwork,
               SocketType.Stream,
               ProtocolType.Tcp);

            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ipaddress), port));
            serverSocket.Listen(5);
            Console.WriteLine("ready to accept clients...");

            ThreadPool.QueueUserWorkItem(new WaitCallback(StartAccepting), serverSocket);

        }


        private void StartAccepting(object state)
        {
            //ServerSocket = (Socket)state;
            while (true)
            {
                Clients.Add(new ClientHändler(ServerSocket.Accept(), inform));
                Console.WriteLine("clients " + Clients.Count + " accepted");
            }


        }

        private void SendToAllClients(string message, Socket initiator)
        {
            foreach (var item in clients)
            {
                if (initiator != item.ClientSocket)
                {
                    item.SendMessage(message);
                }
            }
        }



    }
}
