using System;

namespace GameClient
{
	// Token: 0x02000F5F RID: 3935
	internal class ExpConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098C0 RID: 39104 RVA: 0x001D5BB5 File Offset: 0x001D3FB5
		public ExpConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.ExpChanged
			};
		}

		// Token: 0x060098C1 RID: 39105 RVA: 0x001D5BCF File Offset: 0x001D3FCF
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().Exp;
		}

		// Token: 0x060098C2 RID: 39106 RVA: 0x001D5BE1 File Offset: 0x001D3FE1
		public void OnAdd()
		{
		}
	}
}
