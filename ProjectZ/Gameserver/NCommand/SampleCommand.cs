namespace ProjectZ.NCommand.NConnection {
    class CS_CONNECT {
        public static void OnExecute(ref User pUser, ref NetworkPacket packet) {
            Console.WriteLine("hello from CS_CONNECT");
            pUser.printGID();
            pUser.SetGID(42069);
        }
    }
}