using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using shared;

namespace serverCLI 
{
    class Program
    {
        private static System.Net.IPAddress remoteIPAddress = IPAddress.Parse("127.0.0.1");
        private static int remotePort = 5555;
        private static int localPort = 5000;
    
        // Thread signal.  
        public static void Receiver()
        {
            // Создаем UdpClient для чтения входящих данных
            UdpClient receivingUdpClient = new UdpClient(localPort);

            IPEndPoint RemoteIpEndPoint = null;

            try
            {
                Console.WriteLine(
                   "\n-----------*******Общий чат*******-----------");

                while (true)
                {
                    // Ожидание дейтаграммы
                    byte[] receiveBytes = receivingUdpClient.Receive(
                       ref RemoteIpEndPoint);
                    
                    //return the message to the client
                    receivingUdpClient.Send(receiveBytes, receiveBytes.Length, RemoteIpEndPoint);


                    // Преобразуем и отображаем данные
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    Console.WriteLine("from " + RemoteIpEndPoint);
                    Console.WriteLine(" --> " + returnData.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возникло исключение: " + ex.ToString() + "\n  " + ex.Message);
            }
        }

        public static int Main(String[] args)
        {
            Console.WriteLine("starting");
            
            IPHostEntry ipHostInfo = ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            
            //uncomment for global address so others can connect
            foreach (IPAddress ip in ipHostInfo.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }

            Receiver();
            return 0;
        }
    }
}
