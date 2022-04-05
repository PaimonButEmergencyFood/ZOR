using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_USER_INFO_INVEN_BAG
    {
        public NetworkPacket ZNO_CS_REQ_USER_INFO_INVEN_BAG(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_USER_INFO_INVEN_BAG");
            Console.WriteLine("+-------------------------------------------------------------------");

            int bag_type = req.U1();
            Bag bag = session.user.GetBag((INVEN_BAG_TYPE)bag_type);

            if (bag == null) {
                Console.WriteLine("| Bag is null");
                Console.WriteLine("+-------------------------------------------------------------------");
                return null;
            }

            int count = bag.HasItemCount();

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_USER_INFO_INVEN_BAG);

            rsp.U4((int)session.user.Userseq);
            rsp.U1((sbyte)bag_type);
            rsp.U1((sbyte)count);
            
        }
    }
}