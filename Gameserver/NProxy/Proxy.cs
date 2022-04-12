using Cache;
using Location;
using iFriends;

namespace ProjectZ.NProxy {
    public class Proxy {
        public static bool RegistUser(ref User _user) {
            RegistSyn msg = new RegistSyn();
            msg.seq = (uint)_user.GetUserSeq();


            Console.WriteLine("[PROXY] RegistUser Seq : " + msg.seq);
            return true;
        }

        public bool UserInfoSyn(ref User _user) {
            throw new NotImplementedException();
            return true;
        }
    }
}