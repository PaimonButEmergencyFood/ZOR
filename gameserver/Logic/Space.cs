namespace ProjectZ.Logic {
    public class Space {
        public enum SpaceType {
            __NONE__,
            WORLD,
            SINGLE_DUNGEION,
            PARTY_DUNGEION,
            PVP_PRACTICE,
            PVP_USER,
            BATTLEROYAL,

            NEW_PARTY_ROOM,
            NEW_PVP_ROOM,

            WORLDBOSS_SINGLE,
            WORLDBOSS_PARTY,
            WORLDBOSS_PARTY_FRIENDS,
            __MAX__,
        };

        public Dictionary<Int32, User> USERTREE;
        public Dictionary<int, Monster> MONSTERTREE;
        public Dictionary<Int32, bool> INVITETREE;
        public Dictionary<int, Item> ITEMTREE;
        public List<UInt32> RESERVEVECTOR;
        public List<User> PKOUTPLAYUSERVECTOR;
        public Dictionary<int, Battle> BATTLETREE;

        private Dictionary<Int32, User> _userTree;
        private User? master;
        private Dictionary<int, Monster> _monsterTree;
        private Dictionary<int, Monster> _deadMonsterTree;
        private Dictionary<Int32, bool> _inviteTree;
        private Dictionary<int, Item> _itemTree;
        private List<User> _pkOutPlayUser;
        private List<UInt32> _reserveVector;
        private Dictionary<int, Battle> _battleTree;

        public Space() {
            USERTREE = new Dictionary<Int32, User>();
            MONSTERTREE = new Dictionary<int, Monster>();
            INVITETREE = new Dictionary<Int32, bool>();
            ITEMTREE = new Dictionary<int, Item>();
            RESERVEVECTOR = new List<UInt32>();
            PKOUTPLAYUSERVECTOR = new List<User>();
            BATTLETREE = new Dictionary<int, Battle>();

            _userTree = new Dictionary<Int32, User>();
            _monsterTree = new Dictionary<int, Monster>();
            _deadMonsterTree = new Dictionary<int, Monster>();
            _inviteTree = new Dictionary<Int32, bool>();
            _itemTree = new Dictionary<int, Item>();
            _pkOutPlayUser = new List<User>();
            _reserveVector = new List<UInt32>();
            _battleTree = new Dictionary<int, Battle>();

            master = null;
        }

        public void LeaveUser(User user) {
            if (_userTree.FirstOrDefault(x => x.Value == user).Value != null) {
                _userTree.Remove((int)user.Userseq);
            } else {
                Console.WriteLine("[ERROR] LeaveUser: user not found, userseq: " + user.Userseq);
                return;
            }

            user.SetSpace(null);
        }

        public void EnterUser(User user) {
            if (_userTree.FirstOrDefault(x => x.Value == user).Value != null) {
                Console.WriteLine("[ERROR] EnterUser: user already exists, userseq: " + user.Userseq);
                return;
            }

            _userTree.Add((int)user.Userseq, user);
            user.SetSpace(this);
        }
    }
}