using System;

namespace GameClient
{
	// Token: 0x0200456E RID: 17774
	internal class DevelopGuidanceManager : DataManager<DevelopGuidanceManager>
	{
		// Token: 0x06018CB3 RID: 101555 RVA: 0x007BEF60 File Offset: 0x007BD360
		public void TryOpenGuidanceEntranceFrame()
		{
			if (!this.m_bNeedOpen)
			{
				return;
			}
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
			{
				return;
			}
			this.m_bNeedOpen = false;
			if (DataManager<PlayerBaseData>.GetInstance().Level < 15)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<DevelopGuidanceEntranceFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06018CB4 RID: 101556 RVA: 0x007BEFBB File Offset: 0x007BD3BB
		public void SignalGuidanceEntrace()
		{
			this.m_bNeedOpen = true;
			this.TryOpenGuidanceEntranceFrame();
		}

		// Token: 0x06018CB5 RID: 101557 RVA: 0x007BEFCA File Offset: 0x007BD3CA
		public override void Initialize()
		{
		}

		// Token: 0x06018CB6 RID: 101558 RVA: 0x007BEFCC File Offset: 0x007BD3CC
		public override void Clear()
		{
			this.m_bNeedOpen = false;
		}

		// Token: 0x06018CB7 RID: 101559 RVA: 0x007BEFD5 File Offset: 0x007BD3D5
		public override void OnApplicationStart()
		{
		}

		// Token: 0x06018CB8 RID: 101560 RVA: 0x007BEFD7 File Offset: 0x007BD3D7
		public override void OnApplicationQuit()
		{
		}

		// Token: 0x04011DE0 RID: 73184
		private bool m_bNeedOpen;
	}
}
