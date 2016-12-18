using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo5.Communication
{
    class Client
    {
        byte[] buffer = new byte[512];
        Socket clientsocket;
        Action<string> MessageInformer;
        Action AbortInformer;
        public Client(string ip, int port, Action<string> messageInformer, Action abortInformer)
        {
            try
            {
                this.AbortInformer = abortInformer;
                this.MessageInformer = messageInformer;
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);
                clientsocket = client.Client;
                StartReceiving();
            }
            catch (Exception)
            {
                messageInformer("Server not ready");
                AbortInformer(); //reset Client Communication
            }
        }

        public void StartReceiving()
        {
            //Start receiving in new Thread
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            string message = "";
            while (!message.Equals("@quit"))
            {
                int length = clientsocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                //inform GUI via delegate
                MessageInformer(message);
            }
            Close();
        }

        public void Send(string message)
        {
            if (clientsocket != null) //check if clientsocket connected!
            {
                clientsocket.Send(Encoding.UTF8.GetBytes(message));
            }
        }

        public void Close()
        {
            clientsocket.Close();
            AbortInformer();
        }


    }
}
