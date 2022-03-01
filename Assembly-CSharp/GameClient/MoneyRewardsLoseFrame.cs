using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017F1 RID: 6129
	internal class MoneyRewardsLoseFrame : ClientFrame
	{
		// Token: 0x0600F194 RID: 61844 RVA: 0x00412365 File Offset: 0x00410765
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MoneyRewards/MoneyRewardsLose";
		}

		// Token: 0x0600F195 RID: 61845 RVA: 0x0041236C File Offset: 0x0041076C
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600F196 RID: 61846 RVA: 0x0041237A File Offset: 0x0041077A
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600F197 RID: 61847 RVA: 0x00412388 File Offset: 0x00410788
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600F198 RID: 61848 RVA: 0x0041238A File Offset: 0x0041078A
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600F199 RID: 61849 RVA: 0x0041238C File Offset: 0x0041078C
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
			if (worldPremiumLeagueRaceEnd.result == 2)
			{
				this.m_labTitle.text = TR.Value("guild_battle_lose");
				this.m_objTie.SetActive(false);
			}
			else if (worldPremiumLeagueRaceEnd.result == 4)
			{
				this.m_labTitle.text = TR.Value("guild_battle_lose");
				this.m_objTie.SetActive(true);
			}
			else
			{
				this.m_labTitle.text = TR.Value("guild_battle_result_error");
				this.m_objTie.SetActive(false);
			}
		}

		// Token: 0x0600F19A RID: 61850 RVA: 0x00412525 File Offset: 0x00410925
		private void _ClearUI()
		{
		}

		// Token: 0x0600F19B RID: 61851 RVA: 0x00412527 File Offset: 0x00410927
		[UIEventHandle("Quit")]
		private void _OnQuitClicked()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<MoneyRewardsLoseFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x0400946D RID: 37997
		[UIControl("", typeof(StateController), 0)]
		private StateController comState;

		// Token: 0x0400946E RID: 37998
		[UIControl("Score/Total", null, 0)]
		private Text m_labTotalScore;

		// Token: 0x0400946F RID: 37999
		[UIControl("Score/Delta", null, 0)]
		private Text m_labDeltaScore;

		// Token: 0x04009470 RID: 38000
		[UIControl("Score/Glory", null, 0)]
		private Text m_labGlory;

		// Token: 0x04009471 RID: 38001
		[UIControl("Title/BG/Text", null, 0)]
		private Text m_labTitle;

		// Token: 0x04009472 RID: 38002
		[UIObject("Tie")]
		private GameObject m_objTie;
	}
}
