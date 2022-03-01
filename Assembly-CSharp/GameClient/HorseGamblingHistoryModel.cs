using System;
using System.Runtime.InteropServices;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CF6 RID: 7414
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HorseGamblingHistoryModel
	{
		// Token: 0x06012399 RID: 74649 RVA: 0x0054E70C File Offset: 0x0054CB0C
		public HorseGamblingHistoryModel(BattleRecord msg)
		{
			this = default(HorseGamblingHistoryModel);
			this.GameId = (int)msg.courtId;
			BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>((int)msg.champion, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.ChampionName = tableItem.Name;
			}
			this.ShooterId = (int)msg.champion;
			this.Odds = msg.odds / 10000f;
			this.MaxProfit = (int)msg.maxProfit;
		}

		// Token: 0x17001EF9 RID: 7929
		// (get) Token: 0x0601239A RID: 74650 RVA: 0x0054E785 File Offset: 0x0054CB85
		// (set) Token: 0x0601239B RID: 74651 RVA: 0x0054E78D File Offset: 0x0054CB8D
		public int GameId { get; private set; }

		// Token: 0x17001EFA RID: 7930
		// (get) Token: 0x0601239C RID: 74652 RVA: 0x0054E796 File Offset: 0x0054CB96
		// (set) Token: 0x0601239D RID: 74653 RVA: 0x0054E79E File Offset: 0x0054CB9E
		public string ChampionName { get; private set; }

		// Token: 0x17001EFB RID: 7931
		// (get) Token: 0x0601239E RID: 74654 RVA: 0x0054E7A7 File Offset: 0x0054CBA7
		// (set) Token: 0x0601239F RID: 74655 RVA: 0x0054E7AF File Offset: 0x0054CBAF
		public float Odds { get; private set; }

		// Token: 0x17001EFC RID: 7932
		// (get) Token: 0x060123A0 RID: 74656 RVA: 0x0054E7B8 File Offset: 0x0054CBB8
		// (set) Token: 0x060123A1 RID: 74657 RVA: 0x0054E7C0 File Offset: 0x0054CBC0
		public int MaxProfit { get; private set; }

		// Token: 0x17001EFD RID: 7933
		// (get) Token: 0x060123A2 RID: 74658 RVA: 0x0054E7C9 File Offset: 0x0054CBC9
		// (set) Token: 0x060123A3 RID: 74659 RVA: 0x0054E7D1 File Offset: 0x0054CBD1
		public int ShooterId { get; private set; }
	}
}
