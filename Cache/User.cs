namespace Cache {
    public class User {
        public struct Character {
            public bool _bOpen;
            public bool _bLoad;
            public UInt32 _char_seq;
            public CharacterInfo _characterInfo;
        }

        private UserInfo? _pUserInfo;
        private int _userSeq;
        public User() {
            _pUserInfo = new UserInfo();
            _userSeq = 0;
        }

        public void Initialize() {
            _userSeq = 0;
            _pUserInfo = new UserInfo();
            _pUserInfo.userseq = 0;

            for (int i = 0; i < 8; i++) {
                _pUserInfo.array_Slot[i] = new slot();
                _pUserInfo.array_Slot[i].open = false;
                _pUserInfo.array_Slot[i].character_seq = 0;
                _pUserInfo.array_Slot[i].makeCharacter = false;
                _pUserInfo.array_Slot[i].remainStatResetCount = 0;
                _pUserInfo.array_Slot[i].classtype = 0;
                _pUserInfo.array_Slot[i].level = 0;
                _pUserInfo.array_Slot[i].reg_date = 0;
            }

            _pUserInfo.main_slot_index = -1;
            _pUserInfo.nickname = "";
            _pUserInfo.profile_url = "";
            _pUserInfo.score = 0;
            _pUserInfo.heart_blocked = 0;
            _pUserInfo.invite_blocked = 0;
            _pUserInfo.profile_opened = 0;
            _pUserInfo.company = 0;
            _pUserInfo.sale_code = 0;
            _pUserInfo.u8intro_state = 0;
            _pUserInfo.wp_last_week = 0;
            _pUserInfo.wp_cur_week = 0;
            _pUserInfo.wp_reg_date = 0;
            _pUserInfo.wp_last_reg_date = 0;
        }

        public ref UserInfo? GetUserInfo() {
            return ref _pUserInfo;
        }

        public void SetUserInfo(ref UserInfo userInfo) {
            _pUserInfo = userInfo;
        }

        public void SetUserSeq(int userSeq) {
            _userSeq = userSeq;
        }

        public int GetUserSeq() {
            return _userSeq;
        }
    }
}