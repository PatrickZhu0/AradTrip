using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200128C RID: 4748
	public class ItemDataManager : DataManager<ItemDataManager>
	{
		// Token: 0x17001AF4 RID: 6900
		// (get) Token: 0x0600B67A RID: 46714 RVA: 0x00293CF9 File Offset: 0x002920F9
		public List<int> AddPropertys
		{
			get
			{
				return this.m_aiAddPropertys;
			}
		}

		// Token: 0x0600B67B RID: 46715 RVA: 0x00293D04 File Offset: 0x00292104
		public static ItemData CreateItemDataFromTable(int tableId, int subQuality = 100, int strengthLevel = 0)
		{
			ItemData itemData = new ItemData(tableId);
			ItemDataManager._InitTableData(itemData);
			if (!itemData.IsTableDataInited)
			{
				return null;
			}
			itemData.SubQuality = subQuality;
			itemData.StrengthenLevel = strengthLevel;
			if (itemData.Type == ItemTable.eType.FASHION)
			{
				EquipProp equipProp = EquipProp.CreateFromTable(itemData.FashionBaseAttributeID);
				if (equipProp != null)
				{
					itemData.BaseProp += equipProp;
				}
				EquipProp equipProp2 = EquipProp.CreateFromTable(itemData.FashionAttributeID);
				if (equipProp2 != null)
				{
					itemData.BaseProp += equipProp2;
				}
			}
			EquipQLValueTable equipQLValueTable = ItemDataManager._GetEquipQLValue(itemData);
			if (equipQLValueTable != null)
			{
				float a_fBaseRatio = (float)equipQLValueTable.AtkDef / 1000f;
				float a_fPerRatio = (float)equipQLValueTable.PerfectAtkDef / 1000f;
				float a_fBaseRatio2 = (float)equipQLValueTable.FourDimensional / 1000f;
				float a_fPerRatio2 = (float)equipQLValueTable.PerfectFourDimensional / 1000f;
				float a_fBaseRatio3 = (float)equipQLValueTable.IndependentResists / 1000f;
				float a_fPerRatio3 = (float)equipQLValueTable.PerfectIndependentResists / 1000f;
				itemData.BaseProp.props[0] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[0] * 1000, a_fBaseRatio, a_fPerRatio, subQuality) / 1000;
				itemData.BaseProp.props[1] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[1] * 1000, a_fBaseRatio, a_fPerRatio, subQuality) / 1000;
				itemData.BaseProp.props[2] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[2] * 1000, a_fBaseRatio, a_fPerRatio, subQuality) / 1000;
				itemData.BaseProp.props[3] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[3] * 1000, a_fBaseRatio, a_fPerRatio, subQuality) / 1000;
				itemData.BaseProp.props[4] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[4], a_fBaseRatio2, a_fPerRatio2, subQuality);
				itemData.BaseProp.props[5] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[5], a_fBaseRatio2, a_fPerRatio2, subQuality);
				itemData.BaseProp.props[6] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[6], a_fBaseRatio2, a_fPerRatio2, subQuality);
				itemData.BaseProp.props[7] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[7], a_fBaseRatio2, a_fPerRatio2, subQuality);
				itemData.BaseProp.props[59] = ItemDataManager._CalculateRealProp(itemData.BaseProp.props[59], a_fBaseRatio3, a_fPerRatio3, subQuality);
				float baseRatio = (float)equipQLValueTable.StrProp / 1000f;
				float perfectRate = (float)equipQLValueTable.PerfectStrProp / 1000f;
				for (int i = 1; i < 5; i++)
				{
					itemData.BaseProp.magicElementsAttack[i] = ItemDataManager._CalculateRealPropDefense((float)itemData.BaseProp.magicElementsAttack[i], baseRatio, perfectRate, subQuality);
				}
				float baseRatio2 = (float)equipQLValueTable.DefProp / 1000f;
				float perfectRate2 = (float)equipQLValueTable.PerfectDefProp / 1000f;
				for (int j = 1; j < 5; j++)
				{
					itemData.BaseProp.magicElementsDefence[j] = ItemDataManager._CalculateRealPropDefense((float)itemData.BaseProp.magicElementsDefence[j], baseRatio2, perfectRate2, subQuality);
				}
				float baseRatio3 = (float)equipQLValueTable.AbnormalResists / 1000f;
				float perfectRate3 = (float)equipQLValueTable.PerfectAbnormalResists / 1000f;
				for (int k = 0; k < 13; k++)
				{
					itemData.BaseProp.abnormalResists[k] = ItemDataManager._CalculateRealPropDefense((float)itemData.BaseProp.abnormalResists[k], baseRatio3, perfectRate3, subQuality);
				}
				itemData.BaseProp.props[19] = ItemDataManager._CalculateRealPropDefense((float)itemData.BaseProp.props[19], baseRatio3, perfectRate3, subQuality);
			}
			int nValue = 0;
			int nValue2 = 0;
			ItemDataManager.CalculateIgnroeAttack(itemData, out nValue, out nValue2);
			itemData.BaseProp.props[39] = nValue;
			itemData.BaseProp.props[40] = nValue2;
			int nValue3 = 0;
			ItemDataManager.CalculateIngoreIndependenceAttack(itemData, out nValue3);
			itemData.BaseProp.props[60] = nValue3;
			itemData.RefreshRateScore();
			return itemData;
		}

		// Token: 0x0600B67C RID: 46716 RVA: 0x00294238 File Offset: 0x00292638
		private static EquipQLValueTable _GetEquipQLValue(ItemData a_itemData)
		{
			EquipQLValueTable.ePart id = EquipQLValueTable.ePart.NONE;
			if (a_itemData.Type == ItemTable.eType.EQUIP)
			{
				if (a_itemData.SubType == 1)
				{
					id = EquipQLValueTable.ePart.WEAPON;
				}
				else if (a_itemData.ThirdType == ItemTable.eThirdType.CLOTH)
				{
					id = EquipQLValueTable.ePart.CLOTH;
				}
				else if (a_itemData.ThirdType == ItemTable.eThirdType.HEAVY)
				{
					id = EquipQLValueTable.ePart.HEAVY;
				}
				else if (a_itemData.ThirdType == ItemTable.eThirdType.SKIN)
				{
					id = EquipQLValueTable.ePart.LEATHER;
				}
				else if (a_itemData.ThirdType == ItemTable.eThirdType.PLATE)
				{
					id = EquipQLValueTable.ePart.PLATE;
				}
				else if (a_itemData.ThirdType == ItemTable.eThirdType.LIGHT)
				{
					id = EquipQLValueTable.ePart.LIGHT;
				}
				else if (a_itemData.SubType == 7 || a_itemData.SubType == 8 || a_itemData.SubType == 9)
				{
					id = EquipQLValueTable.ePart.JEWELRY;
				}
				else if (a_itemData.IsAssistEquip())
				{
					id = EquipQLValueTable.ePart.ASSIST;
				}
			}
			return Singleton<TableManager>.GetInstance().GetTableItem<EquipQLValueTable>((int)id, string.Empty, string.Empty);
		}

		// Token: 0x0600B67D RID: 46717 RVA: 0x00294318 File Offset: 0x00292718
		private static int _CalculateRealPropDefense(float value, float baseRatio, float perfectRate, int quality)
		{
			if (value <= 0f)
			{
				return 0;
			}
			float num = (float)quality / 100f;
			bool flag = true;
			if (quality < 100)
			{
				flag = false;
			}
			int num2 = (int)(value * baseRatio + value * (1f - baseRatio) * num);
			int num3 = (int)((float)((!flag) ? 0 : 1) * value * perfectRate);
			if (flag)
			{
				num3 = ((num3 != 0) ? num3 : 1);
			}
			if (num3 > 0 && value < 0f)
			{
				num3 = -num3;
			}
			return num2 + num3;
		}

		// Token: 0x0600B67E RID: 46718 RVA: 0x00294398 File Offset: 0x00292798
		private static void CalculateIngoreIndependenceAttack(ItemData itemData, out int ignoreIndependAttack)
		{
			ignoreIndependAttack = 0;
			if (itemData == null)
			{
				return;
			}
			if (itemData.SubType != 1)
			{
				return;
			}
			if (itemData.StrengthenLevel <= 0)
			{
				return;
			}
			EquipStrModIndAtkTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipStrModIndAtkTable>(1, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int levelLimit = itemData.LevelLimit;
			int strengthenLevel = itemData.StrengthenLevel;
			int quality = (int)itemData.Quality;
			if (tableItem.WpColorQaMod_1.Count <= 0 || quality <= 0 || quality > tableItem.WpColorQaMod_1.Count)
			{
				return;
			}
			float num = (float)tableItem.WpColorQaMod_1[quality - 1] / 100f;
			if (tableItem.WpColorQbMod_1.Count <= 0 || quality <= 0 || quality > tableItem.WpColorQbMod_1.Count)
			{
				return;
			}
			float num2 = (float)tableItem.WpColorQbMod_1[quality - 1] / 100f;
			if (tableItem.WpStrenthMod_1.Count <= 0 || strengthenLevel <= 0 || strengthenLevel > tableItem.WpStrenthMod_1.Count)
			{
				return;
			}
			float num3 = (float)tableItem.WpStrenthMod_1[strengthenLevel - 1] / 100f;
			if (tableItem.EquipMod.Count <= 0 || strengthenLevel <= 0)
			{
				return;
			}
			double num4 = (double)tableItem.EquipMod[0] * 0.01;
			ignoreIndependAttack = (int)((double)((float)levelLimit + num) * 0.125 * (double)num3 * (double)num2 * num4 * 1.1) * 1000;
			if (ignoreIndependAttack < 1)
			{
				ignoreIndependAttack = 1;
			}
		}

		// Token: 0x0600B67F RID: 46719 RVA: 0x0029452C File Offset: 0x0029292C
		private static void CalculateIgnroeAttack(ItemData itemData, out int ignorePhysicsAttack, out int ignoreMagicAttack)
		{
			ignorePhysicsAttack = 0;
			ignoreMagicAttack = 0;
			if (itemData == null)
			{
				return;
			}
			if (itemData.StrengthenLevel <= 0)
			{
				return;
			}
			EquipStrModTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipStrModTable>(1, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int levelLimit = itemData.LevelLimit;
			int strengthenLevel = itemData.StrengthenLevel;
			int quality = (int)itemData.Quality;
			if (tableItem.WpColorQaMod.Count <= 0 || quality <= 0 || quality > tableItem.WpColorQaMod.Count)
			{
				return;
			}
			float num = (float)tableItem.WpColorQaMod[quality - 1] / 100f;
			if (tableItem.WpColorQbMod.Count <= 0 || quality <= 0 || quality > tableItem.WpColorQbMod.Count)
			{
				return;
			}
			float num2 = (float)tableItem.WpColorQbMod[quality - 1] / 100f;
			if (tableItem.WpStrenthMod.Count <= 0 || strengthenLevel <= 0 || strengthenLevel > tableItem.WpStrenthMod.Count)
			{
				return;
			}
			float num3 = (float)tableItem.WpStrenthMod[strengthenLevel - 1] / 100f;
			IList<int> list = null;
			switch (itemData.ThirdType)
			{
			case ItemTable.eThirdType.HUGESWORD:
				list = tableItem.HugeSword;
				break;
			case ItemTable.eThirdType.KATANA:
				list = tableItem.Katana;
				break;
			case ItemTable.eThirdType.SHORTSWORD:
				list = tableItem.ShortSword;
				break;
			case ItemTable.eThirdType.BEAMSWORD:
				list = tableItem.BeamSword;
				break;
			case ItemTable.eThirdType.BLUNT:
				list = tableItem.Blunt;
				break;
			case ItemTable.eThirdType.REVOLVER:
				list = tableItem.Revolver;
				break;
			case ItemTable.eThirdType.CROSSBOW:
				list = tableItem.CrossBow;
				break;
			case ItemTable.eThirdType.HANDCANNON:
				list = tableItem.HandCannon;
				break;
			case ItemTable.eThirdType.RIFLE:
				list = tableItem.AutoRifle;
				break;
			case ItemTable.eThirdType.PISTOL:
				list = tableItem.AutoPistal;
				break;
			case ItemTable.eThirdType.STAFF:
				list = tableItem.MagicStick;
				break;
			case ItemTable.eThirdType.WAND:
				list = tableItem.Twig;
				break;
			case ItemTable.eThirdType.SPEAR:
				list = tableItem.Pike;
				break;
			case ItemTable.eThirdType.STICK:
				list = tableItem.Stick;
				break;
			case ItemTable.eThirdType.BESOM:
				list = tableItem.Besom;
				break;
			case ItemTable.eThirdType.GLOVE:
				list = tableItem.Glove;
				break;
			case ItemTable.eThirdType.BIKAI:
				list = tableItem.Bikai;
				break;
			case ItemTable.eThirdType.CLAW:
				list = tableItem.Claw;
				break;
			case ItemTable.eThirdType.OFG:
				list = tableItem.Ofg;
				break;
			case ItemTable.eThirdType.EAST_STICK:
				list = tableItem.East_stick;
				break;
			case ItemTable.eThirdType.SICKLE:
				list = tableItem.SICKLE;
				break;
			case ItemTable.eThirdType.TOTEM:
				list = tableItem.TOTEM;
				break;
			case ItemTable.eThirdType.AXE:
				list = tableItem.AXE;
				break;
			case ItemTable.eThirdType.BEADS:
				list = tableItem.BEADS;
				break;
			case ItemTable.eThirdType.CROSS:
				list = tableItem.CROSS;
				break;
			}
			if (list == null || list.Count < 2)
			{
				return;
			}
			float num4 = ((float)levelLimit + num) * 0.125f * num3 * num2 * ((float)list[0] / 100f) * 1.1f;
			int num5 = (int)(num4 + 0.5f);
			ignorePhysicsAttack = ((num5 <= strengthenLevel) ? strengthenLevel : num5);
			float num6 = ((float)levelLimit + num) * 0.125f * num3 * num2 * ((float)list[1] / 100f) * 1.1f;
			int num7 = (int)(num6 + 0.5f);
			ignoreMagicAttack = ((num7 <= strengthenLevel) ? strengthenLevel : num7);
		}

		// Token: 0x0600B680 RID: 46720 RVA: 0x002948B0 File Offset: 0x00292CB0
		private static int _CalculateRealProp(int a_nBaseValue, float a_fBaseRatio, float a_fPerRatio, int a_nQuality)
		{
			if (a_nBaseValue <= 0)
			{
				return 0;
			}
			int num = (int)((float)a_nBaseValue * a_fBaseRatio + (float)a_nBaseValue * (1f - a_fBaseRatio) * (float)a_nQuality / 100f);
			if (a_nQuality >= 100)
			{
				int num2 = (int)((float)a_nBaseValue * a_fPerRatio);
				if (num2 < 1000)
				{
					num2 = 1000;
				}
				num += num2;
			}
			return num;
		}

		// Token: 0x0600B681 RID: 46721 RVA: 0x00294904 File Offset: 0x00292D04
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.ItemDataManager;
		}

		// Token: 0x0600B682 RID: 46722 RVA: 0x00294908 File Offset: 0x00292D08
		public sealed override void Initialize()
		{
			this.Clear();
			this._BindNetMessage();
			this.InitData();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FatigueChanged, new ClientEventSystem.UIEventHandler(this._OnFatigueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this.OnSyncResistMagicValueByBuffChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this.OnSyncResistMagicValueByBuffChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ContinueProcessStart, new ClientEventSystem.UIEventHandler(this.OnContinueProcessStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ContinueProcessFinish, new ClientEventSystem.UIEventHandler(this.OnContinueProcessFinish));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ContinueProcessReset, new ClientEventSystem.UIEventHandler(this.OnContinueProcessReset));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			Dictionary<ItemTable.eType, ItemDataManager.PopUpCondition> dictionary = this.popUpConditions;
			ItemTable.eType key = ItemTable.eType.EQUIP;
			ItemDataManager.PopUpCondition popUpCondition = new ItemDataManager.PopUpCondition();
			popUpCondition.iMinPlayerLv = 10;
			popUpCondition.iMaxPlayerLv = 45;
			popUpCondition.checkCallBack = ((ItemData itemData) => true);
			dictionary.Add(key, popUpCondition);
			Dictionary<ItemTable.eType, ItemDataManager.PopUpCondition> dictionary2 = this.popUpConditions;
			ItemTable.eType key2 = ItemTable.eType.FUCKTITTLE;
			popUpCondition = new ItemDataManager.PopUpCondition();
			popUpCondition.iMinPlayerLv = 7;
			popUpCondition.iMaxPlayerLv = 45;
			popUpCondition.checkCallBack = ((ItemData itemData) => true);
			dictionary2.Add(key2, popUpCondition);
			Dictionary<ItemTable.eType, ItemDataManager.PopUpCondition> dictionary3 = this.popUpConditions;
			ItemTable.eType key3 = ItemTable.eType.FASHION;
			popUpCondition = new ItemDataManager.PopUpCondition();
			popUpCondition.iMinPlayerLv = 5;
			popUpCondition.iMaxPlayerLv = 30;
			popUpCondition.checkCallBack = ((ItemData itemData) => true);
			dictionary3.Add(key3, popUpCondition);
			Dictionary<ItemTable.eType, ItemDataManager.PopUpCondition> dictionary4 = this.popUpConditions;
			ItemTable.eType key4 = ItemTable.eType.MATERIAL;
			popUpCondition = new ItemDataManager.PopUpCondition();
			popUpCondition.iMinPlayerLv = 10;
			popUpCondition.iMaxPlayerLv = 0;
			popUpCondition.checkCallBack = ((ItemData itemData) => true);
			dictionary4.Add(key4, popUpCondition);
			Dictionary<ItemTable.eType, ItemDataManager.PopUpCondition> dictionary5 = this.popUpConditions;
			ItemTable.eType key5 = ItemTable.eType.EXPENDABLE;
			popUpCondition = new ItemDataManager.PopUpCondition();
			popUpCondition.iMinPlayerLv = 10;
			popUpCondition.iMaxPlayerLv = 0;
			popUpCondition.checkCallBack = ((ItemData itemData) => itemData.TableData.SubType == ItemTable.eSubType.GiftPackage || itemData.TableData.SubType == ItemTable.eSubType.PetEgg);
			dictionary5.Add(key5, popUpCondition);
		}

		// Token: 0x0600B683 RID: 46723 RVA: 0x00294B61 File Offset: 0x00292F61
		public void InitData()
		{
			this._clearData();
			this._InitMoneyTableData();
			this._InitEquipScore();
		}

		// Token: 0x0600B684 RID: 46724 RVA: 0x00294B78 File Offset: 0x00292F78
		public sealed override void Clear()
		{
			this._UnBindNetMessage();
			this._clearData();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FatigueChanged, new ClientEventSystem.UIEventHandler(this._OnFatigueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this.OnSyncResistMagicValueByBuffChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this.OnSyncResistMagicValueByBuffChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ContinueProcessStart, new ClientEventSystem.UIEventHandler(this.OnContinueProcessStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ContinueProcessFinish, new ClientEventSystem.UIEventHandler(this.OnContinueProcessFinish));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ContinueProcessReset, new ClientEventSystem.UIEventHandler(this.OnContinueProcessReset));
			this.popUpConditions.Clear();
			this.bCalResistMagicValue = true;
			this.bUseVoidCrackTicketIsPlayPrompt = false;
		}

		// Token: 0x0600B685 RID: 46725 RVA: 0x00294C8C File Offset: 0x0029308C
		public void ClearChijiData()
		{
			this.m_itemsDict.Clear();
			this.m_ItemNumDict.Clear();
			this.m_itemPackageTypesDict.Clear();
			this.m_itemTypesDict.Clear();
			this.m_akNeedPopEquips.Clear();
			this.m_packageHasNew = new ushort[15];
			this.m_arrItemCDs.Clear();
			this.m_fItemUpdateInterval = 0f;
			this.m_arrTimeLessItems.Clear();
		}

		// Token: 0x0600B686 RID: 46726 RVA: 0x00294D00 File Offset: 0x00293100
		private void _clearData()
		{
			this.m_itemsDict.Clear();
			this.m_ItemNumDict.Clear();
			this.m_itemPackageTypesDict.Clear();
			this.m_itemTypesDict.Clear();
			this.m_itemCDGroupDict.Clear();
			this.mItemDoubleCheckNeedShow.Clear();
			this.m_akNeedPopEquips.Clear();
			this.m_packageHasNew = new ushort[15];
			this.m_commonTableItemDict.Clear();
			this.m_moneyTypeIDDict.Clear();
			this.m_AuctionMainTypeIDDict.Clear();
			this.m_arrItemCDs.Clear();
			this.m_fItemUpdateInterval = 0f;
			this.m_arrTimeLessItems.Clear();
			this.beforeDisplayAttribute = null;
		}

		// Token: 0x0600B687 RID: 46727 RVA: 0x00294DB0 File Offset: 0x002931B0
		public sealed override void Update(float a_fTime)
		{
			this.m_fItemUpdateInterval -= a_fTime;
			if (this.m_fItemUpdateInterval <= 0f)
			{
				this.m_fItemUpdateInterval = 1f;
			}
		}

		// Token: 0x0600B688 RID: 46728 RVA: 0x00294DDB File Offset: 0x002931DB
		private void _SortTimeLessItems()
		{
			this.m_arrTimeLessItems.Sort(delegate(ItemData var1, ItemData var2)
			{
				int num;
				bool flag;
				var1.GetTimeLeft(out num, out flag);
				int num2;
				bool flag2;
				var2.GetTimeLeft(out num2, out flag2);
				if (num <= 0)
				{
					if (num2 > 0)
					{
						return -1;
					}
					return 0;
				}
				else
				{
					if (num2 <= 0)
					{
						return 1;
					}
					return num - num2;
				}
			});
		}

		// Token: 0x0600B689 RID: 46729 RVA: 0x00294E08 File Offset: 0x00293208
		private void _OnSCNotifyTimeItem(MsgDATA msg)
		{
			SCNotifyTimeItem scnotifyTimeItem = new SCNotifyTimeItem();
			scnotifyTimeItem.decode(msg.bytes);
			for (int i = 0; i < scnotifyTimeItem.items.Length; i++)
			{
				TimeItem timeItem = scnotifyTimeItem.items[i];
				if (timeItem != null)
				{
					ItemData item = this.GetItem(timeItem.itemUid);
					if (item != null)
					{
						if (DataManager<DeadLineReminderDataManager>.GetInstance() != null)
						{
							DataManager<DeadLineReminderDataManager>.GetInstance().RemoveAll(timeItem.itemUid);
						}
						if (item.DeadTimestamp > 0)
						{
							uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
							int num = item.DeadTimestamp - (int)serverTime;
							if (num <= 86400)
							{
								DeadLineReminderModel model = new DeadLineReminderModel
								{
									type = DeadLineReminderType.DRT_LIMITTIMEITEM,
									itemData = item
								};
								if (DataManager<DeadLineReminderDataManager>.GetInstance() != null)
								{
									DataManager<DeadLineReminderDataManager>.GetInstance().Add(model);
								}
							}
						}
					}
				}
			}
			DataManager<DeadLineReminderDataManager>.GetInstance().Sort();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
		}

		// Token: 0x0600B68A RID: 46730 RVA: 0x00294EFC File Offset: 0x002932FC
		public void SendDeleteTimeLessItemsNotify()
		{
			for (int i = 0; i < this.m_arrTimeLessItems.Count; i++)
			{
				SceneDeleteNotifyList sceneDeleteNotifyList = new SceneDeleteNotifyList();
				sceneDeleteNotifyList.notify.type = 5U;
				sceneDeleteNotifyList.notify.param = this.m_arrTimeLessItems[i].GUID;
				NetManager.Instance().SendCommand<SceneDeleteNotifyList>(ServerType.GATE_SERVER, sceneDeleteNotifyList);
			}
			this.m_arrTimeLessItems.Clear();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TimeLessItemsChanged, null, null, null, null);
		}

		// Token: 0x0600B68B RID: 46731 RVA: 0x00294F7E File Offset: 0x0029337E
		public List<ItemData> GetTimeLessItems()
		{
			return this.m_arrTimeLessItems;
		}

		// Token: 0x0600B68C RID: 46732 RVA: 0x00294F88 File Offset: 0x00293388
		public void SetupItemCDs(List<ItemCD> a_arrCDs)
		{
			if (a_arrCDs != null)
			{
				for (int i = 0; i < a_arrCDs.Count; i++)
				{
					ItemCD source = a_arrCDs[i];
					ItemCD itemCD = this.m_arrItemCDs.Find((ItemCD value) => value.groupid == source.groupid);
					if (itemCD != null)
					{
						itemCD.endtime = source.endtime;
						itemCD.maxtime = source.maxtime;
					}
					else
					{
						this.m_arrItemCDs.Add(source);
					}
				}
			}
		}

		// Token: 0x0600B68D RID: 46733 RVA: 0x0029501C File Offset: 0x0029341C
		public int GetItemCount(int tableID)
		{
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				Logger.LogErrorFormat("Can not Get AllItems from tableID IS is {0}", new object[]
				{
					tableID
				});
				return 0;
			}
			Dictionary<ulong, ItemData>.Enumerator enumerator = allPackageItems.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<ulong, ItemData> keyValuePair = enumerator.Current;
				if (keyValuePair.Value.PackageType != EPackageType.Storage)
				{
					KeyValuePair<ulong, ItemData> keyValuePair2 = enumerator.Current;
					if (keyValuePair2.Value.PackageType != EPackageType.RoleStorage)
					{
						KeyValuePair<ulong, ItemData> keyValuePair3 = enumerator.Current;
						int tableID2 = keyValuePair3.Value.TableID;
						if (tableID2 == tableID)
						{
							int num2 = num;
							KeyValuePair<ulong, ItemData> keyValuePair4 = enumerator.Current;
							num = num2 + keyValuePair4.Value.Count;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600B68E RID: 46734 RVA: 0x002950E0 File Offset: 0x002934E0
		public int GetItemCountInPackage(int tableID)
		{
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				Logger.LogErrorFormat("Can not Get AllItems from tableID IS is {0}", new object[]
				{
					tableID
				});
				return 0;
			}
			Dictionary<ulong, ItemData>.Enumerator enumerator = allPackageItems.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<ulong, ItemData> keyValuePair = enumerator.Current;
				if (keyValuePair.Value.PackageType != EPackageType.Storage)
				{
					KeyValuePair<ulong, ItemData> keyValuePair2 = enumerator.Current;
					if (keyValuePair2.Value.PackageType != EPackageType.WearEquip)
					{
						KeyValuePair<ulong, ItemData> keyValuePair3 = enumerator.Current;
						if (keyValuePair3.Value.PackageType != EPackageType.WearFashion)
						{
							KeyValuePair<ulong, ItemData> keyValuePair4 = enumerator.Current;
							if (keyValuePair4.Value.PackageType != EPackageType.RoleStorage)
							{
								KeyValuePair<ulong, ItemData> keyValuePair5 = enumerator.Current;
								int tableID2 = keyValuePair5.Value.TableID;
								if (tableID2 == tableID)
								{
									int num2 = num;
									KeyValuePair<ulong, ItemData> keyValuePair6 = enumerator.Current;
									num = num2 + keyValuePair6.Value.Count;
								}
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600B68F RID: 46735 RVA: 0x002951D8 File Offset: 0x002935D8
		public int GetEqualFashionPriority(int tempType, int subType)
		{
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				return -1;
			}
			Dictionary<ulong, ItemData>.Enumerator enumerator = allPackageItems.GetEnumerator();
			int result = 0;
			while (enumerator.MoveNext())
			{
				KeyValuePair<ulong, ItemData> keyValuePair = enumerator.Current;
				if (keyValuePair.Value.PackageType == EPackageType.WearFashion)
				{
					KeyValuePair<ulong, ItemData> keyValuePair2 = enumerator.Current;
					int tableID = keyValuePair2.Value.TableID;
					EquipmentRelationTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipmentRelationTable>(tableID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.ItemType == (EquipmentRelationTable.eItemType)tempType && tableItem.SubType == (EquipmentRelationTable.eSubType)subType)
					{
						result = tableItem.Priority;
					}
				}
			}
			return result;
		}

		// Token: 0x0600B690 RID: 46736 RVA: 0x00295288 File Offset: 0x00293688
		public ulong GetItemGUIDForType(int tableID, EPackageType packageType)
		{
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				Logger.LogErrorFormat("Can not Get AllItems from tableID IS is {0}", new object[]
				{
					tableID
				});
				return 0UL;
			}
			Dictionary<ulong, ItemData>.Enumerator enumerator = allPackageItems.GetEnumerator();
			ulong result = 0UL;
			while (enumerator.MoveNext())
			{
				KeyValuePair<ulong, ItemData> keyValuePair = enumerator.Current;
				if (keyValuePair.Value.PackageType == packageType)
				{
					KeyValuePair<ulong, ItemData> keyValuePair2 = enumerator.Current;
					int tableID2 = keyValuePair2.Value.TableID;
					if (tableID2 == tableID)
					{
						KeyValuePair<ulong, ItemData> keyValuePair3 = enumerator.Current;
						return keyValuePair3.Value.GUID;
					}
				}
			}
			return result;
		}

		// Token: 0x0600B691 RID: 46737 RVA: 0x00295330 File Offset: 0x00293730
		public List<ItemData> GetItemDataListBySubType(int thisSubType, EPackageType packageType)
		{
			Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
			if (allPackageItems == null)
			{
				return null;
			}
			Dictionary<ulong, ItemData>.Enumerator enumerator = allPackageItems.GetEnumerator();
			List<ItemData> list = new List<ItemData>();
			while (enumerator.MoveNext())
			{
				KeyValuePair<ulong, ItemData> keyValuePair = enumerator.Current;
				if (keyValuePair.Value.SubType == thisSubType)
				{
					KeyValuePair<ulong, ItemData> keyValuePair2 = enumerator.Current;
					if (keyValuePair2.Value.PackageType == packageType)
					{
						List<ItemData> list2 = list;
						KeyValuePair<ulong, ItemData> keyValuePair3 = enumerator.Current;
						list2.Add(keyValuePair3.Value);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B692 RID: 46738 RVA: 0x002953BA File Offset: 0x002937BA
		public Dictionary<ulong, ItemData> GetAllPackageItems()
		{
			return this.m_itemsDict;
		}

		// Token: 0x0600B693 RID: 46739 RVA: 0x002953C4 File Offset: 0x002937C4
		public List<ulong> GetPackageItems()
		{
			if (this.m_itemsDict == null)
			{
				return null;
			}
			List<ulong> list = new List<ulong>();
			foreach (KeyValuePair<ulong, ItemData> keyValuePair in this.m_itemsDict)
			{
				ItemData value = keyValuePair.Value;
				if (value != null)
				{
					if (value.PackageType != EPackageType.WearEquip && value.PackageType != EPackageType.WearFashion && value.PackageType != EPackageType.Storage && value.PackageType != EPackageType.RoleStorage)
					{
						List<ulong> list2 = list;
						Dictionary<ulong, ItemData>.Enumerator enumerator;
						KeyValuePair<ulong, ItemData> keyValuePair2 = enumerator.Current;
						list2.Add(keyValuePair2.Key);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B694 RID: 46740 RVA: 0x0029546C File Offset: 0x0029386C
		public List<ulong> GetItemsByPackageType(EPackageType type)
		{
			List<ulong> list = null;
			if (this.m_itemPackageTypesDict != null)
			{
				this.m_itemPackageTypesDict.TryGetValue(type, out list);
			}
			if (list == null)
			{
				return new List<ulong>();
			}
			return list;
		}

		// Token: 0x0600B695 RID: 46741 RVA: 0x002954A2 File Offset: 0x002938A2
		public void UpdateItemGuidListByPackageType(EPackageType type, List<ulong> itemGuidList)
		{
			if (itemGuidList == null)
			{
				itemGuidList = new List<ulong>();
			}
			if (this.m_itemPackageTypesDict != null)
			{
				this.m_itemPackageTypesDict[type] = itemGuidList;
			}
		}

		// Token: 0x0600B696 RID: 46742 RVA: 0x002954CC File Offset: 0x002938CC
		public List<ulong> GetItemsByType(ItemTable.eType type)
		{
			List<ulong> list;
			this.m_itemTypesDict.TryGetValue(type, out list);
			if (list == null)
			{
				return new List<ulong>();
			}
			return list;
		}

		// Token: 0x0600B697 RID: 46743 RVA: 0x002954F8 File Offset: 0x002938F8
		public List<ulong> GetItemsByPackageSubType(EPackageType type, ItemTable.eSubType subType)
		{
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(type);
			List<ulong> list = new List<ulong>();
			list.AddRange(itemsByPackageType);
			list.RemoveAll(delegate(ulong x)
			{
				ItemData item = this.GetItem(x);
				return item == null || item.SubType != (int)subType;
			});
			return list;
		}

		// Token: 0x0600B698 RID: 46744 RVA: 0x00295542 File Offset: 0x00293942
		public ulong GetMainWeapon()
		{
			return this.GetWearEquipBySlotType(EEquipWearSlotType.EquipWeapon);
		}

		// Token: 0x0600B699 RID: 46745 RVA: 0x0029554C File Offset: 0x0029394C
		public List<ulong> GetOccupationFitEquip(List<ulong> list)
		{
			List<ulong> list2 = new List<ulong>();
			list2.AddRange(list);
			list2.RemoveAll(delegate(ulong x)
			{
				ItemData item = this.GetItem(x);
				return item == null || item.EquipType == EEquipType.ET_BREATH || !this.ShowInSideWeaponBag(item);
			});
			return list2;
		}

		// Token: 0x0600B69A RID: 46746 RVA: 0x0029557A File Offset: 0x0029397A
		private bool ShowInSideWeaponBag(ItemData data)
		{
			return data.IsOccupationFit() && !data.isInSidePack;
		}

		// Token: 0x0600B69B RID: 46747 RVA: 0x00295594 File Offset: 0x00293994
		public List<ulong> GetItemsByPackageThirdType(EPackageType type, ItemTable.eSubType subType, ItemTable.eThirdType thirdType)
		{
			List<ulong> itemsByPackageSubType = this.GetItemsByPackageSubType(type, subType);
			itemsByPackageSubType.RemoveAll(delegate(ulong x)
			{
				ItemData item = this.GetItem(x);
				return item == null || item.ThirdType != thirdType;
			});
			return itemsByPackageSubType;
		}

		// Token: 0x0600B69C RID: 46748 RVA: 0x002955D4 File Offset: 0x002939D4
		public List<ulong> GetItemsByPackageThirdType(EPackageType type, ItemTable.eThirdType thirdType)
		{
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(type);
			List<ulong> list = new List<ulong>();
			list.AddRange(itemsByPackageType);
			list.RemoveAll(delegate(ulong x)
			{
				ItemData item = this.GetItem(x);
				return item == null || item.ThirdType != thirdType;
			});
			return list;
		}

		// Token: 0x0600B69D RID: 46749 RVA: 0x00295620 File Offset: 0x00293A20
		public List<ulong> GetItemsByCDGroup(int a_nGroupID)
		{
			List<ulong> list;
			this.m_itemCDGroupDict.TryGetValue(a_nGroupID, out list);
			if (list == null)
			{
				return new List<ulong>();
			}
			return list;
		}

		// Token: 0x0600B69E RID: 46750 RVA: 0x0029564C File Offset: 0x00293A4C
		public ulong GetFashionWearEquipBySlotType(EFashionWearSlotType eTarget)
		{
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(EPackageType.WearFashion);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = this.GetItem(itemsByPackageType[i]);
				if (item != null && item.FashionWearSlotType == eTarget)
				{
					return itemsByPackageType[i];
				}
			}
			return 0UL;
		}

		// Token: 0x0600B69F RID: 46751 RVA: 0x002956A4 File Offset: 0x00293AA4
		public ulong GetWearEquipBySlotType(EEquipWearSlotType eTarget)
		{
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = this.GetItem(itemsByPackageType[i]);
				if (item != null && item.EquipWearSlotType == eTarget)
				{
					return itemsByPackageType[i];
				}
			}
			return 0UL;
		}

		// Token: 0x0600B6A0 RID: 46752 RVA: 0x002956FC File Offset: 0x00293AFC
		public ItemData GetWearEquipDataBySlotType(EEquipWearSlotType eTarget)
		{
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = this.GetItem(itemsByPackageType[i]);
				if (item != null && item.EquipWearSlotType == eTarget)
				{
					return item;
				}
			}
			return null;
		}

		// Token: 0x0600B6A1 RID: 46753 RVA: 0x0029574C File Offset: 0x00293B4C
		public ItemData GetItem(ulong id)
		{
			ItemData result = null;
			if (this.m_itemsDict.TryGetValue(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0600B6A2 RID: 46754 RVA: 0x00295774 File Offset: 0x00293B74
		public ItemData GetItemByTableID(int tableID, bool bIncludeStoreHouse = true, bool bIncludeWearedItem = true)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			List<ulong> itemsByType = this.GetItemsByType(tableItem.Type);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData item = this.GetItem(itemsByType[i]);
				if (item != null && item.TableID == tableID)
				{
					if (bIncludeStoreHouse || (item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage))
					{
						if (bIncludeWearedItem || (item.PackageType != EPackageType.WearEquip && item.PackageType != EPackageType.WearFashion))
						{
							return item;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600B6A3 RID: 46755 RVA: 0x00295834 File Offset: 0x00293C34
		public ItemData GetCommonItemTableDataByID(int a_nTableID)
		{
			ItemData itemData = null;
			if (this.m_commonTableItemDict.TryGetValue(a_nTableID, out itemData))
			{
				return itemData;
			}
			itemData = ItemDataManager.CreateItemDataFromTable(a_nTableID, 100, 0);
			if (itemData == null)
			{
				return itemData;
			}
			this.m_commonTableItemDict.Add(itemData.TableID, itemData);
			return itemData;
		}

		// Token: 0x0600B6A4 RID: 46756 RVA: 0x00295880 File Offset: 0x00293C80
		public ItemData GetMoneyTableDataByType(ItemTable.eSubType a_eType)
		{
			ItemData result = null;
			int key = 0;
			if (this.m_moneyTypeIDDict.TryGetValue(a_eType, out key))
			{
				this.m_commonTableItemDict.TryGetValue(key, out result);
			}
			return result;
		}

		// Token: 0x0600B6A5 RID: 46757 RVA: 0x002958B4 File Offset: 0x00293CB4
		public ItemCD GetItemCD(int a_nID)
		{
			if (this.m_arrItemCDs == null || this.m_arrItemCDs.Count == 0)
			{
				return null;
			}
			if (a_nID != this.cachedID || this.cachedItemCD == null)
			{
				this.cachedItemCD = this._FindItemCDByID(a_nID);
				this.cachedID = a_nID;
			}
			return this.cachedItemCD;
		}

		// Token: 0x0600B6A6 RID: 46758 RVA: 0x00295910 File Offset: 0x00293D10
		protected ItemCD _FindItemCDByID(int id)
		{
			return this.m_arrItemCDs.Find((ItemCD value) => (int)value.groupid == id);
		}

		// Token: 0x0600B6A7 RID: 46759 RVA: 0x00295944 File Offset: 0x00293D44
		public bool TryDoUnBindItemCostHint(int a_tableID, int iNeedCount, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(a_tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			ItemTable itemTable = null;
			if (tableItem.SubType == ItemTable.eSubType.BindGOLD)
			{
				itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD), string.Empty, string.Empty);
			}
			else if (tableItem.SubType == ItemTable.eSubType.BindPOINT)
			{
				itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT), string.Empty, string.Empty);
			}
			if (itemTable == null)
			{
				return false;
			}
			int ownedItemCount = this.GetOwnedItemCount(a_tableID, true);
			int ownedItemCount2 = this.GetOwnedItemCount(a_tableID, false);
			if (ownedItemCount < iNeedCount || ownedItemCount - ownedItemCount2 >= iNeedCount)
			{
				return false;
			}
			SystemNotifyManager.SystemNotify(7005, OnOKCallBack, OnCancelCallBack, new object[]
			{
				tableItem.Name,
				itemTable.Name
			});
			return true;
		}

		// Token: 0x0600B6A8 RID: 46760 RVA: 0x00295A24 File Offset: 0x00293E24
		public int GetMoneyTypeID(byte bType)
		{
			if (bType == 1)
			{
				return 600000001;
			}
			Logger.LogErrorFormat("服务器下发的货币id = {0},请在GetMoneyTypeID()转换对应货币的表格ID", new object[]
			{
				bType
			});
			return 0;
		}

		// Token: 0x0600B6A9 RID: 46761 RVA: 0x00295A50 File Offset: 0x00293E50
		public int GetOwnedItemCount(int a_tableID, bool a_bNeedRelevance = true)
		{
			int num = this._GetOwnedItemCount(a_tableID);
			if (a_bNeedRelevance)
			{
				EqualItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EqualItemTable>(a_tableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int i = 0; i < tableItem.EqualItemIDs.Count; i++)
					{
						num += this._GetOwnedItemCount(tableItem.EqualItemIDs[i]);
					}
				}
			}
			return num;
		}

		// Token: 0x0600B6AA RID: 46762 RVA: 0x00295ABC File Offset: 0x00293EBC
		public string GetOwnedItemName(int a_tableID)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(a_tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return tableItem.Name;
		}

		// Token: 0x0600B6AB RID: 46763 RVA: 0x00295AF4 File Offset: 0x00293EF4
		public string GetOwnedItemIconPath(int a_tableID)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(a_tableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return tableItem.Icon;
		}

		// Token: 0x0600B6AC RID: 46764 RVA: 0x00295B2C File Offset: 0x00293F2C
		public List<int> GetAuctionItemListBaseFliter(ItemTable.eType itemType, ItemTable.eSubType itemSubType)
		{
			Dictionary<ItemTable.eSubType, List<int>> dictionary = null;
			if (!this.m_AuctionMainTypeIDDict.TryGetValue(itemType, out dictionary))
			{
				return null;
			}
			List<int> result = null;
			if (!dictionary.TryGetValue(itemSubType, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0600B6AD RID: 46765 RVA: 0x00295B64 File Offset: 0x00293F64
		public Dictionary<ItemTable.eSubType, List<int>> GetAuctionItemListByItemType(ItemTable.eType itemType)
		{
			Dictionary<ItemTable.eSubType, List<int>> result = null;
			if (!this.m_AuctionMainTypeIDDict.TryGetValue(itemType, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0600B6AE RID: 46766 RVA: 0x00295B8C File Offset: 0x00293F8C
		public bool TradeItemTypeFliter(List<EPackageType> TypeList, EPackageType ItemType)
		{
			for (int i = 0; i < TypeList.Count; i++)
			{
				if (TypeList[i] == ItemType)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B6AF RID: 46767 RVA: 0x00295BC0 File Offset: 0x00293FC0
		public bool TradeItemQualityFliter(List<ItemTable.eColor> QualityList, ItemTable.eColor ItemColor)
		{
			for (int i = 0; i < QualityList.Count; i++)
			{
				if (QualityList[i] == ItemColor)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B6B0 RID: 46768 RVA: 0x00295BF4 File Offset: 0x00293FF4
		public bool TradeItemStateFliter(ItemData itemData)
		{
			return (itemData.BindAttr != ItemTable.eOwner.NOTBIND && !itemData.Packing && itemData.RePackTime > 0) || this.CanTrade(itemData);
		}

		// Token: 0x0600B6B1 RID: 46769 RVA: 0x00295C22 File Offset: 0x00294022
		public bool TradeItemStateFliter(ItemTable item)
		{
			return item != null && ((item.Owner != ItemTable.eOwner.ROLEBIND && item.Owner != ItemTable.eOwner.ACCBIND) || item.SealMax > 0);
		}

		// Token: 0x0600B6B2 RID: 46770 RVA: 0x00295C53 File Offset: 0x00294053
		public bool CanTrade(ItemData itemData)
		{
			return itemData.BindAttr == ItemTable.eOwner.NOTBIND || itemData.Packing;
		}

		// Token: 0x0600B6B3 RID: 46771 RVA: 0x00295C74 File Offset: 0x00294074
		private int _GetOwnedItemCount(int a_nTableID)
		{
			int num = 0;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(a_nTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.SubType == ItemTable.eSubType.GOLD)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().Gold;
				}
				if (tableItem.SubType == ItemTable.eSubType.BindGOLD)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().BindGold;
				}
				if (tableItem.SubType == ItemTable.eSubType.POINT)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().Ticket;
				}
				if (tableItem.SubType == ItemTable.eSubType.BindPOINT)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().BindTicket;
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_CREDIT_POINT)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().CreditTicketOwnerBySelf;
				}
				if (tableItem.SubType == ItemTable.eSubType.WARRIOR_SOUL)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().WarriorSoul;
				}
				if (tableItem.SubType == ItemTable.eSubType.DUEL_COIN)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().uiPkCoin;
				}
				if (tableItem.SubType == ItemTable.eSubType.GuildContri)
				{
					return DataManager<PlayerBaseData>.GetInstance().guildContribution;
				}
				if (tableItem.SubType == ItemTable.eSubType.GoldJarPoint)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().GoldJarScore;
				}
				if (tableItem.SubType == ItemTable.eSubType.MagicJarPoint)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().MagicJarScore;
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_APPOINTMENT_COIN)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().AppoinmentCoin;
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_MASTER_GOODTEACH_VALUE)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().GoodTeacherValue;
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_WEAPON_LEASE_TICKET)
				{
					return (int)DataManager<PlayerBaseData>.GetInstance().WeaponLeaseTicket;
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_GOLD_REWARD_VALUE)
				{
					return (int)DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamBountyCount();
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_BLESS_CRYSTAL_VALUE)
				{
					return (int)DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamBlessCrystalCount();
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_CHI_JI_COIN)
				{
					return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.CHIJI_SCORE);
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_ZJSL_WZHJJJ_COIN)
				{
					return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.ZJSL_WZHJJJ_COIN);
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_ZJSL_WZHGGG_COIN)
				{
					return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.ZJSL_WZHGGG_COIN);
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_CHAMPION_COIN)
				{
					return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_CHAMPIONSHIP_GUESS_ITEM);
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_HIRE_COIN)
				{
					return (int)DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_COUNTER_HIRE_COIN);
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_ACTIVATE || tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_CLEANUP || tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_CREATE || tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_PROTECT || tableItem.SubType == ItemTable.eSubType.ST_STRENGTHEN_PROTECT)
				{
					List<ulong> itemsByType = this.GetItemsByType(tableItem.Type);
					for (int i = 0; i < itemsByType.Count; i++)
					{
						ItemData item = this.GetItem(itemsByType[i]);
						if (item != null && item.TableID == a_nTableID && item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage)
						{
							int num2;
							bool flag;
							item.GetLimitTimeLeft(out num2, out flag);
							if (num2 > 0 || !flag)
							{
								num += item.Count;
							}
						}
					}
				}
				else
				{
					if (tableItem.SubType == ItemTable.eSubType.ST_MALL_POINT)
					{
						return (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket;
					}
					if (tableItem.SubType == ItemTable.eSubType.ST_ADVENTURE_COIN)
					{
						return (int)DataManager<PlayerBaseData>.GetInstance().adventureCoin;
					}
					if (tableItem.SubType == ItemTable.eSubType.ST_DEEP_TICKET)
					{
						return this.GetItemCountBySubType(EPackageType.Material, ItemTable.eSubType.ST_DEEP_TICKET);
					}
					if (tableItem.SubType == ItemTable.eSubType.ST_ANCIENT_TICKET)
					{
						return this.GetItemCountBySubType(EPackageType.Material, ItemTable.eSubType.ST_ANCIENT_TICKET);
					}
					if (tableItem.SubType == ItemTable.eSubType.ST_FANTASY_COIN)
					{
						return DataManager<ZillionaireGameDataManager>.GetInstance().CoinCount;
					}
					if (tableItem.SubType == ItemTable.eSubType.ST_SECRET_SELL_COIN)
					{
						return DataManager<ActivityDataManager>.GetInstance().AnniversaryPoint;
					}
					if (this.m_ItemNumDict.TryGetValue(a_nTableID, out num))
					{
						return num;
					}
				}
			}
			return num;
		}

		// Token: 0x0600B6B4 RID: 46772 RVA: 0x00296034 File Offset: 0x00294434
		public int GetItemCountBySubType(EPackageType type, ItemTable.eSubType subType)
		{
			int num = 0;
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(type);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ulong id = itemsByPackageType[i];
				ItemData item = this.GetItem(id);
				if (item != null)
				{
					if (item.SubType == (int)subType)
					{
						num += item.Count;
					}
				}
			}
			return num;
		}

		// Token: 0x0600B6B5 RID: 46773 RVA: 0x0029609C File Offset: 0x0029449C
		public int GetMoneyIDByType(ItemTable.eSubType a_eType)
		{
			int result = 0;
			this.m_moneyTypeIDDict.TryGetValue(a_eType, out result);
			return result;
		}

		// Token: 0x0600B6B6 RID: 46774 RVA: 0x002960BB File Offset: 0x002944BB
		public bool IsPackageHasNew(EPackageType type)
		{
			return type > EPackageType.Invalid && type < EPackageType.Count && this.m_packageHasNew[(int)type] > 0;
		}

		// Token: 0x0600B6B7 RID: 46775 RVA: 0x002960E4 File Offset: 0x002944E4
		public bool IsPackageFull(EPackageType a_eType = EPackageType.Invalid)
		{
			if (a_eType == EPackageType.Invalid)
			{
				return this.GetItemsByPackageType(EPackageType.Equip).Count >= DataManager<PlayerBaseData>.GetInstance().PackTotalSize[1] || this.GetItemsByPackageType(EPackageType.Material).Count >= DataManager<PlayerBaseData>.GetInstance().PackTotalSize[2] || this.GetItemsByPackageType(EPackageType.Consumable).Count >= DataManager<PlayerBaseData>.GetInstance().PackTotalSize[3] || this.GetItemsByPackageType(EPackageType.Task).Count >= DataManager<PlayerBaseData>.GetInstance().PackTotalSize[4] || this.GetItemsByPackageType(EPackageType.Fashion).Count >= DataManager<PlayerBaseData>.GetInstance().PackTotalSize[5] || this.GetItemsByPackageType(EPackageType.Title).Count >= DataManager<PlayerBaseData>.GetInstance().PackTotalSize[10];
			}
			return this.GetItemsByPackageType(a_eType).Count >= DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)a_eType];
		}

		// Token: 0x0600B6B8 RID: 46776 RVA: 0x002961E4 File Offset: 0x002945E4
		public void NotifyItemBeOld(ItemData a_item)
		{
			if (a_item != null && a_item.IsNew)
			{
				a_item.IsNew = false;
				if (a_item.PackageType > EPackageType.Invalid && a_item.PackageType < EPackageType.Count)
				{
					ushort[] packageHasNew = this.m_packageHasNew;
					EPackageType packageType = a_item.PackageType;
					packageHasNew[(int)packageType] = packageHasNew[(int)packageType] - 1;
					this._NotifyItemNewStateChanged();
				}
			}
		}

		// Token: 0x0600B6B9 RID: 46777 RVA: 0x00296240 File Offset: 0x00294640
		public void NotifyItemBeNew(ItemData a_item)
		{
			if (a_item != null && !a_item.IsNew)
			{
				a_item.IsNew = true;
				if (a_item.PackageType > EPackageType.Invalid && a_item.PackageType < EPackageType.Count)
				{
					ushort[] packageHasNew = this.m_packageHasNew;
					EPackageType packageType = a_item.PackageType;
					packageHasNew[(int)packageType] = packageHasNew[(int)packageType] + 1;
					this._NotifyItemNewStateChanged();
				}
			}
		}

		// Token: 0x0600B6BA RID: 46778 RVA: 0x0029629C File Offset: 0x0029469C
		public void ArrangeItemsInPackageFrame(EPackageType type)
		{
			List<ulong> list;
			this.m_itemPackageTypesDict.TryGetValue(type, out list);
			if (list == null)
			{
				return;
			}
			list.Sort(delegate(ulong x, ulong y)
			{
				ItemData item = this.GetItem(x);
				ItemData item2 = this.GetItem(y);
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
				if (type == EPackageType.Equip || type == EPackageType.Title)
				{
					bool isItemInUnUsedEquipPlan = item.IsItemInUnUsedEquipPlan;
					bool isItemInUnUsedEquipPlan2 = item2.IsItemInUnUsedEquipPlan;
					if (isItemInUnUsedEquipPlan && !isItemInUnUsedEquipPlan2)
					{
						return -1;
					}
					if (!isItemInUnUsedEquipPlan && isItemInUnUsedEquipPlan2)
					{
						return 1;
					}
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

		// Token: 0x0600B6BB RID: 46779 RVA: 0x002962EC File Offset: 0x002946EC
		public void ArrangeItems(EPackageType type)
		{
			List<ulong> list;
			this.m_itemPackageTypesDict.TryGetValue(type, out list);
			if (list == null)
			{
				return;
			}
			list.Sort(delegate(ulong x, ulong y)
			{
				ItemData item = this.GetItem(x);
				ItemData item2 = this.GetItem(y);
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

		// Token: 0x0600B6BC RID: 46780 RVA: 0x00296324 File Offset: 0x00294724
		public void TakeItem(ItemData item, int count)
		{
			if (item != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("can not find ItemTableData when id is {0}", new object[]
					{
						item.TableID
					});
				}
				if (tableItem.GetLimitNum != 0 && tableItem.GetLimitNum < DataManager<ItemDataManager>.GetInstance().GetItemCount(item.TableID) + count)
				{
					string name = tableItem.Name;
					object[] array = new object[]
					{
						name
					};
					SystemNotifyManager.SystemNotify(9103, string.Empty);
					return;
				}
				ScenePullStorage scenePullStorage = new ScenePullStorage();
				scenePullStorage.uid = item.GUID;
				scenePullStorage.num = (ushort)count;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<ScenePullStorage>(ServerType.GATE_SERVER, scenePullStorage);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<ScenePullStorageRet>(delegate(ScenePullStorageRet msgRet)
				{
					if (msgRet.code != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					}
					else
					{
						UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemTakeSuccess, item.PackageType, null, null, null);
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B6BD RID: 46781 RVA: 0x00296434 File Offset: 0x00294834
		public void SendSellItem(ulong[] guids)
		{
			SceneSellItemBatReq sceneSellItemBatReq = new SceneSellItemBatReq();
			sceneSellItemBatReq.itemUids = guids;
			NetManager.Instance().SendCommand<SceneSellItemBatReq>(ServerType.GATE_SERVER, sceneSellItemBatReq);
		}

		// Token: 0x0600B6BE RID: 46782 RVA: 0x0029645C File Offset: 0x0029485C
		private void _OnRecvSceneSellItemBatRes(MsgDATA msg)
		{
			SceneSellItemBatRes sceneSellItemBatRes = new SceneSellItemBatRes();
			sceneSellItemBatRes.decode(msg.bytes);
			if (sceneSellItemBatRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneSellItemBatRes.code, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("bat_sell_ok"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0600B6BF RID: 46783 RVA: 0x002964AC File Offset: 0x002948AC
		public void SellItem(ItemData item, int Count = 1)
		{
			if (item != null)
			{
				if (!item.CanSell)
				{
					Logger.LogError("物品不可出售！！");
					return;
				}
				if (Count > item.Count)
				{
					Logger.LogErrorFormat("最多可卖{0}个!!", new object[]
					{
						item.Count
					});
					return;
				}
				EPackageType packageType = item.PackageType;
				SceneSellItem sceneSellItem = new SceneSellItem();
				sceneSellItem.uid = item.GUID;
				sceneSellItem.num = (ushort)Count;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneSellItem>(ServerType.GATE_SERVER, sceneSellItem);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneSellItemRet>(delegate(SceneSellItemRet msgRet)
				{
					if (msgRet.code != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					}
					else
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemSellSuccess, packageType, null, null, null);
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B6C0 RID: 46784 RVA: 0x0029655C File Offset: 0x0029495C
		public void UseItem(ItemData item, bool a_bUseAll = false, int a_nParam1 = 0, int a_nParam2 = 0)
		{
			if (item != null)
			{
				if (this.GetItem(item.GUID) == null)
				{
					return;
				}
				if (item.UseType == ItemTable.eCanUse.CanNot)
				{
					SystemNotifyManager.SystemNotify(1007, string.Empty);
					return;
				}
				if (item.SubType == 41 && Utility.IsPlayerLevelFull((int)DataManager<PlayerBaseData>.GetInstance().Level))
				{
					SystemNotifyManager.SystemNotify(1234, string.Empty);
					return;
				}
				if (item.useLimitType == ItemTable.eUseLimiteType.DAYLIMITE)
				{
					if (item.GetCurrentRemainUseTime() <= 0)
					{
						SystemNotifyManager.SystemNotify(1226, string.Empty);
						return;
					}
				}
				else if (item.useLimitType == ItemTable.eUseLimiteType.VIPLIMITE && item.GetCurrentRemainUseTime() <= 0)
				{
					SystemNotifyManager.SystemNotify(1251, delegate()
					{
						VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
						vipFrame.OpenPayTab();
						DataManager<ItemTipManager>.GetInstance().CloseAll();
					});
					return;
				}
				EPackageType packageType = item.PackageType;
				ItemData currentEquipted = null;
				ItemData target = null;
				if ((packageType == EPackageType.Equip || packageType == EPackageType.Fashion || packageType == EPackageType.Title) && item.CanEquip())
				{
					currentEquipted = DataManager<ItemDataManager>.GetInstance().GetItem(DataManager<ItemDataManager>.GetInstance().GetWearEquipBySlotType(item.EquipWearSlotType));
					target = item;
					if (item.ThirdType == ItemTable.eThirdType.BEAMSWORD && DataManager<PlayerBaseData>.GetInstance().JobTableID != 11)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("beamsword_learn_skill"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
				if (packageType == EPackageType.WearEquip || packageType == EPackageType.WearFashion)
				{
					currentEquipted = item;
					target = DataManager<ItemDataManager>.GetInstance().GetItem(DataManager<ItemDataManager>.GetInstance().GetWearEquipBySlotType(item.EquipWearSlotType));
				}
				if (item.TableData.SubType == ItemTable.eSubType.ST_FLYUPITEM)
				{
					DataManager<PlayerBaseData>.GetInstance().IsFlyUpState = true;
				}
				if (!string.IsNullOrEmpty(item.DoubleCheckWindowDesc) && !this.mItemDoubleCheckNeedShow.ContainsKey(item.TableID))
				{
					ItemDoubleCheckData itemDoubleCheckData = new ItemDoubleCheckData();
					itemDoubleCheckData.Desc = item.DoubleCheckWindowDesc;
					itemDoubleCheckData.mCallBack = delegate(bool isCloseNotify)
					{
						if (isCloseNotify)
						{
							this.mItemDoubleCheckNeedShow.Add(item.TableID, true);
						}
						this.SendUseItemMsg(item, currentEquipted, target, a_bUseAll, a_nParam1, a_nParam2);
					};
					itemDoubleCheckData.itemData = item;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ItemDoubleCheckFrame>(FrameLayer.Middle, itemDoubleCheckData, string.Empty);
				}
				else
				{
					this.SendUseItemMsg(item, currentEquipted, target, a_bUseAll, a_nParam1, a_nParam2);
				}
			}
		}

		// Token: 0x0600B6C1 RID: 46785 RVA: 0x0029684B File Offset: 0x00294C4B
		public void UseItemWithoutDoubleCheck(ItemData item, bool a_bUseAll = false, int a_nParam1 = 0, int a_nParam2 = 0)
		{
			this.SendUseItemMsg(item, null, null, a_bUseAll, a_nParam1, a_nParam2);
		}

		// Token: 0x0600B6C2 RID: 46786 RVA: 0x0029685C File Offset: 0x00294C5C
		private void SendUseItemMsg(ItemData item, ItemData currentEquipted, ItemData target, bool a_bUseAll = false, int a_nParam1 = 0, int a_nParam2 = 0)
		{
			SceneUseItem sceneUseItem = new SceneUseItem();
			sceneUseItem.uid = item.GUID;
			sceneUseItem.useAll = ((!a_bUseAll) ? 0 : 1);
			sceneUseItem.param1 = (uint)a_nParam1;
			sceneUseItem.param2 = (uint)a_nParam2;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneUseItem>(ServerType.GATE_SERVER, sceneUseItem);
			if (item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 35)
			{
				this._BindUseJarMsgHandle(item);
			}
			else
			{
				DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneUseItemRet>(delegate(SceneUseItemRet msgRet)
				{
					if (msgRet.code != 0U)
					{
						if (item.TableData.SubType == ItemTable.eSubType.ST_FLYUPITEM)
						{
							DataManager<PlayerBaseData>.GetInstance().IsFlyUpState = false;
						}
						if (item.TableData.SubType == ItemTable.eSubType.ST_CONSUME_JAR_GIFT)
						{
							CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)msgRet.code, string.Empty, string.Empty);
							ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
							if (tableItem != null && tableItem2 != null && tableItem2.jarGiftConsumeItem.Count >= 2)
							{
								int id = tableItem2.jarGiftConsumeItem[0];
								int num = tableItem2.jarGiftConsumeItem[1];
								ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
								if (tableItem3 != null)
								{
									string msgContent = string.Format(tableItem.Descs, new object[]
									{
										tableItem3.Name,
										num,
										tableItem2.Name,
										tableItem3.Name
									});
									SystemNotifyManager.SysNotifyTextAnimation(msgContent, CommonTipsDesc.eShowMode.SI_UNIQUE);
								}
							}
						}
						else
						{
							SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
						}
					}
					else
					{
						this._NotifyItemUseSuccess(item);
						this._OnPackageItemEquiped(currentEquipted, target);
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600B6C3 RID: 46787 RVA: 0x00296928 File Offset: 0x00294D28
		public void SendDecomposeItem(ulong[] a_arrGuilds, bool isDecomposeFashion = false)
		{
			if (a_arrGuilds == null)
			{
				return;
			}
			SceneEquipDecompose sceneEquipDecompose = new SceneEquipDecompose();
			sceneEquipDecompose.uids = a_arrGuilds;
			NetManager.Instance().SendCommand<SceneEquipDecompose>(ServerType.GATE_SERVER, sceneEquipDecompose);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneEquipDecomposeRet>(delegate(SceneEquipDecomposeRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					DecomposeResultData decomposeResultData = new DecomposeResultData();
					decomposeResultData.bSingle = (a_arrGuilds.Length == 1);
					decomposeResultData.arrItems = new List<ItemData>();
					decomposeResultData.bIsDecomposeFashion = isDecomposeFashion;
					for (int i = 0; i < msgRet.getItems.Length; i++)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)msgRet.getItems[i].id, 100, 0);
						if (itemData != null)
						{
							itemData.Count = (int)msgRet.getItems[i].num;
							decomposeResultData.arrItems.Add(itemData);
						}
					}
					if (isDecomposeFashion)
					{
						decomposeResultData.arrItems.Sort(delegate(ItemData x, ItemData y)
						{
							if (x.Quality != y.Quality)
							{
								return y.Quality - x.Quality;
							}
							if (x.ThirdType != y.ThirdType)
							{
								return x.ThirdType - y.ThirdType;
							}
							return x.TableID - y.TableID;
						});
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<DecomposeResultFrame>(FrameLayer.Middle, decomposeResultData, string.Empty);
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionEquipDecomposeFrame>(null, false);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B6C4 RID: 46788 RVA: 0x00296994 File Offset: 0x00294D94
		public void RenewalItem(ItemData a_item, uint a_nTime)
		{
			SceneRenewTimeItemReq sceneRenewTimeItemReq = new SceneRenewTimeItemReq();
			sceneRenewTimeItemReq.itemUid = a_item.GUID;
			sceneRenewTimeItemReq.duration = a_nTime;
			NetManager.Instance().SendCommand<SceneRenewTimeItemReq>(ServerType.GATE_SERVER, sceneRenewTimeItemReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneRenewTimeItemRes>(delegate(SceneRenewTimeItemRes msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					if (a_item.CanEquip() && !a_item.IsEquiped())
					{
						SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("item_renewal_success_equip_ask", a_item.GetColorName(string.Empty, false)), delegate()
						{
							this.UseItem(a_item, false, 0, 0);
						}, null, 0f, false);
					}
					else
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("item_renewal_success"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemRenewalSuccess, null, null, null, null);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B6C5 RID: 46789 RVA: 0x002969FE File Offset: 0x00294DFE
		public void OnLevelChanged(int iPreLv)
		{
			this._OnLevelUpAddNewPopEquipments(iPreLv);
		}

		// Token: 0x0600B6C6 RID: 46790 RVA: 0x00296A07 File Offset: 0x00294E07
		public void OnJobChanged()
		{
			this.m_akNeedPopEquips.Clear();
			this._OnChangeJobAddNewPopEquipments();
		}

		// Token: 0x0600B6C7 RID: 46791 RVA: 0x00296A1C File Offset: 0x00294E1C
		public ItemData CreateItemDataFromNet(Item msgItemData)
		{
			ItemData itemData = new ItemData((int)msgItemData.dataid);
			ItemDataManager._InitTableData(itemData);
			if (!itemData.IsTableDataInited)
			{
				return null;
			}
			itemData.GUID = msgItemData.uid;
			itemData.Count = (int)msgItemData.num;
			itemData.ShowCount = (int)msgItemData.num;
			itemData.Packing = (msgItemData.sealstate == 1);
			itemData.iPackedTimes = (int)msgItemData.sealcount;
			itemData.RePackTime = itemData.iMaxPackTime - itemData.iPackedTimes;
			itemData.PackageType = (EPackageType)msgItemData.pack;
			itemData.GridIndex = (int)msgItemData.grid;
			itemData.StrengthenLevel = (int)msgItemData.strengthen;
			itemData.SubQuality = (int)msgItemData.qualitylv;
			itemData.ItemTradeNumber = (int)msgItemData.auctionTransNum;
			itemData.IsTreasure = (msgItemData.isTreas == 1);
			itemData.AuctionCoolTimeStamp = msgItemData.auctionCoolTimeStamp;
			itemData.DeadTimestamp = (int)msgItemData.deadLine;
			itemData.TransferStone = (int)msgItemData.transferStone;
			itemData.RecoScore = (int)msgItemData.recoScore;
			itemData.finalRateScore = (int)msgItemData.valueScore;
			itemData.bLocked = ((msgItemData.lockItem & 1U) == 1U);
			itemData.IsLease = ((msgItemData.lockItem & 2U) == 2U);
			itemData.bFashionItemLocked = ((msgItemData.lockItem & 8U) == 8U);
			itemData.FashionFreeTimes = (int)msgItemData.fashionFreeSelNum;
			itemData.BaseProp.props[0] = (int)msgItemData.phyatk;
			itemData.BaseProp.props[39] = (int)msgItemData.disPhyAtk;
			itemData.BaseProp.props[60] = (int)msgItemData.independAtkStreng;
			itemData.BaseProp.props[1] = (int)msgItemData.magatk;
			itemData.BaseProp.props[40] = (int)msgItemData.disMagAtk;
			itemData.BaseProp.props[2] = (int)msgItemData.phydef;
			itemData.BaseProp.props[43] = (int)msgItemData.disPhyDef;
			itemData.BaseProp.props[41] = (int)msgItemData.disPhyDefRate;
			itemData.BaseProp.props[3] = (int)msgItemData.magdef;
			itemData.BaseProp.props[44] = (int)msgItemData.disMagDef;
			itemData.BaseProp.props[42] = (int)msgItemData.disMagDefRate;
			itemData.BaseProp.props[4] = (int)msgItemData.strenth;
			itemData.BaseProp.props[5] = (int)msgItemData.intellect;
			itemData.BaseProp.props[6] = (int)msgItemData.spirit;
			itemData.BaseProp.props[7] = (int)msgItemData.stamina;
			itemData.BaseProp.props[59] = (int)msgItemData.independAtk;
			itemData.BaseProp.magicElementsAttack[1] = (int)msgItemData.strPropLight;
			itemData.BaseProp.magicElementsAttack[2] = (int)msgItemData.strPropFire;
			itemData.BaseProp.magicElementsAttack[3] = (int)msgItemData.strPropIce;
			itemData.BaseProp.magicElementsAttack[4] = (int)msgItemData.strPropDark;
			itemData.BaseProp.magicElementsDefence[1] = (int)msgItemData.defPropLight;
			itemData.BaseProp.magicElementsDefence[2] = (int)msgItemData.defPropFire;
			itemData.BaseProp.magicElementsDefence[3] = (int)msgItemData.defPropIce;
			itemData.BaseProp.magicElementsDefence[4] = (int)msgItemData.defPropDark;
			itemData.BaseProp.props[19] = (int)msgItemData.abnormalResistsTotal;
			itemData.BaseProp.abnormalResists[0] = (int)msgItemData.abnormalResistFlash;
			itemData.BaseProp.abnormalResists[1] = (int)msgItemData.abnormalResistBleeding;
			itemData.BaseProp.abnormalResists[2] = (int)msgItemData.abnormalResistBurn;
			itemData.BaseProp.abnormalResists[3] = (int)msgItemData.abnormalResistPoison;
			itemData.BaseProp.abnormalResists[4] = (int)msgItemData.abnormalResistBlind;
			itemData.BaseProp.abnormalResists[5] = (int)msgItemData.abnormalResistStun;
			itemData.BaseProp.abnormalResists[6] = (int)msgItemData.abnormalResistStone;
			itemData.BaseProp.abnormalResists[7] = (int)msgItemData.abnormalResistFrozen;
			itemData.BaseProp.abnormalResists[8] = (int)msgItemData.abnormalResistSleep;
			itemData.BaseProp.abnormalResists[9] = (int)msgItemData.abnormalResistConfunse;
			itemData.BaseProp.abnormalResists[10] = (int)msgItemData.abnormalResistStrain;
			itemData.BaseProp.abnormalResists[11] = (int)msgItemData.abnormalResistSpeedDown;
			itemData.BaseProp.abnormalResists[12] = (int)msgItemData.abnormalResistCurse;
			itemData.FashionAttributeID = (int)msgItemData.fashionAttributeID;
			if (itemData.Type == ItemTable.eType.FASHION)
			{
				itemData.BaseProp = new EquipProp();
				EquipProp equipProp = EquipProp.CreateFromTable(itemData.FashionBaseAttributeID);
				if (equipProp != null)
				{
					itemData.BaseProp += equipProp;
				}
				EquipProp equipProp2 = EquipProp.CreateFromTable(itemData.FashionAttributeID);
				if (equipProp2 != null)
				{
					itemData.BaseProp += equipProp2;
				}
			}
			itemData.EquipType = (EEquipType)msgItemData.equipType;
			itemData.GrowthAttrType = (EGrowthAttrType)msgItemData.enhanceType;
			itemData.GrowthAttrNum = (int)msgItemData.enhanceNum;
			if (itemData.SubType != 25)
			{
				itemData.mPrecEnchantmentCard = this.SwichPrecEnchantmentCard(msgItemData.mountedMagic);
			}
			if (itemData.SubType != 54)
			{
				itemData.PreciousBeadMountHole = this.SwitchPrecBead(msgItemData.preciousBeadHoles);
			}
			else
			{
				itemData.BeadAdditiveAttributeBuffID = (int)msgItemData.param2;
				itemData.BeadPickNumber = (int)msgItemData.beadExtipreCnt;
				itemData.BeadReplaceNumber = (int)msgItemData.beadReplaceCnt;
			}
			if (itemData.Type == ItemTable.eType.EQUIP && itemData.Quality > ItemTable.eColor.PURPLE && msgItemData.inscriptionHoles != null)
			{
				bool flag = false;
				for (int i = 0; i < msgItemData.inscriptionHoles.Length; i++)
				{
					if (msgItemData.inscriptionHoles[i] != null)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					itemData.InscriptionHoles = this.SwichInscriptionHoleData(msgItemData.inscriptionHoles, itemData);
				}
				else
				{
					itemData.InscriptionHoles = DataManager<InscriptionMosaicDataManager>.GetInstance().GetEquipmentInscriptionHoleData(itemData);
				}
			}
			for (int j = 0; j < msgItemData.randProps.Length; j++)
			{
				ItemRandProp itemRandProp = msgItemData.randProps[j];
				if (itemRandProp != null)
				{
					EServerProp type = (EServerProp)itemRandProp.type;
					Type type2 = type.GetType();
					string name = Enum.GetName(type2, type);
					if (!string.IsNullOrEmpty(name))
					{
						FieldInfo field = type2.GetField(name);
						MapEnum mapEnum = Attribute.GetCustomAttribute(field, typeof(MapEnum)) as MapEnum;
						if (mapEnum != null)
						{
							int prop = (int)mapEnum.Prop;
							itemData.RandamProp.props[prop] = (int)itemRandProp.value;
						}
					}
				}
			}
			itemData.IsItemInUnUsedEquipPlan = EquipPlanUtility.IsItemInUnUsedEquipPlanByItemData(itemData);
			return itemData;
		}

		// Token: 0x0600B6C8 RID: 46792 RVA: 0x00297183 File Offset: 0x00295583
		public void NotifyPackageFullState()
		{
			if (this.IsPackageFull(EPackageType.Invalid))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PackageFull, null, null, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PackageNotFull, null, null, null, null);
			}
		}

		// Token: 0x0600B6C9 RID: 46793 RVA: 0x002971BC File Offset: 0x002955BC
		private void _BindUseJarMsgHandle(ItemData a_item)
		{
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneUseItemRet>(delegate(SceneUseItemRet msgRet)
			{
				if (msgRet.code != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
				}
				else
				{
					this._NotifyItemUseSuccess(a_item);
				}
			}, true, 15f, null);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(500943U, delegate(MsgDATA data)
			{
				if (data == null)
				{
					return;
				}
				SceneUseMagicJarRet sceneUseMagicJarRet = new SceneUseMagicJarRet();
				int num = 0;
				sceneUseMagicJarRet.decode(data.bytes, ref num);
				List<Item> list = ItemDecoder.Decode(data.bytes, ref num, data.bytes.Length, false);
				if (sceneUseMagicJarRet.code == 0U)
				{
					DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
					List<JarBonus> list2 = new List<JarBonus>();
					list2.Add(new JarBonus
					{
						nBonusID = 0,
						item = ItemDataManager.CreateItemDataFromTable((int)sceneUseMagicJarRet.baseItem.id, 100, 0),
						item = 
						{
							Count = (int)sceneUseMagicJarRet.baseItem.num
						},
						bHighValue = false
					});
					for (int i = 0; i < sceneUseMagicJarRet.getItems.Length; i++)
					{
						OpenJarResult openJarResult = sceneUseMagicJarRet.getItems[i];
						JarBonus jarBonus = new JarBonus();
						jarBonus.nBonusID = (int)openJarResult.jarItemId;
						JarItemPool tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarItemPool>((int)openJarResult.jarItemId, string.Empty, string.Empty);
						ItemData itemData = null;
						for (int j = 0; j < list.Count; j++)
						{
							if ((long)tableItem.ItemID == (long)((ulong)list[j].dataid))
							{
								Item item = list[j];
								item.num -= (ushort)tableItem.ItemNum;
								itemData = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(list[j]);
								itemData.Count = tableItem.ItemNum;
								if (list[j].num <= 0)
								{
									list.RemoveAt(j);
								}
								break;
							}
						}
						if (itemData == null)
						{
							itemData = ItemDataManager.CreateItemDataFromTable(tableItem.ItemID, 100, 0);
							itemData.Count = tableItem.ItemNum;
						}
						jarBonus.item = itemData;
						jarBonus.bHighValue = (tableItem.ShowEffect == 1);
						list2.Add(jarBonus);
					}
					ShowItemsFrameData showItemsFrameData = new ShowItemsFrameData();
					showItemsFrameData.data = DataManager<JarDataManager>.GetInstance().GetJarData((int)sceneUseMagicJarRet.jarID);
					showItemsFrameData.items = list2;
					showItemsFrameData.buyInfo = null;
					showItemsFrameData.scoreItemData = ItemDataManager.CreateItemDataFromTable((int)sceneUseMagicJarRet.getPointId, 100, 0);
					if (showItemsFrameData.scoreItemData != null)
					{
						showItemsFrameData.scoreItemData.Count = (int)sceneUseMagicJarRet.getPoint;
					}
					showItemsFrameData.scoreRate = (int)sceneUseMagicJarRet.crit;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<JarBuyResultFrame>(FrameLayer.Middle, showItemsFrameData, string.Empty);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600B6CA RID: 46794 RVA: 0x00297230 File Offset: 0x00295630
		private static void _CreateFashionAttributeItems(ItemData data)
		{
			if (data.TableData == null || data.TableData.EquipPropID == 0)
			{
				return;
			}
			FashionAttributesConfigTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionAttributesConfigTable>(data.TableData.EquipPropID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.Attributes.Count; i++)
				{
					EquipAttrTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(tableItem.Attributes[i], string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						if (data.fashionAttributes == null)
						{
							data.fashionAttributes = new List<EquipAttrTable>();
						}
						data.fashionAttributes.Add(tableItem2);
					}
				}
			}
		}

		// Token: 0x0600B6CB RID: 46795 RVA: 0x002972E4 File Offset: 0x002956E4
		private static void _InitTableData(ItemData data)
		{
			if (!data.IsTableDataInited)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(data.TableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				data.GUID = 0UL;
				data.Type = tableItem.Type;
				data.PackageType = EPackageType.Invalid;
				data.SubType = (int)tableItem.SubType;
				data.ThirdType = tableItem.ThirdType;
				if (data.Type == ItemTable.eType.EQUIP)
				{
					data.EquipWearSlotType = (EEquipWearSlotType)tableItem.SubType;
					data.FashionWearSlotType = EFashionWearSlotType.Invalid;
					if (tableItem.SubType == ItemTable.eSubType.ST_ASSIST_EQUIP)
					{
						data.EquipWearSlotType = EEquipWearSlotType.Equipassist1;
					}
					else if (tableItem.SubType == ItemTable.eSubType.ST_MAGICSTONE_EQUIP)
					{
						data.EquipWearSlotType = EEquipWearSlotType.Equipassist2;
					}
					else if (tableItem.SubType == ItemTable.eSubType.ST_EARRINGS_EQUIP)
					{
						data.EquipWearSlotType = EEquipWearSlotType.Equipassist3;
					}
				}
				else if (data.Type == ItemTable.eType.FUCKTITTLE)
				{
					data.EquipWearSlotType = (EEquipWearSlotType)tableItem.SubType;
					data.FashionWearSlotType = EFashionWearSlotType.Invalid;
				}
				else if (data.Type == ItemTable.eType.FASHION)
				{
					data.EquipWearSlotType = EEquipWearSlotType.EquipInvalid;
					if (tableItem.SubType == ItemTable.eSubType.FASHION_WEAPON)
					{
						data.FashionWearSlotType = EFashionWearSlotType.Weapon;
					}
					else if (tableItem.SubType == ItemTable.eSubType.FASHION_AURAS)
					{
						data.FashionWearSlotType = EFashionWearSlotType.Auras;
					}
					else
					{
						data.FashionWearSlotType = (EFashionWearSlotType)(tableItem.SubType - 10);
					}
					ItemDataManager._CreateFashionAttributeItems(data);
				}
				data.DeadTimestamp = tableItem.ExpireTime;
				data.Count = 0;
				data.MaxStackCount = tableItem.MaxNum;
				data.Quality = tableItem.Color;
				data.Quality2 = tableItem.Color2;
				data.SubQuality = 100;
				data.BindAttr = tableItem.Owner;
				data.Packing = tableItem.IsSeal;
				data.iPackedTimes = 0;
				data.iMaxPackTime = tableItem.SealMax;
				data.RePackTime = data.iMaxPackTime - data.iPackedTimes;
				data.LevelLimit = tableItem.NeedLevel;
				data.MaxLevelLimit = tableItem.MaxLevel;
				data.OccupationLimit = new List<int>(tableItem.Occu);
				ItemDataManager._UpdateQccupationLimit(data.OccupationLimit);
				data.UseType = tableItem.CanUse;
				data.CanSell = tableItem.CanTrade;
				data.CD = tableItem.CoolTime;
				data.CDGroupID = tableItem.CdGroup;
				data.useLimitType = tableItem.UseLimiteType;
				data.useLimitValue = tableItem.UseLimiteValue;
				data.FixTimeLeft = tableItem.TimeLeft;
				if (data.SubType == 25)
				{
					data.mPrecEnchantmentCard = new PrecEnchantmentCard
					{
						iEnchantmentCardID = data.TableID,
						iEnchantmentCardLevel = 0
					};
				}
				else
				{
					data.mPrecEnchantmentCard = new PrecEnchantmentCard
					{
						iEnchantmentCardID = 0,
						iEnchantmentCardLevel = 0
					};
				}
				data.Price = tableItem.Price;
				data.PriceItemID = tableItem.SellItemID;
				data.StrengthenLevel = 0;
				data.CanDecompose = tableItem.IsDecompose;
				data.SuitID = tableItem.SuitID;
				data.PackID = tableItem.PackageID;
				data.BaseAttackSpeedRate = tableItem.BaseAttackSpeedRate;
				if (tableItem.Type != ItemTable.eType.FASHION)
				{
					EquipProp equipProp = EquipProp.CreateFromTable(tableItem.EquipPropID);
					if (equipProp != null)
					{
						data.BaseProp = equipProp;
					}
				}
				else
				{
					FashionAttributesConfigTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FashionAttributesConfigTable>(tableItem.EquipPropID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						data.FashionBaseAttributeID = tableItem2.DefaultAttribute_1;
						data.FashionAttributeID = tableItem2.DefaultAttribute;
					}
				}
				if (tableItem.RenewInfo != null && tableItem.RenewInfo.Count > 0)
				{
					data.arrRenewals = new List<RenewalInfo>();
					for (int i = 0; i < tableItem.RenewInfo.Count; i++)
					{
						if (!string.IsNullOrEmpty(tableItem.RenewInfo[i]))
						{
							string[] array = tableItem.RenewInfo[i].Split(new char[]
							{
								','
							});
							RenewalInfo renewalInfo = new RenewalInfo();
							renewalInfo.nDay = int.Parse(array[0]);
							renewalInfo.nCostID = int.Parse(array[1]);
							renewalInfo.nCostCount = int.Parse(array[2]);
							data.arrRenewals.Add(renewalInfo);
						}
					}
				}
				data.IsSelected = false;
				data.IsNew = false;
				data.IsTableDataInited = true;
			}
		}

		// Token: 0x0600B6CC RID: 46796 RVA: 0x0029771B File Offset: 0x00295B1B
		private static void _UpdateQccupationLimit(List<int> occupationLimit)
		{
			occupationLimit.RemoveAll((int data) => data == 0);
		}

		// Token: 0x0600B6CD RID: 46797 RVA: 0x00297744 File Offset: 0x00295B44
		private static void _GetToJobs(ref List<int> toJobList, int job)
		{
			if (job <= 0)
			{
				return;
			}
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(job, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			for (int i = 0; i < tableItem.ToJob.Count; i++)
			{
				int num = tableItem.ToJob[i];
				if (num > 0 && !toJobList.Contains(num))
				{
					toJobList.Add(num);
					ItemDataManager._GetToJobs(ref toJobList, num);
				}
			}
		}

		// Token: 0x0600B6CE RID: 46798 RVA: 0x002977C4 File Offset: 0x00295BC4
		private void _BindNetMessage()
		{
			NetProcess.AddMsgHandler(500974U, new Action<MsgDATA>(this._OnRecvSceneSellItemBatRes));
			NetProcess.AddMsgHandler(500905U, new Action<MsgDATA>(this._OnAddItem));
			NetProcess.AddMsgHandler(500907U, new Action<MsgDATA>(this._OnRemoveItem));
			NetProcess.AddMsgHandler(500906U, new Action<MsgDATA>(this._OnUpdateItem));
			NetProcess.AddMsgHandler(500916U, new Action<MsgDATA>(this._OnNotifyGetItem));
			NetProcess.AddMsgHandler(500949U, new Action<MsgDATA>(this._OnNotifyCostItem));
			NetProcess.AddMsgHandler(500968U, new Action<MsgDATA>(this._OnSCNotifyTimeItem));
		}

		// Token: 0x0600B6CF RID: 46799 RVA: 0x0029786C File Offset: 0x00295C6C
		private void _UnBindNetMessage()
		{
			NetProcess.RemoveMsgHandler(500974U, new Action<MsgDATA>(this._OnRecvSceneSellItemBatRes));
			NetProcess.RemoveMsgHandler(500905U, new Action<MsgDATA>(this._OnAddItem));
			NetProcess.RemoveMsgHandler(500907U, new Action<MsgDATA>(this._OnRemoveItem));
			NetProcess.RemoveMsgHandler(500906U, new Action<MsgDATA>(this._OnUpdateItem));
			NetProcess.RemoveMsgHandler(500916U, new Action<MsgDATA>(this._OnNotifyGetItem));
			NetProcess.RemoveMsgHandler(500949U, new Action<MsgDATA>(this._OnNotifyCostItem));
			NetProcess.RemoveMsgHandler(500968U, new Action<MsgDATA>(this._OnSCNotifyTimeItem));
		}

		// Token: 0x0600B6D0 RID: 46800 RVA: 0x00297914 File Offset: 0x00295D14
		private void _InitMoneyTableData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ItemTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ItemTable itemTable = keyValuePair.Value as ItemTable;
					if (itemTable.Type == ItemTable.eType.INCOME)
					{
						this.m_commonTableItemDict.Add(itemTable.ID, ItemDataManager.CreateItemDataFromTable(itemTable.ID, 100, 0));
						if (!this.m_moneyTypeIDDict.ContainsKey(itemTable.SubType))
						{
							this.m_moneyTypeIDDict.Add(itemTable.SubType, itemTable.ID);
						}
					}
					else if (itemTable.Type == ItemTable.eType.EQUIP || itemTable.Type == ItemTable.eType.EXPENDABLE || itemTable.Type == ItemTable.eType.MATERIAL || itemTable.Type == ItemTable.eType.FUCKTITTLE)
					{
						if (this.TradeItemStateFliter(itemTable))
						{
							ItemTable.eType key = itemTable.Type;
							if (itemTable.Type == ItemTable.eType.FUCKTITTLE)
							{
								key = ItemTable.eType.EQUIP;
							}
							Dictionary<ItemTable.eSubType, List<int>> dictionary = null;
							if (!this.m_AuctionMainTypeIDDict.TryGetValue(key, out dictionary))
							{
								dictionary = new Dictionary<ItemTable.eSubType, List<int>>(new EItemSubComparer());
								List<int> list = new List<int>();
								list.Add(itemTable.ID);
								dictionary.Add(itemTable.SubType, list);
								this.m_AuctionMainTypeIDDict.Add(key, dictionary);
							}
							else
							{
								List<int> list2 = null;
								if (!dictionary.TryGetValue(itemTable.SubType, out list2))
								{
									list2 = new List<int>();
									list2.Add(itemTable.ID);
									dictionary.Add(itemTable.SubType, list2);
								}
								else
								{
									list2.Add(itemTable.ID);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600B6D1 RID: 46801 RVA: 0x00297ABF File Offset: 0x00295EBF
		private void _NotifyItemUseSuccess(ItemData a_item)
		{
			if (!this._TryNotifyMagicJarUseSuccess(a_item))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemUseSuccess, a_item, null, null, null);
			}
		}

		// Token: 0x0600B6D2 RID: 46802 RVA: 0x00297AE0 File Offset: 0x00295EE0
		private bool _TryNotifyMagicJarUseSuccess(ItemData a_item)
		{
			return false;
		}

		// Token: 0x0600B6D3 RID: 46803 RVA: 0x00297AE4 File Offset: 0x00295EE4
		private void _OnPackageItemEquiped(ItemData pre, ItemData aft)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				return;
			}
			List<BetterEquipmentData> list = this._GetEquipmentPropChanges(pre, aft);
			if (list != null)
			{
				this.PopUpChangedAttrbutes(list);
			}
		}

		// Token: 0x0600B6D4 RID: 46804 RVA: 0x00297B20 File Offset: 0x00295F20
		public EquipProp _GetSuitProp(EPackageType eEPackageType, ItemData pre, ItemData aft, bool bUsePre)
		{
			List<ulong> list = new List<ulong>();
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(eEPackageType);
			if (itemsByPackageType != null)
			{
				list.AddRange(itemsByPackageType);
			}
			if (list != null)
			{
				if (bUsePre && aft != null)
				{
					list.RemoveAll((ulong x) => aft.GUID == x);
				}
				if (!bUsePre && pre != null)
				{
					list.RemoveAll((ulong x) => pre.GUID == x);
				}
				if (bUsePre && pre != null && ((pre.Type == ItemTable.eType.FASHION && eEPackageType == EPackageType.WearFashion) || (pre.Type == ItemTable.eType.EQUIP && eEPackageType == EPackageType.WearEquip)))
				{
					list.RemoveAll((ulong x) => pre.GUID == x);
					list.Add(pre.GUID);
				}
				if (!bUsePre && aft != null && ((aft.Type == ItemTable.eType.FASHION && eEPackageType == EPackageType.WearFashion) || (aft.Type == ItemTable.eType.EQUIP && eEPackageType == EPackageType.WearEquip)))
				{
					list.RemoveAll((ulong x) => aft.GUID == x);
					list.Add(aft.GUID);
				}
			}
			List<int> list2 = ListPool<int>.Get();
			for (int i = 0; i < list.Count; i++)
			{
				ItemData item = this.GetItem(list[i]);
				if (item != null)
				{
					list2.Add(item.TableID);
				}
			}
			EquipProp equipProp = DataManager<EquipSuitDataManager>.GetInstance().GetEquipSuitBasePropByIDs(list2);
			ListPool<int>.Release(list2);
			if (equipProp == null)
			{
				equipProp = new EquipProp();
			}
			return equipProp;
		}

		// Token: 0x0600B6D5 RID: 46805 RVA: 0x00297CE4 File Offset: 0x002960E4
		private List<BetterEquipmentData> _GetEquipmentPropChanges(ItemData pre, ItemData aft)
		{
			List<BetterEquipmentData> list = new List<BetterEquipmentData>();
			EquipProp equipProp = (aft != null) ? aft.GetEquipProp() : new EquipProp();
			equipProp += this._GetSuitProp(EPackageType.WearEquip, pre, aft, false);
			equipProp += this._GetSuitProp(EPackageType.WearFashion, pre, aft, false);
			equipProp.props[22] = equipProp.magicElementsAttack[1];
			equipProp.props[23] = equipProp.magicElementsAttack[2];
			equipProp.props[24] = equipProp.magicElementsAttack[3];
			equipProp.props[25] = equipProp.magicElementsAttack[4];
			equipProp.props[26] = equipProp.magicElementsDefence[1];
			equipProp.props[27] = equipProp.magicElementsDefence[2];
			equipProp.props[28] = equipProp.magicElementsDefence[3];
			equipProp.props[29] = equipProp.magicElementsDefence[4];
			equipProp.props[45] = equipProp.abnormalResists[0];
			equipProp.props[46] = equipProp.abnormalResists[1];
			equipProp.props[47] = equipProp.abnormalResists[2];
			equipProp.props[48] = equipProp.abnormalResists[3];
			equipProp.props[49] = equipProp.abnormalResists[4];
			equipProp.props[50] = equipProp.abnormalResists[5];
			equipProp.props[51] = equipProp.abnormalResists[6];
			equipProp.props[52] = equipProp.abnormalResists[7];
			equipProp.props[53] = equipProp.abnormalResists[8];
			equipProp.props[54] = equipProp.abnormalResists[9];
			equipProp.props[55] = equipProp.abnormalResists[10];
			equipProp.props[56] = equipProp.abnormalResists[11];
			equipProp.props[57] = equipProp.abnormalResists[12];
			EquipProp equipProp2 = (pre != null) ? pre.GetEquipProp() : new EquipProp();
			equipProp2 += this._GetSuitProp(EPackageType.WearEquip, pre, aft, true);
			equipProp2 += this._GetSuitProp(EPackageType.WearFashion, pre, aft, true);
			equipProp2.props[22] = equipProp2.magicElementsAttack[1];
			equipProp2.props[23] = equipProp2.magicElementsAttack[2];
			equipProp2.props[24] = equipProp2.magicElementsAttack[3];
			equipProp2.props[25] = equipProp2.magicElementsAttack[4];
			equipProp2.props[26] = equipProp2.magicElementsDefence[1];
			equipProp2.props[27] = equipProp2.magicElementsDefence[2];
			equipProp2.props[28] = equipProp2.magicElementsDefence[3];
			equipProp2.props[29] = equipProp2.magicElementsDefence[4];
			equipProp2.props[45] = equipProp2.abnormalResists[0];
			equipProp2.props[46] = equipProp2.abnormalResists[1];
			equipProp2.props[47] = equipProp2.abnormalResists[2];
			equipProp2.props[48] = equipProp2.abnormalResists[3];
			equipProp2.props[49] = equipProp2.abnormalResists[4];
			equipProp2.props[50] = equipProp2.abnormalResists[5];
			equipProp2.props[51] = equipProp2.abnormalResists[6];
			equipProp2.props[52] = equipProp2.abnormalResists[7];
			equipProp2.props[53] = equipProp2.abnormalResists[8];
			equipProp2.props[54] = equipProp2.abnormalResists[9];
			equipProp2.props[55] = equipProp2.abnormalResists[10];
			equipProp2.props[56] = equipProp2.abnormalResists[11];
			equipProp2.props[57] = equipProp2.abnormalResists[12];
			for (int i = 0; i < equipProp.props.Length; i++)
			{
				if (equipProp.props[i] != 0 || equipProp2.props[i] != 0)
				{
					PropAttribute enumAttribute = Utility.GetEnumAttribute<EEquipProp, PropAttribute>((EEquipProp)i);
					if (enumAttribute != null)
					{
						if (i != 60)
						{
							string desc = enumAttribute.desc;
							string name = desc;
							string curData = string.Empty;
							string preData = string.Empty;
							EquipmentDataState equipmentDataState;
							if ((i >= 16 && i <= 18) || (i >= 30 && i <= 33) || (i >= 8 && i <= 11) || i == 36)
							{
								float num = (float)Math.Round((double)((float)equipProp.props[i] / 10f), 1);
								curData = string.Format("{0}%", (float)equipProp.props[i] / 10f);
								preData = string.Format("{0}%", (float)equipProp2.props[i] / 10f);
								if (equipProp.props[i] / 10 > equipProp2.props[i] / 10)
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
								}
								else if (equipProp.props[i] / 10 < equipProp2.props[i] / 10)
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
								}
								else
								{
									equipmentDataState = EquipmentDataState.PROPERTY_NO_CHANGE;
								}
							}
							else if (i >= 4 && i <= 7)
							{
								float num = (float)Math.Round((double)((float)equipProp.props[i] / 1000f), 1);
								float num2 = (float)Math.Round((double)((float)equipProp2.props[i] / 1000f), 1);
								if (aft != null)
								{
									switch (aft.GrowthAttrType)
									{
									case EGrowthAttrType.GAT_STRENGTH:
										if (i == 4)
										{
											num += (float)aft.GrowthAttrNum;
										}
										break;
									case EGrowthAttrType.GAT_INTELLIGENCE:
										if (i == 5)
										{
											num += (float)aft.GrowthAttrNum;
										}
										break;
									case EGrowthAttrType.GAT_STAMINA:
										if (i == 7)
										{
											num += (float)aft.GrowthAttrNum;
										}
										break;
									case EGrowthAttrType.GAT_SPIRIT:
										if (i == 6)
										{
											num += (float)aft.GrowthAttrNum;
										}
										break;
									}
								}
								if (pre != null)
								{
									switch (pre.GrowthAttrType)
									{
									case EGrowthAttrType.GAT_STRENGTH:
										if (i == 4)
										{
											num2 += (float)pre.GrowthAttrNum;
										}
										break;
									case EGrowthAttrType.GAT_INTELLIGENCE:
										if (i == 5)
										{
											num2 += (float)pre.GrowthAttrNum;
										}
										break;
									case EGrowthAttrType.GAT_STAMINA:
										if (i == 7)
										{
											num2 += (float)pre.GrowthAttrNum;
										}
										break;
									case EGrowthAttrType.GAT_SPIRIT:
										if (i == 6)
										{
											num2 += (float)pre.GrowthAttrNum;
										}
										break;
									}
								}
								curData = string.Format("{0:F1}", num);
								preData = string.Format("{0:F1}", num2);
								if (num > num2)
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
								}
								else if (num < num2)
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
								}
								else
								{
									equipmentDataState = EquipmentDataState.PROPERTY_NO_CHANGE;
								}
							}
							else if (i == 59)
							{
								int num3 = (int)Math.Round((double)((float)equipProp.props[i] / 1000f), 1);
								int num4 = (int)Math.Round((double)((float)equipProp2.props[i] / 1000f), 1);
								num3 += (int)Math.Round((double)((float)equipProp.props[60] / 1000f), 1);
								num4 += (int)Math.Round((double)((float)equipProp2.props[60] / 1000f), 1);
								curData = string.Format("{0:F1}", num3);
								preData = string.Format("{0:F1}", num4);
								if (num3 > num4)
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
								}
								else if (num3 < num4)
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
								}
								else
								{
									equipmentDataState = EquipmentDataState.PROPERTY_NO_CHANGE;
								}
							}
							else
							{
								float num = (float)equipProp.props[i];
								curData = string.Format("{0}", equipProp.props[i]);
								preData = string.Format("{0}", equipProp2.props[i]);
								if (equipProp.props[i] > equipProp2.props[i])
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
								}
								else if (equipProp.props[i] < equipProp2.props[i])
								{
									if (!enumAttribute.bInverse)
									{
										equipmentDataState = EquipmentDataState.PROPERTY_DOWN;
									}
									else
									{
										equipmentDataState = EquipmentDataState.PROPERTY_UP;
									}
								}
								else
								{
									equipmentDataState = EquipmentDataState.PROPERTY_NO_CHANGE;
								}
							}
							if (equipmentDataState != EquipmentDataState.PROPERTY_NO_CHANGE)
							{
								list.Add(new BetterEquipmentData
								{
									CurData = curData,
									PreData = preData,
									name = name,
									DataState = equipmentDataState
								});
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B6D6 RID: 46806 RVA: 0x002988D4 File Offset: 0x00296CD4
		public void PopUpChangedAttrbutes(List<BetterEquipmentData> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				if (!string.Equals(data[i].PreData, data[i].CurData))
				{
					Match match = ItemDataManager.ms_equip_attr_change_reg.Match(data[i].PreData);
					Match match2 = ItemDataManager.ms_equip_attr_change_reg.Match(data[i].CurData);
					if (!string.IsNullOrEmpty(match.Groups[0].Value) && !string.IsNullOrEmpty(match2.Groups[0].Value))
					{
						float num = 0f;
						float num2 = 0f;
						if (float.TryParse(match.Groups[1].Value, out num) && float.TryParse(match2.Groups[1].Value, out num2))
						{
							float num3 = (float)Math.Round((double)(num2 - num), 1);
							string msgContent = string.Empty;
							if (num3 > 0f)
							{
								msgContent = string.Format("{0} +{1}{2}", data[i].name, Math.Abs(num3), match.Groups[2].Value);
							}
							else
							{
								msgContent = string.Format("{0} -{1}{2}", data[i].name, Math.Abs(num3), match2.Groups[2].Value);
							}
							SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						}
					}
				}
			}
		}

		// Token: 0x0600B6D7 RID: 46807 RVA: 0x00298A8C File Offset: 0x00296E8C
		private void _OnStrengthenLevelChanged(ItemData data)
		{
			if (data.EquipWearSlotType == EEquipWearSlotType.EquipWeapon)
			{
				ulong wearEquipBySlotType = this.GetWearEquipBySlotType(EEquipWearSlotType.EquipWeapon);
				if (wearEquipBySlotType > 0UL && data.GUID == wearEquipBySlotType)
				{
					ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemTown;
					if (clientSystemTown != null)
					{
						clientSystemTown.MainPlayer.ShowEquipStrengthenEffect(data.StrengthenLevel);
					}
				}
			}
		}

		// Token: 0x0600B6D8 RID: 46808 RVA: 0x00298AE8 File Offset: 0x00296EE8
		private bool _AddItem(ItemData data, bool isRealAddItemInLogic = true)
		{
			if (data != null && !this.m_itemsDict.ContainsKey(data.GUID))
			{
				this.m_itemsDict.Add(data.GUID, data);
				if (!this.m_itemPackageTypesDict.ContainsKey(data.PackageType))
				{
					this.m_itemPackageTypesDict.Add(data.PackageType, new List<ulong>());
				}
				this.m_itemPackageTypesDict[data.PackageType].Add(data.GUID);
				if (data.PackageType > EPackageType.Invalid && data.PackageType < EPackageType.Count && data.IsNew)
				{
					ushort[] packageHasNew = this.m_packageHasNew;
					EPackageType packageType = data.PackageType;
					packageHasNew[(int)packageType] = packageHasNew[(int)packageType] + 1;
					this._NotifyItemNewStateChanged();
				}
				if (!this.m_itemTypesDict.ContainsKey(data.Type))
				{
					this.m_itemTypesDict.Add(data.Type, new List<ulong>());
				}
				this.m_itemTypesDict[data.Type].Add(data.GUID);
				if (!this.m_itemCDGroupDict.ContainsKey(data.CDGroupID))
				{
					this.m_itemCDGroupDict.Add(data.CDGroupID, new List<ulong>());
				}
				this.m_itemCDGroupDict[data.CDGroupID].Add(data.GUID);
				if (data.PackageType != EPackageType.Storage && data.Type != ItemTable.eType.INCOME && data.PackageType != EPackageType.RoleStorage)
				{
					int num = 0;
					if (this.m_ItemNumDict.TryGetValue(data.TableID, out num))
					{
						this.m_ItemNumDict[data.TableID] = num + data.Count;
					}
					else
					{
						this.m_ItemNumDict.Add(data.TableID, data.Count);
					}
				}
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
				if (clientSystemGameBattle != null)
				{
					CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.SceneType == CitySceneTable.eSceneType.BATTLE && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Battle && !DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare)
					{
						if (data.TableData.Type == ItemTable.eType.EXPENDABLE && data.TableData.SubType == ItemTable.eSubType.GiftPackage)
						{
							this._AutoUseChijiItem(data, isRealAddItemInLogic);
						}
						else if (data.TableData.Type == ItemTable.eType.EQUIP)
						{
							this._AutoEquipChijiEquipment(data, isRealAddItemInLogic);
						}
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600B6D9 RID: 46809 RVA: 0x00298D5C File Offset: 0x0029715C
		private bool _RemoveItem(ulong guid)
		{
			ItemData itemData = null;
			this.m_itemsDict.TryGetValue(guid, out itemData);
			if (itemData != null)
			{
				if (itemData.PackageType > EPackageType.Invalid && itemData.PackageType < EPackageType.Count && itemData.IsNew)
				{
					ushort[] packageHasNew = this.m_packageHasNew;
					EPackageType packageType = itemData.PackageType;
					packageHasNew[(int)packageType] = packageHasNew[(int)packageType] - 1;
					this._NotifyItemNewStateChanged();
				}
				if (itemData.PackageType != EPackageType.Storage && itemData.Type != ItemTable.eType.INCOME && itemData.PackageType != EPackageType.RoleStorage)
				{
					int num = 0;
					if (this.m_ItemNumDict.TryGetValue(itemData.TableID, out num))
					{
						num -= itemData.Count;
						this.m_ItemNumDict[itemData.TableID] = num;
					}
				}
				this.m_itemsDict.Remove(guid);
				this.m_itemPackageTypesDict[itemData.PackageType].Remove(guid);
				this.m_itemTypesDict[itemData.Type].Remove(guid);
				this.m_itemCDGroupDict[itemData.CDGroupID].Remove(guid);
				return true;
			}
			return false;
		}

		// Token: 0x0600B6DA RID: 46810 RVA: 0x00298E73 File Offset: 0x00297273
		private void _NotifyItemCountChanged(int a_nTableID)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemCountChanged, a_nTableID, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
		}

		// Token: 0x0600B6DB RID: 46811 RVA: 0x00298E98 File Offset: 0x00297298
		private void _NotifyItemNewStateChanged()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemNewStateChanged, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
		}

		// Token: 0x0600B6DC RID: 46812 RVA: 0x00298EB8 File Offset: 0x002972B8
		private void _OnAddItem(MsgDATA msg)
		{
			int num = 0;
			List<Item> list = ItemDecoder.Decode(msg.bytes, ref num, msg.bytes.Length, false);
			byte b = 0;
			if (num < msg.bytes.Length)
			{
				BaseDLL.decode_int8(msg.bytes, ref num, ref b);
			}
			for (int i = 0; i < list.Count; i++)
			{
				ItemData itemData = this.CreateItemDataFromNet(list[i]);
				if (itemData != null)
				{
					itemData.IsNew = (b == 0);
					this._AddItem(itemData, true);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnlyUpdateItemList, null, null, null, null);
					this._NotifyItemCountChanged(itemData.TableID);
					if (itemData.DeadTimestamp > 0)
					{
						uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
						int num2 = itemData.DeadTimestamp - (int)serverTime;
						if (num2 <= 86400)
						{
							DeadLineReminderModel model = new DeadLineReminderModel
							{
								type = DeadLineReminderType.DRT_LIMITTIMEITEM,
								itemData = itemData
							};
							if (DataManager<DeadLineReminderDataManager>.GetInstance() != null)
							{
								DataManager<DeadLineReminderDataManager>.GetInstance().Add(model);
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
						}
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnItemInPackageAddedMessage, itemData.GUID, itemData.TableID, null, null);
				}
				else
				{
					Logger.LogErrorFormat("item data tableid = {0} cannot find in itemtable!", new object[]
					{
						list[i].dataid
					});
				}
			}
			if (b != 0)
			{
				DataManager<EquipSuitDataManager>.GetInstance().InitSelfEquipSuits();
				DataManager<EquipHandbookDataManager>.GetInstance().InitSelfEquipData();
				DataManager<EquipUpgradeDataManager>.GetInstance().InitEquipUpgradeTable();
			}
			this.NotifyPackageFullState();
			this._OnAddItem(list);
		}

		// Token: 0x0600B6DD RID: 46813 RVA: 0x0029905C File Offset: 0x0029745C
		private void _OnRemoveItem(MsgDATA msg)
		{
			SceneNotifyDeleteItem sceneNotifyDeleteItem = new SceneNotifyDeleteItem();
			sceneNotifyDeleteItem.decode(msg.bytes);
			ItemData item = this.GetItem(sceneNotifyDeleteItem.uid);
			this._RemoveItem(sceneNotifyDeleteItem.uid);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnlyUpdateItemList, null, null, null, null);
			if (item == null)
			{
				return;
			}
			if (this.onRemoveItem != null && item != null)
			{
				this.onRemoveItem(item);
			}
			this.m_akNeedPopEquips = this.OnFilter(this.m_akNeedPopEquips, false);
			this._RemoveLowScoreEquips(this.m_akNeedPopEquips);
			if (this.onNeedPopEquipsChanged != null)
			{
				this.onNeedPopEquipsChanged(this.m_akNeedPopEquips);
			}
			if (item.PackageType == EPackageType.WearEquip || item.PackageType == EPackageType.WearFashion)
			{
				DataManager<EquipSuitDataManager>.GetInstance().UpdateSelfEquipSuits(item, false);
			}
			if (item.PackageType == EPackageType.EquipRecovery)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipRecivertDeleteItem, null, null, null, null);
			}
			this.NotifyPackageFullState();
			this._NotifyItemCountChanged(item.TableID);
			if (DataManager<DeadLineReminderDataManager>.GetInstance() != null)
			{
				DataManager<DeadLineReminderDataManager>.GetInstance().RemoveAll(item.GUID);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnItemInPackageRemovedMessage, sceneNotifyDeleteItem.uid, null, null, null);
		}

		// Token: 0x0600B6DE RID: 46814 RVA: 0x002991A8 File Offset: 0x002975A8
		private void _OnUpdateItem(MsgDATA msg)
		{
			List<ItemData> list = new List<ItemData>();
			int num = 0;
			List<Item> list2 = ItemDecoder.Decode(msg.bytes, ref num, msg.bytes.Length, true);
			bool flag = false;
			for (int i = 0; i < list2.Count; i++)
			{
				Item item = list2[i];
				ItemData item2 = this.GetItem(item.uid);
				if (item2 != null)
				{
					ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
					if (clientSystemGameBattle != null)
					{
						item.tableID = (uint)item2.TableID;
					}
					list.Add(item2);
					int j = 0;
					while (j < item.dirtyFields.Count)
					{
						EItemProperty eitemProperty = (EItemProperty)item.dirtyFields[j];
						switch (eitemProperty)
						{
						case EItemProperty.EP_NUM:
						{
							bool flag2 = false;
							if (item2.PackageType != EPackageType.Storage && item2.Type != ItemTable.eType.INCOME && item2.PackageType != EPackageType.RoleStorage)
							{
								int num2 = 0;
								if (this.m_ItemNumDict.TryGetValue(item2.TableID, out num2))
								{
									if ((int)item.num > item2.Count)
									{
										Dictionary<int, int> itemNumDict;
										int tableID;
										(itemNumDict = this.m_ItemNumDict)[tableID = item2.TableID] = itemNumDict[tableID] + ((int)item.num - item2.Count);
										flag2 = true;
									}
									else
									{
										Dictionary<int, int> itemNumDict;
										int tableID2;
										(itemNumDict = this.m_ItemNumDict)[tableID2 = item2.TableID] = itemNumDict[tableID2] - (item2.Count - (int)item.num);
									}
								}
								else
								{
									this.m_ItemNumDict.Add(item2.TableID, (int)item.num);
								}
							}
							if ((int)item.num > item2.Count)
							{
								this.NotifyItemBeNew(item2);
							}
							item2.Count = (int)item.num;
							this._NotifyItemCountChanged(item2.TableID);
							ClientSystemGameBattle clientSystemGameBattle2 = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
							if (clientSystemGameBattle2 != null)
							{
								CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemGameBattle2.CurrentSceneID, string.Empty, string.Empty);
								if (tableItem != null && tableItem.SceneType == CitySceneTable.eSceneType.BATTLE && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Battle && !DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare && item2.TableData.Type == ItemTable.eType.EXPENDABLE && item2.TableData.SubType == ItemTable.eSubType.GiftPackage && flag2)
								{
									this._AutoUseChijiItem(item2, true);
								}
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemPropertyChanged, item2, eitemProperty, null, null);
							break;
						}
						case EItemProperty.EP_BIND:
						case EItemProperty.EP_QUALITY:
						case EItemProperty.EP_RANDATTR:
						case EItemProperty.EP_PARAM2:
						case EItemProperty.EP_POWER:
						case EItemProperty.EP_PRICE:
						case EItemProperty.EP_STRFAILED:
						case (EItemProperty)31:
						case (EItemProperty)32:
						case (EItemProperty)33:
						case (EItemProperty)34:
						case (EItemProperty)36:
						case EItemProperty.EP_AUCTION_COOL_TIMESTAMP:
						case EItemProperty.EP_ENHANCE_FAILED:
							goto IL_1106;
						case EItemProperty.EP_PACK:
						{
							flag = true;
							EPackageType packageType = item2.PackageType;
							this._RemoveItem(item2.GUID);
							item2.PackageType = (EPackageType)item.pack;
							this._AddItem(item2, false);
							if (item2.PackageType == EPackageType.WearEquip || item2.PackageType == EPackageType.WearFashion)
							{
								DataManager<EquipSuitDataManager>.GetInstance().UpdateSelfEquipSuits(item2, true);
							}
							else if ((item2.PackageType == EPackageType.Equip || item2.PackageType == EPackageType.Fashion) && (packageType == EPackageType.WearEquip || packageType == EPackageType.WearFashion))
							{
								DataManager<EquipSuitDataManager>.GetInstance().UpdateSelfEquipSuits(item2, false);
							}
							item2.IsItemInUnUsedEquipPlan = EquipPlanUtility.IsItemInUnUsedEquipPlanByItemData(item2);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemCountChanged, item2.TableID, null, null, null);
							break;
						}
						case EItemProperty.EP_GRID:
							item2.GridIndex = (int)item.grid;
							break;
						case EItemProperty.EP_PHY_ATK:
							item2.BaseProp.props[0] = (int)item.phyatk;
							break;
						case EItemProperty.EP_MAG_ATK:
							item2.BaseProp.props[1] = (int)item.magatk;
							break;
						case EItemProperty.EP_PHY_DEF:
							item2.BaseProp.props[2] = (int)item.phydef;
							break;
						case EItemProperty.EP_MAG_DEF:
							item2.BaseProp.props[3] = (int)item.magdef;
							break;
						case EItemProperty.EP_STR:
							item2.BaseProp.props[4] = (int)item.strenth;
							break;
						case EItemProperty.EP_STAMINA:
							item2.BaseProp.props[7] = (int)item.stamina;
							break;
						case EItemProperty.EP_INTELLECT:
							item2.BaseProp.props[5] = (int)item.intellect;
							break;
						case EItemProperty.EP_SPIRIT:
							item2.BaseProp.props[6] = (int)item.spirit;
							break;
						case EItemProperty.EP_QUALITYLV:
							item2.SubQuality = (int)item.qualitylv;
							break;
						case EItemProperty.EP_STRENGTHEN:
							item2.StrengthenLevel = (int)item.strengthen;
							this._OnStrengthenLevelChanged(item2);
							if (item2.SubType == 25)
							{
								item2.mPrecEnchantmentCard = new PrecEnchantmentCard
								{
									iEnchantmentCardID = item2.TableID,
									iEnchantmentCardLevel = (int)item.strengthen
								};
							}
							break;
						case EItemProperty.EP_DAYUSENUM:
							break;
						case EItemProperty.EP_ADDMAGIC:
							if (item.mountedMagic != null)
							{
								item2.mPrecEnchantmentCard = this.SwichPrecEnchantmentCard(item.mountedMagic);
							}
							break;
						case EItemProperty.EP_PARAM1:
							break;
						case EItemProperty.EP_DEADLINE:
							item2.DeadTimestamp = (int)item.deadLine;
							if (DataManager<DeadLineReminderDataManager>.GetInstance() != null)
							{
								DataManager<DeadLineReminderDataManager>.GetInstance().RemoveAll(item2.GUID);
							}
							if (item2.DeadTimestamp > 0)
							{
								uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
								int num3 = item2.DeadTimestamp - (int)serverTime;
								if (num3 <= 86400)
								{
									DeadLineReminderModel model = new DeadLineReminderModel
									{
										type = DeadLineReminderType.DRT_LIMITTIMEITEM,
										itemData = item2
									};
									if (DataManager<DeadLineReminderDataManager>.GetInstance() != null)
									{
										DataManager<DeadLineReminderDataManager>.GetInstance().Add(model);
									}
								}
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DeadLineReminderChanged, null, null, null, null);
							break;
						case EItemProperty.EP_SEAL_STATE:
							item2.Packing = (item.sealstate == 1);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemPropertyChanged, item2, eitemProperty, null, null);
							break;
						case EItemProperty.EP_SEAL_COUNT:
							item2.iPackedTimes = (int)item.sealcount;
							item2.RePackTime = item2.iMaxPackTime - item2.iPackedTimes;
							break;
						case EItemProperty.EP_DIS_PHYATK:
							item2.BaseProp.props[39] = (int)item.disPhyAtk;
							break;
						case EItemProperty.EP_DIS_MAGATK:
							item2.BaseProp.props[40] = (int)item.disMagAtk;
							break;
						case EItemProperty.EP_DIS_PHYDEF:
							item2.BaseProp.props[43] = (int)item.disPhyDef;
							break;
						case EItemProperty.EP_DIS_MAGDEF:
							item2.BaseProp.props[44] = (int)item.disMagDef;
							break;
						case EItemProperty.EP_VALUE_SCORE:
							item2.finalRateScore = (int)item.valueScore;
							break;
						case EItemProperty.EP_IA_FASHION_ATTRID:
							if (item2.Type == ItemTable.eType.FASHION)
							{
								EquipProp equipProp = EquipProp.CreateFromTable(item2.FashionAttributeID);
								if (equipProp != null && item2.BaseProp != null)
								{
									item2.BaseProp -= equipProp;
								}
								EquipProp equipProp2 = EquipProp.CreateFromTable((int)item.fashionAttributeID);
								if (equipProp2 != null && item2.BaseProp != null)
								{
									item2.BaseProp += equipProp2;
								}
							}
							item2.FashionAttributeID = (int)item.fashionAttributeID;
							break;
						case EItemProperty.EP_FASHION_ATTR_SELNUM:
							item2.FashionFreeTimes = (int)item.fashionFreeSelNum;
							break;
						case EItemProperty.EP_PHYDEF_PERCENT:
							item2.BaseProp.props[41] = (int)item.disPhyDefRate;
							break;
						case EItemProperty.EP_MAGDEF_PERCENT:
							item2.BaseProp.props[42] = (int)item.disMagDefRate;
							break;
						case EItemProperty.EP_ADDBEAD:
							item2.PreciousBeadMountHole = this.SwitchPrecBead(item.preciousBeadHoles);
							break;
						case EItemProperty.EP_STRPROP_LIGHT:
							item2.BaseProp.magicElementsAttack[1] = (int)item.strPropLight;
							break;
						case EItemProperty.EP_STRPROP_FIRE:
							item2.BaseProp.magicElementsAttack[2] = (int)item.strPropFire;
							break;
						case EItemProperty.EP_STRPROP_ICE:
							item2.BaseProp.magicElementsAttack[3] = (int)item.strPropIce;
							break;
						case EItemProperty.EP_STRPROP_DARK:
							item2.BaseProp.magicElementsAttack[4] = (int)item.strPropDark;
							break;
						case EItemProperty.EP_DEFPROP_LIGHT:
							item2.BaseProp.magicElementsDefence[1] = (int)item.defPropLight;
							break;
						case EItemProperty.EP_DEFPROP_FIRE:
							item2.BaseProp.magicElementsDefence[2] = (int)item.defPropFire;
							break;
						case EItemProperty.EP_DEFPROP_ICE:
							item2.BaseProp.magicElementsDefence[3] = (int)item.defPropIce;
							break;
						case EItemProperty.EP_DEFPROP_DARK:
							item2.BaseProp.magicElementsDefence[4] = (int)item.defPropDark;
							break;
						case EItemProperty.EP_ABNORMAL_RESISTS_TOTAL:
							item2.BaseProp.props[19] = (int)item.abnormalResistsTotal;
							break;
						case EItemProperty.EP_EAR_FLASH:
							item2.BaseProp.abnormalResists[0] = (int)item.abnormalResistFlash;
							break;
						case EItemProperty.EP_EAR_BLEEDING:
							item2.BaseProp.abnormalResists[1] = (int)item.abnormalResistBleeding;
							break;
						case EItemProperty.EP_EAR_BURN:
							item2.BaseProp.abnormalResists[2] = (int)item.abnormalResistBurn;
							break;
						case EItemProperty.EP_EAR_POISON:
							item2.BaseProp.abnormalResists[3] = (int)item.abnormalResistPoison;
							break;
						case EItemProperty.EP_EAR_BLIND:
							item2.BaseProp.abnormalResists[4] = (int)item.abnormalResistBlind;
							break;
						case EItemProperty.EP_EAR_STUN:
							item2.BaseProp.abnormalResists[5] = (int)item.abnormalResistStun;
							break;
						case EItemProperty.EP_EAR_STONE:
							item2.BaseProp.abnormalResists[6] = (int)item.abnormalResistStone;
							break;
						case EItemProperty.EP_EAR_FROZEN:
							item2.BaseProp.abnormalResists[7] = (int)item.abnormalResistFrozen;
							break;
						case EItemProperty.EP_EAR_SLEEP:
							item2.BaseProp.abnormalResists[8] = (int)item.abnormalResistSleep;
							break;
						case EItemProperty.EP_EAR_CONFUNSE:
							item2.BaseProp.abnormalResists[9] = (int)item.abnormalResistConfunse;
							break;
						case EItemProperty.EP_EAR_STRAIN:
							item2.BaseProp.abnormalResists[10] = (int)item.abnormalResistStrain;
							break;
						case EItemProperty.EP_EAR_SPEED_DOWN:
							item2.BaseProp.abnormalResists[11] = (int)item.abnormalResistSpeedDown;
							break;
						case EItemProperty.EP_EAR_CURSE:
							item2.BaseProp.abnormalResists[12] = (int)item.abnormalResistCurse;
							break;
						case EItemProperty.EP_TRANSFER_STONE:
							item2.TransferStone = (int)item.transferStone;
							break;
						case EItemProperty.EP_RECO_SCORE:
							item2.RecoScore = (int)item.recoScore;
							break;
						case EItemProperty.EP_LOCK_ITEM:
							item2.bLocked = ((item.lockItem & 1U) == 1U);
							item2.bFashionItemLocked = ((item.lockItem & 8U) == 8U);
							break;
						case EItemProperty.EP_PRECIOUSBEAD_HOLES:
							item2.PreciousBeadMountHole = this.SwitchPrecBead(item.preciousBeadHoles);
							break;
						case EItemProperty.EP_IS_TREAS:
							item2.IsTreasure = (item.isTreas == 1);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemPropertyChanged, item2, eitemProperty, null, null);
							break;
						case EItemProperty.EP_BEAD_EXTIRPE_CNT:
							item2.BeadPickNumber = (int)item.beadExtipreCnt;
							break;
						case EItemProperty.EP_BEAD_REPLACE_CNT:
							item2.BeadReplaceNumber = (int)item.beadReplaceCnt;
							break;
						case EItemProperty.EP_TABLE_ID:
						{
							if (item2.PackageType == EPackageType.WearEquip)
							{
								DataManager<EquipSuitDataManager>.GetInstance().UpdateSelfEquipSuits(item2, false);
							}
							item2.TableData = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)item.tableID, string.Empty, string.Empty);
							item2.Name = item2.TableData.Name;
							item2.Price = item2.TableData.Price;
							item2.SuitID = item2.TableData.SuitID;
							item2.LevelLimit = item2.TableData.NeedLevel;
							if (item2.PackageType == EPackageType.WearEquip)
							{
								DataManager<EquipSuitDataManager>.GetInstance().UpdateSelfEquipSuits(item2, true);
							}
							EquipAttrTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(item2.TableData.EquipPropID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								item2.BaseProp.TableData = tableItem2;
								item2.BaseProp.props[8] = new CrypticInt32(tableItem2.PhySkillMp);
								item2.BaseProp.props[9] = new CrypticInt32(tableItem2.PhySkillCd);
								item2.BaseProp.props[10] = new CrypticInt32(tableItem2.MagSkillMp);
								item2.BaseProp.props[11] = new CrypticInt32(tableItem2.MagSkillCd);
								item2.BaseProp.props[12] = new CrypticInt32(tableItem2.HPMax);
								item2.BaseProp.props[13] = new CrypticInt32(tableItem2.MPMax);
								item2.BaseProp.props[14] = new CrypticInt32(tableItem2.HPRecover);
								item2.BaseProp.props[15] = new CrypticInt32(tableItem2.MPRecover);
								item2.BaseProp.props[16] = new CrypticInt32(tableItem2.AttackSpeedRate);
								item2.BaseProp.props[17] = new CrypticInt32(tableItem2.FireSpeedRate);
								item2.BaseProp.props[18] = new CrypticInt32(tableItem2.MoveSpeedRate);
								item2.BaseProp.props[30] = new CrypticInt32(tableItem2.HitRate);
								item2.BaseProp.props[31] = new CrypticInt32(tableItem2.AvoidRate);
								item2.BaseProp.props[32] = new CrypticInt32(tableItem2.PhysicCrit);
								item2.BaseProp.props[33] = new CrypticInt32(tableItem2.MagicCrit);
								item2.BaseProp.props[34] = new CrypticInt32(tableItem2.Spasticity);
								item2.BaseProp.props[35] = new CrypticInt32(tableItem2.Jump);
								item2.BaseProp.props[36] = new CrypticInt32(tableItem2.TownMoveSpeedRate);
								item2.BaseProp.props[58] = new CrypticInt32(tableItem2.ResistMagic);
								item2.BaseProp.attachBuffIDs = new List<int>(tableItem2.AttachBuffInfoIDs);
								item2.BaseProp.attachMechanismIDs = new List<int>(tableItem2.AttachMechanismIDs);
								item2.BaseProp.attachPVPBuffIDs = new List<int>(tableItem2.PVPAttachBuffInfoIDs);
								item2.BaseProp.attachPVPMechanismIDs = new List<int>(tableItem2.PVPAttachMechanismIDs);
							}
							break;
						}
						case EItemProperty.EP_EQUIP_TYPE:
							item2.EquipType = (EEquipType)item.equipType;
							break;
						case EItemProperty.EP_ENHANCE_TYPE:
							item2.GrowthAttrType = (EGrowthAttrType)item.enhanceType;
							break;
						case EItemProperty.EP_ENHANCE_NUM:
							item2.GrowthAttrNum = (int)item.enhanceNum;
							break;
						case EItemProperty.EA_AUCTION_TRANS_NUM:
							item2.ItemTradeNumber = (int)item.auctionTransNum;
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemPropertyChanged, item2, eitemProperty, null, null);
							break;
						case EItemProperty.EP_INSCRIPTION_HOLES:
							item2.InscriptionHoles = this.SwichInscriptionHoleData(item.inscriptionHoles, item2);
							break;
						case EItemProperty.EP_INDEPENDATK:
							item2.BaseProp.props[59] = (int)item.independAtk;
							break;
						case EItemProperty.EP_INDEPENDATK_STRENG:
							item2.BaseProp.props[60] = (int)item.independAtkStreng;
							break;
						case EItemProperty.EP_SUBTYPE:
							item2.SubType = (int)item.subtype;
							break;
						default:
							goto IL_1106;
						}
						IL_1140:
						j++;
						continue;
						IL_1106:
						if (eitemProperty.GetDescription(true) == null)
						{
							string text = " " + item.dirtyFields[j];
						}
						goto IL_1140;
					}
				}
			}
			if (flag)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemPropertyChanged, EItemProperty.EP_PACK, null, null, null);
				this.NotifyPackageFullState();
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Invalid);
			}
			if (list.Count > 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemsAttrChanged, list, null, null, null);
			}
			if (this.onUpdateItem != null)
			{
				this.onUpdateItem(list2);
			}
			this._OnUpdateItem(list2);
			if (this.bCalResistMagicValue)
			{
				this.SyncMainPlayerBaseDataByUpdateItem(list);
			}
		}

		// Token: 0x0600B6DF RID: 46815 RVA: 0x0029A3A0 File Offset: 0x002987A0
		private void _OnNotifyGetItem(MsgDATA msg)
		{
			if (DataManager<PlayerBaseData>.GetInstance().IsFlyUpState)
			{
				return;
			}
			try
			{
				int num = 0;
				uint num2 = 0U;
				byte b = 0;
				List<CustomDecoder.RewardItem> list = CustomDecoder.DecodeGetRewards(msg.bytes, ref num, msg.bytes.Length, ref num2, ref b);
				if (list != null)
				{
					Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ItemNotifyGetTable>();
					if (table == null)
					{
						Logger.LogError("TableManager.instance.GetTable<ItemNotifyGetTable>() failed");
					}
					else
					{
						Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
						bool flag = false;
						if (b == 0)
						{
							flag = true;
						}
						else
						{
							while (enumerator.MoveNext())
							{
								KeyValuePair<int, object> keyValuePair = enumerator.Current;
								ItemNotifyGetTable itemNotifyGetTable = keyValuePair.Value as ItemNotifyGetTable;
								if (itemNotifyGetTable != null && itemNotifyGetTable.ID == (int)num2)
								{
									flag = true;
									break;
								}
							}
						}
						if (!(Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemBattle))
						{
							bool flag2 = false;
							for (int i = 0; i < list.Count; i++)
							{
								ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)list[i].ID, string.Empty, string.Empty);
								if (tableItem != null)
								{
									if (tableItem.CanUse == ItemTable.eCanUse.UseOne || tableItem.CanUse == ItemTable.eCanUse.UseTotal)
									{
										flag2 = true;
									}
									if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemBattle))
									{
										if (!flag)
										{
											ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)list[i].ID, 100, 0);
											if (itemData != null)
											{
												itemData.Count = (int)list[i].Num;
												itemData.StrengthenLevel = (int)list[i].strength;
												itemData.EquipType = (EEquipType)list[i].equipType;
												ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
												if (clientSystemGameBattle != null)
												{
													if (itemData == null || itemData.ThirdType != ItemTable.eThirdType.ChijiGiftPackage)
													{
														string msgContent = string.Format("{0} * {1}", tableItem.Name, list[i].Num);
														SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, (int)list[i].ID);
													}
												}
												else
												{
													SystemNotifyManager.SysNotifyGetNewItemEffect(itemData, false, string.Empty);
												}
											}
											else
											{
												Logger.LogErrorFormat("CreateItemDataFromTable failed, id = {0}", new object[]
												{
													list[i].ID
												});
											}
										}
										else
										{
											string msgContent2 = string.Format("{0} * {1}", tableItem.Name, list[i].Num);
											SystemNotifyManager.SysNotifyFloatingEffect(msgContent2, CommonTipsDesc.eShowMode.SI_QUEUE, (int)list[i].ID);
										}
									}
									else
									{
										string msgContent3 = string.Format("{0} * {1}", tableItem.Name, list[i].Num);
										SystemNotifyManager.SysNotifyFloatingEffect(msgContent3, CommonTipsDesc.eShowMode.SI_QUEUE, (int)list[i].ID);
									}
								}
							}
							if (flag2)
							{
								this.TryOpenEquipmentChangedFrame();
							}
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemNotifyGet, null, null, null, null);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("_OnNotifyGetItem failed! Exception:" + ex.ToString());
			}
		}

		// Token: 0x0600B6E0 RID: 46816 RVA: 0x0029A718 File Offset: 0x00298B18
		private void _OnNotifyCostItem(MsgDATA msg)
		{
			SceneNotifyCostItem sceneNotifyCostItem = new SceneNotifyCostItem();
			sceneNotifyCostItem.decode(msg.bytes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemNotifyRemoved, sceneNotifyCostItem.itemid, sceneNotifyCostItem.num, null, null);
		}

		// Token: 0x0600B6E1 RID: 46817 RVA: 0x0029A760 File Offset: 0x00298B60
		private bool _TryRemoveFatigueDrug()
		{
			bool result = false;
			for (int i = 0; i < this.m_akNeedPopEquips.Count; i++)
			{
				ItemData item = this.GetItem(this.m_akNeedPopEquips[i]);
				if (item != null && item.SubType == 37 && (item.PackageType == EPackageType.Storage || item.PackageType == EPackageType.RoleStorage || item.GetCurrentRemainUseTime() <= 0 || DataManager<PlayerBaseData>.GetInstance().fatigue > 0))
				{
					this.m_akNeedPopEquips.RemoveAt(i--);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600B6E2 RID: 46818 RVA: 0x0029A7FE File Offset: 0x00298BFE
		private void _AutoUseChijiItem(ItemData item, bool isRealAddItemInLogic = true)
		{
			if (DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene)
			{
				return;
			}
			if (!isRealAddItemInLogic)
			{
				return;
			}
			this.UseItem(item, false, 0, 0);
		}

		// Token: 0x0600B6E3 RID: 46819 RVA: 0x0029A824 File Offset: 0x00298C24
		private void _AutoEquipChijiEquipment(ItemData item, bool isRealAddItemInLogic = true)
		{
			if (DataManager<ChijiDataManager>.GetInstance().SwitchingPrepareToChijiScene)
			{
				return;
			}
			if (!isRealAddItemInLogic)
			{
				return;
			}
			if (!this.IsItemJobAdaptToTargetJob(item.TableData, DataManager<PlayerBaseData>.GetInstance().JobTableID))
			{
				return;
			}
			List<ulong> itemsByPackageType = this.GetItemsByPackageType(EPackageType.WearEquip);
			bool flag = false;
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item2 = this.GetItem(itemsByPackageType[i]);
				if (item2 != null)
				{
					if (item2.EquipWearSlotType == item.EquipWearSlotType)
					{
						flag = true;
						if (item2.finalRateScore >= item.finalRateScore)
						{
							break;
						}
						this.UseItem(item, false, 0, 0);
						break;
					}
				}
			}
			if (!flag)
			{
				this.UseItem(item, false, 0, 0);
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("已自动穿戴 {0}", item.GetColorName(string.Empty, false)), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600B6E4 RID: 46820 RVA: 0x0029A910 File Offset: 0x00298D10
		public bool IsItemJobAdaptToTargetJob(ItemTable ItemData, int TargetJobId)
		{
			if (ItemData == null || ItemData.Occu == null || ItemData.Occu.Length < 1)
			{
				return false;
			}
			if (ItemData.Occu[0] == 0)
			{
				return true;
			}
			if (ItemData.Occu[0] == -1)
			{
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(TargetJobId, string.Empty, string.Empty);
				return tableItem != null && tableItem.JobType > 0;
			}
			bool flag = false;
			JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(ItemData.Occu[0], string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return false;
			}
			if (tableItem2.JobType == 0)
			{
				flag = true;
			}
			if (flag)
			{
				JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(TargetJobId, string.Empty, string.Empty);
				if (tableItem3 == null)
				{
					return false;
				}
				if (tableItem3.JobType == 0)
				{
					if (tableItem3.ID == tableItem2.ID)
					{
						return true;
					}
				}
				else if (tableItem3.prejob == tableItem2.ID)
				{
					return true;
				}
			}
			else
			{
				for (int i = 0; i < ItemData.Occu.Length; i++)
				{
					JobTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(ItemData.Occu[i], string.Empty, string.Empty);
					if (tableItem4 != null)
					{
						if (tableItem4.ID == TargetJobId)
						{
							return true;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600B6E5 RID: 46821 RVA: 0x0029AA84 File Offset: 0x00298E84
		public object GetAddDrugUseTipFunc(ItemData item)
		{
			if (item == null)
			{
				return null;
			}
			if (DataManager<ItemDataManager>.GetInstance().GetItem(item.GUID) == null)
			{
				return null;
			}
			TipFuncButon tipFuncButon = null;
			if (item.SubType == 50 || item.SubType == 51 || item.SubType == 52 || item.SubType == 62)
			{
				tipFuncButon = new TipFuncButon();
				tipFuncButon.text = TR.Value("tip_drug_config");
				tipFuncButon.name = "drug_config";
				tipFuncButon.callback = new OnTipFuncClicked(this._DrugConfig);
			}
			return tipFuncButon;
		}

		// Token: 0x0600B6E6 RID: 46822 RVA: 0x0029AB1C File Offset: 0x00298F1C
		private void _DrugConfig(ItemData item, object param1)
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<ChapterBattlePotionSetFrame>(FrameLayer.Middle, null, string.Empty);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600B6E7 RID: 46823 RVA: 0x0029AB3C File Offset: 0x00298F3C
		private bool ItemCanPopUp(ItemData itemData)
		{
			if (itemData == null)
			{
				return false;
			}
			if (itemData.TableData == null)
			{
				return false;
			}
			if (this.popUpConditions == null)
			{
				return false;
			}
			if (!this.popUpConditions.ContainsKey(itemData.TableData.Type))
			{
				return false;
			}
			ItemDataManager.PopUpCondition popUpCondition = this.popUpConditions[itemData.TableData.Type];
			return popUpCondition != null && (popUpCondition.iMinPlayerLv <= 0 || (int)DataManager<PlayerBaseData>.GetInstance().Level >= popUpCondition.iMinPlayerLv) && (popUpCondition.iMaxPlayerLv <= 0 || (int)DataManager<PlayerBaseData>.GetInstance().Level <= popUpCondition.iMaxPlayerLv) && (popUpCondition.checkCallBack == null || popUpCondition.checkCallBack(itemData));
		}

		// Token: 0x0600B6E8 RID: 46824 RVA: 0x0029AC08 File Offset: 0x00299008
		private bool IsNeedAddToEquipChangedList(ulong id)
		{
			ItemData item = this.GetItem(id);
			bool flag = this.ItemCanPopUp(item);
			return item != null && !this.m_akNeedPopEquips.Contains(id) && item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage && flag && item.PackageType != EPackageType.EquipRecovery;
		}

		// Token: 0x0600B6E9 RID: 46825 RVA: 0x0029AC6C File Offset: 0x0029906C
		private void _OnFatigueChanged(UIEvent uiEvent)
		{
			bool flag = false;
			if (DataManager<PlayerBaseData>.GetInstance().fatigue <= 0)
			{
				List<ulong> itemsByPackageSubType = this.GetItemsByPackageSubType(EPackageType.Consumable, ItemTable.eSubType.FatigueDrug);
				for (int i = 0; i < itemsByPackageSubType.Count; i++)
				{
					ItemData item = this.GetItem(itemsByPackageSubType[i]);
					if (item != null && item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage && item.GetCurrentRemainUseTime() > 0)
					{
						if (this.IsNeedAddToEquipChangedList(item.GUID))
						{
							this.m_akNeedPopEquips.Add(item.GUID);
							flag = true;
						}
					}
				}
				if (this._TryRemoveFatigueDrug())
				{
					flag = true;
				}
				if (flag)
				{
					this.TryOpenEquipmentChangedFrame();
				}
			}
			else if (this._TryRemoveFatigueDrug())
			{
				flag = true;
			}
			if (flag && this.onNeedPopEquipsChanged != null)
			{
				this.onNeedPopEquipsChanged(this.m_akNeedPopEquips);
			}
		}

		// Token: 0x0600B6EA RID: 46826 RVA: 0x0029AD5B File Offset: 0x0029915B
		private void _OnCountValueChanged(UIEvent a_event)
		{
			this._OnFatigueChanged(null);
		}

		// Token: 0x0600B6EB RID: 46827 RVA: 0x0029AD64 File Offset: 0x00299164
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			if (Utility.IsPlayerLevelFull(iCurLv) && this._TryRemoveExperiencePill() && this.onNeedPopEquipsChanged != null)
			{
				this.onNeedPopEquipsChanged(this.m_akNeedPopEquips);
			}
		}

		// Token: 0x0600B6EC RID: 46828 RVA: 0x0029AD98 File Offset: 0x00299198
		private bool _TryRemoveExperiencePill()
		{
			bool result = false;
			for (int i = 0; i < this.m_akNeedPopEquips.Count; i++)
			{
				ItemData item = this.GetItem(this.m_akNeedPopEquips[i]);
				if (item == null)
				{
					this.m_akNeedPopEquips.RemoveAt(i--);
					result = true;
				}
				else if (item.SubType == 41)
				{
					this.m_akNeedPopEquips.RemoveAt(i--);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600B6ED RID: 46829 RVA: 0x0029AE18 File Offset: 0x00299218
		private List<ulong> OnFilter(List<ulong> items, bool bNeedNew)
		{
			List<ulong> list = new List<ulong>();
			ItemData itemData = null;
			for (int i = 0; i < items.Count; i++)
			{
				if (this.m_itemsDict.TryGetValue(items[i], out itemData))
				{
					if (itemData.PackageType != EPackageType.Storage && itemData.PackageType != EPackageType.RoleStorage)
					{
						if (!itemData.isInSidePack)
						{
							ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								if (tableItem != null && (tableItem.Type == ItemTable.eType.EQUIP || tableItem.Type == ItemTable.eType.FUCKTITTLE || tableItem.Type == ItemTable.eType.FASHION) && (itemData.IsNew || !bNeedNew))
								{
									if (itemData.CheckBetterThanEquip() && itemData.PackageType != EPackageType.WearEquip)
									{
										list.Add(items[i]);
									}
								}
								else if (tableItem != null && tableItem.SubType == ItemTable.eSubType.GiftPackage)
								{
									if (itemData.CanGiftUse() && tableItem.EPrompt == ItemTable.eEPrompt.EPT_NEW_EQUIP)
									{
										list.Add(items[i]);
									}
								}
								else if (tableItem != null && tableItem.EPrompt == ItemTable.eEPrompt.EPT_NEW_EQUIP)
								{
									if (itemData.IsLevelFit())
									{
										if (tableItem.SubType == ItemTable.eSubType.FatigueDrug)
										{
											if (DataManager<PlayerBaseData>.GetInstance().fatigue <= 0 && itemData.GetCurrentRemainUseTime() > 0)
											{
												list.Add(items[i]);
											}
										}
										else if (tableItem.SubType == ItemTable.eSubType.ExperiencePill)
										{
											if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.NeedLevel && (int)DataManager<PlayerBaseData>.GetInstance().Level <= tableItem.MaxLevel)
											{
												list.Add(items[i]);
											}
										}
										else
										{
											list.Add(items[i]);
										}
									}
								}
								else if (tableItem.SubType == ItemTable.eSubType.PetEgg && DataManager<PlayerBaseData>.GetInstance().Level >= 16 && DataManager<PlayerBaseData>.GetInstance().Level <= 45)
								{
									int petID = Utility.GetPetID(itemData.TableID);
									PetTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(petID, string.Empty, string.Empty);
									if (tableItem2 != null)
									{
										List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
										if (onUsePetList != null)
										{
											bool flag = false;
											for (int j = 0; j < onUsePetList.Count; j++)
											{
												PetTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)onUsePetList[j].dataId, string.Empty, string.Empty);
												if (tableItem3 != null && tableItem3.PetType == tableItem2.PetType)
												{
													flag = true;
													if (tableItem2.Quality > tableItem3.Quality)
													{
														list.Add(items[i]);
													}
													break;
												}
											}
											if (!flag)
											{
												list.Add(items[i]);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			list.Sort();
			return list;
		}

		// Token: 0x0600B6EE RID: 46830 RVA: 0x0029B114 File Offset: 0x00299514
		private void _OnLevelUpAddNewPopEquipments(int iPreLv)
		{
			foreach (KeyValuePair<ulong, ItemData> keyValuePair in this.m_itemsDict)
			{
				ItemData value = keyValuePair.Value;
				if (value.CheckBetterThanEquip() && !value.IsPreLevelFit(iPreLv))
				{
					if (this.IsNeedAddToEquipChangedList(value.GUID))
					{
						this.m_akNeedPopEquips.Add(value.GUID);
					}
				}
				else if (value.SubType == 29 && value.CanGiftUse() && !value.IsPreLevelFit(iPreLv) && this.IsNeedAddToEquipChangedList(value.GUID))
				{
					this.m_akNeedPopEquips.Add(value.GUID);
				}
			}
			this._RemoveLowScoreEquips(this.m_akNeedPopEquips);
			if (this.onNeedPopEquipsChanged != null)
			{
				this.onNeedPopEquipsChanged(this.m_akNeedPopEquips);
			}
			this.TryOpenEquipmentChangedFrame();
		}

		// Token: 0x0600B6EF RID: 46831 RVA: 0x0029B200 File Offset: 0x00299600
		private void _OnFatigueChanged()
		{
		}

		// Token: 0x0600B6F0 RID: 46832 RVA: 0x0029B204 File Offset: 0x00299604
		private void _OnChangeJobAddNewPopEquipments()
		{
			foreach (KeyValuePair<ulong, ItemData> keyValuePair in this.m_itemsDict)
			{
				ItemData value = keyValuePair.Value;
				if (value.CheckBetterThanEquip())
				{
					if (this.IsNeedAddToEquipChangedList(value.GUID))
					{
						this.m_akNeedPopEquips.Add(value.GUID);
					}
				}
				else if (value.SubType == 29 && value.CanGiftUse() && this.IsNeedAddToEquipChangedList(value.GUID))
				{
					this.m_akNeedPopEquips.Add(value.GUID);
				}
			}
			this._RemoveLowScoreEquips(this.m_akNeedPopEquips);
			if (this.onNeedPopEquipsChanged != null)
			{
				this.onNeedPopEquipsChanged(this.m_akNeedPopEquips);
			}
			this.TryOpenEquipmentChangedFrame();
		}

		// Token: 0x0600B6F1 RID: 46833 RVA: 0x0029B2D8 File Offset: 0x002996D8
		private void _RemoveLowScoreEquips(List<ulong> akNeedPopEquips)
		{
			this.m_akSlotMap.Clear();
			for (int i = 0; i < akNeedPopEquips.Count; i++)
			{
				ItemData item = this.GetItem(akNeedPopEquips[i]);
				if (item == null)
				{
					akNeedPopEquips.RemoveAt(i--);
				}
				else if (item.PackageType == EPackageType.Equip || item.PackageType == EPackageType.Title)
				{
					if (!this.m_akSlotMap.ContainsKey(item.EquipWearSlotType))
					{
						this.m_akSlotMap.Add(item.EquipWearSlotType, item);
					}
					else if (this.m_akSlotMap[item.EquipWearSlotType].finalRateScore < item.finalRateScore)
					{
						this.m_akSlotMap[item.EquipWearSlotType] = item;
					}
					akNeedPopEquips.RemoveAt(i--);
				}
			}
			if (this.m_akSlotMap.Count > 0)
			{
				List<ItemData> list = this.m_akSlotMap.Values.ToList<ItemData>();
				for (int j = 0; j < list.Count; j++)
				{
					akNeedPopEquips.Add(list[j].GUID);
				}
			}
		}

		// Token: 0x0600B6F2 RID: 46834 RVA: 0x0029B400 File Offset: 0x00299800
		public void _OnAddItem(List<Item> items)
		{
			List<ulong> list = new List<ulong>();
			list.Clear();
			for (int i = 0; i < items.Count; i++)
			{
				list.Add(items[i].uid);
			}
			List<ulong> list2 = this.OnFilter(list, true);
			if (list2.Count > 0)
			{
				for (int j = 0; j < list2.Count; j++)
				{
					if (this.IsNeedAddToEquipChangedList(list2[j]))
					{
						this.m_akNeedPopEquips.Add(list2[j]);
					}
				}
				this._RemoveLowScoreEquips(this.m_akNeedPopEquips);
				if (this.onNeedPopEquipsChanged != null)
				{
					this.onNeedPopEquipsChanged(this.m_akNeedPopEquips);
				}
			}
			if (this.onAddNewItem != null)
			{
				this.onAddNewItem(items);
			}
		}

		// Token: 0x0600B6F3 RID: 46835 RVA: 0x0029B4D4 File Offset: 0x002998D4
		private void _OnUpdateItem(List<Item> items)
		{
			ItemData itemData = null;
			bool flag = false;
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < items.Count; i++)
			{
				if (this.m_itemsDict.TryGetValue(items[i].uid, out itemData))
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
					if ((tableItem != null && (tableItem.Type == ItemTable.eType.FASHION || tableItem.Type == ItemTable.eType.EQUIP || tableItem.Type == ItemTable.eType.FUCKTITTLE)) || (tableItem != null && tableItem.EPrompt == ItemTable.eEPrompt.EPT_NEW_EQUIP))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				this.m_akNeedPopEquips = this.OnFilter(this.m_akNeedPopEquips, false);
				this._RemoveLowScoreEquips(this.m_akNeedPopEquips);
				if (this.onNeedPopEquipsChanged != null)
				{
					this.onNeedPopEquipsChanged(this.m_akNeedPopEquips);
				}
			}
		}

		// Token: 0x17001AF5 RID: 6901
		// (get) Token: 0x0600B6F4 RID: 46836 RVA: 0x0029B5C6 File Offset: 0x002999C6
		// (set) Token: 0x0600B6F5 RID: 46837 RVA: 0x0029B5CE File Offset: 0x002999CE
		public List<ulong> NeedEquiptmentsID
		{
			get
			{
				return this.m_akNeedPopEquips;
			}
			set
			{
				this.NeedEquiptmentsID = value;
			}
		}

		// Token: 0x0600B6F6 RID: 46838 RVA: 0x0029B5D7 File Offset: 0x002999D7
		public void AddSystemInvoke()
		{
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.RemoveListener(new UnityAction(this.OnSceneLoadFinish));
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.AddListener(new UnityAction(this.OnSceneLoadFinish));
		}

		// Token: 0x0600B6F7 RID: 46839 RVA: 0x0029B60F File Offset: 0x00299A0F
		private void OnSceneLoadFinish()
		{
			this.TryOpenEquipmentChangedFrame();
		}

		// Token: 0x0600B6F8 RID: 46840 RVA: 0x0029B618 File Offset: 0x00299A18
		private void TryOpenEquipmentChangedFrame()
		{
			if (ClientSystem.IsTargetSystem<ClientSystemTown>() && this.m_akNeedPopEquips.Count > 0 && !Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EquipmentChangedFrame>(null))
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					return;
				}
				if (Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
				{
					return;
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipmentChangedFrame>(FrameLayer.Bottom, null, string.Empty);
			}
		}

		// Token: 0x0600B6F9 RID: 46841 RVA: 0x0029B69C File Offset: 0x00299A9C
		public void _InitEquipScore()
		{
			this._InitEquipBaseScoreModTable();
			this._InitEquipIdDic();
			this._RefreshGlobalByTable();
			Dictionary<string, float> dictionary = Global.Settings.equipPropFactors;
			for (int i = 0; i < Global.equipPropName.Count; i++)
			{
				string key = Global.equipPropName[i];
				if (dictionary.ContainsKey(key))
				{
					dictionary[key] = Global.Settings.equipPropFactorValues[i];
				}
				else
				{
					dictionary.Add(key, Global.Settings.equipPropFactorValues[i]);
				}
			}
			dictionary = Global.Settings.quipThirdTypeFactors;
			for (int j = 0; j < Global.equipThirdTypeNamesList.Count; j++)
			{
				string key2 = Global.equipThirdTypeNamesList[j];
				if (dictionary.ContainsKey(key2))
				{
					dictionary[key2] = Global.Settings.quipThirdTypeFactorValues[j];
				}
				else
				{
					dictionary.Add(key2, Global.Settings.quipThirdTypeFactorValues[j]);
				}
			}
		}

		// Token: 0x0600B6FA RID: 46842 RVA: 0x0029B794 File Offset: 0x00299B94
		protected void _InitEquipIdDic()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipScoreTable>();
			if (table == null)
			{
				return;
			}
			EquipScoreTable.eType key = EquipScoreTable.eType.None;
			for (int i = 1; i <= table.Count; i++)
			{
				EquipScoreTable tableItem = Singleton<TableManager>.instance.GetTableItem<EquipScoreTable>(i, string.Empty, string.Empty);
				if (!this.m_EquipScoreValueDic.ContainsKey(tableItem.Type))
				{
					this.m_EquipScoreValueDic.Add(tableItem.Type, tableItem.Value);
				}
				else
				{
					this.m_EquipScoreValueDic[key] = tableItem.Value;
				}
			}
		}

		// Token: 0x0600B6FB RID: 46843 RVA: 0x0029B828 File Offset: 0x00299C28
		private void _RefreshGlobalByTable()
		{
			int num = -1;
			for (int i = 0; i < Global.Settings.equipPropFactorValues.Length; i++)
			{
				switch (i)
				{
				case 0:
					num = this._GetDataByType(EquipScoreTable.eType.HP);
					break;
				case 1:
					num = this._GetDataByType(EquipScoreTable.eType.MP);
					break;
				case 2:
					num = this._GetDataByType(EquipScoreTable.eType.HPRECVR);
					break;
				case 3:
					num = this._GetDataByType(EquipScoreTable.eType.MPRECVR);
					break;
				case 4:
					num = this._GetDataByType(EquipScoreTable.eType.PHYATK);
					break;
				case 5:
					num = this._GetDataByType(EquipScoreTable.eType.MAGATK);
					break;
				case 6:
					num = this._GetDataByType(EquipScoreTable.eType.PHYDEF);
					break;
				case 7:
					num = this._GetDataByType(EquipScoreTable.eType.MAGDEF);
					break;
				case 8:
					num = this._GetDataByType(EquipScoreTable.eType.ATKSPD);
					break;
				case 9:
					num = this._GetDataByType(EquipScoreTable.eType.MAGSPD);
					break;
				case 10:
					num = this._GetDataByType(EquipScoreTable.eType.MVSPD);
					break;
				case 11:
					num = this._GetDataByType(EquipScoreTable.eType.PHYCRT);
					break;
				case 12:
					num = this._GetDataByType(EquipScoreTable.eType.MAGCRT);
					break;
				case 13:
					num = this._GetDataByType(EquipScoreTable.eType.HIT);
					break;
				case 14:
					num = this._GetDataByType(EquipScoreTable.eType.MISS);
					break;
				case 15:
					num = this._GetDataByType(EquipScoreTable.eType.JZ);
					break;
				case 16:
					num = this._GetDataByType(EquipScoreTable.eType.YZ);
					break;
				case 17:
					num = this._GetDataByType(EquipScoreTable.eType.STR);
					break;
				case 18:
					num = this._GetDataByType(EquipScoreTable.eType.INT);
					break;
				case 19:
					num = this._GetDataByType(EquipScoreTable.eType.STAM);
					break;
				case 20:
					num = this._GetDataByType(EquipScoreTable.eType.SPR);
					break;
				case 21:
					num = this._GetDataByType(EquipScoreTable.eType.PHYDMGRDC);
					break;
				case 22:
					num = this._GetDataByType(EquipScoreTable.eType.MAGDMGRDC);
					break;
				case 23:
					num = this._GetDataByType(EquipScoreTable.eType.DISPHYATK);
					break;
				case 24:
					num = this._GetDataByType(EquipScoreTable.eType.DISMAGATK);
					break;
				}
				if (num != -1)
				{
					Global.Settings.equipPropFactorValues[i] = (float)num / 1000f;
				}
			}
			int num2 = -1;
			for (int j = 0; j < Global.Settings.quipThirdTypeFactorValues.Length; j++)
			{
				switch (j)
				{
				case 0:
					num2 = this._GetDataByType(EquipScoreTable.eType.HSWORD);
					break;
				case 1:
					num2 = this._GetDataByType(EquipScoreTable.eType.TD);
					break;
				case 2:
					num2 = this._GetDataByType(EquipScoreTable.eType.DJ);
					break;
				case 3:
					num2 = this._GetDataByType(EquipScoreTable.eType.GUANGJIAN);
					break;
				case 5:
					num2 = this._GetDataByType(EquipScoreTable.eType.ZL);
					break;
				case 6:
					num2 = this._GetDataByType(EquipScoreTable.eType.NUJIAN);
					break;
				case 7:
					num2 = this._GetDataByType(EquipScoreTable.eType.SP);
					break;
				case 8:
					num2 = this._GetDataByType(EquipScoreTable.eType.BUQIANG);
					break;
				case 10:
					num2 = this._GetDataByType(EquipScoreTable.eType.FZ);
					break;
				case 11:
					num2 = this._GetDataByType(EquipScoreTable.eType.MZ);
					break;
				case 12:
					num2 = this._GetDataByType(EquipScoreTable.eType.SPEAR);
					break;
				case 13:
					num2 = this._GetDataByType(EquipScoreTable.eType.STICK);
					break;
				case 14:
					num2 = this._GetDataByType(EquipScoreTable.eType.BJ);
					break;
				case 15:
					num2 = this._GetDataByType(EquipScoreTable.eType.PJ);
					break;
				case 16:
					num2 = this._GetDataByType(EquipScoreTable.eType.QJ);
					break;
				case 17:
					num2 = this._GetDataByType(EquipScoreTable.eType.ZJ);
					break;
				case 18:
					num2 = this._GetDataByType(EquipScoreTable.eType.BA);
					break;
				}
				if (num2 != -1)
				{
					Global.Settings.quipThirdTypeFactorValues[j] = (float)num2 / 1000f;
				}
			}
		}

		// Token: 0x0600B6FC RID: 46844 RVA: 0x0029BBBD File Offset: 0x00299FBD
		public int _GetDataByType(EquipScoreTable.eType type)
		{
			if (this.m_EquipScoreValueDic.ContainsKey(type))
			{
				return this.m_EquipScoreValueDic[type];
			}
			return -1;
		}

		// Token: 0x0600B6FD RID: 46845 RVA: 0x0029BBE0 File Offset: 0x00299FE0
		private bool IsItemBelongSuit(int itemId)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			return tableItem != null && tableItem.SuitID > 0;
		}

		// Token: 0x0600B6FE RID: 46846 RVA: 0x0029BC1C File Offset: 0x0029A01C
		public int GetItemResistMagicValue(int itemId)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			int equipPropID = tableItem.EquipPropID;
			EquipAttrTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(equipPropID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			return tableItem2.ResistMagic;
		}

		// Token: 0x0600B6FF RID: 46847 RVA: 0x0029BC74 File Offset: 0x0029A074
		private void SyncMainPlayerBaseDataByUpdateItem(List<ItemData> itemDataList)
		{
			if (itemDataList == null || itemDataList.Count <= 0)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < itemDataList.Count; i++)
			{
				ItemData itemData = itemDataList[i];
				if (itemData != null)
				{
					int itemResistMagicValue = this.GetItemResistMagicValue(itemData.TableID);
					if (itemResistMagicValue > 0)
					{
						flag = true;
						break;
					}
					bool flag2 = this.IsItemBelongSuit(itemData.TableID);
					if (flag2)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			this.SendSyncResistMagicValueReq();
		}

		// Token: 0x0600B700 RID: 46848 RVA: 0x0029BD04 File Offset: 0x0029A104
		private void SendSyncResistMagicValueReq()
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem == null)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (clientSystemTown.MainPlayer == null)
			{
				return;
			}
			clientSystemTown.MainPlayer.SyncResistMagicValue();
		}

		// Token: 0x0600B701 RID: 46849 RVA: 0x0029BD4F File Offset: 0x0029A14F
		private void OnSyncResistMagicValueByBuffChanged(UIEvent uiEvent)
		{
			this.SendSyncResistMagicValueReq();
		}

		// Token: 0x0600B702 RID: 46850 RVA: 0x0029BD57 File Offset: 0x0029A157
		private void OnContinueProcessStart(UIEvent uiEvent)
		{
			this.bCalResistMagicValue = false;
		}

		// Token: 0x0600B703 RID: 46851 RVA: 0x0029BD60 File Offset: 0x0029A160
		private void OnContinueProcessReset(UIEvent uiEvent)
		{
			this.bCalResistMagicValue = true;
		}

		// Token: 0x0600B704 RID: 46852 RVA: 0x0029BD69 File Offset: 0x0029A169
		private void OnContinueProcessFinish(UIEvent uiEvent)
		{
			this.bCalResistMagicValue = true;
			this.SendSyncResistMagicValueReq();
		}

		// Token: 0x0600B705 RID: 46853 RVA: 0x0029BD78 File Offset: 0x0029A178
		public PrecBead[] SwitchPrecBead(PreciousBeadMountHole[] data)
		{
			if (data == null)
			{
				return null;
			}
			PrecBead[] array = new PrecBead[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != null)
				{
					array[i] = new PrecBead();
					array[i].index = (int)data[i].index;
					array[i].type = (int)data[i].type;
					int preciousBeadId = (int)data[i].preciousBeadId;
					array[i].preciousBeadId = preciousBeadId;
					array[i].randomBuffId = (int)data[i].buffId;
					array[i].pickNumber = (int)data[i].extirpeCnt;
					array[i].beadReplaceNumber = (int)data[i].replaceCnt;
				}
			}
			return array;
		}

		// Token: 0x0600B706 RID: 46854 RVA: 0x0029BE24 File Offset: 0x0029A224
		public PrecEnchantmentCard SwichPrecEnchantmentCard(ItemMountedMagic itemMountedMagic)
		{
			PrecEnchantmentCard precEnchantmentCard = new PrecEnchantmentCard();
			if (itemMountedMagic != null)
			{
				precEnchantmentCard.iEnchantmentCardID = (int)itemMountedMagic.magicCardId;
				precEnchantmentCard.iEnchantmentCardLevel = (int)itemMountedMagic.level;
			}
			return precEnchantmentCard;
		}

		// Token: 0x0600B707 RID: 46855 RVA: 0x0029BE58 File Offset: 0x0029A258
		public PrecEnchantmentCard MountMagicCardInItem(uint mountMagicCardId, byte mountMagicCardLevel)
		{
			return new PrecEnchantmentCard
			{
				iEnchantmentCardID = (int)mountMagicCardId,
				iEnchantmentCardLevel = (int)mountMagicCardLevel
			};
		}

		// Token: 0x0600B708 RID: 46856 RVA: 0x0029BE7C File Offset: 0x0029A27C
		public PrecBead[] MountBeadInItem(uint mountBeadId, uint mountBeadBuffId)
		{
			return new PrecBead[]
			{
				new PrecBead
				{
					preciousBeadId = (int)mountBeadId,
					randomBuffId = (int)mountBeadBuffId
				}
			};
		}

		// Token: 0x0600B709 RID: 46857 RVA: 0x0029BEAC File Offset: 0x0029A2AC
		public List<InscriptionHoleData> SwichInscriptionHoleData(InscriptionMountHole[] data, ItemData itemData)
		{
			if (data == null)
			{
				return null;
			}
			List<InscriptionHoleData> list = new List<InscriptionHoleData>();
			List<HoleData> equipmentInscriptionHoleNumber = DataManager<InscriptionMosaicDataManager>.GetInstance().GetEquipmentInscriptionHoleNumber(itemData);
			for (int i = 0; i < equipmentInscriptionHoleNumber.Count; i++)
			{
				if (equipmentInscriptionHoleNumber[i] != null)
				{
					InscriptionHoleData inscriptionHoleData = new InscriptionHoleData();
					if (i < data.Length)
					{
						inscriptionHoleData.Index = (int)data[i].index;
						inscriptionHoleData.Type = (int)data[i].type;
						inscriptionHoleData.InscriptionId = (int)data[i].inscriptionId;
						inscriptionHoleData.IsOpenHole = true;
					}
					else
					{
						inscriptionHoleData.Index = equipmentInscriptionHoleNumber[i].Index;
						inscriptionHoleData.Type = equipmentInscriptionHoleNumber[i].Type;
						inscriptionHoleData.InscriptionId = 0;
						inscriptionHoleData.IsOpenHole = false;
					}
					list.Add(inscriptionHoleData);
				}
			}
			return list;
		}

		// Token: 0x0600B70A RID: 46858 RVA: 0x0029BF7C File Offset: 0x0029A37C
		private void _InitEquipBaseScoreModTable()
		{
			if (this.mEquipBaseScoreModTableList == null)
			{
				this.mEquipBaseScoreModTableList = new List<EquipBaseScoreModTable>();
			}
			this.mEquipBaseScoreModTableList.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<EquipBaseScoreModTable>())
			{
				EquipBaseScoreModTable equipBaseScoreModTable = keyValuePair.Value as EquipBaseScoreModTable;
				if (equipBaseScoreModTable != null)
				{
					this.mEquipBaseScoreModTableList.Add(equipBaseScoreModTable);
				}
			}
		}

		// Token: 0x0600B70B RID: 46859 RVA: 0x0029BFF8 File Offset: 0x0029A3F8
		public EquipBaseScoreModTable GetEquipBaseScoreModTable(int subType, int quality)
		{
			EquipBaseScoreModTable result = null;
			for (int i = 0; i < this.mEquipBaseScoreModTableList.Count; i++)
			{
				EquipBaseScoreModTable equipBaseScoreModTable = this.mEquipBaseScoreModTableList[i];
				if (equipBaseScoreModTable != null)
				{
					if (subType == (int)equipBaseScoreModTable.ItemSubType)
					{
						if (quality == (int)equipBaseScoreModTable.ItemQuality)
						{
							result = equipBaseScoreModTable;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04006726 RID: 26406
		protected Dictionary<ulong, ItemData> m_itemsDict = new Dictionary<ulong, ItemData>();

		// Token: 0x04006727 RID: 26407
		protected Dictionary<EPackageType, List<ulong>> m_itemPackageTypesDict = new Dictionary<EPackageType, List<ulong>>(new EPackageComparer());

		// Token: 0x04006728 RID: 26408
		protected Dictionary<ItemTable.eType, List<ulong>> m_itemTypesDict = new Dictionary<ItemTable.eType, List<ulong>>(new EItemTypeComparer());

		// Token: 0x04006729 RID: 26409
		protected Dictionary<int, int> m_ItemNumDict = new Dictionary<int, int>();

		// Token: 0x0400672A RID: 26410
		protected Dictionary<int, List<ulong>> m_itemCDGroupDict = new Dictionary<int, List<ulong>>();

		// Token: 0x0400672B RID: 26411
		protected Dictionary<int, bool> mItemDoubleCheckNeedShow = new Dictionary<int, bool>();

		// Token: 0x0400672C RID: 26412
		protected List<ItemCD> m_arrItemCDs = new List<ItemCD>();

		// Token: 0x0400672D RID: 26413
		private static Regex ms_equip_attr_change_reg = new Regex("(\\-?\\d*\\.?\\d+)(%?)");

		// Token: 0x0400672E RID: 26414
		protected Dictionary<int, ItemData> m_commonTableItemDict = new Dictionary<int, ItemData>();

		// Token: 0x0400672F RID: 26415
		protected Dictionary<ItemTable.eSubType, int> m_moneyTypeIDDict = new Dictionary<ItemTable.eSubType, int>(new EItemSubComparer());

		// Token: 0x04006730 RID: 26416
		protected Dictionary<ItemTable.eType, Dictionary<ItemTable.eSubType, List<int>>> m_AuctionMainTypeIDDict = new Dictionary<ItemTable.eType, Dictionary<ItemTable.eSubType, List<int>>>(new EItemTypeComparer());

		// Token: 0x04006731 RID: 26417
		protected ushort[] m_packageHasNew = new ushort[15];

		// Token: 0x04006732 RID: 26418
		private float m_fItemUpdateInterval;

		// Token: 0x04006733 RID: 26419
		private List<ItemData> m_arrTimeLessItems = new List<ItemData>();

		// Token: 0x04006734 RID: 26420
		private List<int> m_aiAddPropertys = new List<int>();

		// Token: 0x04006735 RID: 26421
		public bool bUseVoidCrackTicketIsPlayPrompt;

		// Token: 0x04006736 RID: 26422
		private bool bCalResistMagicValue = true;

		// Token: 0x04006737 RID: 26423
		public ItemDataManager.OnAddNewItem onAddNewItem;

		// Token: 0x04006738 RID: 26424
		public ItemDataManager.OnRemoveItem onRemoveItem;

		// Token: 0x04006739 RID: 26425
		public ItemDataManager.OnUpdateItem onUpdateItem;

		// Token: 0x0400673A RID: 26426
		private DisplayAttribute beforeDisplayAttribute;

		// Token: 0x0400673B RID: 26427
		private int cachedID = -1;

		// Token: 0x0400673C RID: 26428
		private ItemCD cachedItemCD;

		// Token: 0x0400673D RID: 26429
		private const int m_iFatigueLimit = 0;

		// Token: 0x0400673E RID: 26430
		private List<ulong> m_akNeedPopEquips = new List<ulong>();

		// Token: 0x0400673F RID: 26431
		public ItemDataManager.OnNeedPopEquipsChanged onNeedPopEquipsChanged;

		// Token: 0x04006740 RID: 26432
		private Dictionary<EEquipWearSlotType, ItemData> m_akSlotMap = new Dictionary<EEquipWearSlotType, ItemData>();

		// Token: 0x04006741 RID: 26433
		private Dictionary<ItemTable.eType, ItemDataManager.PopUpCondition> popUpConditions = new Dictionary<ItemTable.eType, ItemDataManager.PopUpCondition>();

		// Token: 0x04006742 RID: 26434
		protected Dictionary<EquipScoreTable.eType, int> m_EquipScoreValueDic = new Dictionary<EquipScoreTable.eType, int>();

		// Token: 0x04006743 RID: 26435
		private List<EquipBaseScoreModTable> mEquipBaseScoreModTableList = new List<EquipBaseScoreModTable>();

		// Token: 0x0200128D RID: 4749
		// (Invoke) Token: 0x0600B719 RID: 46873
		public delegate void OnAddNewItem(List<Item> items);

		// Token: 0x0200128E RID: 4750
		// (Invoke) Token: 0x0600B71D RID: 46877
		public delegate void OnRemoveItem(ItemData data);

		// Token: 0x0200128F RID: 4751
		// (Invoke) Token: 0x0600B721 RID: 46881
		public delegate void OnUpdateItem(List<Item> items);

		// Token: 0x02001290 RID: 4752
		// (Invoke) Token: 0x0600B725 RID: 46885
		public delegate void OnNeedPopEquipsChanged(List<ulong> equipts);

		// Token: 0x02001291 RID: 4753
		// (Invoke) Token: 0x0600B729 RID: 46889
		private delegate bool CheckItemPopUp(ItemData itemData);

		// Token: 0x02001292 RID: 4754
		private class PopUpCondition
		{
			// Token: 0x0400674D RID: 26445
			public int iMinPlayerLv;

			// Token: 0x0400674E RID: 26446
			public int iMaxPlayerLv;

			// Token: 0x0400674F RID: 26447
			public ItemDataManager.CheckItemPopUp checkCallBack;
		}
	}
}
