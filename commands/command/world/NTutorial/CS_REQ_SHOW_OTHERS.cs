namespace ProjectZ {
    public class API_ZNO_CS_REQ_SHOW_OTHERS
    {
        public NetworkPacket ZNO_CS_REQ_SHOW_OTHERS(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_REQ_SHOW_OTHERS");
            Console.WriteLine("+-------------------------------------------------------------------");

            sbyte show = (sbyte)req.U1();


            if (show == 0) {
                // TODO set state to tutorial
            }
            else {
                // EVEN MOAR TODO XD
            }

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_SHOW_OTHERS);
            rsp.U2(1);
            rsp.U1(show);
            return rsp;
        }
    }
}
