using Cache;

namespace Location {
    public class LocationServer {
        private int user_seq;
        private User pUser;
        public LocationServer(int seq) {
            user_seq = seq;
            pUser = new User();
        }

        public async void SendMsg<T> (T msg) {
            await Task.Run(() => {
                OnMsg(msg);
            });
        }

        public async void OnMsg<T> (T msg) {
            await Task.Run(() => {
                if (msg is RegistSyn) {
                    RegistSyn? syn = msg as RegistSyn;
                    if (syn == null) {
                        Console.WriteLine("[LOCATION SERVER] RegistSyn is null");
                        return;
                    }
                    Console.WriteLine("[LOCATION SERVER] RegistSyn {0}", syn.seq);
                    OnRegistSyn(syn);
                    return;
                }
                if (msg is RegistAck) {
                    RegistAck? ack = msg as RegistAck;
                    if (ack == null) {
                        Console.WriteLine("[LOCATION SERVER] RegistAck is null");
                        return;
                    }
                    Console.WriteLine("[LOCATION SERVER] RegistAck {0}", ack.seq);
                    OnRegistAck(ack);
                    return;
                }
                Console.WriteLine("[LOCATION SERVER] Unknown msg type "  + msg.GetType());
            });
        }

        private void SendRegistAck(UInt32 seq, LocationResult result, string msg) {
            RegistAck ack = new RegistAck();
            ack.seq = seq;
            ack.result = result;
            ack.strError = msg;
            SendMsg(ack);
        }

        private void SendUnRegistAck(UInt32 seq, LocationResult result, string msg) {
            UnRegistAck ack = new UnRegistAck();
            ack.seq = seq;
            ack.result = result;
            ack.strError = msg;
            SendMsg(ack);
        }

        private void SendChatAck(UInt32 sender_seq, LocationResult result, UInt32 receiver_seq) {
            ChatAck ack = new ChatAck();
            ack.sender_seq = sender_seq;
            ack.result = result;
            ack.receiver_seq = receiver_seq;
            SendMsg(ack);
        }

        private void SendKick(UInt32 kickUserSeq) {
            KickUser kick = new KickUser();
            kick.seq = kickUserSeq;
            SendMsg(kick);
        }

        private void SendRecallAck(UInt32 sender_seq, LocationResult result, UInt32 receiver_seq) {
            RecallAck ack = new RecallAck();
            ack.sender_seq = sender_seq;
            ack.result = result;
            ack.receiver_seq = receiver_seq;
            SendMsg(ack);
        }

        private void SendSetMainCharacterInfoAck(UInt32 seq, Int16 result) {
            SetMainCharacterInfoAck ack = new SetMainCharacterInfoAck();
            ack.seq = seq;
            ack.result = result;
            SendMsg(ack);
        }

        private void SendGetMainCharacterInfoAck(UInt32 seq, Int16 result) {
            GetMainCharacterInfoAck ack = new GetMainCharacterInfoAck();
            ack.seq = seq;
            ack.result = result;
            SendMsg(ack);
        }

        private void OnRegistSyn(RegistSyn syn) {
            Console.WriteLine("[LOCATION] OnRegistSyn seq ]{0} regist success", syn.seq);
            pUser = new User();
            pUser.SetSeq((int)syn.seq);
            SendRegistAck((uint)syn.seq, LocationResult.LOCATION_SUCCESS, "User Regist Success");
        }

        private void OnRegistAck(RegistAck ans) {
            ProjectZ.User? mUser  = ProjectZ.NProxy.Proxy.instance.GetUser((int)ans.seq);
            if (mUser == null) {
                Console.WriteLine("LOCATION OnRegistAck] mUser == nulll");
                return;
            }
            CacheServer? mCacheServer = mUser.GetCacheServer();
            if (mCacheServer == null) {
                Console.WriteLine("LOCATION OnRegistAck] mCacheServer == null");
                return;
            }

            if (ans.result == LocationResult.LOCATION_FAIL) {
                Console.WriteLine("[LOCATION OnRegistAck] ACK_EXIST_USER");

                ProjectZ.NetworkPacket rsp = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_REQ_LOGIN);
                rsp.U2((short)ProjectZ.NetACKTypes.ACK_EXIST_USER);
                rsp.U4(0);

                ProjectZ.Session? session = mUser.GetSession();
                if (session == null) {
                    Console.WriteLine("LOCATION OnRegistAck] session == null");
                    return;
                }

                session.SendPacketAsync(rsp);

                mUser.SetState(ProjectZ.NState.Static.instance.TITLE());
                ProjectZ.NProxy.Proxy.instance.RemoveUser((int)ans.seq);
                return;
            }

            Console.WriteLine("[LOCATION OnRegistAck] ACK_REGIST_SUCCESS");
            ProjectZ.NProxy.Proxy.instance.UserInfoSyn(ref mUser);
            mUser.SetLocationRegist();
        }

        private void OnUnRegistSyn(UnRegistSyn syn) {
            //SendUnRegistAck((uint)_mUser.GetSeq(), LocationResult.LOCATION_SUCCESS, "User UnRegist Success");
        }

        private void OnUnRegistAck(UnRegistAck ans) {
            if (ans.result == LocationResult.LOCATION_FAIL) {
                Console.WriteLine("[LOCATION OnUnRegistAck ] UnRegist Fail");
            }

        ProjectZ.User _user = ProjectZ.NProxy.Proxy.instance.GetUser((int)ans.seq);
        }
    }
}