namespace ProjectZ.Logic {
    public class Function {
        public static int GetBagSlotMaxOpenCount(INVEN_BAG_TYPE eBagType)
        {
            switch (eBagType)
            {
            case INVEN_BAG_TYPE.BAG_TYPE_NORMAL:
                return 52;
            case INVEN_BAG_TYPE.BAG_TYPE_ACCESSORY:
                return 52;
            case INVEN_BAG_TYPE.BAG_TYPE_MISC:
                return 32;
            case INVEN_BAG_TYPE.BAG_TYPE_TITLE:
                return 32;
            case INVEN_BAG_TYPE.BAG_TYPE_WAREHOUSE:
                return 8;
            case INVEN_BAG_TYPE.BAG_TYPE_FAIRY:
                return 60;
            case INVEN_BAG_TYPE.BAG_TYPE_BATTLE_PET:
                return 80;
            default:
                return 0;
            }
        }
        public static int GetDefaultStat(int classtype, ESTATNAME statname) {
            switch (statname) {
                case ESTATNAME.STAT_STR:
                    return NXLData.pcnew.stPcnew_Pcnew[classtype].STR_NEW;
                case ESTATNAME.STAT_DEX:
                    return NXLData.pcnew.stPcnew_Pcnew[classtype].DEX_NEW;
                case ESTATNAME.STAT_CON:
                    return NXLData.pcnew.stPcnew_Pcnew[classtype].CON_NEW;
                case ESTATNAME.STAT_SPI:
                    return NXLData.pcnew.stPcnew_Pcnew[classtype].SPI_NEW;                
            }
            Console.WriteLine("Unknown statname: " + statname);
            return 0;
        }

        public static int GetStatUpConst(int classtype, ESTATNAME statname)
        {
            switch (statname)
            {
            case ESTATNAME.STAT_STR:
                return NXLData.pcnew.stPcnew_Pcnew[classtype].STR_UP;
            case ESTATNAME.STAT_DEX:
                return NXLData.pcnew.stPcnew_Pcnew[classtype].DEX_UP;
            case ESTATNAME.STAT_CON:
                return NXLData.pcnew.stPcnew_Pcnew[classtype].CON_UP;
            case ESTATNAME.STAT_SPI:
                return NXLData.pcnew.stPcnew_Pcnew[classtype].SPI_UP;
            }

            Console.WriteLine("Unknown statname: " + statname);
            return 0;
        }
    }
}