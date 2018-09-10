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

        }

        public void StartListening(int port)
        {
            if (client != null)
                throw new Exception("Server port already creeated");

            client = new UdpClient(port);



        }

    }
}
