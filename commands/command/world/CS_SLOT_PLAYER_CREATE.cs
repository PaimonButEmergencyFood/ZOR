using ProjectZ.Common.Protocol.Protobuf;
using Google.Protobuf;

namespace ProjectZ {
    public class API_ZNO_CS_SLOT_PLAYER_CREATE
    {
        public NetworkPacket ZNO_CS_SLOT_PLAYER_CREATE(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_SLOT_PLAYER_CREATE");
            Console.WriteLine("+-------------------------------------------------------------------");

            byte slot_number = req.U1();
            byte class_type = req.U1();
            byte defaultstat = req.U1();

            Console.WriteLine("| slot_number: " + slot_number);
            Console.WriteLine("| class_type: " + class_type);
            Console.WriteLine("| defaultstat: " + defaultstat);

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_SLOT_PLAYER_CREATE);

            if (slot_number < 0 || slot_number > 7) {
                Console.WriteLine("| ERROR: slot number is out of range: " + slot_number);
                Console.WriteLine("+-------------------------------------------------------------------");
                return null;
            }

            if (session.user.Slots[slot_number].CharacterSeq > 0 && session.user.Slots[slot_number].MakeCharacter == true) {
                Console.WriteLine("| ERROR: slot is already in use: " + slot_number);
                Console.WriteLine("+-------------------------------------------------------------------");
                rsp.U2((short)NetACKTypes.ACK_UNKNOWN_ERROR);
                return rsp;
            }

            rsp.U2((short)NetACKTypes.ACK_OK);

            int str = 0;
            int con = 0;
            int dex = 0;
            int spi = 0;

            if (defaultstat == 1) {
                str = ProjectZ.Logic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_STR);
                con = ProjectZ.Logic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_CON);
                dex = ProjectZ.Logic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_DEX);
                spi = ProjectZ.Logic.Function.GetDefaultStat(class_type, ESTATNAME.STAT_SPI);
            } else {
                str = new Random().Next() % (ProjectZ.Constants.STAT_MAX - ProjectZ.Constants.STAT_MIN + 1) + ProjectZ.Constants.STAT_MIN;
                dex = new Random().Next() % (ProjectZ.Constants.STAT_MAX - ProjectZ.Constants.STAT_MIN + 1) + ProjectZ.Constants.STAT_MIN;
                spi = new Random().Next() % (ProjectZ.Constants.STAT_MAX - ProjectZ.Constants.STAT_MIN + 1) + ProjectZ.Constants.STAT_MIN;
                con = ProjectZ.Constants.STAT_SUM_MAX - (str + dex + spi);
            }

            int character_seq = 1;

            if (session.user.MainSlotIndex == -1) {
                session.user.MainSlotIndex = (sbyte)slot_number;
                session.user.SetSlotIndex(slot_number);

                Slot slot = new Slot();
                slot.Open = true;
                slot.CharacterSeq = (uint)character_seq;
                slot.MakeCharacter = true;
                slot.Level = 1;
                slot.Classtype = class_type;

                session.user.SetSlot(slot_number, slot);

                CharacterInfo character = new CharacterInfo();
                for (int i = 0; i < Constants.MAX_SKILL; i++) {
                    character.ArraySkill.Add(0);
                }
                for (int i = 0; i < 8; i++) {
                    character.ArrayQuickSlot.Add(new QuickSlot());
                }
                character.Characterseq = (uint)character_seq;
                character.EventStamina = -1;
                character.AvartarIconidx = 1000;
                character.Level = 1;
                character.Classtype = class_type;
                character.Str = (uint)str;
                character.Con = (uint)con;
                character.Dex = (uint)dex;
                character.Spi = (uint)spi;

                session.user.SetCharacter(slot_number, character);

                if (session.user.Slots[1].Open == false) {
                    Slot slot1 = new Slot();

                    slot1.Open = true;
                    slot1.CharacterSeq = 0;
                    slot1.MakeCharacter = false;
                    slot1.RemainStatResetCount = 3;

                    session.user.SetSlot(1, slot1);
                }
            } else {
                Slot slot = new Slot();
                slot.Open = true;
                slot.CharacterSeq = (uint)character_seq;
                slot.MakeCharacter = true;
                slot.Level = 1;
                slot.Classtype = class_type;

                session.user.SetSlot(slot_number, slot);

                CharacterInfo character = new CharacterInfo();
                character.Slotindex = slot_number;
                character.Characterseq = (uint)character_seq;
                character.EventStamina = -1;
                character.AvartarIconidx = 1000;
                character.Level = 1;
                character.Classtype = class_type;
                character.Str = (uint)str;
                character.Con = (uint)con;
                character.Dex = (uint)dex;
                character.Spi = (uint)spi;

                session.user.SetCharacter(slot_number, character);
            }

            session.user.SaveUser();

            Console.WriteLine("+-------------------------------------------------------------------");

            session.user.GiveBaseItem(slot_number);

            return rsp;
        }
    }
}
            