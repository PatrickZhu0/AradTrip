using System;

namespace TMEngine.Runtime
{
	// Token: 0x02004720 RID: 18208
	public sealed class LoadPackageCompleteEventArgs : BaseEventArgs
	{
		// Token: 0x0601A235 RID: 107061 RVA: 0x0082087B File Offset: 0x0081EC7B
		public LoadPackageCompleteEventArgs(object package)
		{
			this.Package = package;
		}

		// Token: 0x1700221E RID: 8734
		// (get) Token: 0x0601A236 RID: 107062 RVA: 0x0082088A File Offset: 0x0081EC8A
		// (set) Token: 0x0601A237 RID: 107063 RVA: 0x00820892 File Offset: 0x0081EC92
		public object Package { get; private set; }
	}
}
