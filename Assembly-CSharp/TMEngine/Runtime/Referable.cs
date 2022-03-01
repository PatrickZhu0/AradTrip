using System;

namespace TMEngine.Runtime
{
	// Token: 0x02004717 RID: 18199
	public abstract class Referable
	{
		// Token: 0x0601A1D7 RID: 106967
		public abstract void OnSpawn();

		// Token: 0x0601A1D8 RID: 106968
		public abstract void OnUnspawn();

		// Token: 0x0601A1D9 RID: 106969
		public abstract void OnRelease();

		// Token: 0x170021FE RID: 8702
		// (get) Token: 0x0601A1DA RID: 106970
		public abstract string Name { get; }

		// Token: 0x170021FF RID: 8703
		// (get) Token: 0x0601A1DB RID: 106971
		public abstract int NameHashCode { get; }

		// Token: 0x17002200 RID: 8704
		// (get) Token: 0x0601A1DC RID: 106972
		public abstract bool IsInUse { get; }

		// Token: 0x17002201 RID: 8705
		// (get) Token: 0x0601A1DD RID: 106973
		public abstract bool IsLocked { get; }

		// Token: 0x17002202 RID: 8706
		// (get) Token: 0x0601A1DE RID: 106974
		// (set) Token: 0x0601A1DF RID: 106975
		public abstract int LockFlag { get; set; }

		// Token: 0x17002203 RID: 8707
		// (get) Token: 0x0601A1E0 RID: 106976
		public abstract long LastUseTime { get; }

		// Token: 0x17002204 RID: 8708
		// (get) Token: 0x0601A1E1 RID: 106977
		public abstract int SpawnCount { get; }
	}
}
