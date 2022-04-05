namespace ProjectZ.Logic
{
    public class Equip {
        private Dictionary<int, Item> _clsEquipTree;
        public Equip() {
            _clsEquipTree = new Dictionary<int, Item>();
        }

        public bool AddItem(EnumItemEquipPosition ePosition, Item item) {
            if (item == null) {
                return false;
            }

            if (ePosition >= EnumItemEquipPosition.MAX_ITEM_EQUIP_POS && EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG < ePosition) {
                return false;
            }

            if (ePosition <= EnumItemEquipPosition.ITEM_EQUIP_POS_NONE) {
                return false;
            }

            int itemType = ItemResource.GetItemSubType(item);

            if (ePosition != EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG && (int)ePosition != itemType) {
                Console.WriteLine("Equip.AddItem() : ePosition != itemType");
                return false;
            }

            if (ePosition != EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG && itemType != 62 && itemType != 63) {
                Console.WriteLine("Equip.AddItem() : ePosition != itemType");
                return false;
            }

            if (_clsEquipTree.ContainsKey((int)ePosition)) {
                Item oldItem = _clsEquipTree[(int)ePosition];
                oldItem.SetEquip((int)EnumItemEquipPosition.ITEM_EQUIP_POS_NONE);
            }

            _clsEquipTree.Add((int)ePosition, item);
            item.SetEquip((int)ePosition);
            return true;
        }
    }
}