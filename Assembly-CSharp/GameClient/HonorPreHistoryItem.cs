using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001672 RID: 5746
	public class HonorPreHistoryItem : MonoBehaviour
	{
		// Token: 0x0600E1EB RID: 57835 RVA: 0x003A0D42 File Offset: 0x0039F142
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600E1EC RID: 57836 RVA: 0x003A0D4A File Offset: 0x0039F14A
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600E1ED RID: 57837 RVA: 0x003A0D58 File Offset: 0x0039F158
		private void BindUiEvents()
		{
			if (this.historyActivityItemList != null)
			{
				this.historyActivityItemList.Initialize();
				ComUIListScript comUIListScript = this.historyActivityItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnHistoryActivityItemVisible));
			}
		}

		// Token: 0x0600E1EE RID: 57838 RVA: 0x003A0DA8 File Offset: 0x0039F1A8
		private void UnBindUiEvents()
		{
			if (this.historyActivityItemList != null)
			{
				ComUIListScript comUIListScript = this.historyActivityItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnHistoryActivityItemVisible));
			}
		}

		// Token: 0x0600E1EF RID: 57839 RVA: 0x003A0DE2 File Offset: 0x0039F1E2
		private void ClearData()
		{
			this._playerHistoryHonorInfo = null;
			this._totalPvpNumberStatisticsList = null;
			this._curPvpNumberStatisticsList.Clear();
		}

		// Token: 0x0600E1F0 RID: 57840 RVA: 0x003A0E00 File Offset: 0x0039F200
		public void InitItem(HONOR_DATE_TYPE honorDateType)
		{
			this._honorDateType = honorDateType;
			this._playerHistoryHonorInfo = HonorSystemUtility.GetPlayerHistoryHonorInfoByDateType(this._honorDateType);
			if (this._playerHistoryHonorInfo == null)
			{
				Logger.LogErrorFormat("HistoryHonorInfo is null", new object[0]);
				CommonUtility.UpdateGameObjectVisible(base.gameObject, false);
				return;
			}
			this.InitTitle();
			this.InitHistoryTotalValue();
			this.InitHistoryActivityInfo();
		}

		// Token: 0x0600E1F1 RID: 57841 RVA: 0x003A0E60 File Offset: 0x0039F260
		private void InitTitle()
		{
			string text = TR.Value("Honor_System_Today");
			if (this._honorDateType == HONOR_DATE_TYPE.HONOR_DATE_TYPE_LAST_WEEK)
			{
				text = TR.Value("Honor_System_Pre_Week");
			}
			else if (this._honorDateType == HONOR_DATE_TYPE.HONOR_DATE_TYPE_THIS_WEEK)
			{
				text = TR.Value("Honor_System_This_Week");
			}
			if (this.preHistoryTitleLabel != null)
			{
				this.preHistoryTitleLabel.text = text;
			}
		}

		// Token: 0x0600E1F2 RID: 57842 RVA: 0x003A0EC8 File Offset: 0x0039F2C8
		private void InitHistoryTotalValue()
		{
			if (this.honorTotalValueText != null)
			{
				this.honorTotalValueText.text = this._playerHistoryHonorInfo.HonorTotalNumber.ToString();
			}
		}

		// Token: 0x0600E1F3 RID: 57843 RVA: 0x003A0EFC File Offset: 0x0039F2FC
		private void InitHistoryActivityInfo()
		{
			this._totalPvpNumberStatisticsList = this._playerHistoryHonorInfo.PvpNumberStatisticsList;
			if (this._totalPvpNumberStatisticsList == null)
			{
				return;
			}
			this._curPvpNumber = 0;
			this._curPvpNumberStatisticsList.Clear();
			if (this._totalPvpNumberStatisticsList.Count > 0)
			{
				this._curPvpNumber = this._totalPvpNumberStatisticsList.Count;
				for (int i = 0; i < this._curPvpNumber; i++)
				{
					this._curPvpNumberStatisticsList.Add(this._totalPvpNumberStatisticsList[i]);
				}
			}
			if (this.historyActivityItemList != null)
			{
				this.historyActivityItemList.SetElementAmount(this._curPvpNumber);
			}
		}

		// Token: 0x0600E1F4 RID: 57844 RVA: 0x003A0FAC File Offset: 0x0039F3AC
		private void OnHistoryActivityItemVisible(ComUIListElementScript item)
		{
			if (this.historyActivityItemList == null)
			{
				return;
			}
			if (item == null)
			{
				return;
			}
			if (this._curPvpNumberStatisticsList == null || this._curPvpNumberStatisticsList.Count < 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._curPvpNumberStatisticsList.Count)
			{
				return;
			}
			PvpNumberStatistics pvpNumberStatistics = this._curPvpNumberStatisticsList[item.m_index];
			HonorCommonItem component = item.GetComponent<HonorCommonItem>();
			if (component != null && pvpNumberStatistics != null)
			{
				component.InitItem(pvpNumberStatistics);
			}
		}

		// Token: 0x04008733 RID: 34611
		private HONOR_DATE_TYPE _honorDateType;

		// Token: 0x04008734 RID: 34612
		private PlayerHistoryHonorInfo _playerHistoryHonorInfo;

		// Token: 0x04008735 RID: 34613
		private List<PvpNumberStatistics> _totalPvpNumberStatisticsList;

		// Token: 0x04008736 RID: 34614
		private List<PvpNumberStatistics> _curPvpNumberStatisticsList = new List<PvpNumberStatistics>();

		// Token: 0x04008737 RID: 34615
		private int _curPvpNumber;

		// Token: 0x04008738 RID: 34616
		[Space(5f)]
		[Header("Title")]
		[Space(5f)]
		[SerializeField]
		private Text preHistoryTitleLabel;

		// Token: 0x04008739 RID: 34617
		[SerializeField]
		private Text honorTotalValueText;

		// Token: 0x0400873A RID: 34618
		[Space(5f)]
		[Header("HistoryActivityItemList")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScript historyActivityItemList;
	}
}
