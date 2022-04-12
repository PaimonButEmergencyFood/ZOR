namespace ProjectZ {
    class Program {
        static void Main(string[] args) {
            /**
            User user = new User();
            User.State.Command pCommand = user.GetState().GetCommand((ushort)NetCMDTypes.ZNO_CS_CONNECT);
            if (pCommand == null) {
                Console.WriteLine("pCommand is null");
            }
            else {
                Console.WriteLine("pCommand is not null");
                pCommand(ref user, null);
                user.printGID();
            }
            **/

            TcpServer server = new TcpServer(54000);
            while (server.isRunning) {
                Thread.Sleep(1000);
            }

            /**
            User user = new User();
            user.SetUserSeq(0);
            NProxy.Proxy.instance.RegistUser(ref user);
            user = new User();
            user.SetUserSeq(1);
            NProxy.Proxy.instance.RegistUser(ref user);
            user = new User();
            user.SetUserSeq(2);
            NProxy.Proxy.instance.RegistUser(ref user);
            **/
        }
    }
}