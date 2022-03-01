using System;

namespace GameClient
{
	// Token: 0x02001CA6 RID: 7334
	public class TeamDuplicationGameResultFrame : ClientFrame
	{
		// Token: 0x06012007 RID: 73735 RVA: 0x0054343B File Offset: 0x0054183B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Result/TeamDuplicationGameResultFrame";
		}

		// Token: 0x06012008 RID: 73736 RVA: 0x00543444 File Offset: 0x00541844
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationGameResultView != null)
			{
				bool isSuccess = (bool)this.userData;
				this.mTeamDuplicationGameResultView.Init(isSuccess);
			}
		}

		// Token: 0x06012009 RID: 73737 RVA: 0x00543480 File Offset: 0x00541880
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			bool flag = (bool)this.userData;
			if (flag)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFinalResultCloseMessage, null, null, null, null);
			}
		}

		// Token: 0x0601200A RID: 73738 RVA: 0x005434B8 File Offset: 0x005418B8
		protected override void _bindExUI()
		{
			this.mTeamDuplicationGameResultView = this.mBind.GetCom<TeamDuplicationGameResultView>("TeamDuplicationGameResultView");
		}

		// Token: 0x0601200B RID: 73739 RVA: 0x005434D0 File Offset: 0x005418D0
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationGameResultView = null;
		}

		// Token: 0x0400BBA6 RID: 48038
		private TeamDuplicationGameResultView mTeamDuplicationGameResultView;
	}
}
