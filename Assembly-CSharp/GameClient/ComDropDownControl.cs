using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F79 RID: 3961
	public class ComDropDownControl : MonoBehaviour
	{
		// Token: 0x0600992C RID: 39212 RVA: 0x001D76B1 File Offset: 0x001D5AB1
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0600992D RID: 39213 RVA: 0x001D76BC File Offset: 0x001D5ABC
		private void BindUiEventSystem()
		{
			if (this.dropDownButton != null)
			{
				this.dropDownButton.onClick.RemoveAllListeners();
				this.dropDownButton.onClick.AddListener(new UnityAction(this.OnDropDownButtonClick));
			}
			if (this.dropDownCloseButton != null)
			{
				this.dropDownCloseButton.onClick.RemoveAllListeners();
				this.dropDownCloseButton.onClick.AddListener(new UnityAction(this.OnDropDownCloseButton));
			}
			if (this.dropDownItemList != null)
			{
				ComUIListScript comUIListScript = this.dropDownItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropDownItemVisible));
				ComUIListScript comUIListScript2 = this.dropDownItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnDropDownItemUpdate));
			}
		}

		// Token: 0x0600992E RID: 39214 RVA: 0x001D77A2 File Offset: 0x001D5BA2
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600992F RID: 39215 RVA: 0x001D77B0 File Offset: 0x001D5BB0
		private void UnBindUiEventSystem()
		{
			if (this.dropDownButton != null)
			{
				this.dropDownButton.onClick.RemoveAllListeners();
			}
			if (this.dropDownCloseButton != null)
			{
				this.dropDownCloseButton.onClick.RemoveAllListeners();
			}
			if (this.dropDownItemList != null)
			{
				ComUIListScript comUIListScript = this.dropDownItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropDownItemVisible));
				ComUIListScript comUIListScript2 = this.dropDownItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnDropDownItemUpdate));
			}
		}

		// Token: 0x06009930 RID: 39216 RVA: 0x001D785E File Offset: 0x001D5C5E
		private void ClearData()
		{
			this._comControlData = null;
			this._comDropDownDataList = null;
			this._onComDropDownItemButtonClick = null;
			this._onResetDropDownListAction = null;
		}

		// Token: 0x06009931 RID: 39217 RVA: 0x001D787C File Offset: 0x001D5C7C
		public void InitComDropDownControl(ComControlData comControlData, List<ComControlData> comDropDownDataList, OnComDropDownItemButtonClick onComDropDownItemButtonClick, Action onResetDropDownAction = null)
		{
			this.ClearData();
			this._comControlData = comControlData;
			if (this._comControlData == null)
			{
				Logger.LogError("ComDropDownData is null");
				return;
			}
			this._comDropDownDataList = comDropDownDataList;
			if (this._comDropDownDataList == null || this._comDropDownDataList.Count <= 0)
			{
				Logger.LogError("ComDropDownDataList is null");
				return;
			}
			this._onComDropDownItemButtonClick = onComDropDownItemButtonClick;
			this._onResetDropDownListAction = onResetDropDownAction;
			for (int i = 0; i < this._comDropDownDataList.Count; i++)
			{
				this._comDropDownDataList[i].IsSelected = (this._comDropDownDataList[i].Id == this._comControlData.Id);
			}
			this.InitDropDownControlView();
		}

		// Token: 0x06009932 RID: 39218 RVA: 0x001D793C File Offset: 0x001D5D3C
		private void InitDropDownControlView()
		{
			if (this.dropDownLabelName != null)
			{
				this.dropDownLabelName.text = this._comControlData.Name;
			}
			if (this.dropDownItemListRoot != null)
			{
				this.dropDownItemListRoot.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06009933 RID: 39219 RVA: 0x001D7994 File Offset: 0x001D5D94
		private void OnDropDownButtonClick()
		{
			if (this.dropDownItemListRoot != null)
			{
				if (this.dropDownItemListRoot.gameObject.activeInHierarchy)
				{
					this.UpdateDropDownItemListVisible(false);
				}
				else
				{
					if (!this.dropDownItemList.IsInitialised())
					{
						this.dropDownItemList.Initialize();
						this.dropDownItemList.SetElementAmount(this._comDropDownDataList.Count);
					}
					this.UpdateDropDownItemListVisible(true);
					this.UpdateDropDownItemListPosition();
				}
			}
		}

		// Token: 0x06009934 RID: 39220 RVA: 0x001D7A11 File Offset: 0x001D5E11
		private void OnDropDownItemButtonClick(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			this._comControlData = comControlData;
			this.UpdateDropDownLabelName();
			this.DisableDropDownListRoot();
			if (this._onComDropDownItemButtonClick != null)
			{
				this._onComDropDownItemButtonClick(this._comControlData);
			}
			this.UpdateComDropDownDataListSelectedInfo();
		}

		// Token: 0x06009935 RID: 39221 RVA: 0x001D7A4F File Offset: 0x001D5E4F
		private void OnDropDownCloseButton()
		{
			this.UpdateDropDownItemListVisible(false);
		}

		// Token: 0x06009936 RID: 39222 RVA: 0x001D7A58 File Offset: 0x001D5E58
		private void UpdateDropDownItemListVisible(bool flag)
		{
			if (this._onResetDropDownListAction != null)
			{
				this._onResetDropDownListAction();
			}
			if (this.dropDownItemListRoot != null)
			{
				this.dropDownItemListRoot.CustomActive(flag);
			}
			if (this.dropDownCloseButton != null)
			{
				this.dropDownCloseButton.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06009937 RID: 39223 RVA: 0x001D7ABA File Offset: 0x001D5EBA
		private void UpdateDropDownItemListPosition()
		{
			if (this.dropDownItemList != null)
			{
				this.dropDownItemList.ResetContentPosition();
			}
			this.MoveDropDownListToSelectedItem();
		}

		// Token: 0x06009938 RID: 39224 RVA: 0x001D7AE0 File Offset: 0x001D5EE0
		private void MoveDropDownListToSelectedItem()
		{
			if (this.dropDownItemList == null)
			{
				return;
			}
			int selectedFilterDataIndex = this.GetSelectedFilterDataIndex();
			if (selectedFilterDataIndex <= 1)
			{
				this.dropDownItemList.MoveElementInScrollArea(0, true);
			}
			else if (selectedFilterDataIndex >= this._comDropDownDataList.Count - 2)
			{
				this.dropDownItemList.MoveElementInScrollArea(this._comDropDownDataList.Count - 1, true);
			}
			else
			{
				this.dropDownItemList.MoveElementInScrollArea(selectedFilterDataIndex + 1, true);
			}
		}

		// Token: 0x06009939 RID: 39225 RVA: 0x001D7B60 File Offset: 0x001D5F60
		private void OnDropDownItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.dropDownItemList == null)
			{
				return;
			}
			if (this._comDropDownDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._comDropDownDataList.Count)
			{
				return;
			}
			ComControlData comControlData = this._comDropDownDataList[item.m_index];
			ComDropDownItem component = item.GetComponent<ComDropDownItem>();
			if (component != null && comControlData != null)
			{
				component.InitItem(comControlData, new OnComDropDownItemButtonClick(this.OnDropDownItemButtonClick));
			}
		}

		// Token: 0x0600993A RID: 39226 RVA: 0x001D7BFC File Offset: 0x001D5FFC
		private void OnDropDownItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ComDropDownItem component = item.GetComponent<ComDropDownItem>();
			if (component != null)
			{
				component.UpdateComDropDownItem();
			}
		}

		// Token: 0x0600993B RID: 39227 RVA: 0x001D7C30 File Offset: 0x001D6030
		private void UpdateComDropDownDataListSelectedInfo()
		{
			if (this._comControlData == null)
			{
				return;
			}
			if (this._comDropDownDataList == null || this._comDropDownDataList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._comDropDownDataList.Count; i++)
			{
				if (this._comDropDownDataList[i] != null && this._comDropDownDataList[i].Id == this._comControlData.Id)
				{
					this._comDropDownDataList[i].IsSelected = true;
				}
				else
				{
					this._comDropDownDataList[i].IsSelected = false;
				}
			}
			if (this.dropDownItemList != null)
			{
				this.dropDownItemList.UpdateElement();
			}
		}

		// Token: 0x0600993C RID: 39228 RVA: 0x001D7CF9 File Offset: 0x001D60F9
		private void DisableDropDownListRoot()
		{
			this.UpdateDropDownItemListVisible(false);
		}

		// Token: 0x0600993D RID: 39229 RVA: 0x001D7D02 File Offset: 0x001D6102
		private void UpdateDropDownLabelName()
		{
			if (this.dropDownLabelName != null)
			{
				this.dropDownLabelName.text = this._comControlData.Name;
			}
		}

		// Token: 0x0600993E RID: 39230 RVA: 0x001D7D2C File Offset: 0x001D612C
		private int GetSelectedFilterDataIndex()
		{
			if (this._comDropDownDataList == null || this._comDropDownDataList.Count <= 0)
			{
				return 0;
			}
			if (this._comControlData == null)
			{
				return 0;
			}
			for (int i = 0; i < this._comDropDownDataList.Count; i++)
			{
				ComControlData comControlData = this._comDropDownDataList[i];
				if (comControlData != null)
				{
					if (comControlData.Id == this._comControlData.Id)
					{
						return i;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600993F RID: 39231 RVA: 0x001D7DB4 File Offset: 0x001D61B4
		public void ResetDropDownList()
		{
			if (this.dropDownItemListRoot != null)
			{
				this.dropDownItemListRoot.gameObject.CustomActive(false);
			}
			if (this.dropDownButton != null)
			{
				this.dropDownButton.gameObject.CustomActive(false);
			}
		}

		// Token: 0x04004EDE RID: 20190
		private ComControlData _comControlData;

		// Token: 0x04004EDF RID: 20191
		private List<ComControlData> _comDropDownDataList = new List<ComControlData>();

		// Token: 0x04004EE0 RID: 20192
		private OnComDropDownItemButtonClick _onComDropDownItemButtonClick;

		// Token: 0x04004EE1 RID: 20193
		private Action _onResetDropDownListAction;

		// Token: 0x04004EE2 RID: 20194
		[SerializeField]
		private Text dropDownLabelName;

		// Token: 0x04004EE3 RID: 20195
		[SerializeField]
		private Button dropDownButton;

		// Token: 0x04004EE4 RID: 20196
		[SerializeField]
		private Button dropDownCloseButton;

		// Token: 0x04004EE5 RID: 20197
		[SerializeField]
		private ComUIListScript dropDownItemList;

		// Token: 0x04004EE6 RID: 20198
		[SerializeField]
		private GameObject dropDownItemListRoot;
	}
}
