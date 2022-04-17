using iFriends;

namespace ProjectZ.NCommand.NFriends {
    public class CS_SOCIAL_MYINFO
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);

            SocialMyInfoSyn msg = new SocialMyInfoSyn();

            msg.socialid = Convert.ToUInt64(_user.GetSocialID());
            msg.nickname = _user.GetUserInfo().nickname;
            msg.profile_url = _user.GetUserInfo().profile_url;
            msg.seq = (uint)_user.GetUserSeq();

            NProxy.Proxy.instance.SendFriendsServer(_user.GetUserSeq(), msg);
        }
    }
}