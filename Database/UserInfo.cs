using LiteDB;

namespace Database {
    public class UserInfo {
    [BsonId]
	public uint	userseq {get; set; }

	public int slot1_open {get; set; }
    public int slot1_seq {get; set; }
    public int slot1_classtype {get; set; }
    public int slot_level {get; set; }
    public ulong slot1_reg_date {get; set; }

    public int slot2_open {get; set; }
    public int slot2_seq {get; set; }
    public int slot2_classtype {get; set; }
    public int slot2_level {get; set; }
    public ulong slot2_reg_date {get; set; }


    public int slot3_open {get; set; }
    public int slot3_seq {get; set; }
    public int slot3_classtype {get; set; }
    public int slot3_level {get; set; }
    public ulong slot3_reg_date {get; set; }

    public int slot4_open {get; set; }
    public int slot4_seq {get; set; }
    public int slot4_classtype {get; set; }
    public int slot4_level {get; set; }
    public ulong slot4_reg_date {get; set; }

    public int slot5_open {get; set; }
    public int slot5_seq {get; set; }
    public int slot5_classtype {get; set; }
    public int slot5_level {get; set; }
    public ulong slot5_reg_date {get; set; }

    public int slot6_open {get; set; }
    public int slot6_seq {get; set; }
    public int slot6_classtype {get; set; }
    public int slot6_level {get; set; }
    public ulong slot6_reg_date {get; set; }

    public int slot7_open {get; set; }
    public int slot7_seq {get; set; }
    public int slot7_classtype {get; set; }
    public int slot7_level {get; set; }
    public ulong slot7_reg_date {get; set; }

	public int	main_slot_index = -1;
	public string	nickname = "";
	public string	profile_url = "";
	public uint	score = 0;
	public uint	heart_blocked = 0;
	public uint	invite_blocked = 0;
	public uint	profile_opened = 0;
	public uint	company = 0;
	public uint	sale_code = 0;
	public uint	u8intro_state = 0;
	public uint	wp_last_week = 0;
	public uint	wp_cur_week = 0;
	public ulong	wp_reg_date = 0;
	public uint	array_tutorial_1 = 0;
    public uint	array_tutorial_2 = 0;
    public uint	array_tutorial_3 = 0;
    public uint	array_tutorial_4 = 0;
	[BsonId]
	public string uuid = "";
	public uint	battle_aftereffect_time = 0;
	public string	reward = "";
	public uint	shard_Item_db_type = 0;
	public ulong	wp_last_reg_date = 0;
	public ulong	reserve1 = 0;
	public ulong	reserve2 = 0;
	public ulong	reserve3 = 0;
	public ulong	reserve4 = 0;
	public ulong	reserve5 = 0;
	public ulong	worldboss_hit = 0;
	public ulong	worldboss_point = 0;
    }
}