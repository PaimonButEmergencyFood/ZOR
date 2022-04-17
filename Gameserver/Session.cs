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
        private Semaphore _queueMutex;
        private Semaphore _sendMutex;

        public Session(TcpClient pClient) {
            _packetQueue = new Queue<NetworkPacket>();
            _queueMutex = new Semaphore(1, 1);
            _sendMutex = new Semaphore(1, 1);

            client = pClient;
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            stream = client.GetStream();

            Thread t = new Thread(workAsync);
            t.Start();
        }

        public void OnPacket() {
            NetworkPacket packet;
            _queueMutex.WaitOne();
            while (_packetQueue.Count > 0) {
                packet = _packetQueue.Dequeue();

                Console.WriteLine("[SESSION: Received packet: " + packet.Cmd);

                NetCMDTypes command = packet.Cmd;

                if (command == NetCMDTypes.ZNO_CS_REQ_SERVER_ADDR) {
                    on_CS_REQ_SERVER_ADDR(ref packet);
                    continue;
                }

                if (command == NetCMDTypes.ZNO_CS_CONNECT) {
                    Console.WriteLine("[SESSION: New user connected");

                    if (_user != null) {
                        Console.WriteLine("[SESSION: User already connected");

                        NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_CONNECT);
                        rsp.U2(-11);
                        SendPacketAsync(rsp);
                        continue;
                    }

                    _user = new User();
                    var _this = this;
                    _user.Initialize();
                    _user.SetSession(ref _this);
                }

                if (command == NetCMDTypes.ZNO_CS_RECONNECT) {
                    Console.WriteLine("[SESSION: TODO on user reconnect");
                    continue;
                }

                if (_user == null) {
                    Console.WriteLine("[SESSION: User not connected");
                    continue;
                }

                User.State pState = _user.GetState();
                if (pState == null) {
                    Console.WriteLine("[SESSION: User state is null");
                    continue;
                }

                User.State.Command pCommand = pState.GetCommand((ushort)command);

                if (pCommand == null) {
                    Console.WriteLine("[SESSION: User state {0} has no command {1}", pState.GetName(), command.ToString());
                    continue;
                }
                Int64 starttick = DateTime.Now.Ticks;
                Console.WriteLine("[SESSION: Executing command {0} GID: {1}", command.ToString(), _user.GetUserInfo().userseq );

                pCommand(ref _user, ref packet);

                Console.WriteLine("[SESSION: Executed command {0} GID: {1} in {2} ticks", command.ToString(), _user.GetUserInfo().userseq, DateTime.Now.Ticks - starttick);
            }
            Console.WriteLine("[SESSION: No packets in queue");
            _queueMutex.Release();
        }

        public void ResetUser() {
            _user = null;
        }

        public int SendPacket(ref NetworkPacket pPacket, bool bStatus, bool bOneShot = true) {
            _sendMutex.WaitOne();
            if (pPacket.GetEncrypt()) {
                Encryption.instance.Encrypt(ref pPacket);
            }
            stream.Write(pPacket.GetHeader(), 0, pPacket.GetHeader().Length);
            stream.Write(pPacket.data, 0, pPacket.data.Length);
            _sendMutex.Release();

            return (int)pPacket.Length + pPacket.GetHeader().Length;
        }

        public async Task<int> SendPacketAsync(NetworkPacket pPacket) {
            await Task.Run(() => {
                _sendMutex.WaitOne();
                if (pPacket.GetEncrypt()) {
                    Encryption.instance.Encrypt(ref pPacket);
                }
                stream.Write(pPacket.GetHeader(), 0, pPacket.GetHeader().Length);
                stream.Write(pPacket.data, 0, pPacket.data.Length);
                _sendMutex.Release();

                return (int)pPacket.Length + pPacket.GetHeader().Length;
            });
            return 0;
        }

        private void on_CS_REQ_SERVER_ADDR(ref NetworkPacket pPacket) {
            Console.WriteLine("[CHANNEL] on_CS_REQ_SERVER_ADDR");

            String socialid;

            Encryption.instance.Decrypt_First(ref pPacket);

            socialid = pPacket.Get(pPacket.U2());

            Console.WriteLine("on_CS_REQ_SERVER_ADDR socialid: {0}", socialid);

            // TODO check if user is blocked if we have a blacklist or allowlist
            // TODO check if we reached the max amount of connected users

            String server_ip = "192.168.178.144";
            ushort server_port = 55000;
            short server_key = 1;

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_CS_REQ_SERVER_ADDR);
            rsp.U2((short)server_ip.Length);
            rsp.Set(server_ip);
            rsp.U2((short)server_port);
            rsp.U2(server_key);
            rsp.U2(0);
            Encryption.instance.EncryptFirst(socialid, ref rsp);
            SendPacketAsync(rsp);
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
                _queueMutex.Release();

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
                    _queueMutex.Release();

                    Thread t = new Thread(OnPacket);
                    t.Start();
                } catch (Exception e) {
                    Console.WriteLine("+------------------------------------------------------------");
                    Console.WriteLine("| ERROR!");
                    Console.WriteLine("+------------------------------------------------------------");
                    Console.WriteLine("| " + e.Message);
                    Console.WriteLine("| " + e.StackTrace);
                    Console.WriteLine("| " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Console.WriteLine("+------------------------------------------------------------");
                    client.Close();
                    break;
                }
            }
        }
    }
}