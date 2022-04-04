using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_ENTER_MY_INFO
    {
        public NetworkPacket ZNO_CS_REQ_ENTER_MY_INFO(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_ENTER_MY_INFO");
            Console.WriteLine("+-------------------------------------------------------------------");

            UInt32 recallUserSeq = req.U4();
            UInt16 channel_id = req.U2();

            Console.WriteLine("| recallUserSeq: " + recallUserSeq);
            Console.WriteLine("| channel_id: " + channel_id);
            Console.WriteLine("+-------------------------------------------------------------------");

            if (channel_id > 0) {
                // TODO move user to channel
            }

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_ENTER_MY_INFO);
            rsp.U2((short)NetACKTypes.ACK_OK);
            rsp.U4((int)session.user.Userseq);
            rsp.U2(0);
            rsp.U2(0);
            rsp.U2(0);

            return rsp;
        }
    }
}
