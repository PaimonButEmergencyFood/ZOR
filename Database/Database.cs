using LiteDB;
using Cache;
using Location;
using iFriends;

namespace Database {
    public class NoSql : ProjectZ.NUtil.Single<NoSql> {
        private LiteDatabase _db = new LiteDatabase(Directory.GetCurrentDirectory() + "/database.db");

        public NoSql() {
            // Create all collections
            _db.GetCollection<CharacterInfo>("characterinfo");
            _db.GetCollection<UserInfo>("userinfo");
        }

        public bool CreateUser(Cache.UserInfo userInfo) {
            if (GetUser((int)userInfo.userseq) != null) {
                return false;
            }
            _db.GetCollection<UserInfo>("userinfo").Insert(UserInfo.FromUserInfo(userInfo));
            return true;
        }

        public bool CreateCharacter(Cache.CharacterInfo characterInfo) {
            if (GetCharacter((int)characterInfo.userSeq, (int)characterInfo.characterseq) == null) {
                _db.GetCollection<CharacterInfo>("characterinfo").Insert(CharacterInfo.FromCharacterInfo(characterInfo));
                return true;
            }
            return false;
        }

        public Cache.UserInfo? GetUser(int userSeq) {
            UserInfo? info = _db.GetCollection<UserInfo>("userinfo").FindOne(x => x.userseq == userSeq);
            if (info == null) {
                return null;
            }

            return UserInfo.ToUserInfo(info);
        }

        public int GetUserSeq(string uuid) {
            UserInfo? info = _db.GetCollection<UserInfo>("userinfo").FindOne(x => x.uuid == uuid);
            if (info == null) {
                return -1;
            }
            return (int)info.userseq;
        }

        public Cache.CharacterInfo? GetCharacter(int userSeq, int characterSeq) {
            CharacterInfo? info = _db.GetCollection<CharacterInfo>("characterinfo").FindOne(x => x.userSeq == userSeq && x.characterseq == characterSeq);
            if (info == null) {
                return null;
            }

            return Database.CharacterInfo.ToCharacterInfo(info);
        }

        public bool UpdateUser(Cache.UserInfo userInfo) {
            return _db.GetCollection<UserInfo>("userinfo").Update(UserInfo.FromUserInfo(userInfo));
        }

        public bool UpdateCharacter(Cache.CharacterInfo characterInfo) {
            return _db.GetCollection<CharacterInfo>("characterinfo").Update(CharacterInfo.FromCharacterInfo(characterInfo));
        }
    }
}