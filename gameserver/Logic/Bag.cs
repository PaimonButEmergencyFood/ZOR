namespace ProjectZ.Logic  {
    public class Bag {
        private List<Item> _clsItemVector;
        private bool _bLoad;
        private bool _bDecreaseBattlepetStamina;
        private int _itemCount;
        private int _eBagType;
        private int _maxSlotCount;
        public Bag() {
            
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
    }
}