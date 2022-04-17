namespace ProjectZ.NCommand.NFriends {
    public class CS_SOCIAL_NEWS_COUNT
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_SOCIAL_NEWS_COUNT");
            Console.WriteLine("+-------------------------------------------------------------------");

            Int16 count = 0;
            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_SOCIAL_NEWS_COUNT);
            rsp.U2((short)NetACKTypes.ACK_OK);
            rsp.U2(count);
            
            _user.GetSession().SendPacketAsync(rsp);
        }
    }
}
