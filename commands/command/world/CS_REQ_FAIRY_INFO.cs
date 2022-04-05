namespace ProjectZ {
    public class API_ZNO_CS_REQ_FAIRY_INFO
    {
        public NetworkPacket ZNO_CS_REQ_FAIRY_INFO(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_FAIRY_INFO");
            Console.WriteLine("+-------------------------------------------------------------------");

            int userSeq = (int)req.U4();

            UInt64 fairyItemSeq = session.user.Characters[userSeq].Fairy;
            ProjectZ.Logic.Bag bag = session.user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_FAIRY);

            if (bag == null) {
                Console.WriteLine("| Bag is null");
                Console.WriteLine("+-------------------------------------------------------------------");
                return null;
            }

            ProjectZ.Logic.Item item = bag.GetItem((uint)fairyItemSeq);
            if (item == null) {
                Console.WriteLine("| Item is null");
                Console.WriteLine("+-------------------------------------------------------------------");
                return null;
            }

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_FAIRY_INFO);
            rsp.U4((int)session.user.Userseq);
            rsp.U2((short)item.BagSlotNumber);
            rsp.U8((long)fairyItemSeq);
            rsp.U1(0);
            rsp.U1(0);
            rsp.U1(1);
            rsp.U1(-1);
            rsp.U1(0);
            rsp.U1(0);
            rsp.U1((sbyte)item.Quality);
            rsp.U1((sbyte)item.Level);

            for (int i = 0; i < 7; i++) {
                rsp.U1((sbyte)item.EffType[i]);
                rsp.U1((sbyte)item.EffPos[i]);
                rsp.U1((sbyte)item.EffValue[i]);
            }
            rsp.U1(0);
            rsp.U1(0);
            rsp.U1(0);
            rsp.U1(0);
            rsp.U1(0);
            rsp.U1(0);
            rsp.U2((short)item.EvolvePoint);
            rsp.U2((short)item.EvolvePercent);
            rsp.U2(0);
            rsp.U1((sbyte)item.ClassType);
            rsp.U1((sbyte)item.SubType);
            rsp.U2((short)item.Tid);

            return rsp;
        }
    }
}
