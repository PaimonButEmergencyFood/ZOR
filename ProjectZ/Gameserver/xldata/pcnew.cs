namespace NXLData {
    class pcnew {
        public const int PCNEW_PCNEW_MAX = 5;
        public struct PCNEW_PCNEW
        {
            public string	CLASS_KOR; // [26*2]
            public string	CLASS_ENG;
            public string	CLASS_JPG;
            public string	NAME_KOR;
            public string	NAME_ENG;
            public string	NAME_JPG;
            public string	ENEMY_NAME_KOR; // [28*2]
            public string	ENEMY_NAME_ENG;
            public string	ENEMY_NAME_JPG;
            public int	MAX_COMBO;
            public int	NUM_FINAL_ATTACK;
            public int	RES_KNOCK_RATE;
            public int	STR_NEW;
            public int	DEX_NEW;
            public int	CON_NEW;
            public int	SPI_NEW;
            public int	STR_UP;
            public int	DEX_UP;
            public int	CON_UP;
            public int	SPI_UP;
            public int	FAIRY_ELE;
            public int	FAIRY_SKILL;
        }

        public static PCNEW_PCNEW[] stPcnew_Pcnew = new PCNEW_PCNEW[PCNEW_PCNEW_MAX] {
            new PCNEW_PCNEW {
                CLASS_KOR = "������",
                CLASS_ENG = "SLASHER",
                CLASS_JPG = "�ܫ���",
                NAME_KOR = "���׸�",
                NAME_ENG = "���׸�",
                NAME_JPG = "���׸�",
                ENEMY_NAME_KOR = "���׸��� ȯ��",
                ENEMY_NAME_ENG = "���׸��� ȯ��",
                ENEMY_NAME_JPG = "���׸��� ȯ��",
                MAX_COMBO = 3,
                NUM_FINAL_ATTACK = 1,
                RES_KNOCK_RATE = 0,
                STR_NEW = 14,
                DEX_NEW = 9,
                CON_NEW = 11,
                SPI_NEW = 8,
                STR_UP = 1,
                DEX_UP = 2,
                CON_UP = 2,
                SPI_UP = 3,
                FAIRY_ELE = 0,
                FAIRY_SKILL = 22
            },
            new PCNEW_PCNEW {
                CLASS_KOR = "������",
                CLASS_ENG = "RANGER",
                CLASS_JPG = "�᫫�˫ë�",
                NAME_KOR = "��ũ��",
                NAME_ENG = "��ũ��",
                NAME_JPG = "��ũ��",
                ENEMY_NAME_KOR = "��ũ���� ȯ��",
                ENEMY_NAME_ENG = "��ũ���� ȯ��",
                ENEMY_NAME_JPG = "��ũ���� ȯ��",
                MAX_COMBO = 3,
                NUM_FINAL_ATTACK = 1,
                RES_KNOCK_RATE = 0,
                STR_NEW = 7,
                DEX_NEW = 15,
                CON_NEW = 9,
                SPI_NEW = 11,
                STR_UP = 3,
                DEX_UP = 1,
                CON_UP = 2,
                SPI_UP = 2,
                FAIRY_ELE = 1,
                FAIRY_SKILL = 23
            },
            new PCNEW_PCNEW {
                CLASS_KOR = "������",
                CLASS_ENG = "FIGHTER",
                CLASS_JPG = "������",
                NAME_KOR = "����",
                NAME_ENG = "����",
                NAME_JPG = "����",
                ENEMY_NAME_KOR = "������ ȯ��",
                ENEMY_NAME_ENG = "������ ȯ��",
                ENEMY_NAME_JPG = "������ ȯ��",
                MAX_COMBO = 3,
                NUM_FINAL_ATTACK = 1,
                RES_KNOCK_RATE = 0,
                STR_NEW = 13,
                DEX_NEW = 10,
                CON_NEW = 13,
                SPI_NEW = 6,
                STR_UP = 2,
                DEX_UP = 2,
                CON_UP = 1,
                SPI_UP = 3,
                FAIRY_ELE = 2,
                FAIRY_SKILL = 22
            },
            new PCNEW_PCNEW {
                CLASS_KOR = "������",
                CLASS_ENG = "MAGICIAN",
                CLASS_JPG = "������",
                NAME_KOR = "��",
                NAME_ENG = "��",
                NAME_JPG = "��",
                ENEMY_NAME_KOR = "���� ȯ��",
                ENEMY_NAME_ENG = "���� ȯ��",
                ENEMY_NAME_JPG = "���� ȯ��",
                MAX_COMBO = 3,
                NUM_FINAL_ATTACK = 1,
                RES_KNOCK_RATE = 0,
                STR_NEW = 8,
                DEX_NEW = 9,
                CON_NEW = 9,
                SPI_NEW = 16,
                STR_UP = 3,
                DEX_UP = 2,
                CON_UP = 2,
                SPI_UP = 1,
                FAIRY_ELE = 3,
                FAIRY_SKILL = 25
            },
            new PCNEW_PCNEW {
                CLASS_KOR = "��ؽ�",
                CLASS_ENG = "ASSASSIN",
                CLASS_JPG = "�ѫ��ǫ���",
                NAME_KOR = "��",
                NAME_ENG = "��",
                NAME_JPG = "��",
                ENEMY_NAME_KOR = "���� ȯ��",
                ENEMY_NAME_ENG = "���� ȯ��",
                ENEMY_NAME_JPG = "���� ȯ��",
                MAX_COMBO = 3,
                NUM_FINAL_ATTACK = 1,
                RES_KNOCK_RATE = 0,
                STR_NEW = 8,
                DEX_NEW = 14,
                CON_NEW = 10,
                SPI_NEW = 10,
                STR_UP = 3,
                DEX_UP = 1,
                CON_UP = 2,
                SPI_UP = 2,
                FAIRY_ELE = 3,
                FAIRY_SKILL = 23
            }
        };
    }
}