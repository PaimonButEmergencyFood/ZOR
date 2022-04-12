using Cache;
using Location;
using iFriends;

namespace ProjectZ.NProxy {
    public class Proxy : NUtil.Single<Proxy> {
        private LocationServer _locationServer;
        public Proxy() {
            _locationServer = new LocationServer();
        }
        public bool RegistUser(ref User _user) {
            RegistSyn msg = new RegistSyn();
            msg.seq = (uint)_user.GetUserSeq();

            _locationServer.OnRegistSyn(ref _user, msg);

            Console.WriteLine("[PROXY] RegistUser Seq : " + msg.seq);
            return true;
        }

        public bool UserInfoSyn(ref User _user) {
            throw new NotImplementedException();
            return true;
        }
    }
}