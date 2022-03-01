using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020015BE RID: 5566
	public class EquipHandbookDataManager : DataManager<EquipHandbookDataManager>
	{
		// Token: 0x0600D9A7 RID: 55719 RVA: 0x0036A29A File Offset: 0x0036869A
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x17001C2F RID: 7215
		// (get) Token: 0x0600D9A8 RID: 55720 RVA: 0x0036A29E File Offset: 0x0036869E
		// (set) Token: 0x0600D9A9 RID: 55721 RVA: 0x0036A2A6 File Offset: 0x003686A6
		public int TabSelectedIndex
		{
			get
			{
				return this.mTabSelectedIndex;
			}
			set
			{
				this.mTabSelectedIndex = value;
			}
		}

		// Token: 0x17001C30 RID: 7216
		// (get) Token: 0x0600D9AA RID: 55722 RVA: 0x0036A2AF File Offset: 0x003686AF
		// (set) Token: 0x0600D9AB RID: 55723 RVA: 0x0036A2B7 File Offset: 0x003686B7
		public bool OnLoginFlag
		{
			get
			{
				return this.mOnloginFlag;
			}
			set
			{
				this.mOnloginFlag = value;
			}
		}

		// Token: 0x0600D9AC RID: 55724 RVA: 0x0036A2C0 File Offset: 0x003686C0
		public bool bIsHintEquipmentGuide()
		{
			for (int i = 0; i < this.mLevel.Length; i++)
			{
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level == this.mLevel[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17001C31 RID: 7217
		// (get) Token: 0x0600D9AD RID: 55725 RVA: 0x0036A305 File Offset: 0x00368705
		public List<EquipHandbookTabData> equipTabs
		{
			get
			{
				return this.mEquipTabs;
			}
		}

		// Token: 0x17001C32 RID: 7218
		// (get) Token: 0x0600D9AE RID: 55726 RVA: 0x0036A30D File Offset: 0x0036870D
		public List<EquipHandbookEquipItemData> playerEquipData
		{
			get
			{
				return this.mPlayerEquipData;
			}
		}

		// Token: 0x17001C33 RID: 7219
		// (get) Token: 0x0600D9AF RID: 55727 RVA: 0x0036A318 File Offset: 0x00368718
		public int sumPlayerEquipCollectScore
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.mPlayerEquipData.Count; i++)
				{
					num += this.mPlayerEquipData[i].baseScore;
				}
				return num;
			}
		}

		// Token: 0x0600D9B0 RID: 55728 RVA: 0x0036A358 File Offset: 0x00368758
		public override void Clear()
		{
			this.mEquipTabs.Clear();
			this._clearPlayerEquipData();
			this._unbindEvent();
			this.TabSelectedIndex = 0;
			this.mOnloginFlag = true;
		}

		// Token: 0x0600D9B1 RID: 55729 RVA: 0x0036A37F File Offset: 0x0036877F
		public override void Initialize()
		{
			this.Clear();
			this._initEquipTabsFromContentTable();
			this._attachEquipTabsInfoFromCollectTable();
			this._sortEquipTabs();
			this._bindEvent();
		}

		// Token: 0x0600D9B2 RID: 55730 RVA: 0x0036A39F File Offset: 0x0036879F
		public void InitSelfEquipData()
		{
			this._initPlayerEquipData();
			this._updateEquipScore();
			this._updateFilterByCondition();
		}

		// Token: 0x0600D9B3 RID: 55731 RVA: 0x0036A3B4 File Offset: 0x003687B4
		public void _updateFilterByCondition()
		{
			for (int i = 0; i < this.mEquipTabs.Count; i++)
			{
				EquipHandbookTabData equipHandbookTabData = this.mEquipTabs[i];
				List<EquipHandbookTabCollectionData> list = equipHandbookTabData.FilterWithCondition();
				for (int j = 0; j < list.Count; j++)
				{
					list[j].FilterWithOccupation();
				}
				equipHandbookTabData.FilterItemWithCondition();
			}
		}

		// Token: 0x0600D9B4 RID: 55732 RVA: 0x0036A41C File Offset: 0x0036881C
		private void _updateEquipScore()
		{
			for (int i = 0; i < this.mEquipTabs.Count; i++)
			{
				EquipHandbookTabData equipHandbookTabData = this.mEquipTabs[i];
				if (equipHandbookTabData != null)
				{
					if (equipHandbookTabData.isShowEquipScore)
					{
						equipHandbookTabData.CalculateEquipScore();
					}
				}
			}
		}

		// Token: 0x0600D9B5 RID: 55733 RVA: 0x0036A46E File Offset: 0x0036886E
		private void _onFilterConditionChanged(UIEvent ui)
		{
			this._updateFilterByCondition();
			this._updateEquipScore();
		}

		// Token: 0x0600D9B6 RID: 55734 RVA: 0x0036A47C File Offset: 0x0036887C
		private void _initPlayerEquipData()
		{
			this.mPlayerEquipData.Clear();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (item.Type != ItemTable.eType.FUCKTITTLE || item.SubType != 10)
					{
						this._addPlayerEquipData(item.TableID);
					}
				}
			}
		}

		// Token: 0x0600D9B7 RID: 55735 RVA: 0x0036A500 File Offset: 0x00368900
		private void _addPlayerEquipData(int itemId)
		{
			EquipHandbookEquipItemData equipHandbookEquipItemData = new EquipHandbookEquipItemData(itemId);
			equipHandbookEquipItemData.CalculateBaseScore();
			this.mPlayerEquipData.Add(equipHandbookEquipItemData);
		}

		// Token: 0x0600D9B8 RID: 55736 RVA: 0x0036A528 File Offset: 0x00368928
		private void _updatePlayerEquipData()
		{
			this.mPendingPlayerEquipData.Clear();
			this.mPendingPlayerEquipData.AddRange(this.mPlayerEquipData);
			this.mPlayerEquipData.Clear();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (item.Type != ItemTable.eType.FUCKTITTLE || item.SubType != 10)
					{
						EquipHandbookEquipItemData equipHandbookEquipItemData = this._findEquipHandbookEquipItemData(item.TableID);
						if (equipHandbookEquipItemData != null)
						{
							this.mPlayerEquipData.Add(equipHandbookEquipItemData);
						}
						else
						{
							this._addPlayerEquipData(item.TableID);
						}
					}
				}
			}
			this.mPendingPlayerEquipData.Clear();
		}

		// Token: 0x0600D9B9 RID: 55737 RVA: 0x0036A5F8 File Offset: 0x003689F8
		private EquipHandbookEquipItemData _findEquipHandbookEquipItemData(int itemId)
		{
			for (int i = 0; i < this.mPendingPlayerEquipData.Count; i++)
			{
				if (itemId == this.mPendingPlayerEquipData[i].id)
				{
					return this.mPendingPlayerEquipData[i];
				}
			}
			return null;
		}

		// Token: 0x0600D9BA RID: 55738 RVA: 0x0036A646 File Offset: 0x00368A46
		private void _clearPlayerEquipData()
		{
			this.mPlayerEquipData.Clear();
			this.mPendingPlayerEquipData.Clear();
		}

		// Token: 0x0600D9BB RID: 55739 RVA: 0x0036A65E File Offset: 0x00368A5E
		private void _onSwitchEquipSuccess(UIEvent ui)
		{
			this._updatePlayerEquipData();
			this._updateEquipScore();
		}

		// Token: 0x0600D9BC RID: 55740 RVA: 0x0036A66C File Offset: 0x00368A6C
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onSwitchEquipSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onFilterConditionChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this._onFilterConditionChanged));
		}

		// Token: 0x0600D9BD RID: 55741 RVA: 0x0036A6C4 File Offset: 0x00368AC4
		private void _unbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onSwitchEquipSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onFilterConditionChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDChanged, new ClientEventSystem.UIEventHandler(this._onFilterConditionChanged));
		}

		// Token: 0x0600D9BE RID: 55742 RVA: 0x0036A71C File Offset: 0x00368B1C
		private void _initEquipTabsFromContentTable()
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<EquipHandbookContentTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("[EquipHandbook] EquipHandbookContentTable is broken!", new object[0]);
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				EquipHandbookContentTable data = keyValuePair.Value as EquipHandbookContentTable;
				EquipHandbookTabData item = new EquipHandbookTabData(data);
				this.mEquipTabs.Add(item);
			}
		}

		// Token: 0x0600D9BF RID: 55743 RVA: 0x0036A790 File Offset: 0x00368B90
		private void _attachEquipTabsInfoFromCollectTable()
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<EquipHandbookCollectionTable>();
			if (table == null)
			{
				Logger.LogErrorFormat("[EquipHandbook] EquipHandbookCollectionTable is broken!", new object[0]);
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				EquipHandbookCollectionTable equipHandbookCollectionTable = keyValuePair.Value as EquipHandbookCollectionTable;
				EquipHandbookTabData equipHandbookTabData = this._findEquipTab(equipHandbookCollectionTable.EquipHandbookContentID);
				if (equipHandbookTabData != null)
				{
					EquipHandbookTabCollectionData equipHandbookTabCollectionData = new EquipHandbookTabCollectionData(equipHandbookCollectionTable);
					if (equipHandbookCollectionTable.ScreenType == EquipHandbookCollectionTable.eScreenType.eWeapon)
					{
						IEnumerator weaponSplitIterator = equipHandbookTabCollectionData.GetWeaponSplitIterator();
						while (weaponSplitIterator.MoveNext())
						{
							object obj = weaponSplitIterator.Current;
							EquipHandbookTabCollectionData equipHandbookTabCollectionData2 = obj as EquipHandbookTabCollectionData;
							if (equipHandbookTabCollectionData2 != null)
							{
								equipHandbookTabData.AddTabCollectionData(equipHandbookTabCollectionData2);
							}
						}
					}
					else
					{
						equipHandbookTabData.AddTabCollectionData(equipHandbookTabCollectionData);
					}
				}
				else
				{
					Logger.LogErrorFormat("[EquipHandbook] 页签 {0} 无法找到", new object[]
					{
						equipHandbookCollectionTable.ID
					});
				}
			}
		}

		// Token: 0x0600D9C0 RID: 55744 RVA: 0x0036A880 File Offset: 0x00368C80
		private void _sortEquipTabs()
		{
			this.mEquipTabs.Sort();
			for (int i = 0; i < this.mEquipTabs.Count; i++)
			{
				this.mEquipTabs[i].SortTabCollectionDatas();
			}
		}

		// Token: 0x0600D9C1 RID: 55745 RVA: 0x0036A8C5 File Offset: 0x00368CC5
		private void _clearEquipTabs()
		{
			this.mEquipTabs.Clear();
		}

		// Token: 0x0600D9C2 RID: 55746 RVA: 0x0036A8D4 File Offset: 0x00368CD4
		private EquipHandbookTabData _findEquipTab(int id)
		{
			for (int i = 0; i < this.mEquipTabs.Count; i++)
			{
				if (this.mEquipTabs[i].id == id)
				{
					return this.mEquipTabs[i];
				}
			}
			return null;
		}

		// Token: 0x0600D9C3 RID: 55747 RVA: 0x0036A924 File Offset: 0x00368D24
		public int GetPlayerWeaponScore()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && PlayerBaseData.IsWeapon((ItemTable.eSubType)item.SubType))
				{
					for (int j = 0; j < this.mPlayerEquipData.Count; j++)
					{
						if (item.TableID == this.mPlayerEquipData[j].id)
						{
							return this.mPlayerEquipData[j].baseScore;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600D9C4 RID: 55748 RVA: 0x0036A9D4 File Offset: 0x00368DD4
		public int GetSplitLevel(List<EquipHandbookTabCollectionData> collectIDs, EquipHandbookCollectionTable.eScreenType partType)
		{
			if (collectIDs == null)
			{
				return -1;
			}
			int result = -1;
			int num = -1;
			for (int i = 0; i < collectIDs.Count; i++)
			{
				if (collectIDs[i].partScreenType == partType)
				{
					num = collectIDs[i].level;
					if (num == (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						return num;
					}
					if (num > (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						return result;
					}
					result = num;
				}
			}
			return num;
		}

		// Token: 0x0600D9C5 RID: 55749 RVA: 0x0036AA50 File Offset: 0x00368E50
		public int GetPlayerArmorScore()
		{
			int num = 0;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && PlayerBaseData.IsArmy((ItemTable.eSubType)item.SubType))
				{
					for (int j = 0; j < this.mPlayerEquipData.Count; j++)
					{
						if (item.TableID == this.mPlayerEquipData[j].id)
						{
							num += this.mPlayerEquipData[j].baseScore;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600D9C6 RID: 55750 RVA: 0x0036AB08 File Offset: 0x00368F08
		public int GetPlayerJewelryScore()
		{
			int num = 0;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && PlayerBaseData.IsJewelry((ItemTable.eSubType)item.SubType))
				{
					for (int j = 0; j < this.mPlayerEquipData.Count; j++)
					{
						if (item.TableID == this.mPlayerEquipData[j].id)
						{
							num += this.mPlayerEquipData[j].baseScore;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600D9C7 RID: 55751 RVA: 0x0036ABC0 File Offset: 0x00368FC0
		public bool BIsHintEquipmentGuide()
		{
			List<EquipHandbookEquipItemData> list = new List<EquipHandbookEquipItemData>();
			for (int i = 0; i < this.mEquipTabs.Count; i++)
			{
				EquipHandbookTabData equipHandbookTabData = this.mEquipTabs[i];
				if (equipHandbookTabData != null)
				{
					if (equipHandbookTabData.isShowEquipScore)
					{
						list = equipHandbookTabData.GetLowestScoreItemList();
					}
				}
			}
			int num = 0;
			for (int j = 0; j < list.Count; j++)
			{
				num += list[j].baseScore;
			}
			return num > this.sumPlayerEquipCollectScore;
		}

		// Token: 0x0600D9C8 RID: 55752 RVA: 0x0036AC58 File Offset: 0x00369058
		public bool EquipHandbookAttachedTableIsFindItemID(int mItemID)
		{
			EquipHandbookAttachedTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipHandbookAttachedTable>(mItemID, string.Empty, string.Empty);
			return tableItem != null && tableItem.EquipSourceEntrance == 1;
		}

		// Token: 0x0600D9C9 RID: 55753 RVA: 0x0036AC90 File Offset: 0x00369090
		public bool IsHighestGradeItem(int itemTableId)
		{
			if (this.mEquipTabs == null || this.mEquipTabs.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this.mEquipTabs.Count; i++)
			{
				EquipHandbookTabData equipHandbookTabData = this.mEquipTabs[i];
				if (equipHandbookTabData != null)
				{
					if (equipHandbookTabData.id == 2)
					{
						return equipHandbookTabData.IsContainItem(itemTableId);
					}
				}
			}
			return false;
		}

		// Token: 0x0400800F RID: 32783
		public const int EQUIP_HANDBOOK_TAB_JINPIN_TABLE_ID = 2;

		// Token: 0x04008010 RID: 32784
		private List<EquipHandbookTabData> mEquipTabs = new List<EquipHandbookTabData>();

		// Token: 0x04008011 RID: 32785
		private List<EquipHandbookEquipItemData> mPlayerEquipData = new List<EquipHandbookEquipItemData>();

		// Token: 0x04008012 RID: 32786
		private List<EquipHandbookEquipItemData> mPendingPlayerEquipData = new List<EquipHandbookEquipItemData>();

		// Token: 0x04008013 RID: 32787
		private int[] mLevel = new int[]
		{
			20,
			30,
			40,
			50
		};

		// Token: 0x04008014 RID: 32788
		private int mTabSelectedIndex;

		// Token: 0x04008015 RID: 32789
		private bool mOnloginFlag = true;
	}
}
