using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001471 RID: 5233
	public class AuctionNewFilterControl : MonoBehaviour
	{
		// Token: 0x0600CAFB RID: 51963 RVA: 0x0031BC4F File Offset: 0x0031A04F
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0600CAFC RID: 51964 RVA: 0x0031BC58 File Offset: 0x0031A058
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

		// Token: 0x0600CAFD RID: 51965 RVA: 0x0031BD49 File Offset: 0x0031A149
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600CAFE RID: 51966 RVA: 0x0031BD58 File Offset: 0x0031A158
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

		// Token: 0x0600CAFF RID: 51967 RVA: 0x0031BE06 File Offset: 0x0031A206
		private void ClearData()
		{
			this._defaultSelectedIndex = 0;
			this._auctionNewFilterData = null;
			this._auctionNewFilterDataList = null;
			this._onResetFilterListAction = null;
		}

		// Token: 0x0600CB00 RID: 51968 RVA: 0x0031BE24 File Offset: 0x0031A224
		public void InitFilterControl(AuctionNewFilterData auctionNewFilterData, OnAuctionNewFilterElementItemButtonClick filterElementItemButtonClick, Action onResetFilterListAction = null)
		{
			this.ClearData();
			this._onResetFilterListAction = onResetFilterListAction;
			this._auctionNewFilterData = auctionNewFilterData;
			this._onAuctionNewfilterElementItemButtonClick = filterElementItemButtonClick;
			if (this._auctionNewFilterData == null)
			{
				return;
			}
			this._auctionNewFilterDataList = DataManager<AuctionNewDataManager>.GetInstance().GetAuctionNewFilterDataList(this._auctionNewFilterData.FilterItemType);
			if (this._auctionNewFilterDataList != null && this._auctionNewFilterDataList.Count > 0)
			{
				for (int i = 0; i < this._auctionNewFilterDataList.Count; i++)
				{
					if (this._auctionNewFilterDataList[i].Id == this._auctionNewFilterData.Id)
					{
						this._auctionNewFilterDataList[i].IsSelected = true;
					}
					else
					{
						this._auctionNewFilterDataList[i].IsSelected = false;
					}
				}
			}
			this.InitFilterView();
		}

		// Token: 0x0600CB01 RID: 51969 RVA: 0x0031BEFC File Offset: 0x0031A2FC
		private void InitFilterView()
		{
			if (this.filterName != null)
			{
				this.filterName.text = this._auctionNewFilterData.Name;
			}
			if (this.filterElementItemListRoot != null)
			{
				this.filterElementItemListRoot.gameObject.CustomActive(false);
			}
			if (this.filterElementItemList != null && this._auctionNewFilterDataList != null)
			{
				this.filterElementItemList.SetElementAmount(this._auctionNewFilterDataList.Count);
			}
		}

		// Token: 0x0600CB02 RID: 51970 RVA: 0x0031BF84 File Offset: 0x0031A384
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

		// Token: 0x0600CB03 RID: 51971 RVA: 0x0031BFD0 File Offset: 0x0031A3D0
		private void UpdateElementItemListContent()
		{
			if (this.filterElementItemList != null)
			{
				this.filterElementItemList.ResetContentPosition();
			}
			this.MoveScrollListToShowSelectedFilter();
		}

		// Token: 0x0600CB04 RID: 51972 RVA: 0x0031BFF4 File Offset: 0x0031A3F4
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
			else if (selectedFilterDataIndex >= this._auctionNewFilterDataList.Count - 2)
			{
				this.filterElementItemList.MoveElementInScrollArea(this._auctionNewFilterDataList.Count - 1, true);
			}
			else
			{
				this.filterElementItemList.MoveElementInScrollArea(selectedFilterDataIndex + 1, true);
			}
		}

		// Token: 0x0600CB05 RID: 51973 RVA: 0x0031C074 File Offset: 0x0031A474
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
			if (this._auctionNewFilterDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._auctionNewFilterDataList.Count)
			{
				return;
			}
			AuctionNewFilterData auctionNewFilterData = this._auctionNewFilterDataList[item.m_index];
			AuctionNewFilterElementItem component = item.GetComponent<AuctionNewFilterElementItem>();
			if (component != null && auctionNewFilterData != null)
			{
				component.InitData(auctionNewFilterData, new OnAuctionNewFilterElementItemButtonClick(this.OnFilterElementItemButtonClick));
			}
		}

		// Token: 0x0600CB06 RID: 51974 RVA: 0x0031C110 File Offset: 0x0031A510
		private void OnFilterElementItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewFilterElementItem component = item.GetComponent<AuctionNewFilterElementItem>();
			if (component != null)
			{
				component.UpdateFilterElementItem();
			}
		}

		// Token: 0x0600CB07 RID: 51975 RVA: 0x0031C143 File Offset: 0x0031A543
		private void OnFilterElementItemButtonClick(AuctionNewFilterData auctionNewFilterData)
		{
			if (auctionNewFilterData == null)
			{
				return;
			}
			this._auctionNewFilterData = auctionNewFilterData;
			this.UpdateFilterName();
			this.DisableFilterListRoot();
			if (this._onAuctionNewfilterElementItemButtonClick != null)
			{
				this._onAuctionNewfilterElementItemButtonClick(this._auctionNewFilterData);
			}
			this.UpdateAuctionNewFilterDataSelectedInfo();
		}

		// Token: 0x0600CB08 RID: 51976 RVA: 0x0031C184 File Offset: 0x0031A584
		private void UpdateAuctionNewFilterDataSelectedInfo()
		{
			if (this._auctionNewFilterData == null)
			{
				return;
			}
			if (this._auctionNewFilterDataList == null || this._auctionNewFilterDataList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._auctionNewFilterDataList.Count; i++)
			{
				if (this._auctionNewFilterDataList[i].FilterItemType == this._auctionNewFilterData.FilterItemType && this._auctionNewFilterDataList[i].Id == this._auctionNewFilterData.Id)
				{
					this._auctionNewFilterDataList[i].IsSelected = true;
				}
				else
				{
					this._auctionNewFilterDataList[i].IsSelected = false;
				}
			}
			if (this.filterElementItemList != null)
			{
				this.filterElementItemList.UpdateElement();
			}
		}

		// Token: 0x0600CB09 RID: 51977 RVA: 0x0031C25D File Offset: 0x0031A65D
		private void UpdateFilterName()
		{
			if (this.filterName != null)
			{
				this.filterName.text = this._auctionNewFilterData.Name;
			}
		}

		// Token: 0x0600CB0A RID: 51978 RVA: 0x0031C286 File Offset: 0x0031A686
		private void DisableFilterListRoot()
		{
			this.UpdateFilterElementItemListVisible(false);
		}

		// Token: 0x0600CB0B RID: 51979 RVA: 0x0031C290 File Offset: 0x0031A690
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

		// Token: 0x0600CB0C RID: 51980 RVA: 0x0031C2F8 File Offset: 0x0031A6F8
		private int GetSelectedFilterDataIndex()
		{
			int result = 0;
			if (this._auctionNewFilterDataList == null || this._auctionNewFilterDataList.Count <= 0)
			{
				return 0;
			}
			if (this._auctionNewFilterData == null)
			{
				return 0;
			}
			for (int i = 0; i < this._auctionNewFilterDataList.Count; i++)
			{
				AuctionNewFilterData auctionNewFilterData = this._auctionNewFilterDataList[i];
				if (auctionNewFilterData != null)
				{
					if (auctionNewFilterData.FilterItemType == this._auctionNewFilterData.FilterItemType && auctionNewFilterData.Id == this._auctionNewFilterData.Id)
					{
						return i;
					}
				}
			}
			return result;
		}

		// Token: 0x0600CB0D RID: 51981 RVA: 0x0031C397 File Offset: 0x0031A797
		private void OnCloseButtonClick()
		{
			this.UpdateFilterElementItemListVisible(false);
		}

		// Token: 0x0600CB0E RID: 51982 RVA: 0x0031C3A0 File Offset: 0x0031A7A0
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

		// Token: 0x040075F2 RID: 30194
		private AuctionNewFilterData _auctionNewFilterData;

		// Token: 0x040075F3 RID: 30195
		private List<AuctionNewFilterData> _auctionNewFilterDataList = new List<AuctionNewFilterData>();

		// Token: 0x040075F4 RID: 30196
		private int _defaultSelectedIndex;

		// Token: 0x040075F5 RID: 30197
		private OnAuctionNewFilterElementItemButtonClick _onAuctionNewfilterElementItemButtonClick;

		// Token: 0x040075F6 RID: 30198
		private Action _onResetFilterListAction;

		// Token: 0x040075F7 RID: 30199
		[SerializeField]
		private Text filterName;

		// Token: 0x040075F8 RID: 30200
		[SerializeField]
		private Button filterButton;

		// Token: 0x040075F9 RID: 30201
		[SerializeField]
		private Button closeButton;

		// Token: 0x040075FA RID: 30202
		[SerializeField]
		private ComUIListScript filterElementItemList;

		// Token: 0x040075FB RID: 30203
		[SerializeField]
		private GameObject filterElementItemListRoot;
	}
}
