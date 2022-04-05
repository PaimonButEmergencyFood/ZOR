namespace ProjectZ {
    public class API_ZNO_CS_REQ_SKILL_BUFF
    {
        public NetworkPacket ZNO_CS_REQ_SKILL_BUFF(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_REQ_SKILL_BUFF");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_SKILL_BUFF);
            rsp.U2((short)NetACKTypes.ACK_OK);
            rsp.U4((int)req.U4());
            rsp.U1(0);

            return rsp;
        }
    }
}