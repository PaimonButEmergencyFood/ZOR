using Cache;
using Location;
using iFriends;

namespace ProjectZ.NProxy {
    public class Proxy : NUtil.Single<Proxy> {
        LocationServer[] _locationServer;
        CacheServer[] _cacheServer;
        User[] _userTree;
        public Proxy() {
            uint max_user = 10;
            _locationServer = new LocationServer[max_user]; // number of LocationServer
            _cacheServer = new CacheServer[max_user]; // number of CacheServer
            _userTree = new User[max_user]; // number of users
            // TODO load all saved locations
        }

        public ref LocationServer? GetLocationServer(int user_seq) {
            if (_locationServer.Length > user_seq) {
                if (_locationServer[user_seq] == null) {
                    _locationServer[user_seq] = new LocationServer();
                    _locationServer[user_seq].SetSeq(user_seq);
                }
                return ref _locationServer[user_seq];
            }
            if (_locationServer.Length <= user_seq) {
                throw new Exception("[PROXY] LocationServer malformed -> user_seq out of range");
            }
            Console.WriteLine("[PROXY] Registering new LocationServer, SEQ: " + user_seq);
            _locationServer[user_seq] = new LocationServer();
            _locationServer[user_seq].SetSeq(user_seq);
            return ref _locationServer[user_seq];
        }

        public ref LocationServer? GetLocationServer(User pUser) {
            if (pUser == null) {
                throw new System.Exception("[PROXY] User is null");
            }
            LocationServer? pLocationServer = GetLocationServer(pUser.GetUserSeq());
            if (pLocationServer == null) {
                throw new System.Exception("[PROXY] LocationServer is null");
            }
            pLocationServer.SetUser(pUser);
            return ref GetLocationServer(pUser.GetUserSeq());
        }

        public void RemoveUser(ref User pUser) {
            if (pUser == null) {
                throw new System.Exception("[PROXY] User is null");
            }
            if (_locationServer.Length > pUser.GetUserSeq()) {
                if (_locationServer[pUser.GetUserSeq()] != null) {
                    _locationServer[pUser.GetUserSeq()] = new LocationServer();
                }
            }
        }

        public bool Initial(ref User _user, int user_seq) {
            return true;
        }

        public bool RegistUser(ref User _user) {
            LocationServer? pLocationServer = GetLocationServer(_user);
            if (pLocationServer == null) {
                Console.WriteLine("[PROXY LOCATION] no locationserver, pLocationServer is null");
                return false;
            }

            Console.WriteLine("[PROXY LOCATION] RegistUser, SEQ: " + pLocationServer.GetSeq());

            RegistSyn msg = new RegistSyn();
            msg.seq = (uint)_user.GetUserSeq();
            pLocationServer.SendMsg(msg);
            Console.WriteLine("[PROXY RegistUser] success, SEQ: " + _user.GetUserSeq());
            return true;
        }

        public bool UserInfoSyn(ref User _user) {
            throw new NotImplementedException();
            return true;
        }
    }
}