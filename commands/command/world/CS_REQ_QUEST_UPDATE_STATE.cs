using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_QUEST_UPDATE_STATE
    {
        public NetworkPacket ZNO_CS_REQ_QUEST_UPDATE_STATE(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_QUEST_UPDATE_STATE");
            Console.WriteLine("+-------------------------------------------------------------------");

            // s16 -> ack
            // u16 -> questtid
            // s8 -> state

            UInt16 questtid = req.U2();
            sbyte state = (sbyte)req.U1();
            byte idx = req.U1();

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_QUEST_UPDATE_STATE);

            rsp.U2((short)NetACKTypes.ACK_OK);
            rsp.U2((short)questtid);
            rsp.U1((sbyte)state);

            return rsp;
        }
    }
}