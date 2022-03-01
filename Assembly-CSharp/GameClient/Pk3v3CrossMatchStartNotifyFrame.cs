using System;

namespace GameClient
{
	// Token: 0x020019B3 RID: 6579
	public class Pk3v3CrossMatchStartNotifyFrame : ClientFrame
	{
		// Token: 0x06010116 RID: 65814 RVA: 0x00476BD5 File Offset: 0x00474FD5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossMatchStartNotify";
		}

		// Token: 0x06010117 RID: 65815 RVA: 0x00476BDC File Offset: 0x00474FDC
		protected override void _OnOpenFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x06010118 RID: 65816 RVA: 0x00476BE9 File Offset: 0x00474FE9
		protected override void _OnCloseFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x06010119 RID: 65817 RVA: 0x00476BF6 File Offset: 0x00474FF6
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0601011A RID: 65818 RVA: 0x00476BF9 File Offset: 0x00474FF9
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElasped += timeElapsed;
			if (this.fTimeElasped >= 3f)
			{
				this.frameMgr.CloseFrame<Pk3v3CrossMatchStartNotifyFrame>(this, false);
				this.fTimeElasped = 0f;
			}
		}

		// Token: 0x0400A234 RID: 41524
		private float fTimeElasped;
	}
}
