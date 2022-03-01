using System;

namespace GameClient
{
	// Token: 0x020019A4 RID: 6564
	public class Pk2v2CrossMatchStartNotifyFrame : GameFrame
	{
		// Token: 0x0600FFCC RID: 65484 RVA: 0x0046E617 File Offset: 0x0046CA17
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk2v2Cross/Pk2v2CrossMatchStartNotify";
		}

		// Token: 0x0600FFCD RID: 65485 RVA: 0x0046E61E File Offset: 0x0046CA1E
		protected override void OnOpenFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x0600FFCE RID: 65486 RVA: 0x0046E62B File Offset: 0x0046CA2B
		protected override void OnCloseFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x0600FFCF RID: 65487 RVA: 0x0046E638 File Offset: 0x0046CA38
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FFD0 RID: 65488 RVA: 0x0046E63B File Offset: 0x0046CA3B
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElasped += timeElapsed;
			if (this.fTimeElasped >= 3f)
			{
				this.frameMgr.CloseFrame<Pk2v2CrossMatchStartNotifyFrame>(this, false);
				this.fTimeElasped = 0f;
			}
		}

		// Token: 0x0400A159 RID: 41305
		private float fTimeElasped;
	}
}
