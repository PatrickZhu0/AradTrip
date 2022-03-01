using System;

namespace GameClient
{
	// Token: 0x020011E4 RID: 4580
	public class AuctionFreezeRemindData
	{
		// Token: 0x17001AB9 RID: 6841
		// (get) Token: 0x0600B03F RID: 45119 RVA: 0x0026BEE3 File Offset: 0x0026A2E3
		// (set) Token: 0x0600B040 RID: 45120 RVA: 0x0026BEEB File Offset: 0x0026A2EB
		public uint frozenMoneyType { get; set; }

		// Token: 0x17001ABA RID: 6842
		// (get) Token: 0x0600B041 RID: 45121 RVA: 0x0026BEF4 File Offset: 0x0026A2F4
		// (set) Token: 0x0600B042 RID: 45122 RVA: 0x0026BEFC File Offset: 0x0026A2FC
		public uint frozenAmount { get; set; }

		// Token: 0x17001ABB RID: 6843
		// (get) Token: 0x0600B043 RID: 45123 RVA: 0x0026BF05 File Offset: 0x0026A305
		// (set) Token: 0x0600B044 RID: 45124 RVA: 0x0026BF0D File Offset: 0x0026A30D
		public uint abnormalTransactionTime { get; set; }

		// Token: 0x17001ABC RID: 6844
		// (get) Token: 0x0600B045 RID: 45125 RVA: 0x0026BF16 File Offset: 0x0026A316
		// (set) Token: 0x0600B046 RID: 45126 RVA: 0x0026BF1E File Offset: 0x0026A31E
		public uint terminationOfBail { get; set; }

		// Token: 0x17001ABD RID: 6845
		// (get) Token: 0x0600B047 RID: 45127 RVA: 0x0026BF27 File Offset: 0x0026A327
		// (set) Token: 0x0600B048 RID: 45128 RVA: 0x0026BF2F File Offset: 0x0026A32F
		public uint remainingBailPeriod { get; set; }

		// Token: 0x17001ABE RID: 6846
		// (get) Token: 0x0600B049 RID: 45129 RVA: 0x0026BF38 File Offset: 0x0026A338
		// (set) Token: 0x0600B04A RID: 45130 RVA: 0x0026BF40 File Offset: 0x0026A340
		public uint backAmount { get; set; }

		// Token: 0x17001ABF RID: 6847
		// (get) Token: 0x0600B04B RID: 45131 RVA: 0x0026BF49 File Offset: 0x0026A349
		// (set) Token: 0x0600B04C RID: 45132 RVA: 0x0026BF51 File Offset: 0x0026A351
		public uint backDays { get; set; }
	}
}
