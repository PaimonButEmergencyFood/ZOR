using ProjectZ.Logic;

namespace ProjectZ {
    public class API_ZNO_CS_REQ_TUTORIAL_LIST
    {
        public NetworkPacket ZNO_CS_REQ_TUTORIAL_LIST(NetworkPacket req, Session session) {
            Console.WriteLine("+-------------------------------------------------------------------");
            Console.WriteLine("| TODO: API_ZNO_CS_REQ_TUTORIAL_LISTG");
            Console.WriteLine("+-------------------------------------------------------------------");

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_TUTORIAL_LIST);
            rsp.U2(1);
            rsp.U1(4);
            rsp.U1((sbyte)session.user.ArrayTutorial[0]);
            rsp.U1((sbyte)session.user.ArrayTutorial[1]);
            rsp.U1((sbyte)session.user.ArrayTutorial[2]);
            rsp.U1((sbyte)session.user.ArrayTutorial[3]);

            return rsp;
        }
    }
}
