using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B8A RID: 7050
	public class StrengthenGrowthView : MonoBehaviour
	{
		// Token: 0x0601148C RID: 70796 RVA: 0x004FC356 File Offset: 0x004FA756
		private void Awake()
		{
			this.InitEquipItemUIListScript();
		}

		// Token: 0x0601148D RID: 70797 RVA: 0x004FC35E File Offset: 0x004FA75E
		private void OnDestroy()
		{
			this.UnInitEquipItemUIListScript();
			this.mAllEquipItem.Clear();
			this.CurrentSelectedStrengthGrowthType = StrengthenGrowthType.SGT_Strengthen;
			StrengthenGrowthView.mLastSelectedItemData = null;
			StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick = null;
			this.mCurrentSelectEquipemtnIndex = 0;
		}

		// Token: 0x0601148E RID: 70798 RVA: 0x004FC38B File Offset: 0x004FA78B
		public void OnSetStrengthGrowthType(StrengthenGrowthType type)
		{
			this.CurrentSelectedStrengthGrowthType = type;
			this.RefreshAllEquipments();
		}

		// Token: 0x0601148F RID: 70799 RVA: 0x004FC39A File Offset: 0x004FA79A
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.mLinkData = linkData;
		}

		// Token: 0x06011490 RID: 70800 RVA: 0x004FC3A4 File Offset: 0x004FA7A4
		public void RefreshAllEquipments()
		{
			this.LoadAllEquipments(ref this.mAllEquipItem, this.CurrentSelectedStrengthGrowthType);
			if (this.mEquipItemsUIList != null)
			{
				this.mEquipItemsUIList.SetElementAmount(this.mAllEquipItem.Count);
			}
			if (this.mAllEquipItem.Count > 0)
			{
				this.mEquipItemsUIList.ResetSelectedElementIndex();
				this.TrySetDefaultEquipment();
			}
			else
			{
				DataManager<StrengthenDataManager>.GetInstance().IsEquipmentStrengthBroken = false;
				DataManager<EquipGrowthDataManager>.GetInstance().IsEquipmentIntensifyBroken = false;
				this.UpdateNoEquipTipsDesc();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnEquipmentListNoEquipment, null, null, null, null);
			}
		}

		// Token: 0x06011491 RID: 70801 RVA: 0x004FC440 File Offset: 0x004FA840
		private void UpdateNoEquipTipsDesc()
		{
			string text = string.Empty;
			StrengthenGrowthType currentSelectedStrengthGrowthType = this.CurrentSelectedStrengthGrowthType;
			switch (currentSelectedStrengthGrowthType + 1)
			{
			case StrengthenGrowthType.SGT_Gtowth:
				text = TR.Value("no_equip_tips_desc_strengthen");
				break;
			case StrengthenGrowthType.SGT_Clear:
				text = TR.Value("no_equip_tips_desc_growth");
				break;
			case StrengthenGrowthType.SGT_Activate:
			case StrengthenGrowthType.SGT_Change:
				text = TR.Value("no_equip_tips_desc_clear_or_activation");
				break;
			case (StrengthenGrowthType)5:
				text = TR.Value("no_equip_tips_desc_changed");
				break;
			}
			if (this.mNoEquipTips != null)
			{
				this.mNoEquipTips.text = text;
			}
		}

		// Token: 0x06011492 RID: 70802 RVA: 0x004FC4E4 File Offset: 0x004FA8E4
		private void InitEquipItemUIListScript()
		{
			if (this.mEquipItemsUIList != null)
			{
				this.mEquipItemsUIList.Initialize();
				ComUIListScript comUIListScript = this.mEquipItemsUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipItemsUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipItemsUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipItemsUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06011493 RID: 70803 RVA: 0x004FC5AC File Offset: 0x004FA9AC
		private void UnInitEquipItemUIListScript()
		{
			if (this.mEquipItemsUIList != null)
			{
				ComUIListScript comUIListScript = this.mEquipItemsUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipItemsUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipItemsUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipItemsUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x06011494 RID: 70804 RVA: 0x004FC666 File Offset: 0x004FAA66
		private StrengthenGrowthEquipItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<StrengthenGrowthEquipItem>();
		}

		// Token: 0x06011495 RID: 70805 RVA: 0x004FC670 File Offset: 0x004FAA70
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			StrengthenGrowthEquipItem strengthenGrowthEquipItem = item.gameObjectBindScript as StrengthenGrowthEquipItem;
			if (strengthenGrowthEquipItem != null && item.m_index >= 0 && item.m_index < this.mAllEquipItem.Count)
			{
				strengthenGrowthEquipItem.OnItemVisible(this.mAllEquipItem[item.m_index], this.CurrentSelectedStrengthGrowthType);
				if (StrengthenGrowthView.mLastSelectedItemData != null && this.mAllEquipItem[item.m_index].GUID != StrengthenGrowthView.mLastSelectedItemData.GUID)
				{
					strengthenGrowthEquipItem.OnItemChangeDisplay(false);
				}
			}
		}

		// Token: 0x06011496 RID: 70806 RVA: 0x004FC70C File Offset: 0x004FAB0C
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			StrengthenGrowthEquipItem strengthenGrowthEquipItem = item.gameObjectBindScript as StrengthenGrowthEquipItem;
			if (strengthenGrowthEquipItem != null)
			{
				this.mCurrentSelectEquipemtnIndex = item.m_index;
				StrengthenGrowthView.mLastSelectedItemData = ((strengthenGrowthEquipItem.EquipItemData != null) ? strengthenGrowthEquipItem.EquipItemData : null);
				if (StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick != null)
				{
					StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick(StrengthenGrowthView.mLastSelectedItemData, this.CurrentSelectedStrengthGrowthType);
				}
			}
		}

		// Token: 0x06011497 RID: 70807 RVA: 0x004FC778 File Offset: 0x004FAB78
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			StrengthenGrowthEquipItem strengthenGrowthEquipItem = item.gameObjectBindScript as StrengthenGrowthEquipItem;
			if (strengthenGrowthEquipItem != null)
			{
				strengthenGrowthEquipItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06011498 RID: 70808 RVA: 0x004FC7A4 File Offset: 0x004FABA4
		private void LoadAllEquipments(ref List<ItemData> equipments, StrengthenGrowthType type)
		{
			if (equipments != null)
			{
				equipments.Clear();
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_ASSIST_EQUIP) || !item.IsAssistEquip())
					{
						if (!item.IsLease)
						{
							if (!item.isInSidePack)
							{
								if (item.DeadTimestamp <= 0)
								{
									switch (type)
									{
									case StrengthenGrowthType.SGT_Strengthen:
										if (item.EquipType != EEquipType.ET_COMMON)
										{
											goto IL_122;
										}
										break;
									case StrengthenGrowthType.SGT_Gtowth:
										if (item.EquipType != EEquipType.ET_REDMARK)
										{
											goto IL_122;
										}
										break;
									case StrengthenGrowthType.SGT_Clear:
									case StrengthenGrowthType.SGT_Activate:
										if (item.EquipType != EEquipType.ET_BREATH)
										{
											goto IL_122;
										}
										break;
									case StrengthenGrowthType.SGT_Change:
										if (item.EquipType == EEquipType.ET_BREATH)
										{
											goto IL_122;
										}
										if (item.Quality < ItemTable.eColor.PURPLE)
										{
											goto IL_122;
										}
										break;
									}
									equipments.Add(item);
								}
							}
						}
					}
				}
				IL_122:;
			}
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int j = 0; j < itemsByPackageType2.Count; j++)
			{
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[j]);
				if (item2 != null)
				{
					if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_ASSIST_EQUIP) || !item2.IsAssistEquip())
					{
						if (item2.Type == ItemTable.eType.EQUIP)
						{
							if (!item2.IsLease)
							{
								if (!item2.isInSidePack)
								{
									if (item2.DeadTimestamp <= 0)
									{
										switch (type)
										{
										case StrengthenGrowthType.SGT_Strengthen:
											if (item2.EquipType != EEquipType.ET_COMMON)
											{
												goto IL_266;
											}
											break;
										case StrengthenGrowthType.SGT_Gtowth:
											if (item2.EquipType != EEquipType.ET_REDMARK)
											{
												goto IL_266;
											}
											break;
										case StrengthenGrowthType.SGT_Clear:
										case StrengthenGrowthType.SGT_Activate:
											if (item2.EquipType != EEquipType.ET_BREATH)
											{
												goto IL_266;
											}
											break;
										case StrengthenGrowthType.SGT_Change:
											if (item2.EquipType == EEquipType.ET_BREATH)
											{
												goto IL_266;
											}
											if (item2.Quality < ItemTable.eColor.PURPLE)
											{
												goto IL_266;
											}
											break;
										}
										equipments.Add(item2);
									}
								}
							}
						}
					}
				}
				IL_266:;
			}
			equipments.Sort(new Comparison<ItemData>(this.SortEquipments));
		}

		// Token: 0x06011499 RID: 70809 RVA: 0x004FCA40 File Offset: 0x004FAE40
		private int SortEquipments(ItemData left, ItemData right)
		{
			if (left.PackageType != right.PackageType)
			{
				return right.PackageType - left.PackageType;
			}
			if (left.IsItemInUnUsedEquipPlan != right.IsItemInUnUsedEquipPlan)
			{
				if (left.IsItemInUnUsedEquipPlan)
				{
					return -1;
				}
				if (right.IsItemInUnUsedEquipPlan)
				{
					return 1;
				}
			}
			if (left.Quality != right.Quality)
			{
				return right.Quality - left.Quality;
			}
			if (left.SubType != right.SubType)
			{
				return left.SubType - right.SubType;
			}
			if (left.StrengthenLevel != right.StrengthenLevel)
			{
				return right.StrengthenLevel - left.StrengthenLevel;
			}
			return right.LevelLimit - left.LevelLimit;
		}

		// Token: 0x0601149A RID: 70810 RVA: 0x004FCB04 File Offset: 0x004FAF04
		private void TrySetDefaultEquipment()
		{
			int selectItem = -1;
			if (this.mLinkData != null && this.mLinkData != null && this.mLinkData.itemData != null)
			{
				int selectItem2 = 0;
				for (int i = 0; i < this.mAllEquipItem.Count; i++)
				{
					ItemData itemData = this.mAllEquipItem[i];
					if (itemData.GUID == this.mLinkData.itemData.GUID)
					{
						selectItem2 = i;
						break;
					}
				}
				this.SetSelectItem(selectItem2);
				this.mLinkData = null;
				return;
			}
			if (StrengthenGrowthView.mLastSelectedItemData != null)
			{
				ItemData itemData2 = this.mAllEquipItem.Find((ItemData x) => x.GUID == StrengthenGrowthView.mLastSelectedItemData.GUID);
				if (itemData2 != null)
				{
					StrengthenGrowthView.mLastSelectedItemData = DataManager<ItemDataManager>.GetInstance().GetItem(StrengthenGrowthView.mLastSelectedItemData.GUID);
				}
				else
				{
					StrengthenGrowthView.mLastSelectedItemData = null;
				}
			}
			if (StrengthenGrowthView.mLastSelectedItemData != null)
			{
				for (int j = 0; j < this.mAllEquipItem.Count; j++)
				{
					ItemData itemData3 = this.mAllEquipItem[j];
					if (itemData3.GUID == StrengthenGrowthView.mLastSelectedItemData.GUID)
					{
						selectItem = j;
						break;
					}
				}
			}
			else if (this.mAllEquipItem.Count > 0)
			{
				selectItem = 0;
			}
			if (DataManager<StrengthenDataManager>.GetInstance().IsEquipmentStrengthBroken)
			{
				if (this.mCurrentSelectEquipemtnIndex >= 0 && this.mCurrentSelectEquipemtnIndex < this.mAllEquipItem.Count)
				{
					selectItem = this.mCurrentSelectEquipemtnIndex;
				}
				DataManager<StrengthenDataManager>.GetInstance().IsEquipmentStrengthBroken = false;
			}
			if (DataManager<EquipGrowthDataManager>.GetInstance().IsEquipmentIntensifyBroken)
			{
				if (this.mCurrentSelectEquipemtnIndex >= 0 && this.mCurrentSelectEquipemtnIndex < this.mAllEquipItem.Count)
				{
					selectItem = this.mCurrentSelectEquipemtnIndex;
				}
				DataManager<EquipGrowthDataManager>.GetInstance().IsEquipmentIntensifyBroken = false;
			}
			this.SetSelectItem(selectItem);
		}

		// Token: 0x0601149B RID: 70811 RVA: 0x004FCCFC File Offset: 0x004FB0FC
		private void SetSelectItem(int index)
		{
			if (index >= 0 && index < this.mAllEquipItem.Count)
			{
				if (this.mEquipItemsUIList != null)
				{
					StrengthenGrowthView.mLastSelectedItemData = this.mAllEquipItem[index];
					if (!this.mEquipItemsUIList.IsElementInScrollArea(index))
					{
						this.mEquipItemsUIList.EnsureElementVisable(index);
					}
					this.mEquipItemsUIList.SelectElement(index, true);
				}
			}
			else if (this.mEquipItemsUIList != null)
			{
				this.mEquipItemsUIList.SelectElement(-1, true);
				StrengthenGrowthView.mLastSelectedItemData = null;
			}
			if (StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick != null)
			{
				StrengthenGrowthView.mOnStrengthenGrowthEquipItemClick(StrengthenGrowthView.mLastSelectedItemData, this.CurrentSelectedStrengthGrowthType);
			}
		}

		// Token: 0x0400B2A9 RID: 45737
		[SerializeField]
		private ComUIListScript mEquipItemsUIList;

		// Token: 0x0400B2AA RID: 45738
		[SerializeField]
		private Text mNoEquipTips;

		// Token: 0x0400B2AB RID: 45739
		private StrengthenGrowthType CurrentSelectedStrengthGrowthType;

		// Token: 0x0400B2AC RID: 45740
		public static ItemData mLastSelectedItemData;

		// Token: 0x0400B2AD RID: 45741
		public static OnStrengthenGrowthEquipItemClick mOnStrengthenGrowthEquipItemClick;

		// Token: 0x0400B2AE RID: 45742
		private List<ItemData> mAllEquipItem = new List<ItemData>();

		// Token: 0x0400B2AF RID: 45743
		private SmithShopNewLinkData mLinkData;

		// Token: 0x0400B2B0 RID: 45744
		private int mCurrentSelectEquipemtnIndex;
	}
}
