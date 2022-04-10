namespace ProjectZ.NResource {
    class BalanceData {
        private Dictionary<int, int> clsValueTree = new Dictionary<int, int>();
        public BalanceData() {}
        public bool LoadResource(int company, int saleCode) {
            throw new System.NotImplementedException();
        }
        public int GetValue(int seq) {
            if (clsValueTree.ContainsKey(seq)) {
                return clsValueTree[seq];
            }
            return 0;
        }
    }

    class BalanceResource {
        private BalanceData? pBalanceAD; // Google
        private BalanceData? pBalanceIOS; // Apple

        public BalanceResource() {
            pBalanceAD = new BalanceData();
            pBalanceIOS = new BalanceData();
        }
        public bool LoadResource() {
            if (pBalanceAD.LoadResource(MARKET_GOOGLE, SC_KAKAO_GOOGLE)) {
                return true;
            }
        }
    }
}