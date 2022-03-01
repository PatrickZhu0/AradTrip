using System;

namespace GameClient
{
	// Token: 0x02001B65 RID: 7013
	internal class StrengthenAttributeItemData
	{
		// Token: 0x060112E7 RID: 70375 RVA: 0x004F01BD File Offset: 0x004EE5BD
		public string ToValueDesc()
		{
			return string.Format(this.valueFormat, this.iCurValue);
		}

		// Token: 0x060112E8 RID: 70376 RVA: 0x004F01D5 File Offset: 0x004EE5D5
		public string ToValueDesc(string valueFormat, float iValue)
		{
			return string.Format(valueFormat, iValue);
		}

		// Token: 0x0400B15F RID: 45407
		public string kDesc;

		// Token: 0x0400B160 RID: 45408
		public float iCurValue;

		// Token: 0x0400B161 RID: 45409
		public float iMaxValue;

		// Token: 0x0400B162 RID: 45410
		public string valueFormat = string.Empty;

		// Token: 0x0400B163 RID: 45411
		public bool bIsSpecialItem;
	}
}
