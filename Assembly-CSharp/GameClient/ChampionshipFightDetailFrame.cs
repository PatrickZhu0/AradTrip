using System;

namespace GameClient
{
	// Token: 0x020014E7 RID: 5351
	public class ChampionshipFightDetailFrame : ClientFrame
	{
		// Token: 0x0600CFA1 RID: 53153 RVA: 0x00333D66 File Offset: 0x00332166
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Fight/ChampionshipFightDetailFrame";
		}

		// Token: 0x0600CFA2 RID: 53154 RVA: 0x00333D70 File Offset: 0x00332170
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			int fightGroupId = (int)this.userData;
			if (this.mChampionshipFightDetailView != null)
			{
				this.mChampionshipFightDetailView.Init(fightGroupId);
			}
		}

		// Token: 0x0600CFA3 RID: 53155 RVA: 0x00333DAC File Offset: 0x003321AC
		protected override void _OnCloseFrame()
		{
			DataManager<ChampionshipDataManager>.GetInstance().ResetFightDetailRecordData();
		}

		// Token: 0x0600CFA4 RID: 53156 RVA: 0x00333DB8 File Offset: 0x003321B8
		protected override void _bindExUI()
		{
			this.mChampionshipFightDetailView = this.mBind.GetCom<ChampionshipFightDetailView>("ChampionshipFightDetailView");
		}

		// Token: 0x0600CFA5 RID: 53157 RVA: 0x00333DD0 File Offset: 0x003321D0
		protected override void _unbindExUI()
		{
			this.mChampionshipFightDetailView = null;
		}

		// Token: 0x0400796D RID: 31085
		private ChampionshipFightDetailView mChampionshipFightDetailView;
	}
}
