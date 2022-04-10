namespace ProjectZ.NResource {
    class Static : NUtil.Single<Static> {
        public enum E_TYPE {
            _MIN_ = 1,
            STRINGMATCH,
            QUEST,
            DUNGEON,
            BALANCE,
            VALID,
            COMMON,
            WEEKLY_REWARD,
            FRIEND_REWARD,
            SOCIAL_REWARD,
            FRIENDSHIP_BOX,
            POINT_BUFF,
            DAILY_REWARD,
            PET_REWARD,
            EVENT_TIME,
            ITEM_REFINE,
            ITEM,
            MATCHING,
            MESSAGE,
            DUNGEON_EVENT,
            AI_VARIATION,
            VC_REF,
            PRODUCT,
            CHARGE_ITEM,
            FAIRY,
            BATTLE_PET,
            BATTLE_PET_GACHYA,
            DUNGEON_REWARD,
            PVP_REWARD,
            POINT_RESOURCE,
            ITEM_EVOLUTION,
            DUMMY_USER,
            CIRCLE,
            AVATAR_ABLITY,
            LEVELUP_REWARD,
            MAIL_MESSAGE,
            VERSION_RESOURCE,
            WEATHER_RESOURCE,
            EXCEPTION_MESSAGE,
            ALLOW_USER_RESOURCE,
            CONNECT_EVENT,
            WORLDBOSS,
            WORLDBOSSREWARD,
            BUFF_TIME,
            DLC,
            BATTLE_MATCHING,
            STAMINA_RESOURCE,
            MAX_GAIN_GOLD_RESOURCE,
            MONSTER_RESOURCE,
            ULTIMATE_EVOLUTION_RESOURCE,
            ULTIMATE_EVOLUTION_RATE_RESOURCE,
            FAIRY_REBIRTH_QUALITY_RESOURCE,
            DUNGEONENTERLIMITLEVEL,
            PACKAGE_ITEM_RESOURCE,
            UPSTONE_GACHYA_RESOURCE,
            ITEM_ROUTING_TYPE_RESOURCE,
            ITEM_ROUTING_VALUE_RESOURCE,
            ITEM_ROUTING_RATE_RESOURCE,
            UPSTONE_COMBINE_RESOURCE,
            MONTH_CHARGING_EVENT_RESOURCE,
            VIP_RESOURCE,
            LEVELUP_EXP_RESOURCE,
            CONTENTSOPENRESOURCE,

            _ALL_,
            _MAX_
        };

        public bool LoadResource(E_TYPE eType) {
            bool bResult = true;

            switch(eType) {
                case E_TYPE._ALL_:
                    if (_itemResource.LoadResource() == false) {
                        throw new Exception("_itemResource->LoadResource() failed");
                        bResult = false;
                    }
                    if (_balanceResource.LoadResource() == false) {
                        throw new Exception("_balanceResource->LoadResource() failed");
                        bResult = false;
                    }
                    break;
                case E_TYPE.ITEM:
                    if (_itemResource.LoadResource() == false) {
                        throw new Exception("_itemResource->LoadResource() failed");
                        bResult = false;
                    }
                    break;
                case E_TYPE.BALANCE:
                    if (_balanceResource.LoadResource() == false) {
                        throw new Exception("_balanceResource->LoadResource() failed");
                        bResult = false;
                    }
                    break;
                default:
                    bResult = false;
                    break;
            }
            return bResult;
        }

        public ItemResource? GetItemResource() { return _itemResource; }
        public BalanceResource? GetBalanceResource() { return _balanceResource; }

        private ItemResource? _itemResource;
        private BalanceResource? _balanceResource;

        public Static() {
            _itemResource = new ItemResource();
            _balanceResource = new BalanceResource();
        }
    }
}