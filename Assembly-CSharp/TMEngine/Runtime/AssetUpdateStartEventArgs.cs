using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046E6 RID: 18150
	public sealed class AssetUpdateStartEventArgs : BaseEventArgs
	{
		// Token: 0x0601A071 RID: 106609 RVA: 0x0081DBFF File Offset: 0x0081BFFF
		public AssetUpdateStartEventArgs(string name, string storagePath, string downloadURI, int downloadedBytes, int totalBytes, int retryCount)
		{
			this.Name = name;
			this.StoragePath = storagePath;
			this.DownloadURI = downloadURI;
			this.DownloadedBytes = downloadedBytes;
			this.TotalBytes = totalBytes;
			this.RetryCount = retryCount;
		}

		// Token: 0x170021AB RID: 8619
		// (get) Token: 0x0601A072 RID: 106610 RVA: 0x0081DC34 File Offset: 0x0081C034
		// (set) Token: 0x0601A073 RID: 106611 RVA: 0x0081DC3C File Offset: 0x0081C03C
		public string Name { get; private set; }

		// Token: 0x170021AC RID: 8620
		// (get) Token: 0x0601A074 RID: 106612 RVA: 0x0081DC45 File Offset: 0x0081C045
		// (set) Token: 0x0601A075 RID: 106613 RVA: 0x0081DC4D File Offset: 0x0081C04D
		public string StoragePath { get; private set; }

		// Token: 0x170021AD RID: 8621
		// (get) Token: 0x0601A076 RID: 106614 RVA: 0x0081DC56 File Offset: 0x0081C056
		// (set) Token: 0x0601A077 RID: 106615 RVA: 0x0081DC5E File Offset: 0x0081C05E
		public string DownloadURI { get; private set; }

		// Token: 0x170021AE RID: 8622
		// (get) Token: 0x0601A078 RID: 106616 RVA: 0x0081DC67 File Offset: 0x0081C067
		// (set) Token: 0x0601A079 RID: 106617 RVA: 0x0081DC6F File Offset: 0x0081C06F
		public int DownloadedBytes { get; private set; }

		// Token: 0x170021AF RID: 8623
		// (get) Token: 0x0601A07A RID: 106618 RVA: 0x0081DC78 File Offset: 0x0081C078
		// (set) Token: 0x0601A07B RID: 106619 RVA: 0x0081DC80 File Offset: 0x0081C080
		public int TotalBytes { get; private set; }

		// Token: 0x170021B0 RID: 8624
		// (get) Token: 0x0601A07C RID: 106620 RVA: 0x0081DC89 File Offset: 0x0081C089
		// (set) Token: 0x0601A07D RID: 106621 RVA: 0x0081DC91 File Offset: 0x0081C091
		public int RetryCount { get; private set; }
	}
}
