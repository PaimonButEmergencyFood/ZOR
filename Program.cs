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
            /**
            TcpServer server = new TcpServer(54000);
            while (server.isRunning) {
                Thread.Sleep(1000);
            }
            **/

            User user = new User();
            user.SetUserSeq(1);
            NProxy.Proxy.instance.Initial(ref user, user.GetUserSeq());
            NProxy.Proxy.instance.Initial(ref user, user.GetUserSeq());
            
            NProxy.Proxy.instance.RegistUser(ref user);

            NProxy.Proxy.instance.Final(ref user);

            NProxy.Proxy.instance.RegistUser(ref user);

            Console.WriteLine("Hello World!");

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

            /**
            RefTree<User> userTree = new RefTree<User>();
            User _user = new User();
            _user.SetSocialID("test");
            userTree.Add(0, ref _user);
            User _sampleuser = userTree.Get(0);
            Console.WriteLine("_sampleuser.GetSocialID(): {0}", _sampleuser.GetSocialID());
            _user = new User();
            _user.SetSocialID("test2");
            userTree.Add(1, ref _user);
            _sampleuser = userTree.Get(1);
            Console.WriteLine("_sampleuser.GetSocialID(): {0}", _sampleuser.GetSocialID());
            _user.SetSocialID("asdadas");
            _user = new User();
            _user = userTree.Get(1);
            Console.WriteLine("_sampleuser.GetSocialID(): {0}", _sampleuser.GetSocialID());
            userTree.Remove(0);
            _sampleuser = userTree.Get(0);
            if (_sampleuser == null) {
                Console.WriteLine("_sampleuser is null");
            }
            else {
                Console.WriteLine("_sampleuser is not null");
                Console.WriteLine("_sampleuser.GetSocialID(): {0}", _sampleuser.GetSocialID());
            }
            **/
        }
    }
}