namespace iFriends {
    public class  User {
        public struct UserInfo {
            public string nickname;
            public string profile_url;
            public UInt16 gender;
            public string birthday;
            public UInt16 isHeartBlock;
            public UInt16 isProfileBlock;
            public UInt16 isInviteBlock;
            public UInt16 isGenderOpen; // (0:block 1:open)
            public UInt16 isBirthdayOpen; // (0:block 1:open)
            public UInt32 lastLoginTime;
            public UInt32 shard_db_type;

            public UserInfo() {
                nickname = "";
                profile_url = "";
                gender = 0;
                birthday = "";
                isHeartBlock = 0;
                isProfileBlock = 0;
                isInviteBlock = 0;
                isGenderOpen = 0;
                isBirthdayOpen = 0;
                lastLoginTime = 0;
                shard_db_type = 0;
            }

            public void Initialize() {
                nickname = "";
                profile_url = "";
                gender = 0;
                birthday = "";
                isHeartBlock = 0;
                isProfileBlock = 0;
                isInviteBlock = 0;
                isGenderOpen = 0;
                isBirthdayOpen = 0;
                lastLoginTime = 0;
                shard_db_type = 0;
            }
        }

        public struct FriendInfo {
            public UInt64 socialID;
            public UInt16 friendType; 
            public UInt32 heartTime;
            public UInt32 buffTime;
            public UInt32 connectReqTime;
            public UInt32 friendDelTime;
            public UInt32 shard_db_type;

            public FriendInfo() {
                socialID = 0;
                friendType = 0;
                heartTime = 0;
                buffTime = 0;
                connectReqTime = 0;
                friendDelTime = 0;
                shard_db_type = 0;
            }
        }
        public struct Score {
            UInt32 curweek;
            UInt32 lastweek;
            UInt64 reg_date;
            UInt64 last_reg_date;

            public Score() {
                curweek = 0;
                lastweek = 0;
                reg_date = 0;
                last_reg_date = 0;
            }
        }

        private UInt64 _socialId;
        private UInt32 _userSeq;
        private UInt32 _heartCount;
        private UInt32 _newsCount;
        private UInt16 _isRankView;
        private UInt16 isRankReward;
        private UInt64 _rankConfirmTime;
        private UInt32 _inviteCount;
        private UInt64 _bufftime;
        private bool _bKilled;

        private UserInfo _userInfo;

        public void SetSocialId(UInt64 socialId) {
            _socialId = socialId;
        }
        public UInt64 GetSocialId() {
            return _socialId;
        }

        public void SetUserSeq(UInt32 userSeq) {
            _userSeq = userSeq;
        }

        public UInt32 GetUserSeq() {
            return _userSeq;
        }

        public void SetHeartCount(UInt32 heartCount) {
            _heartCount = heartCount;
        }

        public UInt32 GetHeartCount() {
            return _heartCount;
        }

        public void SetNewsCount(UInt32 newsCount) {
            _newsCount = newsCount;
        }

        public UInt32 GetNewsCount() {
            return _newsCount;
        }

        public void SetRankConfirmTime(UInt64 rankConfirmTime) {
            _rankConfirmTime = rankConfirmTime;
        }

        public UInt64 GetRankConfirmTime() {
            return _rankConfirmTime;
        }

        public void SetBuffTime(UInt64 buffTime) {
            _bufftime = buffTime;
        }

        public UInt64 GetBuffTime() {
            return _bufftime;
        }

        public void SetInviteCount(UInt32 inviteCount) {
            _inviteCount = inviteCount;
        }

        public UInt32 GetInviteCount() {
            return _inviteCount;
        }

        public ref UserInfo GetUserInfo() {
            return ref _userInfo;
        }

        public void SetUserInfo(ref UserInfo userInfo) {
            _userInfo = userInfo;
        }

        public void Initialize() {
            _socialId = 0;
            _userSeq = 0;
            _heartCount = 0;
            _newsCount = 0;
            _isRankView = 0;
            isRankReward = 0;
            _rankConfirmTime = 0;
            _inviteCount = 0;
            _bufftime = 0;
            _bKilled = false;

            _userInfo.birthday = "";
            _userInfo.gender = 0;
            _userInfo.isBirthdayOpen = 0;
            _userInfo.isGenderOpen = 0;
            _userInfo.isHeartBlock = 0;
            _userInfo.isInviteBlock = 0;
            _userInfo.isProfileBlock = 0;
            _userInfo.lastLoginTime = 0;
            _userInfo.nickname = "";
            _userInfo.profile_url = "";
        }

        public User() {
            
        }
    }
}