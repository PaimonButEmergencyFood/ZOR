using ProjectZ.Logic;
using NXLData;

namespace ProjectZ {
    public class ItemResource {
        public ItemResource() {
            
        }

        public int GetItemBagType(Item item) {
            switch ((EnumClassItemTableType)item.SubType) {
                case EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                    return item_common.stItem_Common_Common_Necklace[item.Tid].TYPE;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
            		return item_common.stItem_Common_Commonitem_Cloak[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_RING:
            		return item_common.stItem_Common_Commonitem_RING[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARM:
            		return item_common.stItem_Common_Commonitem_CHARM[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_TITLE:
            		return item_common.stItem_Common_Commonitem_TITLE[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARGE:
            		return item_common.stItem_Common_Commonitem_CHARGE[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_QUEST:
            		return item_common.stItem_Common_Commonitem_QUEST[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_ETC:
            		return item_common.stItem_Common_Commonitem_ETC[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_VEHICLE:
            		return item_common.stItem_Common_Commonitem_VEHICLE[item.Tid].TYPE;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_BATTLE_PET :
            		return item_common.stItem_Common_Commonitem_PET[item.Tid].TYPE;
            }

            if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_SLASHER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class1.stItem_CLASS1_Weapon01[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class1.stItem_CLASS1_Helmet01[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class1.stItem_CLASS1_Armor01[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class1.stItem_CLASS1_Gloves01[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class1.stItem_CLASS1_Shoes01[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class1.stItem_CLASS1_Avatar01[item.Tid].TYPE;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_RANGER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class2.stItem_CLASS2_Weapon02[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class2.stItem_CLASS2_Helmet02[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class2.stItem_CLASS2_Armor02[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class2.stItem_CLASS2_Gloves02[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class2.stItem_CLASS2_Shoes02[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class2.stItem_CLASS2_Avatar02[item.Tid].TYPE;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_FIGHTER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class3.stItem_CLASS3_Weapon03[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class3.stItem_CLASS3_Helmet03[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class3.stItem_CLASS3_Armor03[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class3.stItem_CLASS3_Gloves03[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class3.stItem_CLASS3_Shoes03[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class3.stItem_CLASS3_Avatar03[item.Tid].TYPE;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_MAGICIAN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class4.stItem_CLASS4_Weapon04[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class4.stItem_CLASS4_Helmet04[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class4.stItem_CLASS4_Armor04[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class4.stItem_CLASS4_Gloves04[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class4.stItem_CLASS4_Shoes04[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class4.stItem_CLASS4_Avatar04[item.Tid].TYPE;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_ASSASSIN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class5.stItem_CLASS5_Weapon05[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class5.stItem_CLASS5_Helmet05[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class5.stItem_CLASS5_Armor05[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class5.stItem_CLASS5_Gloves05[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class5.stItem_CLASS5_Shoes05[item.Tid].TYPE;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class5.stItem_CLASS5_Avatar05[item.Tid].TYPE;
                }
            }

            Console.WriteLine("Error: GetItemType() - Unknown class type: {0}, sub type {0}", item.ClassType, item.SubType);
            return 0;
        }
    }
}