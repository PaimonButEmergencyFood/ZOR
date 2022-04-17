namespace ProjectZ.NCommand.NMail {
    public class CS_GET_NEW_MAIL_COUNT
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO!: API_ZNO_CS_GET_NEW_MAIL_COUNT");
            Console.WriteLine("+-------------------------------------------------------------------");

            sbyte newMailCount = 0;
            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_GET_NEW_MAIL_COUNT);
            rsp.U2((short)NetACKTypes.ACK_OK);
            rsp.U1(newMailCount);

            _user.GetSession().SendPacketAsync(rsp);
        }
    }
}
