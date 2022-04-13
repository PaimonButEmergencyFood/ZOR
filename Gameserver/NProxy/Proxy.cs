using Cache;
using Location;
using iFriends;

namespace ProjectZ.NProxy {
    public class Proxy : NUtil.Single<Proxy> {
        private RefTree<User> _userTree;
        private RefTree<LocationServer> _locationTree;

        public Proxy() {
            _userTree = new RefTree<User>();
            _locationTree = new RefTree<LocationServer>();
        }

        public bool Initial(ref User pUser, int user_seq) {
            if (_userTree.HasKey(user_seq)) {
                Console.WriteLine("[PROXY] PROXY::Initial::USER_EXIST");
                return false;
            }
            _userTree.Add(user_seq, ref pUser);
            return true;
        }

        public void Final(ref User pUser) {
            Console.WriteLine("[PROXY] PROXY::Final SOCIALID {0} GID {1}", pUser.GetSocialID(), pUser.GetUserSeq());

            if (!_userTree.HasKey(pUser.GetUserSeq())) {
                return;
            }
            _userTree.Remove(pUser.GetUserSeq());

            throw new NotImplementedException();
            // RemoveUser(pUser);
            // RemoveFRUserSyn(pUser);
        }

        public ref User? GetUser(int user_seq) {
            return ref _userTree.Get(user_seq);
        }

        private ref LocationServer GetLocationServer(ref User pUser) {
            try {
                if (_locationTree.HasKey(pUser.GetUserSeq())) {
                    Console.WriteLine("[PROXY] PROXY::GetLocationServer::LOCATION_EXIST");
                    return ref _locationTree.Get(pUser.GetUserSeq());
                } 
            } catch (Exception e) {
                LocationServer pLocationServer = new LocationServer();
                _locationTree.Add(pUser.GetUserSeq(), ref pLocationServer);
                Console.WriteLine("[PROXY] PROXY::GetLocationServer::LOCATION_SERVER_CREATED");
                return ref _locationTree.Get(pUser.GetUserSeq());
            }
            Console.WriteLine("[PROXY] PROXY::GetLocationServer::LOCATION_SERVER_CREATED -> after try");
            LocationServer mpLocationServer = new LocationServer();
             _locationTree.Add(pUser.GetUserSeq(), ref mpLocationServer);
            return ref _locationTree.Get(pUser.GetUserSeq());
        }

        public bool RegistUser(ref User pUser) {
            LocationServer pLocationServer = GetLocationServer(ref pUser);

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