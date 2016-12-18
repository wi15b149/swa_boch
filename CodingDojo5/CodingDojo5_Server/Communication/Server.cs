using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingDojo5_Server.Communication
{
    class Server
    {
        Socket serverSocket;
        List<ClientHandler> clients = new List<ClientHandler>();
        Action<string> GuiUpdater;
        Thread acceptingThread; //handles the accepting of new clients

        public Server(string ip, int port, Action<string> guiUpdater)
        {
            GuiUpdater = guiUpdater;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            serverSocket.Listen(5);

        }
        public void StartAccepting()
        {
            acceptingThread = new Thread(new ThreadStart(Accept));
            acceptingThread.IsBackground = true;
            acceptingThread.Start();
        }

        private void Accept()
        {
            while (acceptingThread.IsAlive)
            {
                try
                {
                    clients.Add(new ClientHandler(serverSocket.Accept(), new Action<string, Socket>(NewMessageReceived)));
                }
                catch (Exception e)
                {
                    //executed if serversocket.close is called
                }
            }
        }

        public void StopAccepting()
        {
            serverSocket.Close();
            acceptingThread.Abort(); //abort accepting thread
            //close all client threads and connections
            foreach (var item in clients)
            {
                item.Close();
            }
            //remove all entries from the list
            clients.Clear();

        }

        public void DisconnectSpecificClient(string name)
        {
            foreach (var item in clients)
            {
                if (item.Name.Equals(name))
                {
                    item.Close();
                    clients.Remove(item); //remove Clienthandler object from list; that works only if we break the foreach after that operation
                    break;
                }
            }
        }

        private void NewMessageReceived(string message, Socket senderSocket)
        {
            //update gui
            GuiUpdater(message);
            //write message to all clients
            foreach (var item in clients)
            {
                if (item.Clientsocket != senderSocket)
                {
                    item.Send(message);
                }
            }

        }
    }
}