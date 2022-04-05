using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_USER_INFO_INVEN
    {
        public NetworkPacket ZNO_CS_REQ_USER_INFO_INVEN(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_USER_INFO_INVEN");
            Console.WriteLine("+-------------------------------------------------------------------");

            for (int i = (int)INVEN_BAG_TYPE.BAG_TYPE_NORMAL; i < (int)INVEN_BAG_TYPE.BAG_TYPE_MAX; i++) {
                //Bag pBag = session.user.GetBag((INVEN_BAG_TYPE)i);
            }
        }
    }
}
