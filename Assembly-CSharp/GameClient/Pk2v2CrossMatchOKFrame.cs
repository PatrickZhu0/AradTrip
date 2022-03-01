using System;

namespace GameClient
{
	// Token: 0x020019A3 RID: 6563
	public class Pk2v2CrossMatchOKFrame : GameFrame
	{
		// Token: 0x0600FFC6 RID: 65478 RVA: 0x0046E5B3 File Offset: 0x0046C9B3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk2v2Cross/Pk2v2CrossMatchOK";
		}

		// Token: 0x0600FFC7 RID: 65479 RVA: 0x0046E5BA File Offset: 0x0046C9BA
		protected override void OnOpenFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x0600FFC8 RID: 65480 RVA: 0x0046E5C7 File Offset: 0x0046C9C7
		protected override void OnCloseFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x0600FFC9 RID: 65481 RVA: 0x0046E5D4 File Offset: 0x0046C9D4
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FFCA RID: 65482 RVA: 0x0046E5D7 File Offset: 0x0046C9D7
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElasped += timeElapsed;
			if (this.fTimeElasped >= 3f)
			{
				this.frameMgr.CloseFrame<Pk2v2CrossMatchOKFrame>(this, false);
				this.fTimeElasped = 0f;
			}
		}

		// Token: 0x0400A158 RID: 41304
		private float fTimeElasped;
	}
}
