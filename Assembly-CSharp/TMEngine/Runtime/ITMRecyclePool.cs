using System;

namespace TMEngine.Runtime
{
	// Token: 0x0200470C RID: 18188
	public interface ITMRecyclePool<T> where T : Recyclable, new()
	{
		// Token: 0x170021DF RID: 8671
		// (get) Token: 0x0601A16E RID: 106862
		int ReserveCount { get; }

		// Token: 0x170021E0 RID: 8672
		// (get) Token: 0x0601A16F RID: 106863
		int UnusedObjectCount { get; }

		// Token: 0x170021E1 RID: 8673
		// (get) Token: 0x0601A170 RID: 106864
		int UsingObjectCount { get; }

		// Token: 0x170021E2 RID: 8674
		// (get) Token: 0x0601A171 RID: 106865
		int AcquireCount { get; }

		// Token: 0x170021E3 RID: 8675
		// (get) Token: 0x0601A172 RID: 106866
		int RecycleCount { get; }

		// Token: 0x170021E4 RID: 8676
		// (get) Token: 0x0601A173 RID: 106867
		int CreateCount { get; }

		// Token: 0x170021E5 RID: 8677
		// (get) Token: 0x0601A174 RID: 106868
		int ReleaseCount { get; }

		// Token: 0x0601A175 RID: 106869
		void SetReserveCount(int reserveCount);

		// Token: 0x0601A176 RID: 106870
		void SetExpireTime(float expireTime);

		// Token: 0x0601A177 RID: 106871
		void SetPriority(int priority);

		// Token: 0x0601A178 RID: 106872
		T Acquire();

		// Token: 0x0601A179 RID: 106873
		void Recycle(T obj);

		// Token: 0x0601A17A RID: 106874
		void PurgePool(bool clearAll);
	}
}
