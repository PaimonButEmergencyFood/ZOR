namespace ProjectZ {
    class Program {
        private static void CreateCharacter() {
            int userseq = Database.NoSql.instance.GetNewUserSeq();
            if (userseq == -1) {
                Console.WriteLine("[MAIN] GetNewUserSeq failed");
                return;
            }

            if (userseq == 0) {
                userseq = 1;
            }
            Console.WriteLine("[MAIN] GetNewUserSeq {0}", userseq);

            Cache.User userInfo = new Cache.User();
            userInfo.Initialize(userseq);

            Cache.UserInfo uInfo = userInfo.GetUserInfo();

            if (uInfo == null) {
                Console.WriteLine("[MAIN] GetUserInfo failed");
                return;
            }

            uInfo.nickname = "TESTNICK";
            uInfo.uuid = "56A99BAFD15B4474A7D21CD91BE9C341";
            uInfo.profile_url = "https://dl.keksla.wtf/iOS_market_1024.png";
            uInfo.company = 5;
            uInfo.sale_code = 37;

            uInfo.array_Slot[0].open = true;
            uInfo.array_Slot[0].makeCharacter = false;
            uInfo.array_Slot[0].character_seq = 0;
            uInfo.array_Slot[0].remainStatResetCount = 3;

            Database.NoSql.instance.CreateUser(uInfo);

            for (int i = 0; i < 8; i++) {
                Cache.Character character = new Cache.Character();
                character.Initialize((uint)userseq, (uint)i + 1); // FIX character_seq != 0 in OnUserInfoAck

                Cache.CharacterInfo cInfo = character.GetCharacterInfo();

                if (cInfo == null) {
                    Console.WriteLine("[MAIN] GetCharacterInfo failed");
                    return;
                }

                Database.NoSql.instance.CreateCharacter(cInfo);
            }
            

            Console.WriteLine("[MAIN] CreateCharacter {0} success", userseq);
        }
        private static void Testdb() {
            Console.WriteLine("[TEST] db");

            Cache.CharacterInfo charInfo = new Cache.CharacterInfo();
            charInfo.avartar = 102;
            charInfo.characterseq = 1;
            charInfo.userSeq = 40;

            for (int i = 0; i < 8; i++) {
                charInfo.array_QuickSlot[i] = new Cache.QuickSlot();
            }

            charInfo.array_QuickSlot[0].index = 1;
            charInfo.array_QuickSlot[0].type = 1;

            Database.NoSql.instance.CreateCharacter(charInfo);

            Cache.CharacterInfo? info = Database.NoSql.instance.GetCharacter(40, 1);
            if (info == null) {
                Console.WriteLine("[TEST] GetCharacter failed");
                return;
            }
            Console.WriteLine("[TEST] GetCharacter success");

            throw new NotFiniteNumberException();

        }
        static void Main(string[] args) {
            if (args.Length != 0) {
                switch (args[0]) {
                    case "--testdb":
                        Testdb();
                        break;
                    default:
                        Console.WriteLine("Unknown command {0}", args[0]);
                        break;
                }
            }
            CreateCharacter();
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

            // create user
            /**
            uint userseq = 0;
            Cache.User cacheUser = new Cache.User();
            cacheUser.Initialize();
            Cache.UserInfo userInfo = cacheUser.GetUserInfo();
            if (userInfo == null) {
                Console.WriteLine("userInfo is null");
                return;
            }
            userInfo.userseq = userseq;
            userInfo.nickname = "TestNickname";
            userInfo.uuid = "291241201AJSASNJDBSAHUZBDIWQE";
            userInfo.u8intro_state = 0;

            Database.NoSql db = Database.NoSql.instance;
            db.CreateUser(userInfo);

            for (int i = 0; i < 8; i++) {
                Cache.CharacterInfo characterInfo = new Cache.CharacterInfo();
                characterInfo.userSeq = userInfo.userseq;
                characterInfo.characterseq = (uint)i;
                db.CreateCharacter(characterInfo);
            }
            **/
            
            TcpServer server = new TcpServer(54000);
            while (server.isRunning) {
                Thread.Sleep(1000);
            }
            
            

            /**
            User user = new User();
            user.SetUserSeq(1);
            NProxy.Proxy.instance.Initial(ref user, user.GetUserSeq());
            NProxy.Proxy.instance.Initial(ref user, user.GetUserSeq());
            
            NProxy.Proxy.instance.RegistUser(user.GetUserSeq());

            NProxy.Proxy.instance.Final(ref user);

            NProxy.Proxy.instance.RegistUser(user.GetUserSeq());

            Console.WriteLine("Hello World!");
            **/

            /**
            Console.WriteLine("Hello World!");

            Database.NoSql database = new Database.NoSql();

            Cache.UserInfo userInfo = new Cache.UserInfo();
            userInfo.userseq = 1;
            userInfo.uuid = "567189209384";
            userInfo.nickname = "TESTNICKNAME";
            userInfo.u8intro_state = 0;

            database.CreateUser(userInfo);
            for (int i = 0; i < 8; i++) {
                Cache.CharacterInfo characterInfo = new Cache.CharacterInfo();
                characterInfo.userSeq = userInfo.userseq;
                characterInfo.characterseq = (uint)i;
                database.CreateCharacter(characterInfo);
            }

            Cache.UserInfo? userInfo2 = database.GetUser((int)userInfo.userseq);
            if (userInfo2 == null) {
                Console.WriteLine("userInfo2 is null");
            }
            else {
                Console.WriteLine("userInfo2 is not null");
                Console.WriteLine("userInfo2.userseq: {0}", userInfo2.userseq);
                Console.WriteLine("userInfo2.uuid: {0}", userInfo2.uuid);
                Console.WriteLine("userInfo2.nickname: {0}", userInfo2.nickname);
                Console.WriteLine("userInfo2.u8intro_state: {0}", userInfo2.u8intro_state);

                for (int i = 0; i < 8; i++) {
                    Cache.CharacterInfo? characterInfo = database.GetCharacter((int)userInfo2.userseq, (int)i);
                    if (characterInfo == null) {
                        Console.WriteLine("characterInfo is null");
                    }
                    else {
                        Console.WriteLine("characterInfo is not null");
                        Console.WriteLine("characterInfo.userSeq: {0}", characterInfo.userSeq);
                        Console.WriteLine("characterInfo.characterseq: {0}", characterInfo.characterseq);
                    }
                }
            }
            **/

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