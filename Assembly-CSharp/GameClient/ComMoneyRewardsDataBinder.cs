using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017DD RID: 6109
	public class ComMoneyRewardsDataBinder : MonoBehaviour
	{
		// Token: 0x0600F0C2 RID: 61634 RVA: 0x0040D281 File Offset: 0x0040B681
		public void SetVSAwardsDesc()
		{
			if (null != this.eachVSAwardDesc)
			{
				this.eachVSAwardDesc.text = string.Format(this.eachVSFmtString, DataManager<MoneyRewardsDataManager>.GetInstance().MaxAwardEachVS);
			}
		}

		// Token: 0x0600F0C3 RID: 61635 RVA: 0x0040D2B9 File Offset: 0x0040B6B9
		public void SetVSEachFixedGetDesc()
		{
			if (null != this.awardPerVS)
			{
				this.awardPerVS.text = string.Format(this.eachFixFmtString, DataManager<MoneyRewardsDataManager>.GetInstance().FixedAwardEachVS);
			}
		}

		// Token: 0x0600F0C4 RID: 61636 RVA: 0x0040D2F4 File Offset: 0x0040B6F4
		public void SetVSGetAwardsDesc()
		{
			int vsAwards = DataManager<MoneyRewardsDataManager>.GetInstance().vsAwards;
			if (null != this.eachVSGetAward)
			{
				this.eachVSGetAward.text = string.Format(this.eachGetFmtString, vsAwards);
			}
		}

		// Token: 0x0600F0C5 RID: 61637 RVA: 0x0040D33C File Offset: 0x0040B73C
		public void SetPoolAwards()
		{
			if (null != this.awardsInPools)
			{
				this.awardsInPools.text = DataManager<MoneyRewardsDataManager>.GetInstance().moneysInPool.ToString();
			}
		}

		// Token: 0x0600F0C6 RID: 61638 RVA: 0x0040D37D File Offset: 0x0040B77D
		public void SelectVSPanel(bool bEnable)
		{
			if (null != this.mVsStatus)
			{
				this.mVsStatus.Key = ((!bEnable) ? this.mStrDisable : this.mStrEnable);
			}
		}

		// Token: 0x0600F0C7 RID: 61639 RVA: 0x0040D3B2 File Offset: 0x0040B7B2
		public void SetVSEnable(bool bEnable)
		{
			if (null != this.mStateVS)
			{
				this.mStateVS.Key = ((!bEnable) ? this.mStrDisable : this.mStrEnable);
			}
		}

		// Token: 0x0600F0C8 RID: 61640 RVA: 0x0040D3E8 File Offset: 0x0040B7E8
		public void SetPlayerEnable(int iIndex, bool bEnable)
		{
			if (iIndex >= 0 && iIndex < this.mStateVsPlayers.Length)
			{
				StateController stateController = this.mStateVsPlayers[iIndex];
				if (null != stateController)
				{
					stateController.Key = ((!bEnable) ? this.mStrDisable : this.mStrEnable);
				}
			}
		}

		// Token: 0x0600F0C9 RID: 61641 RVA: 0x0040D43C File Offset: 0x0040B83C
		public void SetPlayerData(int iIndex, object data)
		{
			ComMoneyRewardsResultData comMoneyRewardsResultData = data as ComMoneyRewardsResultData;
			if (comMoneyRewardsResultData != null)
			{
				this.SetPlayerName(iIndex, comMoneyRewardsResultData.name);
				this.SetPlayerHead(iIndex, comMoneyRewardsResultData.occu);
				this.SetPlayerLevel(iIndex, 1);
			}
		}

		// Token: 0x0600F0CA RID: 61642 RVA: 0x0040D478 File Offset: 0x0040B878
		public void SetPlayerName(int iIndex, string name)
		{
			if (iIndex >= 0 && iIndex < this.mPlayerNames.Length)
			{
				Text text = this.mPlayerNames[iIndex];
				if (null != text)
				{
					text.text = name;
				}
			}
		}

		// Token: 0x0600F0CB RID: 61643 RVA: 0x0040D4B8 File Offset: 0x0040B8B8
		public void SetPlayerHead(int iIndex, int occu)
		{
			if (iIndex >= 0 && iIndex < this.mPlayerHeads.Length)
			{
				Image image = this.mPlayerHeads[iIndex];
				if (null != image)
				{
					string path = string.Empty;
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							path = tableItem2.IconPath;
						}
					}
					ETCImageLoader.LoadSprite(ref image, path, true);
				}
			}
		}

		// Token: 0x0600F0CC RID: 61644 RVA: 0x0040D544 File Offset: 0x0040B944
		public void SetPlayerLevel(int iIndex, int level)
		{
			if (iIndex >= 0 && iIndex < this.mLevels.Length)
			{
				Text text = this.mLevels[iIndex];
				if (null != text)
				{
					text.text = level.ToString();
				}
			}
		}

		// Token: 0x0600F0CD RID: 61645 RVA: 0x0040D58E File Offset: 0x0040B98E
		public void RemoveWatchListener()
		{
			if (null != this.mButtonWatchPlayerInfo)
			{
				this.mButtonWatchPlayerInfo.onClick.RemoveListener(new UnityAction(this.OnWatchPlayerInfo));
			}
		}

		// Token: 0x0600F0CE RID: 61646 RVA: 0x0040D5BD File Offset: 0x0040B9BD
		public void AddWatchListener()
		{
			if (null != this.mButtonWatchPlayerInfo)
			{
				this.mButtonWatchPlayerInfo.onClick.AddListener(new UnityAction(this.OnWatchPlayerInfo));
			}
		}

		// Token: 0x0600F0CF RID: 61647 RVA: 0x0040D5EC File Offset: 0x0040B9EC
		public void SetWatchPlayerInfo(object other)
		{
			this.mOther = (other as ComMoneyRewardsResultData);
		}

		// Token: 0x0600F0D0 RID: 61648 RVA: 0x0040D5FC File Offset: 0x0040B9FC
		public void OnWatchPlayerInfo()
		{
			if (this.mOther != null && this.mOther.recordId != DataManager<PlayerBaseData>.GetInstance().RoleID && this.mOther.recordId > 0UL)
			{
				DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this.mOther.recordId, 0U, 0U);
			}
		}

		// Token: 0x0600F0D1 RID: 61649 RVA: 0x0040D657 File Offset: 0x0040BA57
		public void DoUnLeaveHint()
		{
			SystemNotifyManager.SysNotifyTextAnimation(this.mUnLeaveStringHint, CommonTipsDesc.eShowMode.SI_UNIQUE);
		}

		// Token: 0x0600F0D2 RID: 61650 RVA: 0x0040D668 File Offset: 0x0040BA68
		public void UpdateStatus()
		{
			if (null != this.mStateDesc)
			{
				MoneyRewardsStatus eMoneyRewardsStatus = DataManager<MoneyRewardsDataManager>.GetInstance().eMoneyRewardsStatus;
				switch (eMoneyRewardsStatus + 1)
				{
				case MoneyRewardsStatus.MRS_READY:
					this.mStateDesc.Key = "finish";
					break;
				case MoneyRewardsStatus.MRS_8_RACE:
					this.mStateDesc.Key = "ready";
					break;
				case MoneyRewardsStatus.MRS_PRE_4_RACE:
					this.mStateDesc.Key = "8level";
					break;
				case MoneyRewardsStatus.MRS_4_RACE:
					this.mStateDesc.Key = "4pre_level";
					break;
				case MoneyRewardsStatus.MRS_2_RACE:
					this.mStateDesc.Key = "4level";
					break;
				case MoneyRewardsStatus.MRS_RACE:
					this.mStateDesc.Key = "2level";
					break;
				case MoneyRewardsStatus.MRS_END:
					this.mStateDesc.Key = "1level";
					break;
				case (MoneyRewardsStatus)7:
					this.mStateDesc.Key = "finish";
					break;
				}
			}
		}

		// Token: 0x0600F0D3 RID: 61651 RVA: 0x0040D766 File Offset: 0x0040BB66
		public void StartCounter(uint count)
		{
			if (null != this.mTimeRefresh)
			{
				this.mTimeRefresh.CustomActive(true);
				this.mTimeRefresh.Initialize();
				this.mTimeRefresh.Time = count;
			}
		}

		// Token: 0x0600F0D4 RID: 61652 RVA: 0x0040D79C File Offset: 0x0040BB9C
		public void CloseCounter()
		{
			if (null != this.mTimeRefresh)
			{
				this.mTimeRefresh.Time = 0U;
				this.mTimeRefresh.CustomActive(false);
			}
		}

		// Token: 0x0600F0D5 RID: 61653 RVA: 0x0040D7C7 File Offset: 0x0040BBC7
		private void OnDestroy()
		{
			this.RemoveWatchListener();
			this.mOther = null;
		}

		// Token: 0x040093C5 RID: 37829
		public StateController mStateVS;

		// Token: 0x040093C6 RID: 37830
		public StateController[] mStateVsPlayers = new StateController[0];

		// Token: 0x040093C7 RID: 37831
		public Text[] mPlayerNames = new Text[0];

		// Token: 0x040093C8 RID: 37832
		public Image[] mPlayerHeads = new Image[0];

		// Token: 0x040093C9 RID: 37833
		public Text[] mLevels = new Text[0];

		// Token: 0x040093CA RID: 37834
		public Button mButtonWatchPlayerInfo;

		// Token: 0x040093CB RID: 37835
		public StateController mStateDesc;

		// Token: 0x040093CC RID: 37836
		public string mUnLeaveStringHint = string.Empty;

		// Token: 0x040093CD RID: 37837
		public TimeRefresh mTimeRefresh;

		// Token: 0x040093CE RID: 37838
		private string mStrEnable = "Enable";

		// Token: 0x040093CF RID: 37839
		private string mStrDisable = "Disable";

		// Token: 0x040093D0 RID: 37840
		public uint triggerTime = 16U;

		// Token: 0x040093D1 RID: 37841
		public string eachVSFmtString = string.Empty;

		// Token: 0x040093D2 RID: 37842
		public Text eachVSAwardDesc;

		// Token: 0x040093D3 RID: 37843
		public Text eachVSGetAward;

		// Token: 0x040093D4 RID: 37844
		public string eachGetFmtString = string.Empty;

		// Token: 0x040093D5 RID: 37845
		public StateController mVsStatus;

		// Token: 0x040093D6 RID: 37846
		public Text awardsInPools;

		// Token: 0x040093D7 RID: 37847
		public string eachFixFmtString = string.Empty;

		// Token: 0x040093D8 RID: 37848
		public Text awardPerVS;

		// Token: 0x040093D9 RID: 37849
		private ComMoneyRewardsResultData mOther;
	}
}
