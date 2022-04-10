using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace iFriends{
public class iSocialUserSeqInfo {
	public ulong	socialid = 0;
	public uint	userseq = 0;
	public ushort	is_delete = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(socialid), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(is_delete), 0, sizeof(ushort));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			socialid = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			userseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_delete = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iSocialUserSeqInfo_Serializer {
	public static bool Store(MemoryStream _buf_, iSocialUserSeqInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref iSocialUserSeqInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iSocialUserSeqInfo obj) { return obj.Size(); }
};
public class iGameUserSeqInfo {
	public ulong	socialid = 0;
	public uint	userseq = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(socialid), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			socialid = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			userseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iGameUserSeqInfo_Serializer {
	public static bool Store(MemoryStream _buf_, iGameUserSeqInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref iGameUserSeqInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iGameUserSeqInfo obj) { return obj.Size(); }
};
public class iSocialFriendInfo {
	public uint	userseq = 0;
	public ushort	no_play_period = 0;
	public ushort	is_connect_requested = 0;
	public ushort	is_heart_sent = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(no_play_period), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_connect_requested), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_heart_sent), 0, sizeof(ushort));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			no_play_period = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_connect_requested = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_heart_sent = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iSocialFriendInfo_Serializer {
	public static bool Store(MemoryStream _buf_, iSocialFriendInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref iSocialFriendInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iSocialFriendInfo obj) { return obj.Size(); }
};
public class iGameFriendInfo {
	public uint	userseq = 0;
	public string	nickname = "";
	public string	profile_url = "";
	public ushort	no_play_period = 0;
	public ushort	is_connect_requested = 0;
	public ushort	is_heart_sent = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(int); 
			if(null != nickname) { nSize += nickname.Length; }
			nSize += sizeof(int); 
			if(null != profile_url) { nSize += profile_url.Length; }
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
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
			_buf_.Write(BitConverter.GetBytes(no_play_period), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_connect_requested), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_heart_sent), 0, sizeof(ushort));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			no_play_period = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_connect_requested = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_heart_sent = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iGameFriendInfo_Serializer {
	public static bool Store(MemoryStream _buf_, iGameFriendInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref iGameFriendInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iGameFriendInfo obj) { return obj.Size(); }
};
public class iRealTimeFriendInfo {
	public uint	userseq = 0;
	public uint	score = 0;
	public ushort	is_connected = 0;
	public ushort	buff_state = 0;
	public ushort	heart_blocked = 0;
	public ushort	invite_blocked = 0;
	public ushort	profile_opend = 0;
	public ushort	gender = 0;
	public ushort	gender_open = 0;
	public string	birthday = "";
	public ushort	birth_open = 0;
	public ushort	server_id = 0;
	public ushort	channel_id = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(int); 
			if(null != birthday) { nSize += birthday.Length; }
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(score), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(is_connected), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(buff_state), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(heart_blocked), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(invite_blocked), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(profile_opend), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(gender), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(gender_open), 0, sizeof(ushort));
			if(null != birthday) {
				_buf_.Write(BitConverter.GetBytes(birthday.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(birthday), 0, birthday.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(birth_open), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(server_id), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(channel_id), 0, sizeof(ushort));
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
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			score = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_connected = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			buff_state = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			heart_blocked = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			invite_blocked = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			profile_opend = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			gender = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			gender_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int birthday_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(birthday_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] birthday_buf = new byte[birthday_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, birthday_buf, 0, birthday_length);
			birthday = System.Text.Encoding.Default.GetString(birthday_buf);
			_buf_.Position += birthday.Length;
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			birth_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			server_id = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			channel_id = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iRealTimeFriendInfo_Serializer {
	public static bool Store(MemoryStream _buf_, iRealTimeFriendInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref iRealTimeFriendInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iRealTimeFriendInfo obj) { return obj.Size(); }
};
public class iNewsInfo {
	public ulong	news_seq = 0;
	public uint	user_seq = 0;
	public ushort	news_type = 0;
	public uint	heart_count = 0;
	public string	nickname = "";
	public string	profile_url = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(uint);
			nSize += sizeof(int); 
			if(null != nickname) { nSize += nickname.Length; }
			nSize += sizeof(int); 
			if(null != profile_url) { nSize += profile_url.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(news_seq), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(user_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(news_type), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			news_seq = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			user_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			news_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
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
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iNewsInfo_Serializer {
	public static bool Store(MemoryStream _buf_, iNewsInfo obj) { return obj.Store(_buf_); }
	public static bool Load(ref iNewsInfo obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iNewsInfo obj) { return obj.Size(); }
};
public class iPlayable {
	public uint	gid = 0;
	public ushort	class_type = 0;
	public ushort	is_playable = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(class_type), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_playable), 0, sizeof(ushort));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			class_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_playable = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iPlayable_Serializer {
	public static bool Store(MemoryStream _buf_, iPlayable obj) { return obj.Store(_buf_); }
	public static bool Load(ref iPlayable obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iPlayable obj) { return obj.Size(); }
};
public class iMessage {
	public ushort	type = 0;
	public string	msg = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(ushort);
			nSize += sizeof(int); 
			if(null != msg) { nSize += msg.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(type), 0, sizeof(ushort));
			if(null != msg) {
				_buf_.Write(BitConverter.GetBytes(msg.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(msg), 0, msg.Length);
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int msg_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(msg_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] msg_buf = new byte[msg_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, msg_buf, 0, msg_length);
			msg = System.Text.Encoding.Default.GetString(msg_buf);
			_buf_.Position += msg.Length;
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iMessage_Serializer {
	public static bool Store(MemoryStream _buf_, iMessage obj) { return obj.Store(_buf_); }
	public static bool Load(ref iMessage obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iMessage obj) { return obj.Size(); }
};
public class iScore {
	public uint	gid = 0;
	public uint	score = 0;
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
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(score), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			score = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct iScore_Serializer {
	public static bool Store(MemoryStream _buf_, iScore obj) { return obj.Store(_buf_); }
	public static bool Load(ref iScore obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(iScore obj) { return obj.Size(); }
};
public class FriendsOpenAck {
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
public struct FriendsOpenAck_Serializer {
	public static bool Store(MemoryStream _buf_, FriendsOpenAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FriendsOpenAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FriendsOpenAck obj) { return obj.Size(); }
};
public class FriendsCloseAck {
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
public struct FriendsCloseAck_Serializer {
	public static bool Store(MemoryStream _buf_, FriendsCloseAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FriendsCloseAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FriendsCloseAck obj) { return obj.Size(); }
};
public class SocialFriendsSyn {
	public const int MSG_ID = 5001;
	public uint	seq = 0;
	public List<uint >	userseq = new List<uint >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(int);
			foreach(var userseq_itr in userseq) { 
				uint userseq_elmt = userseq_itr;
				nSize += sizeof(uint);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(userseq.Count), 0, sizeof(int));
			foreach(var userseq_itr in userseq) { 
				uint userseq_elmt = userseq_itr;
				_buf_.Write(BitConverter.GetBytes(userseq_elmt), 0, sizeof(uint));
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
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int userseq_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int userseq_itr=0; userseq_itr<userseq_length; userseq_itr++) {
				uint userseq_val = 0;
				if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
				userseq_val = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
				_buf_.Position += sizeof(uint);
				userseq.Add(userseq_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SocialFriendsSyn_Serializer {
	public static bool Store(MemoryStream _buf_, SocialFriendsSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref SocialFriendsSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SocialFriendsSyn obj) { return obj.Size(); }
};
public class SocialFriendsAck {
	public const int MSG_ID = 5002;
	public uint	seq = 0;
	public short	result = 0;
	public List<iSocialFriendInfo >	array_Friends = new List<iSocialFriendInfo >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(int);
			foreach(var array_Friends_itr in array_Friends) { 
				iSocialFriendInfo array_Friends_elmt = array_Friends_itr;
				nSize += iSocialFriendInfo_Serializer.Size(array_Friends_elmt);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(array_Friends.Count), 0, sizeof(int));
			foreach(var array_Friends_itr in array_Friends) { 
				iSocialFriendInfo array_Friends_elmt = array_Friends_itr;
				if(false == iSocialFriendInfo_Serializer.Store(_buf_, array_Friends_elmt)) { return false; }
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int array_Friends_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int array_Friends_itr=0; array_Friends_itr<array_Friends_length; array_Friends_itr++) {
				iSocialFriendInfo array_Friends_val = new iSocialFriendInfo();
				if(false == iSocialFriendInfo_Serializer.Load(ref array_Friends_val, _buf_)) { return false; }
				array_Friends.Add(array_Friends_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SocialFriendsAck_Serializer {
	public static bool Store(MemoryStream _buf_, SocialFriendsAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref SocialFriendsAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SocialFriendsAck obj) { return obj.Size(); }
};
public class GameFriendsSyn {
	public const int MSG_ID = 5003;
	public uint	seq = 0;
	public List<uint >	userseq = new List<uint >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(int);
			foreach(var userseq_itr in userseq) { 
				uint userseq_elmt = userseq_itr;
				nSize += sizeof(uint);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(userseq.Count), 0, sizeof(int));
			foreach(var userseq_itr in userseq) { 
				uint userseq_elmt = userseq_itr;
				_buf_.Write(BitConverter.GetBytes(userseq_elmt), 0, sizeof(uint));
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
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int userseq_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int userseq_itr=0; userseq_itr<userseq_length; userseq_itr++) {
				uint userseq_val = 0;
				if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
				userseq_val = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
				_buf_.Position += sizeof(uint);
				userseq.Add(userseq_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GameFriendsSyn_Serializer {
	public static bool Store(MemoryStream _buf_, GameFriendsSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref GameFriendsSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GameFriendsSyn obj) { return obj.Size(); }
};
public class GameFriendsAck {
	public const int MSG_ID = 5004;
	public uint	seq = 0;
	public short	result = 0;
	public List<iGameFriendInfo >	array_Friends = new List<iGameFriendInfo >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(int);
			foreach(var array_Friends_itr in array_Friends) { 
				iGameFriendInfo array_Friends_elmt = array_Friends_itr;
				nSize += iGameFriendInfo_Serializer.Size(array_Friends_elmt);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(array_Friends.Count), 0, sizeof(int));
			foreach(var array_Friends_itr in array_Friends) { 
				iGameFriendInfo array_Friends_elmt = array_Friends_itr;
				if(false == iGameFriendInfo_Serializer.Store(_buf_, array_Friends_elmt)) { return false; }
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int array_Friends_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int array_Friends_itr=0; array_Friends_itr<array_Friends_length; array_Friends_itr++) {
				iGameFriendInfo array_Friends_val = new iGameFriendInfo();
				if(false == iGameFriendInfo_Serializer.Load(ref array_Friends_val, _buf_)) { return false; }
				array_Friends.Add(array_Friends_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GameFriendsAck_Serializer {
	public static bool Store(MemoryStream _buf_, GameFriendsAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref GameFriendsAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GameFriendsAck obj) { return obj.Size(); }
};
public class InviteNoAppSyn {
	public const int MSG_ID = 5007;
	public uint	seq = 0;
	public string	user_id = "";
	public uint	heart_count_max = 0;
	public ushort	send_heart_count = 0;
	public ushort	recv_heart_count = 0;
	public ushort	msg_type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(int); 
			if(null != user_id) { nSize += user_id.Length; }
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			if(null != user_id) {
				_buf_.Write(BitConverter.GetBytes(user_id.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(user_id), 0, user_id.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(send_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(recv_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(msg_type), 0, sizeof(ushort));
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
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int user_id_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(user_id_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] user_id_buf = new byte[user_id_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, user_id_buf, 0, user_id_length);
			user_id = System.Text.Encoding.Default.GetString(user_id_buf);
			_buf_.Position += user_id.Length;
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			send_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			recv_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			msg_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct InviteNoAppSyn_Serializer {
	public static bool Store(MemoryStream _buf_, InviteNoAppSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref InviteNoAppSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(InviteNoAppSyn obj) { return obj.Size(); }
};
public class InviteNoAppAck {
	public const int MSG_ID = 5008;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public ushort	invite_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(invite_count), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			invite_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct InviteNoAppAck_Serializer {
	public static bool Store(MemoryStream _buf_, InviteNoAppAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref InviteNoAppAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(InviteNoAppAck obj) { return obj.Size(); }
};
public class NewsInfoSyn {
	public const int MSG_ID = 5009;
	public uint	seq = 0;
	public ushort	page_num = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(page_num), 0, sizeof(ushort));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			page_num = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct NewsInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, NewsInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref NewsInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(NewsInfoSyn obj) { return obj.Size(); }
};
public class NewsInfoAck {
	public const int MSG_ID = 5010;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	isLastPage = 0;
	public List<iNewsInfo >	array_News = new List<iNewsInfo >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
			nSize += sizeof(int);
			foreach(var array_News_itr in array_News) { 
				iNewsInfo array_News_elmt = array_News_itr;
				nSize += iNewsInfo_Serializer.Size(array_News_elmt);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(isLastPage), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(array_News.Count), 0, sizeof(int));
			foreach(var array_News_itr in array_News) { 
				iNewsInfo array_News_elmt = array_News_itr;
				if(false == iNewsInfo_Serializer.Store(_buf_, array_News_elmt)) { return false; }
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			isLastPage = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int array_News_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int array_News_itr=0; array_News_itr<array_News_length; array_News_itr++) {
				iNewsInfo array_News_val = new iNewsInfo();
				if(false == iNewsInfo_Serializer.Load(ref array_News_val, _buf_)) { return false; }
				array_News.Add(array_News_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct NewsInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, NewsInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref NewsInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(NewsInfoAck obj) { return obj.Size(); }
};
public class SimpleFriendsSyn {
	public const int MSG_ID = 5011;
	public uint	seq = 0;
	public List<uint >	user_seq = new List<uint >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(int);
			foreach(var user_seq_itr in user_seq) { 
				uint user_seq_elmt = user_seq_itr;
				nSize += sizeof(uint);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(user_seq.Count), 0, sizeof(int));
			foreach(var user_seq_itr in user_seq) { 
				uint user_seq_elmt = user_seq_itr;
				_buf_.Write(BitConverter.GetBytes(user_seq_elmt), 0, sizeof(uint));
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
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int user_seq_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int user_seq_itr=0; user_seq_itr<user_seq_length; user_seq_itr++) {
				uint user_seq_val = 0;
				if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
				user_seq_val = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
				_buf_.Position += sizeof(uint);
				user_seq.Add(user_seq_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SimpleFriendsSyn_Serializer {
	public static bool Store(MemoryStream _buf_, SimpleFriendsSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref SimpleFriendsSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SimpleFriendsSyn obj) { return obj.Size(); }
};
public class SimpleFriendsAck {
	public const int MSG_ID = 5012;
	public uint	seq = 0;
	public short	result = 0;
	public List<iRealTimeFriendInfo >	array_Friends = new List<iRealTimeFriendInfo >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(int);
			foreach(var array_Friends_itr in array_Friends) { 
				iRealTimeFriendInfo array_Friends_elmt = array_Friends_itr;
				nSize += iRealTimeFriendInfo_Serializer.Size(array_Friends_elmt);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(array_Friends.Count), 0, sizeof(int));
			foreach(var array_Friends_itr in array_Friends) { 
				iRealTimeFriendInfo array_Friends_elmt = array_Friends_itr;
				if(false == iRealTimeFriendInfo_Serializer.Store(_buf_, array_Friends_elmt)) { return false; }
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int array_Friends_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int array_Friends_itr=0; array_Friends_itr<array_Friends_length; array_Friends_itr++) {
				iRealTimeFriendInfo array_Friends_val = new iRealTimeFriendInfo();
				if(false == iRealTimeFriendInfo_Serializer.Load(ref array_Friends_val, _buf_)) { return false; }
				array_Friends.Add(array_Friends_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SimpleFriendsAck_Serializer {
	public static bool Store(MemoryStream _buf_, SimpleFriendsAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref SimpleFriendsAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SimpleFriendsAck obj) { return obj.Size(); }
};
public class MainListSyn {
	public const int MSG_ID = 5015;
	public uint	seq = 0;
	public uint	last_week_reg_time = 0;
	public uint	last_week_score = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
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
			_buf_.Write(BitConverter.GetBytes(last_week_reg_time), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(last_week_score), 0, sizeof(uint));
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
			last_week_reg_time = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			last_week_score = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct MainListSyn_Serializer {
	public static bool Store(MemoryStream _buf_, MainListSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref MainListSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(MainListSyn obj) { return obj.Size(); }
};
public class MainListAck {
	public const int MSG_ID = 5016;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	heart_count = 0;
	public int	my_ranking = 0;
	public uint	last_week_friend_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
			nSize += sizeof(int);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(my_ranking), 0, sizeof(int));
			_buf_.Write(BitConverter.GetBytes(last_week_friend_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			my_ranking = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			last_week_friend_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct MainListAck_Serializer {
	public static bool Store(MemoryStream _buf_, MainListAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref MainListAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(MainListAck obj) { return obj.Size(); }
};
public class UpdateProfileSyn {
	public const int MSG_ID = 5019;
	public uint	seq = 0;
	public ushort	gender = 0;
	public ushort	is_gender_open = 0;
	public string	birthday = "";
	public ushort	is_birthday_open = 0;
	public ushort	is_profile_open = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(int); 
			if(null != birthday) { nSize += birthday.Length; }
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(gender), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_gender_open), 0, sizeof(ushort));
			if(null != birthday) {
				_buf_.Write(BitConverter.GetBytes(birthday.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(birthday), 0, birthday.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(is_birthday_open), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_profile_open), 0, sizeof(ushort));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			gender = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_gender_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int birthday_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(birthday_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] birthday_buf = new byte[birthday_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, birthday_buf, 0, birthday_length);
			birthday = System.Text.Encoding.Default.GetString(birthday_buf);
			_buf_.Position += birthday.Length;
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_birthday_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_profile_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UpdateProfileSyn_Serializer {
	public static bool Store(MemoryStream _buf_, UpdateProfileSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref UpdateProfileSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UpdateProfileSyn obj) { return obj.Size(); }
};
public class UpdateProfileAck {
	public const int MSG_ID = 5020;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	gender = 0;
	public ushort	is_gender_open = 0;
	public string	birthday = "";
	public ushort	is_birthday_open = 0;
	public ushort	is_profile_open = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(int); 
			if(null != birthday) { nSize += birthday.Length; }
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(gender), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_gender_open), 0, sizeof(ushort));
			if(null != birthday) {
				_buf_.Write(BitConverter.GetBytes(birthday.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(birthday), 0, birthday.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(is_birthday_open), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_profile_open), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			gender = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_gender_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int birthday_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(birthday_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] birthday_buf = new byte[birthday_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, birthday_buf, 0, birthday_length);
			birthday = System.Text.Encoding.Default.GetString(birthday_buf);
			_buf_.Position += birthday.Length;
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_birthday_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_profile_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UpdateProfileAck_Serializer {
	public static bool Store(MemoryStream _buf_, UpdateProfileAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref UpdateProfileAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UpdateProfileAck obj) { return obj.Size(); }
};
public class UpdateStatusSyn {
	public const int MSG_ID = 5025;
	public uint	seq = 0;
	public ushort	is_heart_block = 0;
	public ushort	is_invite_block = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(is_heart_block), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_invite_block), 0, sizeof(ushort));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_heart_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_invite_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UpdateStatusSyn_Serializer {
	public static bool Store(MemoryStream _buf_, UpdateStatusSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref UpdateStatusSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UpdateStatusSyn obj) { return obj.Size(); }
};
public class UpdateStatusAck {
	public const int MSG_ID = 5026;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	is_heart_block = 0;
	public ushort	is_invite_block = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(is_heart_block), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(is_invite_block), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_heart_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_invite_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UpdateStatusAck_Serializer {
	public static bool Store(MemoryStream _buf_, UpdateStatusAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref UpdateStatusAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UpdateStatusAck obj) { return obj.Size(); }
};
public class SendHeartSyn {
	public const int MSG_ID = 5027;
	public uint	seq = 0;
	public uint	gid = 0;
	public uint	heart_count = 0;
	public ushort	is_push = 0;
	public uint	heart_count_max = 0;
	public ushort	send_heart_count = 0;
	public ushort	recv_heart_count = 0;
	public ushort	msg_type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(is_push), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(send_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(recv_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(msg_type), 0, sizeof(ushort));
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
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_push = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			send_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			recv_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			msg_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SendHeartSyn_Serializer {
	public static bool Store(MemoryStream _buf_, SendHeartSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref SendHeartSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SendHeartSyn obj) { return obj.Size(); }
};
public class SendHeartAck {
	public const int MSG_ID = 5028;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SendHeartAck_Serializer {
	public static bool Store(MemoryStream _buf_, SendHeartAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref SendHeartAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SendHeartAck obj) { return obj.Size(); }
};
public class RecommendSyn {
	public const int MSG_ID = 5029;
	public uint	seq = 0;
	public uint	gid = 0;
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
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
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
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RecommendSyn_Serializer {
	public static bool Store(MemoryStream _buf_, RecommendSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref RecommendSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RecommendSyn obj) { return obj.Size(); }
};
public class RecommendAck {
	public const int MSG_ID = 5030;
	public uint	seq = 0;
	public short	result = 0;
	public uint	gid = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RecommendAck_Serializer {
	public static bool Store(MemoryStream _buf_, RecommendAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref RecommendAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RecommendAck obj) { return obj.Size(); }
};
public class BoastSyn {
	public const int MSG_ID = 5033;
	public uint	seq = 0;
	public uint	gid = 0;
	public ushort	type = 0;
	public uint	param = 0;
	public uint	subparam = 0;
	public uint	heart_count_max = 0;
	public ushort	send_heart_count = 0;
	public ushort	recv_heart_count = 0;
	public ushort	msg_type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(type), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(param), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(subparam), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(send_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(recv_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(msg_type), 0, sizeof(ushort));
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
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			param = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			subparam = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			send_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			recv_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			msg_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct BoastSyn_Serializer {
	public static bool Store(MemoryStream _buf_, BoastSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref BoastSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(BoastSyn obj) { return obj.Size(); }
};
public class BoastAck {
	public const int MSG_ID = 5034;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct BoastAck_Serializer {
	public static bool Store(MemoryStream _buf_, BoastAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref BoastAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(BoastAck obj) { return obj.Size(); }
};
public class UseBuffSyn {
	public const int MSG_ID = 5035;
	public uint	seq = 0;
	public uint	gid = 0;
	public uint	buff_time = 0;
	public uint	heart_count_max = 0;
	public ushort	send_heart_count = 0;
	public ushort	recv_heart_count = 0;
	public ushort	msg_type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(buff_time), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(send_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(recv_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(msg_type), 0, sizeof(ushort));
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
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			buff_time = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			send_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			recv_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			msg_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UseBuffSyn_Serializer {
	public static bool Store(MemoryStream _buf_, UseBuffSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref UseBuffSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UseBuffSyn obj) { return obj.Size(); }
};
public class UseBuffAck {
	public const int MSG_ID = 5036;
	public uint	seq = 0;
	public short	result = 0;
	public uint	buff_time = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
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
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(buff_time), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			buff_time = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct UseBuffAck_Serializer {
	public static bool Store(MemoryStream _buf_, UseBuffAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref UseBuffAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UseBuffAck obj) { return obj.Size(); }
};
public class GameFriendSyn {
	public const int MSG_ID = 5039;
	public uint	seq = 0;
	public uint	gid = 0;
	public uint	heart_count_max = 0;
	public ushort	send_heart_count = 0;
	public ushort	recv_heart_count = 0;
	public ushort	msg_type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(send_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(recv_heart_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(msg_type), 0, sizeof(ushort));
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
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			send_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			recv_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			msg_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GameFriendSyn_Serializer {
	public static bool Store(MemoryStream _buf_, GameFriendSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref GameFriendSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GameFriendSyn obj) { return obj.Size(); }
};
public class GameFriendAck {
	public const int MSG_ID = 5040;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GameFriendAck_Serializer {
	public static bool Store(MemoryStream _buf_, GameFriendAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref GameFriendAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GameFriendAck obj) { return obj.Size(); }
};
public class ConfirmFriendSyn {
	public const int MSG_ID = 5041;
	public uint	seq = 0;
	public ulong	news_seq = 0;
	public uint	gid = 0;
	public ushort	is_accept = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(news_seq), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(is_accept), 0, sizeof(ushort));
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
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			news_seq = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_accept = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct ConfirmFriendSyn_Serializer {
	public static bool Store(MemoryStream _buf_, ConfirmFriendSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref ConfirmFriendSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(ConfirmFriendSyn obj) { return obj.Size(); }
};
public class ConfirmFriendAck {
	public const int MSG_ID = 5042;
	public uint	seq = 0;
	public short	result = 0;
	public ulong	news_seq = 0;
	public uint	gid = 0;
	public ushort	is_accept = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ulong);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(news_seq), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(is_accept), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			news_seq = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_accept = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct ConfirmFriendAck_Serializer {
	public static bool Store(MemoryStream _buf_, ConfirmFriendAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref ConfirmFriendAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(ConfirmFriendAck obj) { return obj.Size(); }
};
public class RequestConnectSyn {
	public const int MSG_ID = 5045;
	public uint	seq = 0;
	public uint	gid = 0;
	public uint	heart_count_max = 0;
	public ushort	sleeping_user_checking_day_const = 0;
	public ushort	sleeping_user_invite_heart_point_reward = 0;
	public ushort	sleeping_user_invite_heart_point_reward_max = 0;
	public ushort	sleeping_user_be_invited_heart_point_reward = 0;
	public ushort	sleeping_user_be_invited_heart_point_reward_max = 0;
	public ushort	msg_type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(sleeping_user_checking_day_const), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(sleeping_user_invite_heart_point_reward), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(sleeping_user_invite_heart_point_reward_max), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(sleeping_user_be_invited_heart_point_reward), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(sleeping_user_be_invited_heart_point_reward_max), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(msg_type), 0, sizeof(ushort));
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
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			sleeping_user_checking_day_const = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			sleeping_user_invite_heart_point_reward = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			sleeping_user_invite_heart_point_reward_max = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			sleeping_user_be_invited_heart_point_reward = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			sleeping_user_be_invited_heart_point_reward_max = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			msg_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RequestConnectSyn_Serializer {
	public static bool Store(MemoryStream _buf_, RequestConnectSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref RequestConnectSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RequestConnectSyn obj) { return obj.Size(); }
};
public class RequestConnectAck {
	public const int MSG_ID = 5046;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RequestConnectAck_Serializer {
	public static bool Store(MemoryStream _buf_, RequestConnectAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref RequestConnectAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RequestConnectAck obj) { return obj.Size(); }
};
public class ConfirmNewsSyn {
	public const int MSG_ID = 5047;
	public uint	seq = 0;
	public ushort	type = 0;
	public ulong	news_seq = 0;
	public uint	gid = 0;
	public uint	heart_count_max = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ulong);
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
			_buf_.Write(BitConverter.GetBytes(type), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(news_seq), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			news_seq = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct ConfirmNewsSyn_Serializer {
	public static bool Store(MemoryStream _buf_, ConfirmNewsSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref ConfirmNewsSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(ConfirmNewsSyn obj) { return obj.Size(); }
};
public class ConfirmNewsAck {
	public const int MSG_ID = 5048;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public ulong	news_seq = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(news_seq), 0, sizeof(ulong));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			news_seq = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct ConfirmNewsAck_Serializer {
	public static bool Store(MemoryStream _buf_, ConfirmNewsAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref ConfirmNewsAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(ConfirmNewsAck obj) { return obj.Size(); }
};
public class DeleteFriendSyn {
	public const int MSG_ID = 5049;
	public uint	seq = 0;
	public uint	gid = 0;
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
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
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
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct DeleteFriendSyn_Serializer {
	public static bool Store(MemoryStream _buf_, DeleteFriendSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref DeleteFriendSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(DeleteFriendSyn obj) { return obj.Size(); }
};
public class DeleteFriendAck {
	public const int MSG_ID = 5050;
	public uint	seq = 0;
	public short	result = 0;
	public uint	gid = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct DeleteFriendAck_Serializer {
	public static bool Store(MemoryStream _buf_, DeleteFriendAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref DeleteFriendAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(DeleteFriendAck obj) { return obj.Size(); }
};
public class SocialUserSeqSyn {
	public const int MSG_ID = 5051;
	public uint	seq = 0;
	public List<ulong >	array_social_id = new List<ulong >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(int);
			foreach(var array_social_id_itr in array_social_id) { 
				ulong array_social_id_elmt = array_social_id_itr;
				nSize += sizeof(ulong);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(array_social_id.Count), 0, sizeof(int));
			foreach(var array_social_id_itr in array_social_id) { 
				ulong array_social_id_elmt = array_social_id_itr;
				_buf_.Write(BitConverter.GetBytes(array_social_id_elmt), 0, sizeof(ulong));
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
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int array_social_id_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int array_social_id_itr=0; array_social_id_itr<array_social_id_length; array_social_id_itr++) {
				ulong array_social_id_val = 0;
				if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
				array_social_id_val = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
				_buf_.Position += sizeof(ulong);
				array_social_id.Add(array_social_id_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SocialUserSeqSyn_Serializer {
	public static bool Store(MemoryStream _buf_, SocialUserSeqSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref SocialUserSeqSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SocialUserSeqSyn obj) { return obj.Size(); }
};
public class SocialUserSeqAck {
	public const int MSG_ID = 5052;
	public uint	seq = 0;
	public ushort	result = 0;
	public List<iSocialUserSeqInfo >	array_social_userseq_info = new List<iSocialUserSeqInfo >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(int);
			foreach(var array_social_userseq_info_itr in array_social_userseq_info) { 
				iSocialUserSeqInfo array_social_userseq_info_elmt = array_social_userseq_info_itr;
				nSize += iSocialUserSeqInfo_Serializer.Size(array_social_userseq_info_elmt);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(array_social_userseq_info.Count), 0, sizeof(int));
			foreach(var array_social_userseq_info_itr in array_social_userseq_info) { 
				iSocialUserSeqInfo array_social_userseq_info_elmt = array_social_userseq_info_itr;
				if(false == iSocialUserSeqInfo_Serializer.Store(_buf_, array_social_userseq_info_elmt)) { return false; }
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int array_social_userseq_info_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int array_social_userseq_info_itr=0; array_social_userseq_info_itr<array_social_userseq_info_length; array_social_userseq_info_itr++) {
				iSocialUserSeqInfo array_social_userseq_info_val = new iSocialUserSeqInfo();
				if(false == iSocialUserSeqInfo_Serializer.Load(ref array_social_userseq_info_val, _buf_)) { return false; }
				array_social_userseq_info.Add(array_social_userseq_info_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SocialUserSeqAck_Serializer {
	public static bool Store(MemoryStream _buf_, SocialUserSeqAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref SocialUserSeqAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SocialUserSeqAck obj) { return obj.Size(); }
};
public class GameUserSeqSyn {
	public const int MSG_ID = 5053;
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
public struct GameUserSeqSyn_Serializer {
	public static bool Store(MemoryStream _buf_, GameUserSeqSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref GameUserSeqSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GameUserSeqSyn obj) { return obj.Size(); }
};
public class GameUserSeqAck {
	public const int MSG_ID = 5054;
	public uint	seq = 0;
	public ushort	result = 0;
	public List<iGameUserSeqInfo >	array_game_userseq_info = new List<iGameUserSeqInfo >();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(int);
			foreach(var array_game_userseq_info_itr in array_game_userseq_info) { 
				iGameUserSeqInfo array_game_userseq_info_elmt = array_game_userseq_info_itr;
				nSize += iGameUserSeqInfo_Serializer.Size(array_game_userseq_info_elmt);
			}
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(array_game_userseq_info.Count), 0, sizeof(int));
			foreach(var array_game_userseq_info_itr in array_game_userseq_info) { 
				iGameUserSeqInfo array_game_userseq_info_elmt = array_game_userseq_info_itr;
				if(false == iGameUserSeqInfo_Serializer.Store(_buf_, array_game_userseq_info_elmt)) { return false; }
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int array_game_userseq_info_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			for(int array_game_userseq_info_itr=0; array_game_userseq_info_itr<array_game_userseq_info_length; array_game_userseq_info_itr++) {
				iGameUserSeqInfo array_game_userseq_info_val = new iGameUserSeqInfo();
				if(false == iGameUserSeqInfo_Serializer.Load(ref array_game_userseq_info_val, _buf_)) { return false; }
				array_game_userseq_info.Add(array_game_userseq_info_val);
			}
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GameUserSeqAck_Serializer {
	public static bool Store(MemoryStream _buf_, GameUserSeqAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref GameUserSeqAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GameUserSeqAck obj) { return obj.Size(); }
};
public class SocialMyInfoSyn {
	public const int MSG_ID = 5055;
	public uint	seq = 0;
	public ulong	socialid = 0;
	public string	nickname = "";
	public string	profile_url = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(int); 
			if(null != nickname) { nSize += nickname.Length; }
			nSize += sizeof(int); 
			if(null != profile_url) { nSize += profile_url.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(socialid), 0, sizeof(ulong));
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
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			socialid = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
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
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SocialMyInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, SocialMyInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref SocialMyInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SocialMyInfoSyn obj) { return obj.Size(); }
};
public class SocialMyInfoAck {
	public const int MSG_ID = 5056;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public ushort	heart_blocked = 0;
	public ushort	profile_opened = 0;
	public ushort	invite_block = 0;
	public ushort	gender = 0;
	public ushort	gender_open = 0;
	public string	birthday = "";
	public ushort	birth_open = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(int); 
			if(null != birthday) { nSize += birthday.Length; }
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_blocked), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(profile_opened), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(invite_block), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(gender), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(gender_open), 0, sizeof(ushort));
			if(null != birthday) {
				_buf_.Write(BitConverter.GetBytes(birthday.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(birthday), 0, birthday.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(birth_open), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			heart_blocked = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			profile_opened = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			invite_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			gender = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			gender_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int birthday_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(birthday_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] birthday_buf = new byte[birthday_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, birthday_buf, 0, birthday_length);
			birthday = System.Text.Encoding.Default.GetString(birthday_buf);
			_buf_.Position += birthday.Length;
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			birth_open = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SocialMyInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, SocialMyInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref SocialMyInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SocialMyInfoAck obj) { return obj.Size(); }
};
public class FriendTypeModifySyn {
	public const int MSG_ID = 5057;
	public uint	seq = 0;
	public ulong	socialid = 0;
	public uint	gid = 0;
	public uint	type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
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
			_buf_.Write(BitConverter.GetBytes(socialid), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(gid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(type), 0, sizeof(uint));
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
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			socialid = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			gid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			type = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FriendTypeModifySyn_Serializer {
	public static bool Store(MemoryStream _buf_, FriendTypeModifySyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref FriendTypeModifySyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FriendTypeModifySyn obj) { return obj.Size(); }
};
public class FlushFRUserInfoSyn {
	public const int MSG_ID = 5058;
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
public struct FlushFRUserInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, FlushFRUserInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushFRUserInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushFRUserInfoSyn obj) { return obj.Size(); }
};
public class FlushFRUserInfoAck {
	public const int MSG_ID = 5059;
	public uint	seq = 0;
	public short	result = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FlushFRUserInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, FlushFRUserInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FlushFRUserInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FlushFRUserInfoAck obj) { return obj.Size(); }
};
public class RemoveFRUserSyn {
	public const int MSG_ID = 5062;
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
public struct RemoveFRUserSyn_Serializer {
	public static bool Store(MemoryStream _buf_, RemoveFRUserSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref RemoveFRUserSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RemoveFRUserSyn obj) { return obj.Size(); }
};
public class RemoveFRUserAck {
	public const int MSG_ID = 5063;
	public uint	seq = 0;
	public short	result = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RemoveFRUserAck_Serializer {
	public static bool Store(MemoryStream _buf_, RemoveFRUserAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref RemoveFRUserAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RemoveFRUserAck obj) { return obj.Size(); }
};
public class NewsCountSyn {
	public const int MSG_ID = 5064;
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
public struct NewsCountSyn_Serializer {
	public static bool Store(MemoryStream _buf_, NewsCountSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref NewsCountSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(NewsCountSyn obj) { return obj.Size(); }
};
public class NewsCountAck {
	public const int MSG_ID = 5065;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	news_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(news_count), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			news_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct NewsCountAck_Serializer {
	public static bool Store(MemoryStream _buf_, NewsCountAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref NewsCountAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(NewsCountAck obj) { return obj.Size(); }
};
public class AllowFriendSyn {
	public const int MSG_ID = 5066;
	public uint	seq = 0;
	public uint	userseq = 0;
	public uint	msgid = 0;
	public ulong	dummy = 0;
	public int Size() {
		int nSize = 0;
		try {
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
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(msgid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(dummy), 0, sizeof(ulong));
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
			userseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			msgid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			dummy = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct AllowFriendSyn_Serializer {
	public static bool Store(MemoryStream _buf_, AllowFriendSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref AllowFriendSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(AllowFriendSyn obj) { return obj.Size(); }
};
public class AllowFriendAck {
	public const int MSG_ID = 5067;
	public uint	seq = 0;
	public uint	userseq = 0;
	public short	result = 0;
	public ushort	is_allow = 0;
	public uint	msgid = 0;
	public ulong	dummy = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(userseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(is_allow), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(msgid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(dummy), 0, sizeof(ulong));
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
			userseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_allow = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			msgid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			dummy = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct AllowFriendAck_Serializer {
	public static bool Store(MemoryStream _buf_, AllowFriendAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref AllowFriendAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(AllowFriendAck obj) { return obj.Size(); }
};
public class InviteBlockSyn {
	public const int MSG_ID = 5068;
	public uint	seq = 0;
	public ushort	invite_block = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(invite_block), 0, sizeof(ushort));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			invite_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct InviteBlockSyn_Serializer {
	public static bool Store(MemoryStream _buf_, InviteBlockSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref InviteBlockSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(InviteBlockSyn obj) { return obj.Size(); }
};
public class InviteBlockAck {
	public const int MSG_ID = 5069;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	invite_block = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(invite_block), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			invite_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct InviteBlockAck_Serializer {
	public static bool Store(MemoryStream _buf_, InviteBlockAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref InviteBlockAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(InviteBlockAck obj) { return obj.Size(); }
};
public class FriendShipBlockSyn {
	public const int MSG_ID = 5070;
	public uint	seq = 0;
	public ushort	heart_block = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_block), 0, sizeof(ushort));
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
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			heart_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FriendShipBlockSyn_Serializer {
	public static bool Store(MemoryStream _buf_, FriendShipBlockSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref FriendShipBlockSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FriendShipBlockSyn obj) { return obj.Size(); }
};
public class FriendShipBlockAck {
	public const int MSG_ID = 5071;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	heart_block = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_block), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			heart_block = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FriendShipBlockAck_Serializer {
	public static bool Store(MemoryStream _buf_, FriendShipBlockAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FriendShipBlockAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FriendShipBlockAck obj) { return obj.Size(); }
};
public class InviteCountSyn {
	public const int MSG_ID = 5072;
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
public struct InviteCountSyn_Serializer {
	public static bool Store(MemoryStream _buf_, InviteCountSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref InviteCountSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(InviteCountSyn obj) { return obj.Size(); }
};
public class InviteCountAck {
	public const int MSG_ID = 5073;
	public uint	seq = 0;
	public short	result = 0;
	public ushort	invite_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(invite_count), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			invite_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct InviteCountAck_Serializer {
	public static bool Store(MemoryStream _buf_, InviteCountAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref InviteCountAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(InviteCountAck obj) { return obj.Size(); }
};
public class GachyaBoxSyn {
	public const int MSG_ID = 5076;
	public uint	seq = 0;
	public uint	box_open_point = 0;
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
			_buf_.Write(BitConverter.GetBytes(box_open_point), 0, sizeof(uint));
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
			box_open_point = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GachyaBoxSyn_Serializer {
	public static bool Store(MemoryStream _buf_, GachyaBoxSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref GachyaBoxSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GachyaBoxSyn obj) { return obj.Size(); }
};
public class GachyaBoxAck {
	public const int MSG_ID = 5077;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GachyaBoxAck_Serializer {
	public static bool Store(MemoryStream _buf_, GachyaBoxAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref GachyaBoxAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GachyaBoxAck obj) { return obj.Size(); }
};
public class LastWeekRankInfoSyn {
	public const int MSG_ID = 5078;
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
public struct LastWeekRankInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, LastWeekRankInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref LastWeekRankInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(LastWeekRankInfoSyn obj) { return obj.Size(); }
};
public class LastWeekRankInfoAck {
	public const int MSG_ID = 5079;
	public uint	seq = 0;
	public short	result = 0;
	public int	my_ranking = 0;
	public ushort	this_week_friend_count = 0;
	public ushort	last_week_friend_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(int);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(my_ranking), 0, sizeof(int));
			_buf_.Write(BitConverter.GetBytes(this_week_friend_count), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(last_week_friend_count), 0, sizeof(ushort));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			my_ranking = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			this_week_friend_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			last_week_friend_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct LastWeekRankInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, LastWeekRankInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref LastWeekRankInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(LastWeekRankInfoAck obj) { return obj.Size(); }
};
public class AddHeartCountSyn {
	public const int MSG_ID = 5080;
	public uint	seq = 0;
	public uint	msgid = 0;
	public uint	heart_count_max = 0;
	public ushort	get_heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(msgid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count_max), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(get_heart_count), 0, sizeof(ushort));
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
			msgid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count_max = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			get_heart_count = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct AddHeartCountSyn_Serializer {
	public static bool Store(MemoryStream _buf_, AddHeartCountSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref AddHeartCountSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(AddHeartCountSyn obj) { return obj.Size(); }
};
public class AddHeartCountAck {
	public const int MSG_ID = 5081;
	public uint	seq = 0;
	public short	result = 0;
	public uint	msgid = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
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
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(msgid), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			msgid = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct AddHeartCountAck_Serializer {
	public static bool Store(MemoryStream _buf_, AddHeartCountAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref AddHeartCountAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(AddHeartCountAck obj) { return obj.Size(); }
};
public class GetHeartCountSyn {
	public const int MSG_ID = 5082;
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
public struct GetHeartCountSyn_Serializer {
	public static bool Store(MemoryStream _buf_, GetHeartCountSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref GetHeartCountSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GetHeartCountSyn obj) { return obj.Size(); }
};
public class GetHeartCountAck {
	public const int MSG_ID = 5083;
	public uint	seq = 0;
	public short	result = 0;
	public uint	heart_count = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
			_buf_.Write(BitConverter.GetBytes(heart_count), 0, sizeof(uint));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			heart_count = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GetHeartCountAck_Serializer {
	public static bool Store(MemoryStream _buf_, GetHeartCountAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref GetHeartCountAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GetHeartCountAck obj) { return obj.Size(); }
};
public class FriendKillTimerSyn {
	public const int MSG_ID = 5086;
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
public struct FriendKillTimerSyn_Serializer {
	public static bool Store(MemoryStream _buf_, FriendKillTimerSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref FriendKillTimerSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FriendKillTimerSyn obj) { return obj.Size(); }
};
public class FriendKillTimerAck {
	public const int MSG_ID = 5087;
	public uint	seq = 0;
	public short	result = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(short);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(result), 0, sizeof(short));
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
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			result = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct FriendKillTimerAck_Serializer {
	public static bool Store(MemoryStream _buf_, FriendKillTimerAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref FriendKillTimerAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(FriendKillTimerAck obj) { return obj.Size(); }
};
}
