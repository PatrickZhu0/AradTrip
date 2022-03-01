using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001792 RID: 6034
	public class MallNewLimitTimeMallView : MallNewBaseView
	{
		// Token: 0x0600EE4E RID: 61006 RVA: 0x003FF972 File Offset: 0x003FDD72
		private void Awake()
		{
			this._isAlreadyInit = false;
			this.BindUiEventSystem();
		}

		// Token: 0x0600EE4F RID: 61007 RVA: 0x003FF984 File Offset: 0x003FDD84
		private void BindUiEventSystem()
		{
			if (this.limitTimeMallElementList != null)
			{
				this.limitTimeMallElementList.Initialize();
				ComUIListScript comUIListScript = this.limitTimeMallElementList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
				ComUIListScript comUIListScript2 = this.limitTimeMallElementList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600EE50 RID: 61008 RVA: 0x003FF9FB File Offset: 0x003FDDFB
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			if (this._limitTimeMallElementDataModelList != null)
			{
				this._limitTimeMallElementDataModelList.Clear();
			}
			this._curMallType = 0;
			this.ResetLimitTimeMallElementDataModelList();
		}

		// Token: 0x0600EE51 RID: 61009 RVA: 0x003FFA26 File Offset: 0x003FDE26
		private void ResetLimitTimeMallElementDataModelList()
		{
			if (this._limitTimeMallElementDataModelList != null)
			{
				this._limitTimeMallElementDataModelList.Clear();
			}
		}

		// Token: 0x0600EE52 RID: 61010 RVA: 0x003FFA40 File Offset: 0x003FDE40
		private void UnBindUiEventSystem()
		{
			if (this.limitTimeMallElementList != null)
			{
				ComUIListScript comUIListScript = this.limitTimeMallElementList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
				ComUIListScript comUIListScript2 = this.limitTimeMallElementList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600EE53 RID: 61011 RVA: 0x003FFAAC File Offset: 0x003FDEAC
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
			if (this._isAlreadyInit)
			{
				this.UpdateLimitTimeMallElementListByOnEnable();
			}
		}

		// Token: 0x0600EE54 RID: 61012 RVA: 0x003FFADA File Offset: 0x003FDEDA
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
		}

		// Token: 0x0600EE55 RID: 61013 RVA: 0x003FFAF8 File Offset: 0x003FDEF8
		public override void InitData(int index, int secondIndex = 0, int thirdIndex = 0)
		{
			if (this.limitTimeMallElementList == null)
			{
				return;
			}
			if (this._isAlreadyInit)
			{
				return;
			}
			this._isAlreadyInit = true;
			this._curMallType = this.GetMallType();
			DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(9, 0, 0);
		}

		// Token: 0x0600EE56 RID: 61014 RVA: 0x003FFB44 File Offset: 0x003FDF44
		private void OnSyncWorldMallQueryItem(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num != this._curMallType)
			{
				return;
			}
			this._limitTimeMallElementDataModelList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList(this._curMallType, 0, 0);
			if (this._limitTimeMallElementDataModelList != null)
			{
				this._limitTimeMallElementDataModelList.Sort(new Comparison<MallItemInfo>(this._SortList));
			}
			this.ShowLimitTimeMallElementList();
		}

		// Token: 0x0600EE57 RID: 61015 RVA: 0x003FFBC0 File Offset: 0x003FDFC0
		private void ShowLimitTimeMallElementList()
		{
			if (this._limitTimeMallElementDataModelList == null || this._limitTimeMallElementDataModelList.Count < 0)
			{
				return;
			}
			if (this.limitTimeMallElementList != null)
			{
				this.limitTimeMallElementList.SetElementAmount(this._limitTimeMallElementDataModelList.Count);
				this.limitTimeMallElementList.MoveElementInScrollArea(0, true);
			}
		}

		// Token: 0x0600EE58 RID: 61016 RVA: 0x003FFC20 File Offset: 0x003FE020
		private void UpdateLimitTimeMallElementListByOnEnable()
		{
			this._limitTimeMallElementDataModelList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList(this._curMallType, 0, 0);
			if (this._limitTimeMallElementDataModelList != null)
			{
				this._limitTimeMallElementDataModelList.Sort(new Comparison<MallItemInfo>(this._SortList));
			}
			this.ShowLimitTimeMallElementList();
		}

		// Token: 0x0600EE59 RID: 61017 RVA: 0x003FFC6D File Offset: 0x003FE06D
		private int _SortList(MallItemInfo a, MallItemInfo b)
		{
			if (a.sortIdx > b.sortIdx)
			{
				return 1;
			}
			if (a.sortIdx < b.sortIdx)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x0600EE5A RID: 61018 RVA: 0x003FFC98 File Offset: 0x003FE098
		private void OnElementItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.limitTimeMallElementList == null)
			{
				return;
			}
			if (this._limitTimeMallElementDataModelList == null || this._limitTimeMallElementDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._limitTimeMallElementDataModelList.Count)
			{
				return;
			}
			MallNewLimitTimeMallElementItem component = item.GetComponent<MallNewLimitTimeMallElementItem>();
			MallItemInfo mallItemInfo = this._limitTimeMallElementDataModelList[item.m_index];
			if (component != null && mallItemInfo != null)
			{
				component.Init(mallItemInfo);
			}
		}

		// Token: 0x0600EE5B RID: 61019 RVA: 0x003FFD38 File Offset: 0x003FE138
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.limitTimeMallElementList == null)
			{
				return;
			}
			MallNewLimitTimeMallElementItem component = item.GetComponent<MallNewLimitTimeMallElementItem>();
			if (component != null)
			{
				component.Reset();
			}
		}

		// Token: 0x0600EE5C RID: 61020 RVA: 0x003FFD80 File Offset: 0x003FE180
		private int GetMallType()
		{
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(9, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return (int)tableItem.MallType;
		}

		// Token: 0x0600EE5D RID: 61021 RVA: 0x003FFDB4 File Offset: 0x003FE1B4
		private int GetSelfBaseJobId()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return num;
			}
			if (tableItem.JobType == 1)
			{
				num = tableItem.prejob;
			}
			return num;
		}

		// Token: 0x040091A9 RID: 37289
		private const int MallTypeTableId = 9;

		// Token: 0x040091AA RID: 37290
		private int _curMallType;

		// Token: 0x040091AB RID: 37291
		private bool _isAlreadyInit;

		// Token: 0x040091AC RID: 37292
		private List<MallItemInfo> _limitTimeMallElementDataModelList = new List<MallItemInfo>();

		// Token: 0x040091AD RID: 37293
		[SerializeField]
		private ComUIListScript limitTimeMallElementList;
	}
}
