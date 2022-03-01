using System;

namespace GameClient
{
	// Token: 0x02001608 RID: 5640
	public class GuildDungeonActivityOpenNotifyFrame : ClientFrame
	{
		// Token: 0x0600DCFD RID: 56573 RVA: 0x0037EF01 File Offset: 0x0037D301
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonActivityOpenNotify";
		}

		// Token: 0x0600DCFE RID: 56574 RVA: 0x0037EF08 File Offset: 0x0037D308
		protected override void _OnOpenFrame()
		{
			this.fTimeElasped = 0f;
		}

		// Token: 0x0600DCFF RID: 56575 RVA: 0x0037EF15 File Offset: 0x0037D315
		protected override void _OnCloseFrame()
		{
			this.fTimeElasped = 0f;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<JoinGuildDungeonActivityFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DD00 RID: 56576 RVA: 0x0037EF34 File Offset: 0x0037D334
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0600DD01 RID: 56577 RVA: 0x0037EF37 File Offset: 0x0037D337
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElasped += timeElapsed;
			if (this.fTimeElasped >= 3f)
			{
				this.frameMgr.CloseFrame<GuildDungeonActivityOpenNotifyFrame>(this, false);
				this.fTimeElasped = 0f;
			}
		}

		// Token: 0x0400828E RID: 33422
		private float fTimeElasped;
	}
}
