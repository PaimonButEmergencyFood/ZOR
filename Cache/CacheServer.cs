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
                if (msg is CharacterInfoSyn) {
                    CharacterInfoSyn? syn = msg as CharacterInfoSyn;
                    if (syn == null) {
                        Console.WriteLine("[CACHE SERVER] CharacterInfoSyn is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] CharacterInfoSyn {0}", syn.seq);
                    OnCharacterInfoSyn(syn);
                    return;
                }
                if (msg is CharacterInfoAck) {
                    CharacterInfoAck? ack = msg as CharacterInfoAck;
                    if (ack == null) {
                        Console.WriteLine("[CACHE SERVER] CharacterInfoAck is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] CharacterInfoAck {0}", ack.seq);
                    OnCharacterInfoAck(ack);
                    return;
                }
                if (msg is FlushUserSlotInfoSyn) {
                    FlushUserSlotInfoSyn? syn = msg as FlushUserSlotInfoSyn;
                    if (syn == null) {
                        Console.WriteLine("[CACHE SERVER] FlushUserSlotInfoSyn is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] FlushUserSlotInfoSyn {0}", syn.seq);
                    OnFlushUserSlotInfoSyn(syn);
                    return;
                }
                if (msg is FlushUserSlotInfoAck) {
                    FlushUserSlotInfoAck? ack = msg as FlushUserSlotInfoAck;
                    if (ack == null) {
                        Console.WriteLine("[CACHE SERVER] FlushUserSlotInfoAck is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] FlushUserSlotInfoAck {0}", ack.seq);
                    OnFlushUserSlotInfoAck(ack);
                    return;
                }
                if (msg is NewCharacterInfoSyn) {
                    NewCharacterInfoSyn? syn = msg as NewCharacterInfoSyn;
                    if (syn == null) {
                        Console.WriteLine("[CACHE SERVER] NewCharacterInfoSyn is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] NewCharacterInfoSyn {0}", syn.seq);
                    OnNewCharacterInfoSyn(syn);
                    return;
                }
                if (msg is NewCharacterInfoAck) {
                    NewCharacterInfoAck? ack = msg as NewCharacterInfoAck;
                    if (ack == null) {
                        Console.WriteLine("[CACHE SERVER] NewCharacterInfoAck is null");
                        return;
                    }
                    Console.WriteLine("[CACHE SERVER] NewCharacterInfoAck {0}", ack.seq);
                    OnNewCharacterInfoAck(ack);
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

        public void SendFlushUserSlotInfo(UInt32 seq, UInt32 slotIndex, CacheResult result, string msg) {
            FlushUserSlotInfoAck ack = new FlushUserSlotInfoAck();
            ack.seq = seq;
            ack.slotIndex = slotIndex;
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
            
            ProjectZ.User? pUser = ProjectZ.NProxy.Proxy.instance.GetUser((int)ack.seq);
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

        public void OnCharacterInfoSyn(CharacterInfoSyn syn) {
            _pUser.Initialize();

            CharacterInfo? characterInfo = Database.NoSql.instance.GetCharacter((int)syn.seq, (int)syn.char_seq);
            if (characterInfo == null) {
                Console.WriteLine("[CACHE SERVER] CharacterInfo doesnt exist (yet?) - using default");
                return;
            }

            Console.WriteLine("[CACHE SERVER] CharacterInfo {0}", syn.seq);

            CharacterInfoAck ack = new CharacterInfoAck();
            ack.seq = syn.seq;
            ack.result = CacheResult.CACHE_SUCCESS;
            ack.stCharacterInfo = characterInfo;
            SendMsg(ack);
            return;
        }

        public void OnCharacterInfoAck(CharacterInfoAck ack) {
            ProjectZ.User? pUser = ProjectZ.NProxy.Proxy.instance.GetUser((int)ack.seq);
            if (pUser == null) {
                Console.WriteLine("[CACHE SERVER] CharacterInfoAck failed - user doesnt exist");
                return;
            }

            ProjectZ.Session? session = pUser.GetSession();
            if (session == null) {
                Console.WriteLine("[CACHE SERVER] CharacterInfoAck failed - session doesnt exist");
                return;
            }

            if (ack.result != CacheResult.CACHE_SUCCESS) {
                Console.WriteLine("[CACHE SERVER] CharacterInfoAck failed {0}", ack.strError);
                ProjectZ.NetworkPacket mrsp = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_REQ_ENTER_MY_INFO);
                mrsp.U2((short)ProjectZ.NetACKTypes.ACK_DB_ERROR);
                mrsp.U4((int)ack.seq);

                session.SendPacketAsync(mrsp);
                return;
            }

            Console.WriteLine("[CACHE SERVER] CharacterInfoAck GID {0}", ack.seq);

            pUser.SetCharacterInfo(ack.stCharacterInfo, (int)ack.stCharacterInfo.slotindex);
            pUser.AddLoadCharacterCount();

            if (pUser.GetLoadCharacterCount() < pUser.GetOpenCharacterCount()) {
                Console.WriteLine("[CACHE SERVER] CharacterInfoAck OPEN CHARACTER COUNT {0}", pUser.GetOpenCharacterCount());
                return;
            }

            pUser.SetLogin();
            pUser.SetState(ProjectZ.NState.Static.instance.MAINFRIENDLIST());

            ProjectZ.NetworkPacket rsp = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_REQ_LOGIN);
            rsp.U2((short)ProjectZ.NetACKTypes.ACK_OK);
            rsp.U4(pUser.GetUserSeq());

            session.SendPacketAsync(rsp);

            //ProjectZ.NProxy.Proxy.instance.SetMainCharacterInfo(ref pUser);
            return;
        }

        private void OnFlushUserSlotInfoSyn(FlushUserSlotInfoSyn syn) {

            Console.WriteLine("[CACHE SERVER] FlushUserSlotInfo {0}", syn.seq);

            _pUser.GetUserInfo().array_Slot[syn.slotIndex] = syn.stSlot;

            Cache.Character? character = _pUser.GetCharacter((int)syn.stSlot.character_seq);
            if (character == null) {
                Console.WriteLine("[CACHE SERVER] FlushUserSlotInfo failed - character doesnt exist");
                return;
            }

            character._bOpen = true;
            character._bLoad = false;
            character._char_seq = syn.stSlot.character_seq;


            SendFlushUserSlotInfo(syn.seq, syn.slotIndex, CacheResult.CACHE_SUCCESS, "SUCCESS");
            return;
        }

        private void OnFlushUserSlotInfoAck(FlushUserSlotInfoAck ack) {
            ProjectZ.User? pUser = ProjectZ.NProxy.Proxy.instance.GetUser((int)ack.seq);
            if (pUser == null) {
                Console.WriteLine("[CACHE SERVER] FlushUserSlotInfoAck failed - user doesnt exist");
                return;
            }

            ProjectZ.NProxy.Proxy.instance.NewCharacterInfoSyn(ref pUser, (int)pUser.GetCharacterInfoFromIndex((int)ack.slotIndex).characterseq);

            //ProjectZ.NProxy.Proxy.instance.SetMainCharacterInfo(ref pUser);
            return;
        }

        private void OnNewCharacterInfoSyn(NewCharacterInfoSyn syn) {
            ProjectZ.User? pUser = ProjectZ.NProxy.Proxy.instance.GetUser((int)syn.seq);
            if (pUser == null) {
                Console.WriteLine("[CACHE SERVER] NewCharacterInfoSyn failed - user doesnt exist");
                return;
            }
            CharacterInfo characterInfo = new CharacterInfo();
            _pUser.GetCharacter((int)syn.char_seq)._bOpen = true;
            _pUser.GetCharacter((int)syn.char_seq)._char_seq = syn.char_seq;
            _pUser.GetCharacter((int)syn.char_seq)._characterInfo = characterInfo;

            NewCharacterInfoAck ack = new NewCharacterInfoAck();
            ack.seq = syn.seq;
            ack.result = CacheResult.CACHE_SUCCESS;
            ack.stCharacterInfo = _pUser.GetCharacter((int)syn.char_seq)._characterInfo;

            SendMsg(ack);
        }

        private void OnNewCharacterInfoAck(NewCharacterInfoAck ack) {
            ProjectZ.User? pUser = ProjectZ.NProxy.Proxy.instance.GetUser((int)ack.seq);
            if (pUser == null) {
                Console.WriteLine("[CACHE SERVER] NewCharacterInfoAck failed - user doesnt exist");
                return;
            }

            ProjectZ.Session? session = pUser.GetSession();
            if (session == null) {
                Console.WriteLine("[CACHE SERVER] NewCharacterInfoAck failed - session doesnt exist");
                return;
            }

            if (ack.result != CacheResult.CACHE_SUCCESS) {
                Console.WriteLine("[CACHE SERVER] NewCharacterInfoAck failed {0}", ack.strError);
                ProjectZ.NetworkPacket mrsp = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_REQ_ENTER_MY_INFO);
                mrsp.U2((short)ProjectZ.NetACKTypes.ACK_DB_ERROR);
                mrsp.U4((int)ack.seq);

                session.SendPacketAsync(mrsp);
                return;
            }

            Console.WriteLine("[CACHE SERVER] NewCharacterInfoAck GID {0}", ack.seq);

            pUser.SetCharacterInfo(ack.stCharacterInfo, (int)ack.stCharacterInfo.slotindex);
            pUser.AddLoadCharacterCount();

            pUser.GiveBaseItem((int)ack.stCharacterInfo.slotindex);

            pUser.SetState(ProjectZ.NState.Static.instance.MAINFRIENDLIST());

            ProjectZ.NetworkPacket rsp = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_SLOT_PLAYER_CREATE);
            rsp.U2((short)ProjectZ.NetACKTypes.ACK_OK);

            session.SendPacketAsync(rsp);

            // TODO OnFlushCharacterInfoSyn
        }

    }
}