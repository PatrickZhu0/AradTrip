using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001248 RID: 4680
	public class EquipPlanDataModel
	{
		// Token: 0x04006569 RID: 25961
		public ulong Guid;

		// Token: 0x0400656A RID: 25962
		public EquipSchemeType EquipPlanType;

		// Token: 0x0400656B RID: 25963
		public uint EquipPlanId;

		// Token: 0x0400656C RID: 25964
		public bool IsWear;

		// Token: 0x0400656D RID: 25965
		public List<ulong> EquipItemGuidList = new List<ulong>();
	}
}
