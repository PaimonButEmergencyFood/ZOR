namespace ProjectZ.NCommand.NWorld {
    public class CS_REQ_GAME_INFO
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO!: API_ZNO_CS_REQ_GAME_INFO");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_GAME_INFO);
            // TODO get maxLevel and recoveryMinute from somewhere
            rsp.U2((short)2); // count of ints
            rsp.U4(99); // maxLevel
            rsp.U4(1); // recoveryMinute

            Console.WriteLine("[CHANNEL] maxLevel: " + 99);
            Console.WriteLine("[CHANNEL] recoveryMinute: " + 1);
            
            _user.GetSession().SendPacketAsync(rsp);
        }
    }
}
           