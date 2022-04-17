namespace ProjectZ.NLogic {
    public class SocialInfo {
        public enum EnumInviteState : int  {
            __NONE__ = -1,

            ALL_BLOCK,
            DUNGEON_ON,
            PVP_ON,
            DUNGEON_PVP_ON,
            BATTLE_ROYAL_ON,
            DUNGEON_BATTLE_ROYAL_ON,
            PVP_BATTLE_ROYAL_ON,
            ALL_ON,

            __MAX__
        };

        public struct Data {
            public UInt32 _heart_count;
            public int _heart_blocked;
            public int	_invite_blocked;
            public int	_profile_opened;
            public int	_gender;
            public int	_isGenderOpen;
            public string _birthday;
            public int	_isBirthdayOpen;

            public Data() {
                _heart_count = 0;
                _heart_blocked = 0;
                _invite_blocked = 7;
                _profile_opened = 1;
                _gender = 0;
                _isGenderOpen = 1;
                _birthday = "";
                _isBirthdayOpen = 1;
            }

            public void Clear() {
                _heart_count = 0;
                _heart_blocked = 0;
                _invite_blocked = 7;
                _profile_opened = 1;
                _gender = 0;
                _isGenderOpen = 1;
                _birthday = "";
                _isBirthdayOpen = 1;
            }
        }

        private Data _data;

        public ref Data GetData() {
            return ref _data;
        }
        public SocialInfo() {
            _data = new Data();
        }
    }
}