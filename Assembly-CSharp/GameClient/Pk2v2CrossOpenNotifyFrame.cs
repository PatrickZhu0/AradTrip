using System;

namespace GameClient
{
	// Token: 0x020019A5 RID: 6565
	public class Pk2v2CrossOpenNotifyFrame : GameFrame
	{
		// Token: 0x0600FFD2 RID: 65490 RVA: 0x0046E67B File Offset: 0x0046CA7B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk2v2Cross/Pk2v2CrossOpenNotify";
		}

		// Token: 0x0600FFD3 RID: 65491 RVA: 0x0046E682 File Offset: 0x0046CA82
		protected override void OnOpenFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x0600FFD4 RID: 65492 RVA: 0x0046E68F File Offset: 0x0046CA8F
		protected override void OnCloseFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x0600FFD5 RID: 65493 RVA: 0x0046E69C File Offset: 0x0046CA9C
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FFD6 RID: 65494 RVA: 0x0046E69F File Offset: 0x0046CA9F
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElasped += timeElapsed;
			if (this.fTimeElasped >= 3f)
			{
				this.frameMgr.CloseFrame<Pk2v2CrossOpenNotifyFrame>(this, false);
				this.fTimeElasped = 0f;
			}
		}

		// Token: 0x0400A15A RID: 41306
		private float fTimeElasped;
	}
}
