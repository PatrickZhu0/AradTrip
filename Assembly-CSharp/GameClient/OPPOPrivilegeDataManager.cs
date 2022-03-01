using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020013A7 RID: 5031
	public class OPPOPrivilegeDataManager : DataManager<OPPOPrivilegeDataManager>
	{
		// Token: 0x17001BDC RID: 7132
		// (get) Token: 0x0600C343 RID: 49987 RVA: 0x002E9EAE File Offset: 0x002E82AE
		// (set) Token: 0x0600C344 RID: 49988 RVA: 0x002E9EB6 File Offset: 0x002E82B6
		public int OppOAmberLevel { get; set; }

		// Token: 0x0600C345 RID: 49989 RVA: 0x002E9EBF File Offset: 0x002E82BF
		public sealed override void Clear()
		{
			if (SDKInterface.instance.IsOppoPlatform() || SDKInterface.instance.IsVivoPlatForm())
			{
				this._ClearDrawTableData();
				this.OppOAmberLevel = 0;
			}
		}

		// Token: 0x0600C346 RID: 49990 RVA: 0x002E9EEC File Offset: 0x002E82EC
		public sealed override void Initialize()
		{
			if (SDKInterface.instance.IsOppoPlatform() || SDKInterface.instance.IsVivoPlatForm())
			{
				this._InitDrawPrizeTableData();
			}
		}

		// Token: 0x0600C347 RID: 49991 RVA: 0x002E9F14 File Offset: 0x002E8314
		public TheyLuckyData GetTheLuckyData(int a_nID)
		{
			TheyLuckyData result = null;
			this.m_dictDrawData.TryGetValue(a_nID, out result);
			return result;
		}

		// Token: 0x0600C348 RID: 49992 RVA: 0x002E9F34 File Offset: 0x002E8334
		private void _InitDrawPrizeTableData()
		{
			this.m_dictDrawData.Clear();
			Dictionary<int, List<AwardItemData>> dictionary = new Dictionary<int, List<AwardItemData>>();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<RewardPoolTable>())
			{
				RewardPoolTable rewardPoolTable = keyValuePair.Value as RewardPoolTable;
				if (rewardPoolTable != null)
				{
					AwardItemData awardItemData = new AwardItemData();
					awardItemData.ID = rewardPoolTable.ItemID;
					awardItemData.Num = rewardPoolTable.ItemNum;
					if (!dictionary.ContainsKey(rewardPoolTable.DrawPrizeTableID))
					{
						dictionary.Add(rewardPoolTable.DrawPrizeTableID, new List<AwardItemData>());
					}
					dictionary[rewardPoolTable.DrawPrizeTableID].Add(awardItemData);
				}
			}
			foreach (KeyValuePair<int, object> keyValuePair2 in Singleton<TableManager>.GetInstance().GetTable<DrawPrizeTable>())
			{
				DrawPrizeTable drawPrizeTable = keyValuePair2.Value as DrawPrizeTable;
				if (drawPrizeTable != null)
				{
					TheyLuckyData theyLuckyData = new TheyLuckyData();
					theyLuckyData.nID = drawPrizeTable.ID;
					if (dictionary.ContainsKey(theyLuckyData.nID))
					{
						theyLuckyData.itemData = dictionary[theyLuckyData.nID];
					}
					else
					{
						theyLuckyData.itemData = new List<AwardItemData>();
					}
					this.m_dictDrawData.Add(theyLuckyData.nID, theyLuckyData);
				}
			}
		}

		// Token: 0x0600C349 RID: 49993 RVA: 0x002EA090 File Offset: 0x002E8490
		public bool _CheckPrivilrge(int templateID)
		{
			int num = 0;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(templateID);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				if (activeData.akChildItems[i].status == 2)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600C34A RID: 49994 RVA: 0x002EA0F4 File Offset: 0x002E84F4
		public bool _CheckLuckyGuy()
		{
			List<TaskPair> list = new List<TaskPair>();
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(10001, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("DrawPrizeTabl is null", new object[0]);
			}
			list.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(17000);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				for (int j = 0; j < activeData.akChildItems[i].akActivityValues.Count; j++)
				{
					list.Add(activeData.akChildItems[i].akActivityValues[j]);
				}
			}
			int num = 0;
			for (int k = 0; k < list.Count; k++)
			{
				if (list[k].key == tableItem.RestCountKey)
				{
					int.TryParse(list[k].value, out num);
				}
			}
			return num > 0;
		}

		// Token: 0x0600C34B RID: 49995 RVA: 0x002EA218 File Offset: 0x002E8618
		public bool _CheckDail()
		{
			int num = 0;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(15000);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				if (activeData.akChildItems[i].status == 2)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600C34C RID: 49996 RVA: 0x002EA280 File Offset: 0x002E8680
		public bool _CheckAmberGiftBag()
		{
			int num = 0;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.IActivitytEmplateID);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				if (activeData.akChildItems[i].status == 2)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600C34D RID: 49997 RVA: 0x002EA2EC File Offset: 0x002E86EC
		public bool _CheckAmberPrivilege()
		{
			int num = 0;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.iAmberPrivilegeActivityId);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				if (activeData.akChildItems[i].status == 2)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600C34E RID: 49998 RVA: 0x002EA358 File Offset: 0x002E8758
		public bool _CheckOPPOGrowthHaoLi()
		{
			int num = 0;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.iOPPOGrowthHaoLiActivityId);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				if (activeData.akChildItems[i].status == 2)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600C34F RID: 49999 RVA: 0x002EA3C4 File Offset: 0x002E87C4
		public bool _ActiveIsOpen()
		{
			if (SDKInterface.instance.IsOppoPlatform())
			{
				for (int i = 0; i < this.oppoActivityID.Length; i++)
				{
					ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.oppoActivityID[i]);
					if (activeData != null)
					{
						if (activeData.mainInfo.state == 1)
						{
							return true;
						}
					}
				}
				return false;
			}
			if (SDKInterface.instance.IsVivoPlatForm())
			{
				ActiveManager.ActiveData activeData2 = DataManager<ActiveManager>.GetInstance().GetActiveData(23000);
				if (activeData2 == null)
				{
					return false;
				}
				if (activeData2.mainInfo.state != 1)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600C350 RID: 50000 RVA: 0x002EA46C File Offset: 0x002E886C
		protected void _ClearDrawTableData()
		{
			this.m_dictDrawData.Clear();
		}

		// Token: 0x0600C351 RID: 50001 RVA: 0x002EA47C File Offset: 0x002E887C
		public string GetAmberLevel()
		{
			string result = string.Empty;
			switch (this.OppOAmberLevel)
			{
			case 0:
				result = "无";
				break;
			case 1:
				result = "绿珀一星";
				break;
			case 2:
				result = "绿珀二星";
				break;
			case 3:
				result = "绿珀三星";
				break;
			case 4:
				result = "蓝珀一星";
				break;
			case 5:
				result = "蓝珀二星";
				break;
			case 6:
				result = "蓝珀三星";
				break;
			case 7:
				result = "金珀一星";
				break;
			case 8:
				result = "金珀二星";
				break;
			case 9:
				result = "金珀三星";
				break;
			case 10:
				result = "华贵红珀";
				break;
			case 11:
				result = "至尊紫珀";
				break;
			}
			return result;
		}

		// Token: 0x04006E93 RID: 28307
		private Dictionary<int, TheyLuckyData> m_dictDrawData = new Dictionary<int, TheyLuckyData>();

		// Token: 0x04006E94 RID: 28308
		public const int oppoPrivilegeID = 12000;

		// Token: 0x04006E95 RID: 28309
		public const int vivoPrivilegeID = 23000;

		// Token: 0x04006E96 RID: 28310
		public const int dailID = 15000;

		// Token: 0x04006E97 RID: 28311
		public const int luckyGuyID = 17000;

		// Token: 0x04006E98 RID: 28312
		public const int tableID = 10001;

		// Token: 0x04006E99 RID: 28313
		private int IActivitytEmplateID = 20000;

		// Token: 0x04006E9A RID: 28314
		private int iAmberPrivilegeActivityId = 27000;

		// Token: 0x04006E9B RID: 28315
		private int iOPPOGrowthHaoLiActivityId = 26000;

		// Token: 0x04006E9C RID: 28316
		public int surplusNum;

		// Token: 0x04006E9D RID: 28317
		public int totalNum;

		// Token: 0x04006E9E RID: 28318
		private int[] oppoActivityID = new int[]
		{
			12000,
			15000,
			17000,
			20000,
			260000,
			27000
		};
	}
}
