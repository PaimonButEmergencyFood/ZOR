using LiteDB;
using Cache;
using Location;
using iFriends;

namespace Database {
    public class NoSql {
        private LiteDatabase _db = new LiteDatabase(Directory.GetCurrentDirectory() + "/database.db");

        public NoSql() {
            // Create all collections
            _db.GetCollection<Cache.CharacterInfo>("characterinfo");
            _db.GetCollection<Cache.UserInfo>("userinfo");
        }

        public bool CreateUser(Cache.UserInfo userInfo) {
            if (GetUser((int)userInfo.userseq) != null) {
                return false;
            }
            _db.GetCollection<Cache.UserInfo>("userinfo").Insert(userInfo);
            return true;
        }

        public bool CreateCharacter(Cache.CharacterInfo characterInfo) {
            if (GetCharacter((int)characterInfo.userSeq, (int)characterInfo.characterseq) == null) {
                _db.GetCollection<Cache.CharacterInfo>("characterinfo").Insert(characterInfo);
                return true;
            }
            return false;
        }

        public Cache.UserInfo? GetUser(int userSeq) {
            return _db.GetCollection<Cache.UserInfo>("userinfo").FindOne(x => x.userseq == userSeq);
        }

        public Cache.CharacterInfo? GetCharacter(int userSeq, int characterSeq) {
            return _db.GetCollection<Cache.CharacterInfo>("characterinfo").FindOne(x => x.userSeq == userSeq && x.characterseq == characterSeq);
        }

        public bool UpdateUser(Cache.UserInfo userInfo) {
            return _db.GetCollection<Cache.UserInfo>("userinfo").Update(userInfo);
        }

        public bool UpdateCharacter(Cache.CharacterInfo characterInfo) {
            return _db.GetCollection<Cache.CharacterInfo>("characterinfo").Update(characterInfo);
        }
    }
}