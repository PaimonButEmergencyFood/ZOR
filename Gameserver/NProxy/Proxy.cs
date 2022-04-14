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
            try {
                if (_userTree.HasKey(user_seq) || _userTree.Get(user_seq) != null) {
                    Console.WriteLine("[PROXY] PROXY::Initial::USER_EXIST");
                    return false;
                }
            } catch (KeyNotFoundException) {
                Console.WriteLine("[PROXY] PROXY::Initial::USER_NOT_EXIST");
            }
            _userTree.Add(user_seq, ref pUser);
            LocationServer? pLocationServer = new LocationServer();
            if (pLocationServer == null) {
                Console.WriteLine("[PROXY] PROXY::Initial::LOCATION_SERVER_NULL");
                return false;
            }
            pUser.SetLocationServer(ref pLocationServer);
            return true;
        }

        public void Final(ref User pUser) {
            Console.WriteLine("[PROXY] PROXY::Final SOCIALID {0} GID {1}", pUser.GetSocialID(), pUser.GetUserSeq());

            if (!_userTree.HasKey(pUser.GetUserSeq())) {
                return;
            }
            _userTree.Remove(pUser.GetUserSeq());

            //throw new NotImplementedException();
            // RemoveUser(pUser);
            // RemoveFRUserSyn(pUser);
        }

        public ref User? GetUser(int user_seq) {
            return ref _userTree.Get(user_seq);
        }

        private ref LocationServer? GetLocationServer(ref User pUser) {
            return ref pUser.GetLocationServer();
        }

        public bool RegistUser(ref User pUser) {
            LocationServer? pLocationServer = GetLocationServer(ref pUser);

            if (pLocationServer == null) {
                Console.WriteLine("[PROXY] PROXY::RegistUser::LOCATION_SERVER_NULL");
                return false;
            }

            RegistSyn msg = new RegistSyn();
            msg.seq = (uint)pUser.GetUserSeq();

            pLocationServer.SendMsg(msg);
            return true;
        }

        public int GetNewUserSeq() {
            return _userTree.Count;
        }
    }
}