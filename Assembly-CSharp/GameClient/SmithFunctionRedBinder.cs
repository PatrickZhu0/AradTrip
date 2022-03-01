using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004741 RID: 18241
	internal class SmithFunctionRedBinder : MonoBehaviour
	{
		// Token: 0x17002256 RID: 8790
		// (get) Token: 0x0601A350 RID: 107344 RVA: 0x00823918 File Offset: 0x00821D18
		// (set) Token: 0x0601A351 RID: 107345 RVA: 0x00823920 File Offset: 0x00821D20
		public ItemData SpecialItem
		{
			get
			{
				return this.specialItem;
			}
			set
			{
				this.specialItem = value;
			}
		}

		// Token: 0x0601A352 RID: 107346 RVA: 0x0082392C File Offset: 0x00821D2C
		private void Start()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			this._Update();
		}

		// Token: 0x0601A353 RID: 107347 RVA: 0x008239D7 File Offset: 0x00821DD7
		public void SetCheckFunction(SmithFunctionRedBinder.SmithFunctionType eSmithFunctionType)
		{
			this.m_akFunctionTypes.Clear();
			this.m_akFunctionTypes.Add(eSmithFunctionType);
			this._Update();
		}

		// Token: 0x0601A354 RID: 107348 RVA: 0x008239F6 File Offset: 0x00821DF6
		public void AddCheckFunction(SmithFunctionRedBinder.SmithFunctionType eSmithFunctionType)
		{
			if (!this.m_akFunctionTypes.Contains(eSmithFunctionType))
			{
				this.m_akFunctionTypes.Add(eSmithFunctionType);
			}
			this._Update();
		}

		// Token: 0x0601A355 RID: 107349 RVA: 0x00823A1B File Offset: 0x00821E1B
		public void ClearCheckFunctions()
		{
			this.m_akFunctionTypes.Clear();
			this._Update();
		}

		// Token: 0x0601A356 RID: 107350 RVA: 0x00823A30 File Offset: 0x00821E30
		private bool _CheckStrength()
		{
			if (this.SpecialItem != null)
			{
				return this._CheckItemDataNeedStrengthHint(this.SpecialItem) && this._CheckItemDataCanStrength(this.SpecialItem);
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (this._CheckItemDataNeedStrengthHint(item) && this._CheckItemDataCanStrength(item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A357 RID: 107351 RVA: 0x00823ABC File Offset: 0x00821EBC
		private bool _CheckStrengthSpecial()
		{
			int num = 9527;
			if (this.SpecialItem == null)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null && item.Type != ItemTable.eType.FUCKTITTLE)
					{
						num = IntMath.Min(num, item.StrengthenLevel);
					}
				}
			}
			else if (this.SpecialItem != null && this.SpecialItem.Type != ItemTable.eType.FUCKTITTLE)
			{
				num = IntMath.Min(num, this.SpecialItem.StrengthenLevel);
			}
			List<ulong> itemsByPackageSubType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Material, ItemTable.eSubType.Coupon);
			if (itemsByPackageSubType != null)
			{
				for (int j = 0; j < itemsByPackageSubType.Count; j++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageSubType[j]);
					if (item2 != null)
					{
						StrengthenTicketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(item2.TableID, string.Empty, string.Empty);
						if (tableItem != null && tableItem.Level > num)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0601A358 RID: 107352 RVA: 0x00823BE8 File Offset: 0x00821FE8
		private bool _CheckItemDataCanStrength(ItemData itemData)
		{
			if (itemData != null && itemData.Type != ItemTable.eType.FUCKTITTLE)
			{
				StrengthenCost strengthenCost = default(StrengthenCost);
				if (DataManager<StrengthenDataManager>.GetInstance().GetCost(itemData.StrengthenLevel, itemData.LevelLimit, itemData.Quality, ref strengthenCost))
				{
					int a_tableID = 300000106;
					int a_tableID2 = 300000105;
					int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
					if (itemData.SubType == 1)
					{
						float num = 1f;
						SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(21, string.Empty, string.Empty);
						if (tableItem != null)
						{
							num = (float)tableItem.Value / 10f;
						}
						strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num);
						strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num);
						strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num);
					}
					else if (itemData.SubType >= 2 && itemData.SubType <= 6)
					{
						float num2 = 1f;
						SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(22, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							num2 = (float)tableItem2.Value / 10f;
						}
						strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num2);
						strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num2);
						strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num2);
					}
					else if (itemData.SubType >= 7 && itemData.SubType <= 9)
					{
						float num3 = 1f;
						SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(23, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							num3 = (float)tableItem3.Value / 10f;
						}
						strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num3);
						strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num3);
						strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num3);
					}
					if (strengthenCost.UnColorCost > 0)
					{
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(a_tableID, true);
						if (ownedItemCount < strengthenCost.UnColorCost)
						{
							return false;
						}
					}
					if (strengthenCost.ColorCost > 0)
					{
						int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(a_tableID2, true);
						if (ownedItemCount2 < strengthenCost.ColorCost)
						{
							return false;
						}
					}
					if (strengthenCost.GoldCost > 0)
					{
						int ownedItemCount3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, true);
						if (ownedItemCount3 < strengthenCost.GoldCost)
						{
							return false;
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A359 RID: 107353 RVA: 0x00823E87 File Offset: 0x00822287
		private bool _CheckItemDataNeedStrengthHint(ItemData itemData)
		{
			return itemData != null && itemData.StrengthenLevel < 10;
		}

		// Token: 0x0601A35A RID: 107354 RVA: 0x00823EA0 File Offset: 0x008222A0
		private bool _CheckAddMagic()
		{
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.EXPENDABLE);
			if (itemsByType.Count <= 0)
			{
				return false;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			if (itemsByPackageType.Count <= 0)
			{
				return false;
			}
			List<ItemData> list = new List<ItemData>();
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData itemData = this._TryAddMagicCard(itemsByType[i]);
				if (itemData != null)
				{
					list.Add(itemData);
				}
			}
			if (this.specialItem == null)
			{
				for (int j = 0; j < itemsByPackageType.Count; j++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
					if (item != null && item.Type != ItemTable.eType.FUCKTITTLE)
					{
						if (item.mPrecEnchantmentCard != null)
						{
							if (item.mPrecEnchantmentCard.iEnchantmentCardID == 0)
							{
								for (int k = 0; k < list.Count; k++)
								{
									if (list[k] != null)
									{
										MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(list[k].TableID, string.Empty, string.Empty);
										if (tableItem != null && tableItem.Parts.Contains((int)item.EquipWearSlotType))
										{
											return true;
										}
									}
								}
							}
						}
					}
				}
			}
			else if (this.specialItem != null && this.specialItem.Type != ItemTable.eType.FUCKTITTLE && this.specialItem.mPrecEnchantmentCard != null && this.specialItem.mPrecEnchantmentCard.iEnchantmentCardID == 0)
			{
				for (int l = 0; l < list.Count; l++)
				{
					if (list[l] != null)
					{
						MagicCardTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(list[l].TableID, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.Parts.Contains((int)this.specialItem.EquipWearSlotType))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0601A35B RID: 107355 RVA: 0x008240BC File Offset: 0x008224BC
		private bool _CheckAdjustQuality()
		{
			int a_tableID = int.Parse(TR.Value("ItemKeyZBPJTZX"));
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(a_tableID, true);
			if (ownedItemCount < 1)
			{
				return false;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			if (itemsByPackageType.Count <= 0)
			{
				return false;
			}
			if (this.SpecialItem == null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null && item.Type != ItemTable.eType.FUCKTITTLE && item.SubQuality <= 60)
					{
						return true;
					}
				}
			}
			else if (this.SpecialItem != null && this.SpecialItem.Type != ItemTable.eType.FUCKTITTLE && this.SpecialItem.SubQuality <= 60)
			{
				return true;
			}
			return false;
		}

		// Token: 0x0601A35C RID: 107356 RVA: 0x00824198 File Offset: 0x00822598
		private ItemData _TryAddMagicCard(ulong guid)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item != null && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25)
			{
				return item;
			}
			return null;
		}

		// Token: 0x0601A35D RID: 107357 RVA: 0x008241D4 File Offset: 0x008225D4
		private bool _CheckOk(SmithFunctionRedBinder.SmithFunctionType eSmithFunctionType)
		{
			if (eSmithFunctionType == SmithFunctionRedBinder.SmithFunctionType.SFT_STRENGTH)
			{
				return this._CheckStrengthSpecial() || this._CheckStrength();
			}
			if (eSmithFunctionType == SmithFunctionRedBinder.SmithFunctionType.SFT_ADDMAGIC)
			{
				return this._CheckAddMagic();
			}
			if (eSmithFunctionType == SmithFunctionRedBinder.SmithFunctionType.SFT_ADJUST)
			{
				return this._CheckAdjustQuality();
			}
			return eSmithFunctionType == SmithFunctionRedBinder.SmithFunctionType.SFT_STRENGTH_SPECIAL && this._CheckStrengthSpecial();
		}

		// Token: 0x0601A35E RID: 107358 RVA: 0x00824228 File Offset: 0x00822628
		private void _Update()
		{
			if (this.m_goTarget == null)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			while (!flag && num < this.m_akFunctionTypes.Count)
			{
				flag = this._CheckOk(this.m_akFunctionTypes[num]);
				num++;
			}
			flag = false;
			this.m_goTarget.CustomActive(flag);
		}

		// Token: 0x0601A35F RID: 107359 RVA: 0x0082428C File Offset: 0x0082268C
		private void _OnAddNewItem(List<Item> items)
		{
			this._Update();
		}

		// Token: 0x0601A360 RID: 107360 RVA: 0x00824294 File Offset: 0x00822694
		private void _OnRemoveItem(ItemData data)
		{
			this._Update();
		}

		// Token: 0x0601A361 RID: 107361 RVA: 0x0082429C File Offset: 0x0082269C
		private void _OnUpdateItem(List<Item> items)
		{
			this._Update();
		}

		// Token: 0x0601A362 RID: 107362 RVA: 0x008242A4 File Offset: 0x008226A4
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._Update();
		}

		// Token: 0x0601A363 RID: 107363 RVA: 0x008242AC File Offset: 0x008226AC
		private void OnEnable()
		{
			this._Update();
		}

		// Token: 0x0601A364 RID: 107364 RVA: 0x008242B4 File Offset: 0x008226B4
		private void OnDestroy()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
		}

		// Token: 0x0401267B RID: 75387
		public List<SmithFunctionRedBinder.SmithFunctionType> m_akFunctionTypes = new List<SmithFunctionRedBinder.SmithFunctionType>();

		// Token: 0x0401267C RID: 75388
		public GameObject m_goTarget;

		// Token: 0x0401267D RID: 75389
		private ItemData specialItem;

		// Token: 0x02004742 RID: 18242
		public enum SmithFunctionType
		{
			// Token: 0x0401267F RID: 75391
			SFT_STRENGTH,
			// Token: 0x04012680 RID: 75392
			SFT_ADDMAGIC,
			// Token: 0x04012681 RID: 75393
			SFT_PEARLINLAY,
			// Token: 0x04012682 RID: 75394
			SFT_ADJUST,
			// Token: 0x04012683 RID: 75395
			SFT_STRENGTH_SPECIAL
		}
	}
}
