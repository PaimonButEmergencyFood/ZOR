namespace ProjectZ.NState {
    class MainFriendList : User.State {
        private String name;

        public override String GetName() {
            return name;
        }

        public MainFriendList() {
            name = "MainFriendList";
        }
    }
}