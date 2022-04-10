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

        public bool SetItemDataFromResource(ref User pUser, ref NLogic.Item.Data clsData) {
            NResource.BalanceData pBalance = NResource.Static.instance.GetBalanceResource().GetBalancePtr(ref pUser);
            if (pBalance == null) {
                Console.WriteLine("pBalance is null");
                return false;
            }

            Flyweight? flyweight = getFly(clsData.sub_type, clsData.tid, clsData.class_type);

            if (flyweight == null) {
                Console.WriteLine("flyweight is null, sub_type: {0}, tid: {1}, class_type: {2}", clsData.sub_type, clsData.tid, clsData.class_type);
                return false;
            }

            clsData.bag_type = GetItemBagType(clsData);
            clsData.level = GetItemLevel(clsData);
            clsData.cur_duration = GetItemDurability(clsData);
            clsData.max_duration = GetItemDurability(clsData);
            clsData.max_enhance_step = GetItemMaxRefine(pBalance, clsData);
            clsData.iconidx = GetIconIndex(clsData);

            clsData.item_type = GetItemUsing(clsData);

            clsData.buy_use = GetItemBelong(pBalance, clsData);
            
            clsData.open_upgrade_stone_slot = GetItemOpenSlotCount(clsData);

            clsData.set_type = GetItemSettedType(pBalance, clsData);

            clsData.non_identity = Convert.ToInt32(IsItemIdentify(pBalance, clsData));

            SetAdditionalEffect(ref clsData);

            return true;

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

        public int GetItemSettedType(NResource.BalanceData pBalance, NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool IsItemIdentify(NResource.BalanceData pBalance, NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetItemBelong(NResource.BalanceData, NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public int GetItemMaxRefine(NResource.BalanceData pBalance, NLogic.Item.Data clsData) {
            if (isEquip(clsData) == false) {
                return 0;
            }

            switch (clsData.quality) {
                case (int)EnumItemQuality.ITEM_QUALITY_D: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_D_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_C: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_C_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_B: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_B_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_A: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_A_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_S: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_S_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_SP: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_SP_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_SS: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_SS_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_SSP: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_SSP_GRADE);
                case (int)EnumItemQuality.ITEM_QUALITY_SSS: return pBalance.GetValue((int)EnumBalance.EM_REFINE_ABLE_MAX_COUNT_SSS_GRADE);
            }
            return 0;
        }

        public int GetItemOpenSlotCount(NLogic.Item.Data clsData) {
            throw new System.NotImplementedException();
        }

        public bool isEquip(NLogic.Item.Data clsData) {
            switch (clsData.sub_type) {
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_RING:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_CHARM:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
                    return true;
            }
            return false;
        }

        public bool isUpstone(NLogic.Item.Data clsData) {
            if (clsData.sub_type == (int)EnumClassItemTableType.CLASS_ITEM_TABLE_ETC && clsData.tid == Constants.UPSTONE_TID) {
                return true;
            }
            return false;
        }

        public bool isFairy(NLogic.Item.Data clsData) {
            if (clsData.bag_type == (int)INVEN_BAG_TYPE.BAG_TYPE_FAIRY) {
                return true;
            }
            return false;
        }

        public bool isBattlePet(NLogic.Item.Data clsData) {
            if (clsData.bag_type == (int)INVEN_BAG_TYPE.BAG_TYPE_BATTLE_PET) {
                return true;
            }
            return false;
        }

        public bool isAccessory(NLogic.Item.Data clsData) {
            switch (clsData.sub_type) {
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_RING:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_CHARM:
                case (int)EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
                    return true;
            }
            return false;
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
            /**
            Flyweight? pFly = getFly(clsData.sub_type, clsData.tid, clsData.class_type);
            
            if (pFly == null) {
                Console.WriteLine("pFly is null: " + clsData.sub_type + " " + clsData.tid + " " + clsData.class_type);
                return -1;
            }
            return pFly._BAGTYPE;
            **/
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