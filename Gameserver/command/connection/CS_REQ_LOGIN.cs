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
            Console.WriteLine("[CHANNEL]: CS_REQ_LOGIN SOCIALID: " + user_id);

            // TODO check version

            Console.WriteLine("[CHANNEL]: version : " + version);
            Console.WriteLine("[CHANNEL]: user_id : " + user_id);
            Console.WriteLine("[CHANNEL]: user_nickname : " + user_nickname);
            Console.WriteLine("[CHANNEL]: user_profile_image_url : " + user_profile_image_url);
            Console.WriteLine("[CHANNEL]: isBlocked : " + isBlocked);
            Console.WriteLine("[CHANNEL]: isAuth : " + isAuth);
            Console.WriteLine("[CHANNEL]: uuid : " + uuid);
            Console.WriteLine("[CHANNEL]: company : " + company);
            Console.WriteLine("[CHANNEL]: sale_code : " + sale_code);
            Console.WriteLine("[CHANNEL] ----------------------------------------");

            _user.SetSocialID(user_id);
            _user.SetUserNickName(user_nickname);
            _user.SetUUID("291241201AJSASNJDBSAHUZBDIWQE"); // #TODO

            _user.SetEncryptKey(Encryption.instance.GetKey());

            _user.SetCompany(company);
            _user.SetSaleCode(sale_code);
            _user.SetVersion(version);

            bool isBlock = false;
            string image_profile_url = "";

            if (loginQuery(ref _user, _user.GetUserNickName(), image_profile_url, _user.GetUUID(), ref isBlock) == false) {
                Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::OnExecute::LOGIN_QUERY_FAILED");
                return;
            }

            if (isBlock) {
                Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::OnExecute::USER_BLOCKED");
                return;
            }

            if (NProxy.Proxy.instance.Initial(ref _user, _user.GetUserSeq()) == false) {
                Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::OnExecute::Initial failed");
                return;
            }

            Console.WriteLine("[CHANNEL CS_REQ_LOGIN] ProjectZ::Initial seq : " + _user.GetUserSeq());
            _user.SetState(NState.Static.instance.READYMAINFRIENDLIST());
            try {
                NProxy.Proxy.instance.RegistUser(_user.GetUserSeq());
            } catch (KeyNotFoundException) {
                Console.WriteLine("FATAL ERROR: PROXY::REGISTUSER FAILED!");
                Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::OnExecute::RegistUser failed");
                return;
            }
        }

        private static bool loginQuery(ref User pUser, string username, string user_profile_image, string uuid, ref bool is_block) {
            int userseq = Database.NoSql.instance.GetUserSeq(uuid);
            if (userseq == -1) {
                Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::loginQuery::USER_NOT_FOUND");
                return false;
            }
            else {
                pUser.SetUserSeq((int)userseq);
                Console.WriteLine("[CHANNEL] CS_REQ_LOGIN::loginQuery::USER_FOUND");
            }

            is_block = false;
            return true;
        }
    }
}