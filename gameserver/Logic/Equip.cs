using ProjectZ.Common.Protocol.Protobuf;

namespace ProjectZ.Logic
{
    public class Equip {
        private Dictionary<int, Item> _clsEquipTree;
        public Equip() {
            _clsEquipTree = new Dictionary<int, Item>();
        }

        public Item GetItem(int itemId) {
            if (_clsEquipTree.ContainsKey(itemId)) {
                return _clsEquipTree[itemId];
            }
            return null;
        }
        public int HasItemCount() {
            // TODO check for invalid reg_date
            return _clsEquipTree.Count;
        }

        public bool IsExistItem(EnumItemEquipPosition ePosition) {
            return _clsEquipTree.ContainsKey((int)ePosition);
        }

        public Item PopItem(EnumItemEquipPosition ePosition) {
            if (IsExistItem(ePosition) == false) {
                return null;
            }

            Item pItem = _clsEquipTree[(int)ePosition];
            _clsEquipTree.Remove((int)ePosition);
            return pItem;
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

        public void EquipAddFromCharacterInfo(User user, CharacterInfo characterInfo) {
            if (characterInfo.Weapon != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Weapon);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_WEAPON, item);
                }
            }

            if (characterInfo.Helmet != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Helmet);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_HELMET, item);
                }
            }

            if (characterInfo.Armor != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Armor);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_ARMOR, item);
                }
            }

            if (characterInfo.Glove != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Glove);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_GLOVE, item);
                }
            }

            if (characterInfo.Shoes != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Shoes);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_SHOES, item);
                }
            }

            if (characterInfo.Necklace != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Necklace);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_NECKLACE, item);
                }
            }

            if (characterInfo.Ring != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Ring);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_RING, item);
                }
            }

            if (characterInfo.Charm != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Charm);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_CHARM, item);
                }
            }

            if (characterInfo.Avatar != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Avatar);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_AVARTAR, item);
                }
            }

            if (characterInfo.Vehicle != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Vehicle);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_VEHICLE, item);
                }
            }

            if (characterInfo.Title != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Title);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_TITLE, item);
                }
            }

            if (characterInfo.Fairy != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Fairy);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_FAIRY, item);
                }
            }

            if (characterInfo.Battlepet != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.Battlepet);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_PET, item);
                }
            }

            if (characterInfo.NameTag != 0) {
                Item item = user.GetBag(INVEN_BAG_TYPE.BAG_TYPE_NORMAL).GetItem((uint)characterInfo.NameTag);
                if (item != null) {
                    AddItem(EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG, item);
                }
            }
        }

        public void UpdateCharacterInfo(User user) {
            if (!IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_WEAPON)
            || !IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_FAIRY)
            || !IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_VEHICLE)) {
                return;
            }

            CharacterInfo characterInfo = user.Characters[user.GetSlotIndex()];

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_WEAPON)) {
                characterInfo.Weapon = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_WEAPON).GetItemSeq;
                characterInfo.WeaponIconidx = this.GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_WEAPON).Iconidx;
            } else {
                characterInfo.Weapon = 0;
                characterInfo.WeaponIconidx = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_HELMET)) {
                characterInfo.Helmet = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_HELMET).GetItemSeq;
                characterInfo.HelmetIconidx = this.GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_HELMET).Iconidx;
            } else {
                characterInfo.Helmet = 0;
                characterInfo.HelmetIconidx = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_ARMOR)) {
                characterInfo.Armor = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_ARMOR).GetItemSeq;
                characterInfo.ArmorIconidx = this.GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_ARMOR).Iconidx;
            } else {
                characterInfo.Armor = 0;
                characterInfo.ArmorIconidx = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_GLOVE)) {
                characterInfo.Glove = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_GLOVE).GetItemSeq;
            } else {
                characterInfo.Glove = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_SHOES)) {
                characterInfo.Shoes = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_SHOES).GetItemSeq;
            } else {
                characterInfo.Shoes = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_NECKLACE)) {
                characterInfo.Necklace = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_NECKLACE).GetItemSeq;
            } else {
                characterInfo.Necklace = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_CLOAK)) {
                characterInfo.Cloak = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_RING).GetItemSeq;
            } else {
                characterInfo.Cloak = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_RING)) {
                characterInfo.Ring = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_RING).GetItemSeq;
            } else {
                characterInfo.Ring = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_CHARM)) {
                characterInfo.Charm = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_CHARM).GetItemSeq;
            } else {
                characterInfo.Charm = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_AVARTAR)) {
                characterInfo.Avatar = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_AVARTAR).GetItemSeq;
                characterInfo.AvartarIconidx = this.GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_AVARTAR).Iconidx;
            } else {
                characterInfo.Avatar = 0;
                characterInfo.AvartarIconidx = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_VEHICLE)) {
                characterInfo.Vehicle = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_VEHICLE).GetItemSeq;
                characterInfo.VehicleIconidx = this.GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_VEHICLE).Iconidx;
            } else {
                characterInfo.Vehicle = 0;
                characterInfo.VehicleIconidx = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_TITLE)) {
                characterInfo.Title = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_TITLE).GetItemSeq;
            } else {
                characterInfo.Title = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_FAIRY)) {
                characterInfo.Fairy = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_FAIRY).GetItemSeq;
            } else {
                characterInfo.Fairy = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_PET)) {
                characterInfo.Battlepet = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_PET).GetItemSeq;
            } else {
                characterInfo.Battlepet = 0;
            }

            if (IsExistItem(EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG)) {
                characterInfo.NameTag = GetItem((int)EnumItemEquipPosition.ITEM_EQUIP_POS_NAME_TAG).GetItemSeq;
            } else {
                characterInfo.NameTag = 0;
            }

            user.SetCharacter(user.GetSlotIndex(), characterInfo);
            // TODO SetMainCharacterInfo
        }
    }
}