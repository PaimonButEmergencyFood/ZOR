using System.Net;
using System.Net.Sockets;
using System.Text;
using ProjectZ;
using System.Reflection;

namespace ProjectZ {
    public class Session {
        public TcpClient client;
        public NetworkStream stream;
        public bool isRunning = true;

        private User? user;
        private Queue<NetworkPacket> _clsWaitAsyncSender;
        private Mutex _mutex_Async;

        private Queue<NetworkPacket> _clsWaitAsyncReceiver;
        private Mutex _mutex_Sync;

        public Session() {
            client = new TcpClient();
            user = new User();
        }

        bool IsNeedEnc(NetCMDTypes wCMD)
        {
            if (wCMD == NetCMDTypes.ZNO_CS_PING ||		
                wCMD == NetCMDTypes.ZNO_CS_MOVE || 
                wCMD == NetCMDTypes.ZNO_SC_MOVE ||
                wCMD == NetCMDTypes.ZNO_CS_STOP ||
                wCMD == NetCMDTypes.ZNO_SC_STOP ||
                wCMD == NetCMDTypes.ZNO_CS_DASH ||
                wCMD == NetCMDTypes.ZNO_SC_DASH ||
                wCMD == NetCMDTypes.ZNO_CS_RECONNECT ||
                wCMD == NetCMDTypes.ZNO_SC_RECONNECT ||
                wCMD == NetCMDTypes.ZNO_CS_REQ_LOCATION ||
                wCMD == NetCMDTypes.ZNO_SN_REQ_LOCATION ||
                wCMD == NetCMDTypes.ZNO_CS_MOVE_MOB ||
                wCMD == NetCMDTypes.ZNO_SC_MOVE_MOB ||
                wCMD == NetCMDTypes.ZNO_CN_LOCATION_MODIFY ||
                wCMD == NetCMDTypes.ZNO_SN_LOCATION_MODIFY ||
                wCMD == NetCMDTypes.ZNO_CS_ATTACK_START ||
                wCMD == NetCMDTypes.ZNO_SC_ATTACK_START ) {
                    return false;
                }
	        return true;
        }

        void xorEncode(byte[] src, uint srclen, byte[] key, uint keylen)
        {
            for (uint i = 0; i < srclen; i++)
            {
                src[i] ^= key[i % keylen];
            }
        }
        public void HandleClient(TcpClient client) {
            this.client = client;
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            stream = client.GetStream();
            Thread t = new Thread(run);
            t.Start();
        }
        public void Send(NetworkPacket packet) {
            /**
            if (IsNeedEnc(packet.Cmd)) {
                if (packet.Cmd == NetCMDTypes.ZNO_SC_REQ_SERVER_ADDR || packet.Cmd == NetCMDTypes.ZNO_SC_CONNECT) {
                    //Console.WriteLine("Encrypting with user key");
                    xorEncode(packet.data, (uint)packet.data.Length, Encoding.ASCII.GetBytes(user.SocialID), (uint)Encoding.ASCII.GetBytes(user.SocialID).Length);
                } else {
                    //Console.WriteLine("Encrypting");
                    xorEncode(packet.data, (uint)packet.data.Length, Encoding.ASCII.GetBytes(user.encryption_key), (uint)Encoding.ASCII.GetBytes(user.encryption_key).Length);
                }
            }
            stream.Write(packet.GetHeader(), 0, packet.GetHeader().Length);
            stream.Write(packet.data, 0, packet.data.Length);
            if (packet.Cmd == NetCMDTypes.ZNO_SC_REQ_SERVER_ADDR) {
                // close stream
                Console.WriteLine("Closing stream");
                //stream.Close();
                // return;
            }
            Console.WriteLine("Sent " + packet.Cmd.ToString());
            **/
        }
        private void run() {
            try {
                while (isRunning) {
                    byte[] data = new byte[6]; // read a header first
                    stream.Read(data, 0, data.Length);
                    NetworkPacket packet;
                    try {
                        packet = new NetworkPacket(data);
                        //Console.WriteLine("Received a packet");
                        // print the name of the cmd from the NetCMDTypes enum
                        //Console.WriteLine("cmd " + packet.Cmd.ToString());
                        byte[] body = new byte[packet.Length];
                        if (packet.Length > 0) {
                            stream.Read(body, 0, body.Length);
                            /**
                            if (IsNeedEnc(packet.Cmd)) {
                                if (packet.Cmd == NetCMDTypes.ZNO_CS_CONNECT || packet.Cmd == NetCMDTypes.ZNO_CS_REQ_SERVER_ADDR) {
                                    //Console.WriteLine("Decrypting");
                                    xorEncode(body, (uint)body.Length, Encoding.ASCII.GetBytes("ZenoniaOnline"), (uint)Encoding.ASCII.GetBytes("ZenoniaOnline").Length);
                                } else {
                                    //Console.WriteLine("Decrypting with user key");
                                    xorEncode(body, (uint)body.Length, Encoding.ASCII.GetBytes(user.encryption_key), (uint)Encoding.ASCII.GetBytes(user.encryption_key).Length);
                                }
                            }
                            packet.data = body;
                            **/
                        }

                        String func = "ProjectZ.API_" + packet.Cmd.ToString();
                        Console.WriteLine("func " + func);

                        /**
                        Type t = Type.GetType(func);
                        var instance = Activator.CreateInstance(t);
                        MethodInfo method = t.GetMethod(packet.Cmd.ToString());

                        method.Invoke(instance, new object[] {packet, this});
                        Console.WriteLine("Invoked at " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        **/
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                        // print time
                        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (e.GetType().Name == "NullReferenceException" || e.GetType().Name == "ArgumentNullException") {
                            Console.WriteLine("Function not implemented");
                        } else {
                            Console.WriteLine("Error: " + e.GetType().Name);
                            Console.WriteLine("Closing connection");
                            client.Close();
                            break;
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Closing connection");
                client.Close();
            }
        }
    }
}