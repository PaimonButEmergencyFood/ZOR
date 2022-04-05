using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_ENTER_MY_INFO
    {
        private void RecallProcess(User user, int recallUserSeq) {
            Console.WriteLine("[API_ZNO_CS_REQ_ENTER_MY_INFO] RecallProcess");
        }

        private void ChannelChangeProcess(User User, int channel_id) {
            Console.WriteLine("[API_ZNO_CS_REQ_ENTER_MY_INFO] ChannelChangeProcess");
        }
        public NetworkPacket ZNO_CS_REQ_ENTER_MY_INFO(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_ENTER_MY_INFO");
            Console.WriteLine("+-------------------------------------------------------------------");

            UInt32 recallUserSeq = req.U4();
            UInt16 channel_id = req.U2();

            Console.WriteLine("| recallUserSeq: " + recallUserSeq);
            Console.WriteLine("| channel_id: " + channel_id);
            Console.WriteLine("+-------------------------------------------------------------------");

            if (recallUserSeq > 0 && channel_id > 0) {
                RecallProcess(session.user, (int)recallUserSeq);
            }

            if (channel_id > 0) {
                ChannelChangeProcess(session.user, (int)channel_id);
            }

            Space pSpace = session.user.GetSpace();
            if (pSpace != null) {
                pSpace.LeaveUser(session.user);
            }

            Space pWorld = session.user.GetReserveSpace();
            if (pWorld == null) {
                Console.WriteLine("| user {0} entering world space", session.user.Nickname);
                Console.WriteLine("+-------------------------------------------------------------------");
                Space worldTree = Static.GETWORLDSPACETREE();
                pSpace = worldTree;
                session.user.SetWorldSpace(worldTree);
            }

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_ENTER_MY_INFO);

            if (pSpace == null) {
                rsp.U2((short)NetACKTypes.ACK_CHANNEL_USER_FULL);
                rsp.U4((int)session.user.Userseq);
                rsp.U2(0);
                rsp.U2(0);
                rsp.U2(0);
            } else {
                pSpace.EnterUser(session.user);
                rsp.U2((short)NetACKTypes.ACK_OK);
                rsp.U4((int)session.user.Userseq);
                rsp.U2(0); // session.user.GetBattle().GetData().X
                rsp.U2(0); // session.user.GetBattle().GetData().Y
                rsp.U2(0); // pSpace.GetData()._index
            }

            return rsp;
        }
    }
}
