using System;

namespace GameClient
{
	// Token: 0x020014F2 RID: 5362
	public class ChampionshipGuessBetFrame : ClientFrame
	{
		// Token: 0x0600D01B RID: 53275 RVA: 0x00335B6B File Offset: 0x00333F6B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Guess/Bet/ChampionshipGuessBetFrame";
		}

		// Token: 0x0600D01C RID: 53276 RVA: 0x00335B74 File Offset: 0x00333F74
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			ChampionshipGuessBetDataModel championshipGuessBetDataModel = this.userData as ChampionshipGuessBetDataModel;
			uint projectId = 0U;
			ulong guessOptionId = 0UL;
			if (championshipGuessBetDataModel != null)
			{
				projectId = championshipGuessBetDataModel.ProjectId;
				guessOptionId = championshipGuessBetDataModel.GuessOptionId;
			}
			if (this.mChampionshipGuessBetView != null)
			{
				this.mChampionshipGuessBetView.InitView(projectId, guessOptionId);
			}
		}

		// Token: 0x0600D01D RID: 53277 RVA: 0x00335BCA File Offset: 0x00333FCA
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600D01E RID: 53278 RVA: 0x00335BCC File Offset: 0x00333FCC
		protected override void _bindExUI()
		{
			this.mChampionshipGuessBetView = this.mBind.GetCom<ChampionshipGuessBetView>("ChampionshipGuessBetView");
		}

		// Token: 0x0600D01F RID: 53279 RVA: 0x00335BE4 File Offset: 0x00333FE4
		protected override void _unbindExUI()
		{
			this.mChampionshipGuessBetView = null;
		}

		// Token: 0x040079C9 RID: 31177
		private ChampionshipGuessBetView mChampionshipGuessBetView;
	}
}
