using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046E9 RID: 18153
	public sealed class AssetUpdateFailureEventArgs : BaseEventArgs
	{
		// Token: 0x0601A094 RID: 106644 RVA: 0x0081DD9E File Offset: 0x0081C19E
		public AssetUpdateFailureEventArgs(string name, string downloadURI, int retryCount, int targetRetryCount, string errorMessage)
		{
			this.Name = name;
			this.DownloadURI = downloadURI;
			this.RetryCount = retryCount;
			this.TargetRetryCount = targetRetryCount;
			this.ErrorMessage = errorMessage;
		}

		// Token: 0x170021BB RID: 8635
		// (get) Token: 0x0601A095 RID: 106645 RVA: 0x0081DDCB File Offset: 0x0081C1CB
		// (set) Token: 0x0601A096 RID: 106646 RVA: 0x0081DDD3 File Offset: 0x0081C1D3
		public string Name { get; private set; }

		// Token: 0x170021BC RID: 8636
		// (get) Token: 0x0601A097 RID: 106647 RVA: 0x0081DDDC File Offset: 0x0081C1DC
		// (set) Token: 0x0601A098 RID: 106648 RVA: 0x0081DDE4 File Offset: 0x0081C1E4
		public string DownloadURI { get; private set; }

		// Token: 0x170021BD RID: 8637
		// (get) Token: 0x0601A099 RID: 106649 RVA: 0x0081DDED File Offset: 0x0081C1ED
		// (set) Token: 0x0601A09A RID: 106650 RVA: 0x0081DDF5 File Offset: 0x0081C1F5
		public int RetryCount { get; private set; }

		// Token: 0x170021BE RID: 8638
		// (get) Token: 0x0601A09B RID: 106651 RVA: 0x0081DDFE File Offset: 0x0081C1FE
		// (set) Token: 0x0601A09C RID: 106652 RVA: 0x0081DE06 File Offset: 0x0081C206
		public int TargetRetryCount { get; private set; }

		// Token: 0x170021BF RID: 8639
		// (get) Token: 0x0601A09D RID: 106653 RVA: 0x0081DE0F File Offset: 0x0081C20F
		// (set) Token: 0x0601A09E RID: 106654 RVA: 0x0081DE17 File Offset: 0x0081C217
		public string ErrorMessage { get; private set; }
	}
}
