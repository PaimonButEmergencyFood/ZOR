namespace ProjectZ {
    public class API_ZNO_CS_REQ_AI_BATTLE_RESULT
    {
        public NetworkPacket ZNO_CS_REQ_AI_BATTLE_RESULT(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_REQ_AI_BATTLE_RESULT");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_AI_BATTLE_RESULT);

            rsp.U2(-1);
            rsp.U1(0);
            rsp.U1(0);
            rsp.U2(0);
            rsp.U2(0);
            rsp.U1(0);

            return rsp;
        }
    }
}