namespace ProjectZ.command.world {
    public class CS_REQ_SLOT_LIST {
        public static void OnExecute(ref User _user, ref NetworkPacket req) {
            Encryption.instance.Decrypt(ref req);

            NetworkPacket rsp = new NetworkPacket(NetCMDTypes.ZNO_SC_REQ_SLOT_LIST);

            rsp.U1((sbyte)_user.GetUserInfo().main_slot_index);

            _user.GetSession().SendPacketAsync(rsp);
        }
    }
}