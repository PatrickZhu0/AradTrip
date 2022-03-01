using System;

namespace TMEngine.Runtime
{
	// Token: 0x02004715 RID: 18197
	public interface ITMReferencePool<T> where T : Referable
	{
		// Token: 0x170021F5 RID: 8693
		// (get) Token: 0x0601A1B3 RID: 106931
		string Name { get; }

		// Token: 0x170021F6 RID: 8694
		// (get) Token: 0x0601A1B4 RID: 106932
		Type ObjectType { get; }

		// Token: 0x170021F7 RID: 8695
		// (get) Token: 0x0601A1B5 RID: 106933
		int ObjectCount { get; }

		// Token: 0x170021F8 RID: 8696
		// (get) Token: 0x0601A1B6 RID: 106934
		int CanReleasedCount { get; }

		// Token: 0x170021F9 RID: 8697
		// (get) Token: 0x0601A1B7 RID: 106935
		float ExpireTime { get; }

		// Token: 0x170021FA RID: 8698
		// (get) Token: 0x0601A1B8 RID: 106936
		float AutoPurgeInterval { get; }

		// Token: 0x170021FB RID: 8699
		// (get) Token: 0x0601A1B9 RID: 106937
		int Priority { get; }

		// Token: 0x170021FC RID: 8700
		// (get) Token: 0x0601A1BA RID: 106938
		int Capacity { get; }

		// Token: 0x0601A1BB RID: 106939
		void Register(T obj, bool withSpawn);

		// Token: 0x0601A1BC RID: 106940
		bool CanSpawn(string objectKey);

		// Token: 0x0601A1BD RID: 106941
		bool Lock(string objectKey, int lockFlag);

		// Token: 0x0601A1BE RID: 106942
		T Spawn(string objectKey);

		// Token: 0x0601A1BF RID: 106943
		void Unspawn(T obj);

		// Token: 0x0601A1C0 RID: 106944
		void SetPriority(int priority);

		// Token: 0x0601A1C1 RID: 106945
		void SetExpireTime(float seconds);

		// Token: 0x0601A1C2 RID: 106946
		void SetCapacity(int capacity);

		// Token: 0x0601A1C3 RID: 106947
		void SetAutoPurgeInterval(float autoPurgeInterval);

		// Token: 0x0601A1C4 RID: 106948
		void PurgePool(ref float timeSlice);

		// Token: 0x0601A1C5 RID: 106949
		void ReleaseUnusedObject(bool releaseAll);

		// Token: 0x0601A1C6 RID: 106950
		ObjectDesc[] GetAllObjectInfos();
	}
}
