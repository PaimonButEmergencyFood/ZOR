namespace ProjectZ.NLogic {
    using SPACETREE = Dictionary<int, Space>;
    using SPACEVECTOR = List<Space>;
    using PARTYROOMTREE = Dictionary<Key, List<Space>>;
    using PARTYROOMTREE_V2 = Dictionary<int, List<Space>>;
    using WORLDBOSSROOMTREE = Dictionary<int, Space>;
    using PKROOMTREE = Dictionary<int, Space>;
    public struct Key {
        public Key() {
            u16dungeon_tid = 0;
            u8difficulty = 0;
        }

        public Key(ushort dungeon_tid, byte difficulty) {
            u16dungeon_tid = dungeon_tid;
            u8difficulty = difficulty;
        }

        public bool Equals(Key rSide) {
            return u16dungeon_tid == rSide.u16dungeon_tid && u8difficulty == rSide.u8difficulty;
        }

        public bool Smaller(Key rSide) {
            if (u16dungeon_tid < rSide.u16dungeon_tid) {
                return true;
            } else if (u16dungeon_tid == rSide.u16dungeon_tid) {
                return u8difficulty < rSide.u8difficulty;
            } else {
                return false;
            }
        }

        private UInt16 u16dungeon_tid;
        private byte u8difficulty;
    }

    class Static : NUtil.Single<Static> {
        private NUtil.Pool<Space> _clsSpacePool;
        private SPACETREE _clsSpaceTree;
        private SPACETREE _clsWorldTree;

        private SPACEVECTOR _clsPVPRoomVector;

        private PARTYROOMTREE _clsPartyRoomTree;

        private PKROOMTREE _clsPKRoomTree;

        private NUtil.Pool<Monster> _clsMonsterPool;
        private Dictionary<Monster, int> _clsMonsterCounter;

        private NUtil.Pool<Item> _clsItemPool;
        private Dictionary<Item, int> _clsItemCounter;

        private NUtil.Pool<QuestInfo.Quest> _clsQuestPool;
        private NUtil.Pool<Party> _clsPartyPool;
        NUtil.Pool<MailBox.Mail> _clsMailPool;
        NUtil.Pool<Trade.TradeItem> _clsTradeItemPool;

        // ServerAddrCCU
        Memcached _clsMemcached;

        NUtil.Pool<Battle> _pBattlePool;

        NUtil.Pool<Indexer> _clsIndexerPool;
        NUtil.Pool<IndexerPVP> _clsPVPIndexerPool;
        NUtil.Pool<IndexerPK> _clsPKIndexerPool;

        WORLDBOSSROOMTREE _clsWorldBossRoomTree;
        WorldBossRank _pWorldBossRank;
        NUtil.Pool<IndexerWorldBoss> _pWorldBossIndexerPool;

        WORLDBOSSROOMTREE _clsWorldBossRoomTree_Friend;
        NUtil.Pool<IndexerNewPartyRoomV2> _clsIndexerNewPartyRoomV2Pool;
        PARTYROOMTREE_V2 _clsPartyRoomTree_V2;
        public Static() {
            _clsSpacePool = new NUtil.Pool<Space>(Constants.MAX_SPACE_POOL);
            for (int i = 1; i <= 10; i++) {
            }
            _clsMonsterPool = new NUtil.Pool<Monster>(1200 * 8);

            _clsItemPool = new NUtil.Pool<Item>(1200 * 30);

            _clsQuestPool = new NUtil.Pool<QuestInfo.Quest>(1200 * 8);
            _clsPartyPool = new NUtil.Pool<Party>(1200);
            _clsMailPool = new NUtil.Pool<MailBox.Mail>(1200 * 8);
            _clsTradeItemPool = new NUtil.Pool<Trade.TradeItem>(1200 * 10);

            _clsMemcached = new Memcached();

            _pBattlePool = new NUtil.Pool<Battle>(1200);

            _clsIndexerPool = new NUtil.Pool<Indexer>(1000);
            _clsPVPIndexerPool = new NUtil.Pool<IndexerPVP>(Constants.MAX_NEW_PVP_ROOM);
            _clsPKIndexerPool = new NUtil.Pool<IndexerPK>(Constants.MAX_NEW_PK_ROOM);

            _clsPartyRoomTree_V2 = new PARTYROOMTREE_V2();
            _clsPartyRoomTree = new PARTYROOMTREE();
            for (int dungeonTid = 1; dungeonTid < 36; dungeonTid++) {
                _clsPartyRoomTree_V2.Add(dungeonTid, new SPACEVECTOR());
                for (int difficulty = 1; difficulty <= 3; difficulty++) {
                    _clsPartyRoomTree.Add(new Key((ushort)dungeonTid, (byte)difficulty), new SPACEVECTOR());
                }
            }

            _pWorldBossRank = new WorldBossRank();
            _pWorldBossIndexerPool = new NUtil.Pool<IndexerWorldBoss>(1000);

            _clsIndexerNewPartyRoomV2Pool = new NUtil.Pool<IndexerNewPartyRoomV2>(1000);
        }

        public Item? NEW_ITEM() {
            return _clsItemPool.NEW();
        }
        public void DEL_ITEM(Item obj) {
            _clsItemPool.DEL(obj);
        }
        public Monster? NEW_MONS() {
            return _clsMonsterPool.NEW();
        }
        public void DEL_MONSTER(Monster obj) {
            _clsMonsterPool.DEL(obj);
        }
        public ref NUtil.Pool<Space> GETSPACEPOOL() {
            return ref _clsSpacePool;
        }
        public ref SPACETREE GETSPACETREE() {
            return ref _clsSpaceTree;
        }
        public ref SPACETREE GETWORLDSPACETREE() {
            return ref _clsWorldTree;
        }
        public ref NUtil.Pool<QuestInfo.Quest> GETQUESTPOOL() {
            return ref _clsQuestPool;
        }
        public ref NUtil.Pool<Party> GETPARTYPOOL() {
            return ref _clsPartyPool;
        }
        public ref NUtil.Pool<MailBox.Mail> GETMAILPOOL() {
            return ref _clsMailPool;
        }
        public ref NUtil.Pool<Trade.TradeItem> GETTRADEITEMPOOL() {
            return ref _clsTradeItemPool;
        }
        public ref Memcached GetMemcached() {
            return ref _clsMemcached;
        }

        public ref NUtil.Pool<Battle> GETBATTLEPOOL() {
            return ref _pBattlePool;
        }

        public int GETCCU(int channelNumber) {
            throw new NotImplementedException();
            //return _clsWorldTree.ContainsKey(channelNumber) ? _clsWorldTree[channelNumber].GetCCU() : 0;
        }

        public ref NUtil.Pool<Indexer> GETINDEXERPOOL() {
            return ref _clsIndexerPool;
        }
        public ref NUtil.Pool<IndexerPVP> GETPVPINDEXERPOOL() {
            return ref _clsPVPIndexerPool;
        }
        public ref NUtil.Pool<IndexerPK> GETPKINDEXERPOOL() {
            return ref _clsPKIndexerPool;
        }
        public ref PARTYROOMTREE GETPARTYROOMTREE() {
            return ref _clsPartyRoomTree;
        }
        public ref PKROOMTREE GETPKROOMTREE() {
            return ref _clsPKRoomTree;
        }
        public ref SPACEVECTOR GETPVPROOMVECTOR() {
            return ref _clsPVPRoomVector;
        }

        public ref WORLDBOSSROOMTREE GETWORLDBOSSROOMTREE() {
            return ref _clsWorldBossRoomTree;
        }
        public ref WorldBossRank GETWORLDBOSSRANK() {
            return ref _pWorldBossRank;
        }
        public ref NUtil.Pool<IndexerWorldBoss> GETWORLDBOSSINDEXERPOOL() {
            return ref _pWorldBossIndexerPool;
        }

        public ref WORLDBOSSROOMTREE GETWORLDBOSSROOMTREE_FRIEND() {
            return ref _clsWorldBossRoomTree_Friend;
        }

        public ref NUtil.Pool<IndexerNewPartyRoomV2> GETINDEXERNEWPARTYROOMV2POOL() {
            return ref _clsIndexerNewPartyRoomV2Pool;
        }
        public ref PARTYROOMTREE_V2 GETPARTYROOMTREEV2() {
            return ref _clsPartyRoomTree_V2;
        }
    }
}