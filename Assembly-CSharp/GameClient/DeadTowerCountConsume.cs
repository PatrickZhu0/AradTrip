using System;

namespace GameClient
{
	// Token: 0x02000F67 RID: 3943
	internal class DeadTowerCountConsume : BaseActivityConsume
	{
		// Token: 0x060098DA RID: 39130 RVA: 0x001D6197 File Offset: 0x001D4597
		public DeadTowerCountConsume(int id) : base(id, null)
		{
			this.mData = new DeadTowerActivityConsumeData(id);
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnCountValueChange
			};
		}

		// Token: 0x060098DB RID: 39131 RVA: 0x001D61C1 File Offset: 0x001D45C1
		public new void OnAdd()
		{
		}
	}
}
