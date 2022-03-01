using System;

namespace GameClient
{
	// Token: 0x020014F4 RID: 5364
	public class ChampionshipGuessRecordFrame : ClientFrame
	{
		// Token: 0x0600D03C RID: 53308 RVA: 0x003367E5 File Offset: 0x00334BE5
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Guess/Bet/ChampionshipGuessRecordFrame";
		}

		// Token: 0x0600D03D RID: 53309 RVA: 0x003367EC File Offset: 0x00334BEC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChampionshipGuessRecordView != null)
			{
				this.mChampionshipGuessRecordView.InitView();
			}
		}

		// Token: 0x0600D03E RID: 53310 RVA: 0x00336810 File Offset: 0x00334C10
		protected override void _OnCloseFrame()
		{
			DataManager<ChampionshipDataManager>.GetInstance().ResetChampionshipGuessRecordDataModelList();
		}

		// Token: 0x0600D03F RID: 53311 RVA: 0x0033681C File Offset: 0x00334C1C
		protected override void _bindExUI()
		{
			this.mChampionshipGuessRecordView = this.mBind.GetCom<ChampionshipGuessRecordView>("ChampionshipGuessRecordView");
		}

		// Token: 0x0600D040 RID: 53312 RVA: 0x00336834 File Offset: 0x00334C34
		protected override void _unbindExUI()
		{
			this.mChampionshipGuessRecordView = null;
		}

		// Token: 0x040079E6 RID: 31206
		private ChampionshipGuessRecordView mChampionshipGuessRecordView;
	}
}
