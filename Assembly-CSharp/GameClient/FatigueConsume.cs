using System;

namespace GameClient
{
	// Token: 0x02000F6A RID: 3946
	internal class FatigueConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098E0 RID: 39136 RVA: 0x001D620E File Offset: 0x001D460E
		public FatigueConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.FatigueChanged
			};
		}

		// Token: 0x060098E1 RID: 39137 RVA: 0x001D6228 File Offset: 0x001D4628
		public void OnChange()
		{
			base.cnt = (ulong)DataManager<PlayerBaseData>.GetInstance().fatigue;
		}

		// Token: 0x060098E2 RID: 39138 RVA: 0x001D623B File Offset: 0x001D463B
		public void OnAdd()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<ComsumeFatigueAddFrame>(FrameLayer.Middle, null, string.Empty);
		}
	}
}
