using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046E3 RID: 18147
	public sealed class VersionListUpdateSuccessEventArgs : BaseEventArgs
	{
		// Token: 0x0601A05E RID: 106590 RVA: 0x0081DB26 File Offset: 0x0081BF26
		public VersionListUpdateSuccessEventArgs(string storagePath, string downloadURI)
		{
			this.StoragePath = storagePath;
			this.DownloadURI = downloadURI;
		}

		// Token: 0x170021A3 RID: 8611
		// (get) Token: 0x0601A05F RID: 106591 RVA: 0x0081DB3C File Offset: 0x0081BF3C
		// (set) Token: 0x0601A060 RID: 106592 RVA: 0x0081DB44 File Offset: 0x0081BF44
		public string StoragePath { get; private set; }

		// Token: 0x170021A4 RID: 8612
		// (get) Token: 0x0601A061 RID: 106593 RVA: 0x0081DB4D File Offset: 0x0081BF4D
		// (set) Token: 0x0601A062 RID: 106594 RVA: 0x0081DB55 File Offset: 0x0081BF55
		public string DownloadURI { get; private set; }
	}
}
