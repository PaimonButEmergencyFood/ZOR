namespace ProjectZ.NLogic {
    class Item {
        public enum ItemStatus {
            EM_ITEM_STATUS_NORMAL = 0,

            EM_ITEM_STATUS_REG_MARKET	= 10,
            EM_ITEM_STATUS_DESTROY,
            EM_ITEM_STATUS_SELL_STORE,
            EM_ITEM_STATUS_UPSTONE,
            EM_ITEM_STATUS_SEND_MAIL,
            EM_ITEM_STATUS_FAIRY_REBIRTH,
            EM_ITEM_STATUS_FAIRY_SACRIFICE,
            EM_ITEM_STATUS_BATTLEPET_COMBINE,
            EM_ITEM_STATUS_BATTLEPET_EVOLUTION,
            EM_ITEM_STATUS_ITEM_USE,
            EM_ITEM_STATUS_FAIRY_EVOLUTION = 20,
            EM_ITEM_STATUS_UPSTONE_COMBINE,

            EM_ITEM_STATUS_INVALID_ITEM	= 99,
        };

        public struct Data {
            public int bag_type;
            public int bag_slot_number;
            public int stack_num;
            public int class_type;
            public int sub_type;
            public int tid;
            public int item_type;
            public int iconidx;

            public int cur_duration;
            public int max_duration;
            public int quantity;
            public int set_type;
            public int non_identity;
            public int cur_refine_step;
            public int quality;
            public int level;

            public int[] eff_type; // 7
            public int[] eff_pos; // 7
            public int[] eff_value; // 7

            public int open_upgrade_stone_slot;
            public int ability_enhance_rate;
            public int max_enhance_step;
            public int buy_use;
            public int evolve_step;
            public int evolve_max;
            public int evolve_point;
            public int evolve_percent;
            public int evolve_value;

            public long reg_date;

            public Data() {
                bag_type = 0;
                bag_slot_number = 0;
                stack_num = 0;
                class_type = 0;
                sub_type = 0;
                tid = 0;
                item_type = 0;
                iconidx = 0;

                cur_duration = 0;
                max_duration = 0;
                quantity = 0;
                set_type = 0;
                non_identity = 0;
                cur_refine_step = 0;
                quality = 0;
                level = 0;
                
                set_type = -1;

                eff_type = new int[7];
                eff_pos = new int[7];
                eff_value = new int[7];

                for (int i = 0; i < 7; ++i) {
                    eff_type[i] = -1;
                    eff_pos[i] = -1;
                    eff_value[i] = -1;
                }

                open_upgrade_stone_slot = 0;
                ability_enhance_rate = 0;
                max_enhance_step = 0;
                buy_use = 0;
                evolve_step = 0;
                evolve_max = 0;
                evolve_point = 0;
                evolve_percent = 0;
                evolve_value = 0;

                reg_date = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }

            public void Clear() {
                bag_type = 0;
                bag_slot_number = 0;
                stack_num = 0;
                class_type = 0;
                sub_type = 0;
                tid = 0;
                item_type = 0;
                iconidx = 0;

                cur_duration = 0;
                max_duration = 0;
                quantity = 0;
                set_type = 0;
                non_identity = 0;
                cur_refine_step = 0;
                quality = 0;
                level = 0;

                set_type = -1;

                eff_type = new int[7];
                eff_pos = new int[7];
                eff_value = new int[7];

                for (int i = 0; i < 7; ++i) {
                    eff_type[i] = -1;
                    eff_pos[i] = -1;
                    eff_value[i] = -1;
                }

                open_upgrade_stone_slot = 0;
                ability_enhance_rate = 0;
                max_enhance_step = 0;
                buy_use = 0;
                evolve_step = 0;
                evolve_max = 0;
                evolve_point = 0;
                evolve_percent = 0;
                evolve_value = 0;

                reg_date = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        };

        private Data _data;
        private UInt64 _itemSeq;
        private User? _user;
        private int _status;
        private EnumClassItemTableType e_EquipPos;

        private static int s_index = 1;

        public Item() {
           Initialize();
        }

        public void Initialize() {
            e_EquipPos = EnumClassItemTableType.CLASS_ITEM_TABLE_NONE;
            _itemSeq = 0;
            _user = null;
            _status = 0;
        }

        public void Finalize() {
        }

        public ref Item.Data GetData() {
            return ref _data;
        }

        public bool Open_Normal(Data data, ref User pUser) {
            _data = data;
            _user = pUser;

            return ProjectZ.NResource.Static.instance.GetItemResource().SetItemDataFromResource(ref _user, ref _data);
        }

        public void OpenFairy(Data data, ref User pUser) {
            _data = data;
            _user = pUser;
        }

        public void Open_FromDatabase(UInt64 itemSeq, Data data, ref User user) {
            _data = data;
            _user = user;
            _itemSeq = itemSeq;
        }

        public void Open_None(Data data, ref User pUser) {
            _data = data;
            _user = pUser;
        }

        public void Open_UpStone(Data data, ref User pUser) {
            _data = data;
            _user = pUser;

            NResource.Static.instance.GetItemResource().SetAdditionalEffect(ref _data);
        }

        public void Open_DungeonDrop(Data data, ref User pUser) {
            _data = data;
            _user = pUser;
            _itemSeq = (UInt64)s_index++;

            NResource.Static.instance.GetItemResource().SetItemDataFromResource(ref _user, ref _data);
        }

        public void SetEquip(EnumClassItemTableType eEquipPos) {
            e_EquipPos = eEquipPos;
        }

        public EnumClassItemTableType GetEquipPos() {
            return e_EquipPos;
        }

        public bool IsEquip() {
            return e_EquipPos != EnumClassItemTableType.CLASS_ITEM_TABLE_NONE;
        }

        public UInt64 GetItemSeq() {
            return _itemSeq;
        }

        public bool InsertToDatabaseItemInfo(int slotIndex) {
            throw new NotImplementedException();
        }

        public bool UpdateDatabaseItemInfo() {
            throw new NotImplementedException();
        }

        public bool DeleteDatabaseItemInfo(ItemStatus eStatus) {
            throw new NotImplementedException();
        }

        public void WriteToPacket(ref NetworkPacket packet) {
            packet.U1((sbyte)_data.cur_duration);
            packet.U1((sbyte)_data.max_duration);
            packet.U1((sbyte)_data.quantity);
            packet.U1((sbyte)_data.set_type);
            packet.U1((sbyte)_data.non_identity);
            packet.U1((sbyte)_data.cur_refine_step);

            packet.U1((sbyte)_data.quality);
            packet.U1((sbyte)_data.level);

            for (int i = 0; i < 7; ++i) {
                packet.U1((sbyte)_data.eff_type[i]);
                packet.U1((sbyte)_data.eff_pos[i]);
                
                if (i == 0 && (int)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG == NResource.Static.instance.GetItemResource().GetItemSubType(_data)) {
                    long remainTime = (_data.reg_date + (_data.eff_value[0] * 60)) - DateTimeOffset.Now.ToUnixTimeMilliseconds();

                    if (remainTime > 0) {
                        packet.U2((short)(remainTime / 60));
                    } else {
                        packet.U2(0);
                    }
                } else if (i == 0 && (int)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG_WORLDBOSS != NResource.Static.instance.GetItemResource().GetItemSubType(_data)) {
                    long remainTime = (_data.reg_date + (_data.eff_value[0] * 60)) - DateTimeOffset.Now.ToUnixTimeMilliseconds();

                    if (remainTime > 0) {
                        packet.U2((short)(remainTime / 60));
                    } else {
                        packet.U2(0);
                    }
                } else {
                    packet.U2((short)_data.eff_value[i]);
                }
            }

            packet.U1((sbyte)_data.open_upgrade_stone_slot);
            packet.U1((sbyte)_data.ability_enhance_rate);
            packet.U1((sbyte)_data.max_enhance_step);
            packet.U1((sbyte)_data.buy_use);

            packet.U1((sbyte)_data.evolve_step);
            packet.U1((sbyte)_data.evolve_max);
            packet.U2((short)_data.evolve_point);
            packet.U2((short)_data.evolve_percent);
            packet.U2((short)_data.evolve_value);
            packet.U1((sbyte)_data.class_type);
            packet.U1((sbyte)_data.sub_type);
            packet.U2((short)_data.tid);
        }

        public void SetStatus(int status) {
            _status = status;
        }

        public int GetStatus() {
            return _status;
        }

        public void ChangeBagTypeFromResourceData() {
            _data.bag_type = NResource.Static.instance.GetItemResource().GetItemBagType(_data);
        }

        public void ChangeBagTypeWareHouse() {
            _data.bag_type = (int)INVEN_BAG_TYPE.BAG_TYPE_WAREHOUSE;
        }

        public void ChangeIdentifyItem() {
            _data.non_identity = 0;
        }

        public void DecreaseBattlepetStamina() {
            if (_data.eff_value[5] <= 0) {
                return;
            }
            _data.eff_value[5] -= 1;
            UpdateDatabaseItemInfo();
        }
    }
}