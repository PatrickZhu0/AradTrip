using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020017A6 RID: 6054
	public class MallNewPropertyMallView : MallNewBaseView
	{
		// Token: 0x0600EEB2 RID: 61106 RVA: 0x0040170D File Offset: 0x003FFB0D
		private void Awake()
		{
			this._isAlreadyInit = false;
			this._mallTypeTable = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600EEB3 RID: 61107 RVA: 0x00401724 File Offset: 0x003FFB24
		private void BindUiEventSystem()
		{
			if (this.propertyMallTabList != null)
			{
				this.propertyMallTabList.Initialize();
				ComUIListScript comUIListScript = this.propertyMallTabList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTabItemVisible));
			}
			if (this.propertyMallElementList != null)
			{
				this.propertyMallElementList.Initialize();
				ComUIListScript comUIListScript2 = this.propertyMallElementList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
		}

		// Token: 0x0600EEB4 RID: 61108 RVA: 0x004017B7 File Offset: 0x003FFBB7
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600EEB5 RID: 61109 RVA: 0x004017C5 File Offset: 0x003FFBC5
		private void ClearData()
		{
			this._selectedIndex = 0;
			this._mallTypeTableId = 0;
			this._mallTypeTable = null;
			if (this._propertyMallElementDataModelList != null)
			{
				this._propertyMallElementDataModelList.Clear();
			}
		}

		// Token: 0x0600EEB6 RID: 61110 RVA: 0x004017F4 File Offset: 0x003FFBF4
		private void UnBindUiEventSystem()
		{
			if (this.propertyMallTabList != null)
			{
				ComUIListScript comUIListScript = this.propertyMallTabList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTabItemVisible));
			}
			if (this.propertyMallElementList != null)
			{
				ComUIListScript comUIListScript2 = this.propertyMallElementList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
		}

		// Token: 0x0600EEB7 RID: 61111 RVA: 0x00401871 File Offset: 0x003FFC71
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
			if (this._isAlreadyInit)
			{
				this.UpdatePropertyMallElementListByOnEnable();
			}
		}

		// Token: 0x0600EEB8 RID: 61112 RVA: 0x0040189F File Offset: 0x003FFC9F
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
		}

		// Token: 0x0600EEB9 RID: 61113 RVA: 0x004018BC File Offset: 0x003FFCBC
		private void OnSyncWorldMallQueryItem(UIEvent uiEvent)
		{
			if (this._mallTypeTable == null)
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
			if (num != (int)this._mallTypeTable.MallType)
			{
				return;
			}
			this._propertyMallElementDataModelList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList((int)this._mallTypeTable.MallType, 0, 0);
			this.ShowPropertyMallElementList();
		}

		// Token: 0x0600EEBA RID: 61114 RVA: 0x0040192C File Offset: 0x003FFD2C
		private void UpdatePropertyMallElementListByOnEnable()
		{
			this._mallTypeTable = this.GetMallTypeTableByType(this._mallTypeTableId);
			if (this._mallTypeTable == null)
			{
				return;
			}
			this._propertyMallElementDataModelList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList((int)this._mallTypeTable.MallType, 0, 0);
			this.ShowPropertyMallElementList();
		}

		// Token: 0x0600EEBB RID: 61115 RVA: 0x0040197C File Offset: 0x003FFD7C
		public override void InitData(int index, int secondIndex = 0, int thirdIndex = 0)
		{
			if (this.propertyMallTabList == null)
			{
				return;
			}
			if (this._isAlreadyInit)
			{
				return;
			}
			this._isAlreadyInit = true;
			this._selectedIndex = index;
			if (this.propertyMallTabDataModelList != null && this.propertyMallTabDataModelList.Count > 0)
			{
				if (this._selectedIndex >= this.propertyMallTabDataModelList.Count)
				{
					this._selectedIndex = 0;
				}
				this.propertyMallTabList.SetElementAmount(this.propertyMallTabDataModelList.Count);
			}
		}

		// Token: 0x0600EEBC RID: 61116 RVA: 0x00401A04 File Offset: 0x003FFE04
		private void OnTabItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.propertyMallTabDataModelList == null || this.propertyMallTabDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.propertyMallTabDataModelList.Count)
			{
				return;
			}
			MallNewPropertyMallTabData mallNewPropertyMallTabData = this.propertyMallTabDataModelList[item.m_index];
			MallNewPropertyMallTabItem component = item.GetComponent<MallNewPropertyMallTabItem>();
			if (mallNewPropertyMallTabData != null && component != null)
			{
				bool isSelected = item.m_index == this._selectedIndex;
				component.InitData(mallNewPropertyMallTabData, new OnPropertyMallTabValueChanged(this.OnTabClicked), isSelected);
			}
		}

		// Token: 0x0600EEBD RID: 61117 RVA: 0x00401AAC File Offset: 0x003FFEAC
		private void OnTabClicked(int index, int mallTypeTableId)
		{
			this._selectedIndex = index;
			this._mallTypeTableId = mallTypeTableId;
			Utility.DoStartFrameOperation("MallNewPropertyMallView", string.Format("MallTypeTableId/{0}", mallTypeTableId));
			this.UpdatePropertyMallElementItemList();
		}

		// Token: 0x0600EEBE RID: 61118 RVA: 0x00401ADC File Offset: 0x003FFEDC
		private void UpdatePropertyMallElementItemList()
		{
			this.ResetPropertyMallElementList();
			this._mallTypeTable = this.GetMallTypeTableByType(this._mallTypeTableId);
			if (this._mallTypeTable == null)
			{
				return;
			}
			this._propertyMallElementDataModelList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList((int)this._mallTypeTable.MallType, 0, 0);
			if (this._propertyMallElementDataModelList == null)
			{
				DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(this._mallTypeTable.ID, 0, 0);
			}
			else
			{
				this.ShowPropertyMallElementList();
			}
		}

		// Token: 0x0600EEBF RID: 61119 RVA: 0x00401B58 File Offset: 0x003FFF58
		private void ShowPropertyMallElementList()
		{
			if (this.propertyMallElementList == null || this._propertyMallElementDataModelList == null)
			{
				return;
			}
			this.propertyMallElementList.SetElementAmount(this._propertyMallElementDataModelList.Count);
			this.propertyMallElementList.MoveElementInScrollArea(0, true);
		}

		// Token: 0x0600EEC0 RID: 61120 RVA: 0x00401BA5 File Offset: 0x003FFFA5
		private void ResetPropertyMallElementList()
		{
			this.propertyMallElementList.SetElementAmount(0);
		}

		// Token: 0x0600EEC1 RID: 61121 RVA: 0x00401BB4 File Offset: 0x003FFFB4
		private void OnElementItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.propertyMallElementList == null)
			{
				return;
			}
			if (this._propertyMallElementDataModelList == null || this._propertyMallElementDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._propertyMallElementDataModelList.Count)
			{
				return;
			}
			MallNewPropertyMallElementItem component = item.GetComponent<MallNewPropertyMallElementItem>();
			MallItemInfo mallItemInfo = this._propertyMallElementDataModelList[item.m_index];
			if (component != null && mallItemInfo != null)
			{
				component.InitData(mallItemInfo);
			}
		}

		// Token: 0x0600EEC2 RID: 61122 RVA: 0x00401C54 File Offset: 0x00400054
		private MallTypeTable GetMallTypeTableByType(int mallTypeTableId)
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(mallTypeTableId, string.Empty, string.Empty);
		}

		// Token: 0x04009224 RID: 37412
		private bool _isAlreadyInit;

		// Token: 0x04009225 RID: 37413
		private int _selectedIndex;

		// Token: 0x04009226 RID: 37414
		private MallTypeTable _mallTypeTable;

		// Token: 0x04009227 RID: 37415
		private int _mallTypeTableId;

		// Token: 0x04009228 RID: 37416
		private List<MallItemInfo> _propertyMallElementDataModelList = new List<MallItemInfo>();

		// Token: 0x04009229 RID: 37417
		[Header("TabDataList")]
		[SerializeField]
		private List<MallNewPropertyMallTabData> propertyMallTabDataModelList = new List<MallNewPropertyMallTabData>();

		// Token: 0x0400922A RID: 37418
		[Space(20f)]
		[SerializeField]
		private ComUIListScript propertyMallTabList;

		// Token: 0x0400922B RID: 37419
		[SerializeField]
		private ComUIListScript propertyMallElementList;
	}
}
