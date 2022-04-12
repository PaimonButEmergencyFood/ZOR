using Cache;
using Location;
using iFriends;

namespace ProjectZ.NProxy {
    public class Proxy : NUtil.Single<Proxy> {
        LocationServer[] _locationServer;
        public Proxy() {
            // TODO load all saved locations
        }

        public ref LocationServer? GetLocationServer(int user_seq) {
            if (_locationServer.Length >= user_seq) {
                return ref _locationServer[user_seq];
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
        public bool RegistUser(ref User _user) {
            LocationServer? pLocationServer = GetLocationServer(_user);
            if (pLocationServer == null) {
                Console.WriteLine("[PROXY LOCATION] no locationserver, pLocationServer is null");
                return false;
            }

            Console.WriteLine("[PROXY LOCATION] RegistUser, SEQ: " + pLocationServer.GetSeq());

            RegistSyn msg = new RegistSyn();
            msg.seq = (uint)_user.GetUserSeq();
            pLocationServer.OnMsg(msg);
            Console.WriteLine("[PROXY RegistUser] success, SEQ: " + _user.GetUserSeq());
            return true;
        }

        public bool UserInfoSyn(ref User _user) {
            throw new NotImplementedException();
            return true;
        }
    }
}