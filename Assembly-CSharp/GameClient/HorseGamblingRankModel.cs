using System;
using System.Runtime.InteropServices;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CF7 RID: 7415
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HorseGamblingRankModel
	{
		// Token: 0x060123A4 RID: 74660 RVA: 0x0054E7DC File Offset: 0x0054CBDC
		public HorseGamblingRankModel(shooterRankInfo msg)
		{
			this = default(HorseGamblingRankModel);
			BetHorseShooter tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BetHorseShooter>((int)msg.shooterId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.ShooterName = tableItem.Name;
			}
			this.ShooterId = (int)msg.shooterId;
			this.BattleNum = msg.battleNum;
			this.WinRate = msg.winRate / 100f;
		}

		// Token: 0x17001EFE RID: 7934
		// (get) Token: 0x060123A5 RID: 74661 RVA: 0x0054E849 File Offset: 0x0054CC49
		// (set) Token: 0x060123A6 RID: 74662 RVA: 0x0054E851 File Offset: 0x0054CC51
		public string ShooterName { get; private set; }

		// Token: 0x17001EFF RID: 7935
		// (get) Token: 0x060123A7 RID: 74663 RVA: 0x0054E85A File Offset: 0x0054CC5A
		// (set) Token: 0x060123A8 RID: 74664 RVA: 0x0054E862 File Offset: 0x0054CC62
		public uint BattleNum { get; private set; }

		// Token: 0x17001F00 RID: 7936
		// (get) Token: 0x060123A9 RID: 74665 RVA: 0x0054E86B File Offset: 0x0054CC6B
		// (set) Token: 0x060123AA RID: 74666 RVA: 0x0054E873 File Offset: 0x0054CC73
		public float WinRate { get; private set; }

		// Token: 0x17001F01 RID: 7937
		// (get) Token: 0x060123AB RID: 74667 RVA: 0x0054E87C File Offset: 0x0054CC7C
		// (set) Token: 0x060123AC RID: 74668 RVA: 0x0054E884 File Offset: 0x0054CC84
		public int ShooterId { get; private set; }

		// Token: 0x0400BD99 RID: 48537
		private const int WIN_RATE_TO_PERCENT = 100;
	}
}
