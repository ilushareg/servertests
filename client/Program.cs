using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Threading;  
using System.Text;  

public class AsynchronousClient {  

    private static System.Net.IPAddress remoteIPAddress = IPAddress.Parse("172.16.6.11");
    private static int remotePort = 5555;
    private static int localPort = 5000;



    private static void Send(string datagram)
    {
        // Создаем UdpClient
        UdpClient sender = new UdpClient();

        // Создаем endPoint по информации об удаленном хосте
        IPEndPoint endPoint = new IPEndPoint(remoteIPAddress, localPort);

        try
        {
            // Преобразуем данные в массив байтов
            byte[] bytes = Encoding.UTF8.GetBytes(datagram);

            // Отправляем данные
            sender.Send(bytes, bytes.Length, endPoint);

            IPEndPoint RemoteIpEndPoint = null;

            byte[] receiveBytes = sender.Receive(
                ref RemoteIpEndPoint);

            string returnData = Encoding.UTF8.GetString(receiveBytes);
            Console.WriteLine("from " + RemoteIpEndPoint);
            Console.WriteLine(" --> " + returnData.ToString());
            

        }
        catch (Exception ex)
        {
            Console.WriteLine("Возникло исключение: " + ex.ToString() + "\n  " + ex.Message);
        }
        finally
        {
            // Закрыть соединение
            sender.Close();
        }
    }


    public static int Main(String[] args) {  


        while(true)
        {
            Send(args[0]);
        }

        return 0;  
    }  
}  