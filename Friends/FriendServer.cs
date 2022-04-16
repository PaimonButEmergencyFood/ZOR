namespace iFriends {
    public class FriendServer {
        User _user;
        public FriendServer() {
            _user = new User();

        }

        public async void SendMsg<T> (T msg) {
            await Task.Run(() => {
                OnMsg(msg);
            });
        }

        public async void OnMsg<T> (T msg) {
            await Task.Run(() => {
                if (msg is SocialMyInfoSyn) {
                    SocialMyInfoSyn? syn = msg as SocialMyInfoSyn;
                    if (syn == null) {
                        Console.WriteLine("[FRIEND SERVER] UserInfoSyn is null");
                        return;
                    }
                    Console.WriteLine("[FRIEND SERVER] UserInfoSyn {0}", syn.seq);
                    OnSocialMyInfoSyn(syn);
                    return;
                }
                Console.WriteLine("[CACHE SERVER] Unknown msg type "  + msg.GetType());
            });
        }

        public void OnSocialMyInfoSyn(SocialMyInfoSyn syn) {
            Console.WriteLine("SEQ : {0}", syn.seq);

            SocialMyInfoAck ack = new SocialMyInfoAck();
            ack.seq = syn.seq;
        }
    }
}