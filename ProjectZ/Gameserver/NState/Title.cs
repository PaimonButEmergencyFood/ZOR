namespace ProjectZ.NState {
    class Title : User.State {
        private String? name;

        public override String GetName() {
            return name;
        }

        public Title() {
            name = "TITLE";
            AddCommand((ushort)NetCMDTypes.ZNO_CS_CONNECT, ProjectZ.NCommand.NConnection.CS_CONNECT.OnExecute);
        }
    }
}