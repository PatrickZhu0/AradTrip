using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200471D RID: 18205
	public sealed class LoadResourceUpdateEventArgs : BaseEventArgs
	{
		// Token: 0x0601A226 RID: 107046 RVA: 0x008207D3 File Offset: 0x0081EBD3
		public LoadResourceUpdateEventArgs(ResourceLoadMode mode, float progress)
		{
			this.Mode = mode;
			this.Progress = progress;
		}

		// Token: 0x17002218 RID: 8728
		// (get) Token: 0x0601A227 RID: 107047 RVA: 0x008207E9 File Offset: 0x0081EBE9
		// (set) Token: 0x0601A228 RID: 107048 RVA: 0x008207F1 File Offset: 0x0081EBF1
		public ResourceLoadMode Mode { get; private set; }

		// Token: 0x17002219 RID: 8729
		// (get) Token: 0x0601A229 RID: 107049 RVA: 0x008207FA File Offset: 0x0081EBFA
		// (set) Token: 0x0601A22A RID: 107050 RVA: 0x00820802 File Offset: 0x0081EC02
		public float Progress { get; private set; }
	}
}
