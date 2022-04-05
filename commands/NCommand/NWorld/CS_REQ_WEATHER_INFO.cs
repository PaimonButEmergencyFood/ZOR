using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_WEATHER_INFO
    {
        public NetworkPacket ZNO_CS_REQ_WEATHER_INFO(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_WEATHER_INFO");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_WEATHER_INFO);
            rsp.U1(0); // weather_type
            return rsp;
        }
    }
}
