namespace ProjectZ.NCommand.NConnect {
    public class CS_REQ_REMOTE_CONTROL
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);
            Console.WriteLine("+-------------------------------------------------------------------");
	        Console.WriteLine("| TODO!: API_ZNO_CS_REQ_REMOTE_CONTROL");
            Console.WriteLine("+-------------------------------------------------------------------");

            sbyte _front_news_banner = 0;
            sbyte _top_news_banner = 0;
            sbyte _cpi_button = 0;

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_REMOTE_CONTROL);
            rsp.U2(1);
            rsp.U1(_front_news_banner);
            rsp.U1(_top_news_banner);
            rsp.U1(_cpi_button);

            Console.WriteLine("| front_news_banner: " + _front_news_banner);
            Console.WriteLine("| top_news_banner: " + _top_news_banner);
            Console.WriteLine("| cpi_button: " + _cpi_button);
            Console.WriteLine("+-------------------------------------------------------------------");

            _user.GetSession().SendPacketAsync(rsp);
        }
    }
}
            