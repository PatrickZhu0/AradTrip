using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F81 RID: 3969
	public class CommonNewDropDownListView : MonoBehaviour
	{
		// Token: 0x0600996A RID: 39274 RVA: 0x001D867D File Offset: 0x001D6A7D
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0600996B RID: 39275 RVA: 0x001D8688 File Offset: 0x001D6A88
		private void BindUiEventSystem()
		{
			if (this.dropDownItemList != null)
			{
				this.dropDownItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.dropDownItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.dropDownItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
		}

		// Token: 0x0600996C RID: 39276 RVA: 0x001D86FF File Offset: 0x001D6AFF
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600996D RID: 39277 RVA: 0x001D8710 File Offset: 0x001D6B10
		private void UnBindUiEventSystem()
		{
			if (this.dropDownItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.dropDownItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.dropDownItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
		}

		// Token: 0x0600996E RID: 39278 RVA: 0x001D877C File Offset: 0x001D6B7C
		private void ClearData()
		{
			this._onItemButtonClick = null;
			this._commonNewDropDownDataList = null;
		}

		// Token: 0x0600996F RID: 39279 RVA: 0x001D878C File Offset: 0x001D6B8C
		public virtual void InitCommonNewDropDownListView(ComControlData defaultControlData, List<ComControlData> comControlDataList, OnCommonNewDropDownItemButtonClick onItemButtonClick = null)
		{
			this._commonNewDropDownDataList = comControlDataList;
			this._onItemButtonClick = onItemButtonClick;
			this.UpdateCommonNewDropDownDataList(defaultControlData);
			this.InitDropDownList();
		}

		// Token: 0x06009970 RID: 39280 RVA: 0x001D87A9 File Offset: 0x001D6BA9
		private void InitDropDownList()
		{
			if (this.dropDownItemList != null)
			{
				this.dropDownItemList.SetElementAmount(this._commonNewDropDownDataList.Count);
			}
			this.UpdateSelectedItemPosition();
		}

		// Token: 0x06009971 RID: 39281 RVA: 0x001D87D8 File Offset: 0x001D6BD8
		public virtual void UpdateSelectedItemPosition()
		{
			if (this.dropDownItemList != null)
			{
				this.dropDownItemList.ResetComUiListScriptEx();
			}
			int selectedItemIndex = this.GetSelectedItemIndex();
			if (this.dropDownItemList != null)
			{
				this.dropDownItemList.MoveItemToMiddlePosition(selectedItemIndex);
			}
		}

		// Token: 0x06009972 RID: 39282 RVA: 0x001D8828 File Offset: 0x001D6C28
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.dropDownItemList == null)
			{
				return;
			}
			if (this._commonNewDropDownDataList == null)
			{
				return;
			}
			if (this._commonNewDropDownDataList.Count <= 0 || item.m_index >= this._commonNewDropDownDataList.Count)
			{
				return;
			}
			ComControlData comControlData = this._commonNewDropDownDataList[item.m_index];
			CommonNewDropDownItem component = item.GetComponent<CommonNewDropDownItem>();
			if (component != null && comControlData != null)
			{
				component.InitItem(comControlData, new OnCommonNewDropDownItemButtonClick(this.OnItemButtonClick));
			}
		}

		// Token: 0x06009973 RID: 39283 RVA: 0x001D88C8 File Offset: 0x001D6CC8
		private void OnItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			CommonNewDropDownItem component = item.GetComponent<CommonNewDropDownItem>();
			if (component != null)
			{
				component.UpdateComDropDownItemSelectedFlag();
			}
		}

		// Token: 0x06009974 RID: 39284 RVA: 0x001D88FB File Offset: 0x001D6CFB
		private void OnItemButtonClick(ComControlData comControlData)
		{
			this.UpdateCommonNewDropDownDataList(comControlData);
			this.UpdateCommonNewDropDownItemList();
			if (this._onItemButtonClick != null)
			{
				this._onItemButtonClick(comControlData);
			}
		}

		// Token: 0x06009975 RID: 39285 RVA: 0x001D8924 File Offset: 0x001D6D24
		public void UpdateCommonNewDropDownDataList(ComControlData comControlData)
		{
			if (this._commonNewDropDownDataList == null)
			{
				return;
			}
			for (int i = 0; i < this._commonNewDropDownDataList.Count; i++)
			{
				if (this._commonNewDropDownDataList[i].Id == comControlData.Id)
				{
					this._commonNewDropDownDataList[i].IsSelected = true;
				}
				else
				{
					this._commonNewDropDownDataList[i].IsSelected = false;
				}
			}
		}

		// Token: 0x06009976 RID: 39286 RVA: 0x001D899E File Offset: 0x001D6D9E
		public void UpdateCommonNewDropDownItemList()
		{
			if (this.dropDownItemList != null)
			{
				this.dropDownItemList.UpdateElement();
			}
		}

		// Token: 0x06009977 RID: 39287 RVA: 0x001D89BC File Offset: 0x001D6DBC
		private int GetSelectedItemIndex()
		{
			for (int i = 0; i < this._commonNewDropDownDataList.Count; i++)
			{
				ComControlData comControlData = this._commonNewDropDownDataList[i];
				if (comControlData != null && comControlData.IsSelected)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x04004F04 RID: 20228
		private OnCommonNewDropDownItemButtonClick _onItemButtonClick;

		// Token: 0x04004F05 RID: 20229
		private List<ComControlData> _commonNewDropDownDataList;

		// Token: 0x04004F06 RID: 20230
		[SerializeField]
		private ComUIListScriptEx dropDownItemList;
	}
}
