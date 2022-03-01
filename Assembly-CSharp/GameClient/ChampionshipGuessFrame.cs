using System;

namespace GameClient
{
	// Token: 0x020014F9 RID: 5369
	public class ChampionshipGuessFrame : ClientFrame
	{
		// Token: 0x0600D063 RID: 53347 RVA: 0x00336ED2 File Offset: 0x003352D2
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Guess/ChampionshipGuessFrame";
		}

		// Token: 0x0600D064 RID: 53348 RVA: 0x00336ED9 File Offset: 0x003352D9
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChampionshipGuessView != null)
			{
				this.mChampionshipGuessView.InitView();
			}
		}

		// Token: 0x0600D065 RID: 53349 RVA: 0x00336EFD File Offset: 0x003352FD
		protected override void _OnCloseFrame()
		{
			DataManager<ChampionshipDataManager>.GetInstance().ResetChampionshipGuessProjectData();
		}

		// Token: 0x0600D066 RID: 53350 RVA: 0x00336F09 File Offset: 0x00335309
		protected override void _bindExUI()
		{
			this.mChampionshipGuessView = this.mBind.GetCom<ChampionshipGuessView>("ChampionshipGuessView");
		}

		// Token: 0x0600D067 RID: 53351 RVA: 0x00336F21 File Offset: 0x00335321
		protected override void _unbindExUI()
		{
			this.mChampionshipGuessView = null;
		}

		// Token: 0x040079FC RID: 31228
		private ChampionshipGuessView mChampionshipGuessView;
	}
}
