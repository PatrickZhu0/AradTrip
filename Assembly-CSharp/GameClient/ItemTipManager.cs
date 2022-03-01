using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200129B RID: 4763
	internal class ItemTipManager : DataManager<ItemTipManager>
	{
		// Token: 0x0600B74F RID: 46927 RVA: 0x0029D383 File Offset: 0x0029B783
		public override void Initialize()
		{
		}

		// Token: 0x0600B750 RID: 46928 RVA: 0x0029D385 File Offset: 0x0029B785
		public override void Clear()
		{
			this.CloseAll();
		}

		// Token: 0x0600B751 RID: 46929 RVA: 0x0029D390 File Offset: 0x0029B790
		public void ShowPetTips(PetItemTipsData petData, PetItemTipsData comparePetData)
		{
			if (petData == null)
			{
				return;
			}
			ItemTipPetData itemTipPetData = new ItemTipPetData();
			itemTipPetData.textAnchor = 4;
			itemTipPetData.item = petData;
			itemTipPetData.compareItem = comparePetData;
			itemTipPetData.nTipIndex = this.m_nMaxTipFrameIdx;
			this.m_nMaxTipFrameIdx++;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ItemTipFrame>(FrameLayer.Middle, itemTipPetData, this._GetFrameName(this.m_nMaxTipFrameIdx));
		}

		// Token: 0x0600B752 RID: 46930 RVA: 0x0029D3F4 File Offset: 0x0029B7F4
		public void ShowTipWithCompareItem(ItemData a_item, ItemData a_compareItem, List<TipFuncButon> funcs = null, bool a_enableMask = true)
		{
			if (a_item == null || a_compareItem == null)
			{
				return;
			}
			ItemTipData itemTipData = new ItemTipData();
			itemTipData.item = a_item;
			itemTipData.itemSuitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(a_item.SuitID);
			itemTipData.compareItem = a_compareItem;
			itemTipData.compareItemSuitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(a_compareItem.SuitID);
			itemTipData.textAnchor = 4;
			itemTipData.funcs = funcs;
			itemTipData.giftItemIsRequestServer = true;
			this.m_nMaxTipFrameIdx++;
			itemTipData.nTipIndex = this.m_nMaxTipFrameIdx;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ItemTipFrame>(FrameLayer.Middle, itemTipData, this._GetFrameName(this.m_nMaxTipFrameIdx));
		}

		// Token: 0x0600B753 RID: 46931 RVA: 0x0029D498 File Offset: 0x0029B898
		public ItemData GetCompareItem(ItemData a_item)
		{
			ItemData result = null;
			if (a_item.Type == ItemTable.eType.EQUIP || a_item.Type == ItemTable.eType.FASHION || a_item.Type == ItemTable.eType.FUCKTITTLE)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(a_item.GUID);
				if (item == null || (item.PackageType != EPackageType.WearEquip && item.PackageType != EPackageType.WearFashion))
				{
					if (a_item.Type == ItemTable.eType.EQUIP || a_item.Type == ItemTable.eType.FUCKTITTLE)
					{
						List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
						if (itemsByPackageType != null)
						{
							for (int i = 0; i < itemsByPackageType.Count; i++)
							{
								ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
								if (item2 != null && item2.EquipWearSlotType == a_item.EquipWearSlotType)
								{
									result = item2;
									break;
								}
							}
						}
					}
					else if (a_item.Type == ItemTable.eType.FASHION)
					{
						List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
						if (itemsByPackageType2 != null)
						{
							for (int j = 0; j < itemsByPackageType2.Count; j++)
							{
								ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[j]);
								if (item3 != null && item3.FashionWearSlotType == a_item.FashionWearSlotType)
								{
									result = item3;
									break;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600B754 RID: 46932 RVA: 0x0029D5E7 File Offset: 0x0029B9E7
		public void ShowTipWithoutModelAvatar(ItemData itemData)
		{
			this.ShowTip(itemData, null, 4, true, true, true);
		}

		// Token: 0x0600B755 RID: 46933 RVA: 0x0029D5F8 File Offset: 0x0029B9F8
		public void ShowTip(ItemData a_item, List<TipFuncButon> funcs = null, TextAnchor a_textAnchor = 4, bool a_enableMask = true, bool isForceCloseModelAvatar = false, bool giftItemIsRequestServer = true)
		{
			if (a_item == null)
			{
				return;
			}
			ItemData compareItem = this.GetCompareItem(a_item);
			EquipSuitObj compareItemSuitObj = null;
			if (compareItem != null)
			{
				compareItemSuitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(compareItem.SuitID);
			}
			ItemTipData itemTipData = new ItemTipData();
			itemTipData.item = a_item;
			itemTipData.itemSuitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(a_item.SuitID);
			itemTipData.compareItem = compareItem;
			itemTipData.compareItemSuitObj = compareItemSuitObj;
			itemTipData.textAnchor = a_textAnchor;
			itemTipData.funcs = funcs;
			itemTipData.IsForceCloseModelAvatar = isForceCloseModelAvatar;
			itemTipData.giftItemIsRequestServer = giftItemIsRequestServer;
			this.m_nMaxTipFrameIdx++;
			itemTipData.nTipIndex = this.m_nMaxTipFrameIdx;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ItemTipFrame>(FrameLayer.Middle, itemTipData, this._GetFrameName(this.m_nMaxTipFrameIdx));
		}

		// Token: 0x0600B756 RID: 46934 RVA: 0x0029D6B0 File Offset: 0x0029BAB0
		public void ShowOtherPlayerTipWithCompareItem(ItemData a_item, EquipSuitObj a_itemSuitObj, ItemData a_compareItem, EquipSuitObj a_compareItemSuitObj, List<TipFuncButon> funcs = null, bool a_enableMask = true)
		{
			if (a_item == null)
			{
				return;
			}
			ItemTipData itemTipData = new ItemTipData();
			itemTipData.item = a_item;
			itemTipData.itemSuitObj = a_itemSuitObj;
			itemTipData.compareItem = a_compareItem;
			itemTipData.compareItemSuitObj = a_compareItemSuitObj;
			itemTipData.textAnchor = 4;
			itemTipData.funcs = funcs;
			this.m_nMaxTipFrameIdx++;
			itemTipData.nTipIndex = this.m_nMaxTipFrameIdx;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ItemTipFrame>(FrameLayer.Middle, itemTipData, this._GetFrameName(this.m_nMaxTipFrameIdx));
		}

		// Token: 0x0600B757 RID: 46935 RVA: 0x0029D72C File Offset: 0x0029BB2C
		public void ShowOtherPlayerTip(ItemData a_item, EquipSuitObj a_itemSuitObj, List<TipFuncButon> funcs = null, TextAnchor a_textAnchor = 4, bool a_enableMask = true)
		{
			if (a_item == null)
			{
				return;
			}
			ItemData compareItem = this.GetCompareItem(a_item);
			EquipSuitObj compareItemSuitObj = null;
			if (compareItem != null)
			{
				compareItemSuitObj = DataManager<EquipSuitDataManager>.GetInstance().GetSelfEquipSuitObj(compareItem.SuitID);
			}
			ItemTipData itemTipData = new ItemTipData();
			itemTipData.item = a_item;
			itemTipData.itemSuitObj = a_itemSuitObj;
			itemTipData.compareItem = compareItem;
			itemTipData.compareItemSuitObj = compareItemSuitObj;
			itemTipData.textAnchor = a_textAnchor;
			itemTipData.funcs = funcs;
			itemTipData.giftItemIsRequestServer = true;
			this.m_nMaxTipFrameIdx++;
			itemTipData.nTipIndex = this.m_nMaxTipFrameIdx;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ItemTipFrame>(FrameLayer.Middle, itemTipData, this._GetFrameName(this.m_nMaxTipFrameIdx));
		}

		// Token: 0x0600B758 RID: 46936 RVA: 0x0029D7CC File Offset: 0x0029BBCC
		public void CloseAll()
		{
			while (this.m_nMaxTipFrameIdx >= 0)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame(this._GetFrameName(this.m_nMaxTipFrameIdx));
				this.m_nMaxTipFrameIdx--;
			}
			this.m_nMaxTipFrameIdx = -1;
		}

		// Token: 0x0600B759 RID: 46937 RVA: 0x0029D80C File Offset: 0x0029BC0C
		public void CloseTip(int a_nTipIndex)
		{
			while (this.m_nMaxTipFrameIdx >= a_nTipIndex)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame(this._GetFrameName(this.m_nMaxTipFrameIdx));
				this.m_nMaxTipFrameIdx--;
			}
			if (this.m_nMaxTipFrameIdx < 0)
			{
				this.m_nMaxTipFrameIdx = -1;
			}
		}

		// Token: 0x0600B75A RID: 46938 RVA: 0x0029D861 File Offset: 0x0029BC61
		private string _GetFrameName(int nIdx)
		{
			return string.Format("ItemTipFrame{0}", nIdx);
		}

		// Token: 0x0600B75B RID: 46939 RVA: 0x0029D874 File Offset: 0x0029BC74
		public int GetItemTipModelAvatarLayerIndex(int itemTipIndex)
		{
			int currentShowModelAvatarLayerNumber = this.GetCurrentShowModelAvatarLayerNumber(itemTipIndex);
			int num = currentShowModelAvatarLayerNumber + this.ItemTipModelAvatarBaseLayerIndex;
			if (num < this.ItemTipModelAvatarBaseLayerIndex)
			{
				num = this.ItemTipModelAvatarBaseLayerIndex;
			}
			else if (num > this.ItemTipModelAvatarMaxLayerIndex)
			{
				num = this.ItemTipModelAvatarMaxLayerIndex;
			}
			return num;
		}

		// Token: 0x0600B75C RID: 46940 RVA: 0x0029D8C0 File Offset: 0x0029BCC0
		private int GetCurrentShowModelAvatarLayerNumber(int currentItemTipIndex)
		{
			int num = 0;
			if (currentItemTipIndex <= 0)
			{
				return num;
			}
			for (int i = 0; i < currentItemTipIndex; i++)
			{
				string name = this._GetFrameName(i);
				ItemTipFrame itemTipFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(name) as ItemTipFrame;
				if (itemTipFrame != null && itemTipFrame.GetShowModelAvatarFlag())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0400676B RID: 26475
		private int m_nMaxTipFrameIdx = -1;

		// Token: 0x0400676C RID: 26476
		public readonly int ItemTipModelAvatarBaseLayerIndex = 29;

		// Token: 0x0400676D RID: 26477
		public readonly int ItemTipModelAvatarMaxLayerIndex = 31;
	}
}
