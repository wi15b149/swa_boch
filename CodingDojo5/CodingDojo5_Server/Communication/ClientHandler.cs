using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingDojo5_Server.Communication
{
    class ClientHandler
    {
        private Action<string, Socket> action;
        private byte[] buffer = new byte[512];
        private Thread clientReceiveThread;
        const string endMessage = "@quit";

        public string Name { get; private set; }

        public Socket Clientsocket
        {
            get;
            private set;
        }

        public ClientHandler(Socket socket, Action<string, Socket> action)
        {
            this.Clientsocket = socket;
            this.action = action;
            //start receiving in a new thread
            clientReceiveThread = new Thread(Receive);
            clientReceiveThread.Start();
        }

        private void Receive()
        {
            string message = "";
            while (!message.Equals(endMessage))
            {
                int length = Clientsocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                //set name property if not already done
                if (Name == null && message.Contains(":"))
                {
                    Name = message.Split(':')[0];
                }
                //inform GUI via delegate
                action(message, Clientsocket);
            }
            Close();
        }

        public void Send(string message)
        {
            Clientsocket.Send(Encoding.UTF8.GetBytes(message));
        }

        public void Close()
        {
            Send(endMessage); //sends endmessage to client 
            Clientsocket.Close(1); //disconnects
            clientReceiveThread.Abort(); //abort client threads
        }
    }
}
