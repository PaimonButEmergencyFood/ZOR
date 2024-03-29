using System.Text;

namespace ProjectZ {
    class Encryption : NUtil.Single<Encryption> {
        private bool IsNeedEnc(NetCMDTypes wCMD)
        {
            if (wCMD == NetCMDTypes.ZNO_CS_PING ||		
                wCMD == NetCMDTypes.ZNO_CS_MOVE || 
                wCMD == NetCMDTypes.ZNO_SC_MOVE ||
                wCMD == NetCMDTypes.ZNO_CS_STOP ||
                wCMD == NetCMDTypes.ZNO_SC_STOP ||
                wCMD == NetCMDTypes.ZNO_CS_DASH ||
                wCMD == NetCMDTypes.ZNO_SC_DASH ||
                wCMD == NetCMDTypes.ZNO_CS_RECONNECT ||
                wCMD == NetCMDTypes.ZNO_SC_RECONNECT ||
                wCMD == NetCMDTypes.ZNO_CS_REQ_LOCATION ||
                wCMD == NetCMDTypes.ZNO_SN_REQ_LOCATION ||
                wCMD == NetCMDTypes.ZNO_CS_MOVE_MOB ||
                wCMD == NetCMDTypes.ZNO_SC_MOVE_MOB ||
                wCMD == NetCMDTypes.ZNO_CN_LOCATION_MODIFY ||
                wCMD == NetCMDTypes.ZNO_SN_LOCATION_MODIFY ||
                wCMD == NetCMDTypes.ZNO_CS_ATTACK_START ||
                wCMD == NetCMDTypes.ZNO_SC_ATTACK_START ) {
                    return false;
                }
	        return true;
        }
        private int _key1;
        private int _key2;
        private int _key3;
        private int _key4;

        public Encryption() {
            _key1 = 0;
            _key2 = 0;
            _key3 = 0;
            _key4 = 0;
        }

        public void MakeKey() {
            UInt16[] array = new UInt16[2];
            array[0] = 0x5555;
            array[1] = 0x5555;
            _key1 = array[0];
            _key2 = array[0];
            _key3 = array[0];
            _key4 = array[0];

            _key1 |= 0x1234;
            _key2 |= 0x4567;
            _key3 |= 0x8765;
            _key4 |= 0x4321;
        }

        public int GetKey() {
            return _key1;
        }
        public int GetKey1() {
            return _key2;
        }
        public int GetKey2() {
            return _key3;
        }
        public int GetKey3() {
            return _key4;
        }

        public void Decrypt_First(ref NetworkPacket pPacket) {
            byte[] public_key = Encoding.ASCII.GetBytes("ZenoniaOnline");
            int public_key_len = public_key.Length;

            if (public_key_len >= 17) {
                public_key_len = 16;
            }

            for (int i = 0; i < pPacket.data.Length; i++) {
                pPacket.data[i] ^= public_key[i % public_key_len];
            }
        }

        public void EncryptFirst(string social_id, ref NetworkPacket pPacket) {
            byte[] public_key = Encoding.ASCII.GetBytes(social_id);
            int public_key_len = public_key.Length;

            if (public_key_len >= 17) {
                public_key_len = 16;
            }

            for (int i = 0; i < pPacket.data.Length; i++) {
                pPacket.data[i] ^= public_key[i % public_key_len];
            }
        }

        public void Encrypt(ref NetworkPacket pPacket) {
            if (!IsNeedEnc(pPacket.Cmd)) {
                return;
            }

            int[] keys = new int[4];
            keys[0] = _key1;
            keys[1] = _key2;
            keys[2] = _key3;
            keys[3] = _key4;

            byte[] public_key = new byte[16];
            ByteArray.SetUInt32(public_key, 0, (uint)_key1);
            ByteArray.SetUInt32(public_key, 4, (uint)_key2);
            ByteArray.SetUInt32(public_key, 8, (uint)_key3);
            ByteArray.SetUInt32(public_key, 12, (uint)_key4);

            int public_keys_len = 16;

            for (int i = 0; i < pPacket.data.Length; i++) {
                pPacket.data[i] ^= public_key[i % public_keys_len];
            }
        }

        public void Decrypt(ref NetworkPacket pPacket) {
            Encrypt(ref pPacket);
        }

    }
}