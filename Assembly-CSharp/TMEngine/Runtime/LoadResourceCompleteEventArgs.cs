using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200471E RID: 18206
	public sealed class LoadResourceCompleteEventArgs : BaseEventArgs
	{
		// Token: 0x0601A22B RID: 107051 RVA: 0x0082080B File Offset: 0x0081EC0B
		public LoadResourceCompleteEventArgs(object asset, bool sharedAsset)
		{
			this.Asset = asset;
			this.SharedAsset = sharedAsset;
		}

		// Token: 0x1700221A RID: 8730
		// (get) Token: 0x0601A22C RID: 107052 RVA: 0x00820821 File Offset: 0x0081EC21
		// (set) Token: 0x0601A22D RID: 107053 RVA: 0x00820829 File Offset: 0x0081EC29
		public object Asset { get; private set; }

		// Token: 0x1700221B RID: 8731
		// (get) Token: 0x0601A22E RID: 107054 RVA: 0x00820832 File Offset: 0x0081EC32
		// (set) Token: 0x0601A22F RID: 107055 RVA: 0x0082083A File Offset: 0x0081EC3A
		public bool SharedAsset { get; private set; }
	}
}
