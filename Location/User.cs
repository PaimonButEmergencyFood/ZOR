namespace Location {
    public class User {
        public struct MainCharacterInfo {
            public int _level;
            public int _class;
            public int _head;
            public int _armor;
            public int _weapon;
            public int _sideHand;
            public int _effect;
            public int _petTid;

            public MainCharacterInfo() {
                _level = 0;
                _class = 0;
                _head = 0;
                _armor = 0;
                _weapon = 0;
                _sideHand = 0;
                _effect = 0;
                _petTid = 0;
            }
        }

        private int _seq;

        private MainCharacterInfo _pMainCharacterInfo;

        public User() {
            _pMainCharacterInfo = new MainCharacterInfo();
        }

        public MainCharacterInfo GetMainCharacterInfo() {
            return _pMainCharacterInfo;
        }

        public void SetSeq(int seq) {
            _seq = seq;
        }
        public int GetSeq() {
            return _seq;
        }
    }
}