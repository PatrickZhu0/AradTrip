using System;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004726 RID: 18214
	public struct UnityGameObjectPoolInfo
	{
		// Token: 0x0601A258 RID: 107096 RVA: 0x00820B2C File Offset: 0x0081EF2C
		public UnityGameObjectPoolInfo(string prefabRes, GameObjectUsage usage, int reserveCount, float expireTime, int priority, int unusedObjectCount, int usingObjectCount, int acquireCount, int recycleCount, int createCount, int releaseCount)
		{
			this.m_PrefabResPath = prefabRes;
			this.m_ObjectUsage = usage;
			this.m_ReserveCount = reserveCount;
			this.m_ExpireTime = expireTime;
			this.m_Priority = priority;
			this.m_UnusedObjectCount = unusedObjectCount;
			this.m_UsingObjectCount = usingObjectCount;
			this.m_AcquireCount = acquireCount;
			this.m_RecycleCount = recycleCount;
			this.m_CreateCount = createCount;
			this.m_ReleaseCount = releaseCount;
		}

		// Token: 0x04012602 RID: 75266
		public string m_PrefabResPath;

		// Token: 0x04012603 RID: 75267
		public GameObjectUsage m_ObjectUsage;

		// Token: 0x04012604 RID: 75268
		public int m_ReserveCount;

		// Token: 0x04012605 RID: 75269
		public float m_ExpireTime;

		// Token: 0x04012606 RID: 75270
		public int m_Priority;

		// Token: 0x04012607 RID: 75271
		public int m_UnusedObjectCount;

		// Token: 0x04012608 RID: 75272
		public int m_UsingObjectCount;

		// Token: 0x04012609 RID: 75273
		public int m_AcquireCount;

		// Token: 0x0401260A RID: 75274
		public int m_RecycleCount;

		// Token: 0x0401260B RID: 75275
		public int m_CreateCount;

		// Token: 0x0401260C RID: 75276
		public int m_ReleaseCount;
	}
}
