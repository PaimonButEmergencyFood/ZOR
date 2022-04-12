namespace ProjectZ.NCommand.NConnection {
    public class CS_CONNECT
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Console.WriteLine("[CHANNEL] CS_CONNECT::ONEXECUTE");

            Encryption.instance.Decrypt_First(ref req);

            UInt16 social_len = (UInt16)req.U2();
            string social_id = req.Get(social_len);

            UInt16 type = req.U1();
            UInt16 server_id = req.U2();
            UInt16 channel_id = req.U2();

            Console.WriteLine("[CHANNEL] CS_CONNECT::ONEXECUTE::SOCIAL_ID: {0}", social_id);

            NetworkPacket response = new NetworkPacket(NetCMDTypes.ZNO_SC_CONNECT);
            response.U2((short)NetACKTypes.ACK_OK);
            // next 16 bytes are the new encryption key
            response.U4(Encryption.instance.GetKey());
            response.U4(Encryption.instance.GetKey1());
            response.U4(Encryption.instance.GetKey2());
            response.U4(Encryption.instance.GetKey3());

            Encryption.instance.EncryptFirst(social_id, ref response);
            response.SetNoEncrypt();
            _user.GetSession().SendPacket(ref response, true, true);
        }
    }
}