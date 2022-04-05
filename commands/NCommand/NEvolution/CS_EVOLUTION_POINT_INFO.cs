namespace ProjectZ {
    public class API_ZNO_CS_EVOLUTION_POINT_INFO
    {
        public NetworkPacket ZNO_CS_EVOLUTION_POINT_INFO(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_EVOLUTION_POINT_INFO");
            Console.WriteLine("+-------------------------------------------------------------------");

            req.U4();

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_FAIRY_INFO);
            rsp.U2((short)NetACKTypes.ACK_OK);
            rsp.U2((short)session.user.Characters[session.user.GetSlotIndex()].EpMax);
            rsp.U2((short)session.user.Characters[session.user.GetSlotIndex()].EpCurrent);

            return rsp;
        }
    }
}
