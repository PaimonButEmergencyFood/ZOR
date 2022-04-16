using LiteDB;

namespace Database {
    public class CharacterInfo {
        public uint	characterseq { get; set; }
        public uint	userSeq { get; set; }
        public uint	classtype { get; set; }
        public uint	slotindex { get; set; }
        public uint	remain_stat_point { get; set; }
        public uint	remain_skill_point { get; set; }  
        public uint	ap_current { get; set; }  
        public uint	ep_current { get; set; }  
        public uint	ep_max { get; set; }  
        public ulong weapon { get; set; }  
        public uint	weapon_iconidx { get; set; }  
        public ulong helmet { get; set; }  
        public uint	helmet_iconidx { get; set; }  
        public ulong armor { get; set; }  
        public uint	armor_iconidx { get; set; }  
        public ulong glove { get; set; }  
        public ulong shoes { get; set; }  
        public ulong necklace { get; set; }  
        public ulong cloak { get; set; }  
        public ulong ring { get; set; }  
        public ulong charm { get; set; }  
        public ulong avartar { get; set; }
        public uint	avartar_iconidx { get; set; }  
        public ulong vehicle { get; set; }  
        public uint	vehicle_iconidx { get; set; }  
        public ulong title { get; set; }  
        public ulong fairy { get; set; }  
        public ulong battlepet { get; set; }  
        public uint	exp { get; set; }  
        public uint	level { get; set; }  
        public uint	str { get; set; }  
        public uint	dex { get; set; }  
        public uint	con { get; set; }  
        public uint	spi { get; set; }  

        public uint qs_type1 { get; set; }
        public ulong qs_index1 { get; set; }
        public uint qs_type2 { get; set; }  
        public ulong qs_index2 { get; set; }  
        public uint qs_type3 { get; set; }  
        public ulong qs_index3 { get; set; }  
        public uint qs_type4 { get; set; }  
        public ulong qs_index4 { get; set; }  
        public uint qs_type5 { get; set; }  
        public ulong qs_index5 { get; set; }  
        public uint qs_type6 { get; set; }  
        public ulong qs_index6 { get; set; }  
        public uint qs_type7 { get; set; }  
        public ulong qs_index7 { get; set; }  
        public uint qs_type8 { get; set; }  
        public ulong qs_index8 { get; set; }  

        public uint	skill_1 { get; set; }  
        public uint	skill_2 { get; set; }  
        public uint	skill_3 { get; set; }  
        public uint	skill_4 { get; set; }  
        public uint	skill_5 { get; set; }  
        public uint	skill_6 { get; set; }  
        public uint	skill_7 { get; set; }  
        public uint	skill_8 { get; set; }  
        public uint	skill_9 { get; set; }  
        public uint	skill_10 { get; set; }  
        public uint	skill_11 { get; set; }  
        public uint	skill_12 { get; set; }  
        public uint	skill_13 { get; set; }  
        public uint	skill_14 { get; set; }  
        public uint	skill_15 { get; set; }  
        public uint	skill_16 { get; set; }  
        public uint	skill_17 { get; set; }  
        public uint	skill_18 { get; set; }  
        public uint	skill_19 { get; set; }  
        public uint	skill_20 { get; set; }  

        public uint	gold { get; set; }  
        public int	event_stamina { get; set; }  
        public ulong recover_stamina_sec { get; set; }  
        public uint	drill_status { get; set; }  
        public uint	drill_time { get; set; }  
        public ulong drill_start { get; set; }  
        public ulong drill_end { get; set; }  
        public uint	consecutive_win { get; set; }  
        public string? win_comment { get; set; }  
        public ulong reg_date { get; set; }  
        public string? dungeon_clear_info { get; set; }  
        public string? bag_order_info { get; set; }  
        public string? buff_info { get; set; }  
        public string? battle_afterEffect_info { get; set; }  
        public uint	daily_ep { get; set; }  
        public ulong name_tag { get; set; }  
        public uint	name_tag_iconidx { get; set; }  
        public ulong reserve1 { get; set; }  
        public ulong reserve2 { get; set; }  
        public ulong reserve3 { get; set; }  
        public ulong reserve4 { get; set; }  
        public ulong reserve5 { get; set; }  

        public static CharacterInfo FromCharacterInfo(Cache.CharacterInfo info) {
            CharacterInfo characterInfo = new CharacterInfo();
            characterInfo.characterseq = info.characterseq;
            characterInfo.userSeq = info.userSeq;
            characterInfo.classtype = info.classtype;
            characterInfo.slotindex = info.slotindex;
            characterInfo.remain_stat_point = info.remain_stat_point;
            characterInfo.remain_skill_point = info.remain_skill_point;
            characterInfo.ap_current = info.ap_current;
            characterInfo.ep_current = info.ep_current;
            characterInfo.ep_max = info.ep_max;
            characterInfo.weapon = info.weapon;
            characterInfo.weapon_iconidx = info.weapon_iconidx;
            characterInfo.helmet = info.helmet;
            characterInfo.helmet_iconidx = info.helmet_iconidx;
            characterInfo.armor = info.armor;
            characterInfo.armor_iconidx = info.armor_iconidx;
            characterInfo.glove = info.glove;
            characterInfo.shoes = info.shoes;
            characterInfo.necklace = info.necklace;
            characterInfo.cloak = info.cloak;
            characterInfo.ring = info.ring;
            characterInfo.charm = info.charm;
            characterInfo.avartar = info.avartar;
            characterInfo.avartar_iconidx = info.avartar_iconidx;
            characterInfo.vehicle = info.vehicle;
            characterInfo.vehicle_iconidx = info.vehicle_iconidx;
            characterInfo.title = info.title;
            characterInfo.fairy = info.fairy;
            characterInfo.battlepet = info.battlepet;
            characterInfo.exp = info.exp;
            characterInfo.level = info.level;
            characterInfo.str = info.str;
            characterInfo.dex = info.dex;
            characterInfo.con = info.con;
            characterInfo.spi = info.spi;
            characterInfo.qs_type1 = info.array_QuickSlot[0].type;
            characterInfo.qs_index1 = info.array_QuickSlot[0].index;
            characterInfo.qs_type2 = info.array_QuickSlot[1].type;
            characterInfo.qs_index2 = info.array_QuickSlot[1].index;
            characterInfo.qs_type3 = info.array_QuickSlot[2].type;
            characterInfo.qs_index3 = info.array_QuickSlot[2].index;
            characterInfo.qs_type4 = info.array_QuickSlot[3].type;
            characterInfo.qs_index4 = info.array_QuickSlot[3].index;
            characterInfo.qs_type5 = info.array_QuickSlot[4].type;
            characterInfo.qs_index5 = info.array_QuickSlot[4].index;
            characterInfo.qs_type6 = info.array_QuickSlot[5].type;
            characterInfo.qs_index6 = info.array_QuickSlot[5].index;
            characterInfo.qs_type7 = info.array_QuickSlot[6].type;
            characterInfo.qs_index7 = info.array_QuickSlot[6].index;
            characterInfo.qs_type8 = info.array_QuickSlot[7].type;
            characterInfo.qs_index8 = info.array_QuickSlot[7].index;
            characterInfo.skill_1 = info.array_Skill[0];
            characterInfo.skill_2 = info.array_Skill[1];
            characterInfo.skill_3 = info.array_Skill[2];
            characterInfo.skill_4 = info.array_Skill[3];
            characterInfo.skill_5 = info.array_Skill[4];
            characterInfo.skill_6 = info.array_Skill[5];
            characterInfo.skill_7 = info.array_Skill[6];
            characterInfo.skill_8 = info.array_Skill[7];
            characterInfo.skill_9 = info.array_Skill[8];
            characterInfo.skill_10 = info.array_Skill[9];
            characterInfo.skill_11 = info.array_Skill[10];
            characterInfo.skill_12 = info.array_Skill[11];
            characterInfo.skill_13 = info.array_Skill[12];
            characterInfo.skill_14 = info.array_Skill[13];
            characterInfo.skill_15 = info.array_Skill[14];
            characterInfo.skill_16 = info.array_Skill[15];
            characterInfo.skill_17 = info.array_Skill[16];
            characterInfo.skill_18 = info.array_Skill[17];
            characterInfo.skill_19 = info.array_Skill[18];
            characterInfo.skill_20 = info.array_Skill[19];
            characterInfo.gold = info.gold;
            characterInfo.event_stamina = info.event_stamina;
            characterInfo.recover_stamina_sec = info.recover_stamina_sec;
            characterInfo.drill_status = info.drill_status;
            characterInfo.drill_time = info.drill_time;
            characterInfo.drill_start = info.drill_start;
            characterInfo.drill_end = info.drill_end;
            characterInfo.consecutive_win = info.consecutive_win;
            characterInfo.win_comment = info.win_comment;
            characterInfo.reg_date = info.reg_date;
            characterInfo.dungeon_clear_info = info.dungeon_clear_info;
            characterInfo.bag_order_info = info.bag_order_info;
            characterInfo.buff_info = info.buff_info;
            characterInfo.battle_afterEffect_info = info.battle_afterEffect_info;
            characterInfo.daily_ep = info.daily_ep;
            characterInfo.name_tag = info.name_tag;
            characterInfo.name_tag_iconidx = info.name_tag_iconidx;
            characterInfo.reserve1 = info.reserve1;
            characterInfo.reserve2 = info.reserve2;
            characterInfo.reserve3 = info.reserve3;
            characterInfo.reserve4 = info.reserve4;
            characterInfo.reserve5 = info.reserve5;

            return characterInfo;
        }

        public static Cache.CharacterInfo ToCharacterInfo(CharacterInfo info)
        {
            Cache.CharacterInfo characterInfo = new Cache.CharacterInfo();
            characterInfo.userSeq = info.userSeq;
            characterInfo.classtype = info.classtype;
            characterInfo.slotindex = info.slotindex;
            characterInfo.remain_stat_point = info.remain_stat_point;
            characterInfo.remain_skill_point = info.remain_skill_point;
            characterInfo.ap_current = info.ap_current;
            characterInfo.ep_current = info.ep_current;
            characterInfo.ep_max = info.ep_max;
            characterInfo.weapon = info.weapon;
            characterInfo.weapon_iconidx = info.weapon_iconidx;
            characterInfo.helmet = info.helmet;
            characterInfo.helmet_iconidx = info.helmet_iconidx;
            characterInfo.armor = info.armor;
            characterInfo.armor_iconidx = info.armor_iconidx;
            characterInfo.glove = info.glove;
            characterInfo.shoes = info.shoes;
            characterInfo.necklace = info.necklace;
            characterInfo.cloak = info.cloak;
            characterInfo.ring = info.ring;
            characterInfo.charm = info.charm;
            characterInfo.avartar = info.avartar;
            characterInfo.avartar_iconidx = info.avartar_iconidx;
            characterInfo.vehicle = info.vehicle;
            characterInfo.vehicle_iconidx = info.vehicle_iconidx;
            characterInfo.title = info.title;
            characterInfo.fairy = info.fairy;
            characterInfo.battlepet = info.battlepet;
            characterInfo.exp = info.exp;
            characterInfo.level = info.level;
            characterInfo.str = info.str;
            characterInfo.dex = info.dex;
            characterInfo.con = info.con;
            characterInfo.spi = info.spi;

            characterInfo.array_QuickSlot[0].type = info.qs_type1;
            characterInfo.array_QuickSlot[0].index = info.qs_index1;
            characterInfo.array_QuickSlot[1].type = info.qs_type2;
            characterInfo.array_QuickSlot[1].index = info.qs_index2;
            characterInfo.array_QuickSlot[2].type = info.qs_type3;
            characterInfo.array_QuickSlot[2].index = info.qs_index3;
            characterInfo.array_QuickSlot[3].type = info.qs_type4;
            characterInfo.array_QuickSlot[3].index = info.qs_index4;
            characterInfo.array_QuickSlot[4].type = info.qs_type5;
            characterInfo.array_QuickSlot[4].index = info.qs_index5;
            characterInfo.array_QuickSlot[5].type = info.qs_type6;
            characterInfo.array_QuickSlot[5].index = info.qs_index6;
            characterInfo.array_QuickSlot[6].type = info.qs_type7;
            characterInfo.array_QuickSlot[6].index = info.qs_index7;
            characterInfo.array_QuickSlot[7].type = info.qs_type8;
            characterInfo.array_QuickSlot[7].index = info.qs_index8;

            characterInfo.array_Skill[0] = info.skill_1;
            characterInfo.array_Skill[1] = info.skill_2;
            characterInfo.array_Skill[2] = info.skill_3;
            characterInfo.array_Skill[3] = info.skill_4;
            characterInfo.array_Skill[4] = info.skill_5;
            characterInfo.array_Skill[5] = info.skill_6;
            characterInfo.array_Skill[6] = info.skill_7;
            characterInfo.array_Skill[7] = info.skill_8;
            characterInfo.array_Skill[8] = info.skill_9;
            characterInfo.array_Skill[9] = info.skill_10;
            characterInfo.array_Skill[10] = info.skill_11;
            characterInfo.array_Skill[11] = info.skill_12;
            characterInfo.array_Skill[12] = info.skill_13;
            characterInfo.array_Skill[13] = info.skill_14;
            characterInfo.array_Skill[14] = info.skill_15;
            characterInfo.array_Skill[15] = info.skill_16;
            characterInfo.array_Skill[16] = info.skill_17;
            characterInfo.array_Skill[17] = info.skill_18;
            characterInfo.array_Skill[18] = info.skill_19;
            characterInfo.array_Skill[19] = info.skill_20;

            characterInfo.gold = info.gold;
            characterInfo.event_stamina = info.event_stamina;
            characterInfo.recover_stamina_sec = info.recover_stamina_sec;
            characterInfo.drill_status = info.drill_status;
            characterInfo.drill_time = info.drill_time;
            characterInfo.drill_start = info.drill_start;
            characterInfo.drill_end = info.drill_end;
            characterInfo.consecutive_win = info.consecutive_win;
            characterInfo.win_comment = info.win_comment;
            characterInfo.reg_date = info.reg_date;
            characterInfo.dungeon_clear_info = info.dungeon_clear_info;
            characterInfo.bag_order_info = info.bag_order_info;
            characterInfo.buff_info = info.buff_info;
            characterInfo.battle_afterEffect_info = info.battle_afterEffect_info;
            characterInfo.daily_ep = info.daily_ep;
            characterInfo.name_tag = info.name_tag;
            characterInfo.name_tag_iconidx = info.name_tag_iconidx;
            characterInfo.reserve1 = info.reserve1;
            characterInfo.reserve2 = info.reserve2;
            characterInfo.reserve3 = info.reserve3;
            characterInfo.reserve4 = info.reserve4;
            characterInfo.reserve5 = info.reserve5;

            return characterInfo;
        }
    }
}