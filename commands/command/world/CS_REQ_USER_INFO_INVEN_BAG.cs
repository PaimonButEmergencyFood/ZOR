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

            List<Item> itemlist = bag.GetItemVector();
            foreach (var item_ in itemlist) {
                rsp.U1((sbyte)item_.BagSlotNumber);
                rsp.U8((long)item_.Seq);

                rsp.U1((sbyte)item_.GetEquipPos());
                rsp.U8(item_.GetItemSeq);

                rsp.U1((sbyte)item_.CurDuration);
                rsp.U1((sbyte)item_.MaxDuration);
                rsp.U1((sbyte)item_.Quantity);
                rsp.U1((sbyte)item_.SetType);
                rsp.U1((sbyte)item_.NonIdentity);
                rsp.U1((sbyte)item_.CurRefineStep);

                rsp.U1((sbyte)item_.Quality);
                rsp.U1((sbyte)item_.Level);

                for (int b = 0; b < 7; b++) {
                    rsp.U1((sbyte)item_.EffType[b]);
                    rsp.U1((sbyte)item_.EffPos[b]);

                    if (b == 0 && ItemResource.GetItemSubType(item_) == (int)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG) {
                        // remaintime = RegDate + (EffValue[0] * 60) - time()

                        // if remaintime > 0 then
                        //     rsp.U2(remaintime / 60)
                        // else
                        rsp.U2(0);
                    }
                    if (b == 0 && ItemResource.GetItemSubType(item_) == (int)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG_WORLDBOSS) {
                        // remaintime = RegDate + (EffValue[0] * 60) - time()

                        // if remaintime > 0 then
                        //     rsp.U2(remaintime / 60)
                        // else
                        rsp.U2(0);
                    } else {
                        rsp.U2((short)item_.EffValue[b]);
                    }
                }

                rsp.U1((sbyte)item_.OpenUpgradeStoneSlot);
                rsp.U1((sbyte)item_.AbilityEnhanceRate);
                rsp.U1((sbyte)item_.MaxEnhanceStep);
                rsp.U1((sbyte)item_.BuyUse);

                rsp.U1((sbyte)item_.EvolveStep);
                rsp.U1((sbyte)item_.EvolveMax);
                rsp.U2((short)item_.EvolvePoint);
                rsp.U2((short)item_.EvolvePercent);
                rsp.U2((sbyte)item_.EvolveValue);
                rsp.U1((sbyte)item_.ClassType);
                rsp.U1((sbyte)item_.SubType);
                rsp.U2((sbyte)item_.Tid);
            }

            return rsp;
        }
    }
}