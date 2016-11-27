using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OurFirstServer.Klassen
{
    class ClientHändler
    {
        private byte[] buffer = new byte[512];
        private Socket clientSocket;
        Informer inform;

        public ClientHändler(Socket socket, Informer inform)
        {
            ClientSocket = socket;
            this.inform = inform;
            ThreadPool.QueueUserWorkItem(ReceiveMessage);
        }

        public Socket ClientSocket
        {
            get
            {
                return clientSocket;
            }

            set
            {
                clientSocket = value;
            }
        }

        private void ReceiveMessage(object a)
        {

            while (true)
            {
                int length;
                string message;
                length = ClientSocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                inform(message, clientSocket);
                Console.WriteLine(message);
            }
           
        }

        public void SendMessage(string message)
        {
            try
            {
                clientSocket.Send(Encoding.UTF8.GetBytes(message));

            }
            catch (Exception)
            {
                Console.WriteLine("Client nicht verbunden!");
            }
            
        }
        
    }
}
