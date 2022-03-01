using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B7D RID: 7037
	public class GrowthExpendItemFrame : ClientFrame
	{
		// Token: 0x06011427 RID: 70695 RVA: 0x004FA318 File Offset: 0x004F8718
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/StrengthenGrowth/GrowthExpendItemFrame";
		}

		// Token: 0x06011428 RID: 70696 RVA: 0x004FA31F File Offset: 0x004F871F
		protected sealed override void _OnOpenFrame()
		{
			this.mGrowthExpendItemData = (this.userData as GrowthExpendData);
			this.InitExpendItemComUIListScript();
			this.LoadGrowthExpendItemList();
			this.UpdateLinkID();
		}

		// Token: 0x06011429 RID: 70697 RVA: 0x004FA344 File Offset: 0x004F8744
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitExpendItemComUIListScript();
			if (this.mGrowthExpengItemList != null)
			{
				this.mGrowthExpengItemList.Clear();
			}
			this.mGrowthExpendItemData = null;
		}

		// Token: 0x0601142A RID: 70698 RVA: 0x004FA36C File Offset: 0x004F876C
		private void LoadGrowthExpendItemList()
		{
			if (this.mGrowthExpengItemList != null)
			{
				this.mGrowthExpengItemList = new List<ItemData>();
			}
			else
			{
				this.mGrowthExpengItemList.Clear();
			}
			if (this.mGrowthExpendItemData != null)
			{
				if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Strengthen)
				{
					List<ItemData> strengthenStampList = DataManager<StrengthenDataManager>.GetInstance().GetStrengthenStampList(this.mGrowthExpendItemData.mEquipItemData);
					if (strengthenStampList != null)
					{
						this.mGrowthExpengItemList.AddRange(strengthenStampList);
					}
				}
				else if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Gtowth)
				{
					List<ItemData> growthStampList = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthStampList(this.mGrowthExpendItemData.mEquipItemData);
					if (growthStampList != null)
					{
						this.mGrowthExpengItemList.AddRange(growthStampList);
					}
				}
				else
				{
					List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Material);
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
						if (item != null)
						{
							if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Activate)
							{
								if (item.SubType == 103)
								{
									item.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
									if (this.timeLeft > 0 || !this.bStartCountdown)
									{
										this.AddExpendItem(item);
									}
								}
							}
							else if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Clear)
							{
								if (item.SubType == 104)
								{
									item.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
									if (this.timeLeft > 0 || !this.bStartCountdown)
									{
										this.AddExpendItem(item);
									}
								}
							}
							else if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Change && this.mGrowthExpendItemData.mEquipItemData != null)
							{
								if (item.ThirdType != ItemTable.eThirdType.ZENGFU_COLOR_PURPLE || this.mGrowthExpendItemData.mEquipItemData.Quality == ItemTable.eColor.PURPLE)
								{
									if (item.ThirdType != ItemTable.eThirdType.ZENGFU_COLOR_GREEN || this.mGrowthExpendItemData.mEquipItemData.Quality == ItemTable.eColor.GREEN)
									{
										if (this.mGrowthExpendItemData.mEquipItemData.EquipType == EEquipType.ET_REDMARK)
										{
											if (item.SubType == 105)
											{
												item.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
												if (this.timeLeft > 0 || !this.bStartCountdown)
												{
													this.AddExpendItem(item);
												}
											}
										}
										else if (this.mGrowthExpendItemData.mEquipItemData.EquipType == EEquipType.ET_COMMON && this.mGrowthExpendItemData.mEquipItemData.StrengthenLevel <= 0)
										{
											if (item.SubType == 106)
											{
												item.GetLimitTimeLeft(out this.timeLeft, out this.bStartCountdown);
												if (this.timeLeft > 0 || !this.bStartCountdown)
												{
													this.AddExpendItem(item);
												}
											}
											else if (item.SubType == 107)
											{
												this.AddExpendItem(item);
											}
										}
										else if (this.mGrowthExpendItemData.mEquipItemData.EquipType == EEquipType.ET_COMMON && this.mGrowthExpendItemData.mEquipItemData.StrengthenLevel > 0 && item.SubType == 107)
										{
											this.AddExpendItem(item);
										}
									}
								}
							}
						}
					}
				}
				this.mExpendItemScrollView.SetElementAmount(this.mGrowthExpengItemList.Count);
			}
		}

		// Token: 0x0601142B RID: 70699 RVA: 0x004FA6F6 File Offset: 0x004F8AF6
		private void AddExpendItem(ItemData itemData)
		{
			this.mGrowthExpengItemList.Add(itemData);
		}

		// Token: 0x0601142C RID: 70700 RVA: 0x004FA704 File Offset: 0x004F8B04
		private void UpdateLinkID()
		{
			if (this.mGrowthExpengItemList.Count <= 0 && this.mGrowthExpendItemData != null)
			{
				if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Activate)
				{
					this.mLink.iItemLinkID = 300000205;
				}
				else if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Clear)
				{
					this.mLink.iItemLinkID = 300000206;
				}
				else if (this.mGrowthExpendItemData.mStrengthenGrowthType == StrengthenGrowthType.SGT_Change && this.mGrowthExpendItemData.mEquipItemData != null)
				{
					if (this.mGrowthExpendItemData.mEquipItemData.EquipType == EEquipType.ET_COMMON)
					{
						this.mLink.iItemLinkID = 300000202;
					}
					else if (this.mGrowthExpendItemData.mEquipItemData.EquipType == EEquipType.ET_REDMARK)
					{
						this.mLink.iItemLinkID = 300000204;
					}
				}
			}
		}

		// Token: 0x0601142D RID: 70701 RVA: 0x004FA7EC File Offset: 0x004F8BEC
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

		// Token: 0x0601142E RID: 70702 RVA: 0x004FA88C File Offset: 0x004F8C8C
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

		// Token: 0x0601142F RID: 70703 RVA: 0x004FA91F File Offset: 0x004F8D1F
		private GrowthExpendItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<GrowthExpendItem>();
		}

		// Token: 0x06011430 RID: 70704 RVA: 0x004FA928 File Offset: 0x004F8D28
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			GrowthExpendItem growthExpendItem = item.gameObjectBindScript as GrowthExpendItem;
			if (growthExpendItem != null && this.mGrowthExpendItemData != null && item.m_index >= 0 && item.m_index < this.mGrowthExpengItemList.Count)
			{
				growthExpendItem.OnItemVisiable(this.mGrowthExpengItemList[item.m_index]);
			}
		}

		// Token: 0x06011431 RID: 70705 RVA: 0x004FA994 File Offset: 0x004F8D94
		private void OnItemSelectDelegate(ComUIListElementScript item)
		{
			if (item != null && item.gameObjectBindScript != null)
			{
				GrowthExpendItem growthExpendItem = item.gameObjectBindScript as GrowthExpendItem;
				if (growthExpendItem != null && this.mGrowthExpendItemData != null && this.mGrowthExpendItemData.mOnItemClick != null && growthExpendItem.ItemData != null)
				{
					this.mGrowthExpendItemData.mOnItemClick.Invoke(growthExpendItem.ItemData);
				}
				base.Close(false);
			}
		}

		// Token: 0x06011432 RID: 70706 RVA: 0x004FAA13 File Offset: 0x004F8E13
		protected sealed override void _bindExUI()
		{
			this.mLink = this.mBind.GetCom<ItemComeLink>("Link");
			this.mExpendItemScrollView = this.mBind.GetCom<ComUIListScript>("ExpendItemScrollView");
		}

		// Token: 0x06011433 RID: 70707 RVA: 0x004FAA41 File Offset: 0x004F8E41
		protected sealed override void _unbindExUI()
		{
			this.mLink = null;
			this.mExpendItemScrollView = null;
		}

		// Token: 0x0400B262 RID: 45666
		private GrowthExpendData mGrowthExpendItemData;

		// Token: 0x0400B263 RID: 45667
		private List<ItemData> mGrowthExpengItemList = new List<ItemData>();

		// Token: 0x0400B264 RID: 45668
		private int timeLeft;

		// Token: 0x0400B265 RID: 45669
		private bool bStartCountdown;

		// Token: 0x0400B266 RID: 45670
		private ItemComeLink mLink;

		// Token: 0x0400B267 RID: 45671
		private ComUIListScript mExpendItemScrollView;
	}
}
