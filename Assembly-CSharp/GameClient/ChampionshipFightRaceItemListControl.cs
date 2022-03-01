using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014F0 RID: 5360
	public class ChampionshipFightRaceItemListControl : MonoBehaviour
	{
		// Token: 0x0600D003 RID: 53251 RVA: 0x00335342 File Offset: 0x00333742
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D004 RID: 53252 RVA: 0x0033534A File Offset: 0x0033374A
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D005 RID: 53253 RVA: 0x00335358 File Offset: 0x00333758
		private void BindUiEvents()
		{
			if (this.fightRaceItemList != null)
			{
				this.fightRaceItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.fightRaceItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFightRaceItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.fightRaceItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnFightRaceItemRecycle));
			}
		}

		// Token: 0x0600D006 RID: 53254 RVA: 0x003353D0 File Offset: 0x003337D0
		private void UnBindUiEvents()
		{
			if (this.fightRaceItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.fightRaceItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFightRaceItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.fightRaceItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnFightRaceItemRecycle));
			}
		}

		// Token: 0x0600D007 RID: 53255 RVA: 0x0033543C File Offset: 0x0033383C
		private void ClearData()
		{
			this._scheduleType = ChampionshipScheduleTable.eScheduleType.None;
			this._fightRaceDataModelList = null;
		}

		// Token: 0x0600D008 RID: 53256 RVA: 0x0033544C File Offset: 0x0033384C
		public void UpdateFightRaceItemControl(ChampionshipScheduleTable.eScheduleType scheduleType, List<ChampionshipFightRaceDataModel> fightRaceDataModelList)
		{
			this._scheduleType = scheduleType;
			this._fightRaceDataModelList = fightRaceDataModelList;
			if (this.fightRaceItemRootRtf != null)
			{
				Vector3 localPosition = this.fightRaceItemRootRtf.localPosition;
				if (this._scheduleType == ChampionshipScheduleTable.eScheduleType.Eight_Select)
				{
					if (this.eightPlayerRtf != null)
					{
						localPosition = this.eightPlayerRtf.localPosition;
					}
				}
				else if (this._scheduleType == ChampionshipScheduleTable.eScheduleType.Four_Select)
				{
					if (this.fourPlayerRtf != null)
					{
						localPosition = this.fourPlayerRtf.localPosition;
					}
				}
				else if (this._scheduleType == ChampionshipScheduleTable.eScheduleType.Two_Select && this.twoPlayerRtf != null)
				{
					localPosition = this.twoPlayerRtf.localPosition;
				}
				this.fightRaceItemRootRtf.localPosition = localPosition;
			}
			int elementAmount = 0;
			if (this._fightRaceDataModelList != null)
			{
				elementAmount = this._fightRaceDataModelList.Count;
			}
			if (this.fightRaceItemList != null)
			{
				this.fightRaceItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600D009 RID: 53257 RVA: 0x0033554C File Offset: 0x0033394C
		private void OnFightRaceItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._fightRaceDataModelList == null || this._fightRaceDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._fightRaceDataModelList.Count)
			{
				return;
			}
			ChampionshipFightRaceDataModel championshipFightRaceDataModel = this._fightRaceDataModelList[item.m_index];
			ChampionshipFightRaceItem component = item.GetComponent<ChampionshipFightRaceItem>();
			if (component != null && championshipFightRaceDataModel != null)
			{
				component.Init(championshipFightRaceDataModel);
			}
		}

		// Token: 0x0600D00A RID: 53258 RVA: 0x003355D8 File Offset: 0x003339D8
		private void OnFightRaceItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChampionshipFightRaceItem component = item.GetComponent<ChampionshipFightRaceItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x040079B3 RID: 31155
		private ChampionshipScheduleTable.eScheduleType _scheduleType;

		// Token: 0x040079B4 RID: 31156
		private List<ChampionshipFightRaceDataModel> _fightRaceDataModelList;

		// Token: 0x040079B5 RID: 31157
		[Space(10f)]
		[Header("Position")]
		[Space(10f)]
		[SerializeField]
		private RectTransform eightPlayerRtf;

		// Token: 0x040079B6 RID: 31158
		[SerializeField]
		private RectTransform fourPlayerRtf;

		// Token: 0x040079B7 RID: 31159
		[SerializeField]
		private RectTransform twoPlayerRtf;

		// Token: 0x040079B8 RID: 31160
		[SerializeField]
		private RectTransform fightRaceItemRootRtf;

		// Token: 0x040079B9 RID: 31161
		[Space(10f)]
		[Header("ItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx fightRaceItemList;
	}
}
