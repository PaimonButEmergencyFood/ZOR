namespace Location {
    public class LocationServer {
        private User _mUser;
        private ProjectZ.User _pUser;
        public LocationServer() {
            _mUser = new User();
            _pUser = new ProjectZ.User();
        }

        public void SetUser(ProjectZ.User pUser) {
            _pUser = pUser;
        }

        public async void OnMsg<T> (T msg) {
            await Task.Run(() => {
                if (msg is RegistSyn) {
                    RegistSyn? syn = msg as RegistSyn;
                    if (syn == null) {
                        Console.WriteLine("[LOCATION SERVER] RegistSyn is null");
                        return;
                    }
                }
            });
        }

        public int GetSeq() {
            return _user.GetSeq();
        }
        public void SetSeq(int user_seq) {
            _user.SetSeq(user_seq);
        }
    }
}