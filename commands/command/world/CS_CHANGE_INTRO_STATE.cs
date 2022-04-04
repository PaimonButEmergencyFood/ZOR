using ProjectZ.Common.Protocol.Protobuf;
using Google.Protobuf;

namespace ProjectZ {
    public class API_ZNO_CS_CHANGE_INTRO_STATE
    {
        public NetworkPacket ZNO_CS_CHANGE_INTRO_STATE(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| API_ZNO_CS_CHANGE_INTRO_STATE");
            Console.WriteLine("+-------------------------------------------------------------------");

            byte new_intro_state = req.U1();
            session.user.IntroState = (sbyte)new_intro_state;
            Console.WriteLine("| new_intro_state: " + new_intro_state);
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_CHANGE_INTRO_STATE);
            rsp.U2((short)NetACKTypes.ACK_OK);
            return rsp;
        }
    }
}
