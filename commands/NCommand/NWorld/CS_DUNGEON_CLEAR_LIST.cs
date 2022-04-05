using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_DUNGEON_CLEAR_LIST
    {
        public NetworkPacket ZNO_CS_DUNGEON_CLEAR_LIST(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_DUNGEON_CLEAR_LIST");
            Console.WriteLine("+-------------------------------------------------------------------");

            if (session.user.GetSpace == null) {
                Console.WriteLine("| CS_DUNGEON_CLEAR_LIST: user {0} is not in space", session.user.Nickname);
                return null;
            }

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_DUNGEON_CLEAR_LIST);

            for (int i = 0; i < Constants.MAX_DUNGEON_COUNT; i++) {
                rsp.U1((sbyte)session.user.GetDungeonClear(i));
            }
            return rsp;
        }
    }
}
