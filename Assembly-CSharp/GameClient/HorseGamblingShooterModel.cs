using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CF3 RID: 7411
	public class HorseGamblingShooterModel : IHorseGamblingShooterModel
	{
		// Token: 0x06012362 RID: 74594 RVA: 0x0054E1F4 File Offset: 0x0054C5F4
		public HorseGamblingShooterModel(ShooterInfo msg, bool isUnknown)
		{
			this.Id = (int)msg.id;
			BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>((int)msg.dataid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("赌马射手表中找不到id为{0}的数据", msg.dataid));
			}
			else
			{
				this.IconPath = tableItem.IconPath;
				this.Name = tableItem.Name;
				this.PortraitPath = tableItem.PortraitPath;
				this.Occupation = tableItem.Occupation;
				this.Terrain = tableItem.Terrain;
				this.Weather = tableItem.Weather;
				this.OccupationIcon = tableItem.OccupationIcon;
			}
			this.IsUnknown = isUnknown;
			this.WinRate = msg.winRate / 100f;
			this.ChampionCount = (int)msg.champion;
			this.Odds = msg.odds / 10000f;
			this.Status = (ShooterStatusType)msg.status;
		}

		// Token: 0x17001EE1 RID: 7905
		// (get) Token: 0x06012363 RID: 74595 RVA: 0x0054E2EE File Offset: 0x0054C6EE
		// (set) Token: 0x06012364 RID: 74596 RVA: 0x0054E2F6 File Offset: 0x0054C6F6
		public int Id { get; private set; }

		// Token: 0x17001EE2 RID: 7906
		// (get) Token: 0x06012365 RID: 74597 RVA: 0x0054E2FF File Offset: 0x0054C6FF
		// (set) Token: 0x06012366 RID: 74598 RVA: 0x0054E307 File Offset: 0x0054C707
		public string IconPath { get; private set; }

		// Token: 0x17001EE3 RID: 7907
		// (get) Token: 0x06012367 RID: 74599 RVA: 0x0054E310 File Offset: 0x0054C710
		// (set) Token: 0x06012368 RID: 74600 RVA: 0x0054E318 File Offset: 0x0054C718
		public string PortraitPath { get; private set; }

		// Token: 0x17001EE4 RID: 7908
		// (get) Token: 0x06012369 RID: 74601 RVA: 0x0054E321 File Offset: 0x0054C721
		// (set) Token: 0x0601236A RID: 74602 RVA: 0x0054E329 File Offset: 0x0054C729
		public string Name { get; private set; }

		// Token: 0x17001EE5 RID: 7909
		// (get) Token: 0x0601236B RID: 74603 RVA: 0x0054E332 File Offset: 0x0054C732
		// (set) Token: 0x0601236C RID: 74604 RVA: 0x0054E33A File Offset: 0x0054C73A
		public string Occupation { get; private set; }

		// Token: 0x17001EE6 RID: 7910
		// (get) Token: 0x0601236D RID: 74605 RVA: 0x0054E343 File Offset: 0x0054C743
		// (set) Token: 0x0601236E RID: 74606 RVA: 0x0054E34B File Offset: 0x0054C74B
		public string OccupationIcon { get; private set; }

		// Token: 0x17001EE7 RID: 7911
		// (get) Token: 0x0601236F RID: 74607 RVA: 0x0054E354 File Offset: 0x0054C754
		// (set) Token: 0x06012370 RID: 74608 RVA: 0x0054E35C File Offset: 0x0054C75C
		public string Terrain { get; private set; }

		// Token: 0x17001EE8 RID: 7912
		// (get) Token: 0x06012371 RID: 74609 RVA: 0x0054E365 File Offset: 0x0054C765
		// (set) Token: 0x06012372 RID: 74610 RVA: 0x0054E36D File Offset: 0x0054C76D
		public string Weather { get; private set; }

		// Token: 0x17001EE9 RID: 7913
		// (get) Token: 0x06012373 RID: 74611 RVA: 0x0054E376 File Offset: 0x0054C776
		// (set) Token: 0x06012374 RID: 74612 RVA: 0x0054E37E File Offset: 0x0054C77E
		public ShooterStatusType Status { get; private set; }

		// Token: 0x17001EEA RID: 7914
		// (get) Token: 0x06012375 RID: 74613 RVA: 0x0054E387 File Offset: 0x0054C787
		// (set) Token: 0x06012376 RID: 74614 RVA: 0x0054E38F File Offset: 0x0054C78F
		public float WinRate { get; private set; }

		// Token: 0x17001EEB RID: 7915
		// (get) Token: 0x06012377 RID: 74615 RVA: 0x0054E398 File Offset: 0x0054C798
		// (set) Token: 0x06012378 RID: 74616 RVA: 0x0054E3A0 File Offset: 0x0054C7A0
		public int ChampionCount { get; private set; }

		// Token: 0x17001EEC RID: 7916
		// (get) Token: 0x06012379 RID: 74617 RVA: 0x0054E3A9 File Offset: 0x0054C7A9
		// (set) Token: 0x0601237A RID: 74618 RVA: 0x0054E3B1 File Offset: 0x0054C7B1
		public float Odds { get; private set; }

		// Token: 0x17001EED RID: 7917
		// (get) Token: 0x0601237B RID: 74619 RVA: 0x0054E3BA File Offset: 0x0054C7BA
		// (set) Token: 0x0601237C RID: 74620 RVA: 0x0054E3C2 File Offset: 0x0054C7C2
		public bool IsUnknown { get; private set; }

		// Token: 0x17001EEE RID: 7918
		// (get) Token: 0x0601237D RID: 74621 RVA: 0x0054E3CB File Offset: 0x0054C7CB
		// (set) Token: 0x0601237E RID: 74622 RVA: 0x0054E3D3 File Offset: 0x0054C7D3
		public ShooterRecord[] Records { get; private set; }

		// Token: 0x0601237F RID: 74623 RVA: 0x0054E3DC File Offset: 0x0054C7DC
		public void UpdateOdds(int odds)
		{
			this.Odds = (float)odds / 10000f;
		}

		// Token: 0x06012380 RID: 74624 RVA: 0x0054E3EC File Offset: 0x0054C7EC
		public void UpdateRecords(ShooterRecord[] records)
		{
			this.Records = records;
		}

		// Token: 0x0400BD84 RID: 48516
		private const int INT_TO_FLOAT_RATE = 10000;

		// Token: 0x0400BD85 RID: 48517
		private const int WIN_RATE_TO_PERCENT = 100;
	}
}
