using System.Numerics;

namespace ProjectZ.NResource {
    class ItemResource {
        public struct Key {
            public Key(int tid, int class_type) {
                _tid = tid;
                _class_type = class_type;
            }

            public Key() : this(0, 0) { }

            int _tid;
            int _class_type;

            bool Equals(Key other) {
                return _tid == other._tid && _class_type == other._class_type;
            }

            bool Smaller(Key other) {
                return _tid < other._tid || (_tid == other._tid && _class_type < other._class_type);
            }
        };

        public struct Flyweight {
            int _TID;
            int 	_CLASSITEMTABLETYPE;
            int		_ICON;
            String	_NAME_KOR; // len 100
            String	_NAME_ENG; // len 100
            String	_NAME_JPN; // len 100
            int		_USING;
            int		_DESTROY;
            int		_SALE;	
            int		_ITEM_EXCHANGE;
            int		_STACK;
            int		_BAGTYPE;
            int		_SUBTYPE;
            int		_CHARCLASSTYPE;
            int		_PRICE;
            int		_DURABILITY;
            int		_LIMIT_LEVEL;
            int		_EFFECT;
            int		_EFF_VALUE;
            int		_EFF_POS;
        };

        //private Dictionary<Key, Flyweight> ITEMRESOURCETREE = new Dictionary<Key, Flyweight>();
        private List<Dictionary<Key, Flyweight>> ITEMRESOURCETREEVECTOR = new List<Dictionary<Key, Flyweight>>((int)EnumClassItemTableType.CLASS_ALL_ITEM_TABLE_MAX);

        String? emptyString;

        public ItemResource() {
            ITEMRESOURCETREEVECTOR = new List<Dictionary<Key, Flyweight>>((int)EnumClassItemTableType.CLASS_ALL_ITEM_TABLE_MAX);
            emptyString = "";
        }

        public void Clear() {
            ITEMRESOURCETREEVECTOR.Clear();
        }

        public bool LoadResource() {
            throw new System.NotImplementedException();
        }

        public bool SetItemDataFromResource(ref User user, ref NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool SetItemFromXLS(ref User user, ref NLogic.Item.Data clsData, int sheet, int tid, int quantity) {
            throw new System.NotImplementedException();
        }

        public String GetItemName(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetIconIndex(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetItemUsing(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        // GetItemSettedType

        // IsItemIdentify

        // GetItemBelong

        // GetItemMaxRefine

        public int GetItemOpenSlotCount(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool isEquip(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool isUpstone(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool isFairy(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool isBattlePet(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool isAccessary(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public void SetAdditionalEffect(ref NLogic.Item.Data clsData, bool bFairySacrifice=false) {
            throw new System.NotImplementedException();
        }

        public int getAdditionalEffectType(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int getAdditionalEffectValue(NLogic.Item.Data clsData, int effectType, int upAddPercent, int slotIndex) {
            throw new System.NotImplementedException();
        }

        public int getAdditionalEffectPos(int effectType) {
            throw new System.NotImplementedException();
        }

        public int getItemRoutingValue(NLogic.Item.Data clsData, int slotIndex) {
            throw new System.NotImplementedException();
        }

        public int GetItemBagType(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetItemPrice(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetItemDurability(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetItemLevel(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public void setItemEffect(ref NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetClassType(ref User pUser, int tid, int sheet_type) {
            throw new System.NotImplementedException();
        }

        public int GetItemSubType(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int getItemTradeType(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int getItemSaleType(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int getItemStackType(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public void setItemEffectForCardReward(ref NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int getRandBetween(int min, int max) {
            if (max < min) {
                max = min;
            }
            return (int)((max - min) * (float)new Random().NextDouble() + min);
        }

        public Dictionary<Key, Flyweight> GetItemResourceTree(EnumClassItemTableType eClassItemTableType) {
            return ITEMRESOURCETREEVECTOR[(int)eClassItemTableType];
        }

        public Flyweight? getFly(int sub_type, int tid, int class_type) {
            var key = new Key(tid, class_type);
            if (sub_type > (int)EnumClassItemTableType.CLASS_ALL_ITEM_TABLE_MAX) {
                key = new Key(tid, -1);
            }
            var tree = ITEMRESOURCETREEVECTOR[(int)class_type];
            if (tree.ContainsKey(key)) {
                return tree[key];
            }
            return null;
        }
    }
}