namespace ProjectZ {
    public class API_ZNO_CS_BLACKSMITH_UPSTONE_LIST
    {
        public NetworkPacket ZNO_CS_BLACKSMITH_UPSTONE_LIST(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_BLACKSMITH_UPSTONE_LIST");
            Console.WriteLine("+-------------------------------------------------------------------");

            // TODO get actual upstone list
            /**
            uint64_t	seq			= 0;
            uint8_t		status		= 0;
            uint8_t		quality		= 0;
            int32_t		remainSec	= 0;
            int32_t		totalSec	= 0;
            uint16_t	needZen		= 0;
            uint16_t	stoneLevel	= 0;
            **/
            // for every stone ^^

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_BLACKSMITH_UPSTONE_LIST);
            rsp.U1(0);

            return rsp;
        }
    }
}
           