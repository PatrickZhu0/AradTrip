using System;
using GameClient;
using Protocol;
using ProtoTable;

namespace DataModel
{
	// Token: 0x02001CD4 RID: 7380
	public sealed class ActivityTreasureLotteryHistoryModel : ActivityTreasureLotteryModelBase, IActivityTreasureLotteryHistoryModel, IActivityTreasureLotteryModelBase
	{
		// Token: 0x0601219B RID: 74139 RVA: 0x0054BE1C File Offset: 0x0054A21C
		public ActivityTreasureLotteryHistoryModel(GambingItemRecordData data) : base((int)data.itemDataId, data.gambingItemNum, data.gambingItemId, (int)data.sortId)
		{
			this.PlayerList = new HistroyPlayerData[data.groupRecordData.Length];
			this.IsWin = false;
			for (int i = 0; i < data.groupRecordData.Length; i++)
			{
				bool flag = string.Compare(SDKInterface.instance.GetPlatformNameBySelect(), data.groupRecordData[i].gainerENPlatform, StringComparison.Ordinal) == 0;
				if (!this.IsWin && flag && data.groupRecordData[i].gainerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					this.IsWin = true;
				}
				bool isPlayer = data.groupRecordData[i].gainerId == DataManager<PlayerBaseData>.GetInstance().RoleID && flag;
				this.PlayerList[i] = new HistroyPlayerData(data.groupRecordData[i].gainerName, data.groupRecordData[i].gainerServerName, data.groupRecordData[i].gainerPlatform, (int)data.groupRecordData[i].groupId, data.groupRecordData[i].investCurrencyNum, isPlayer);
			}
			this.IsSellOut = (data.soldOutTimestamp != 0U);
			this.TimeSoldOut = Function.GetShortTimeString((double)data.soldOutTimestamp);
			this.CurrencyName = string.Empty;
			if (data.groupRecordData.Length > 0)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)data.groupRecordData[0].investCurrencyId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.CurrencyName = tableItem.Name;
				}
				else
				{
					Logger.LogError("服务端传来的investCurrencyId 在ItemTable表中找不到，investCurrencyId为:" + data.groupRecordData[0].investCurrencyId);
				}
			}
		}

		// Token: 0x17001DEB RID: 7659
		// (get) Token: 0x0601219C RID: 74140 RVA: 0x0054BFDF File Offset: 0x0054A3DF
		// (set) Token: 0x0601219D RID: 74141 RVA: 0x0054BFE7 File Offset: 0x0054A3E7
		public string CurrencyName { get; private set; }

		// Token: 0x17001DEC RID: 7660
		// (get) Token: 0x0601219E RID: 74142 RVA: 0x0054BFF0 File Offset: 0x0054A3F0
		// (set) Token: 0x0601219F RID: 74143 RVA: 0x0054BFF8 File Offset: 0x0054A3F8
		public bool IsSellOut { get; private set; }

		// Token: 0x17001DED RID: 7661
		// (get) Token: 0x060121A0 RID: 74144 RVA: 0x0054C001 File Offset: 0x0054A401
		// (set) Token: 0x060121A1 RID: 74145 RVA: 0x0054C009 File Offset: 0x0054A409
		public HistroyPlayerData[] PlayerList { get; private set; }

		// Token: 0x17001DEE RID: 7662
		// (get) Token: 0x060121A2 RID: 74146 RVA: 0x0054C012 File Offset: 0x0054A412
		// (set) Token: 0x060121A3 RID: 74147 RVA: 0x0054C01A File Offset: 0x0054A41A
		public bool IsWin { get; private set; }

		// Token: 0x17001DEF RID: 7663
		// (get) Token: 0x060121A4 RID: 74148 RVA: 0x0054C023 File Offset: 0x0054A423
		// (set) Token: 0x060121A5 RID: 74149 RVA: 0x0054C02B File Offset: 0x0054A42B
		public string TimeSoldOut { get; private set; }
	}
}
