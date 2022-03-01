using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001BB4 RID: 7092
	public class StrengthenResult
	{
		// Token: 0x060115BD RID: 71101 RVA: 0x0050745B File Offset: 0x0050585B
		public static float ToValue(int iIndex, int iValue)
		{
			if (iIndex >= 0 && iIndex < StrengthenResult.convertRate.Length)
			{
				return StrengthenResult.convertRate[iIndex] * (float)iValue;
			}
			return (float)iValue;
		}

		// Token: 0x060115BE RID: 71102 RVA: 0x00507480 File Offset: 0x00505880
		public static string ToDesc(int iIndex, int iValue)
		{
			float num = StrengthenResult.ToValue(iIndex, iValue);
			return string.Format(StrengthenResult.formatString[iIndex], iValue);
		}

		// Token: 0x060115BF RID: 71103 RVA: 0x005074A7 File Offset: 0x005058A7
		public static float GrowthToValue(int iIndex, int iValue)
		{
			if (iIndex >= 0 && iIndex < StrengthenResult.growthConverRate.Length)
			{
				return StrengthenResult.growthConverRate[iIndex] * (float)iValue;
			}
			return (float)iValue;
		}

		// Token: 0x060115C0 RID: 71104 RVA: 0x005074CC File Offset: 0x005058CC
		public static string GrowthToDesc(int iIndex, int iValue)
		{
			float num = StrengthenResult.GrowthToValue(iIndex, iValue);
			return string.Format(StrengthenResult.growthFormatString[iIndex], iValue);
		}

		// Token: 0x0400B406 RID: 46086
		public bool StrengthenSuccess;

		// Token: 0x0400B407 RID: 46087
		public ItemData EquipData;

		// Token: 0x0400B408 RID: 46088
		public List<ItemData> BrokenItems;

		// Token: 0x0400B409 RID: 46089
		public uint code;

		// Token: 0x0400B40A RID: 46090
		public int iStrengthenLevel;

		// Token: 0x0400B40B RID: 46091
		public int iTargetStrengthenLevel;

		// Token: 0x0400B40C RID: 46092
		public int iTableID;

		// Token: 0x0400B40D RID: 46093
		public int[] orgAttr = new int[7];

		// Token: 0x0400B40E RID: 46094
		public int[] curAttr = new int[7];

		// Token: 0x0400B40F RID: 46095
		public int[] growthOrgAttr = new int[8];

		// Token: 0x0400B410 RID: 46096
		public int[] growthCurAttr = new int[8];

		// Token: 0x0400B411 RID: 46097
		public int[] assistEquipStrengthenOrgAttr = new int[4];

		// Token: 0x0400B412 RID: 46098
		public int[] assistEquipStrengthenCurAttr = new int[4];

		// Token: 0x0400B413 RID: 46099
		public int[] assistEquipGrowthOrgAttr = new int[5];

		// Token: 0x0400B414 RID: 46100
		public int[] assistEquipGrowthCurAttr = new int[5];

		// Token: 0x0400B415 RID: 46101
		public static float[] convertRate = new float[]
		{
			1f,
			1f,
			1f,
			1f,
			1f,
			0.01f,
			0.01f
		};

		// Token: 0x0400B416 RID: 46102
		public static string[] formatString = new string[]
		{
			"{0}",
			"{0}",
			"{0}",
			"{0}",
			"{0}",
			"{0:F2}",
			"{0:F2}"
		};

		// Token: 0x0400B417 RID: 46103
		public static float[] growthConverRate = new float[]
		{
			1f,
			1f,
			1f,
			1f,
			1f,
			1f,
			0.01f,
			0.01f
		};

		// Token: 0x0400B418 RID: 46104
		public static string[] growthFormatString = new string[]
		{
			"{0}",
			"{0}",
			"{0}",
			"{0}",
			"{0}",
			"{0}",
			"{0:F2}",
			"{0:F2}"
		};
	}
}
