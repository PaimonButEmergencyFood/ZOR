using iFriends;

namespace ProjectZ.NCommand.NFriends {
    public class CS_UPDATE_MY_PROFILE {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);

            UpdateProfileSyn msg = new UpdateProfileSyn();

            msg.gender = req.U1();
            msg.is_gender_open = req.U1();
            msg.birthday = req.Get(req.U2());
            msg.is_birthday_open = req.U1();
            msg.is_profile_open = req.U1();
            msg.seq = (uint)_user.GetUserSeq();

            Console.WriteLine("Birthday " + msg.birthday);

            NProxy.Proxy.instance.SendFriendsServer(_user.GetUserSeq(), msg);
        }
    }
}