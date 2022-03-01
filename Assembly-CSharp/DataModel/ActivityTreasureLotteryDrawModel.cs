using System;
using GameClient;
using Protocol;

namespace DataModel
{
	// Token: 0x02001CD7 RID: 7383
	public class ActivityTreasureLotteryDrawModel : IActivityTreasureLotteryDrawModel
	{
		// Token: 0x060121BD RID: 74173 RVA: 0x0054C174 File Offset: 0x0054A574
		public ActivityTreasureLotteryDrawModel(GambingParticipantInfo winner, GambingParticipantInfo[] topFiveInvestPlayers)
		{
			this.WinnerName = winner.participantName;
			this.ServerName = winner.participantServerName;
			this.PlatformName = winner.participantPlatform;
			this.WinnerRate = winner.gambingRate;
			this.TopFiveInvestPlayers = new DrawWinnerData[topFiveInvestPlayers.Length];
			for (int i = 0; i < topFiveInvestPlayers.Length; i++)
			{
				this.TopFiveInvestPlayers[i] = new DrawWinnerData(topFiveInvestPlayers[i]);
			}
			this.IsPlayerWin = (winner.participantId == DataManager<PlayerBaseData>.GetInstance().RoleID && string.Compare(SDKInterface.instance.GetPlatformNameBySelect(), winner.participantENPlatform, StringComparison.Ordinal) == 0);
			this.ItemId = DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetItemIdByLotteryId((int)winner.gambingItemId);
		}

		// Token: 0x17001DFA RID: 7674
		// (get) Token: 0x060121BE RID: 74174 RVA: 0x0054C23F File Offset: 0x0054A63F
		// (set) Token: 0x060121BF RID: 74175 RVA: 0x0054C247 File Offset: 0x0054A647
		public string WinnerName { get; private set; }

		// Token: 0x17001DFB RID: 7675
		// (get) Token: 0x060121C0 RID: 74176 RVA: 0x0054C250 File Offset: 0x0054A650
		// (set) Token: 0x060121C1 RID: 74177 RVA: 0x0054C258 File Offset: 0x0054A658
		public string WinnerRate { get; private set; }

		// Token: 0x17001DFC RID: 7676
		// (get) Token: 0x060121C2 RID: 74178 RVA: 0x0054C261 File Offset: 0x0054A661
		// (set) Token: 0x060121C3 RID: 74179 RVA: 0x0054C269 File Offset: 0x0054A669
		public string ServerName { get; private set; }

		// Token: 0x17001DFD RID: 7677
		// (get) Token: 0x060121C4 RID: 74180 RVA: 0x0054C272 File Offset: 0x0054A672
		// (set) Token: 0x060121C5 RID: 74181 RVA: 0x0054C27A File Offset: 0x0054A67A
		public string PlatformName { get; private set; }

		// Token: 0x17001DFE RID: 7678
		// (get) Token: 0x060121C6 RID: 74182 RVA: 0x0054C283 File Offset: 0x0054A683
		// (set) Token: 0x060121C7 RID: 74183 RVA: 0x0054C28B File Offset: 0x0054A68B
		public DrawWinnerData[] TopFiveInvestPlayers { get; private set; }

		// Token: 0x17001DFF RID: 7679
		// (get) Token: 0x060121C8 RID: 74184 RVA: 0x0054C294 File Offset: 0x0054A694
		// (set) Token: 0x060121C9 RID: 74185 RVA: 0x0054C29C File Offset: 0x0054A69C
		public bool IsPlayerWin { get; private set; }

		// Token: 0x17001E00 RID: 7680
		// (get) Token: 0x060121CA RID: 74186 RVA: 0x0054C2A5 File Offset: 0x0054A6A5
		// (set) Token: 0x060121CB RID: 74187 RVA: 0x0054C2AD File Offset: 0x0054A6AD
		public int ItemId { get; private set; }
	}
}
