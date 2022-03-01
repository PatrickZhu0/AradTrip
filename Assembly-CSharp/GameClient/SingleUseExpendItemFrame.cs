using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B81 RID: 7041
	public class SingleUseExpendItemFrame : ClientFrame
	{
		// Token: 0x06011458 RID: 70744 RVA: 0x004FB859 File Offset: 0x004F9C59
		protected sealed override void _bindExUI()
		{
			this.mLink = this.mBind.GetCom<ItemComeLink>("Link");
			this.mExpendItemScrollView = this.mBind.GetCom<ComUIListScript>("ExpendItemScrollView");
		}

		// Token: 0x06011459 RID: 70745 RVA: 0x004FB887 File Offset: 0x004F9C87
		protected sealed override void _unbindExUI()
		{
			this.mLink = null;
			this.mExpendItemScrollView = null;
		}

		// Token: 0x0601145A RID: 70746 RVA: 0x004FB897 File Offset: 0x004F9C97
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/StrengthenGrowth/GrowthExpendItemFrame";
		}

		// Token: 0x0601145B RID: 70747 RVA: 0x004FB89E File Offset: 0x004F9C9E
		protected sealed override void _OnOpenFrame()
		{
			this.mExpendItemData = (this.userData as GrowthExpendData);
			this.InitExpendItemComUIListScript();
			this.LoadExpendItemList();
			this.UpdateLinkID();
		}

		// Token: 0x0601145C RID: 70748 RVA: 0x004FB8C3 File Offset: 0x004F9CC3
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitExpendItemComUIListScript();
			this.mExpendItemData = null;
			if (this.mExpengItemList != null)
			{
				this.mExpengItemList.Clear();
			}
		}

		// Token: 0x0601145D RID: 70749 RVA: 0x004FB8E8 File Offset: 0x004F9CE8
		private void LoadExpendItemList()
		{
			if (this.mExpendItemData != null)
			{
				List<ItemData> collection = new List<ItemData>();
				if (this.mExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Strengthen)
				{
					collection = DataManager<StrengthenDataManager>.GetInstance().GetDisposableStrengItemList(StrengthenView.CurrentSelectItemData);
				}
				else if (this.mExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Gtowth)
				{
					collection = DataManager<EquipGrowthDataManager>.GetInstance().GetDisposableIncreaseItemList(EquipGrowthView.CurrentSelectItemData);
				}
				this.mExpengItemList.AddRange(collection);
			}
			this.mExpendItemScrollView.SetElementAmount(this.mExpengItemList.Count);
		}

		// Token: 0x0601145E RID: 70750 RVA: 0x004FB970 File Offset: 0x004F9D70
		private void InitExpendItemComUIListScript()
		{
			if (this.mExpendItemScrollView != null)
			{
				this.mExpendItemScrollView.Initialize();
				ComUIListScript comUIListScript = this.mExpendItemScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mExpendItemScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mExpendItemScrollView;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectDelegate));
			}
		}

		// Token: 0x0601145F RID: 70751 RVA: 0x004FBA10 File Offset: 0x004F9E10
		private void UnInitExpendItemComUIListScript()
		{
			if (this.mExpendItemScrollView != null)
			{
				ComUIListScript comUIListScript = this.mExpendItemScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mExpendItemScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mExpendItemScrollView;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectDelegate));
			}
		}

		// Token: 0x06011460 RID: 70752 RVA: 0x004FBAA3 File Offset: 0x004F9EA3
		private GrowthExpendItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<GrowthExpendItem>();
		}

		// Token: 0x06011461 RID: 70753 RVA: 0x004FBAAC File Offset: 0x004F9EAC
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			GrowthExpendItem growthExpendItem = item.gameObjectBindScript as GrowthExpendItem;
			if (growthExpendItem != null && this.mExpendItemData != null && item.m_index >= 0 && item.m_index < this.mExpengItemList.Count)
			{
				growthExpendItem.OnItemVisiable(this.mExpengItemList[item.m_index]);
			}
		}

		// Token: 0x06011462 RID: 70754 RVA: 0x004FBB18 File Offset: 0x004F9F18
		private void OnItemSelectDelegate(ComUIListElementScript item)
		{
			GrowthExpendItem growthExpendItem = item.gameObjectBindScript as GrowthExpendItem;
			if (growthExpendItem != null && this.mExpendItemData != null)
			{
				if (this.mExpendItemData.mOnItemClick != null)
				{
					this.mExpendItemData.mOnItemClick.Invoke(growthExpendItem.ItemData);
				}
				base.Close(false);
			}
		}

		// Token: 0x06011463 RID: 70755 RVA: 0x004FBB78 File Offset: 0x004F9F78
		private void UpdateLinkID()
		{
			if (this.mExpengItemList.Count <= 0 && this.mExpendItemData != null)
			{
				if (this.mExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Strengthen)
				{
					this.mLink.iItemLinkID = 330000242;
				}
				else if (this.mExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Gtowth)
				{
					this.mLink.iItemLinkID = 330000243;
				}
			}
		}

		// Token: 0x0400B285 RID: 45701
		private GrowthExpendData mExpendItemData;

		// Token: 0x0400B286 RID: 45702
		private List<ItemData> mExpengItemList = new List<ItemData>();

		// Token: 0x0400B287 RID: 45703
		private ItemComeLink mLink;

		// Token: 0x0400B288 RID: 45704
		private ComUIListScript mExpendItemScrollView;
	}
}
