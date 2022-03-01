using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A7B RID: 6779
	public class ShopNewFilterControl : MonoBehaviour
	{
		// Token: 0x06010A44 RID: 68164 RVA: 0x004B6487 File Offset: 0x004B4887
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x06010A45 RID: 68165 RVA: 0x004B6490 File Offset: 0x004B4890
		private void BindUiEventSystem()
		{
			if (this.filterButton != null)
			{
				this.filterButton.onClick.RemoveAllListeners();
				this.filterButton.onClick.AddListener(new UnityAction(this.OnFilterButtonClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.filterElementItemList != null)
			{
				this.filterElementItemList.Initialize();
				ComUIListScript comUIListScript = this.filterElementItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFilterElementItemVisible));
				ComUIListScript comUIListScript2 = this.filterElementItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnFilterElementItemUpdate));
			}
		}

		// Token: 0x06010A46 RID: 68166 RVA: 0x004B6581 File Offset: 0x004B4981
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x06010A47 RID: 68167 RVA: 0x004B6590 File Offset: 0x004B4990
		private void UnBindUiEventSystem()
		{
			if (this.filterButton != null)
			{
				this.filterButton.onClick.RemoveAllListeners();
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.filterElementItemList != null)
			{
				ComUIListScript comUIListScript = this.filterElementItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnFilterElementItemVisible));
				ComUIListScript comUIListScript2 = this.filterElementItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnFilterElementItemUpdate));
			}
		}

		// Token: 0x06010A48 RID: 68168 RVA: 0x004B6640 File Offset: 0x004B4A40
		private void ClearData()
		{
			this._defaultSelectedIndex = 0;
			this._shopNewFilterData = null;
			this._shopNewFilterDataList = null;
			this._onResetFilterListAction = null;
			this._isShowFilterTitle = false;
			if (this.filterElementItemList != null)
			{
				this.filterElementItemList.SetElementAmount(0);
			}
		}

		// Token: 0x06010A49 RID: 68169 RVA: 0x004B6690 File Offset: 0x004B4A90
		public void InitFilterControl(ShopNewFilterData shopNewFilterData, OnShopNewFilterElementItemTabValueChanged filterElementItemTabValueChanged, Action onResetFilterListAction = null, bool isShowFilterTitle = false)
		{
			this.ClearData();
			this._onResetFilterListAction = onResetFilterListAction;
			this._shopNewFilterData = shopNewFilterData;
			this._filterElementItemTabValueChanged = filterElementItemTabValueChanged;
			this._isShowFilterTitle = isShowFilterTitle;
			if (this._shopNewFilterData == null)
			{
				return;
			}
			this._shopNewFilterDataList = DataManager<ShopNewDataManager>.GetInstance().GetShopNewFilterDataList(this._shopNewFilterData.FilterType);
			if (this._shopNewFilterDataList != null && this._shopNewFilterDataList.Count > 0)
			{
				for (int i = 0; i < this._shopNewFilterDataList.Count; i++)
				{
					if (this._shopNewFilterDataList[i].Index == this._shopNewFilterData.Index)
					{
						this._shopNewFilterDataList[i].IsSelected = true;
					}
					else
					{
						this._shopNewFilterDataList[i].IsSelected = false;
					}
				}
			}
			this.InitFilterView();
		}

		// Token: 0x06010A4A RID: 68170 RVA: 0x004B6770 File Offset: 0x004B4B70
		private void InitFilterView()
		{
			if (this.filterName != null)
			{
				this.filterName.text = this._shopNewFilterData.Name;
			}
			if (this.filterElementItemListRoot != null)
			{
				this.filterElementItemListRoot.gameObject.CustomActive(false);
			}
			if (this.filterElementItemList != null && this._shopNewFilterDataList != null)
			{
				this.filterElementItemList.SetElementAmount(this._shopNewFilterDataList.Count);
			}
			this.InitFilterTitle();
		}

		// Token: 0x06010A4B RID: 68171 RVA: 0x004B6800 File Offset: 0x004B4C00
		private void InitFilterTitle()
		{
			if (this.typeRoot != null)
			{
				this.typeRoot.gameObject.CustomActive(this._isShowFilterTitle);
			}
			if (this.typeName != null)
			{
				this.typeName.text = TR.Value("shop_new_occu_label");
				if (this._shopNewFilterData.FilterType == ShopTable.eFilter.SF_OCCU)
				{
					this.typeName.text = TR.Value("shop_new_occu_label");
				}
				else if (this._shopNewFilterData.FilterType == ShopTable.eFilter.SF_ARMOR)
				{
					this.typeName.text = TR.Value("shop_new_armor_label");
				}
				else if (this.typeRoot != null)
				{
					this.typeRoot.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06010A4C RID: 68172 RVA: 0x004B68D8 File Offset: 0x004B4CD8
		private void OnFilterButtonClick()
		{
			if (this.filterElementItemListRoot != null)
			{
				if (this.filterElementItemListRoot.gameObject.activeSelf)
				{
					this.UpdateFilterElementItemListVisible(false);
				}
				else
				{
					this.UpdateFilterElementItemListVisible(true);
					this.UpdateElementItemListContent();
				}
			}
		}

		// Token: 0x06010A4D RID: 68173 RVA: 0x004B6924 File Offset: 0x004B4D24
		private void UpdateElementItemListContent()
		{
			if (this.filterElementItemList != null)
			{
				this.filterElementItemList.ResetContentPosition();
			}
			this.MoveScrollListToShowSelectedFilter();
		}

		// Token: 0x06010A4E RID: 68174 RVA: 0x004B6948 File Offset: 0x004B4D48
		private void MoveScrollListToShowSelectedFilter()
		{
			if (this.filterElementItemList == null)
			{
				return;
			}
			int selectedFilterDataIndex = this.GetSelectedFilterDataIndex();
			if (selectedFilterDataIndex <= 1)
			{
				this.filterElementItemList.MoveElementInScrollArea(0, true);
			}
			else if (selectedFilterDataIndex >= this._shopNewFilterDataList.Count - 2)
			{
				this.filterElementItemList.MoveElementInScrollArea(this._shopNewFilterDataList.Count - 1, true);
			}
			else
			{
				this.filterElementItemList.MoveElementInScrollArea(selectedFilterDataIndex + 1, true);
			}
		}

		// Token: 0x06010A4F RID: 68175 RVA: 0x004B69C8 File Offset: 0x004B4DC8
		private void OnFilterElementItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.filterElementItemList == null)
			{
				return;
			}
			if (this._shopNewFilterDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._shopNewFilterDataList.Count)
			{
				return;
			}
			ShopNewFilterData shopNewFilterData = this._shopNewFilterDataList[item.m_index];
			ShopNewFilterElementItem component = item.GetComponent<ShopNewFilterElementItem>();
			if (component != null && shopNewFilterData != null)
			{
				component.InitData(shopNewFilterData, new OnShopNewFilterElementItemTabValueChanged(this.OnFilterElementItemToggleClick));
			}
		}

		// Token: 0x06010A50 RID: 68176 RVA: 0x004B6A64 File Offset: 0x004B4E64
		private void OnFilterElementItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ShopNewFilterElementItem component = item.GetComponent<ShopNewFilterElementItem>();
			if (component != null)
			{
				component.UpdateFilterElementItem();
			}
		}

		// Token: 0x06010A51 RID: 68177 RVA: 0x004B6A98 File Offset: 0x004B4E98
		private void OnFilterElementItemToggleClick(ShopNewFilterData shopNewFilterData)
		{
			if (shopNewFilterData == null)
			{
				return;
			}
			if (shopNewFilterData.Index == this._shopNewFilterData.Index)
			{
				return;
			}
			this._shopNewFilterData = shopNewFilterData;
			this.UpdateFilterName();
			this.DisableFilterListRoot();
			if (this._filterElementItemTabValueChanged != null)
			{
				this._filterElementItemTabValueChanged(this._shopNewFilterData);
			}
			this.UpdateShopNewFilterDataSelectedInfo();
		}

		// Token: 0x06010A52 RID: 68178 RVA: 0x004B6AF8 File Offset: 0x004B4EF8
		private void UpdateShopNewFilterDataSelectedInfo()
		{
			if (this._shopNewFilterData == null)
			{
				return;
			}
			if (this._shopNewFilterDataList == null || this._shopNewFilterDataList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._shopNewFilterDataList.Count; i++)
			{
				if (this._shopNewFilterDataList[i].FilterType == this._shopNewFilterData.FilterType && this._shopNewFilterDataList[i].Index == this._shopNewFilterData.Index)
				{
					this._shopNewFilterDataList[i].IsSelected = true;
				}
				else
				{
					this._shopNewFilterDataList[i].IsSelected = false;
				}
			}
			if (this.filterElementItemList != null)
			{
				this.filterElementItemList.UpdateElement();
			}
		}

		// Token: 0x06010A53 RID: 68179 RVA: 0x004B6BD1 File Offset: 0x004B4FD1
		private void UpdateFilterName()
		{
			if (this.filterName != null)
			{
				this.filterName.text = this._shopNewFilterData.Name;
			}
		}

		// Token: 0x06010A54 RID: 68180 RVA: 0x004B6BFA File Offset: 0x004B4FFA
		private void DisableFilterListRoot()
		{
			this.UpdateFilterElementItemListVisible(false);
		}

		// Token: 0x06010A55 RID: 68181 RVA: 0x004B6C04 File Offset: 0x004B5004
		private void UpdateFilterElementItemListVisible(bool flag)
		{
			if (this._onResetFilterListAction != null)
			{
				this._onResetFilterListAction();
			}
			if (this.filterElementItemListRoot != null)
			{
				this.filterElementItemListRoot.gameObject.CustomActive(flag);
			}
			if (this.closeButton != null)
			{
				this.closeButton.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x06010A56 RID: 68182 RVA: 0x004B6C6C File Offset: 0x004B506C
		private int GetSelectedFilterDataIndex()
		{
			int result = 0;
			if (this._shopNewFilterDataList == null || this._shopNewFilterDataList.Count <= 0)
			{
				return 0;
			}
			if (this._shopNewFilterData == null)
			{
				return 0;
			}
			for (int i = 0; i < this._shopNewFilterDataList.Count; i++)
			{
				ShopNewFilterData shopNewFilterData = this._shopNewFilterDataList[i];
				if (shopNewFilterData != null)
				{
					if (shopNewFilterData.FilterType == this._shopNewFilterData.FilterType && shopNewFilterData.Index == this._shopNewFilterData.Index)
					{
						return i;
					}
				}
			}
			return result;
		}

		// Token: 0x06010A57 RID: 68183 RVA: 0x004B6D0B File Offset: 0x004B510B
		private void OnCloseButtonClick()
		{
			this.UpdateFilterElementItemListVisible(false);
		}

		// Token: 0x06010A58 RID: 68184 RVA: 0x004B6D14 File Offset: 0x004B5114
		public void ResetFilterList()
		{
			if (this.filterElementItemListRoot != null)
			{
				this.filterElementItemListRoot.gameObject.CustomActive(false);
			}
			if (this.closeButton != null)
			{
				this.closeButton.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0400AA04 RID: 43524
		private ShopNewFilterData _shopNewFilterData;

		// Token: 0x0400AA05 RID: 43525
		private List<ShopNewFilterData> _shopNewFilterDataList = new List<ShopNewFilterData>();

		// Token: 0x0400AA06 RID: 43526
		private int _defaultSelectedIndex;

		// Token: 0x0400AA07 RID: 43527
		private OnShopNewFilterElementItemTabValueChanged _filterElementItemTabValueChanged;

		// Token: 0x0400AA08 RID: 43528
		private Action _onResetFilterListAction;

		// Token: 0x0400AA09 RID: 43529
		private bool _isShowFilterTitle;

		// Token: 0x0400AA0A RID: 43530
		[SerializeField]
		private Text filterName;

		// Token: 0x0400AA0B RID: 43531
		[SerializeField]
		private Button filterButton;

		// Token: 0x0400AA0C RID: 43532
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400AA0D RID: 43533
		[SerializeField]
		private ComUIListScript filterElementItemList;

		// Token: 0x0400AA0E RID: 43534
		[SerializeField]
		private GameObject filterElementItemListRoot;

		// Token: 0x0400AA0F RID: 43535
		[Space(10f)]
		[Header("typeRoot")]
		[SerializeField]
		private GameObject typeRoot;

		// Token: 0x0400AA10 RID: 43536
		[SerializeField]
		private Text typeName;
	}
}
