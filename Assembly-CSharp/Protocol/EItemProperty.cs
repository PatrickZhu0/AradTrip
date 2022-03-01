﻿using System;

namespace Protocol
{
	// Token: 0x02000630 RID: 1584
	public enum EItemProperty
	{
		// Token: 0x04001EDB RID: 7899
		EP_INVALID,
		// Token: 0x04001EDC RID: 7900
		EP_NUM,
		// Token: 0x04001EDD RID: 7901
		EP_BIND,
		// Token: 0x04001EDE RID: 7902
		EP_PACK,
		// Token: 0x04001EDF RID: 7903
		EP_GRID,
		// Token: 0x04001EE0 RID: 7904
		EP_PHY_ATK,
		// Token: 0x04001EE1 RID: 7905
		EP_MAG_ATK,
		// Token: 0x04001EE2 RID: 7906
		EP_PHY_DEF,
		// Token: 0x04001EE3 RID: 7907
		EP_MAG_DEF,
		// Token: 0x04001EE4 RID: 7908
		EP_STR,
		// Token: 0x04001EE5 RID: 7909
		EP_STAMINA,
		// Token: 0x04001EE6 RID: 7910
		EP_INTELLECT,
		// Token: 0x04001EE7 RID: 7911
		EP_SPIRIT,
		// Token: 0x04001EE8 RID: 7912
		EP_QUALITYLV,
		// Token: 0x04001EE9 RID: 7913
		EP_QUALITY,
		// Token: 0x04001EEA RID: 7914
		EP_STRENGTHEN,
		// Token: 0x04001EEB RID: 7915
		EP_RANDATTR,
		// Token: 0x04001EEC RID: 7916
		EP_DAYUSENUM,
		// Token: 0x04001EED RID: 7917
		EP_ADDMAGIC,
		// Token: 0x04001EEE RID: 7918
		EP_PARAM1,
		// Token: 0x04001EEF RID: 7919
		EP_PARAM2,
		// Token: 0x04001EF0 RID: 7920
		EP_POWER,
		// Token: 0x04001EF1 RID: 7921
		EP_DEADLINE,
		// Token: 0x04001EF2 RID: 7922
		EP_PRICE,
		// Token: 0x04001EF3 RID: 7923
		EP_STRFAILED,
		// Token: 0x04001EF4 RID: 7924
		EP_SEAL_STATE,
		// Token: 0x04001EF5 RID: 7925
		EP_SEAL_COUNT,
		// Token: 0x04001EF6 RID: 7926
		EP_DIS_PHYATK,
		// Token: 0x04001EF7 RID: 7927
		EP_DIS_MAGATK,
		// Token: 0x04001EF8 RID: 7928
		EP_DIS_PHYDEF,
		// Token: 0x04001EF9 RID: 7929
		EP_DIS_MAGDEF,
		// Token: 0x04001EFA RID: 7930
		EP_VALUE_SCORE = 35,
		// Token: 0x04001EFB RID: 7931
		EP_IA_FASHION_ATTRID = 37,
		// Token: 0x04001EFC RID: 7932
		EP_FASHION_ATTR_SELNUM,
		// Token: 0x04001EFD RID: 7933
		EP_PHYDEF_PERCENT,
		// Token: 0x04001EFE RID: 7934
		EP_MAGDEF_PERCENT,
		// Token: 0x04001EFF RID: 7935
		EP_ADDBEAD,
		// Token: 0x04001F00 RID: 7936
		EP_STRPROP_LIGHT,
		// Token: 0x04001F01 RID: 7937
		EP_STRPROP_FIRE,
		// Token: 0x04001F02 RID: 7938
		EP_STRPROP_ICE,
		// Token: 0x04001F03 RID: 7939
		EP_STRPROP_DARK,
		// Token: 0x04001F04 RID: 7940
		EP_DEFPROP_LIGHT,
		// Token: 0x04001F05 RID: 7941
		EP_DEFPROP_FIRE,
		// Token: 0x04001F06 RID: 7942
		EP_DEFPROP_ICE,
		// Token: 0x04001F07 RID: 7943
		EP_DEFPROP_DARK,
		// Token: 0x04001F08 RID: 7944
		EP_ABNORMAL_RESISTS_TOTAL,
		// Token: 0x04001F09 RID: 7945
		EP_EAR_FLASH,
		// Token: 0x04001F0A RID: 7946
		EP_EAR_BLEEDING,
		// Token: 0x04001F0B RID: 7947
		EP_EAR_BURN,
		// Token: 0x04001F0C RID: 7948
		EP_EAR_POISON,
		// Token: 0x04001F0D RID: 7949
		EP_EAR_BLIND,
		// Token: 0x04001F0E RID: 7950
		EP_EAR_STUN,
		// Token: 0x04001F0F RID: 7951
		EP_EAR_STONE,
		// Token: 0x04001F10 RID: 7952
		EP_EAR_FROZEN,
		// Token: 0x04001F11 RID: 7953
		EP_EAR_SLEEP,
		// Token: 0x04001F12 RID: 7954
		EP_EAR_CONFUNSE,
		// Token: 0x04001F13 RID: 7955
		EP_EAR_STRAIN,
		// Token: 0x04001F14 RID: 7956
		EP_EAR_SPEED_DOWN,
		// Token: 0x04001F15 RID: 7957
		EP_EAR_CURSE,
		// Token: 0x04001F16 RID: 7958
		EP_TRANSFER_STONE,
		// Token: 0x04001F17 RID: 7959
		EP_RECO_SCORE,
		// Token: 0x04001F18 RID: 7960
		EP_LOCK_ITEM,
		// Token: 0x04001F19 RID: 7961
		EP_PRECIOUSBEAD_HOLES,
		// Token: 0x04001F1A RID: 7962
		EP_AUCTION_COOL_TIMESTAMP,
		// Token: 0x04001F1B RID: 7963
		EP_IS_TREAS,
		// Token: 0x04001F1C RID: 7964
		EP_BEAD_EXTIRPE_CNT,
		// Token: 0x04001F1D RID: 7965
		EP_BEAD_REPLACE_CNT,
		// Token: 0x04001F1E RID: 7966
		EP_TABLE_ID,
		// Token: 0x04001F1F RID: 7967
		EP_EQUIP_TYPE,
		// Token: 0x04001F20 RID: 7968
		EP_ENHANCE_TYPE,
		// Token: 0x04001F21 RID: 7969
		EP_ENHANCE_NUM,
		// Token: 0x04001F22 RID: 7970
		EP_ENHANCE_FAILED,
		// Token: 0x04001F23 RID: 7971
		EA_AUCTION_TRANS_NUM,
		// Token: 0x04001F24 RID: 7972
		EP_INSCRIPTION_HOLES,
		// Token: 0x04001F25 RID: 7973
		EP_INDEPENDATK,
		// Token: 0x04001F26 RID: 7974
		EP_INDEPENDATK_STRENG,
		// Token: 0x04001F27 RID: 7975
		EP_SUBTYPE
	}
}