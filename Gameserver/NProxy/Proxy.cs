using Cache;
using Location;
using iFriends;

namespace ProjectZ.NProxy {
    public class Proxy : NUtil.Single<Proxy> {
        private RefTree<User> _userTree;

        public Proxy() {
            _userTree = new RefTree<User>();
        }

        public bool Initial(ref User pUser, int user_seq) {
            if (pUser.GetUserSeq() == 0) {
                Console.WriteLine("Invalid user_seq: {0}", user_seq);
                return false;
            }
            if (_userTree.HasKey(user_seq)) {
                pUser = _userTree.Get(user_seq);
                return true;
            }
            _userTree.Add(user_seq, ref pUser);
            return false;
        }

        public void Final(ref User pUser) {
            Console.WriteLine("[PROXY] PROXY::Final SOCIALID {0} GID {1}", pUser.GetSocialID(), pUser.GetUserSeq());

            if (!_userTree.HasKey(pUser.GetUserSeq())) {
                return;
            }
            _userTree.Remove(pUser.GetUserSeq());

            // RemoveUser(pUser);
            // RemoveFRUserSyn(pUser);
        }

        public ref User? GetUser(int user_seq) {
            return ref _userTree.Get(user_seq);
        }

        public bool RegistUser(ref User pUser) {
            _userTree.Add(pUser.GetUserSeq(), ref pUser);
            return true;
        }

        public int GetNewUserSeq() {
            return _userTree.Count;
        }
    }
}