using System.Net;
using System.Net.Sockets;
using System.Text;
using ProjectZ;
using System.Reflection;

namespace ProjectZ {
    public class Session {
        private TcpClient client;
        private NetworkStream stream;
        private User? _user;
        private Queue<NetworkPacket> _packetQueue;
        private Mutex _queueMutex;
        private Mutex _sendMutex;

        public Session(TcpClient pClient) {
            _packetQueue = new Queue<NetworkPacket>();
            _queueMutex = new Mutex();
            _sendMutex = new Mutex();

            client = pClient;
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            stream = client.GetStream();

            Thread t = new Thread(workAsync);
            t.Start();
        }

        public void OnPacket() {
            _queueMutex.WaitOne();
            NetworkPacket packet = _packetQueue.Dequeue();
            _queueMutex.ReleaseMutex();
        }

        public void ResetUser() {
            _user = null;
        }

        public int SendPacket(NetworkPacket pPacket, bool bStatus, bool bOneShot = true) {
            _sendMutex.WaitOne();
            if (pPacket.GetEncrypt()) {
                Encryption.instance.Encrypt(ref pPacket);
            }
            stream.Write(pPacket.GetHeader(), 0, pPacket.GetHeader().Length);
            stream.Write(pPacket.data, 0, pPacket.data.Length);
            _sendMutex.ReleaseMutex();

            return (int)pPacket.Length + pPacket.GetHeader().Length;
        }

        public async Task<int> SendPacketAsync(NetworkPacket pPacket) {
            _sendMutex.WaitOne();
            if (pPacket.GetEncrypt()) {
                Encryption.instance.Encrypt(ref pPacket);
            }
            await stream.WriteAsync(pPacket.GetHeader(), 0, pPacket.GetHeader().Length);
            await stream.WriteAsync(pPacket.data, 0, pPacket.data.Length);
            _sendMutex.ReleaseMutex();

            return (int)pPacket.Length + pPacket.GetHeader().Length;
        }

        private void on_CS_REQ_SERVER_ADDR(NetworkPacket pPacket) {

        }

        private void work() {
            try {
                byte[] data = new byte[6]; // read a header first
                stream.Read(data, 0, data.Length);

                NetworkPacket packet = new NetworkPacket(data);
                    
                if (packet.Length > 0) {
                    byte[] body = new byte[packet.Length];
                    stream.Read(body, 0, body.Length);
                    packet.data = body;
                }

                _queueMutex.WaitOne();
                _packetQueue.Enqueue(packet);
                _queueMutex.ReleaseMutex();

                Thread t = new Thread(OnPacket);
                t.Start();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                client.Close();
            }
        }

        private void workAsync() { // ik this is not reall async
            while (true) {
                try {
                    byte[] data = new byte[6]; // read a header first
                    stream.Read(data, 0, data.Length);

                    NetworkPacket packet = new NetworkPacket(data);
                    
                    if (packet.Length > 0) {
                        byte[] body = new byte[packet.Length];
                        stream.Read(body, 0, body.Length);
                        packet.data = body;
                    }

                    _queueMutex.WaitOne();
                    _packetQueue.Enqueue(packet);
                    _queueMutex.ReleaseMutex();

                    Thread t = new Thread(OnPacket);
                    t.Start();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    client.Close();
                    break;
                }
            }
        }
    }
}