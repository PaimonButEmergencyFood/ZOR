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
        }
    }
}