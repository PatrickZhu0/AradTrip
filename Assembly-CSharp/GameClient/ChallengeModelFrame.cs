using System;

namespace GameClient
{
	// Token: 0x020014D6 RID: 5334
	public class ChallengeModelFrame : ClientFrame
	{
		// Token: 0x0600CEDF RID: 52959 RVA: 0x0033088F File Offset: 0x0032EC8F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Challenge/ChallengeModelFrame";
		}

		// Token: 0x0600CEE0 RID: 52960 RVA: 0x00330896 File Offset: 0x0032EC96
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChallengeModelView != null)
			{
				this.mChallengeModelView.InitView();
			}
		}

		// Token: 0x0600CEE1 RID: 52961 RVA: 0x003308BA File Offset: 0x0032ECBA
		protected override void _bindExUI()
		{
			this.mChallengeModelView = this.mBind.GetCom<ChallengeModelView>("ChallengeModelView");
		}

		// Token: 0x0600CEE2 RID: 52962 RVA: 0x003308D2 File Offset: 0x0032ECD2
		protected override void _unbindExUI()
		{
			this.mChallengeModelView = null;
		}

		// Token: 0x040078E1 RID: 30945
		private ChallengeModelView mChallengeModelView;
	}
}
