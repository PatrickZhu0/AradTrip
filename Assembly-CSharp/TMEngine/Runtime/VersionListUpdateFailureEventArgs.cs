using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046E4 RID: 18148
	public sealed class VersionListUpdateFailureEventArgs : BaseEventArgs
	{
		// Token: 0x0601A063 RID: 106595 RVA: 0x0081DB5E File Offset: 0x0081BF5E
		public VersionListUpdateFailureEventArgs(string downloadURI, string errorMessage)
		{
			this.DownloadURI = downloadURI;
			this.ErrorMessage = errorMessage;
		}

		// Token: 0x170021A5 RID: 8613
		// (get) Token: 0x0601A064 RID: 106596 RVA: 0x0081DB74 File Offset: 0x0081BF74
		// (set) Token: 0x0601A065 RID: 106597 RVA: 0x0081DB7C File Offset: 0x0081BF7C
		public string DownloadURI { get; private set; }

		// Token: 0x170021A6 RID: 8614
		// (get) Token: 0x0601A066 RID: 106598 RVA: 0x0081DB85 File Offset: 0x0081BF85
		// (set) Token: 0x0601A067 RID: 106599 RVA: 0x0081DB8D File Offset: 0x0081BF8D
		public string ErrorMessage { get; private set; }
	}
}
