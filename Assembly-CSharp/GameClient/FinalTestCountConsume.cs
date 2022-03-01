using System;

namespace GameClient
{
	// Token: 0x02000F68 RID: 3944
	internal class FinalTestCountConsume : BaseActivityConsume
	{
		// Token: 0x060098DC RID: 39132 RVA: 0x001D61C3 File Offset: 0x001D45C3
		public FinalTestCountConsume(int id) : base(id, null)
		{
			this.mData = new FinalTestActivityConsumeData(id);
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnCountValueChange
			};
		}
	}
}
