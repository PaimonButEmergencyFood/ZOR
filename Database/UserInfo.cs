using LiteDB;

namespace Database {
    public class UserInfo {
        [BsonId]
        public uint	userseq {get; set; }

        public bool slot1_open {get; set; }
        public uint slot1_character_seq {get; set; }
        public bool slot1_makeCharacter {get; set; }
        public uint slot1_remainStatResetCount {get; set; }
        public uint slot1_classtype {get; set; }
        public uint slot1_level {get; set; }
        public ulong slot1_reg_date {get; set; }

        public bool slot2_open {get; set; }
        public uint slot2_character_seq {get; set; }
        public bool slot2_makeCharacter {get; set; }
        public uint slot2_remainStatResetCount {get; set; }
        public uint slot2_classtype {get; set; }
        public uint slot2_level {get; set; }
        public ulong slot2_reg_date {get; set; }

        public bool slot3_open {get; set; }
        public uint slot3_character_seq {get; set; }
        public bool slot3_makeCharacter {get; set; }
        public uint slot3_remainStatResetCount {get; set; }
        public uint slot3_classtype {get; set; }
        public uint slot3_level {get; set; }
        public ulong slot3_reg_date {get; set; }

        public bool slot4_open {get; set; }
        public uint slot4_character_seq {get; set; }
        public bool slot4_makeCharacter {get; set; }
        public uint slot4_remainStatResetCount {get; set; }
        public uint slot4_classtype {get; set; }
        public uint slot4_level {get; set; }
        public ulong slot4_reg_date {get; set; }

        public bool slot5_open {get; set; }
        public uint slot5_character_seq {get; set; }
        public bool slot5_makeCharacter {get; set; }
        public uint slot5_remainStatResetCount {get; set; }
        public uint slot5_classtype {get; set; }
        public uint slot5_level {get; set; }
        public ulong slot5_reg_date {get; set; }

        public bool slot6_open {get; set; }
        public uint slot6_character_seq {get; set; }
        public bool slot6_makeCharacter {get; set; }
        public uint slot6_remainStatResetCount {get; set; }
        public uint slot6_classtype {get; set; }
        public uint slot6_level {get; set; }
        public ulong slot6_reg_date {get; set; }

        public bool slot7_open {get; set; }
        public uint slot7_character_seq {get; set; }
        public bool slot7_makeCharacter {get; set; }
        public uint slot7_remainStatResetCount {get; set; }
        public uint slot7_classtype {get; set; }
        public uint slot7_level {get; set; }
        public ulong slot7_reg_date {get; set; }

        public bool slot8_open {get; set; }
        public uint slot8_character_seq {get; set; }
        public bool slot8_makeCharacter {get; set; }
        public uint slot8_remainStatResetCount {get; set; }
        public uint slot8_classtype {get; set; }
        public uint slot8_level {get; set; }
        public ulong slot8_reg_date {get; set; }

        public int	main_slot_index { get; set; }
        public string nickname { get; set; }  
        public string profile_url { get; set; }  
        public uint	score { get; set; }  
        public uint	heart_blocked { get; set; }  
        public uint	invite_blocked { get; set; }  
        public uint	profile_opened { get; set; }  
        public uint	company { get; set; }  
        public uint	sale_code { get; set; }  
        public uint	u8intro_state { get; set; }  
        public uint	wp_last_week { get; set; }  
        public uint	wp_cur_week { get; set; }  
        public ulong wp_reg_date { get; set; }  
        public uint	array_tutorial_1 { get; set; }  
        public uint	array_tutorial_2 { get; set; }  
        public uint	array_tutorial_3 { get; set; }  
        public uint	array_tutorial_4 { get; set; }  
        [BsonId]
        public string uuid { get; set; }  
        public uint	battle_aftereffect_time { get; set; }  
        public string reward { get; set; }  
        public uint	shard_Item_db_type { get; set; }  
        public ulong wp_last_reg_date { get; set; }  
        public ulong reserve1 { get; set; }  
        public ulong reserve2 { get; set; }  
        public ulong reserve3 { get; set; }  
        public ulong reserve4 { get; set; }  
        public ulong reserve5 { get; set; }  
        public ulong worldboss_hit { get; set; }  
        public ulong worldboss_point { get; set; }

        public static UserInfo FromUserInfo(Cache.UserInfo mInfo) {
            Database.UserInfo userInfo = new UserInfo();
            userInfo.userseq = mInfo.userseq;

            userInfo.slot1_open = mInfo.array_Slot[0].open;
            userInfo.slot1_character_seq = mInfo.array_Slot[0].character_seq;
            userInfo.slot1_classtype = mInfo.array_Slot[0].classtype;
            userInfo.slot1_level = mInfo.array_Slot[0].level;
            userInfo.slot1_reg_date = mInfo.array_Slot[0].reg_date;
            userInfo.slot1_makeCharacter = mInfo.array_Slot[0].makeCharacter;
            userInfo.slot1_remainStatResetCount = mInfo.array_Slot[0].remainStatResetCount;

            userInfo.slot2_open = mInfo.array_Slot[1].open;
            userInfo.slot2_character_seq = mInfo.array_Slot[1].character_seq;
            userInfo.slot2_classtype = mInfo.array_Slot[1].classtype;
            userInfo.slot2_level = mInfo.array_Slot[1].level;
            userInfo.slot2_reg_date = mInfo.array_Slot[1].reg_date; 
            userInfo.slot2_makeCharacter = mInfo.array_Slot[1].makeCharacter;
            userInfo.slot2_remainStatResetCount = mInfo.array_Slot[1].remainStatResetCount;

            userInfo.slot3_open = mInfo.array_Slot[2].open;
            userInfo.slot3_character_seq = mInfo.array_Slot[2].character_seq;
            userInfo.slot3_classtype = mInfo.array_Slot[2].classtype;
            userInfo.slot3_level = mInfo.array_Slot[2].level;
            userInfo.slot3_reg_date = mInfo.array_Slot[2].reg_date;
            userInfo.slot3_makeCharacter = mInfo.array_Slot[2].makeCharacter;
            userInfo.slot3_remainStatResetCount = mInfo.array_Slot[2].remainStatResetCount;

            userInfo.slot4_open = mInfo.array_Slot[3].open;
            userInfo.slot4_character_seq = mInfo.array_Slot[3].character_seq;
            userInfo.slot4_classtype = mInfo.array_Slot[3].classtype;
            userInfo.slot4_level = mInfo.array_Slot[3].level;
            userInfo.slot4_reg_date = mInfo.array_Slot[3].reg_date;
            userInfo.slot4_makeCharacter = mInfo.array_Slot[3].makeCharacter;
            userInfo.slot4_remainStatResetCount = mInfo.array_Slot[3].remainStatResetCount;
            
            userInfo.slot5_open = mInfo.array_Slot[4].open;
            userInfo.slot5_character_seq = mInfo.array_Slot[4].character_seq;
            userInfo.slot5_classtype = mInfo.array_Slot[4].classtype;
            userInfo.slot5_level = mInfo.array_Slot[4].level;
            userInfo.slot5_reg_date = mInfo.array_Slot[4].reg_date;
            userInfo.slot5_makeCharacter = mInfo.array_Slot[4].makeCharacter;
            userInfo.slot5_remainStatResetCount = mInfo.array_Slot[4].remainStatResetCount;

            userInfo.slot6_open = mInfo.array_Slot[5].open;
            userInfo.slot6_character_seq = mInfo.array_Slot[5].character_seq;
            userInfo.slot6_classtype = mInfo.array_Slot[5].classtype;
            userInfo.slot6_level = mInfo.array_Slot[5].level;
            userInfo.slot6_reg_date = mInfo.array_Slot[5].reg_date;
            userInfo.slot6_makeCharacter = mInfo.array_Slot[5].makeCharacter;
            userInfo.slot6_remainStatResetCount = mInfo.array_Slot[5].remainStatResetCount;

            userInfo.slot7_open = mInfo.array_Slot[6].open;
            userInfo.slot7_character_seq = mInfo.array_Slot[6].character_seq;
            userInfo.slot7_classtype = mInfo.array_Slot[6].classtype;
            userInfo.slot7_level = mInfo.array_Slot[6].level;
            userInfo.slot7_reg_date = mInfo.array_Slot[6].reg_date;
            userInfo.slot7_makeCharacter = mInfo.array_Slot[6].makeCharacter;
            userInfo.slot7_remainStatResetCount = mInfo.array_Slot[6].remainStatResetCount;

            userInfo.slot8_open = mInfo.array_Slot[7].open;
            userInfo.slot8_character_seq = mInfo.array_Slot[7].character_seq;
            userInfo.slot8_classtype = mInfo.array_Slot[7].classtype;
            userInfo.slot8_level = mInfo.array_Slot[7].level;
            userInfo.slot8_reg_date = mInfo.array_Slot[7].reg_date;
            userInfo.slot8_makeCharacter = mInfo.array_Slot[7].makeCharacter;
            userInfo.slot8_remainStatResetCount = mInfo.array_Slot[7].remainStatResetCount;

            userInfo.main_slot_index = mInfo.main_slot_index;
            userInfo.nickname = mInfo.nickname;
            userInfo.profile_url = mInfo.profile_url;
            userInfo.score = mInfo.score;
            userInfo.heart_blocked = mInfo.heart_blocked;
            userInfo.invite_blocked = mInfo.invite_blocked;
            userInfo.profile_opened = mInfo.profile_opened;
            userInfo.company = mInfo.company;
            userInfo.sale_code = mInfo.sale_code;
            userInfo.u8intro_state = mInfo.u8intro_state;
            userInfo.wp_last_week = mInfo.wp_last_week;
            userInfo.wp_cur_week = mInfo.wp_cur_week;
            userInfo.wp_reg_date = mInfo.wp_reg_date;
            userInfo.array_tutorial_1 = mInfo.array_tutorial[0];
            userInfo.array_tutorial_2 = mInfo.array_tutorial[1];
            userInfo.array_tutorial_3 = mInfo.array_tutorial[2];
            userInfo.array_tutorial_4 = mInfo.array_tutorial[3];
            userInfo.uuid = mInfo.uuid;
            userInfo.battle_aftereffect_time = mInfo.battle_aftereffect_time;
            userInfo.reward = mInfo.reward;
            userInfo.shard_Item_db_type = mInfo.shard_Item_db_type;
            userInfo.wp_last_reg_date = mInfo.wp_last_reg_date;
            userInfo.reserve1 = mInfo.reserve1;
            userInfo.reserve2 = mInfo.reserve2;
            userInfo.reserve3 = mInfo.reserve3;
            userInfo.reserve4 = mInfo.reserve4;
            userInfo.worldboss_hit = mInfo.worldboss_hit;
            userInfo.worldboss_point = mInfo.worldboss_point;

            return userInfo;
        }

        public static Cache.UserInfo ToUserInfo(UserInfo mInfo)
        {
            Cache.UserInfo userInfo = new Cache.UserInfo();

            userInfo.userseq = mInfo.userseq;

            userInfo.array_Slot[0].open = mInfo.slot1_open;
            userInfo.array_Slot[0].character_seq = mInfo.slot1_character_seq;
            userInfo.array_Slot[0].classtype = mInfo.slot1_classtype;
            userInfo.array_Slot[0].level = mInfo.slot1_level;
            userInfo.array_Slot[0].reg_date = mInfo.slot1_reg_date;
            userInfo.array_Slot[0].makeCharacter = mInfo.slot1_makeCharacter;
            userInfo.array_Slot[0].remainStatResetCount = mInfo.slot1_remainStatResetCount;

            userInfo.array_Slot[1].open = mInfo.slot2_open;
            userInfo.array_Slot[1].character_seq = mInfo.slot2_character_seq;
            userInfo.array_Slot[1].classtype = mInfo.slot2_classtype;
            userInfo.array_Slot[1].level = mInfo.slot2_level;
            userInfo.array_Slot[1].reg_date = mInfo.slot2_reg_date;
            userInfo.array_Slot[1].makeCharacter = mInfo.slot2_makeCharacter;
            userInfo.array_Slot[1].remainStatResetCount = mInfo.slot2_remainStatResetCount;

            userInfo.array_Slot[2].open = mInfo.slot3_open;
            userInfo.array_Slot[2].character_seq = mInfo.slot3_character_seq;
            userInfo.array_Slot[2].classtype = mInfo.slot3_classtype;
            userInfo.array_Slot[2].level = mInfo.slot3_level;
            userInfo.array_Slot[2].reg_date = mInfo.slot3_reg_date;
            userInfo.array_Slot[2].makeCharacter = mInfo.slot3_makeCharacter;
            userInfo.array_Slot[2].remainStatResetCount = mInfo.slot3_remainStatResetCount;
            
            userInfo.array_Slot[3].open = mInfo.slot4_open;
            userInfo.array_Slot[3].character_seq = mInfo.slot4_character_seq;
            userInfo.array_Slot[3].classtype = mInfo.slot4_classtype;
            userInfo.array_Slot[3].level = mInfo.slot4_level;
            userInfo.array_Slot[3].reg_date = mInfo.slot4_reg_date;
            userInfo.array_Slot[3].makeCharacter = mInfo.slot4_makeCharacter;
            userInfo.array_Slot[3].remainStatResetCount = mInfo.slot4_remainStatResetCount;

            userInfo.array_Slot[4].open = mInfo.slot5_open;
            userInfo.array_Slot[4].character_seq = mInfo.slot5_character_seq;
            userInfo.array_Slot[4].classtype = mInfo.slot5_classtype;
            userInfo.array_Slot[4].level = mInfo.slot5_level;
            userInfo.array_Slot[4].reg_date = mInfo.slot5_reg_date;
            userInfo.array_Slot[4].makeCharacter = mInfo.slot5_makeCharacter;
            userInfo.array_Slot[4].remainStatResetCount = mInfo.slot5_remainStatResetCount;

            userInfo.array_Slot[5].open = mInfo.slot6_open;
            userInfo.array_Slot[5].character_seq = mInfo.slot6_character_seq;
            userInfo.array_Slot[5].classtype = mInfo.slot6_classtype;
            userInfo.array_Slot[5].level = mInfo.slot6_level;
            userInfo.array_Slot[5].reg_date = mInfo.slot6_reg_date;
            userInfo.array_Slot[5].makeCharacter = mInfo.slot6_makeCharacter;
            userInfo.array_Slot[5].remainStatResetCount = mInfo.slot6_remainStatResetCount;

            userInfo.array_Slot[6].open = mInfo.slot7_open;
            userInfo.array_Slot[6].character_seq = mInfo.slot7_character_seq;
            userInfo.array_Slot[6].classtype = mInfo.slot7_classtype;
            userInfo.array_Slot[6].level = mInfo.slot7_level;
            userInfo.array_Slot[6].reg_date = mInfo.slot7_reg_date;
            userInfo.array_Slot[6].makeCharacter = mInfo.slot7_makeCharacter;
            userInfo.array_Slot[6].remainStatResetCount = mInfo.slot7_remainStatResetCount;

            userInfo.array_Slot[7].open = mInfo.slot8_open;
            userInfo.array_Slot[7].character_seq = mInfo.slot8_character_seq;
            userInfo.array_Slot[7].classtype = mInfo.slot8_classtype;
            userInfo.array_Slot[7].level = mInfo.slot8_level;
            userInfo.array_Slot[7].reg_date = mInfo.slot8_reg_date;
            userInfo.array_Slot[7].makeCharacter = mInfo.slot8_makeCharacter;
            userInfo.array_Slot[7].remainStatResetCount = mInfo.slot8_remainStatResetCount;

            userInfo.main_slot_index = mInfo.main_slot_index;
            userInfo.nickname = mInfo.nickname;
            userInfo.profile_url = mInfo.profile_url;
            userInfo.score = mInfo.score;
            userInfo.heart_blocked = mInfo.heart_blocked;
            userInfo.invite_blocked = mInfo.invite_blocked;
            userInfo.profile_opened = mInfo.profile_opened;
            userInfo.company = mInfo.company;
            userInfo.sale_code = mInfo.sale_code;
            userInfo.u8intro_state = mInfo.u8intro_state;
            userInfo.wp_last_week = mInfo.wp_last_week;
            userInfo.wp_cur_week = mInfo.wp_cur_week;
            userInfo.wp_reg_date = mInfo.wp_reg_date;
            userInfo.array_tutorial[0] = mInfo.array_tutorial_1;
            userInfo.array_tutorial[1] = mInfo.array_tutorial_2;
            userInfo.array_tutorial[2] = mInfo.array_tutorial_3;
            userInfo.array_tutorial[3] = mInfo.array_tutorial_4;
            userInfo.uuid = mInfo.uuid;
            userInfo.battle_aftereffect_time = mInfo.battle_aftereffect_time;
            userInfo .reward = mInfo.reward;
            userInfo.shard_Item_db_type = mInfo.shard_Item_db_type;
            userInfo.wp_last_reg_date = mInfo.wp_last_reg_date;
            userInfo.reserve1 = mInfo.reserve1;
            userInfo.reserve2 = mInfo.reserve2;
            userInfo.reserve3 = mInfo.reserve3;
            userInfo.reserve4 = mInfo.reserve4;
            userInfo.reserve5 = mInfo.reserve5;
            userInfo.worldboss_hit = mInfo.worldboss_hit;
            userInfo.worldboss_point = mInfo.worldboss_point;

            return userInfo;
        }
    }
}