using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using LiteDB;

namespace Cache{
public class slot {
	public bool	open = false;
	public uint	character_seq = 0;
	public bool	makeCharacter = false;
	public uint	remainStatResetCount = 0;
	public uint	classtype = 0;
	public uint	level = 0;
	public ulong	reg_date = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(bool);
			nSize += sizeof(uint);
			nSize += sizeof(bool);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(open), 0, sizeof(bool));
			_buf_.Write(BitConverter.GetBytes(character_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(makeCharacter), 0, sizeof(bool));
			_buf_.Write(BitConverter.GetBytes(remainStatResetCount), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(classtype), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(level), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(reg_date), 0, sizeof(ulong));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(bool) > _buf_.Length - _buf_.Position) { return false; }
			open = BitConverter.ToBoolean(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(bool);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			character_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(bool) > _buf_.Length - _buf_.Position) { return false; }
			makeCharacter = BitConverter.ToBoolean(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(bool);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			remainStatResetCount = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			classtype = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			level = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reg_date = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct slot_Serializer {
	public static bool Store(MemoryStream _buf_, slot obj) { return obj.Store(_buf_); }
	public static bool Load(ref slot obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(slot obj) { return obj.Size(); }
};
public class UserInfo {
	[BsonId]
	public uint	userseq {get; set; }
	public slot[]	array_Slot = new slot[8];
	public int	main_slot_index = 0;
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
	public uint[]	array_tutorial = new uint[4];
	public string	uuid = "";
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
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			for(int array_Slot_itr=0; array_Slot_itr<8; array_Slot_itr++) {
				nSize += slot_Serializer.Size(array_Slot[array_Slot_itr]);
			}
			nSize += sizeof(int);
			nSize += sizeof(int); 
			if(null != nickname) { nSize += nickname.Length; }
			nSize += sizeof(int); 
			if(null != profile_url) { nSize += profile_url.Length; }
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(uint) * 4;
			nSize += sizeof(int); 
			if(null != uuid) { nSize += uuid.Length; }
			nSize += sizeof(uint);
			nSize += sizeof(int); 
			if(null != reward) { nSize += reward.Length; }
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
			for(int array_Slot_itr=0; array_Slot_itr<8; array_Slot_itr++) {
				if(false == slot_Serializer.Store(_buf_, array_Slot[array_Slot_itr])) { return false; }
			}
			_buf_.Write(BitConverter.GetBytes(main_slot_index), 0, sizeof(int));
			if(null != nickname) {
				_buf_.Write(BitConverter.GetBytes(nickname.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(nickname), 0, nickname.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(null != profile_url) {
				_buf_.Write(BitConverter.GetBytes(profile_url.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(profile_url), 0, profile_url.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(score), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_blocked), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(invite_blocked), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(profile_opened), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(company), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(sale_code), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(u8intro_state), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(wp_last_week), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(wp_cur_week), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(wp_reg_date), 0, sizeof(ulong));
			for(int array_tutorial_itr=0; array_tutorial_itr<4; array_tutorial_itr++) {
				_buf_.Write(BitConverter.GetBytes(array_tutorial[array_tutorial_itr]), 0, sizeof(uint));
			}
			if(null != uuid) {
				_buf_.Write(BitConverter.GetBytes(uuid.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(uuid), 0, uuid.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(battle_aftereffect_time), 0, sizeof(uint));
			if(null != reward) {
				_buf_.Write(BitConverter.GetBytes(reward.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(reward), 0, reward.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(shard_Item_db_type), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(wp_last_reg_date), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve1), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve2), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve3), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve4), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve5), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(worldboss_hit), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(worldboss_point), 0, sizeof(ulong));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			userseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			for(int array_Slot_itr=0; array_Slot_itr<8; array_Slot_itr++) {
				slot array_Slot_val = new slot();
				if(false == slot_Serializer.Load(ref array_Slot_val, _buf_)) { return false; }
				array_Slot[array_Slot_itr] = array_Slot_val;
			}
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			main_slot_index = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int nickname_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(nickname_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] nickname_buf = new byte[nickname_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, nickname_buf, 0, nickname_length);
			nickname = System.Text.Encoding.Default.GetString(nickname_buf);
			_buf_.Position += nickname.Length;
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int profile_url_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(profile_url_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] profile_url_buf = new byte[profile_url_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, profile_url_buf, 0, profile_url_length);
			profile_url = System.Text.Encoding.Default.GetString(profile_url_buf);
			_buf_.Position += profile_url.Length;
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			score = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_blocked = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			invite_blocked = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			profile_opened = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			company = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			sale_code = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			u8intro_state = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			wp_last_week = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			wp_cur_week = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			wp_reg_date = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			for(int array_tutorial_itr=0; array_tutorial_itr<4; array_tutorial_itr++) {
				uint array_tutorial_val = 0;
				if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
				array_tutorial_val = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
				_buf_.Position += sizeof(uint);
				array_tutorial[array_tutorial_itr] = array_tutorial_val;
			}
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int uuid_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(uuid_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] uuid_buf = new byte[uuid_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, uuid_buf, 0, uuid_length);
			uuid = System.Text.Encoding.Default.GetString(uuid_buf);
			_buf_.Position += uuid.Length;
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			battle_aftereffect_time = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int reward_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(reward_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] reward_buf = new byte[reward_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, reward_buf, 0, reward_length);
			reward = System.Text.Encoding.Default.GetString(reward_buf);
			_buf_.Position += reward.Length;
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			shard_Item_db_type = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			wp_last_reg_date = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve1 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve2 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve3 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve4 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve5 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			worldboss_hit = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			worldboss_point = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UserInfo_Serializer {
	public static bool Store(MemoryStream _buf_, UserInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref UserInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UserInfo obj) { return obj.Size(); }
};
public class QuickSlot {
	public uint	type = 0;
	public ulong	index = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(type), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(index), 0, sizeof(ulong));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			type = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			index = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct QuickSlot_Serializer {
	public static bool Store(MemoryStream _buf_, QuickSlot obj) { return obj.Store(_buf_); }
	public static bool Load(ref QuickSlot obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(QuickSlot obj) { return obj.Size(); }
};
public class CharacterInfo {
	[BsonId]
	public uint	characterseq {get; set; }
	[BsonId]
	public uint	userSeq {get; set; }
	public uint	classtype = 0;
	public uint	slotindex = 0;
	public uint	remain_stat_point = 0;
	public uint	remain_skill_point = 0;
	public uint	ap_current = 0;
	public uint	ep_current = 0;
	public uint	ep_max = 0;
	public ulong	weapon = 0;
	public uint	weapon_iconidx = 0;
	public ulong	helmet = 0;
	public uint	helmet_iconidx = 0;
	public ulong	armor = 0;
	public uint	armor_iconidx = 0;
	public ulong	glove = 0;
	public ulong	shoes = 0;
	public ulong	necklace = 0;
	public ulong	cloak = 0;
	public ulong	ring = 0;
	public ulong	charm = 0;
	public ulong	avartar = 0;
	public uint	avartar_iconidx = 0;
	public ulong	vehicle = 0;
	public uint	vehicle_iconidx = 0;
	public ulong	title = 0;
	public ulong	fairy = 0;
	public ulong	battlepet = 0;
	public uint	exp = 0;
	public uint	level = 0;
	public uint	str = 0;
	public uint	dex = 0;
	public uint	con = 0;
	public uint	spi = 0;
	public QuickSlot[]	array_QuickSlot = new QuickSlot[8];
	public uint[]	array_Skill = new uint[20];
	public uint	gold = 0;
	public int	event_stamina = 0;
	public ulong	recover_stamina_sec = 0;
	public uint	drill_status = 0;
	public uint	drill_time = 0;
	public ulong	drill_start = 0;
	public ulong	drill_end = 0;
	public uint	consecutive_win = 0;
	public string	win_comment = "";
	public ulong	reg_date = 0;
	public string	dungeon_clear_info = "";
	public string	bag_order_info = "";
	public string	buff_info = "";
	public string	battle_afterEffect_info = "";
	public uint	daily_ep = 0;
	public ulong	name_tag = 0;
	public uint	name_tag_iconidx = 0;
	public ulong	reserve1 = 0;
	public ulong	reserve2 = 0;
	public ulong	reserve3 = 0;
	public ulong	reserve4 = 0;
	public ulong	reserve5 = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			for(int array_QuickSlot_itr=0; array_QuickSlot_itr<8; array_QuickSlot_itr++) {
				nSize += QuickSlot_Serializer.Size(array_QuickSlot[array_QuickSlot_itr]);
			}
			nSize += sizeof(uint) * 20;
			nSize += sizeof(uint);
			nSize += sizeof(int);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(int); 
			if(null != win_comment) { nSize += win_comment.Length; }
			nSize += sizeof(ulong);
			nSize += sizeof(int); 
			if(null != dungeon_clear_info) { nSize += dungeon_clear_info.Length; }
			nSize += sizeof(int); 
			if(null != bag_order_info) { nSize += bag_order_info.Length; }
			nSize += sizeof(int); 
			if(null != buff_info) { nSize += buff_info.Length; }
			nSize += sizeof(int); 
			if(null != battle_afterEffect_info) { nSize += battle_afterEffect_info.Length; }
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
			nSize += sizeof(ulong);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(characterseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(userSeq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(classtype), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(slotindex), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(remain_stat_point), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(remain_skill_point), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(ap_current), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(ep_current), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(ep_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(weapon), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(weapon_iconidx), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(helmet), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(helmet_iconidx), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(armor), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(armor_iconidx), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(glove), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(shoes), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(necklace), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(cloak), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(ring), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(charm), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(avartar), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(avartar_iconidx), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(vehicle), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(vehicle_iconidx), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(title), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(fairy), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(battlepet), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(exp), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(level), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(str), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(dex), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(con), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(spi), 0, sizeof(uint));
			for(int array_QuickSlot_itr=0; array_QuickSlot_itr<8; array_QuickSlot_itr++) {
				if(false == QuickSlot_Serializer.Store(_buf_, array_QuickSlot[array_QuickSlot_itr])) { return false; }
			}
			for(int array_Skill_itr=0; array_Skill_itr<20; array_Skill_itr++) {
				_buf_.Write(BitConverter.GetBytes(array_Skill[array_Skill_itr]), 0, sizeof(uint));
			}
			_buf_.Write(BitConverter.GetBytes(gold), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(event_stamina), 0, sizeof(int));
			_buf_.Write(BitConverter.GetBytes(recover_stamina_sec), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(drill_status), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(drill_time), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(drill_start), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(drill_end), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(consecutive_win), 0, sizeof(uint));
			if(null != win_comment) {
				_buf_.Write(BitConverter.GetBytes(win_comment.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(win_comment), 0, win_comment.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(reg_date), 0, sizeof(ulong));
			if(null != dungeon_clear_info) {
				_buf_.Write(BitConverter.GetBytes(dungeon_clear_info.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(dungeon_clear_info), 0, dungeon_clear_info.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(null != bag_order_info) {
				_buf_.Write(BitConverter.GetBytes(bag_order_info.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(bag_order_info), 0, bag_order_info.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(null != buff_info) {
				_buf_.Write(BitConverter.GetBytes(buff_info.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(buff_info), 0, buff_info.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(null != battle_afterEffect_info) {
				_buf_.Write(BitConverter.GetBytes(battle_afterEffect_info.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(battle_afterEffect_info), 0, battle_afterEffect_info.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(daily_ep), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(name_tag), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(name_tag_iconidx), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(reserve1), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve2), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve3), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve4), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(reserve5), 0, sizeof(ulong));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			characterseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			userSeq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			classtype = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			slotindex = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			remain_stat_point = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			remain_skill_point = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			ap_current = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			ep_current = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			ep_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			weapon = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			weapon_iconidx = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			helmet = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			helmet_iconidx = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			armor = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			armor_iconidx = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			glove = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			shoes = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			necklace = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			cloak = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			ring = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			charm = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			avartar = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			avartar_iconidx = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			vehicle = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			vehicle_iconidx = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			title = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			fairy = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			battlepet = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			exp = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			level = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			str = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			dex = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			con = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			spi = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			for(int array_QuickSlot_itr=0; array_QuickSlot_itr<8; array_QuickSlot_itr++) {
				QuickSlot array_QuickSlot_val = new QuickSlot();
				if(false == QuickSlot_Serializer.Load(ref array_QuickSlot_val, _buf_)) { return false; }
				array_QuickSlot[array_QuickSlot_itr] = array_QuickSlot_val;
			}
			for(int array_Skill_itr=0; array_Skill_itr<20; array_Skill_itr++) {
				uint array_Skill_val = 0;
				if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
				array_Skill_val = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
				_buf_.Position += sizeof(uint);
				array_Skill[array_Skill_itr] = array_Skill_val;
			}
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gold = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			event_stamina = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			recover_stamina_sec = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			drill_status = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			drill_time = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			drill_start = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			drill_end = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			consecutive_win = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int win_comment_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(win_comment_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] win_comment_buf = new byte[win_comment_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, win_comment_buf, 0, win_comment_length);
			win_comment = System.Text.Encoding.Default.GetString(win_comment_buf);
			_buf_.Position += win_comment.Length;
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reg_date = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int dungeon_clear_info_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(dungeon_clear_info_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] dungeon_clear_info_buf = new byte[dungeon_clear_info_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, dungeon_clear_info_buf, 0, dungeon_clear_info_length);
			dungeon_clear_info = System.Text.Encoding.Default.GetString(dungeon_clear_info_buf);
			_buf_.Position += dungeon_clear_info.Length;
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int bag_order_info_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(bag_order_info_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] bag_order_info_buf = new byte[bag_order_info_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, bag_order_info_buf, 0, bag_order_info_length);
			bag_order_info = System.Text.Encoding.Default.GetString(bag_order_info_buf);
			_buf_.Position += bag_order_info.Length;
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int buff_info_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(buff_info_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] buff_info_buf = new byte[buff_info_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, buff_info_buf, 0, buff_info_length);
			buff_info = System.Text.Encoding.Default.GetString(buff_info_buf);
			_buf_.Position += buff_info.Length;
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int battle_afterEffect_info_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(battle_afterEffect_info_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] battle_afterEffect_info_buf = new byte[battle_afterEffect_info_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, battle_afterEffect_info_buf, 0, battle_afterEffect_info_length);
			battle_afterEffect_info = System.Text.Encoding.Default.GetString(battle_afterEffect_info_buf);
			_buf_.Position += battle_afterEffect_info.Length;
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			daily_ep = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			name_tag = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			name_tag_iconidx = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve1 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve2 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve3 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve4 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			reserve5 = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct CharacterInfo_Serializer {
	public static bool Store(MemoryStream _buf_, CharacterInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref CharacterInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(CharacterInfo obj) { return obj.Size(); }
};
public enum CacheResult {
	CACHE_SUCCESS,
	CACHE_NOT_EXIST_USER,
	CACHE_NOT_EXIST_CHARACTER,
	CACHE_DATABASE_ERROR,
}; // CacheResult
public struct CacheResult_Serializer {
	public static bool Store(System.IO.MemoryStream _buf_, CacheResult obj) { 
		try {
			_buf_.Write(System.BitConverter.GetBytes((int)obj), (int)_buf_.Position, sizeof(CacheResult));
		}
		catch(System.Exception) {
			return false;
		}
		return true;
	}
	public static bool Load(ref CacheResult obj, MemoryStream _buf_) { 
		try {
			obj = (CacheResult)System.BitConverter.ToInt32(_buf_.ToArray(), (int)_buf_.Position);
			_buf_.Position += sizeof(CacheResult);
		}
		catch(System.Exception) { 
			return false;
		}
		return true;
	}
	public static System.Int32 Size(CacheResult obj) { return sizeof(CacheResult); }
};
public class CacheOpenAck {
	public const int MSG_ID = 1;
	public int Size() {
		int nSize = 0;
		try {
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct CacheOpenAck_Serializer {
	public static bool Store(MemoryStream _buf_, CacheOpenAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref CacheOpenAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(CacheOpenAck obj) { return obj.Size(); }
};
public class CacheCloseAck {
	public const int MSG_ID = 2;
	public int Size() {
		int nSize = 0;
		try {
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct CacheCloseAck_Serializer {
	public static bool Store(MemoryStream _buf_, CacheCloseAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref CacheCloseAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(CacheCloseAck obj) { return obj.Size(); }
};
public class UserInfoSyn {
	public const int MSG_ID = 7001;
	public uint	seq = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UserInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, UserInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref UserInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UserInfoSyn obj) { return obj.Size(); }
};
public class UserInfoAck {
	public const int MSG_ID = 7002;
	public uint	seq = 0;
	public CacheResult	result = new CacheResult();
	public string	strError = "";
	public UserInfo	stUserInfo = new UserInfo();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += CacheResult_Serializer.Size(result);
			nSize += sizeof(int); 
			if(null != strError) { nSize += strError.Length; }
			nSize += UserInfo_Serializer.Size(stUserInfo);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			if(false == CacheResult_Serializer.Store(_buf_, result)) { return false; }
			if(null != strError) {
				_buf_.Write(BitConverter.GetBytes(strError.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(strError), 0, strError.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(false == UserInfo_Serializer.Store(_buf_, stUserInfo)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == CacheResult_Serializer.Load(ref result, _buf_)) { return false; }
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int strError_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(strError_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] strError_buf = new byte[strError_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, strError_buf, 0, strError_length);
			strError = System.Text.Encoding.Default.GetString(strError_buf);
			_buf_.Position += strError.Length;
			if(false == UserInfo_Serializer.Load(ref stUserInfo, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UserInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, UserInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref UserInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UserInfoAck obj) { return obj.Size(); }
};
public class CharacterInfoSyn {
	public const int MSG_ID = 7003;
	public uint	seq = 0;
	public uint	char_seq = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(char_seq), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			char_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct CharacterInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, CharacterInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref CharacterInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(CharacterInfoSyn obj) { return obj.Size(); }
};
public class CharacterInfoAck {
	public const int MSG_ID = 7004;
	public uint	seq = 0;
	public CacheResult	result = new CacheResult();
	public string	strError = "";
	public CharacterInfo	stCharacterInfo = new CharacterInfo();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += CacheResult_Serializer.Size(result);
			nSize += sizeof(int); 
			if(null != strError) { nSize += strError.Length; }
			nSize += CharacterInfo_Serializer.Size(stCharacterInfo);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			if(false == CacheResult_Serializer.Store(_buf_, result)) { return false; }
			if(null != strError) {
				_buf_.Write(BitConverter.GetBytes(strError.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(strError), 0, strError.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(false == CharacterInfo_Serializer.Store(_buf_, stCharacterInfo)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == CacheResult_Serializer.Load(ref result, _buf_)) { return false; }
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int strError_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(strError_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] strError_buf = new byte[strError_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, strError_buf, 0, strError_length);
			strError = System.Text.Encoding.Default.GetString(strError_buf);
			_buf_.Position += strError.Length;
			if(false == CharacterInfo_Serializer.Load(ref stCharacterInfo, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct CharacterInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, CharacterInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref CharacterInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(CharacterInfoAck obj) { return obj.Size(); }
};
public class FlushCharacterInfoSyn {
	public const int MSG_ID = 7005;
	public uint	seq = 0;
	public uint	char_seq = 0;
	public bool	flushDB = false;
	public CharacterInfo	stCharacterInfo = new CharacterInfo();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(bool);
			nSize += CharacterInfo_Serializer.Size(stCharacterInfo);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(char_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(flushDB), 0, sizeof(bool));
			if(false == CharacterInfo_Serializer.Store(_buf_, stCharacterInfo)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			char_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(bool) > _buf_.Length - _buf_.Position) { return false; }
			flushDB = BitConverter.ToBoolean(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(bool);
			if(false == CharacterInfo_Serializer.Load(ref stCharacterInfo, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FlushCharacterInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, FlushCharacterInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushCharacterInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushCharacterInfoSyn obj) { return obj.Size(); }
};
public class FlushCharacterInfoAck {
	public const int MSG_ID = 7006;
	public uint	seq = 0;
	public CacheResult	result = new CacheResult();
	public string	strError = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += CacheResult_Serializer.Size(result);
			nSize += sizeof(int); 
			if(null != strError) { nSize += strError.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			if(false == CacheResult_Serializer.Store(_buf_, result)) { return false; }
			if(null != strError) {
				_buf_.Write(BitConverter.GetBytes(strError.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(strError), 0, strError.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == CacheResult_Serializer.Load(ref result, _buf_)) { return false; }
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int strError_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(strError_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] strError_buf = new byte[strError_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, strError_buf, 0, strError_length);
			strError = System.Text.Encoding.Default.GetString(strError_buf);
			_buf_.Position += strError.Length;
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FlushCharacterInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, FlushCharacterInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushCharacterInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushCharacterInfoAck obj) { return obj.Size(); }
};
public class FlushUserInfoSyn {
	public const int MSG_ID = 7007;
	public uint	seq = 0;
	public bool	flushDB = false;
	public UserInfo	stUserInfo = new UserInfo();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(bool);
			nSize += UserInfo_Serializer.Size(stUserInfo);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(flushDB), 0, sizeof(bool));
			if(false == UserInfo_Serializer.Store(_buf_, stUserInfo)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(bool) > _buf_.Length - _buf_.Position) { return false; }
			flushDB = BitConverter.ToBoolean(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(bool);
			if(false == UserInfo_Serializer.Load(ref stUserInfo, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FlushUserInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, FlushUserInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushUserInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushUserInfoSyn obj) { return obj.Size(); }
};
public class FlushUserInfoAck {
	public const int MSG_ID = 7008;
	public uint	seq = 0;
	public CacheResult	result = new CacheResult();
	public string	strError = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += CacheResult_Serializer.Size(result);
			nSize += sizeof(int); 
			if(null != strError) { nSize += strError.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			if(false == CacheResult_Serializer.Store(_buf_, result)) { return false; }
			if(null != strError) {
				_buf_.Write(BitConverter.GetBytes(strError.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(strError), 0, strError.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == CacheResult_Serializer.Load(ref result, _buf_)) { return false; }
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int strError_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(strError_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] strError_buf = new byte[strError_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, strError_buf, 0, strError_length);
			strError = System.Text.Encoding.Default.GetString(strError_buf);
			_buf_.Position += strError.Length;
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FlushUserInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, FlushUserInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushUserInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushUserInfoAck obj) { return obj.Size(); }
};
public class FlushUserSlotInfoSyn {
	public const int MSG_ID = 7009;
	public uint	seq = 0;
	public uint	slotIndex = 0;
	public slot	stSlot = new slot();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += slot_Serializer.Size(stSlot);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(slotIndex), 0, sizeof(uint));
			if(false == slot_Serializer.Store(_buf_, stSlot)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			slotIndex = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == slot_Serializer.Load(ref stSlot, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FlushUserSlotInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, FlushUserSlotInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushUserSlotInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushUserSlotInfoSyn obj) { return obj.Size(); }
};
public class FlushUserSlotInfoAck {
	public const int MSG_ID = 7010;
	public uint	seq = 0;
	public uint	slotIndex = 0;
	public CacheResult	result = new CacheResult();
	public string	strError = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += CacheResult_Serializer.Size(result);
			nSize += sizeof(int); 
			if(null != strError) { nSize += strError.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(slotIndex), 0, sizeof(uint));
			if(false == CacheResult_Serializer.Store(_buf_, result)) { return false; }
			if(null != strError) {
				_buf_.Write(BitConverter.GetBytes(strError.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(strError), 0, strError.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			slotIndex = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == CacheResult_Serializer.Load(ref result, _buf_)) { return false; }
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int strError_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(strError_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] strError_buf = new byte[strError_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, strError_buf, 0, strError_length);
			strError = System.Text.Encoding.Default.GetString(strError_buf);
			_buf_.Position += strError.Length;
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FlushUserSlotInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, FlushUserSlotInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushUserSlotInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushUserSlotInfoAck obj) { return obj.Size(); }
};
public class RemoveUserSyn {
	public const int MSG_ID = 7011;
	public uint	seq = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RemoveUserSyn_Serializer {
	public static bool Store(MemoryStream _buf_, RemoveUserSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref RemoveUserSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RemoveUserSyn obj) { return obj.Size(); }
};
public class RemoveUserAck {
	public const int MSG_ID = 7012;
	public uint	seq = 0;
	public CacheResult	result = new CacheResult();
	public string	strError = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += CacheResult_Serializer.Size(result);
			nSize += sizeof(int); 
			if(null != strError) { nSize += strError.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			if(false == CacheResult_Serializer.Store(_buf_, result)) { return false; }
			if(null != strError) {
				_buf_.Write(BitConverter.GetBytes(strError.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(strError), 0, strError.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == CacheResult_Serializer.Load(ref result, _buf_)) { return false; }
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int strError_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(strError_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] strError_buf = new byte[strError_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, strError_buf, 0, strError_length);
			strError = System.Text.Encoding.Default.GetString(strError_buf);
			_buf_.Position += strError.Length;
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RemoveUserAck_Serializer {
	public static bool Store(MemoryStream _buf_, RemoveUserAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref RemoveUserAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RemoveUserAck obj) { return obj.Size(); }
};
public class NewCharacterInfoSyn {
	public const int MSG_ID = 7013;
	public uint	seq = 0;
	public uint	char_seq = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(char_seq), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			char_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct NewCharacterInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, NewCharacterInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref NewCharacterInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(NewCharacterInfoSyn obj) { return obj.Size(); }
};
public class NewCharacterInfoAck {
	public const int MSG_ID = 7014;
	public uint	seq = 0;
	public CacheResult	result = new CacheResult();
	public string	strError = "";
	public CharacterInfo	stCharacterInfo = new CharacterInfo();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += CacheResult_Serializer.Size(result);
			nSize += sizeof(int); 
			if(null != strError) { nSize += strError.Length; }
			nSize += CharacterInfo_Serializer.Size(stCharacterInfo);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			if(false == CacheResult_Serializer.Store(_buf_, result)) { return false; }
			if(null != strError) {
				_buf_.Write(BitConverter.GetBytes(strError.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(strError), 0, strError.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(false == CharacterInfo_Serializer.Store(_buf_, stCharacterInfo)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == CacheResult_Serializer.Load(ref result, _buf_)) { return false; }
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int strError_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(strError_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] strError_buf = new byte[strError_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, strError_buf, 0, strError_length);
			strError = System.Text.Encoding.Default.GetString(strError_buf);
			_buf_.Position += strError.Length;
			if(false == CharacterInfo_Serializer.Load(ref stCharacterInfo, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct NewCharacterInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, NewCharacterInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref NewCharacterInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(NewCharacterInfoAck obj) { return obj.Size(); }
};
}
