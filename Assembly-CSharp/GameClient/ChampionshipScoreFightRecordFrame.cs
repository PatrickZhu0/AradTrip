using System;

namespace GameClient
{
	// Token: 0x02001511 RID: 5393
	public class ChampionshipScoreFightRecordFrame : ClientFrame
	{
		// Token: 0x0600D178 RID: 53624 RVA: 0x0033AD53 File Offset: 0x00339153
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Main/Score/ChampionshipScoreFightRecordFrame";
		}

		// Token: 0x0600D179 RID: 53625 RVA: 0x0033AD5A File Offset: 0x0033915A
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChampionshipScoreFightRecordView != null)
			{
				this.mChampionshipScoreFightRecordView.InitView();
			}
		}

		// Token: 0x0600D17A RID: 53626 RVA: 0x0033AD7E File Offset: 0x0033917E
		protected override void _OnCloseFrame()
		{
			DataManager<ChampionshipDataManager>.GetInstance().ResetScoreFightRecordDataModel();
		}

		// Token: 0x0600D17B RID: 53627 RVA: 0x0033AD8A File Offset: 0x0033918A
		protected override void _bindExUI()
		{
			this.mChampionshipScoreFightRecordView = this.mBind.GetCom<ChampionshipScoreFightRecordView>("ChampionshipScoreFightRecordView");
		}

		// Token: 0x0600D17C RID: 53628 RVA: 0x0033ADA2 File Offset: 0x003391A2
		protected override void _unbindExUI()
		{
			this.mChampionshipScoreFightRecordView = null;
		}

		// Token: 0x04007A98 RID: 31384
		private ChampionshipScoreFightRecordView mChampionshipScoreFightRecordView;
	}
}
