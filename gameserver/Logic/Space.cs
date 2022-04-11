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

        public delegate Dictionary<Int32, User> USERTREE();
        public delegate Dictionary<int, Monster> MONSTERTREE();
        public delegate Dictionary<Int32, bool> INVITETREE();
        public delegate Dictionary<int, Item> ITEMTREE();
        public delegate List<UInt32> RESERVEVECTOR();
        public delegate List<User> PKOUTPLAYUSERVECTOR();
        public delegate Dictionary<int, Battle> BATTLETREE();

        private USERTREE _userTree;
        private User? master;
        private MONSTERTREE _monsterTree;
        private MONSTERTREE _deadMonsterTree;
        private INVITETREE _inviteTree;
        private ITEMTREE _itemTree;
        private PKOUTPLAYUSERVECTOR _pkOutPlayUser;
        private RESERVEVECTOR _reserveVector;
        private BATTLETREE _battleTree;

        public Space() {

            _userTree = new USERTREE(() => new Dictionary<Int32, User>());
            _monsterTree = new MONSTERTREE(() => new Dictionary<int, Monster>());
            _deadMonsterTree = new MONSTERTREE(() => new Dictionary<int, Monster>());
            _inviteTree = new INVITETREE(() => new Dictionary<int, bool>());
            _itemTree = new ITEMTREE(() => new Dictionary<int, Item>());
            _pkOutPlayUser = new PKOUTPLAYUSERVECTOR(() => new List<User>());
            _reserveVector = new RESERVEVECTOR(() => new List<UInt32>());
            _battleTree = new BATTLETREE(() => new Dictionary<int, Battle>());

            master = null;
        }

        public void LeaveUser(User user) {
            foreach (var muser in _userTree()) {
                if (muser.Value.GetUserId() == user.GetUserId()) {
                    _userTree().Remove(muser.Key);
                    break;
                }
            }
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