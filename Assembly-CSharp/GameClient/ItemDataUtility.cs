using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001287 RID: 4743
	public static class ItemDataUtility
	{
		// Token: 0x0600B658 RID: 46680 RVA: 0x0029220F File Offset: 0x0029060F
		public static bool IsItemTradeLimitBuyNumber(ItemData itemData)
		{
			return itemData != null && itemData.TableData != null && itemData.TableData.TransactionsNum > 0;
		}

		// Token: 0x0600B659 RID: 46681 RVA: 0x0029223C File Offset: 0x0029063C
		public static int GetItemTradeLeftTime(ItemData itemData)
		{
			if (itemData == null)
			{
				return 0;
			}
			if (itemData.TableData == null)
			{
				return 0;
			}
			int num = itemData.TableData.TransactionsNum - itemData.ItemTradeNumber;
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x0600B65A RID: 46682 RVA: 0x0029227C File Offset: 0x0029067C
		public static List<BetterEquipmentData> GetPlayerAttributeDisplayChangeList(DisplayAttribute beforePlayerAttribute, DisplayAttribute afterPlayerAttribute)
		{
			if (afterPlayerAttribute == null || beforePlayerAttribute == null)
			{
				return null;
			}
			List<BetterEquipmentData> list = new List<BetterEquipmentData>();
			BetterEquipmentData item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.maxHp, afterPlayerAttribute.maxHp, TR.Value("player_attribute_format_maxHp"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.maxMp, afterPlayerAttribute.maxMp, TR.Value("player_attribute_format_maxMp"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.hpRecover, afterPlayerAttribute.hpRecover, TR.Value("player_attribute_format_hpRecover"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.mpRecover, afterPlayerAttribute.mpRecover, TR.Value("player_attribute_format_mpRecover"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseSta, afterPlayerAttribute.baseSta, TR.Value("player_attribute_format_baseSta"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseInt, afterPlayerAttribute.baseInt, TR.Value("player_attribute_format_baseInt"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseIndependence, afterPlayerAttribute.baseIndependence, TR.Value("player_attribute_format_baseIndependence"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseSpr, afterPlayerAttribute.baseSpr, TR.Value("player_attribute_format_baseSpr"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.attack, afterPlayerAttribute.attack, TR.Value("player_attribute_format_attack"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.magicAttack, afterPlayerAttribute.magicAttack, TR.Value("player_attribute_format_magicAttack"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.defence, afterPlayerAttribute.defence, TR.Value("player_attribute_format_defence"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.magicDefence, afterPlayerAttribute.magicDefence, TR.Value("player_attribute_format_magicDefence"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.attackSpeed, afterPlayerAttribute.attackSpeed, TR.Value("player_attribute_format_attackSpeed"), true);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.spellSpeed, afterPlayerAttribute.spellSpeed, TR.Value("player_attribute_format_spellSpeed"), true);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.moveSpeed, afterPlayerAttribute.moveSpeed, TR.Value("player_attribute_format_moveSpeed"), true);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.ciriticalAttack, afterPlayerAttribute.ciriticalAttack, TR.Value("player_attribute_format_ciriticalAttack"), true);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.ciriticalMagicAttack, afterPlayerAttribute.ciriticalMagicAttack, TR.Value("player_attribute_format_ciriticalMagicAttack"), true);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.dex, afterPlayerAttribute.dex, TR.Value("player_attribute_format_dex"), true);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.dodge, afterPlayerAttribute.dodge, TR.Value("player_attribute_format_dodge"), true);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.frozen, afterPlayerAttribute.frozen, TR.Value("player_attribute_format_frozen"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.hard, afterPlayerAttribute.hard, TR.Value("player_attribute_format_hard"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.resistMagic, afterPlayerAttribute.resistMagic, TR.Value("player_attribute_format_resistMagic"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.lightAttack, afterPlayerAttribute.lightAttack, TR.Value("player_attribute_format_lightAttack"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.fireAttack, afterPlayerAttribute.fireAttack, TR.Value("player_attribute_format_fireAttack"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.iceAttack, afterPlayerAttribute.iceAttack, TR.Value("player_attribute_format_iceAttack"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.darkAttack, afterPlayerAttribute.darkAttack, TR.Value("player_attribute_format_darkAttack"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.lightDefence, afterPlayerAttribute.lightDefence, TR.Value("player_attribute_format_lightDefence"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.fireDefence, afterPlayerAttribute.fireDefence, TR.Value("player_attribute_format_fireDefence"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.iceDefence, afterPlayerAttribute.iceDefence, TR.Value("player_attribute_format_iceDefence"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.darkDefence, afterPlayerAttribute.darkDefence, TR.Value("player_attribute_format_darkDefence"), false);
			if (item.DataState != EquipmentDataState.PROPERTY_NO_CHANGE)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600B65B RID: 46683 RVA: 0x00292840 File Offset: 0x00290C40
		public static List<BetterEquipmentData> GetPlayerAttributeDisplayChangeUpList(DisplayAttribute beforePlayerAttribute, DisplayAttribute afterPlayerAttribute)
		{
			if (afterPlayerAttribute == null || beforePlayerAttribute == null)
			{
				return null;
			}
			List<BetterEquipmentData> list = new List<BetterEquipmentData>();
			BetterEquipmentData item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.maxHp, afterPlayerAttribute.maxHp, TR.Value("player_attribute_format_maxHp"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.maxMp, afterPlayerAttribute.maxMp, TR.Value("player_attribute_format_maxMp"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.hpRecover, afterPlayerAttribute.hpRecover, TR.Value("player_attribute_format_hpRecover"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.mpRecover, afterPlayerAttribute.mpRecover, TR.Value("player_attribute_format_mpRecover"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseSta, afterPlayerAttribute.baseSta, TR.Value("player_attribute_format_baseSta"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseInt, afterPlayerAttribute.baseInt, TR.Value("player_attribute_format_baseInt"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseIndependence, afterPlayerAttribute.baseIndependence, TR.Value("player_attribute_format_baseIndependence"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.baseSpr, afterPlayerAttribute.baseSpr, TR.Value("player_attribute_format_baseSpr"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.attack, afterPlayerAttribute.attack, TR.Value("player_attribute_format_attack"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.magicAttack, afterPlayerAttribute.magicAttack, TR.Value("player_attribute_format_magicAttack"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.defence, afterPlayerAttribute.defence, TR.Value("player_attribute_format_defence"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.magicDefence, afterPlayerAttribute.magicDefence, TR.Value("player_attribute_format_magicDefence"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.attackSpeed, afterPlayerAttribute.attackSpeed, TR.Value("player_attribute_format_attackSpeed"), true);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.spellSpeed, afterPlayerAttribute.spellSpeed, TR.Value("player_attribute_format_spellSpeed"), true);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.moveSpeed, afterPlayerAttribute.moveSpeed, TR.Value("player_attribute_format_moveSpeed"), true);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.ciriticalAttack, afterPlayerAttribute.ciriticalAttack, TR.Value("player_attribute_format_ciriticalAttack"), true);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.ciriticalMagicAttack, afterPlayerAttribute.ciriticalMagicAttack, TR.Value("player_attribute_format_ciriticalMagicAttack"), true);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.dex, afterPlayerAttribute.dex, TR.Value("player_attribute_format_dex"), true);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.dodge, afterPlayerAttribute.dodge, TR.Value("player_attribute_format_dodge"), true);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.frozen, afterPlayerAttribute.frozen, TR.Value("player_attribute_format_frozen"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.hard, afterPlayerAttribute.hard, TR.Value("player_attribute_format_hard"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.resistMagic, afterPlayerAttribute.resistMagic, TR.Value("player_attribute_format_resistMagic"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.lightAttack, afterPlayerAttribute.lightAttack, TR.Value("player_attribute_format_lightAttack"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.fireAttack, afterPlayerAttribute.fireAttack, TR.Value("player_attribute_format_fireAttack"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.iceAttack, afterPlayerAttribute.iceAttack, TR.Value("player_attribute_format_iceAttack"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.darkAttack, afterPlayerAttribute.darkAttack, TR.Value("player_attribute_format_darkAttack"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.lightDefence, afterPlayerAttribute.lightDefence, TR.Value("player_attribute_format_lightDefence"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.fireDefence, afterPlayerAttribute.fireDefence, TR.Value("player_attribute_format_fireDefence"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.iceDefence, afterPlayerAttribute.iceDefence, TR.Value("player_attribute_format_iceDefence"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			item = ItemDataUtility.CreateBetterData(beforePlayerAttribute.darkDefence, afterPlayerAttribute.darkDefence, TR.Value("player_attribute_format_darkDefence"), false);
			if (item.DataState == EquipmentDataState.PROPERTY_UP)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600B65C RID: 46684 RVA: 0x00292E20 File Offset: 0x00291220
		private static BetterEquipmentData CreateBetterData(float beforeData, float afterData, string name, bool isPercentNumber = false)
		{
			BetterEquipmentData result = default(BetterEquipmentData);
			result.DataState = EquipmentDataState.PROPERTY_NO_CHANGE;
			if ((double)Math.Abs(afterData - beforeData) > 0.1)
			{
				result.name = name;
				if (afterData > beforeData)
				{
					result.DataState = EquipmentDataState.PROPERTY_UP;
				}
				else
				{
					result.DataState = EquipmentDataState.PROPERTY_DOWN;
				}
				if (isPercentNumber)
				{
					result.PreData = string.Format("{0:F1}%", beforeData);
					result.CurData = string.Format("{0:F1}%", afterData);
				}
				else
				{
					result.PreData = string.Format("{0:F1}", beforeData);
					result.CurData = string.Format("{0:F1}", afterData);
				}
			}
			return result;
		}

		// Token: 0x0600B65D RID: 46685 RVA: 0x00292EE0 File Offset: 0x002912E0
		public static void ArrangeItemGuidList(List<ulong> itemGuidList)
		{
			if (itemGuidList == null || itemGuidList.Count <= 0)
			{
				return;
			}
			itemGuidList.Sort(delegate(ulong x, ulong y)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(x);
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(y);
				if (item == null || item2 == null)
				{
					return 0;
				}
				if (item.isInSidePack && !item2.isInSidePack)
				{
					return -1;
				}
				if (!item.isInSidePack && item2.isInSidePack)
				{
					return 1;
				}
				int num = item2.Quality.CompareTo(item.Quality);
				if (num == 0)
				{
					num = item2.TableID.CompareTo(item.TableID);
					if (num == 0)
					{
						num = item2.Count.CompareTo(item.Count);
						if (num == 0)
						{
							num = item.StrengthenLevel.CompareTo(item2.StrengthenLevel);
						}
					}
				}
				return num;
			});
		}

		// Token: 0x0600B65E RID: 46686 RVA: 0x00292F18 File Offset: 0x00291318
		public static bool IsItemTipShowModelAvatar(ItemData itemData)
		{
			return itemData != null && ItemDataUtility.IsNeedShowModelAvatarByItemTypeAndSubType(itemData.TableData) && ItemDataUtility.IsNeedShowModelAvatarByItemGuid(itemData);
		}

		// Token: 0x0600B65F RID: 46687 RVA: 0x00292F54 File Offset: 0x00291354
		public static bool IsNeedShowModelAvatarByItemTypeAndSubType(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return false;
			}
			ItemTable.eType type = itemTable.Type;
			if (type == ItemTable.eType.HEAD_FRAME)
			{
				return false;
			}
			if (type == ItemTable.eType.VirtualPack)
			{
				return ItemDataUtility.IsNeedShowModelAvatarByGiftData(itemTable.PackageID);
			}
			ItemTable.eSubType subType = itemTable.SubType;
			switch (subType)
			{
			case ItemTable.eSubType.TITLE:
				return true;
			case ItemTable.eSubType.FASHION_HAIR:
			case ItemTable.eSubType.FASHION_HEAD:
			case ItemTable.eSubType.FASHION_SASH:
			case ItemTable.eSubType.FASHION_CHEST:
			case ItemTable.eSubType.FASHION_LEG:
			case ItemTable.eSubType.FASHION_EPAULET:
				break;
			default:
				if (subType != ItemTable.eSubType.WEAPON)
				{
					if (subType == ItemTable.eSubType.GiftPackage)
					{
						return ItemDataUtility.IsNeedShowModelAvatarByGiftData(itemTable.PackageID);
					}
					if (subType == ItemTable.eSubType.PetEgg)
					{
						return true;
					}
					if (subType != ItemTable.eSubType.FASHION_WEAPON && subType != ItemTable.eSubType.FASHION_AURAS)
					{
						return false;
					}
				}
				break;
			}
			return ItemDataUtility.IsItemTableOwnerResModel(itemTable);
		}

		// Token: 0x0600B660 RID: 46688 RVA: 0x00293008 File Offset: 0x00291408
		private static bool IsNeedShowModelAvatarByGiftData(int giftPackId)
		{
			GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(giftPackId, string.Empty, string.Empty);
			return tableItem != null && tableItem.ShowAvatarModelType != GiftPackTable.eShowAvatarModelType.None;
		}

		// Token: 0x0600B661 RID: 46689 RVA: 0x00293044 File Offset: 0x00291444
		public static bool IsNeedShowModelAvatarByItemGuid(ItemData itemData)
		{
			if (itemData == null)
			{
				return false;
			}
			if (itemData.GUID <= 0UL)
			{
				return true;
			}
			if (itemData.TableData != null)
			{
				if (itemData.TableData.Type == ItemTable.eType.VirtualPack)
				{
					return true;
				}
				if (itemData.TableData.SubType == ItemTable.eSubType.PetEgg || itemData.TableData.SubType == ItemTable.eSubType.GiftPackage)
				{
					return true;
				}
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemData.GUID);
			return item == null;
		}

		// Token: 0x0600B662 RID: 46690 RVA: 0x002930C8 File Offset: 0x002914C8
		public static bool IsSuitPlayerProfession(ItemTable itemTable, out int otherProfessionId)
		{
			otherProfessionId = 0;
			if (itemTable == null)
			{
				return false;
			}
			List<int> list = itemTable.Occu.ToList<int>();
			if (list == null || list.Count <= 0)
			{
				return true;
			}
			bool flag = false;
			int num = 0;
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.JobType == 1)
			{
				flag = true;
				num = tableItem.prejob;
			}
			for (int i = 0; i < list.Count; i++)
			{
				int num2 = list[i];
				if (num2 == 0)
				{
					return true;
				}
				if (flag)
				{
					if (num2 == jobTableID || num2 == num)
					{
						return true;
					}
				}
				else if (num2 == jobTableID)
				{
					return true;
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				int num3 = list[j];
				if (num3 > 0)
				{
					otherProfessionId = num3;
					JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num3, string.Empty, string.Empty);
					if (tableItem2.JobType == 1)
					{
						otherProfessionId = tableItem2.prejob;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x0600B663 RID: 46691 RVA: 0x00293204 File Offset: 0x00291604
		private static List<ItemTable> GetFinalGiftPackShowGiftPackList(GiftPackTable giftPackTable)
		{
			if (giftPackTable == null || giftPackTable.Items == null || giftPackTable.Items.Count <= 0)
			{
				return null;
			}
			List<int> list = giftPackTable.Items.ToList<int>();
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			List<ItemTable> list2 = new List<ItemTable>();
			for (int i = 0; i < list.Count; i++)
			{
				int id = list[i];
				GiftTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (ItemDataUtility.IsGiftTableSuitProfession(tableItem))
					{
						int itemID = tableItem.ItemID;
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							if (tableItem2.SubType == ItemTable.eSubType.GiftPackage || tableItem2.Type == ItemTable.eType.VirtualPack)
							{
								GiftPackTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(tableItem2.PackageID, string.Empty, string.Empty);
								if (tableItem3 != null)
								{
									GiftPackTable.eShowAvatarModelType showAvatarModelType = tableItem3.ShowAvatarModelType;
									if (showAvatarModelType == GiftPackTable.eShowAvatarModelType.Combination || showAvatarModelType == GiftPackTable.eShowAvatarModelType.Complete || showAvatarModelType == GiftPackTable.eShowAvatarModelType.Single)
									{
										list2.Add(tableItem2);
									}
								}
							}
						}
					}
				}
			}
			return list2;
		}

		// Token: 0x0600B664 RID: 46692 RVA: 0x00293354 File Offset: 0x00291754
		public static GiftPackModelAvatarDataModel GetGiftPackModelAvatarDataModel(int giftPackId)
		{
			GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(giftPackId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			GiftPackTable.eShowAvatarModelType eShowAvatarModelType = tableItem.ShowAvatarModelType;
			if (eShowAvatarModelType == GiftPackTable.eShowAvatarModelType.None)
			{
				return null;
			}
			if (eShowAvatarModelType == GiftPackTable.eShowAvatarModelType.CompleteEnumeration)
			{
				List<ItemTable> finalGiftPackShowGiftPackList = ItemDataUtility.GetFinalGiftPackShowGiftPackList(tableItem);
				if (finalGiftPackShowGiftPackList == null || finalGiftPackShowGiftPackList.Count <= 0)
				{
					return null;
				}
				return new GiftPackModelAvatarDataModel
				{
					GiftPackShowModelAvatarType = eShowAvatarModelType,
					GiftPackShowItemTableList = finalGiftPackShowGiftPackList
				};
			}
			else
			{
				bool isOwnerCompleteShowType = false;
				List<ItemTable> finalGiftPackShowItemTableList = ItemDataUtility.GetFinalGiftPackShowItemTableList(giftPackId, eShowAvatarModelType, out isOwnerCompleteShowType);
				if (finalGiftPackShowItemTableList == null || finalGiftPackShowItemTableList.Count <= 0)
				{
					return null;
				}
				int count = finalGiftPackShowItemTableList.Count;
				if (count == 1)
				{
					eShowAvatarModelType = GiftPackTable.eShowAvatarModelType.Single;
				}
				else if (eShowAvatarModelType == GiftPackTable.eShowAvatarModelType.Matching)
				{
					ItemTable itemTable = finalGiftPackShowItemTableList[count - 1];
					if (itemTable == null || itemTable.SubType != ItemTable.eSubType.PetEgg)
					{
						eShowAvatarModelType = GiftPackTable.eShowAvatarModelType.Combination;
					}
				}
				return new GiftPackModelAvatarDataModel
				{
					GiftPackShowModelAvatarType = eShowAvatarModelType,
					GiftPackShowItemTableList = finalGiftPackShowItemTableList,
					IsOwnerCompleteShowType = isOwnerCompleteShowType
				};
			}
		}

		// Token: 0x0600B665 RID: 46693 RVA: 0x0029345C File Offset: 0x0029185C
		public static List<ItemTable> GetFinalGiftPackShowItemTableList(int giftPackId, GiftPackTable.eShowAvatarModelType showAvatarModelType, out bool isOwnerCompleteShowType)
		{
			isOwnerCompleteShowType = false;
			if (giftPackId <= 0)
			{
				return null;
			}
			bool flag = false;
			List<ItemTable> originalGiftPackShowItemTableList = ItemDataUtility.GetOriginalGiftPackShowItemTableList(giftPackId, true, out flag);
			if (flag)
			{
				isOwnerCompleteShowType = true;
			}
			return ItemDataUtility.GetFilterGiftPackShowItemTableList(originalGiftPackShowItemTableList, showAvatarModelType);
		}

		// Token: 0x0600B666 RID: 46694 RVA: 0x00293494 File Offset: 0x00291894
		private static List<ItemTable> GetOriginalGiftPackShowItemTableList(int giftPackId, bool isFindNextLayer, out bool isOwnerCompleteShowType)
		{
			isOwnerCompleteShowType = false;
			GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(giftPackId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			if (tableItem.Items == null)
			{
				return null;
			}
			List<int> list = tableItem.Items.ToList<int>();
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			if (tableItem.ShowAvatarModelType == GiftPackTable.eShowAvatarModelType.Complete)
			{
				isOwnerCompleteShowType = true;
			}
			List<ItemTable> list2 = new List<ItemTable>();
			for (int i = 0; i < list.Count; i++)
			{
				int id = list[i];
				GiftTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(id, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					List<int> list3 = tableItem2.RecommendJobs.ToList<int>();
					if (list3 == null || list3.Count <= 0 || list3.Contains(0) || list3.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						int itemID = tableItem2.ItemID;
						ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							if (tableItem3.Type != ItemTable.eType.HEAD_FRAME)
							{
								if (tableItem3.SubType == ItemTable.eSubType.GiftPackage || tableItem3.Type == ItemTable.eType.VirtualPack)
								{
									if (isFindNextLayer)
									{
										bool flag = false;
										List<ItemTable> originalGiftPackShowItemTableList = ItemDataUtility.GetOriginalGiftPackShowItemTableList(tableItem3.PackageID, false, out flag);
										if (originalGiftPackShowItemTableList != null && originalGiftPackShowItemTableList.Count > 0)
										{
											list2.AddRange(originalGiftPackShowItemTableList.ToList<ItemTable>());
											if (flag)
											{
												isOwnerCompleteShowType = true;
											}
										}
									}
								}
								else if (ItemDataUtility.IsSuitItemSubTypeInGiftPack(tableItem3))
								{
									int num = 0;
									if (ItemDataUtility.IsSuitPlayerProfession(tableItem3, out num))
									{
										list2.Add(tableItem3);
									}
								}
							}
						}
					}
				}
			}
			return list2;
		}

		// Token: 0x0600B667 RID: 46695 RVA: 0x00293678 File Offset: 0x00291A78
		private static List<ItemTable> GetFilterGiftPackShowItemTableList(List<ItemTable> itemTableList, GiftPackTable.eShowAvatarModelType showAvatarModelType)
		{
			if (itemTableList == null || itemTableList.Count <= 0)
			{
				return null;
			}
			List<ItemTable> list = new List<ItemTable>();
			Dictionary<int, ItemTable> dictionary = new Dictionary<int, ItemTable>();
			Dictionary<int, ItemTable> dictionary2 = new Dictionary<int, ItemTable>();
			Dictionary<int, ItemTable> dictionary3 = new Dictionary<int, ItemTable>();
			ItemTable itemTable = null;
			ItemTable itemTable2 = null;
			for (int i = 0; i < itemTableList.Count; i++)
			{
				ItemTable itemTable3 = itemTableList[i];
				if (itemTable3 != null)
				{
					if (itemTable3.SubType == ItemTable.eSubType.PetEgg)
					{
						if (!dictionary.ContainsKey(itemTable3.ID))
						{
							dictionary[itemTable3.ID] = itemTable3;
							list.Add(itemTable3);
							if (itemTable2 == null)
							{
								itemTable2 = itemTable3;
							}
						}
					}
					else if (itemTable3.SubType == ItemTable.eSubType.TITLE)
					{
						if (!dictionary2.ContainsKey(itemTable3.ID))
						{
							dictionary2[itemTable3.ID] = itemTable3;
							list.Add(itemTable3);
							if (itemTable == null)
							{
								itemTable = itemTable3;
							}
						}
					}
					else if (ItemDataUtility.IsItemTableOwnerResModel(itemTable3))
					{
						if (!dictionary3.ContainsKey(itemTable3.ResID))
						{
							dictionary3[itemTable3.ResID] = itemTable3;
							list.Add(itemTable3);
						}
					}
				}
			}
			if (showAvatarModelType == GiftPackTable.eShowAvatarModelType.Enumeration)
			{
				return list;
			}
			list.Clear();
			Dictionary<int, ItemTable> dictionary4 = new Dictionary<int, ItemTable>();
			foreach (KeyValuePair<int, ItemTable> keyValuePair in dictionary3)
			{
				ItemTable value = keyValuePair.Value;
				if (value != null)
				{
					if (!dictionary4.ContainsKey((int)value.SubType))
					{
						dictionary4[(int)value.SubType] = value;
					}
				}
			}
			foreach (KeyValuePair<int, ItemTable> keyValuePair2 in dictionary4)
			{
				ItemTable value2 = keyValuePair2.Value;
				if (value2 != null)
				{
					list.Add(value2);
				}
			}
			if (itemTable != null)
			{
				list.Add(itemTable);
			}
			if (itemTable2 != null)
			{
				list.Add(itemTable2);
			}
			return list;
		}

		// Token: 0x0600B668 RID: 46696 RVA: 0x00293884 File Offset: 0x00291C84
		public static bool IsSuitItemSubTypeInGiftPack(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return false;
			}
			ItemTable.eSubType subType = itemTable.SubType;
			switch (subType)
			{
			case ItemTable.eSubType.TITLE:
				return true;
			case ItemTable.eSubType.FASHION_HAIR:
				return true;
			case ItemTable.eSubType.FASHION_HEAD:
				return true;
			case ItemTable.eSubType.FASHION_SASH:
				return true;
			case ItemTable.eSubType.FASHION_CHEST:
				return true;
			case ItemTable.eSubType.FASHION_LEG:
				return true;
			case ItemTable.eSubType.FASHION_EPAULET:
				return true;
			default:
				return subType == ItemTable.eSubType.WEAPON || subType == ItemTable.eSubType.PetEgg || subType == ItemTable.eSubType.FASHION_WEAPON || subType == ItemTable.eSubType.FASHION_AURAS;
			}
		}

		// Token: 0x0600B669 RID: 46697 RVA: 0x00293900 File Offset: 0x00291D00
		private static bool IsGiftTableSuitProfession(GiftTable giftTable)
		{
			if (giftTable == null)
			{
				return false;
			}
			List<int> list = giftTable.RecommendJobs.ToList<int>();
			if (list != null && list.Count > 0)
			{
				if (list.Contains(0))
				{
					return true;
				}
				if (list.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B66A RID: 46698 RVA: 0x0029395C File Offset: 0x00291D5C
		public static bool IsItemTableOwnerResModel(ItemTable itemTable)
		{
			return itemTable != null && Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(itemTable.ResID, string.Empty, string.Empty) != null;
		}

		// Token: 0x0600B66B RID: 46699 RVA: 0x00293998 File Offset: 0x00291D98
		public static int GetPetIdByItemTable(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return 0;
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				PetTable petTable = keyValuePair.Value as PetTable;
				if (petTable != null)
				{
					if (petTable.PetEggID == itemTable.ID)
					{
						return petTable.ID;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600B66C RID: 46700 RVA: 0x00293A10 File Offset: 0x00291E10
		public static List<ItemData> GetGiftItemDataList(int giftId, int jobId)
		{
			List<ItemData> list = new List<ItemData>();
			GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(giftId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.Items.Count; i++)
				{
					int id = tableItem.Items[i];
					GiftTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(id, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						if (tableItem2.RecommendJobs.Contains(jobId))
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableItem2.ItemID, 100, 0);
							itemData.EquipType = (EEquipType)tableItem2.EquipType;
							itemData.StrengthenLevel = tableItem2.Strengthen;
							list.Add(itemData);
						}
					}
				}
			}
			return list;
		}
	}
}
