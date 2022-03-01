using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001790 RID: 6032
	public class MallNewIntergralMallView : MallNewBaseView
	{
		// Token: 0x0600EE20 RID: 60960 RVA: 0x003FE488 File Offset: 0x003FC888
		private void Awake()
		{
			this.BindUIEventSystem();
		}

		// Token: 0x0600EE21 RID: 60961 RVA: 0x003FE490 File Offset: 0x003FC890
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600EE22 RID: 60962 RVA: 0x003FE498 File Offset: 0x003FC898
		public sealed override void InitData(int index, int secondIndex = 0, int thirdIndex = 0)
		{
			this.mMallNewIntergralMallTabDataList = MallNewUtility.GetIntergralMallTabDataModelList();
			if (this.mMallNewIntergralMallTabDataList == null)
			{
				return;
			}
			this.mSeletedIndex = index;
			if (this.mMallNewIntergralMallTabDataList != null && this.mMallNewIntergralMallTabDataList.Count > 0 && this.mSeletedIndex >= this.mMallNewIntergralMallTabDataList.Count)
			{
				this.mSeletedIndex = 0;
			}
			this.mIntergralMallTabList.SetElementAmount(this.mMallNewIntergralMallTabDataList.Count);
		}

		// Token: 0x0600EE23 RID: 60963 RVA: 0x003FE512 File Offset: 0x003FC912
		public sealed override void OnEnableView()
		{
			base.OnEnableView();
		}

		// Token: 0x0600EE24 RID: 60964 RVA: 0x003FE51A File Offset: 0x003FC91A
		private void ClearData()
		{
			this.mSeletedIndex = 0;
			this.mMallTypeTableId = 0;
			this.mMallNewIntergralMallTabDataList = null;
			this.mIntergralMallElementDataModelList = null;
			this.mMallTypeTable = null;
			this.UnBindUIEventSystem();
		}

		// Token: 0x0600EE25 RID: 60965 RVA: 0x003FE548 File Offset: 0x003FC948
		private void BindUIEventSystem()
		{
			if (this.mIntergralMallTabList != null)
			{
				this.mIntergralMallTabList.Initialize();
				ComUIListScript comUIListScript = this.mIntergralMallTabList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mIntergralMallTabList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			if (this.mIntergralMallElmentList != null)
			{
				this.mIntergralMallElmentList.Initialize();
				ComUIListScript comUIListScript3 = this.mIntergralMallElmentList;
				comUIListScript3.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript3.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindIntergralMallElementItemDelegate));
				ComUIListScript comUIListScript4 = this.mIntergralMallElmentList;
				comUIListScript4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnIntergralMallElementItemVisiableDelegate));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
		}

		// Token: 0x0600EE26 RID: 60966 RVA: 0x003FE644 File Offset: 0x003FCA44
		private void UnBindUIEventSystem()
		{
			if (this.mIntergralMallTabList != null)
			{
				ComUIListScript comUIListScript = this.mIntergralMallTabList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mIntergralMallTabList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			if (this.mIntergralMallElmentList != null)
			{
				ComUIListScript comUIListScript3 = this.mIntergralMallElmentList;
				comUIListScript3.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript3.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindIntergralMallElementItemDelegate));
				ComUIListScript comUIListScript4 = this.mIntergralMallElmentList;
				comUIListScript4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnIntergralMallElementItemVisiableDelegate));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
		}

		// Token: 0x0600EE27 RID: 60967 RVA: 0x003FE72A File Offset: 0x003FCB2A
		private MallNewIntergralMallTabItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<MallNewIntergralMallTabItem>();
		}

		// Token: 0x0600EE28 RID: 60968 RVA: 0x003FE734 File Offset: 0x003FCB34
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			MallNewIntergralMallTabItem mallNewIntergralMallTabItem = item.gameObjectBindScript as MallNewIntergralMallTabItem;
			if (mallNewIntergralMallTabItem != null && item.m_index >= 0 && item.m_index < this.mMallNewIntergralMallTabDataList.Count)
			{
				bool isSeleted = this.mSeletedIndex == this.mMallNewIntergralMallTabDataList[item.m_index].index;
				mallNewIntergralMallTabItem.InitData(this.mMallNewIntergralMallTabDataList[item.m_index], new MallNewIntergralMallTabClick(this.OnTabClick), isSeleted);
			}
		}

		// Token: 0x0600EE29 RID: 60969 RVA: 0x003FE7BE File Offset: 0x003FCBBE
		private void OnTabClick(int mallTypeTableId)
		{
			this.mMallTypeTableId = mallTypeTableId;
			this.UpdateIntergralMallElementItemList();
		}

		// Token: 0x0600EE2A RID: 60970 RVA: 0x003FE7D0 File Offset: 0x003FCBD0
		private void UpdateIntergralMallElementItemList()
		{
			this.mMallTypeTable = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(this.mMallTypeTableId, string.Empty, string.Empty);
			if (this.mMallTypeTable == null)
			{
				return;
			}
			this.mIntergralMallElementDataModelList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList((int)this.mMallTypeTable.MallType, 0, 0);
			if (this.mIntergralMallElementDataModelList == null)
			{
				DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(this.mMallTypeTable.ID, 0, 0);
			}
			else
			{
				this.SetIntergralMallElementList();
			}
		}

		// Token: 0x0600EE2B RID: 60971 RVA: 0x003FE853 File Offset: 0x003FCC53
		private void SetIntergralMallElementList()
		{
			if (this.mIntergralMallElementDataModelList == null)
			{
				return;
			}
			this.mIntergralMallElmentList.SetElementAmount(this.mIntergralMallElementDataModelList.Count);
			this.mIntergralMallElmentList.MoveElementInScrollArea(0, true);
		}

		// Token: 0x0600EE2C RID: 60972 RVA: 0x003FE884 File Offset: 0x003FCC84
		private MallNewPropertyMallElementItem OnBindIntergralMallElementItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<MallNewPropertyMallElementItem>();
		}

		// Token: 0x0600EE2D RID: 60973 RVA: 0x003FE88C File Offset: 0x003FCC8C
		private void OnIntergralMallElementItemVisiableDelegate(ComUIListElementScript item)
		{
			MallNewPropertyMallElementItem mallNewPropertyMallElementItem = item.gameObjectBindScript as MallNewPropertyMallElementItem;
			if (mallNewPropertyMallElementItem != null && item.m_index >= 0 && item.m_index < this.mIntergralMallElementDataModelList.Count)
			{
				mallNewPropertyMallElementItem.InitData(this.mIntergralMallElementDataModelList[item.m_index]);
			}
		}

		// Token: 0x0600EE2E RID: 60974 RVA: 0x003FE8EC File Offset: 0x003FCCEC
		private void OnSyncWorldMallQueryItem(UIEvent uiEvent)
		{
			if (this.mMallTypeTable == null)
			{
				return;
			}
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num != (int)this.mMallTypeTable.MallType)
			{
				return;
			}
			this.mIntergralMallElementDataModelList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList((int)this.mMallTypeTable.MallType, 0, 0);
			this.SetIntergralMallElementList();
		}

		// Token: 0x0400917F RID: 37247
		[SerializeField]
		private ComUIListScript mIntergralMallTabList;

		// Token: 0x04009180 RID: 37248
		[SerializeField]
		private ComUIListScript mIntergralMallElmentList;

		// Token: 0x04009181 RID: 37249
		private List<MallItemInfo> mIntergralMallElementDataModelList;

		// Token: 0x04009182 RID: 37250
		private List<MallNewIntergralMallTabData> mMallNewIntergralMallTabDataList;

		// Token: 0x04009183 RID: 37251
		private int mSeletedIndex;

		// Token: 0x04009184 RID: 37252
		private int mMallTypeTableId;

		// Token: 0x04009185 RID: 37253
		private MallTypeTable mMallTypeTable;
	}
}
