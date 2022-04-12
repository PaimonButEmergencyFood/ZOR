namespace ProjectZ.NUtil {
    class Utils {
        public const int MARKET_IOS = 4;
        public const int MARKET_GOOGLE = 5;

        public const int SC_KAKAO_GOOGLE = 37;
        public const int SC_KAKAO_IOS = 38;

        public enum MarketType {
            __NONE__,
            IOS_KAKAO,
            AD_KAKAO,
            __MAX__
        }

        public MarketType GetMarketType(int company, int saleCode) {
            if (company == MARKET_IOS) {
                if (saleCode == SC_KAKAO_IOS) {
                    return MarketType.IOS_KAKAO;
                }
            } else if (company == MARKET_GOOGLE) {
                if (saleCode == SC_KAKAO_GOOGLE) {
                    return MarketType.AD_KAKAO;
                }
            }
            return MarketType.__NONE__;
        }

        public int getRandBetween(int min, int max) {
            if (max < min) {
                max = min;
            }
            return (int)(((max - min + 1) % (float)new Random().NextDouble()) + min);
        }

        public int AddPercentage(int value , int percentage) {
            return (int)(value + (value * (percentage / 100.0f)));
        }

        public int GetEggGrade(int itemQuality) {
            int accRate = 0;
            int eggGrade = 0;
            int eggRate = (int)(new Random().NextDouble() % 100);

            for (; eggGrade < NXLData.egg_grade.EGG_GRADE_EGG_GRADE_MAX; eggGrade++) {
                NXLData.egg_grade.EGG_GRADE_EGG_GRADE eggGradeData = NXLData.egg_grade.stEgg_Grade_Egg_Grade[eggGrade];

                switch (itemQuality) {
                    case 0: accRate += eggGradeData.star1_rate4; break;
                    case 1: accRate += eggGradeData.star2_rate5; break;
                    case 2: accRate += eggGradeData.star3_rate6; break;
                    case 3: accRate += eggGradeData.star4_rate7; break;
                    case 4: accRate += eggGradeData.star5_rate8; break;
                    case 5: accRate += eggGradeData.star6_rate9; break;
                    case 6: accRate += eggGradeData.star7_rate10; break;
                    case 7: accRate += eggGradeData.star8_rate11; break;
                    case 8: accRate += eggGradeData.star9_rate12; break;
                    case 9: accRate += eggGradeData.star10_rate13; break;
                }

                if (eggRate < accRate) {
                    break;
                }
            }

            if (eggRate == NXLData.egg_grade.EGG_GRADE_EGG_GRADE_MAX) {
                eggGrade -= 1;
            }

            return eggGrade;
        }
    }
}