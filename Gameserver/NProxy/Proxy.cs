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
            LocationServer pLocationServer = new LocationServer(user_seq);
            CacheServer mCacheServer = new CacheServer();

            pUser.SetLocationServer(ref pLocationServer);
            pUser.SetCacheServer(ref mCacheServer);
            return true;
        }

        public void RemoveUser(ref User mUser) {
            if (mUser == null) {
                Console.WriteLine("[PROXY] PROXY::RemoveUser User == null");
                return;
            }

            LocationServer mLocationServer = new LocationServer(mUser.GetUserSeq());
            CacheServer mCacheServer = new CacheServer();

            mUser.SetLocationServer(ref mLocationServer);
            mUser.SetCacheServer(ref mCacheServer);

            Final(ref mUser);
        }

        public void RemoveUser(int user_seq) {
            if (!_userTree.HasKey(user_seq)) {
                return;
            }
            _userTree.Remove(user_seq);
        }

        public void Final(ref User pUser) {
            Console.WriteLine("[PROXY] PROXY::Final SOCIALID {0} GID {1}", pUser.GetSocialID(), pUser.GetUserSeq());

            if (!_userTree.HasKey(pUser.GetUserSeq())) {
                return;
            }
            _userTree.Remove(pUser.GetUserSeq());

            //throw new NotImplementedException();
            RemoveUser(ref pUser);
            // RemoveFRUserSyn(pUser);
        }

        public ref User? GetUser(int user_seq) {
            return ref _userTree.Get(user_seq);
        }

        public bool UserInfoSyn(ref User pUser) {
            if (pUser == null) {
                Console.WriteLine("[PROXY] PROXY::UserInfoSyn User == null");
                return false;
            }

            UserInfoSyn msg = new UserInfoSyn();
            msg.seq = (uint)pUser.GetUserSeq();
            CacheServer mCacheServer = pUser.GetCacheServer();
            if (mCacheServer == null) {
                Console.WriteLine("[PROXY] PROXY::UserInfoSyn mCacheServer == null");
                return false;
            }
            mCacheServer.SendMsg(msg);
            return true;
        }

        public bool CharacterInfoSyn(ref User pUser, uint character_seq) {
            if (pUser == null) {
                Console.WriteLine("[PROXY] PROXY::CharacterInfoSyn User == null");
                return false;
            }

            CharacterInfoSyn msg = new CharacterInfoSyn();
            msg.seq = (uint)pUser.GetUserSeq();
            msg.char_seq = character_seq;
            CacheServer mCacheServer = pUser.GetCacheServer();
            if (mCacheServer == null) {
                Console.WriteLine("[PROXY] PROXY::CharacterInfoSyn mCacheServer == null");
                return false;
            }
            mCacheServer.SendMsg(msg);
            return true;
        }

        private ref LocationServer? GetLocationServer(ref User pUser) {
            return ref pUser.GetLocationServer();
        }

        public bool RegistUser(int user_seq) {
            User pUser = GetUser(user_seq);
            if (pUser == null) {
                Console.WriteLine("[PROXY] PROXY::RegistUser::USER_NOT_EXIST");
                return false;
            }
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
            return Database.NoSql.instance.GetNewUserSeq();
        }
    }
}