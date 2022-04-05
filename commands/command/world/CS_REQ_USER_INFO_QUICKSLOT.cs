namespace ProjectZ {
    public class API_ZNO_CS_REQ_USER_INFO_QUICKSLOT
    {
        public NetworkPacket ZNO_CS_REQ_USER_INFO_QUICKSLOT(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_USER_INFO_QUICKSLOT");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_USER_INFO_QUICKSLOT);
            rsp.U4((int)session.user.Userseq);
            rsp.U1(8);

            for (int i = 0; i < 8; i++) {
                rsp.U1((sbyte)i);
                rsp.U1((sbyte)session.user.Characters[session.user.GetSlotIndex()].ArrayQuickSlot[i].Type);
                rsp.U8((sbyte)session.user.Characters[session.user.GetSlotIndex()].ArrayQuickSlot[i].Index);
            }

            return rsp;
        }
    }
}
