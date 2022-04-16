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

            public delegate void Command(ref User pUser, ref NetworkPacket packet);
            public Command? GetCommand(ushort cmd) {
                if (clsCommandMap.ContainsKey(cmd)) {
                    return clsCommandMap[cmd];
                }
                Console.WriteLine("[USER]: Command not found: " + cmd);
                return null;
            }

            public virtual String GetName() {
                return "";
            }
            
            protected bool AddCommand(ushort cmd, Command pCommand) {
                if (clsCommandMap.ContainsKey(cmd)) {
                    Console.WriteLine("[USER]: Command already exists");
                    return false;
                }
                clsCommandMap.Add(cmd, pCommand);
                return true;
            }
            protected Dictionary<int, Command> clsCommandMap;
        }
        public enum EnumState {
            __NONE__,
            PVP_QUICK_WAIT,
            PVP_FRIENDLY_WAIT,
            PVP_AMITY_WAIT,
            PVP_READY,
            PVP_BATTLE,
            PVP_BATTLE_END,

            FRIEND_PARTY_WAIT,
            RANDOM_PARTY_WAIT,

            SINGLE_DUNGEON,

            INVITE,
            ACCEPT_WAIT,
            READY_WAIT,
            DUNGEON_BATTLE,

            BATTLE_ROYAL_PARTY_WAIT,
            BATTLE_ROYAL_READY_WAIT,
            BATTLE_ROYAL_READY,
            BATTLE_ROYAL_BATTLE,
            BATTLE_ROYAL_END,

            RECONNECT_WAIT,

            RECALL,

            PHYSICAL_CHANGE,

            TUTORIAL,

            NEW_PVP_ROOM_WAIT,

            WORLDBOSS_SINGLE,
            WORLDBOSS_PARTY,

            ENTER_EVENT_DUNGEON,

            RECEIPT_CHECKING_CLOSE,
            __MAX__
        }

        public delegate List<int> VECTORINFO();

        private string _socialID;
        private string _userNickName;
        private string _uuid;
        private UInt32 _company;
        private UInt32 _sale_code;

        private UserInfo _userInfo = new UserInfo();
        private CharacterInfo[] _characterInfo = new CharacterInfo[8];
        private List<UInt64> _dailyEPTime;
        private int _userSeq;
        private int _encrypt_key;
        private bool _userInfoCache;
        private bool _characterInfoCache;
        private bool _locationRegist;
        private bool _bagInfoCache;
        private int _openCharacterCount;
        private int _loadCharacterCount;

        private LocationServer? _locationServer;
        private CacheServer? _cacheServer;
        private FriendServer? _iFriendsServer;

        private NLogic.Bag[] _clsBagVector;

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
        private NLogic.Memcached _memcachedKey;
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
        private NLogic.Party? _party;
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

        private bool _isKick;

        public void SetLocationServer(ref LocationServer pLocationServer) {
            _locationServer = pLocationServer;
        }

        public void SetCacheServer(ref CacheServer pCacheServer) {
            _cacheServer = pCacheServer;
        }

        public void SetFriendServer(ref FriendServer pFriendServer) {
            _iFriendsServer = pFriendServer;
        }

        public ref LocationServer? GetLocationServer() {
            return ref _locationServer;
        }

        public ref CacheServer? GetCacheServer() {
            return ref _cacheServer;
        }

        public ref FriendServer GetFriendServer() {
            return ref _iFriendsServer;
        }

        public void SetSocialID(string pSocialID) {
            _socialID = pSocialID;
        }

        public string GetSocialID() {
            return _socialID;
        }

        public void SetUserNickName(string pUserNickName) {
            _userNickName = pUserNickName;
        }

        public string GetUserNickName() {
            return _userNickName;
        }

        public void SetUUID(string pUUID) {
            _uuid = pUUID;
        }

        public string GetUUID() {
            return _uuid;
        }

        public void SetCompany(UInt32 pCompany) {
            _company = pCompany;
        }

        public UInt32 GetCompany() {
            return _company;
        }

        public void SetSaleCode(UInt32 pSaleCode) {
            _sale_code = pSaleCode;
        }

        public UInt32 GetSaleCode() {
            return _sale_code;
        }

        public void SetUserInfo(UserInfo pUserInfo) {
            _userInfo = pUserInfo;
            _userInfoCache = true;

            _userInfo.nickname = GetUserNickName();
            _userInfo.uuid = GetUUID();

            _userInfo.company = GetCompany();
            _userInfo.sale_code = GetSaleCode();
        }

        public ref UserInfo GetUserInfo() {
            return ref _userInfo;
        }

        public void SetCharacterInfo(CharacterInfo characterInfo, int slotIndex) {
            _characterInfo[slotIndex] = characterInfo;

            if (_userInfo.main_slot_index == -1) {
                _userInfo.main_slot_index = slotIndex;
                Console.WriteLine("[USER]: SetMainSlotIndex : " + slotIndex);
            }

            if (_userInfo.main_slot_index == slotIndex) {
                throw new NotImplementedException();
                // load_DungeonClear_BagOrder_Buff_BattleAfterEffect();
                _characterInfoCache = true;
            }
        }

        public ref CharacterInfo GetCharacterInfo() {
            return ref _characterInfo[_userInfo.main_slot_index];
        }

        public ref CharacterInfo GetCharacterInfoFromIndex(int slotIndex) {
            return ref _characterInfo[slotIndex];
        }

        public void SetUserSeq(int pUserSeq) {
            _userSeq = pUserSeq;
            //throw new NotImplementedException();
            //_memcachedKey.SetMemcached(userSeq);
        }

        public int GetUserSeq() {
            return _userSeq;
        }

        public void SetEncryptKey(int pEncryptKey) {
            _encrypt_key = pEncryptKey;
        }

        public int GetEncryptKey() {
            return _encrypt_key;
        }

        public void SetLocationRegist() {
            _locationRegist = true;
        }

        public void SetCharacterInfoSetTime(UInt64 characterInfoSetTime) {
            _characterInfoSetTime = characterInfoSetTime;
        }

        public UInt64 GetCharacterInfoSetTime() {
            return _characterInfoSetTime;
        }

        public void SetLoginTime(UInt64 loginTime) {
            _loginTime = loginTime;
        }

        public UInt64 GetLoginTime() {
            return _loginTime;
        }

        public void SetAllDailyEPTime(UInt64 settime) {
            for (int i = 0; i < _dailyEPTime.Count; i++) {
                _dailyEPTime[i] = settime;
            }
        }

        public void SetDailyEPTime(UInt64 settime) {
            _dailyEPTime[_userInfo.main_slot_index] = settime;
        }

        UInt64 GetDailyEPTime() {
            return _dailyEPTime[_userInfo.main_slot_index];
        }

        public void SetOpenCharacterCount(int pOpenCharacterCount) {
            _openCharacterCount = pOpenCharacterCount;
        }

        public int GetOpenCharacterCount() {
            return _openCharacterCount;
        }

        public void AddOpenCharacterCount() {
            _openCharacterCount++;
        }

        public void AddLoadCharacterCount() {
            _loadCharacterCount++;
        }

        public int GetLoadCharacterCount() {
            return _loadCharacterCount;
        }

        public void CacheBagInfo(bool bFlag) {
            _bagInfoCache = bFlag;
        }

        public bool IsCacheBagInfo() {
            return _bagInfoCache;
        }

        public void FlushUserInfo() {
            if (_userInfoCache == true && GetLogin() == true) {
                throw new NotImplementedException();
            }
        }

        public void FlushCharacterInfo() {
            if (_characterInfoCache == true && GetLogin() == true) {
                throw new NotImplementedException();
            }
        }

        public void FlushNewCharacterInfo(int slotIndex) {
            if (_characterInfoCache == true && GetLogin() == true) {
                throw new NotImplementedException();
            }
        }

        public void FlushUserInfoCache() {
            if (_userInfoCache == true && GetLogin() == true) {
                throw new NotImplementedException();
            }
        }

        public void FlushCharacterInfoCache() {
            if (_characterInfoCache == true && GetLogin() == true) {
                throw new NotImplementedException();
            }
        }

        public void UnRegistLocation() {
            if (_locationRegist == true) {
                throw new NotImplementedException();
            }
        }

        public ref NLogic.Bag GetBag(INVEN_BAG_TYPE eBagType) {
            if (eBagType < INVEN_BAG_TYPE.BAG_TYPE_NORMAL || eBagType >= INVEN_BAG_TYPE.BAG_TYPE_MAX) {
                throw new Exception("eBagType is invalid");
            }

            return ref _clsBagVector[(int)eBagType];;
        }

        public ref NLogic.Equip GetEquip() {
            return ref _equip;
        }

        public ref  NLogic.MailBox GetMailBox() {
            return ref _mailBox;
        }

        public ref NLogic.Trade GetTrade() {
            return ref _trade;
        }

        public ref NLogic.Buff GetBuff() {
            return ref _buff;
        }

        public ref NLogic.Status GetStatus() {
            return ref _status;
        }

        public NLogic.Card GetCard() {
            return _card;
        }

        public NLogic.SocialInfo GetSocialInfo() {
            return _socialInfo;
        }

        public NLogic.BattleAfterEffect GetBattleAfterEffect() {
            return _battleAfterEffect;
        }

        public ref NLogic.VirtualCurrency GetVirtualCurrency() {
            return ref _virtualCurrency;
        }

        public ref NLogic.Score GetScore() {
            return ref _score;
        }

        public ref NLogic.Reward GetReward() {
            return ref _reward;
        }

        public ref NLogic.BattleResult GetBattleResult() {
            return ref _battleResult;
        }

        public ref NLogic.UserLocation GetUserLocation() {
            return ref _userLocation;
        }

        public ref NLogic.Memcached GetMemcached() {
            return ref _memcachedKey;
        }

        public ref NLogic.BackEndServerInfo GetBackEndServerInfo() {
            return ref _backEndServerInfo;
        }

        public ref NLogic.QuestInfo GetQuestInfo() {
            return ref _questInfo;
        }

        public ref NLogic.Fishing GetFishing() {
            return ref _fishing;
        }

        public ref NLogic.Stamina GetStamina() {
            return ref _stamina;
        }

        public bool GiveBaseItem(int slotIndex) {
            // weapon
            {
                NLogic.Item.Data clsData = new NLogic.Item.Data();
                clsData.tid = 0;
                clsData.sub_type = (int)EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON;
                clsData.quantity = 1;
                clsData.class_type = (int)GetCharacterInfoFromIndex(slotIndex).classtype;
                clsData.bag_type = NResource.Static.instance.GetItemResource().GetItemBagType(clsData);
                clsData.bag_slot_number = 0;

                NResource.Static.instance.GetItemResource().setItemEffect(ref clsData);

                NLogic.Item pItem = new NLogic.Item();
                var me = this; // ugh this is horrible
                pItem.Open_Normal(clsData, ref me);
                pItem.InsertToDatabaseItemInfo(slotIndex);
                GetCharacterInfoFromIndex(slotIndex).weapon = pItem.GetItemSeq();
                GetCharacterInfoFromIndex(slotIndex).weapon_iconidx = 0;
            }

            // fairy
            {
                throw new NotImplementedException();
            }
            
            return true;
        }


        public void SetLogin() {
            _login = true;
        }

        public bool GetLogin() {
            return _login;
        }

        public void SetVersion(int version) {
            _version = version;
        }

        public int GetVersion() {
            return _version;
        }

        public void SetKick() {
            _isKick = true;
        }

        
        public User() {
            _clsBagVector = new NLogic.Bag[(int)INVEN_BAG_TYPE.BAG_TYPE_MAX];
            _session = null;
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

            for (int i = (int)INVEN_BAG_TYPE.BAG_TYPE_NORMAL; i < (int)INVEN_BAG_TYPE.BAG_TYPE_MAX; i++) {
                _clsBagVector[i] = new NLogic.Bag();
            }

            _equip = new NLogic.Equip();
            _battle = new NLogic.Battle();
            _mailBox = new NLogic.MailBox();
            _trade = new NLogic.Trade();
            _buff = new NLogic.Buff();
            _status = new NLogic.Status();
            _card = new NLogic.Card();
            _socialInfo = new NLogic.SocialInfo();
            _battleAfterEffect = new NLogic.BattleAfterEffect();
            _virtualCurrency = new NLogic.VirtualCurrency();
            _score = new NLogic.Score();
            _reward = new NLogic.Reward();
            _battleResult = new NLogic.BattleResult();
            _userLocation = new NLogic.UserLocation();
            _memcachedKey = new NLogic.Memcached();
            _backEndServerInfo = new NLogic.BackEndServerInfo();
            _questInfo = new NLogic.QuestInfo();
            _fishing = new NLogic.Fishing();
            _stamina = new NLogic.Stamina();

            _dailyEPTime = new List<UInt64>();
            for (int i = 0; i < 8; i++) {
                _dailyEPTime.Add(0);
            }

            _enumStateType = EnumState.__NONE__;

            _login = false;

            _battlePVP = null;
            _battleRoyalBattle = null;
            _characterInfoSetTime = 0;
            _company = 0;
            _encrypt_key = 0;
            _loadCharacterCount = 0;
            _locationRegist = false;
            _openCharacterCount = 0;
            _loginTime = 0;
            _party = null;
            _sale_code = 0;
            //_state = null;
            _userSeq = 0;
            _version = 0;
            GID = 0;
            _characterInfoCache = false;
            _userInfoCache = false;

            _isKick = false;
        }

        public void Initialize() {
            _userInfo = new Cache.UserInfo();
            for (int i = 0; i < 8; i++) {
                _characterInfo[i] = new Cache.CharacterInfo();
            }
        }

        public void SetState(State pState) {
            _state = pState;
        }

        public ref State GetState() {
            return ref _state;
        }

        public void SetSession(ref Session session) {
            _session = session;
        }

        public ref Session? GetSession() {
            return ref _session;
        }

        public void SetDelUser() {
            _bDelUser = true;
        }
        public bool GetDelUser() {
            return _bDelUser;
        }

        public void SetSpace(ref NLogic.Space space) {
            _space = space;
        }
        public ref NLogic.Space? GetSpace() {
            return ref _space;
        }
        public void SetReserveSpace(ref NLogic.Space space) {
            _reserveSpace = space;
        }
        public ref NLogic.Space? GetReserveSpace() {
            return ref _reserveSpace;
        }
        public void _setWorldSpace(ref NLogic.Space space) {
            _world = space;
        }
        public ref NLogic.Space? _getWorldSpace() {
            return ref _world;
        }
        public int GetOldWorldSpaceIndex() {
            return _worldIndex;
        }
        public void SetEnumState(EnumState enumStateType) {
            _enumStateType = enumStateType;
        }
        public EnumState GetEnumState() {
            return _enumStateType;
        }
        public void SetParty(ref NLogic.Party party) {
            _party = party;
        }
        public ref NLogic.Party? GetParty() {
            return ref _party;
        }
        public void SetPartyAccept() {
            _partyAccept = true;
        }
        public bool GetPartyAccept() {
            return _partyAccept;
        }
        public void OnDisconnect() {
            throw new NotImplementedException();
        }
        public void OnReconnect() {
            throw new NotImplementedException();
        }
        public void CleanUp() {
            throw new NotImplementedException();
        }
        public void ForcedCleanUp() {
            throw new NotImplementedException();
        }

        public void printGID() {
            Console.WriteLine("[USER]: GID : " + GID);
        }

        public void SetGID(int pGID) {
            GID = pGID;
        }
    }
}