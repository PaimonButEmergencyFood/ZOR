namespace Cache {
    public class CacheServer {
        private User _pUser;
        public CacheServer() {
            _pUser = new User();
        }

        public async void SendMsg<T> (T msg) {
            await Task.Run(() => {
                OnMsg(msg);
            });
        }

        public async void OnMsg<T> (T msg) {
            await Task.Run(() => {
                if (msg is UserInfoSyn) {
                    UserInfoSyn? syn = msg as UserInfoSyn;
                    if (syn == null) {
                        Console.WriteLine("[CACHE SERVER] UserInfoSyn is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] UserInfoSyn {0}", syn.seq);
                    OnUserInfoSyn(syn);
                    return;
                }
                if (msg is UserInfoAck) {
                    UserInfoAck? ack = msg as UserInfoAck;
                    if (ack == null) {
                        Console.WriteLine("[CACHE SERVER] UserInfoAck is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] UserInfoAck {0}", ack.seq);
                    OnUserInfoAck(ack);
                    return;
                }
                Console.WriteLine("[CACHE SERVER] Unknown msg type "  + msg.GetType());
            });
        }

        public void SendFailUserInfo(UInt32 seq, CacheResult result, string msg) {
            UserInfoAck ack = new UserInfoAck();
            ack.seq = seq;
            ack.result = result;
            ack.strError = msg;
            SendMsg(ack);
        }

        public void SendFailCharacterInfo(UInt32 seq, CacheResult result, string msg) {
            CharacterInfoAck ack = new CharacterInfoAck();
            ack.seq = seq;
            ack.result = result;
            ack.strError = msg;
            SendMsg(ack);
        }

        public void SendFailFlushCharacterInfo(UInt32 seq, CacheResult result, string msg) {
            FlushCharacterInfoAck ack = new FlushCharacterInfoAck();
            ack.seq = seq;
            ack.result = result;
            ack.strError = msg;
            SendMsg(ack);
        }

        public void SendFailFlushUserInfo(UInt32 seq, CacheResult result, string msg) {
            FlushUserInfoAck ack = new FlushUserInfoAck();
            ack.seq = seq;
            ack.result = result;
            ack.strError = msg;
            SendMsg(ack);
        }

        public void SendFlushUserSlotInfo(UInt32 seq, CacheResult result, string msg) {
            FlushUserSlotInfoAck ack = new FlushUserSlotInfoAck();
            ack.seq = seq;
            ack.result = result;
            ack.strError = msg;
            SendMsg(ack);
        }

        private void OnUserInfoSyn(UserInfoSyn syn) {
            _pUser.Initialize();

            UserInfo? userInfo = Database.NoSql.instance.GetUser((int)syn.seq);
            if (userInfo == null) {
                Console.WriteLine("[CACHE SERVER] UserInfo doesnt exist (yet?) - using default");
                return;
            }
            _pUser.SetUserInfo(ref userInfo);

            Console.WriteLine("[CACHE SERVER] UserInfo {0}", syn.seq);

            UserInfoAck ack = new UserInfoAck();
            ack.seq = syn.seq;
            ack.result = CacheResult.CACHE_SUCCESS;
            if (_pUser.GetUserInfo() == null) {
                ack.result = CacheResult.CACHE_DATABASE_ERROR;
                ack.strError = "UserInfo is null";
            } else {
                ack.stUserInfo = _pUser.GetUserInfo();
            }
            SendMsg(ack);
            return;
        }

        private void OnUserInfoAck(UserInfoAck ack) {
            if (ack.result != CacheResult.CACHE_SUCCESS) {
                Console.WriteLine("[CACHE SERVER] UserInfoAck failed {0}", ack.strError);
                return;
            }
            
            ProjectZ.User? pUser = ProjectZ.NProxy.Proxy.instance.GetUser((int)ack.seq)
            if (pUser == null) {
                Console.WriteLine("[CACHE SERVER] UserInfoAck failed - user doesnt exist");
                return;
            }

            Console.WriteLine("[CACHE SERVER] UserInfoAck GID {0}", ack.seq);

            pUser.SetUserInfo(ack.stUserInfo);

            int count = 0;
            for (int i = 0; i < 8; i++) {
                if (pUser.GetUserInfo().array_Slot[i].open == true && pUser.GetUserInfo().array_Slot[i].makeCharacter == true) {
                    count++;
                }
            }

            pUser.SetOpenCharacterCount(count);

            if (count <= 0) {
                pUser.SetLogin();
                pUser.SetState(ProjectZ.NState.Static.instance.MAINFRIENDLIST());

                ProjectZ.NetworkPacket rsp = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_REQ_LOGIN);
                rsp.U2((short)ProjectZ.NetACKTypes.ACK_OK);
                rsp.U4(0);
                ProjectZ.Session? session = pUser.GetSession();

                if (session == null) {
                    Console.WriteLine("[CACHE SERVER] UserInfoAck failed - session doesnt exist");
                    return;
                }
                session.SendPacketAsync(rsp);
            }
            for (int i = 0; i < 8; i++) {
                if (pUser.GetUserInfo().array_Slot[i].open == true && pUser.GetUserInfo().array_Slot[i].character_seq != 0) {
                    ProjectZ.NProxy.Proxy.instance.CharacterInfoSyn(ref pUser, pUser.GetUserInfo().array_Slot[i].character_seq);
                }
            }

            // reward...
            Console.WriteLine("[CACHE SERVER] UserInfoAck OPEN CHARACTER COUNT {0}", pUser.GetOpenCharacterCount());
        }
    }
}