namespace ProjectZ.NState {
    class ReadyMainFriendList : User.State {
        private String name;

        public override String GetName() {
            return name;
        }

        public ReadyMainFriendList() {
            name = "ReadyMainFriendList";
        }
    }
}