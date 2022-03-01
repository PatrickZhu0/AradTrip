using System;
using Protocol;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017F2 RID: 6130
	internal class MoneyRewardsWinFrame : ClientFrame
	{
		// Token: 0x0600F19D RID: 61853 RVA: 0x0041254A File Offset: 0x0041094A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MoneyRewards/MoneyRewardsWin";
		}

		// Token: 0x0600F19E RID: 61854 RVA: 0x00412551 File Offset: 0x00410951
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600F19F RID: 61855 RVA: 0x0041255F File Offset: 0x0041095F
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600F1A0 RID: 61856 RVA: 0x0041256D File Offset: 0x0041096D
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600F1A1 RID: 61857 RVA: 0x0041256F File Offset: 0x0041096F
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600F1A2 RID: 61858 RVA: 0x00412574 File Offset: 0x00410974
		private void _InitUI()
		{
			WorldPremiumLeagueRaceEnd worldPremiumLeagueRaceEnd = this.userData as WorldPremiumLeagueRaceEnd;
			this.m_labTotalScore.text = worldPremiumLeagueRaceEnd.newScore.ToString();
			this.m_labDeltaScore.text = (worldPremiumLeagueRaceEnd.newScore - worldPremiumLeagueRaceEnd.oldScore).ToString();
			this.m_labGlory.text = worldPremiumLeagueRaceEnd.getHonor.ToString();
			if (null != this.comState)
			{
				MoneyRewardsStatus eMoneyRewardsStatus = DataManager<MoneyRewardsDataManager>.GetInstance().eMoneyRewardsStatus;
				switch (eMoneyRewardsStatus + 1)
				{
				case MoneyRewardsStatus.MRS_READY:
				case MoneyRewardsStatus.MRS_8_RACE:
				case MoneyRewardsStatus.MRS_PRE_4_RACE:
				case MoneyRewardsStatus.MRS_4_RACE:
				case (MoneyRewardsStatus)7:
					this.comState.Key = "need_score";
					if (worldPremiumLeagueRaceEnd.preliminayRewardNum > 0U)
					{
						if (null != this.scoreStatus)
						{
							this.scoreStatus.Key = "get";
						}
						if (null != this.m_getScore && null != this.comVsSetting)
						{
							this.m_getScore.text = string.Format(this.comVsSetting.FmtString0, worldPremiumLeagueRaceEnd.preliminayRewardNum);
						}
					}
					else
					{
						if (null != this.scoreStatus)
						{
							this.scoreStatus.Key = "full";
						}
						if (null != this.m_fullScore && null != this.comVsSetting)
						{
							this.m_fullScore.text = string.Format(this.comVsSetting.FmtString1, DataManager<MoneyRewardsDataManager>.GetInstance().MaxAwardEachVS);
						}
					}
					break;
				case MoneyRewardsStatus.MRS_2_RACE:
					this.comState.Key = "level4";
					break;
				case MoneyRewardsStatus.MRS_RACE:
					this.comState.Key = "level2";
					break;
				case MoneyRewardsStatus.MRS_END:
					this.comState.Key = "level1";
					break;
				}
			}
		}

		// Token: 0x0600F1A3 RID: 61859 RVA: 0x0041276F File Offset: 0x00410B6F
		private void _ClearUI()
		{
		}

		// Token: 0x0600F1A4 RID: 61860 RVA: 0x00412771 File Offset: 0x00410B71
		[UIEventHandle("Quit")]
		private void _OnQuitClicked()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<MoneyRewardsWinFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x04009473 RID: 38003
		[UIControl("", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x04009474 RID: 38004
		[UIControl("", typeof(ComMoneyRewardsVSWinSetting), 0)]
		private ComMoneyRewardsVSWinSetting comVsSetting;

		// Token: 0x04009475 RID: 38005
		[UIControl("Score/Total", null, 0)]
		private Text m_labTotalScore;

		// Token: 0x04009476 RID: 38006
		[UIControl("Score/Delta", null, 0)]
		private Text m_labDeltaScore;

		// Token: 0x04009477 RID: 38007
		[UIControl("Score/Glory", null, 0)]
		private Text m_labGlory;

		// Token: 0x04009478 RID: 38008
		[UIControl("Score/getStatus/d", null, 0)]
		private Text m_getScore;

		// Token: 0x04009479 RID: 38009
		[UIControl("Score/fullStatus/d", null, 0)]
		private Text m_fullScore;

		// Token: 0x0400947A RID: 38010
		[UIControl("Score", typeof(StateController), 0)]
		private StateController scoreStatus;
	}
}
