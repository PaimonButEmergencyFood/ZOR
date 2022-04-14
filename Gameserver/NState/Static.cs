namespace ProjectZ.NState
{
    class Static : NUtil.Single<Static>
    {
        public Static() {
            _title = new Title();
            _readyMainFriendList = new ReadyMainFriendList();
            _mainFriendList = new MainFriendList();
        }

        public ref Title TITLE() {
            return ref _title;
        }
        public ref ReadyMainFriendList READYMAINFRIENDLIST() {
            return ref _readyMainFriendList;
        }
        public ref MainFriendList MAINFRIENDLIST() {
            return ref _mainFriendList;
        }

        private Title _title;
        private ReadyMainFriendList _readyMainFriendList;
        private MainFriendList _mainFriendList;

    }
}