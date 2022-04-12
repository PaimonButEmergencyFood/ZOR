namespace Location {
    class LocationServer {
        private List<uint> _userSeqList;

        public LocationServer() {
            _userSeqList = new List<uint>();
        }
        public void OnRegistAck(ref ProjectZ.User pUser, ref RegistAck msg) {
            Console.WriteLine("[LOCATION] RegistAck Seq : " + msg.seq);
            if (msg.result != 0) {
                Console.WriteLine("[LOCATION] RegistAck FAILED, Result : " + msg.result);

                ProjectZ.NetworkPacket rsp = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_REQ_LOGIN);
                rsp.U2((short)ProjectZ.NetACKTypes.ACK_EXIST_USER);
                rsp.U4(0);
                pUser.GetSession().SendPacket(ref rsp, true, true);
                pUser.SetState(ProjectZ.NState.Static.instance.TITLE());
                return;
            }

            ProjectZ.NProxy.Proxy.instance.UserInfoSyn(ref pUser);
        }
        public void OnRegistSyn(ref ProjectZ.User pUser, RegistSyn msg) {
            if (pUser == null) {
                Console.WriteLine("[PROXY] RegisterUser Session is null");
                return;
            }

            if (_userSeqList.Contains(msg.seq)) {
                Console.WriteLine("[PROXY] RegisterUser Seq is already exist");
                // TODO send kick
                return;
            }

            _userSeqList.Add(msg.seq);
            Console.WriteLine("[PROXY] RegisterUser Success, Seq : " + msg.seq);

            RegistAck ack = new RegistAck();
            ack.seq = msg.seq;
            ack.result = 0;
        }
    }
}