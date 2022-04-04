namespace ProjectZ {
    enum EnumClassItemTableType {

        CLASS_ITEM_TABLE_NONE = -1,

        CLASS_ITEM_TABLE_WEAPON = 0,
        CLASS_ITEM_TABLE_HELMET,
        CLASS_ITEM_TABLE_ARMOR,	
        CLASS_ITEM_TABLE_GLOVES,
        CLASS_ITEM_TABLE_SHOES,
        CLASS_ITEM_TABLE_AVATAR,
        CLASS_ITEM_TABLE_MAX,

        CLASS_ITEM_TABLE_NECKLACE = CLASS_ITEM_TABLE_MAX,
        CLASS_ITEM_TABLE_CLOAK,
        CLASS_ITEM_TABLE_RING,
        CLASS_ITEM_TABLE_CHARM,
        CLASS_ITEM_TABLE_TITLE,
        CLASS_ITEM_TABLE_CHARGE,
        CLASS_ITEM_TABLE_QUEST,
        CLASS_ITEM_TABLE_ETC,
        CLASS_ITEM_TABLE_VEHICLE,
        CLASS_ITEM_TABLE_BATTLE_PET,
        CLASS_ITEM_TABLE_FAIRY,
        CLASS_ALL_ITEM_TABLE_MAX = CLASS_ITEM_TABLE_FAIRY
    };

    enum EnumItemEquipPosition {
        ITEM_EQUIP_POS_NONE = -1,

        ITEM_EQUIP_POS_WEAPON = 0,
        ITEM_EQUIP_POS_HELMET,
        ITEM_EQUIP_POS_ARMOR,
        ITEM_EQUIP_POS_GLOVE,
        ITEM_EQUIP_POS_SHOES,
        ITEM_EQUIP_POS_AVARTAR,

        ITEM_EQUIP_POS_NECKLACE,
        ITEM_EQUIP_POS_CLOAK,
        ITEM_EQUIP_POS_RING,
        ITEM_EQUIP_POS_CHARM,
        ITEM_EQUIP_POS_VEHICLE,
        ITEM_EQUIP_POS_TITLE,
        MAX_ITEM_EQUIP_STAT,
        ITEM_EQUIP_POS_FAIRY = MAX_ITEM_EQUIP_STAT,
        ITEM_EQUIP_POS_PET,
        MAX_ITEM_EQUIP_POS,


        ITEM_SUBTYPE_FAIRY_EGG = MAX_ITEM_EQUIP_POS,
        ITEM_SUBTYPE_PET_EGG,
        ITEM_SUBTYPE_POTION,
        ITEM_SUBTYPE_FOOD,
        ITEM_SUBTYPE_MATERIAL_ITEM,
        ITEM_SUBTYPE_PORTAL,
        ITEM_SUBTYPE_REPAIR,
        ITEM_SUBTYPE_MATERIAL,
        ITEM_SUBTYPE_SALE_MIX_SCROLL,
        ITEM_SUBTYPE_REBIRTH,
        ITEM_SUBTYPE_IDENTIFY,
        ITEM_SUBTYPE_MAX_DURABILITY,
        ITEM_SUBTYPE_UPGRADE_STONE,
        ITEM_SUBTYPE_RETURN_STATPOINT,
        ITEM_SUBTYPE_RETURN_SKILLPOINT,
        ITEM_SUBTYPE_LIGHT,
        ITEM_SUBTYPE_DROPEXP,
        ITEM_SUBTYPE_SPECIAL_POSION,
        ITEM_SUBTYPE_PORTAL_BOTH,
        ITEM_SUBTYPE_RECOVERY_ITEM,
        ITEM_SUBTYPE_MIX_BOOK,
        ITEM_SUBTYPE_KEY,
        ITEM_SUBTYPE_QUEST,
        ITEM_SUBTYPE_COLLECTION_EQUIP,
        ITEM_SUBTYPE_SET_ITEM_BOX,
        ITEM_SUBTYPE_SKILL_JAM,
        ITEM_SUBTYPE_AUTO_ROUTING,
        ITEM_SUBTYPE_BAG,
        ITEM_SUBTYPE_HELP_STONE,
        ITEM_SUBTYPE_GAMBLE_STONE,
        ITEM_SUBTYPE_TREASURE_BOX,
        ITEM_SUBTYPE_PACKAGE,
        ITEM_SUBTYPE_BLACKSMITH_KIT,
        ITEM_SUBTYPE_CHANGE_INTO_ZEN,
        ITEM_SUBTYPE_CHANGE_INTO_GOLD,
        ITEM_SUBTYPE_GOLDEN_UPGRADE_STONE,
        ITEM_SUBTYPE_ADD_BANKSLOT,
        ITEM_SUBTYPE_TICKET,
        ITEM_SUBTYPE_DUE_DATE_TICKET,
        ITEM_SUBTYPE_NO_CONDITION,
        ITEM_SUBTYPE_SETBOX_RED,
        ITEM_SUBTYPE_UPGRADE_REFINE_STEP_MAX,
        ITEM_SUBTYPE_HIGH_QULITY_UPGRADE_STONE,
        ITEM_SUBTYPE_SEAL,
        ITEM_SUBTYPE_UPGRADE,
        ITEM_SUBTYPE_GOLD,
        ITEM_SUBTYPE_EV_POINT,
        ITEM_SUBTYPE_ITEM_GACHYA_TICKET,
        ITEM_EQUIP_POS_NAME_TAG,
        ITEM_EQUIP_POS_NAME_TAG_WORLDBOSS,
    };

    enum EnumCharClass {
        CLASS_TYPE_SLASHER = 0,
        CLASS_TYPE_RANGER,
        CLASS_TYPE_FIGHTER,
        CLASS_TYPE_MAGICIAN,
        CLASS_TYPE_ASSASSIN,
    //	CLASS_TYPE_WIZARD,
        CLASS_TYPE_MAX
    };
}