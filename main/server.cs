using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
#nullable disable
namespace Main
{
    class Server
    {
        public static void Main ()
        {
            Listener TcpListener = new Listener();
            TcpListener.Port = 8080;
            TcpListener.StartListening().Wait();
        }

    }

    class Listener
    {
        public int Port;
        private TcpListener tcpListener;

        public async Task StartListening ()
        {
            tcpListener = new TcpListener(IPAddress.Loopback, Port);
            tcpListener.Start();
            Console.WriteLine($"Server is listening on port {Port}");

            await AcceptTcpClient();
        }

        public async Task AcceptTcpClient()
        {

            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                NetworkStream networkStream = client.GetStream();
                StreamReader reader = new StreamReader(networkStream);
                string line = await reader.ReadLineAsync();

                Console.WriteLine($"Received: {line}");
            }
            
        }
    }

    class ClientConnection
    {
        public static void Hello ()
        {
            // string serverAddress = "127.0.0.1";

            
        }
    }
}