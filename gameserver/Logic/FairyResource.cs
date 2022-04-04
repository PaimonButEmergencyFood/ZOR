using ProjectZ.Logic;

namespace ProjectZ {
    public class FairyResource {
        public static void SetBaseFairyInfo(Item item, int classType) {
            int fairyType = 0;
            item.EffType[0] = 1;
            item.Tid = (fairyType * 4) + item.EffType[0];
            item.Level = 1;
            item.Quality = 1;
            item.ClassType = -1;
            item.BagType = (int)INVEN_BAG_TYPE.BAG_TYPE_FAIRY;
            item.SubType = (int)EnumClassItemTableType.CLASS_ITEM_TABLE_FAIRY;
            item.EffPos[0] = 2;

            item.EffValue[0] = new Random().Next((int)EnumBalance.EM_FAIRY_PASSIVE_TID_MIN, (int)EnumBalance.EM_FAIRY_PASSIVE_TID_MAX);

            item.EffPos[1] = 1;

            item.EffValue[1] = 7;

            switch (item.EffValue[0]) {
                case 0:
                    item.EffValue[2] = 7;
                    item.EffValue[3] = 1;
                    item.EffValue[4] = 1;
                    item.EffValue[5] = 1;
                    break;
                case 1:
                    item.EffValue[2] = 1;
                    item.EffValue[3] = 7;
                    item.EffValue[4] = 1;
                    item.EffValue[5] = 1;
                    break;
                case 2:
                    item.EffValue[2] = 1;
                    item.EffValue[3] = 1;
                    item.EffValue[4] = 7;
                    item.EffValue[5] = 1;
                    break;
                case 3:
                    item.EffValue[2] = 1;
                    item.EffValue[3] = 1;
                    item.EffValue[4] = 1;
                    item.EffValue[5] = 7;
                    break;
            }

            item.EvolvePoint = -1;
            item.EvolvePercent = -1;
        }
    }
}