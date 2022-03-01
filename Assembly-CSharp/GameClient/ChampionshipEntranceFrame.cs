using System;

namespace GameClient
{
	// Token: 0x020014DD RID: 5341
	public class ChampionshipEntranceFrame : ClientFrame
	{
		// Token: 0x0600CF34 RID: 53044 RVA: 0x003323B4 File Offset: 0x003307B4
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Entrance/ChampionshipEntranceFrame";
		}

		// Token: 0x0600CF35 RID: 53045 RVA: 0x003323BB File Offset: 0x003307BB
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChampionshipEntranceView != null)
			{
				this.mChampionshipEntranceView.InitView();
			}
		}

		// Token: 0x0600CF36 RID: 53046 RVA: 0x003323DF File Offset: 0x003307DF
		protected override void _OnCloseFrame()
		{
			DataManager<ChampionshipDataManager>.GetInstance().ResetTotalFightRaceAndTopPlayerDataModel();
		}

		// Token: 0x0600CF37 RID: 53047 RVA: 0x003323EB File Offset: 0x003307EB
		protected override void _bindExUI()
		{
			this.mChampionshipEntranceView = this.mBind.GetCom<ChampionshipEntranceView>("ChampionshipEntranceView");
		}

		// Token: 0x0600CF38 RID: 53048 RVA: 0x00332403 File Offset: 0x00330803
		protected override void _unbindExUI()
		{
			this.mChampionshipEntranceView = null;
		}

		// Token: 0x04007922 RID: 31010
		private ChampionshipEntranceView mChampionshipEntranceView;
	}
}
