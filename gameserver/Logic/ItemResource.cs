using ProjectZ.Logic;
using NXLData;

namespace ProjectZ {
    public class ItemResource {
        public static int GetItemBagType(Item item) {
            switch ((EnumClassItemTableType)item.SubType) {
                case EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                    return item_common.stItem_Common_Common_NECKLACE[item.Tid].TYPE;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
            		return item_common.stItem_Common_Commonitem_CLOAK[item.Tid].TYPE;
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

            Console.WriteLine("Error: GetItemType() - Unknown class type: {0}, sub type {1}", item.ClassType, item.SubType);
            return 0;
        }

        public static int getItemStackType(Item item) {
            switch ((EnumClassItemTableType)item.SubType) {
                case EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                    return item_common.stItem_Common_Common_NECKLACE[item.Tid].STACK;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
            		return item_common.stItem_Common_Commonitem_CLOAK[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_RING:
            		return item_common.stItem_Common_Commonitem_RING[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARM:
            		return item_common.stItem_Common_Commonitem_CHARM[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_TITLE:
            		return item_common.stItem_Common_Commonitem_TITLE[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARGE:
            		return item_common.stItem_Common_Commonitem_CHARGE[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_QUEST:
            		return item_common.stItem_Common_Commonitem_QUEST[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_ETC:
            		return item_common.stItem_Common_Commonitem_ETC[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_VEHICLE:
            		return item_common.stItem_Common_Commonitem_VEHICLE[item.Tid].STACK;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_BATTLE_PET :
            		return item_common.stItem_Common_Commonitem_PET[item.Tid].STACK;
            }

            if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_SLASHER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class1.stItem_CLASS1_Weapon01[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class1.stItem_CLASS1_Helmet01[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class1.stItem_CLASS1_Armor01[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class1.stItem_CLASS1_Gloves01[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class1.stItem_CLASS1_Shoes01[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class1.stItem_CLASS1_Avatar01[item.Tid].STACK;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_RANGER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class2.stItem_CLASS2_Weapon02[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class2.stItem_CLASS2_Helmet02[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class2.stItem_CLASS2_Armor02[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class2.stItem_CLASS2_Gloves02[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class2.stItem_CLASS2_Shoes02[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class2.stItem_CLASS2_Avatar02[item.Tid].STACK;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_FIGHTER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class3.stItem_CLASS3_Weapon03[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class3.stItem_CLASS3_Helmet03[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class3.stItem_CLASS3_Armor03[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class3.stItem_CLASS3_Gloves03[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class3.stItem_CLASS3_Shoes03[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class3.stItem_CLASS3_Avatar03[item.Tid].STACK;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_MAGICIAN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class4.stItem_CLASS4_Weapon04[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class4.stItem_CLASS4_Helmet04[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class4.stItem_CLASS4_Armor04[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class4.stItem_CLASS4_Gloves04[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class4.stItem_CLASS4_Shoes04[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class4.stItem_CLASS4_Avatar04[item.Tid].STACK;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_ASSASSIN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class5.stItem_CLASS5_Weapon05[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class5.stItem_CLASS5_Helmet05[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class5.stItem_CLASS5_Armor05[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class5.stItem_CLASS5_Gloves05[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class5.stItem_CLASS5_Shoes05[item.Tid].STACK;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class5.stItem_CLASS5_Avatar05[item.Tid].STACK;
                }
            }

            Console.WriteLine("Error: GetItemType() - Unknown class type: {0}, sub type {1}", item.ClassType, item.SubType);
            return 0;
        }

        public static int GetIconIndex(Item item) {
            switch ((EnumClassItemTableType)item.SubType) {
                case EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                    return item_common.stItem_Common_Common_NECKLACE[item.Tid].ICON;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
            		return item_common.stItem_Common_Commonitem_CLOAK[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_RING:
            		return item_common.stItem_Common_Commonitem_RING[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARM:
            		return item_common.stItem_Common_Commonitem_CHARM[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_TITLE:
            		return item_common.stItem_Common_Commonitem_TITLE[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARGE:
            		return item_common.stItem_Common_Commonitem_CHARGE[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_QUEST:
            		return item_common.stItem_Common_Commonitem_QUEST[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_ETC:
            		return item_common.stItem_Common_Commonitem_ETC[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_VEHICLE:
            		return item_common.stItem_Common_Commonitem_VEHICLE[item.Tid].ICON;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_BATTLE_PET :
            		return item_common.stItem_Common_Commonitem_PET[item.Tid].ICON;
            }

            if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_SLASHER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class1.stItem_CLASS1_Weapon01[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class1.stItem_CLASS1_Helmet01[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class1.stItem_CLASS1_Armor01[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class1.stItem_CLASS1_Gloves01[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class1.stItem_CLASS1_Shoes01[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class1.stItem_CLASS1_Avatar01[item.Tid].ICON;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_RANGER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class2.stItem_CLASS2_Weapon02[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class2.stItem_CLASS2_Helmet02[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class2.stItem_CLASS2_Armor02[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class2.stItem_CLASS2_Gloves02[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class2.stItem_CLASS2_Shoes02[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class2.stItem_CLASS2_Avatar02[item.Tid].ICON;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_FIGHTER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class3.stItem_CLASS3_Weapon03[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class3.stItem_CLASS3_Helmet03[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class3.stItem_CLASS3_Armor03[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class3.stItem_CLASS3_Gloves03[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class3.stItem_CLASS3_Shoes03[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class3.stItem_CLASS3_Avatar03[item.Tid].ICON;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_MAGICIAN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class4.stItem_CLASS4_Weapon04[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class4.stItem_CLASS4_Helmet04[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class4.stItem_CLASS4_Armor04[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class4.stItem_CLASS4_Gloves04[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class4.stItem_CLASS4_Shoes04[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class4.stItem_CLASS4_Avatar04[item.Tid].ICON;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_ASSASSIN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class5.stItem_CLASS5_Weapon05[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class5.stItem_CLASS5_Helmet05[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class5.stItem_CLASS5_Armor05[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class5.stItem_CLASS5_Gloves05[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class5.stItem_CLASS5_Shoes05[item.Tid].ICON;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class5.stItem_CLASS5_Avatar05[item.Tid].ICON;
                }
            }

            Console.WriteLine("Error: GetIconIndex() - Unknown class type: {0}, sub type {1}", item.ClassType, item.SubType);
            return 0;
        }

        public static void SetItemEffect(Item item) {
            switch((EnumClassItemTableType)item.SubType) {
                case EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                    item.SetEffType(0, item_common.stItem_Common_Common_NECKLACE[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Common_NECKLACE[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Common_NECKLACE[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_CLOAK[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_CLOAK[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_CLOAK[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_RING:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_RING[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_RING[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_RING[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARM:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_CHARM[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_CHARM[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_CHARM[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_TITLE:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_TITLE[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_TITLE[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_TITLE[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARGE:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_CHARGE[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_CHARGE[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_CHARGE[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_QUEST:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_QUEST[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_QUEST[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_QUEST[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_ETC:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_ETC[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_ETC[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_ETC[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_VEHICLE:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_VEHICLE[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_VEHICLE[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_VEHICLE[item.Tid].EFF_POS);
                    return;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_BATTLE_PET:
                    item.SetEffType(0, item_common.stItem_Common_Commonitem_PET[item.Tid].EFFECT);
                    item.SetEffValue(0, item_common.stItem_Common_Commonitem_PET[item.Tid].EFF_VALUE);
                    item.SetEffPos(0, item_common.stItem_Common_Commonitem_PET[item.Tid].EFF_POS);
                    return;
            }

            if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_SLASHER) {
                switch ((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        item.SetEffType(0, item_class1.stItem_CLASS1_Weapon01[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class1.stItem_CLASS1_Weapon01[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class1.stItem_CLASS1_Weapon01[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        item.SetEffType(0, item_class1.stItem_CLASS1_Helmet01[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class1.stItem_CLASS1_Helmet01[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class1.stItem_CLASS1_Helmet01[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        item.SetEffType(0, item_class1.stItem_CLASS1_Armor01[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class1.stItem_CLASS1_Armor01[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class1.stItem_CLASS1_Armor01[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        item.SetEffType(0, item_class1.stItem_CLASS1_Gloves01[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class1.stItem_CLASS1_Gloves01[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class1.stItem_CLASS1_Gloves01[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        item.SetEffType(0, item_class1.stItem_CLASS1_Shoes01[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class1.stItem_CLASS1_Shoes01[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class1.stItem_CLASS1_Shoes01[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        item.SetEffType(0, item_class1.stItem_CLASS1_Avatar01[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class1.stItem_CLASS1_Avatar01[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class1.stItem_CLASS1_Avatar01[item.Tid].EFF_POS);
                        return;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_RANGER) {
                switch ((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        item.SetEffType(0, item_class2.stItem_CLASS2_Weapon02[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class2.stItem_CLASS2_Weapon02[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class2.stItem_CLASS2_Weapon02[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        item.SetEffType(0, item_class2.stItem_CLASS2_Helmet02[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class2.stItem_CLASS2_Helmet02[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class2.stItem_CLASS2_Helmet02[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        item.SetEffType(0, item_class2.stItem_CLASS2_Armor02[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class2.stItem_CLASS2_Armor02[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class2.stItem_CLASS2_Armor02[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        item.SetEffType(0, item_class2.stItem_CLASS2_Gloves02[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class2.stItem_CLASS2_Gloves02[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class2.stItem_CLASS2_Gloves02[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        item.SetEffType(0, item_class2.stItem_CLASS2_Shoes02[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class2.stItem_CLASS2_Shoes02[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class2.stItem_CLASS2_Shoes02[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        item.SetEffType(0, item_class2.stItem_CLASS2_Avatar02[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class2.stItem_CLASS2_Avatar02[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class2.stItem_CLASS2_Avatar02[item.Tid].EFF_POS);
                        return;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_FIGHTER) {
                switch ((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        item.SetEffType(0, item_class3.stItem_CLASS3_Weapon03[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class3.stItem_CLASS3_Weapon03[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class3.stItem_CLASS3_Weapon03[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        item.SetEffType(0, item_class3.stItem_CLASS3_Helmet03[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class3.stItem_CLASS3_Helmet03[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class3.stItem_CLASS3_Helmet03[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        item.SetEffType(0, item_class3.stItem_CLASS3_Armor03[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class3.stItem_CLASS3_Armor03[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class3.stItem_CLASS3_Armor03[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        item.SetEffType(0, item_class3.stItem_CLASS3_Gloves03[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class3.stItem_CLASS3_Gloves03[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class3.stItem_CLASS3_Gloves03[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        item.SetEffType(0, item_class3.stItem_CLASS3_Shoes03[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class3.stItem_CLASS3_Shoes03[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class3.stItem_CLASS3_Shoes03[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        item.SetEffType(0, item_class3.stItem_CLASS3_Avatar03[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class3.stItem_CLASS3_Avatar03[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class3.stItem_CLASS3_Avatar03[item.Tid].EFF_POS);
                        return;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_MAGICIAN) {
                switch ((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        item.SetEffType(0, item_class4.stItem_CLASS4_Weapon04[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class4.stItem_CLASS4_Weapon04[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class4.stItem_CLASS4_Weapon04[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        item.SetEffType(0, item_class4.stItem_CLASS4_Helmet04[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class4.stItem_CLASS4_Helmet04[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class4.stItem_CLASS4_Helmet04[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        item.SetEffType(0, item_class4.stItem_CLASS4_Armor04[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class4.stItem_CLASS4_Armor04[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class4.stItem_CLASS4_Armor04[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        item.SetEffType(0, item_class4.stItem_CLASS4_Gloves04[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class4.stItem_CLASS4_Gloves04[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class4.stItem_CLASS4_Gloves04[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        item.SetEffType(0, item_class4.stItem_CLASS4_Shoes04[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class4.stItem_CLASS4_Shoes04[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class4.stItem_CLASS4_Shoes04[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        item.SetEffType(0, item_class4.stItem_CLASS4_Avatar04[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class4.stItem_CLASS4_Avatar04[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class4.stItem_CLASS4_Avatar04[item.Tid].EFF_POS);
                        return;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_ASSASSIN) {
                switch ((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        item.SetEffType(0, item_class5.stItem_CLASS5_Weapon05[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class5.stItem_CLASS5_Weapon05[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class5.stItem_CLASS5_Weapon05[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        item.SetEffType(0, item_class5.stItem_CLASS5_Helmet05[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class5.stItem_CLASS5_Helmet05[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class5.stItem_CLASS5_Helmet05[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        item.SetEffType(0, item_class5.stItem_CLASS5_Armor05[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class5.stItem_CLASS5_Armor05[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class5.stItem_CLASS5_Armor05[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        item.SetEffType(0, item_class5.stItem_CLASS5_Gloves05[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class5.stItem_CLASS5_Gloves05[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class5.stItem_CLASS5_Gloves05[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        item.SetEffType(0, item_class5.stItem_CLASS5_Shoes05[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class5.stItem_CLASS5_Shoes05[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class5.stItem_CLASS5_Shoes05[item.Tid].EFF_POS);
                        return;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        item.SetEffType(0, item_class5.stItem_CLASS5_Avatar05[item.Tid].EFFECT);
                        item.SetEffValue(0, item_class5.stItem_CLASS5_Avatar05[item.Tid].EFF_VALUE);
                        item.SetEffPos(0, item_class5.stItem_CLASS5_Avatar05[item.Tid].EFF_POS);
                        return;
                }
            }

            Console.WriteLine("Error: ItemEffect.GetItemEffect() - Unknown ClassType: {0} slot index {1}", item.ClassType, item.SubType);
            item.SetEffType(0, -1);
            item.SetEffValue(0, 0);
            item.SetEffPos(0, -1);
        }

        public static int GetItemUsing(Item item) {
            switch ((EnumClassItemTableType)item.SubType) {
                case EnumClassItemTableType.CLASS_ITEM_TABLE_NECKLACE:
                    return item_common.stItem_Common_Common_NECKLACE[item.Tid].USING;
                case EnumClassItemTableType.CLASS_ITEM_TABLE_CLOAK:
            		return item_common.stItem_Common_Commonitem_CLOAK[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_RING:
            		return item_common.stItem_Common_Commonitem_RING[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARM:
            		return item_common.stItem_Common_Commonitem_CHARM[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_TITLE:
            		return item_common.stItem_Common_Commonitem_TITLE[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_CHARGE:
            		return item_common.stItem_Common_Commonitem_CHARGE[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_QUEST:
            		return item_common.stItem_Common_Commonitem_QUEST[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_ETC:
            		return item_common.stItem_Common_Commonitem_ETC[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_VEHICLE:
            		return item_common.stItem_Common_Commonitem_VEHICLE[item.Tid].USING;
            	case EnumClassItemTableType.CLASS_ITEM_TABLE_BATTLE_PET :
            		return item_common.stItem_Common_Commonitem_PET[item.Tid].USING;
            }

            if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_SLASHER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class1.stItem_CLASS1_Weapon01[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class1.stItem_CLASS1_Helmet01[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class1.stItem_CLASS1_Armor01[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class1.stItem_CLASS1_Gloves01[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class1.stItem_CLASS1_Shoes01[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class1.stItem_CLASS1_Avatar01[item.Tid].USING;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_RANGER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class2.stItem_CLASS2_Weapon02[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class2.stItem_CLASS2_Helmet02[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class2.stItem_CLASS2_Armor02[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class2.stItem_CLASS2_Gloves02[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class2.stItem_CLASS2_Shoes02[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class2.stItem_CLASS2_Avatar02[item.Tid].USING;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_FIGHTER) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class3.stItem_CLASS3_Weapon03[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class3.stItem_CLASS3_Helmet03[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class3.stItem_CLASS3_Armor03[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class3.stItem_CLASS3_Gloves03[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class3.stItem_CLASS3_Shoes03[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class3.stItem_CLASS3_Avatar03[item.Tid].USING;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_MAGICIAN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class4.stItem_CLASS4_Weapon04[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class4.stItem_CLASS4_Helmet04[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class4.stItem_CLASS4_Armor04[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class4.stItem_CLASS4_Gloves04[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class4.stItem_CLASS4_Shoes04[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class4.stItem_CLASS4_Avatar04[item.Tid].USING;
                }
            } else if (item.ClassType == (int)EnumCharClass.CLASS_TYPE_ASSASSIN) {
                switch((EnumClassItemTableType)item.SubType) {
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_WEAPON:
                        return item_class5.stItem_CLASS5_Weapon05[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_HELMET:
                        return item_class5.stItem_CLASS5_Helmet05[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_ARMOR:
                        return item_class5.stItem_CLASS5_Armor05[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_GLOVES:
                        return item_class5.stItem_CLASS5_Gloves05[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_SHOES:
                        return item_class5.stItem_CLASS5_Shoes05[item.Tid].USING;
                    case EnumClassItemTableType.CLASS_ITEM_TABLE_AVATAR:
                        return item_class5.stItem_CLASS5_Avatar05[item.Tid].USING;
                }
            }

            Console.WriteLine("Error: GetItemUsing() - Unknown class type: {0}, sub type {1}", item.ClassType, item.SubType);
            return 0;
        }
    }
}