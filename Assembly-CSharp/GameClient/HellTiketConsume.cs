using System;

namespace GameClient
{
	// Token: 0x02000F69 RID: 3945
	internal class HellTiketConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098DD RID: 39133 RVA: 0x001D61ED File Offset: 0x001D45ED
		public HellTiketConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnCountValueChange
			};
		}

		// Token: 0x060098DE RID: 39134 RVA: 0x001D620A File Offset: 0x001D460A
		public void OnChange()
		{
		}

		// Token: 0x060098DF RID: 39135 RVA: 0x001D620C File Offset: 0x001D460C
		public void OnAdd()
		{
		}
	}
}
