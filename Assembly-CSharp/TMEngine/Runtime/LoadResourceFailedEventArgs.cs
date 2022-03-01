using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200471F RID: 18207
	public sealed class LoadResourceFailedEventArgs : BaseEventArgs
	{
		// Token: 0x0601A230 RID: 107056 RVA: 0x00820843 File Offset: 0x0081EC43
		public LoadResourceFailedEventArgs(AssetLoadErrorCode errorCode, string msg)
		{
			this.ErrorCode = errorCode;
			this.Message = msg;
		}

		// Token: 0x1700221C RID: 8732
		// (get) Token: 0x0601A231 RID: 107057 RVA: 0x00820859 File Offset: 0x0081EC59
		// (set) Token: 0x0601A232 RID: 107058 RVA: 0x00820861 File Offset: 0x0081EC61
		public AssetLoadErrorCode ErrorCode { get; private set; }

		// Token: 0x1700221D RID: 8733
		// (get) Token: 0x0601A233 RID: 107059 RVA: 0x0082086A File Offset: 0x0081EC6A
		// (set) Token: 0x0601A234 RID: 107060 RVA: 0x00820872 File Offset: 0x0081EC72
		public string Message { get; private set; }
	}
}
