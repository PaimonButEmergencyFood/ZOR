namespace ProjectZ.NState
{
    class Static : NUtil.Single<Static>
    {
        public Static() {
            _title = new Title();
            _readyMainFriendList = new ReadyMainFriendList();
        }

        public ref Title TITLE() {
            return ref _title;
        }
        public ref ReadyMainFriendList READYMAINFRIENDLIST() {
            return ref _readyMainFriendList;
        }

        private Title _title;
        private ReadyMainFriendList _readyMainFriendList;

    }
}