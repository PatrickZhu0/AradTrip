using System;

namespace GameClient
{
	// Token: 0x020014EA RID: 5354
	public class ChampionshipFightRaceFrame : ClientFrame
	{
		// Token: 0x0600CFC2 RID: 53186 RVA: 0x00334811 File Offset: 0x00332C11
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Fight/ChampionshipFightRaceFrame";
		}

		// Token: 0x0600CFC3 RID: 53187 RVA: 0x00334818 File Offset: 0x00332C18
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			int scheduleId = (int)this.userData;
			if (this.mChampionshipFightRaceView != null)
			{
				this.mChampionshipFightRaceView.Init(scheduleId);
			}
		}

		// Token: 0x0600CFC4 RID: 53188 RVA: 0x00334854 File Offset: 0x00332C54
		protected override void _OnCloseFrame()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChampionshipEntranceFrame>(null))
			{
				DataManager<ChampionshipDataManager>.GetInstance().ResetTotalFightRaceAndTopPlayerDataModel();
			}
		}

		// Token: 0x0600CFC5 RID: 53189 RVA: 0x00334870 File Offset: 0x00332C70
		protected override void _bindExUI()
		{
			this.mChampionshipFightRaceView = this.mBind.GetCom<ChampionshipFightRaceView>("ChampionshipFightRaceView");
		}

		// Token: 0x0600CFC6 RID: 53190 RVA: 0x00334888 File Offset: 0x00332C88
		protected override void _unbindExUI()
		{
			this.mChampionshipFightRaceView = null;
		}

		// Token: 0x0400798F RID: 31119
		private ChampionshipFightRaceView mChampionshipFightRaceView;
	}
}
