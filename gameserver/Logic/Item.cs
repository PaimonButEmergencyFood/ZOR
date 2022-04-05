using ProjectZ.Common.Protocol.Protobuf;

namespace ProjectZ.Logic {
    public class Item {
        public enum ItemStatus
        {
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

        private ProjectZ.Common.Protocol.Protobuf.Item _item;
        private int e_EquipPos;

        public int Tid {
            get {
                return _item.Tid;
            }
            set {
                _item.Tid = value;
            }
        }

        public int SubType {
            get {
                return _item.SubType;
            }
            set {
                _item.SubType = value;
            }
        }

        public int Quality {
            get {
                return _item.Quality;
            }
            set {
                _item.Quality = value;
            }
        }

        public int Level {
            get {
                return _item.Level;
            }
            set {
                _item.Level = value;
            }
        }

        public int Quantity {
            get {
                return _item.Quantity;
            }
            set {
                _item.Quantity = value;
            }
        }

        public int ClassType {
            get {
                return _item.ClassType;
            }
            set {
                _item.ClassType = value;
            }
        }

        public int BagType {
            get {
                return _item.BagType;
            }
            set {
                _item.BagType = value;
            }
        }

        public int BagSlotNumber {
            get {
                return _item.BagSlotNumber;
            }
            set {
                _item.BagSlotNumber = value;
            }
        }

        public int EvolvePoint {
            get {
                return _item.EvolvePoint;
            }
            set {
                _item.EvolvePoint = value;
            }
        }

        public int EvolvePercent {
            get {
                return _item.EvolvePercent;
            }
            set {
                _item.EvolvePercent = value;
            }
        }

        public int EvolveStep {
            get {
                return _item.EvolveStep;
            }
            set {
                _item.EvolveStep = value;
            }
        }

        public int EvolveMax {
            get {
                return _item.EvolveMax;
            }
            set {
                _item.EvolveMax = value;
            }
        }

        public int EvolveValue {
            get {
                return _item.EvolveValue;
            }
            set {
                _item.EvolveValue = value;
            }
        }

        public int CharacterSeq {
            get {
                return (int)_item.CharacterSeq;
            }
            set {
                _item.CharacterSeq = (uint)value;
            }
        }

        public List<int> EffType {
            get {
                List<int> effType = new List<int>();
                foreach (var eff in _item.EffType) {
                    effType.Add(eff);
                }
                return effType;
            }
        }

        public List<int> EffValue {
            get {
                List<int> effValue = new List<int>();
                foreach (var eff in _item.EffValue) {
                    effValue.Add(eff);
                }
                return effValue;
            }
        }

        public List<int> EffPos {
            get {
                List<int> effPos = new List<int>();
                foreach (var eff in _item.EffPos) {
                    effPos.Add(eff);
                }
                return effPos;
            }
        }

        public uint GetItemSeq {
            get {
                return _item.Seq;
            }
        }

        public uint Iconidx {
            get {
                return (uint)_item.Iconidx;
            }
        }

        public int CurDuration {
            get {
                return _item.CurDuration;
            }
            set {
                _item.CurDuration = value;
            }
        }

        public int MaxDuration {
            get {
                return _item.MaxDuration;
            }
            set {
                _item.MaxDuration = value;
            }
        }

        public int SetType {
            get {
                return _item.SetType;
            }
            set {
                _item.SetType = value;
            }
        }

        public int CurRefineStep {
            get {
                return _item.CurRefineStep;
            }
            set {
                _item.CurRefineStep = value;
            }
        }

        public int NonIdentity {
            get {
                return _item.NonIdentity;
            }
            set {
                _item.NonIdentity = value;
            }
        }

        public int OpenUpgradeStoneSlot {
            get {
                return _item.OpenUpgradeStoneSlot;
            }
            set {
                _item.OpenUpgradeStoneSlot = value;
            }
        }

        public int AbilityEnhanceRate {
            get {
                return _item.AbilityEnhanceRate;
            }
            set {
                _item.AbilityEnhanceRate = value;
            }
        }

        public int MaxEnhanceStep {
            get {
                return _item.MaxEnhanceStep;
            }
            set {
                _item.MaxEnhanceStep = value;
            }
        }

        public int BuyUse {
            get {
                return _item.BuyUse;
            }
            set {
                _item.BuyUse = value;
            }
        }

        public void SetEffType(int index, int value) {
            _item.EffType[index] = value;
        }

        public void SetEffType(List<int> effType) {
            _item.EffType.Clear();
            foreach (var eff in effType) {
                _item.EffType.Add(eff);
            }
        }

        public void SetEffValue(int index, int value) {
            _item.EffValue[index] = value;
        }

        public void SetEffValue(List<int> effValue) {
            _item.EffValue.Clear();
            foreach (var eff in effValue) {
                _item.EffValue.Add(eff);
            }
        }

        public void SetEffPos(int index, int value) {
            _item.EffPos[index] = value;
        }

        public void SetEffPos(List<int> effPos) {
            _item.EffPos.Clear();
            foreach (var eff in effPos) {
                _item.EffPos.Add(eff);
            }
        }

        public void SaveItem(User user) {
            if (_item.Seq == 0) {
                if (user.ItemCount == 0) {
                    _item.Seq = 1;
                } else {
                    _item.Seq = user.ItemCount + 1;
                }
            }
            user.AddItem(_item);
        }

        public Item() {
            _item = new ProjectZ.Common.Protocol.Protobuf.Item();
            for (int i = 0; i < 7; i++) {
                _item.EffType.Add(-1);
                _item.EffPos.Add(0);
                _item.EffValue.Add(-1);
            }
            e_EquipPos = -1;
            _item.SetType = -1;
        }

        public void SetItem(ProjectZ.Common.Protocol.Protobuf.Item item) {
            _item = item;
        }

        public void SetEquip (int pos) {
            e_EquipPos = pos;
        }

        public EnumItemEquipPosition GetEquipPos() {
            return (EnumItemEquipPosition)e_EquipPos;
        }
    }
}