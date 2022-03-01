using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B84 RID: 7044
	public class StrengthenDeviceItem : MonoBehaviour
	{
		// Token: 0x0601146D RID: 70765 RVA: 0x004FBC05 File Offset: 0x004FA005
		private void Awake()
		{
			if (this.mSelectedBtn != null)
			{
				this.mSelectedBtn.onClick.RemoveAllListeners();
				this.mSelectedBtn.onClick.AddListener(new UnityAction(this.OnSelectedClick));
			}
		}

		// Token: 0x0601146E RID: 70766 RVA: 0x004FBC44 File Offset: 0x004FA044
		private void OnDestroy()
		{
			this.mStrengthenGrowthType = StrengthenGrowthType.SGT_Strengthen;
			this.mOnStrengthenDeviceItem = null;
		}

		// Token: 0x0601146F RID: 70767 RVA: 0x004FBC54 File Offset: 0x004FA054
		private void OnSelectedClick()
		{
			if (this.mStrengthenGrowthType == StrengthenGrowthType.SGT_Strengthen)
			{
				List<ItemData> disposableStrengItemList = DataManager<StrengthenDataManager>.GetInstance().GetDisposableStrengItemList(StrengthenView.CurrentSelectItemData);
				if (disposableStrengItemList.Count <= 0)
				{
					ItemComeLink.OnLink(330000242, 0, false, null, false, false, false, null, string.Empty);
					return;
				}
			}
			else if (this.mStrengthenGrowthType == StrengthenGrowthType.SGT_Gtowth)
			{
				List<ItemData> disposableIncreaseItemList = DataManager<EquipGrowthDataManager>.GetInstance().GetDisposableIncreaseItemList(EquipGrowthView.CurrentSelectItemData);
				if (disposableIncreaseItemList.Count <= 0)
				{
					ItemComeLink.OnLink(330000243, 0, false, null, false, false, false, null, string.Empty);
					return;
				}
			}
			GrowthExpendData growthExpendData = new GrowthExpendData();
			growthExpendData.mStrengthenGrowthType = this.mStrengthenGrowthType;
			growthExpendData.mOnItemClick = new UnityAction<ItemData>(this.RefreshExpendItemData);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SingleUseExpendItemFrame>(FrameLayer.Middle, growthExpendData, string.Empty);
		}

		// Token: 0x06011470 RID: 70768 RVA: 0x004FBD1C File Offset: 0x004FA11C
		private void RefreshExpendItemData(ItemData item)
		{
			if (item == null)
			{
				return;
			}
			this.OnSetBgImg(item.GetQualityInfo().Background);
			this.OnSetIconImg(item.Icon);
			this.OnSetCount(string.Format("{0}/1", item.Count));
			this.OnStrengthenDeviceItem(item);
			this.OnSetParentGameObject(true);
			this.SetName(item);
		}

		// Token: 0x06011471 RID: 70769 RVA: 0x004FBD7D File Offset: 0x004FA17D
		public void InitItem(StrengthenGrowthType strengthenType, OnStrengthenDeviceItem click)
		{
			this.mStrengthenGrowthType = strengthenType;
			this.mOnStrengthenDeviceItem = click;
			this.SetName(null);
		}

		// Token: 0x06011472 RID: 70770 RVA: 0x004FBD94 File Offset: 0x004FA194
		private void SetName(ItemData item)
		{
			if (this.mName != null)
			{
				if (item == null)
				{
					if (this.mStrengthenGrowthType == StrengthenGrowthType.SGT_Strengthen)
					{
						this.mName.text = this.mStrengthenDesc;
					}
					else if (this.mStrengthenGrowthType == StrengthenGrowthType.SGT_Gtowth)
					{
						this.mName.text = this.mGrowthDesc;
					}
				}
				else
				{
					this.mName.text = item.GetColorName(string.Empty, false);
				}
			}
		}

		// Token: 0x06011473 RID: 70771 RVA: 0x004FBE14 File Offset: 0x004FA214
		public void SetItem(ItemData item)
		{
			this.SetName(item);
			if (item == null)
			{
				this.OnSetParentGameObject(false);
				this.OnSetCount(string.Empty);
			}
			else
			{
				this.OnSetBgImg(item.GetQualityInfo().Background);
				this.OnSetIconImg(item.Icon);
				this.OnSetCount(string.Format("{0}/1", item.Count));
				this.OnSetParentGameObject(true);
			}
		}

		// Token: 0x06011474 RID: 70772 RVA: 0x004FBE84 File Offset: 0x004FA284
		private void OnStrengthenDeviceItem(ItemData item)
		{
			if (this.mOnStrengthenDeviceItem != null)
			{
				this.mOnStrengthenDeviceItem(item);
			}
		}

		// Token: 0x06011475 RID: 70773 RVA: 0x004FBE9D File Offset: 0x004FA29D
		private void OnSetCount(string str)
		{
			if (this.mCount != null)
			{
				this.mCount.text = str;
			}
		}

		// Token: 0x06011476 RID: 70774 RVA: 0x004FBEBC File Offset: 0x004FA2BC
		private void OnSetBgImg(string path)
		{
			if (this.mItemBgImg != null)
			{
				ETCImageLoader.LoadSprite(ref this.mItemBgImg, path, true);
			}
		}

		// Token: 0x06011477 RID: 70775 RVA: 0x004FBEDD File Offset: 0x004FA2DD
		private void OnSetIconImg(string path)
		{
			if (this.mItemIconImg != null)
			{
				ETCImageLoader.LoadSprite(ref this.mItemIconImg, path, true);
			}
		}

		// Token: 0x06011478 RID: 70776 RVA: 0x004FBEFE File Offset: 0x004FA2FE
		private void OnSetParentGameObject(bool isFlag)
		{
			if (this.mItemParent != null)
			{
				this.mItemParent.CustomActive(isFlag);
			}
		}

		// Token: 0x06011479 RID: 70777 RVA: 0x004FBF20 File Offset: 0x004FA320
		private ItemData OnFillTheProps()
		{
			ItemData result = null;
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
			if (this.mStrengthenGrowthType == StrengthenGrowthType.SGT_Strengthen)
			{
				if (itemsByPackageType != null)
				{
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
						if (item != null)
						{
							if (item.ThirdType == ItemTable.eThirdType.DisposableStrengItem)
							{
								list.Add(item);
							}
						}
					}
				}
			}
			else if (this.mStrengthenGrowthType == StrengthenGrowthType.SGT_Gtowth && itemsByPackageType != null)
			{
				for (int j = 0; j < itemsByPackageType.Count; j++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
					if (item2 != null)
					{
						if (item2.ThirdType == ItemTable.eThirdType.DisposableIncreaseItem)
						{
							list.Add(item2);
						}
					}
				}
			}
			List<ItemData> list2 = new List<ItemData>();
			list2 = this.FiltrateItemDatas(list, ItemTable.eOwner.ROLEBIND);
			if (list2.Count > 0)
			{
				result = this.FiltrateItem(list2);
			}
			else
			{
				list2 = this.FiltrateItemDatas(list, ItemTable.eOwner.ACCBIND);
				if (list2.Count > 0)
				{
					result = this.FiltrateItem(list2);
				}
				else
				{
					list2 = this.FiltrateItemDatas(list, ItemTable.eOwner.NOTBIND);
					if (list2.Count > 0)
					{
						result = this.FiltrateItem(list2);
					}
				}
			}
			return result;
		}

		// Token: 0x0601147A RID: 70778 RVA: 0x004FC088 File Offset: 0x004FA488
		private List<ItemData> FiltrateItemDatas(List<ItemData> mItemDatas, ItemTable.eOwner owner)
		{
			List<ItemData> list = new List<ItemData>();
			for (int i = 0; i < mItemDatas.Count; i++)
			{
				ItemData itemData = mItemDatas[i];
				if (itemData != null)
				{
					if (itemData.BindAttr == owner)
					{
						list.Add(itemData);
					}
				}
			}
			return list;
		}

		// Token: 0x0601147B RID: 70779 RVA: 0x004FC0E0 File Offset: 0x004FA4E0
		private ItemData FiltrateItem(List<ItemData> filtrateItems)
		{
			List<ItemData> list = new List<ItemData>();
			for (int i = 0; i < filtrateItems.Count; i++)
			{
				ItemData itemData = filtrateItems[i];
				if (itemData != null)
				{
					if (itemData.DeadTimestamp > 0)
					{
						list.Add(itemData);
					}
				}
			}
			ItemData result;
			if (list.Count > 0)
			{
				list.Sort(delegate(ItemData x, ItemData y)
				{
					int num = x.DeadTimestamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
					int num2 = y.DeadTimestamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
					return num - num2;
				});
				result = list[0];
			}
			else
			{
				result = filtrateItems[0];
			}
			return result;
		}

		// Token: 0x0400B289 RID: 45705
		[SerializeField]
		private Button mSelectedBtn;

		// Token: 0x0400B28A RID: 45706
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B28B RID: 45707
		[SerializeField]
		private Text mCount;

		// Token: 0x0400B28C RID: 45708
		[SerializeField]
		private Text mName;

		// Token: 0x0400B28D RID: 45709
		[SerializeField]
		private Image mItemBgImg;

		// Token: 0x0400B28E RID: 45710
		[SerializeField]
		private Image mItemIconImg;

		// Token: 0x0400B28F RID: 45711
		[SerializeField]
		private string mStrengthenDesc = "选择强化装置";

		// Token: 0x0400B290 RID: 45712
		[SerializeField]
		private string mGrowthDesc = "选择激化装置";

		// Token: 0x0400B291 RID: 45713
		private StrengthenGrowthType mStrengthenGrowthType;

		// Token: 0x0400B292 RID: 45714
		private OnStrengthenDeviceItem mOnStrengthenDeviceItem;
	}
}
