namespace ProjectZ.Logic  {
    public class Bag {
        private List<Item> _clsItemVector;
        private bool _bLoad;
        private bool _bDecreaseBattlepetStamina;
        private int _itemCount;
        private int _eBagType;
        private int _maxSlotCount;
        public Bag(int eBagType) {
            _clsItemVector = new List<Item>();
            _bLoad = false;
            _bDecreaseBattlepetStamina = false;
            _itemCount = -1;
            _eBagType = -1;
            _maxSlotCount = Function.GetBagSlotMaxOpenCount((INVEN_BAG_TYPE)eBagType);
        }

        public int HasItemCount() {
            return _itemCount;
        }

        public int GetBagType() {
            return _eBagType;
        }

        public bool IsLoad() {
            return _bLoad;
        }

        public bool IsDecreaseBattlepetStamina() {
            return _bDecreaseBattlepetStamina;
        }

        public List<Item> GetItemVector() {
            return _clsItemVector;
        }

        public bool AddItem(Item item) {
            if (item == null) {
                return false;
            }

            if (HasItemCount() >= _maxSlotCount) {
                return false;
            }

            _clsItemVector.Add(item);
            _itemCount++;
            return true;
        }

        public bool AddItem(ProjectZ.Common.Protocol.Protobuf.Item _item) {
            if (_item == null) {
                return false;
            }

            if (HasItemCount() >= _maxSlotCount) {
                return false;
            }

            Item item = new Item();
            item.SetItem(_item);
            _clsItemVector.Add(item);
            _itemCount++;
            return true;
        }

        public Item GetItem(UInt32 ItemSeq) {
            for (int i = 0; i < _clsItemVector.Count; i++) {
                if (_clsItemVector[i].GetItemSeq == ItemSeq) {
                    return _clsItemVector[i];
                }
            }

            return null;
        }

        public Item PopItem(UInt32 ItemSeq) {
            for (int i = 0; i < _clsItemVector.Count; i++) {
                if (_clsItemVector[i].GetItemSeq == ItemSeq) {
                    Item item = _clsItemVector[i];
                    _clsItemVector.RemoveAt(i);
                    _itemCount--;
                    return item;
                }
            }

            return null;
        }

        public bool IsBagFull() {
            return HasItemCount() >= _maxSlotCount;
        }

        public bool IsExistItem(UInt32 ItemSeq) {
            for (int i = 0; i < _clsItemVector.Count; i++) {
                if (_clsItemVector[i].GetItemSeq == ItemSeq) {
                    return true;
                }
            }

            return false;
        }

        public bool IsExistSameItem(Item item) {
            for (int i = 0; i < _clsItemVector.Count; i++) {
                if (_clsItemVector[i].SubType == item.SubType && _clsItemVector[i].Tid != item.Tid) {
                    return true;
                }
            }
            return false;
        }

        public int RemainBagSlotCount() {
            return _maxSlotCount - HasItemCount();
        }

        public void ItemLoadFromList(List<ProjectZ.Common.Protocol.Protobuf.Item> items, int characterseq = -1) {
            foreach (var item in items) {
                if (item.BagType == _eBagType) {
                    if (characterseq >= 0) {
                        if (item.CharacterSeq == characterseq) {
                            AddItem(item);
                        }
                    } else {
                        AddItem(item);
                    }
                }
            }
            _bLoad = true;
        }
    }
}