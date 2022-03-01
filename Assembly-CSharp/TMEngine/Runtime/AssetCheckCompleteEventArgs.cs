using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046E5 RID: 18149
	public sealed class AssetCheckCompleteEventArgs : BaseEventArgs
	{
		// Token: 0x0601A068 RID: 106600 RVA: 0x0081DB96 File Offset: 0x0081BF96
		public AssetCheckCompleteEventArgs(int removeCount, int updateCount, int updateTotalBytes, int updateTotalZipBytes)
		{
			this.RemoveCount = removeCount;
			this.UpdateCount = updateCount;
			this.UpdateTotalBytes = updateTotalBytes;
			this.UpdateTotalZipBytes = updateTotalZipBytes;
		}

		// Token: 0x170021A7 RID: 8615
		// (get) Token: 0x0601A069 RID: 106601 RVA: 0x0081DBBB File Offset: 0x0081BFBB
		// (set) Token: 0x0601A06A RID: 106602 RVA: 0x0081DBC3 File Offset: 0x0081BFC3
		public int RemoveCount { get; private set; }

		// Token: 0x170021A8 RID: 8616
		// (get) Token: 0x0601A06B RID: 106603 RVA: 0x0081DBCC File Offset: 0x0081BFCC
		// (set) Token: 0x0601A06C RID: 106604 RVA: 0x0081DBD4 File Offset: 0x0081BFD4
		public int UpdateCount { get; private set; }

		// Token: 0x170021A9 RID: 8617
		// (get) Token: 0x0601A06D RID: 106605 RVA: 0x0081DBDD File Offset: 0x0081BFDD
		// (set) Token: 0x0601A06E RID: 106606 RVA: 0x0081DBE5 File Offset: 0x0081BFE5
		public int UpdateTotalBytes { get; private set; }

		// Token: 0x170021AA RID: 8618
		// (get) Token: 0x0601A06F RID: 106607 RVA: 0x0081DBEE File Offset: 0x0081BFEE
		// (set) Token: 0x0601A070 RID: 106608 RVA: 0x0081DBF6 File Offset: 0x0081BFF6
		public int UpdateTotalZipBytes { get; private set; }
	}
}
