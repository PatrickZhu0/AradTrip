using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046E8 RID: 18152
	public sealed class AssetUpdateSuccessEventArgs : BaseEventArgs
	{
		// Token: 0x0601A089 RID: 106633 RVA: 0x0081DD1C File Offset: 0x0081C11C
		public AssetUpdateSuccessEventArgs(string name, string storagePath, string downloadURI, int assetBytes, string assetMD5Sum)
		{
			this.Name = name;
			this.StoragePath = storagePath;
			this.DownloadURI = downloadURI;
			this.AssetBytes = assetBytes;
			this.AssetMD5Sum = assetMD5Sum;
		}

		// Token: 0x170021B6 RID: 8630
		// (get) Token: 0x0601A08A RID: 106634 RVA: 0x0081DD49 File Offset: 0x0081C149
		// (set) Token: 0x0601A08B RID: 106635 RVA: 0x0081DD51 File Offset: 0x0081C151
		public string Name { get; private set; }

		// Token: 0x170021B7 RID: 8631
		// (get) Token: 0x0601A08C RID: 106636 RVA: 0x0081DD5A File Offset: 0x0081C15A
		// (set) Token: 0x0601A08D RID: 106637 RVA: 0x0081DD62 File Offset: 0x0081C162
		public string StoragePath { get; private set; }

		// Token: 0x170021B8 RID: 8632
		// (get) Token: 0x0601A08E RID: 106638 RVA: 0x0081DD6B File Offset: 0x0081C16B
		// (set) Token: 0x0601A08F RID: 106639 RVA: 0x0081DD73 File Offset: 0x0081C173
		public string DownloadURI { get; private set; }

		// Token: 0x170021B9 RID: 8633
		// (get) Token: 0x0601A090 RID: 106640 RVA: 0x0081DD7C File Offset: 0x0081C17C
		// (set) Token: 0x0601A091 RID: 106641 RVA: 0x0081DD84 File Offset: 0x0081C184
		public int AssetBytes { get; private set; }

		// Token: 0x170021BA RID: 8634
		// (get) Token: 0x0601A092 RID: 106642 RVA: 0x0081DD8D File Offset: 0x0081C18D
		// (set) Token: 0x0601A093 RID: 106643 RVA: 0x0081DD95 File Offset: 0x0081C195
		public string AssetMD5Sum { get; private set; }
	}
}
