using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CF5 RID: 7413
	public class HorseGamblingStakeModel : IHorseGamblingStakeModel
	{
		// Token: 0x0601238B RID: 74635 RVA: 0x0054E618 File Offset: 0x0054CA18
		public HorseGamblingStakeModel(StakeRecord msg)
		{
			this.ShooterId = (int)msg.stakeShooter;
			BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>(this.ShooterId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.ShooterName = tableItem.Name;
			}
			this.Stake = (int)msg.stakeNum;
			this.GameId = (int)msg.courtId;
			this.Profit = msg.profit;
			this.Odds = msg.odds / 10000f;
		}

		// Token: 0x17001EF3 RID: 7923
		// (get) Token: 0x0601238C RID: 74636 RVA: 0x0054E69C File Offset: 0x0054CA9C
		// (set) Token: 0x0601238D RID: 74637 RVA: 0x0054E6A4 File Offset: 0x0054CAA4
		public int ShooterId { get; private set; }

		// Token: 0x17001EF4 RID: 7924
		// (get) Token: 0x0601238E RID: 74638 RVA: 0x0054E6AD File Offset: 0x0054CAAD
		// (set) Token: 0x0601238F RID: 74639 RVA: 0x0054E6B5 File Offset: 0x0054CAB5
		public string ShooterName { get; private set; }

		// Token: 0x17001EF5 RID: 7925
		// (get) Token: 0x06012390 RID: 74640 RVA: 0x0054E6BE File Offset: 0x0054CABE
		// (set) Token: 0x06012391 RID: 74641 RVA: 0x0054E6C6 File Offset: 0x0054CAC6
		public int Stake { get; private set; }

		// Token: 0x17001EF6 RID: 7926
		// (get) Token: 0x06012392 RID: 74642 RVA: 0x0054E6CF File Offset: 0x0054CACF
		// (set) Token: 0x06012393 RID: 74643 RVA: 0x0054E6D7 File Offset: 0x0054CAD7
		public int GameId { get; private set; }

		// Token: 0x17001EF7 RID: 7927
		// (get) Token: 0x06012394 RID: 74644 RVA: 0x0054E6E0 File Offset: 0x0054CAE0
		// (set) Token: 0x06012395 RID: 74645 RVA: 0x0054E6E8 File Offset: 0x0054CAE8
		public int Profit { get; private set; }

		// Token: 0x17001EF8 RID: 7928
		// (get) Token: 0x06012396 RID: 74646 RVA: 0x0054E6F1 File Offset: 0x0054CAF1
		// (set) Token: 0x06012397 RID: 74647 RVA: 0x0054E6F9 File Offset: 0x0054CAF9
		public float Odds { get; private set; }

		// Token: 0x06012398 RID: 74648 RVA: 0x0054E702 File Offset: 0x0054CB02
		public void UpdateStake(int num)
		{
			this.Stake = num;
		}
	}
}
