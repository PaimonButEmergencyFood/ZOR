using Cache;
using Location;
using iFriends;

using System.Reflection;

namespace ProjectZ {
    public class User {
        public class State {
            public State() {
                clsCommandMap = new Dictionary<int, Command>();
            }

            public delegate void Command(ref User pUser, NetworkPacket packet);
            Command? GetCommand(ushort cmd) {
                if (clsCommandMap.ContainsKey(cmd)) {
                    return clsCommandMap[cmd];
                }
                return null;
            }

            public virtual String GetName() {
                return "";
            }
            
            protected bool AddCommand(ushort cmd, Command pCommand) {
                if (clsCommandMap.ContainsKey(cmd)) {
                    return false;
                }
                clsCommandMap.Add(cmd, pCommand);
                return true;
            }
            protected Dictionary<int, Command> clsCommandMap;
        }
        public enum EnumState {
            __NONE__,
            __MAX__
        }

        public List<int> VECTORINFO = new List<int>();

        private string _socialID;
        private string _userNickName;
        private string _uuid;
        private UInt32 _company;
        private UInt32 _sale_code;

        private UserInfo _userInfo;
        private CharacterInfo[] _characterInfo;
        private List<UInt64> _dailyEPTime;
        private int _userSeq;
        private int _encrypt_key;
        private bool _userInfoCache;
        private bool _characterInfoCache;
        private bool _locationRegist;
        private bool _bagInfoCache;
        private int _openCharacterCount;
        private int _loadCharacterCount;

        private List<NLogic.Bag> _clsBagVector;

        private NLogic.Equip _equip;
        private NLogic.Buff _buff;
        private NLogic.Status _status;
        private NLogic.Card _card;
        private NLogic.SocialInfo _socialInfo;
        private NLogic.MailBox _mailBox;
        private NLogic.BattleAfterEffect _battleAfterEffect;
        private NLogic.VirtualCurrency _virtualCurrency;
        private NLogic.Score _score;
        private NLogic.Reward _reward;
        private NLogic.BattleResult _battleResult;
        private NLogic.UserLocation _userLocation;
        private NLogic.Trade _trade;
        private NLogic.MemcachedKey _memcachedKey;
        private NLogic.BackEndServerInfo _backEndServerInfo;
        private NLogic.QuestInfo _questInfo;
        private NLogic.Fishing _fishing;
        private NLogic.Stamina _stamina;

        private State _state;
        private Session? _session;

        private bool _bClose;
        private bool _bDelUser;
        private bool _bZENEvent;
        private bool _bBattleReconnect;
        private NLogic.Space? _space;
        private NLogic.Space? _world;
        private NLogic.Space? _reserveSpace;
        private int _worldIndex;
        private NLogic.Battle _battle;

        private EnumState _enumStateType;
        private NLogic.Party _party;
        private bool _partyAccept;

        private List<int> _array_dungeon_clear_info;
        private List<int> _array_bag_order_info;
        private bool _battle_aftereffect;

        private ulong _latency;

        private uint _refCount;
        private UInt64 _characterInfoSetTime;
        private UInt64 _loginTime;

        private NLogic.Battle _battleRoyalBattle;
        private NLogic.Battle _battlePVP;

        protected int GID;

        private bool _login;
        private int _version;

        
        public User() {
            _clsBagVector = new List<NLogic.Bag>((int)INVEN_BAG_TYPE.BAG_TYPE_MAX);
            _session = new Session();
            _bClose = false;
            _bDelUser = false;
            _bZENEvent = false;
            _bBattleReconnect = false;
            _space = null;
            _world = null;
            _reserveSpace = null;
            _worldIndex = -1;
            _partyAccept = false;
            _bagInfoCache = false;
            _battle_aftereffect = false;
            _latency = 0;
            _refCount = 0;
            _array_dungeon_clear_info = new List<int>(Constants.MAX_DUNGEON_COUNT);
            _array_bag_order_info = new List<int>((int)INVEN_BAG_TYPE.BAG_TYPE_MAX);

            SetState(NState.Static.instance.TITLE());
        }

        public void SetState(State pState) {
            _state = pState;
        }
    }
}