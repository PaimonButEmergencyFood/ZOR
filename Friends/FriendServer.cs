namespace iFriends {
    public class FriendServer {
        private enum EAck
        {
            ACK_EXIST_USER = -4,
            ACK_NO_DATA = -3,
            ACK_DB_ERROR = -2,
            ACK_UNKNOWN_ERROR	= -1,
            ACK_OK	= 1,

            ACK_OF_THE_REQUESTS = 2100,
            ACK_TIME_LEFT = 2101,
            ACK_MAX_FRIENDS = 2102,
            ACK_MAX_FRIENDS_OTHER = 2103,
            ACK_POINT_IS_LACKING = 2104,
        };
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
                if (msg is SocialMyInfoAck) {
                    SocialMyInfoAck? ack = msg as SocialMyInfoAck;
                    if (ack == null) {
                        Console.WriteLine("[FRIEND SERVER] UserInfoAck is null");
                        return;
                    }
                    Console.WriteLine("[FRIEND SERVER] UserInfoAck {0}", ack.seq);
                    OnSocialMyInfoAck(ack);
                    return;
                }
                if (msg is UpdateProfileSyn) {
                    UpdateProfileSyn? syn = msg as UpdateProfileSyn;
                    if (syn == null) {
                        Console.WriteLine("[FRIEND SERVER] UpdateProfileSyn is null");
                        return;
                    }
                    Console.WriteLine("[FRIEND SERVER] UpdateProfileSyn {0}", syn.seq);
                    OnUpdateProfileSyn(syn);
                    return;
                }
                if (msg is UpdateProfileAck) {
                    UpdateProfileAck? ack = msg as UpdateProfileAck;
                    if (ack == null) {
                        Console.WriteLine("[FRIEND SERVER] UpdateProfileAck is null");
                        return;
                    }
                    Console.WriteLine("[FRIEND SERVER] UpdateProfileAck {0}", ack.seq);
                    OnUpdateProfileAck(ack);
                    return;
                }
                Console.WriteLine("[FRIEND SERVER] Unknown msg type "  + msg.GetType());
            });
        }

        private void OnSocialMyInfoSyn(SocialMyInfoSyn syn) {
            Console.WriteLine("SEQ : {0}", syn.seq);

            _user.Initialize();
            _user.SetSocialId(syn.socialid);
            _user.SetUserSeq(syn.seq);

            User.UserInfo userInfo = _user.GetUserInfo();
            userInfo.Initialize();
            userInfo.nickname = syn.nickname;
            userInfo.profile_url = syn.profile_url;

            // TODO load user friend info from db

            SocialMyInfoAck ack = new SocialMyInfoAck();
            ack.result = (short)EAck.ACK_OK;
            ack.heart_count = _user.GetHeartCount();
            ack.heart_blocked = userInfo.isHeartBlock;
            ack.profile_opened = userInfo.isProfileBlock;
            ack.invite_block = userInfo.isInviteBlock;
            ack.gender = userInfo.gender;
            ack.gender_open = userInfo.isGenderOpen;
            ack.birthday = userInfo.birthday;
            ack.birth_open = userInfo.isBirthdayOpen;

            ack.seq = syn.seq; // FIX FOR OnSocialMyInfoAck not get user

            OnMsg(ack);

            //_user.SetGameUserSeq();
            //_user.SetNoAppFriends();
        }

        private void OnSocialMyInfoAck(SocialMyInfoAck ack) {
            Console.WriteLine("[FRIEND SERVER] OnSocialMyInfoAck SEQ : {0}", ack.seq);
            ProjectZ.User? user = ProjectZ.NProxy.Proxy.instance.GetUser((int)ack.seq);
            if (user == null) {
                Console.WriteLine("[FRIEND SERVER] User is null");
                return;
            }

            ProjectZ.NetworkPacket packet = new ProjectZ.NetworkPacket(ProjectZ.NetCMDTypes.ZNO_SC_SOCIAL_MYINFO);
            packet.U2(ack.result);
            packet.U4((int)ack.seq);
            packet.U4((int)user.GetUserInfo().wp_cur_week);
            packet.U1((sbyte)ack.heart_blocked);
            packet.U1((sbyte)ack.profile_opened);
            packet.U1((sbyte)ack.invite_block);
            packet.U1((sbyte)ack.gender);
            packet.U1((sbyte)ack.gender_open);
            packet.U2((short)ack.birthday.Length);
            packet.Set(ack.birthday);
            packet.U1((sbyte)ack.birth_open);

            ProjectZ.Session? session = user.GetSession();
            if (session == null) {
                Console.WriteLine("[FRIEND SERVER] Session is null");
                return;
            }

            session.SendPacketAsync(packet);
            Console.WriteLine("[FRIEND SERVER] Send packet");
        }

        private void OnUpdateProfileSyn(UpdateProfileSyn syn) {
            Console.WriteLine("[FRIEND SERVER] OnUpdateProfileSyn SEQ : {0}", syn.seq);
            ProjectZ.User? user = ProjectZ.NProxy.Proxy.instance.GetUser((int)syn.seq);
            if (user == null) {
                Console.WriteLine("[FRIEND SERVER] User is null");
                return;
            }

            User.UserInfo userInfo = _user.GetUserInfo();
            userInfo.gender = syn.gender;
            userInfo.isGenderOpen = syn.is_gender_open;
            userInfo.birthday = syn.birthday;
            userInfo.isBirthdayOpen = syn.is_birthday_open;
            userInfo.isProfileBlock = syn.is_profile_open;

            UpdateProfileAck ack = new UpdateProfileAck();
            ack.result = (short)EAck.ACK_OK;
            ack.birthday = syn.birthday;
            ack.gender = syn.gender;
            ack.is_birthday_open = syn.is_birthday_open;
            ack.is_gender_open = syn.is_gender_open;
            ack.is_profile_open = syn.is_profile_open;

            OnMsg(ack);
        }

        private void OnUpdateProfileAck(UpdateProfileAck ack) {
            
        }
    }
}