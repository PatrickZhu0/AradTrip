using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200135D RID: 4957
	public class FairDuelDataManager : DataManager<FairDuelDataManager>
	{
		// Token: 0x0600C040 RID: 49216 RVA: 0x002D4E44 File Offset: 0x002D3244
		public override void Initialize()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
		}

		// Token: 0x0600C041 RID: 49217 RVA: 0x002D4E64 File Offset: 0x002D3264
		public override void Clear()
		{
			this.mEqualPvPEuqipTableList.Clear();
			this.EquipIdList.Clear();
			this.FashioIdList.Clear();
			this.EquipDic.Clear();
			this.FashionDic.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityUpdate));
		}

		// Token: 0x0600C042 RID: 49218 RVA: 0x002D4EC4 File Offset: 0x002D32C4
		public void IintEqualPvPEuqipTableList()
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<EqualPvPEuqipTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					EqualPvPEuqipTable equalPvPEuqipTable = keyValuePair.Value as EqualPvPEuqipTable;
					if (equalPvPEuqipTable != null)
					{
						this.mEqualPvPEuqipTableList.Add(equalPvPEuqipTable);
					}
				}
			}
			for (int i = 0; i < this.mEqualPvPEuqipTableList.Count; i++)
			{
				if (this.mEqualPvPEuqipTableList[i].Occu == DataManager<PlayerBaseData>.GetInstance().JobTableID)
				{
					if (this.mEqualPvPEuqipTableList[i].Type == EqualPvPEuqipTable.eType.EQUIP)
					{
						if (!this.EquipDic.ContainsKey(this.mEqualPvPEuqipTableList[i].EquipID))
						{
							this.EquipIdList.Add(this.mEqualPvPEuqipTableList[i].EquipID);
							this.EquipDic.Add(this.mEqualPvPEuqipTableList[i].EquipID, this.mEqualPvPEuqipTableList[i]);
						}
					}
					else if (this.mEqualPvPEuqipTableList[i].Type == EqualPvPEuqipTable.eType.FASHION && !this.FashionDic.ContainsKey(this.mEqualPvPEuqipTableList[i].EquipID))
					{
						this.FashioIdList.Add(this.mEqualPvPEuqipTableList[i].EquipID);
						this.FashionDic.Add(this.mEqualPvPEuqipTableList[i].EquipID, this.mEqualPvPEuqipTableList[i]);
					}
				}
			}
		}

		// Token: 0x0600C043 RID: 49219 RVA: 0x002D5070 File Offset: 0x002D3470
		public List<ItemProperty> GetEquipedEquipments()
		{
			List<ItemProperty> list = new List<ItemProperty>();
			List<int> list2 = this.EquipIdList;
			if (list2 != null)
			{
				foreach (int tableId in list2)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
					if (itemData != null)
					{
						ItemProperty battleProperty = itemData.GetBattleProperty(0);
						battleProperty.itemID = itemData.TableID;
						battleProperty.guid = itemData.GUID;
						list.Add(battleProperty);
					}
				}
			}
			list2 = this.FashioIdList;
			if (list2 != null)
			{
				foreach (int tableId2 in list2)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(tableId2, 100, 0);
					if (itemData2 != null)
					{
						ItemProperty battleProperty2 = itemData2.GetBattleProperty(0);
						battleProperty2.itemID = itemData2.TableID;
						list.Add(battleProperty2);
					}
				}
			}
			return list;
		}

		// Token: 0x0600C044 RID: 49220 RVA: 0x002D51A0 File Offset: 0x002D35A0
		public bool IsShowFairDuelEnterBtn()
		{
			bool result = false;
			for (int i = 0; i < this.mFairDuelActivityIDs.Count; i++)
			{
				int key = this.mFairDuelActivityIDs[i];
				if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(key))
				{
					ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[key];
					if (activityInfo.state == 1)
					{
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600C045 RID: 49221 RVA: 0x002D5212 File Offset: 0x002D3612
		public bool IsFairDuelFieldStr(string judgeStr)
		{
			return !string.IsNullOrEmpty(judgeStr) && judgeStr.Equals("FairDuelField");
		}

		// Token: 0x0600C046 RID: 49222 RVA: 0x002D5234 File Offset: 0x002D3634
		private bool IsContainsFairDuelActivityID(int activityID)
		{
			return this.mFairDuelActivityIDs != null && this.mFairDuelActivityIDs.Contains(activityID);
		}

		// Token: 0x0600C047 RID: 49223 RVA: 0x002D5250 File Offset: 0x002D3650
		private void OnActivityUpdate(UIEvent uiEvent)
		{
			uint activityID = (uint)uiEvent.Param1;
			if (this.IsContainsFairDuelActivityID((int)activityID))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateFairDuelEntryState, this.IsShowFairDuelEnterBtn(), null, null, null);
			}
		}

		// Token: 0x04006C8E RID: 27790
		private List<EqualPvPEuqipTable> mEqualPvPEuqipTableList = new List<EqualPvPEuqipTable>();

		// Token: 0x04006C8F RID: 27791
		public List<int> EquipIdList = new List<int>();

		// Token: 0x04006C90 RID: 27792
		public Dictionary<int, EqualPvPEuqipTable> EquipDic = new Dictionary<int, EqualPvPEuqipTable>();

		// Token: 0x04006C91 RID: 27793
		public List<int> FashioIdList = new List<int>();

		// Token: 0x04006C92 RID: 27794
		public Dictionary<int, EqualPvPEuqipTable> FashionDic = new Dictionary<int, EqualPvPEuqipTable>();

		// Token: 0x04006C93 RID: 27795
		private List<int> mFairDuelActivityIDs = new List<int>
		{
			2026,
			2027,
			2028,
			2029,
			2030,
			2031,
			2032
		};

		// Token: 0x04006C94 RID: 27796
		private const string FAIRDUEL_BATTLEFIELD = "FairDuelField";
	}
}
