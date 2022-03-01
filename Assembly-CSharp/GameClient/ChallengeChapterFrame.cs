using System;

namespace GameClient
{
	// Token: 0x020014B2 RID: 5298
	public class ChallengeChapterFrame : ClientFrame
	{
		// Token: 0x0600CD4A RID: 52554 RVA: 0x003279FB File Offset: 0x00325DFB
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Challenge/ChallengeChapterFrame";
		}

		// Token: 0x0600CD4B RID: 52555 RVA: 0x00327A04 File Offset: 0x00325E04
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChallengeChapterView != null)
			{
				ChallengeChapterParamDataModel chapterParamDataModel = null;
				if (this.userData != null)
				{
					chapterParamDataModel = (ChallengeChapterParamDataModel)this.userData;
				}
				this.mChallengeChapterView.InitView(chapterParamDataModel);
			}
		}

		// Token: 0x0600CD4C RID: 52556 RVA: 0x00327A4D File Offset: 0x00325E4D
		protected override void _bindExUI()
		{
			this.mChallengeChapterView = this.mBind.GetCom<ChallengeChapterView>("ChallengeChapterView");
		}

		// Token: 0x0600CD4D RID: 52557 RVA: 0x00327A65 File Offset: 0x00325E65
		protected override void _unbindExUI()
		{
			this.mChallengeChapterView = null;
		}

		// Token: 0x040077AD RID: 30637
		private ChallengeChapterView mChallengeChapterView;
	}
}
