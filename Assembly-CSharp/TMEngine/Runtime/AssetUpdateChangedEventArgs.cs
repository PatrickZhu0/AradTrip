using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046E7 RID: 18151
	public sealed class AssetUpdateChangedEventArgs : BaseEventArgs
	{
		// Token: 0x0601A07E RID: 106622 RVA: 0x0081DC9A File Offset: 0x0081C09A
		public AssetUpdateChangedEventArgs(string name, string storagePath, string downloadURI, int downloadedBytes, int totalBytes)
		{
			this.Name = name;
			this.StoragePath = storagePath;
			this.DownloadURI = downloadURI;
			this.DownloadedBytes = downloadedBytes;
			this.TotalBytes = totalBytes;
		}

		// Token: 0x170021B1 RID: 8625
		// (get) Token: 0x0601A07F RID: 106623 RVA: 0x0081DCC7 File Offset: 0x0081C0C7
		// (set) Token: 0x0601A080 RID: 106624 RVA: 0x0081DCCF File Offset: 0x0081C0CF
		public string Name { get; private set; }

		// Token: 0x170021B2 RID: 8626
		// (get) Token: 0x0601A081 RID: 106625 RVA: 0x0081DCD8 File Offset: 0x0081C0D8
		// (set) Token: 0x0601A082 RID: 106626 RVA: 0x0081DCE0 File Offset: 0x0081C0E0
		public string StoragePath { get; private set; }

		// Token: 0x170021B3 RID: 8627
		// (get) Token: 0x0601A083 RID: 106627 RVA: 0x0081DCE9 File Offset: 0x0081C0E9
		// (set) Token: 0x0601A084 RID: 106628 RVA: 0x0081DCF1 File Offset: 0x0081C0F1
		public string DownloadURI { get; private set; }

		// Token: 0x170021B4 RID: 8628
		// (get) Token: 0x0601A085 RID: 106629 RVA: 0x0081DCFA File Offset: 0x0081C0FA
		// (set) Token: 0x0601A086 RID: 106630 RVA: 0x0081DD02 File Offset: 0x0081C102
		public int DownloadedBytes { get; private set; }

		// Token: 0x170021B5 RID: 8629
		// (get) Token: 0x0601A087 RID: 106631 RVA: 0x0081DD0B File Offset: 0x0081C10B
		// (set) Token: 0x0601A088 RID: 106632 RVA: 0x0081DD13 File Offset: 0x0081C113
		public int TotalBytes { get; private set; }
	}
}
