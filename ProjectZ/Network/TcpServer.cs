using System.Net;
using System.Net.Sockets;
using System.Text;
using ProjectZ;
using System.Reflection;

namespace ProjectZ {
    public class TcpServer {
        TcpListener server;

        public bool isRunning {get; set;}
        private List<Session> sessions;
        public TcpServer(int port = 55000) {
            sessions = new List<Session>();
            // listen on any IP address
            server = new TcpListener(IPAddress.Any, port);
            TcpClient client;
            // start the server
            server.Start();
            isRunning = true;
            // run HandlePacketAsync in background
            while (isRunning) {
                Console.WriteLine("waiting for connection...");
                client = server.AcceptTcpClient();
                // create a new stream to read and write data
                //NetworkStream stream = client.GetStream();
                Console.WriteLine("new client connected");
                Session session = new Session(client);
                sessions.Add(session);
            }
        }
    }
}