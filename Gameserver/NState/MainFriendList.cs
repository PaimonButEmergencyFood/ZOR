namespace ProjectZ.NState {
    class MainFriendList : User.State {
        private String name;

        public override String GetName() {
            return name;
        }

        public MainFriendList() {
            name = "MainFriendList";
            AddCommand((ushort)NetCMDTypes.ZNO_CS_PING, ProjectZ.command.connection.CS_PING.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_SOCIAL_MYINFO, ProjectZ.NCommand.NFriends.CS_SOCIAL_MYINFO.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_SOCIAL_INGAME_FRIEND_LIST_GET_GID, ProjectZ.NCommand.NFriends.CS_SOCIAL_INGAME_FRIEND_LIST_GET_GID.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_GET_NEW_MAIL_COUNT, ProjectZ.NCommand.NMail.CS_GET_NEW_MAIL_COUNT.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_SOCIAL_NEWS_COUNT, ProjectZ.NCommand.NFriends.CS_SOCIAL_NEWS_COUNT.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_REQ_SLOT_LIST, ProjectZ.command.world.CS_REQ_SLOT_LIST.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_REQ_GAME_INFO, ProjectZ.NCommand.NWorld.CS_REQ_GAME_INFO.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_UPDATE_MY_PROFILE, ProjectZ.NCommand.NFriends.CS_UPDATE_MY_PROFILE.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_REQ_REMOTE_CONTROL, ProjectZ.NCommand.NConnect.CS_REQ_REMOTE_CONTROL.OnExecute);
            AddCommand((ushort)NetCMDTypes.ZNO_CS_SLOT_PLAYER_CREATE, ProjectZ.command.world.CS_SLOT_PLAYER_CREATE.OnExecute);
        }
    }
}