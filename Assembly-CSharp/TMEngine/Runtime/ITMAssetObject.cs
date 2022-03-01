using System;

namespace TMEngine.Runtime
{
	// Token: 0x020046CC RID: 18124
	public interface ITMAssetObject
	{
		// Token: 0x06019F47 RID: 106311
		object CreateAssetInst();

		// Token: 0x17002153 RID: 8531
		// (get) Token: 0x06019F48 RID: 106312
		bool IsWeakRefAsset { get; }

		// Token: 0x17002154 RID: 8532
		// (get) Token: 0x06019F49 RID: 106313
		bool IsInUse { get; }

		// Token: 0x17002155 RID: 8533
		// (get) Token: 0x06019F4A RID: 106314
		int SpawnCount { get; }
	}
}
