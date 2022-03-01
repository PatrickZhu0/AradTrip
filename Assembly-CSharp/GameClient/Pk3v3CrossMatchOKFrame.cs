using System;

namespace GameClient
{
	// Token: 0x020019B2 RID: 6578
	public class Pk3v3CrossMatchOKFrame : ClientFrame
	{
		// Token: 0x06010110 RID: 65808 RVA: 0x00476B71 File Offset: 0x00474F71
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossMatchOK";
		}

		// Token: 0x06010111 RID: 65809 RVA: 0x00476B78 File Offset: 0x00474F78
		protected override void _OnOpenFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x06010112 RID: 65810 RVA: 0x00476B85 File Offset: 0x00474F85
		protected override void _OnCloseFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x06010113 RID: 65811 RVA: 0x00476B92 File Offset: 0x00474F92
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06010114 RID: 65812 RVA: 0x00476B95 File Offset: 0x00474F95
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElasped += timeElapsed;
			if (this.fTimeElasped >= 3f)
			{
				this.frameMgr.CloseFrame<Pk3v3CrossMatchOKFrame>(this, false);
				this.fTimeElasped = 0f;
			}
		}

		// Token: 0x0400A233 RID: 41523
		private float fTimeElasped;
	}
}
