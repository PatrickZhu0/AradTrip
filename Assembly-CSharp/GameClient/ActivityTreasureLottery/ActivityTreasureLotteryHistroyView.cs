using System;
using DataModel;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E2 RID: 5090
	public class ActivityTreasureLotteryHistroyView : ActivityTreasureLotteryActivityViewBase<IActivityTreasureLotteryHistoryModel>
	{
		// Token: 0x0600C56B RID: 50539 RVA: 0x002F926E File Offset: 0x002F766E
		protected override void OnInit()
		{
			this.mScrollList.Initialize();
			this.mScrollList.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this.OnWinnerItemVisible);
		}

		// Token: 0x0600C56C RID: 50540 RVA: 0x002F9292 File Offset: 0x002F7692
		protected override void OnDispose()
		{
			this.mScrollList.onItemVisiable = null;
		}

		// Token: 0x0600C56D RID: 50541 RVA: 0x002F92A0 File Offset: 0x002F76A0
		private void OnWinnerItemVisible(ComUIListElementScript item)
		{
			if (item != null && this.mModel != null && this.mModel.PlayerList != null && item.m_index >= 0 && item.m_index < this.mModel.PlayerList.Length)
			{
				Text component = item.gameObject.GetComponent<Text>();
				if (component == null)
				{
					return;
				}
				component.text = string.Empty;
				HistroyPlayerData histroyPlayerData = this.mModel.PlayerList[item.m_index];
				if (histroyPlayerData.IsPlayer)
				{
					component.SafeSetText(TR.Value("activity_treasure_history_player_win_color"));
				}
				component.SafeSetText(component.text + string.Format(TR.Value("activity_treasure_history_winner_info").Replace("\\n", "\n"), new object[]
				{
					histroyPlayerData.GroupId,
					histroyPlayerData.PlatformName,
					histroyPlayerData.ServerName,
					histroyPlayerData.Name,
					histroyPlayerData.TotalInvestment,
					this.mModel.CurrencyName
				}));
				if (histroyPlayerData.IsPlayer)
				{
					component.SafeSetText(component.text + "</color>");
				}
				if (item.m_index != this.mModel.PlayerList.Length - 1)
				{
					component.SafeSetText(component.text + "\n");
				}
			}
		}

		// Token: 0x0600C56E RID: 50542 RVA: 0x002F9428 File Offset: 0x002F7828
		protected override void OnSelectItem(IActivityTreasureLotteryHistoryModel model)
		{
			this.mModel = model;
			if (model != null)
			{
				if (model.PlayerList != null && model.PlayerList.Length > 0)
				{
					this.mScrollList.SetElementAmount(model.PlayerList.Length);
					this.mOtherGroup.CustomActive(!model.IsSellOut);
				}
				else
				{
					this.mScrollList.SetElementAmount(0);
					this.mTextNoRecord.SafeSetText(TR.Value("activity_treasure_history_no_record"));
					this.mOtherGroup.CustomActive(false);
				}
			}
		}

		// Token: 0x040070B3 RID: 28851
		[SerializeField]
		private Text mTextNoRecord;

		// Token: 0x040070B4 RID: 28852
		[SerializeField]
		private GameObject mOtherGroup;

		// Token: 0x040070B5 RID: 28853
		[SerializeField]
		private new ComUIListScript mScrollList;

		// Token: 0x040070B6 RID: 28854
		private IActivityTreasureLotteryHistoryModel mModel;
	}
}
