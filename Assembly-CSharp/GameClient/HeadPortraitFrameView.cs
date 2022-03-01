using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200196A RID: 6506
	public class HeadPortraitFrameView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600FCF7 RID: 64759 RVA: 0x0045A213 File Offset: 0x00458613
		private void Awake()
		{
			this.InitHeadPortraitItemUIList();
			this.InitHeadPortraitInfoMation();
		}

		// Token: 0x0600FCF8 RID: 64760 RVA: 0x0045A221 File Offset: 0x00458621
		public void InitView(OnHeadPortraitTabItemClick onHeadPortraitTabItemClick)
		{
			this.mOnHeadPortraitTabItemClick = onHeadPortraitTabItemClick;
			this.InitMainTabUIList();
		}

		// Token: 0x0600FCF9 RID: 64761 RVA: 0x0045A230 File Offset: 0x00458630
		private void InitHeadPortraitItemUIList()
		{
			if (this.mHeadPortraitItemUIList != null)
			{
				this.mHeadPortraitItemUIList.Initialize();
				ComUIListScript comUIListScript = this.mHeadPortraitItemUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mHeadPortraitItemUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mHeadPortraitItemUIList;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript4 = this.mHeadPortraitItemUIList;
				comUIListScript4.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript4.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript5 = this.mHeadPortraitItemUIList;
				comUIListScript5.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript5.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
				this.mHeadPortraitItemUIList.SetElementAmount(0);
			}
		}

		// Token: 0x0600FCFA RID: 64762 RVA: 0x0045A328 File Offset: 0x00458728
		private void UnInitHeadPortraitItemUIList()
		{
			if (this.mHeadPortraitItemUIList != null)
			{
				ComUIListScript comUIListScript = this.mHeadPortraitItemUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mHeadPortraitItemUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mHeadPortraitItemUIList;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript4 = this.mHeadPortraitItemUIList;
				comUIListScript4.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript4.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript5 = this.mHeadPortraitItemUIList;
				comUIListScript5.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript5.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
			this.mHeadPortraitItemUIList = null;
		}

		// Token: 0x0600FCFB RID: 64763 RVA: 0x0045A410 File Offset: 0x00458810
		private HeadPortraitItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<HeadPortraitItem>();
		}

		// Token: 0x0600FCFC RID: 64764 RVA: 0x0045A418 File Offset: 0x00458818
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			HeadPortraitItem headPortraitItem = item.gameObjectBindScript as HeadPortraitItem;
			if (headPortraitItem == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this.mSelfItemDataList.Count)
			{
				headPortraitItem.OnItemVisiable(this.mSelfItemDataList[item.m_index]);
			}
		}

		// Token: 0x0600FCFD RID: 64765 RVA: 0x0045A478 File Offset: 0x00458878
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			HeadPortraitItem headPortraitItem = item.gameObjectBindScript as HeadPortraitItem;
			if (headPortraitItem == null)
			{
				return;
			}
			if (headPortraitItem.HeadPortraitItemData.itemID == this.mCurSelectHeadPortraitItemID)
			{
				return;
			}
			this.mCurSelectHeadPortraitItemIndex = item.m_index;
			this.mCurSelectHeadPortraitItemID = headPortraitItem.HeadPortraitItemData.itemID;
			this.RefreshHeadPortraitInfoMation(headPortraitItem.HeadPortraitItemData);
		}

		// Token: 0x0600FCFE RID: 64766 RVA: 0x0045A4E0 File Offset: 0x004588E0
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			HeadPortraitItem headPortraitItem = item.gameObjectBindScript as HeadPortraitItem;
			if (headPortraitItem == null)
			{
				return;
			}
			headPortraitItem.OnItemChangeDisplay(bSelected);
		}

		// Token: 0x0600FCFF RID: 64767 RVA: 0x0045A510 File Offset: 0x00458910
		private void InitMainTabUIList()
		{
			if (this.mMainTabUIList != null)
			{
				this.mMainTabUIList.Initialize();
				ComUIListScript comUIListScript = this.mMainTabUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnMainTabBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisiableDelegate));
				this.mMainTabUIList.SetElementAmount(this.mMainTabList.Count);
			}
		}

		// Token: 0x0600FD00 RID: 64768 RVA: 0x0045A5A0 File Offset: 0x004589A0
		private void UnInitMainTabUIList()
		{
			if (this.mMainTabUIList != null)
			{
				ComUIListScript comUIListScript = this.mMainTabUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnMainTabBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisiableDelegate));
			}
			this.mMainTabUIList = null;
		}

		// Token: 0x0600FD01 RID: 64769 RVA: 0x0045A613 File Offset: 0x00458A13
		private HeadPortraitTabItem OnMainTabBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<HeadPortraitTabItem>();
		}

		// Token: 0x0600FD02 RID: 64770 RVA: 0x0045A61C File Offset: 0x00458A1C
		private void OnMainTabItemVisiableDelegate(ComUIListElementScript item)
		{
			HeadPortraitTabItem headPortraitTabItem = item.gameObjectBindScript as HeadPortraitTabItem;
			if (headPortraitTabItem == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this.mMainTabList.Count)
			{
				if (this.mMainTabList[item.m_index].index == 0)
				{
					headPortraitTabItem.InitTabItem(this.mMainTabList[item.m_index], this.mOnHeadPortraitTabItemClick, true);
				}
				else
				{
					headPortraitTabItem.InitTabItem(this.mMainTabList[item.m_index], this.mOnHeadPortraitTabItemClick, false);
				}
			}
		}

		// Token: 0x0600FD03 RID: 64771 RVA: 0x0045A6C0 File Offset: 0x00458AC0
		private void InitHeadPortraitInfoMation()
		{
			if (this.mGoHeadPortraitInfomation != null)
			{
				UIPrefabWrapper component = this.mGoHeadPortraitInfomation.GetComponent<UIPrefabWrapper>();
				if (component != null)
				{
					GameObject gameObject = component.LoadUIPrefab();
					Utility.AttachTo(gameObject, this.mGoHeadPortraitInfomation, false);
					if (this.mHeadPortraitInfoMationView == null)
					{
						this.mHeadPortraitInfoMationView = gameObject.GetComponent<HeadPortraitInfoMationView>();
					}
				}
			}
		}

		// Token: 0x0600FD04 RID: 64772 RVA: 0x0045A728 File Offset: 0x00458B28
		public void UpdateHeadProtraitItem(List<HeadPortraitItemData> list, bool isResetIndex = false)
		{
			this.mCurSelectHeadPortraitItemID = 0;
			if (isResetIndex)
			{
				this.mCurSelectHeadPortraitItemIndex = 0;
			}
			this.mSelfItemDataList = new List<HeadPortraitItemData>();
			this.mSelfItemDataList = list;
			this.mSelfItemDataList.Sort();
			if (this.mHeadPortraitItemUIList != null)
			{
				this.mHeadPortraitItemUIList.ResetSelectedElementIndex();
				this.mHeadPortraitItemUIList.SetElementAmount(this.mSelfItemDataList.Count);
				this.mHeadPortraitItemUIList.SelectElement(this.mCurSelectHeadPortraitItemIndex, true);
				if (this.mHeadPortraitInfoMationView != null)
				{
					this.mHeadPortraitInfoMationView.SetGameobjectRoot(this.mSelfItemDataList.Count > 0);
				}
			}
		}

		// Token: 0x0600FD05 RID: 64773 RVA: 0x0045A7D4 File Offset: 0x00458BD4
		private void RefreshHeadPortraitInfoMation(HeadPortraitItemData itemData)
		{
			if (this.mHeadPortraitInfoMationView != null)
			{
				this.mHeadPortraitInfoMationView.RefreshHeadPortraitInfoMation(itemData);
			}
		}

		// Token: 0x0600FD06 RID: 64774 RVA: 0x0045A7F3 File Offset: 0x00458BF3
		public void Dispose()
		{
			this.mOnHeadPortraitTabItemClick = null;
			this.mHeadPortraitInfoMationView = null;
			this.mCurSelectHeadPortraitItemIndex = 0;
			this.mCurSelectHeadPortraitItemID = 0;
			this.UnInitHeadPortraitItemUIList();
			this.UnInitMainTabUIList();
		}

		// Token: 0x0600FD07 RID: 64775 RVA: 0x0045A81D File Offset: 0x00458C1D
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04009EE5 RID: 40677
		[SerializeField]
		private List<HeadPortraitTabDataModel> mMainTabList;

		// Token: 0x04009EE6 RID: 40678
		[SerializeField]
		private ComUIListScript mMainTabUIList;

		// Token: 0x04009EE7 RID: 40679
		[SerializeField]
		private ComUIListScript mHeadPortraitItemUIList;

		// Token: 0x04009EE8 RID: 40680
		[SerializeField]
		private GameObject mGoHeadPortraitInfomation;

		// Token: 0x04009EE9 RID: 40681
		private List<HeadPortraitItemData> mSelfItemDataList = new List<HeadPortraitItemData>();

		// Token: 0x04009EEA RID: 40682
		private OnHeadPortraitTabItemClick mOnHeadPortraitTabItemClick;

		// Token: 0x04009EEB RID: 40683
		private HeadPortraitInfoMationView mHeadPortraitInfoMationView;

		// Token: 0x04009EEC RID: 40684
		private int mCurSelectHeadPortraitItemID;

		// Token: 0x04009EED RID: 40685
		private int mCurSelectHeadPortraitItemIndex;
	}
}
