using System;

namespace GameClient
{
	// Token: 0x020012FB RID: 4859
	public class StrengthenTicketFuseSpecialMaterial
	{
		// Token: 0x0600BC56 RID: 48214 RVA: 0x002BEA3D File Offset: 0x002BCE3D
		public StrengthenTicketFuseSpecialMaterial()
		{
			this.Clear();
		}

		// Token: 0x0600BC57 RID: 48215 RVA: 0x002BEA56 File Offset: 0x002BCE56
		public void Clear()
		{
			this.fuseNeedItemData = new ItemSimpleData();
		}

		// Token: 0x040069FC RID: 27132
		public ItemSimpleData fuseNeedItemData = new ItemSimpleData();

		// Token: 0x040069FD RID: 27133
		public int limitStrengthenLevelMin;

		// Token: 0x040069FE RID: 27134
		public int limitStrengthenLevelMax;
	}
}
