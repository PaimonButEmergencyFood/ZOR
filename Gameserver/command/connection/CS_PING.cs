namespace ProjectZ.command.connection {
    public class CS_PING
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);
        }
    }
}
 