namespace ProjectZ {
    public class API_ZNO_SC_REQ_MY_LEVEL_EXP
    {
        public NetworkPacket ZNO_SC_REQ_MY_LEVEL_EXP(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_SC_REQ_MY_LEVEL_EXP");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_MY_LEVEL_EXP);

            rsp.U4((int)session.user.Userseq);
            rsp.U1((sbyte)0); // is_level_up
            rsp.U2((short)session.user.Characters[session.user.GetSlotIndex()].Level);
            rsp.U8((long)session.user.Characters[session.user.GetSlotIndex()].Exp);
            rsp.U4(100); // getMaxExp
            rsp.U1(0);
            
            return rsp;
        }
    }
}
