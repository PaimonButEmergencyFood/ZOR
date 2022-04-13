namespace ProjectZ.NCommand.NConnection {
    public class CS_REQ_LOGIN
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Console.WriteLine("[CHANNEL] ----------------------------------------");
            Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::OnExecute");

            Encryption.instance.Decrypt(ref req);

            UInt16 version = 0;
            String user_id;
            String user_nickname;
            String user_profile_image_url;
            byte isBlocked = 0;
            byte isAuth = 0;
            String uuid;
            byte company;
            byte sale_code;

            version = req.U2();
            user_id = req.Get(req.U2());
            user_nickname = req.Get(req.U2());
            user_profile_image_url = req.Get(req.U2());
            isBlocked = req.U1();
            isAuth = req.U1();
            uuid = req.Get(req.U2());
            company = req.U1();
            sale_code = req.U1();

            // check if user blocked or allowed
            Console.WriteLine("CS_REQ_LOGIN SOCIALID: " + user_id);

            // TODO check version

            Console.WriteLine("version : " + version);
            Console.WriteLine("user_id : " + user_id);
            Console.WriteLine("user_nickname : " + user_nickname);
            Console.WriteLine("user_profile_image_url : " + user_profile_image_url);
            Console.WriteLine("isBlocked : " + isBlocked);
            Console.WriteLine("isAuth : " + isAuth);
            Console.WriteLine("uuid : " + uuid);
            Console.WriteLine("company : " + company);
            Console.WriteLine("sale_code : " + sale_code);

            _user.SetSocialID(user_id);
            _user.SetUserNickName(user_nickname);
            _user.SetUUID(uuid);

            _user.SetEncryptKey(Encryption.instance.GetKey());

            _user.SetCompany(company);
            _user.SetSaleCode(sale_code);
            _user.SetVersion(version);

            // TODO loginQuery -> sets user userseq -> primary key

            // todo check if userseq already connected

            if (NProxy.Proxy.instance.Initial(ref _user, _user.GetUserSeq()) == false) {
                Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::OnExecute::Initial failed");
                return;
            }

            Console.WriteLine("[CHANNEL CS_REQ_LOGIN] ProjectZ::Initial seq : " + _user.GetUserSeq());
            _user.SetState(NState.Static.instance.READYMAINFRIENDLIST());
            NProxy.Proxy.instance.RegistUser(ref _user);
        }
    }
}