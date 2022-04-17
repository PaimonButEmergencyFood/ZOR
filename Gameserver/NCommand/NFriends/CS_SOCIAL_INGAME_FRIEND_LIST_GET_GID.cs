namespace ProjectZ.NCommand.NFriends {
    public class CS_SOCIAL_INGAME_FRIEND_LIST_GET_GID
    {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);
            Console.WriteLine("+-------------------------------------------------------------------");
	        Console.WriteLine("| TODO!: API_ZNO_CS_SOCIAL_INGAME_FRIEND_LIST_GET_GID");
            Console.WriteLine("+-------------------------------------------------------------------");
            NetworkPacket response = new NetworkPacket(NetCMDTypes.ZNO_SC_SOCIAL_INGAME_FRIEND_LIST_GET_GID);
            response.U2((short)NetACKTypes.ACK_OK);
            response.U2(0); // TODO this len of in-game friend list
            
            _user.GetSession().SendPacketAsync(response);
        }
    }
}