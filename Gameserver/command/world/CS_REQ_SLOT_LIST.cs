namespace ProjectZ.command.world {
    public class CS_REQ_SLOT_LIST {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_SLOT_LIST);

            rsp.U1((sbyte)_user.GetUserInfo().main_slot_index);

            rsp.U1((sbyte)_user.GetUserInfo().u8intro_state);

            int count = 0;
            for (int i = 0; i < 8; i++) {
                if (_user.GetUserInfo().array_Slot[i].open == true) {
                    count++;
                }
            }

            rsp.U1((sbyte)count);

            for (int i = 0; i < 8; i++) {
                if (_user.GetUserInfo().array_Slot[i].open == true) {
                    rsp.U1((sbyte)i);
                    rsp.U1((sbyte)_user.GetUserInfo().array_Slot[i].remainStatResetCount);
                }
            }
            int characterMaxCount = 0;
            for (int i = 0; i < 8; i++) {
                if (_user.GetUserInfo().array_Slot[i].open == true && _user.GetUserInfo().array_Slot[i].makeCharacter == true && _user.GetCharacterInfoFromIndex(i).characterseq != 0) {
                    characterMaxCount++;
                }
            }

            rsp.U1((sbyte)characterMaxCount);

            for (int i = 0; i < 8; i++) {
                if (_user.GetUserInfo().array_Slot[i].open == true && _user.GetUserInfo().array_Slot[i].makeCharacter == true && _user.GetCharacterInfoFromIndex(i).characterseq != 0) {
                    rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).slotindex);

                    rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).classtype);
                    rsp.U2((short)_user.GetCharacterInfoFromIndex(i).level);

                    Console.WriteLine("[CHANNEL] FIXME birthday string");

                    string birthday = "20220101";
                    rsp.U2((short)birthday.Length);
                    rsp.Set(birthday);

                    rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).drill_status);
                    rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).drill_time);
                    rsp.U8((long)(_user.GetCharacterInfoFromIndex(i).drill_end - _user.GetCharacterInfoFromIndex(i).drill_start));

                    if (_user.GetCharacterInfoFromIndex(i).avartar_iconidx == 1000) {
                        rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).helmet_iconidx);
                        rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).armor_iconidx);
                        rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).weapon_iconidx);
                        rsp.U1((sbyte)_user.GetCharacterInfoFromIndex(i).weapon_iconidx);
                        rsp.U1(0);
                    } else {
                        rsp.U1((sbyte)(_user.GetCharacterInfoFromIndex(i).avartar_iconidx + 100));
                        rsp.U1((sbyte)(_user.GetCharacterInfoFromIndex(i).avartar_iconidx + 100));
                        rsp.U1((sbyte)(_user.GetCharacterInfoFromIndex(i).avartar_iconidx + 100));
                        rsp.U1((sbyte)(_user.GetCharacterInfoFromIndex(i).avartar_iconidx + 100));
                        rsp.U1(0);
                    }
                }
            }

            rsp.U1((sbyte)Constants.MAX_CLASS_TYPE);
            for (int i = 0; i < Constants.MAX_CLASS_TYPE; i++) {
                rsp.U1((sbyte)ProjectZ.NLogic.Function.GetDefaultStat(i, ESTATNAME.STAT_STR));
                rsp.U1((sbyte)ProjectZ.NLogic.Function.GetDefaultStat(i, ESTATNAME.STAT_DEX));
                rsp.U1((sbyte)ProjectZ.NLogic.Function.GetDefaultStat(i, ESTATNAME.STAT_CON));
                rsp.U1((sbyte)ProjectZ.NLogic.Function.GetDefaultStat(i, ESTATNAME.STAT_SPI));
            }

            _user.GetSession().SendPacketAsync(rsp);
        }
    }
}