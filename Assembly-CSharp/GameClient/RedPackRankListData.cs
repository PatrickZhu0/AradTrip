using System;

namespace GameClient
{
	// Token: 0x020019DB RID: 6619
	internal class RedPackRankListData : IComparable<RedPackRankListData>
	{
		// Token: 0x17001D30 RID: 7472
		// (get) Token: 0x06010377 RID: 66423 RVA: 0x00489108 File Offset: 0x00487508
		// (set) Token: 0x06010378 RID: 66424 RVA: 0x00489110 File Offset: 0x00487510
		public int rank { get; set; }

		// Token: 0x17001D31 RID: 7473
		// (get) Token: 0x06010379 RID: 66425 RVA: 0x00489119 File Offset: 0x00487519
		// (set) Token: 0x0601037A RID: 66426 RVA: 0x00489121 File Offset: 0x00487521
		public int zone_id { get; set; }

		// Token: 0x17001D32 RID: 7474
		// (get) Token: 0x0601037B RID: 66427 RVA: 0x0048912A File Offset: 0x0048752A
		// (set) Token: 0x0601037C RID: 66428 RVA: 0x00489132 File Offset: 0x00487532
		public int acc_id { get; set; }

		// Token: 0x17001D33 RID: 7475
		// (get) Token: 0x0601037D RID: 66429 RVA: 0x0048913B File Offset: 0x0048753B
		// (set) Token: 0x0601037E RID: 66430 RVA: 0x00489143 File Offset: 0x00487543
		public string role_id { get; set; }

		// Token: 0x17001D34 RID: 7476
		// (get) Token: 0x0601037F RID: 66431 RVA: 0x0048914C File Offset: 0x0048754C
		// (set) Token: 0x06010380 RID: 66432 RVA: 0x00489154 File Offset: 0x00487554
		public int total_money { get; set; }

		// Token: 0x17001D35 RID: 7477
		// (get) Token: 0x06010381 RID: 66433 RVA: 0x0048915D File Offset: 0x0048755D
		// (set) Token: 0x06010382 RID: 66434 RVA: 0x00489165 File Offset: 0x00487565
		public string role_name { get; set; }

		// Token: 0x17001D36 RID: 7478
		// (get) Token: 0x06010383 RID: 66435 RVA: 0x0048916E File Offset: 0x0048756E
		// (set) Token: 0x06010384 RID: 66436 RVA: 0x00489176 File Offset: 0x00487576
		public string server_name { get; set; }

		// Token: 0x06010385 RID: 66437 RVA: 0x0048917F File Offset: 0x0048757F
		public int CompareTo(RedPackRankListData other)
		{
			return this.rank - other.rank;
		}
	}
}
