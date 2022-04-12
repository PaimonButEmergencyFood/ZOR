namespace Location {
    public class LocationServer {
        private User _mUser;
        private ProjectZ.User _pUser;
        public LocationServer() {
            _mUser = new User();
            _pUser = new ProjectZ.User();
        }

        public LocationServer(User user) {
            _mUser = user;
            _pUser = new ProjectZ.User();
        }

        public void SetUser(ProjectZ.User pUser) {
            _pUser = pUser;
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
                    OnRegistSyn(syn);
                    return;
                }
                if (msg is RegistAck) {
                    RegistAck? ack = msg as RegistAck;
                    if (ack == null) {
                        Console.WriteLine("[LOCATION SERVER] RegistAck is null");
                        return;
                    }
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
            SendRegistAck((uint)_mUser.GetSeq(), LocationResult.LOCATION_SUCCESS, "User Regist Success");
        }

        private void OnRegistAck(RegistAck ans) {
            if (ans.result == LocationResult.LOCATION_FAIL) {
                ProjectZ.NetworkPacket packet = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_REQ_LOGIN);
                packet.U2((short)ProjectZ.NetACKTypes.ACK_EXIST_USER);
                packet.U4(0);
                _pUser.GetSession().SendPacketAsync(packet);
                _pUser.SetState(ProjectZ.NState.Static.instance.TITLE());
                ProjectZ.NProxy.Proxy.instance.RemoveUser(ref _pUser);
                return;
            }

            Console.WriteLine("[LOCATION OnRegistAck ] Regist Success UserInfoSyn");
            ProjectZ.NProxy.Proxy.instance.UserInfoSyn(ref _pUser);
            _pUser.SetLocationRegist();
        }

        private void OnUnRegistSyn(UnRegistSyn syn) {
            SendUnRegistAck((uint)_mUser.GetSeq(), LocationResult.LOCATION_SUCCESS, "User UnRegist Success");
        }

        private void OnUnRegistAck(UnRegistAck ans) {
            if (ans.result == LocationResult.LOCATION_SUCCESS) {
                Console.WriteLine("[LOCATION OnUnRegistAck ] UnRegist Success");
            } else {
                Console.WriteLine("[LOCATION OnUnRegistAck ] UnRegist Fail");
            }
            _pUser.SetState(ProjectZ.NState.Static.instance.TITLE());
            ProjectZ.NProxy.Proxy.instance.RemoveUser(ref _pUser);
        }

        public int GetSeq() {
            return _mUser.GetSeq();
        }
        public void SetSeq(int user_seq) {
            _mUser.SetSeq(user_seq);
        }
    }
}