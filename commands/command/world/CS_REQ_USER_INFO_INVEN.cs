using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_USER_INFO_INVEN
    {
        public NetworkPacket ZNO_CS_REQ_USER_INFO_INVEN(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_USER_INFO_INVEN");
            Console.WriteLine("+-------------------------------------------------------------------");

            for (int i = (int)INVEN_BAG_TYPE.BAG_TYPE_NORMAL; i < (int)INVEN_BAG_TYPE.BAG_TYPE_MAX; i++) {
                Bag pBag = session.user.GetBag((INVEN_BAG_TYPE)i);

                if (pBag.IsLoad() == false) {
                    Console.WriteLine("| user {0} loading bag {1}", session.user.Nickname, i);
                    pBag.ItemLoadFromList(session.user.Items, session.user.GetSlotIndex());
                }
                Console.WriteLine("bag item count " + pBag.HasItemCount());
                session.user.SetBag((INVEN_BAG_TYPE)i, pBag);
            }

            Equip equip = session.user.GetEquip();
            equip.EquipAddFromCharacterInfo(session.user, session.user.Characters[session.user.GetSlotIndex()]);
            equip.UpdateCharacterInfo(session.user);

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_USER_INFO_INVEN);
            rsp.U4((int)session.user.Userseq);
            rsp.U4((int)session.user.Characters[session.user.GetSlotIndex()].Gold);
            rsp.U1((sbyte)INVEN_BAG_TYPE.BAG_TYPE_MAX);

            for (int i = 0; i < (int)INVEN_BAG_TYPE.BAG_TYPE_MAX; i++) {
                int maxSlotCount = Function.GetBagSlotMaxOpenCount((INVEN_BAG_TYPE)i);
                rsp.U1((sbyte)maxSlotCount);
            }

            if (equip.HasItemCount() <= 0) {
                Console.WriteLine("| EQUIPHASITEMCOUTN is zero GID: {0}", session.user.Userseq);
            }

            for (int i = 0; i < (int)EnumItemEquipPosition.MAX_ITEM_EQUIP_POS; i++) {
                Item item = equip.GetItem(i);
                if (item == null) {
                    continue;
                }

                rsp.U1((sbyte)i);
                rsp.U8((int)item.GetItemSeq);
                Console.WriteLine("| item.GetItemSeq: {0}", item.GetItemSeq);
            }

            Item pItem = equip.GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG);

            if (pItem != null) {
                rsp.U1((sbyte)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG);
                rsp.U8((long)pItem.GetItemSeq);
            }

            session.user.SetEquip(equip);
            Console.WriteLine("+-------------------------------------------------------------------");

            return rsp;
        }
    }
}
