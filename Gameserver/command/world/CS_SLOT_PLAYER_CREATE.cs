namespace ProjectZ.command.world {
    public class CS_SLOT_PLAYER_CREATE {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);

            Console.WriteLine("[CHANNEL] CS_SLOT_PLAYER_CREATE::ONEXECUTE");
            byte slot_number = req.U1();
            byte class_type = req.U1();
            byte defaultstat = req.U1();

            if (slot_number < 0 || slot_number >= 8) {
                Console.WriteLine("[CHANNEL] CS_SLOT_PLAYER_CREATE::ONEXECUTE::ERROR::SLOT_NUMBER " + slot_number);
                return;
            }

            if (_user.GetUserInfo().array_Slot[slot_number].character_seq > 0 && _user.GetUserInfo().array_Slot[slot_number].makeCharacter == true) {
                Console.WriteLine("[CHANNEL] CS_SLOT_PLAYER_CREATE::ONEXECUTE::ERROR::SLOT_NUMBER " + slot_number + " ALREADY HAVE CHARACTER");

                NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_SLOT_PLAYER_CREATE);
                rsp.U2((short)NetACKTypes.ACK_UNKNOWN_ERROR);

                _user.GetSession().SendPacketAsync(rsp);
                return;
            }

            int ret = (int)NetACKTypes.ACK_OK;


            int str = 0;
            int con = 0;
            int dex = 0;
            int spi = 0;

            if (defaultstat == Convert.ToInt32(true)) {
                str = NLogic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_STR);
                con = NLogic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_CON);
                dex = NLogic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_DEX);
                spi = NLogic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_SPI);
            } else {
                str = new Random().Next() % (Constants.STAT_MAX - Constants.STAT_MIN) + Constants.STAT_MIN;
                dex = new Random().Next() % (Constants.STAT_MAX - Constants.STAT_MIN) + Constants.STAT_MIN;
                spi = new Random().Next() % (Constants.STAT_MAX - Constants.STAT_MIN) + Constants.STAT_MIN;
                con = Constants.STAT_SUM_MAX - (str + dex + spi);
            }

            uint character_seq = _user.GetCharacterInfoFromIndex(slot_number).characterseq;
            _user.GetCharacterInfoFromIndex(slot_number).str = (uint)str;
            _user.GetCharacterInfoFromIndex(slot_number).con = (uint)con;
            _user.GetCharacterInfoFromIndex(slot_number).dex = (uint)dex;
            _user.GetCharacterInfoFromIndex(slot_number).spi = (uint)spi;

            bool is_updated = Database.NoSql.instance.UpdateCharacter(_user.GetCharacterInfo());
            if (is_updated == false) {
                throw new Exception("[CHANNEL] CS_SLOT_PLAYER_CREATE::ONEXECUTE::ERROR::UPDATE_CHARACTER_FAILED");
            }

            if (_user.GetUserInfo().main_slot_index == -1) {
                _user.GetUserInfo().main_slot_index = slot_number;
                
                _user.GetUserInfo().array_Slot[slot_number].open = true;
                _user.GetUserInfo().array_Slot[slot_number].character_seq = character_seq;
                _user.GetUserInfo().array_Slot[slot_number].makeCharacter = true;
                _user.GetUserInfo().array_Slot[slot_number].level = 1;
                _user.GetUserInfo().array_Slot[slot_number].classtype = class_type;

                _user.GetCharacterInfoFromIndex(slot_number).event_stamina = -1;

                if (_user.GetUserInfo().array_Slot[1].open == false) {
                    _user.GetUserInfo().array_Slot[1].open = true;
                    _user.GetUserInfo().array_Slot[1].character_seq = 0;
                    _user.GetUserInfo().array_Slot[1].makeCharacter = false;
                    _user.GetUserInfo().array_Slot[1].remainStatResetCount = 3;
                }

                NProxy.Proxy.instance.FlushUserSlotInfoSyn(ref _user, slot_number);
            } else {
                _user.GetUserInfo().array_Slot[slot_number].open = true;
                _user.GetUserInfo().array_Slot[slot_number].character_seq = character_seq;
                _user.GetUserInfo().array_Slot[slot_number].makeCharacter = true;
                _user.GetUserInfo().array_Slot[slot_number].level = 1;
                _user.GetUserInfo().array_Slot[slot_number].classtype = class_type;

                _user.GetCharacterInfoFromIndex(slot_number).event_stamina = -1;

                NProxy.Proxy.instance.FlushUserSlotInfoSyn(ref _user, slot_number);
            }
        }
    }
}