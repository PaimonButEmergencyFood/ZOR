namespace ProjectZ.NState {
    class MainFriendList : User.State {
        private String name;

        public override String GetName() {
            return name;
        }

        public MainFriendList() {
            name = "MainFriendList";
            AddCommand((ushort)NetCMDTypes.ZNO_CS_SOCIAL_MYINFO, ProjectZ.NCommand.NFriends.CS_SOCIAL_MYINFO.OnExecute);
        }
    }
}