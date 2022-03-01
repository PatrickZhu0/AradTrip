using System;

namespace GameClient
{
	// Token: 0x020014E4 RID: 5348
	public class ChampionshipBigRewardPreviewFrame : ClientFrame
	{
		// Token: 0x0600CF86 RID: 53126 RVA: 0x003337DC File Offset: 0x00331BDC
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Entrance/ChampionshipBigRewardPreviewFrame";
		}

		// Token: 0x0600CF87 RID: 53127 RVA: 0x003337E4 File Offset: 0x00331BE4
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			int scheduleId = (int)this.userData;
			if (this.mChampionshipBigRewardPreviewView != null)
			{
				this.mChampionshipBigRewardPreviewView.Init(scheduleId);
			}
		}

		// Token: 0x0600CF88 RID: 53128 RVA: 0x00333820 File Offset: 0x00331C20
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600CF89 RID: 53129 RVA: 0x00333822 File Offset: 0x00331C22
		protected override void _bindExUI()
		{
			this.mChampionshipBigRewardPreviewView = this.mBind.GetCom<ChampionshipBigRewardPreviewView>("ChampionshipBigRewardPreviewView");
		}

		// Token: 0x0600CF8A RID: 53130 RVA: 0x0033383A File Offset: 0x00331C3A
		protected override void _unbindExUI()
		{
			this.mChampionshipBigRewardPreviewView = null;
		}

		// Token: 0x04007961 RID: 31073
		private ChampionshipBigRewardPreviewView mChampionshipBigRewardPreviewView;
	}
}
