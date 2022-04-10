using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Location{
public enum LocationResult {
	LOCATION_SUCCESS,
	LOCATION_FAIL,
	LOCATION_NOT_EXIST_USER,
	LOCATION_NOT_EXIST_TARGET_USER,
}; // LocationResult
public struct LocationResult_Serializer {
	public static bool Store(System.IO.MemoryStream _buf_, LocationResult obj) { 
		try {
			_buf_.Write(System.BitConverter.GetBytes((int)obj), (int)_buf_.Position, sizeof(LocationResult));
		}
		catch(System.Exception) {
			return false;
		}
		return true;
	}
	public static bool Load(ref LocationResult obj, MemoryStream _buf_) { 
		try {
			obj = (LocationResult)System.BitConverter.ToInt32(_buf_.ToArray(), (int)_buf_.Position);
			_buf_.Position += sizeof(LocationResult);
		}
		catch(System.Exception) { 
			return false;
		}
		return true;
	}
	public static System.Int32 Size(LocationResult obj) { return sizeof(LocationResult); }
};
public class LocationOpenAck {
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
public struct LocationOpenAck_Serializer {
	public static bool Store(MemoryStream _buf_, LocationOpenAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref LocationOpenAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(LocationOpenAck obj) { return obj.Size(); }
};
public class LocationCloseAck {
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
public struct LocationCloseAck_Serializer {
	public static bool Store(MemoryStream _buf_, LocationCloseAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref LocationCloseAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(LocationCloseAck obj) { return obj.Size(); }
};
public class RegistSyn {
	public const int MSG_ID = 8001;
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
public struct RegistSyn_Serializer {
	public static bool Store(MemoryStream _buf_, RegistSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref RegistSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RegistSyn obj) { return obj.Size(); }
};
public class RegistAck {
	public const int MSG_ID = 8002;
	public uint	seq = 0;
	public LocationResult	result = new LocationResult();
	public string	strError = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += LocationResult_Serializer.Size(result);
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
			if(false == LocationResult_Serializer.Store(_buf_, result)) { return false; }
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
			if(false == LocationResult_Serializer.Load(ref result, _buf_)) { return false; }
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
public struct RegistAck_Serializer {
	public static bool Store(MemoryStream _buf_, RegistAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref RegistAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RegistAck obj) { return obj.Size(); }
};
public class UnRegistSyn {
	public const int MSG_ID = 8003;
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
public struct UnRegistSyn_Serializer {
	public static bool Store(MemoryStream _buf_, UnRegistSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref UnRegistSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UnRegistSyn obj) { return obj.Size(); }
};
public class UnRegistAck {
	public const int MSG_ID = 8004;
	public uint	seq = 0;
	public LocationResult	result = new LocationResult();
	public string	strError = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += LocationResult_Serializer.Size(result);
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
			if(false == LocationResult_Serializer.Store(_buf_, result)) { return false; }
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
			if(false == LocationResult_Serializer.Load(ref result, _buf_)) { return false; }
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
public struct UnRegistAck_Serializer {
	public static bool Store(MemoryStream _buf_, UnRegistAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref UnRegistAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(UnRegistAck obj) { return obj.Size(); }
};
public class KickUser {
	public const int MSG_ID = 8005;
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
public struct KickUser_Serializer {
	public static bool Store(MemoryStream _buf_, KickUser obj) { return obj.Store(_buf_); }
	public static bool Load(ref KickUser obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(KickUser obj) { return obj.Size(); }
};
public class ChatSyn {
	public const int MSG_ID = 8006;
	public uint	type = 0;
	public uint	sender_seq = 0;
	public uint	receiver_seq = 0;
	public string	sender_nick = "";
	public string	msgs = "";
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(int); 
			if(null != sender_nick) { nSize += sender_nick.Length; }
			nSize += sizeof(int); 
			if(null != msgs) { nSize += msgs.Length; }
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(type), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(sender_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(receiver_seq), 0, sizeof(uint));
			if(null != sender_nick) {
				_buf_.Write(BitConverter.GetBytes(sender_nick.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(sender_nick), 0, sender_nick.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			if(null != msgs) {
				_buf_.Write(BitConverter.GetBytes(msgs.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(msgs), 0, msgs.Length);
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
			type = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			sender_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			receiver_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int sender_nick_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(sender_nick_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] sender_nick_buf = new byte[sender_nick_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, sender_nick_buf, 0, sender_nick_length);
			sender_nick = System.Text.Encoding.Default.GetString(sender_nick_buf);
			_buf_.Position += sender_nick.Length;
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int msgs_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(msgs_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] msgs_buf = new byte[msgs_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, msgs_buf, 0, msgs_length);
			msgs = System.Text.Encoding.Default.GetString(msgs_buf);
			_buf_.Position += msgs.Length;
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct ChatSyn_Serializer {
	public static bool Store(MemoryStream _buf_, ChatSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref ChatSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(ChatSyn obj) { return obj.Size(); }
};
public class ChatAck {
	public const int MSG_ID = 8007;
	public uint	type = 0;
	public uint	sender_seq = 0;
	public uint	receiver_seq = 0;
	public LocationResult	result = new LocationResult();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += LocationResult_Serializer.Size(result);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(type), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(sender_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(receiver_seq), 0, sizeof(uint));
			if(false == LocationResult_Serializer.Store(_buf_, result)) { return false; }
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
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			sender_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			receiver_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(false == LocationResult_Serializer.Load(ref result, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct ChatAck_Serializer {
	public static bool Store(MemoryStream _buf_, ChatAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref ChatAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(ChatAck obj) { return obj.Size(); }
};
public class RecallSyn {
	public const int MSG_ID = 8008;
	public uint	sender_seq = 0;
	public uint	receiver_seq = 0;
	public string	ip = "";
	public uint	port = 0;
	public uint	server_id = 0;
	public uint	channel_id = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(int); 
			if(null != ip) { nSize += ip.Length; }
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
			_buf_.Write(BitConverter.GetBytes(sender_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(receiver_seq), 0, sizeof(uint));
			if(null != ip) {
				_buf_.Write(BitConverter.GetBytes(ip.Length), 0, sizeof(int));
				_buf_.Write(Encoding.Default.GetBytes(ip), 0, ip.Length);
			}
			else {
				_buf_.Write(BitConverter.GetBytes(0), 0, sizeof(int));
			}
			_buf_.Write(BitConverter.GetBytes(port), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(server_id), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(channel_id), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			sender_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			receiver_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			int ip_length = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(ip_length > _buf_.Length - _buf_.Position) { return false; }
			byte[] ip_buf = new byte[ip_length];
			Array.Copy(_buf_.GetBuffer(), (int)_buf_.Position, ip_buf, 0, ip_length);
			ip = System.Text.Encoding.Default.GetString(ip_buf);
			_buf_.Position += ip.Length;
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			port = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			server_id = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			channel_id = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RecallSyn_Serializer {
	public static bool Store(MemoryStream _buf_, RecallSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref RecallSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RecallSyn obj) { return obj.Size(); }
};
public class RecallAck {
	public const int MSG_ID = 8009;
	public uint	sender_seq = 0;
	public uint	receiver_seq = 0;
	public ushort	is_accept = 0;
	public LocationResult	result = new LocationResult();
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += LocationResult_Serializer.Size(result);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(sender_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(receiver_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(is_accept), 0, sizeof(ushort));
			if(false == LocationResult_Serializer.Store(_buf_, result)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			sender_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			receiver_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			is_accept = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(false == LocationResult_Serializer.Load(ref result, _buf_)) { return false; }
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct RecallAck_Serializer {
	public static bool Store(MemoryStream _buf_, RecallAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref RecallAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(RecallAck obj) { return obj.Size(); }
};
public class TradeItemSoldoutSyn {
	public const int MSG_ID = 8010;
	public uint	buyer_characterseq = 0;
	public uint	seller_userseq = 0;
	public ulong	item_trade_seq = 0;
	public int	item_class_type = 0;
	public uint	item_sheet_type = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(uint);
			nSize += sizeof(ulong);
			nSize += sizeof(int);
			nSize += sizeof(uint);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(buyer_characterseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(seller_userseq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(item_trade_seq), 0, sizeof(ulong));
			_buf_.Write(BitConverter.GetBytes(item_class_type), 0, sizeof(int));
			_buf_.Write(BitConverter.GetBytes(item_sheet_type), 0, sizeof(uint));
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
	public bool Load(MemoryStream _buf_) {
		_buf_.Position = 0;
		try {
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			buyer_characterseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			seller_userseq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ulong) > _buf_.Length - _buf_.Position) { return false; }
			item_trade_seq = BitConverter.ToUInt64(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ulong);
			if(sizeof(int) > _buf_.Length - _buf_.Position) { return false; }
			item_class_type = BitConverter.ToInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(int);
			if(sizeof(uint) > _buf_.Length - _buf_.Position) { return false; }
			item_sheet_type = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct TradeItemSoldoutSyn_Serializer {
	public static bool Store(MemoryStream _buf_, TradeItemSoldoutSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref TradeItemSoldoutSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(TradeItemSoldoutSyn obj) { return obj.Size(); }
};
public class SetMainCharacterInfoSyn {
	public const int MSG_ID = 8011;
	public uint	seq = 0;
	public ushort	level = 0;
	public ushort	class_type = 0;
	public ushort	head = 0;
	public ushort	armor = 0;
	public ushort	weapon = 0;
	public ushort	side_hand = 0;
	public ushort	effect = 0;
	public short	pet_tid = 0;
	public int Size() {
		int nSize = 0;
		try {
			nSize += sizeof(uint);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
			nSize += sizeof(short);
		} catch(System.Exception) {
			return -1;
		}
		return nSize;
	}
	public bool Store(MemoryStream _buf_) {
		try {
			_buf_.Write(BitConverter.GetBytes(seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(level), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(class_type), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(head), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(armor), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(weapon), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(side_hand), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(effect), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(pet_tid), 0, sizeof(short));
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
			level = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			class_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			head = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			armor = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			weapon = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			side_hand = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			effect = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			pet_tid = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct SetMainCharacterInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, SetMainCharacterInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref SetMainCharacterInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SetMainCharacterInfoSyn obj) { return obj.Size(); }
};
public class SetMainCharacterInfoAck {
	public const int MSG_ID = 8012;
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
public struct SetMainCharacterInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, SetMainCharacterInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref SetMainCharacterInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(SetMainCharacterInfoAck obj) { return obj.Size(); }
};
public class GetMainCharacterInfoSyn {
	public const int MSG_ID = 8013;
	public uint	seq = 0;
	public uint	target_seq = 0;
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
			_buf_.Write(BitConverter.GetBytes(target_seq), 0, sizeof(uint));
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
			target_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GetMainCharacterInfoSyn_Serializer {
	public static bool Store(MemoryStream _buf_, GetMainCharacterInfoSyn obj) { return obj.Store(_buf_); }
	public static bool Load(ref GetMainCharacterInfoSyn obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GetMainCharacterInfoSyn obj) { return obj.Size(); }
};
public class GetMainCharacterInfoAck {
	public const int MSG_ID = 8014;
	public uint	seq = 0;
	public short	result = 0;
	public uint	target_seq = 0;
	public ushort	level = 0;
	public ushort	class_type = 0;
	public ushort	head = 0;
	public ushort	armor = 0;
	public ushort	weapon = 0;
	public ushort	side_hand = 0;
	public ushort	effect = 0;
	public short	pet_tid = 0;
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
			nSize += sizeof(ushort);
			nSize += sizeof(ushort);
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
			_buf_.Write(BitConverter.GetBytes(target_seq), 0, sizeof(uint));
			_buf_.Write(BitConverter.GetBytes(level), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(class_type), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(head), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(armor), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(weapon), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(side_hand), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(effect), 0, sizeof(ushort));
			_buf_.Write(BitConverter.GetBytes(pet_tid), 0, sizeof(short));
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
			target_seq = BitConverter.ToUInt32(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(uint);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			level = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			class_type = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			head = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			armor = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			weapon = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			side_hand = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(ushort) > _buf_.Length - _buf_.Position) { return false; }
			effect = BitConverter.ToUInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(ushort);
			if(sizeof(short) > _buf_.Length - _buf_.Position) { return false; }
			pet_tid = BitConverter.ToInt16(_buf_.GetBuffer(), (int)_buf_.Position);
			_buf_.Position += sizeof(short);
		} catch(System.Exception) {
			return false;
		}
		return true;
	}
};
public struct GetMainCharacterInfoAck_Serializer {
	public static bool Store(MemoryStream _buf_, GetMainCharacterInfoAck obj) { return obj.Store(_buf_); }
	public static bool Load(ref GetMainCharacterInfoAck obj, MemoryStream _buf_) { return obj.Load(_buf_); }
	public static int Size(GetMainCharacterInfoAck obj) { return obj.Size(); }
};
}
