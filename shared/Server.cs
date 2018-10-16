using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;


namespace shared.Net
{
    
    class Server
    {
        UdpClient client = null;

        Server()
        {
            StartListening(5000);
        }

        public void StartListening(int port)
        {
            if (client != null)
            {
                throw new Exception("Server port already creeated");
            }
            
            client = new UdpClient(port);

            


        }

        public void Stop()
        {
            if(client != null)
            {
                client.Close();
                client = null;
            } 
            else 
            {
                throw new Exception("Can't stop server it's not running");
            }
        }

    }
}
