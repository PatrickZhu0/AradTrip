using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x02004716 RID: 18198
	public interface ITMReferencePoolManager
	{
		// Token: 0x170021FD RID: 8701
		// (get) Token: 0x0601A1C7 RID: 106951
		int Count { get; }

		// Token: 0x0601A1C8 RID: 106952
		bool HasReferencePool<T>() where T : Referable;

		// Token: 0x0601A1C9 RID: 106953
		bool HasReferencePool<T>(string name) where T : Referable;

		// Token: 0x0601A1CA RID: 106954
		ITMReferencePool<T> GetReferencePool<T>() where T : Referable;

		// Token: 0x0601A1CB RID: 106955
		ITMReferencePool<T> GetReferencePool<T>(string name) where T : Referable;

		// Token: 0x0601A1CC RID: 106956
		void GetAllReferencePools(List<ReferencePoolBase> objectPools);

		// Token: 0x0601A1CD RID: 106957
		void GetAllReferencePools(List<ReferencePoolBase> objectPools, bool sort);

		// Token: 0x0601A1CE RID: 106958
		ITMReferencePool<T> CreateSingleSpawnReferencePool<T>(string name) where T : Referable;

		// Token: 0x0601A1CF RID: 106959
		ITMReferencePool<T> CreateSingleSpawnReferencePool<T>(string name, int capacity, float expireTime, int priority) where T : Referable;

		// Token: 0x0601A1D0 RID: 106960
		ITMReferencePool<T> CreateMultiSpawnReferencePool<T>(string name) where T : Referable;

		// Token: 0x0601A1D1 RID: 106961
		ITMReferencePool<T> CreateMultiSpawnReferencePool<T>(string name, int capacity, float expireTime, int priority) where T : Referable;

		// Token: 0x0601A1D2 RID: 106962
		bool DestroyReferencePool<T>(string name) where T : Referable;

		// Token: 0x0601A1D3 RID: 106963
		bool DestroyReferencePool(ReferencePoolBase objectPool);

		// Token: 0x0601A1D4 RID: 106964
		void Release();

		// Token: 0x0601A1D5 RID: 106965
		void ReleaseAllUnused();
	}
}
