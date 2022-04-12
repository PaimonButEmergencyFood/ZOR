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
            if (pBalanceAD.LoadResource(NUtil.Utils.MARKET_GOOGLE, NUtil.Utils.SC_KAKAO_GOOGLE) == false) {
                return false;
            }
            if (pBalanceIOS.LoadResource(NUtil.Utils.MARKET_IOS, NUtil.Utils.SC_KAKAO_IOS) == false) {
                return false;
            }
            return true;
        }

        int GetValue(ref User pUser, int seq) {
            throw new System.NotImplementedException();
            /**
            NUtil.Utils.MarketType marketType = NUtil.Utils.GetMarketType(pUser.GetUserInfo().company, pUser.GetUserInfo().saleCode);

            switch (marketType) {
                case NUtil.Utils.MarketType.IOS_KAKAO:
                    return pBalanceIOS.GetValue(seq);
                case NUtil.Utils.MarketType.AD_KAKAO:
                    return pBalanceAD.GetValue(seq);
                default:
                    return 0;
            }
            **/
        }

        public ref BalanceData? GetBalancePtr(ref User pUser) {
            throw new System.NotImplementedException();
            /**
            NUtil.Utils.MarketType marketType = NUtil.Utils.GetMarketType(pUser.GetUserInfo().company, pUser.GetUserInfo().saleCode);

            switch (marketType) {
                case NUtil.Utils.MarketType.IOS_KAKAO:
                    return ref pBalanceIOS;
                case NUtil.Utils.MarketType.AD_KAKAO:
                    return ref pBalanceAD;
                default:
                    return ref null;
            }
            **/
        }
    }
}