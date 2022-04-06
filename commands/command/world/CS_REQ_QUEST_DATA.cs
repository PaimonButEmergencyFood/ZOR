namespace ProjectZ {
    public class API_ZNO_CS_REQ_QUEST_DATA
    {
        public NetworkPacket ZNO_CS_REQ_QUEST_DATA(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_REQ_QUEST_DATA");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_QUEST_DATA);

            rsp.U1(0);
            rsp.U1(0);

            return rsp;
        }
    }
}