using System;

namespace GameClient
{
	// Token: 0x020019B7 RID: 6583
	public class Pk3v3CrossOpenNotifyFrame : ClientFrame
	{
		// Token: 0x06010146 RID: 65862 RVA: 0x004780BF File Offset: 0x004764BF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossOpenNotify";
		}

		// Token: 0x06010147 RID: 65863 RVA: 0x004780C6 File Offset: 0x004764C6
		protected override void _OnOpenFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x06010148 RID: 65864 RVA: 0x004780D3 File Offset: 0x004764D3
		protected override void _OnCloseFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x06010149 RID: 65865 RVA: 0x004780E0 File Offset: 0x004764E0
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0601014A RID: 65866 RVA: 0x004780E3 File Offset: 0x004764E3
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElasped += timeElapsed;
			if (this.fTimeElasped >= 3f)
			{
				this.frameMgr.CloseFrame<Pk3v3CrossOpenNotifyFrame>(this, false);
				this.fTimeElasped = 0f;
			}
		}

		// Token: 0x0400A251 RID: 41553
		private float fTimeElasped;
	}
}
