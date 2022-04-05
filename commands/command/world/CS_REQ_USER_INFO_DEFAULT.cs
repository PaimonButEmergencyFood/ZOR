namespace ProjectZ {
    public class API_ZNO_CS_REQ_USER_INFO_DEFAULT
    {
        public NetworkPacket ZNO_CS_REQ_USER_INFO_DEFAULT(NetworkPacket req, Session session) {
            try {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_REQ_USER_INFO_DEFAULT");
            Console.WriteLine("+-------------------------------------------------------------------");

            int cur_slot = req.U1();

            Console.WriteLine("| cur_slot: " + cur_slot);

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_USER_INFO_DEFAULT);

            int added_attack = 100;
            int added_hp = 100;
            int posx = 0;
            int posy = 0;

            int degree = 0;

            //if (session.user.GetSpace()._space_type == SpaceType.WORLD && posx == 0 && posy == 0) {
            posx = 1804;
            posy = 508;

            //}

            rsp.U4((int)session.user.Userseq);
            rsp.U2((short)session.user.Characters[session.user.GetSlotIndex()].RemainStatPoint);
            rsp.U2((short)session.user.Characters[session.user.GetSlotIndex()].RemainSkillPoint);
            
            rsp.U4((int)session.user.Characters[session.user.GetSlotIndex()].Str);
            rsp.U4((int)session.user.Characters[session.user.GetSlotIndex()].Dex);
            rsp.U4((int)session.user.Characters[session.user.GetSlotIndex()].Con);
            rsp.U4((int)session.user.Characters[session.user.GetSlotIndex()].Spi);

            rsp.U4(0); // Expansion effect (additional experience buff)
            rsp.U4(0); // auto-routing time

            ProjectZ.Logic.Item item = session.user.GetEquip().GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG);
            if (item != null) {
                rsp.U2((short)item.Iconidx); // Cosmetic item index number -> avatar skin
            } else {
                rsp.U2(-1);
            }

            rsp.U1(0); // Number of open active skills

            rsp.U1(Constants.MAX_SKILL); // max skill count
            for (int i = 0; i < Constants.MAX_SKILL; i++) {
                rsp.U2((short)(i + session.user.Characters[session.user.GetSlotIndex()].Classtype * Constants.MAX_SKILL));
                rsp.U1((sbyte)session.user.Characters[session.user.GetSlotIndex()].ArraySkill[i]);
            }

            if (session.user.GetEquip().IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG)) {
                rsp.U1((sbyte)(session.user.GetEquip().HasItemCount() - 1));
            } else {
                rsp.U1((sbyte)session.user.GetEquip().HasItemCount());
            }

            for (int i = 0; i < (int)EnumItemEquipPosition.MAX_ITEM_EQUIP_POS; i++) {
                ProjectZ.Logic.Item item_ = session.user.GetEquip().GetItem((int)i);
                if (item_ != null) {
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
                    rsp.U1((sbyte)item_.EvolvePoint);
                    rsp.U1((sbyte)item_.EvolvePercent);
                    rsp.U1((sbyte)item_.EvolveValue);
                    rsp.U1((sbyte)item_.ClassType);
                    rsp.U1((sbyte)item_.SubType);
                    rsp.U1((sbyte)item_.Tid);
                }
            }

            rsp.U2((short)added_hp);
            rsp.U2((short)added_attack);

            int gender = 2;

            if (session.user.IsGenderOpen == 1) {
                gender = session.user.Gender;
            }

            rsp.U2((short)session.user.WpLastWeek);
            rsp.U1((sbyte)gender);

            return rsp;
            } catch (Exception e) {
                // print stacktrace
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
