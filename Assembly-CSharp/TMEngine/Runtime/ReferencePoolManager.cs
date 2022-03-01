using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x02004719 RID: 18201
	internal class ReferencePoolManager : BaseModule, ITMReferencePoolManager
	{
		// Token: 0x0601A1F2 RID: 106994 RVA: 0x0081F979 File Offset: 0x0081DD79
		public ReferencePoolManager()
		{
			this.m_ObjectPools = new Dictionary<string, ReferencePoolBase>();
			this.m_TempSortedObjectPool = new List<ReferencePoolBase>(5);
		}

		// Token: 0x1700220E RID: 8718
		// (get) Token: 0x0601A1F3 RID: 106995 RVA: 0x0081F9A3 File Offset: 0x0081DDA3
		internal override int Priority
		{
			get
			{
				return 90;
			}
		}

		// Token: 0x1700220F RID: 8719
		// (get) Token: 0x0601A1F4 RID: 106996 RVA: 0x0081F9A7 File Offset: 0x0081DDA7
		public int Count
		{
			get
			{
				return this.m_ObjectPools.Count;
			}
		}

		// Token: 0x0601A1F5 RID: 106997 RVA: 0x0081F9B4 File Offset: 0x0081DDB4
		internal sealed override void Update(float elapseSeconds, float realElapseSeconds)
		{
			float perframeReleaseTime = this.m_PerframeReleaseTime;
			foreach (KeyValuePair<string, ReferencePoolBase> keyValuePair in this.m_ObjectPools)
			{
				keyValuePair.Value.Update(elapseSeconds, realElapseSeconds);
			}
		}

		// Token: 0x0601A1F6 RID: 106998 RVA: 0x0081F9FC File Offset: 0x0081DDFC
		internal sealed override void Shutdown()
		{
			foreach (KeyValuePair<string, ReferencePoolBase> keyValuePair in this.m_ObjectPools)
			{
				keyValuePair.Value.Shutdown();
			}
			this.m_ObjectPools.Clear();
		}

		// Token: 0x0601A1F7 RID: 106999 RVA: 0x0081FA68 File Offset: 0x0081DE68
		public bool HasReferencePool<T>() where T : Referable
		{
			return this.InternalHasObjectPool(Utility.Text.GetNameWithType<T>(string.Empty));
		}

		// Token: 0x0601A1F8 RID: 107000 RVA: 0x0081FA7A File Offset: 0x0081DE7A
		public bool HasReferencePool<T>(string name) where T : Referable
		{
			return this.InternalHasObjectPool(Utility.Text.GetNameWithType<T>(name));
		}

		// Token: 0x0601A1F9 RID: 107001 RVA: 0x0081FA88 File Offset: 0x0081DE88
		public ITMReferencePool<T> GetReferencePool<T>() where T : Referable
		{
			return (ITMReferencePool<T>)this.InternelGetObjectPool(Utility.Text.GetNameWithType<T>(string.Empty));
		}

		// Token: 0x0601A1FA RID: 107002 RVA: 0x0081FA9F File Offset: 0x0081DE9F
		public ITMReferencePool<T> GetReferencePool<T>(string name) where T : Referable
		{
			return (ITMReferencePool<T>)this.InternelGetObjectPool(Utility.Text.GetNameWithType<T>(name));
		}

		// Token: 0x0601A1FB RID: 107003 RVA: 0x0081FAB2 File Offset: 0x0081DEB2
		public void GetAllReferencePools(List<ReferencePoolBase> objectPools)
		{
			this.GetAllReferencePools(objectPools, false);
		}

		// Token: 0x0601A1FC RID: 107004 RVA: 0x0081FABC File Offset: 0x0081DEBC
		public void GetAllReferencePools(List<ReferencePoolBase> objectPools, bool sort)
		{
			objectPools.Clear();
			objectPools.AddRange(this.m_ObjectPools.Values);
			if (sort)
			{
				objectPools.Sort(new Comparison<ReferencePoolBase>(this.ObjectPoolComparer));
			}
		}

		// Token: 0x0601A1FD RID: 107005 RVA: 0x0081FAED File Offset: 0x0081DEED
		public ITMReferencePool<T> CreateSingleSpawnReferencePool<T>(string name) where T : Referable
		{
			return this.InternalCreateObjectPool<T>(name, false, int.MaxValue, float.MaxValue, 0);
		}

		// Token: 0x0601A1FE RID: 107006 RVA: 0x0081FB02 File Offset: 0x0081DF02
		public ITMReferencePool<T> CreateSingleSpawnReferencePool<T>(string name, int capacity, float expireTime, int priority) where T : Referable
		{
			return this.InternalCreateObjectPool<T>(name, false, capacity, expireTime, priority);
		}

		// Token: 0x0601A1FF RID: 107007 RVA: 0x0081FB10 File Offset: 0x0081DF10
		public ITMReferencePool<T> CreateMultiSpawnReferencePool<T>(string name) where T : Referable
		{
			return this.InternalCreateObjectPool<T>(name, true, int.MaxValue, float.MaxValue, 0);
		}

		// Token: 0x0601A200 RID: 107008 RVA: 0x0081FB25 File Offset: 0x0081DF25
		public ITMReferencePool<T> CreateMultiSpawnReferencePool<T>(string name, int capacity, float expireTime, int priority) where T : Referable
		{
			return this.InternalCreateObjectPool<T>(name, true, capacity, expireTime, priority);
		}

		// Token: 0x0601A201 RID: 107009 RVA: 0x0081FB33 File Offset: 0x0081DF33
		public bool DestroyReferencePool<T>(string name) where T : Referable
		{
			return this.InternalDestroyObjectPool(Utility.Text.GetNameWithType<T>(name));
		}

		// Token: 0x0601A202 RID: 107010 RVA: 0x0081FB41 File Offset: 0x0081DF41
		public bool DestroyReferencePool(ReferencePoolBase objectPool)
		{
			if (objectPool == null)
			{
				throw new TMEngineException("Object pool is invalid.");
			}
			return this.InternalDestroyObjectPool(Utility.Text.GetNameWithType(objectPool.ObjectType, objectPool.Name));
		}

		// Token: 0x0601A203 RID: 107011 RVA: 0x0081FB6C File Offset: 0x0081DF6C
		public void Release()
		{
			float perframeReleaseTime = this.m_PerframeReleaseTime;
			this.GetAllReferencePools(this.m_TempSortedObjectPool, true);
			for (int i = 0; i < this.m_TempSortedObjectPool.Count; i++)
			{
				this.m_TempSortedObjectPool[i].PurgePool(ref perframeReleaseTime);
			}
			this.m_TempSortedObjectPool.Clear();
		}

		// Token: 0x0601A204 RID: 107012 RVA: 0x0081FBC8 File Offset: 0x0081DFC8
		public void ReleaseAllUnused()
		{
			this.GetAllReferencePools(this.m_TempSortedObjectPool, true);
			for (int i = 0; i < this.m_TempSortedObjectPool.Count; i++)
			{
				this.m_TempSortedObjectPool[i].ReleaseUnusedObject(true);
			}
			this.m_TempSortedObjectPool.Clear();
		}

		// Token: 0x0601A205 RID: 107013 RVA: 0x0081FC1B File Offset: 0x0081E01B
		private bool InternalHasObjectPool(string fullName)
		{
			return this.m_ObjectPools.ContainsKey(fullName);
		}

		// Token: 0x0601A206 RID: 107014 RVA: 0x0081FC2C File Offset: 0x0081E02C
		private ReferencePoolBase InternelGetObjectPool(string fullName)
		{
			ReferencePoolBase result = null;
			if (this.m_ObjectPools.TryGetValue(fullName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0601A207 RID: 107015 RVA: 0x0081FC54 File Offset: 0x0081E054
		private ITMReferencePool<T> InternalCreateObjectPool<T>(string name, bool allowMultiSpawn, int capacity, float expireTime, int priority) where T : Referable
		{
			if (this.HasReferencePool<T>(name))
			{
				throw new TMEngineException(string.Format("Already exist object pool '{0}'.", Utility.Text.GetNameWithType<T>(name)));
			}
			ReferencePoolManager.ReferencePool<T> referencePool = new ReferencePoolManager.ReferencePool<T>(name, allowMultiSpawn, (float)Utility.Time.SecondsToTicks(expireTime), priority, capacity, 300f);
			this.m_ObjectPools.Add(Utility.Text.GetNameWithType<T>(name), referencePool);
			return referencePool;
		}

		// Token: 0x0601A208 RID: 107016 RVA: 0x0081FCB0 File Offset: 0x0081E0B0
		private bool InternalDestroyObjectPool(string fullName)
		{
			ReferencePoolBase referencePoolBase = null;
			if (this.m_ObjectPools.TryGetValue(fullName, out referencePoolBase))
			{
				referencePoolBase.Shutdown();
				return this.m_ObjectPools.Remove(fullName);
			}
			return false;
		}

		// Token: 0x0601A209 RID: 107017 RVA: 0x0081FCE8 File Offset: 0x0081E0E8
		private int ObjectPoolComparer(ReferencePoolBase a, ReferencePoolBase b)
		{
			return a.Priority.CompareTo(b.Priority);
		}

		// Token: 0x040125E0 RID: 75232
		private const int DefaultCapacity = 2147483647;

		// Token: 0x040125E1 RID: 75233
		private const float DefaultExpireTime = 3.4028235E+38f;

		// Token: 0x040125E2 RID: 75234
		private const int DefaultPriority = 0;

		// Token: 0x040125E3 RID: 75235
		private readonly Dictionary<string, ReferencePoolBase> m_ObjectPools;

		// Token: 0x040125E4 RID: 75236
		private List<ReferencePoolBase> m_TempSortedObjectPool;

		// Token: 0x040125E5 RID: 75237
		private float m_PerframeReleaseTime = 10f;

		// Token: 0x0200471A RID: 18202
		public class ReferencePool<T> : ReferencePoolBase, ITMReferencePool<T> where T : Referable
		{
			// Token: 0x0601A20A RID: 107018 RVA: 0x0081FD0C File Offset: 0x0081E10C
			public ReferencePool(string name, bool allowMultiRef, float expireTimeInSeconds, int priority, int capacity, float checkTime) : base(name)
			{
				this.m_ObjectList = new LinkedList<T>();
				this.m_RemovedCacheList = new LinkedList<T>();
				this.m_ExpireTime = Utility.Time.SecondsToTicks(expireTimeInSeconds);
				this.m_AllowMultiRef = allowMultiRef;
				this.m_Priority = priority;
				this.m_CheckTime = checkTime;
				this.m_Capacity = capacity;
			}

			// Token: 0x17002210 RID: 8720
			// (get) Token: 0x0601A20B RID: 107019 RVA: 0x0081FD61 File Offset: 0x0081E161
			public override Type ObjectType
			{
				get
				{
					return typeof(T);
				}
			}

			// Token: 0x17002211 RID: 8721
			// (get) Token: 0x0601A20C RID: 107020 RVA: 0x0081FD6D File Offset: 0x0081E16D
			public override int ObjectCount
			{
				get
				{
					return this.m_ObjectList.Count + this.m_RemovedCacheList.Count;
				}
			}

			// Token: 0x17002212 RID: 8722
			// (get) Token: 0x0601A20D RID: 107021 RVA: 0x0081FD86 File Offset: 0x0081E186
			public override int CanReleasedCount
			{
				get
				{
					return this.m_RemovedCacheList.Count;
				}
			}

			// Token: 0x17002213 RID: 8723
			// (get) Token: 0x0601A20E RID: 107022 RVA: 0x0081FD93 File Offset: 0x0081E193
			public override float ExpireTime
			{
				get
				{
					return Utility.Time.TicksToSeconds(this.m_ExpireTime);
				}
			}

			// Token: 0x17002214 RID: 8724
			// (get) Token: 0x0601A20F RID: 107023 RVA: 0x0081FDA0 File Offset: 0x0081E1A0
			public override int Capacity
			{
				get
				{
					return this.m_Capacity;
				}
			}

			// Token: 0x17002215 RID: 8725
			// (get) Token: 0x0601A210 RID: 107024 RVA: 0x0081FDA8 File Offset: 0x0081E1A8
			public override int Priority
			{
				get
				{
					return this.m_Priority;
				}
			}

			// Token: 0x17002216 RID: 8726
			// (get) Token: 0x0601A211 RID: 107025 RVA: 0x0081FDB0 File Offset: 0x0081E1B0
			public override bool AllowMultiRef
			{
				get
				{
					return this.m_AllowMultiRef;
				}
			}

			// Token: 0x17002217 RID: 8727
			// (get) Token: 0x0601A212 RID: 107026 RVA: 0x0081FDB8 File Offset: 0x0081E1B8
			public override float AutoPurgeInterval
			{
				get
				{
					return this.m_AutoPurgeInterval;
				}
			}

			// Token: 0x0601A213 RID: 107027 RVA: 0x0081FDC0 File Offset: 0x0081E1C0
			public void Register(T obj, bool withSpawn)
			{
				if (obj == null)
				{
					TMDebug.AssertFailed("Object can not be null!");
				}
				this.m_ObjectList.AddFirst(obj);
				if (withSpawn)
				{
					obj.OnSpawn();
				}
			}

			// Token: 0x0601A214 RID: 107028 RVA: 0x0081FDF8 File Offset: 0x0081E1F8
			public bool Lock(string objectKey, int lockFlag)
			{
				if (string.IsNullOrEmpty(objectKey))
				{
					TMDebug.LogWarningFormat("Object key can not be null or empty string!", new object[0]);
					return false;
				}
				int hashCode = objectKey.GetHashCode();
				for (LinkedListNode<T> linkedListNode = this.m_ObjectList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					if (hashCode == value.NameHashCode && objectKey == value.Name)
					{
						value.LockFlag = lockFlag;
						return true;
					}
				}
				return false;
			}

			// Token: 0x0601A215 RID: 107029 RVA: 0x0081FE8C File Offset: 0x0081E28C
			public bool CanSpawn(string objectKey)
			{
				if (string.IsNullOrEmpty(objectKey))
				{
					TMDebug.LogWarningFormat("Object key can not be null or empty string!", new object[0]);
					return false;
				}
				int hashCode = objectKey.GetHashCode();
				for (LinkedListNode<T> linkedListNode = this.m_RemovedCacheList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					if (hashCode == value.NameHashCode && objectKey == value.Name)
					{
						return true;
					}
				}
				if (this.m_AllowMultiRef)
				{
					for (LinkedListNode<T> linkedListNode = this.m_ObjectList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
					{
						T value = linkedListNode.Value;
						if (hashCode == value.NameHashCode && objectKey == value.Name)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0601A216 RID: 107030 RVA: 0x0081FF70 File Offset: 0x0081E370
			public T Spawn(string objectKey)
			{
				T t = this._Spawn(objectKey);
				if (t != null && !t.IsInUse)
				{
					this._Release(t);
					t = (T)((object)null);
				}
				return t;
			}

			// Token: 0x0601A217 RID: 107031 RVA: 0x0081FFB4 File Offset: 0x0081E3B4
			private T _Spawn(string objectKey)
			{
				if (string.IsNullOrEmpty(objectKey))
				{
					TMDebug.LogWarningFormat("Object key can not be null or empty string!", new object[0]);
					return (T)((object)null);
				}
				int hashCode = objectKey.GetHashCode();
				for (LinkedListNode<T> linkedListNode = this.m_RemovedCacheList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					if (hashCode == value.NameHashCode && objectKey == value.Name)
					{
						this.m_RemovedCacheList.Remove(linkedListNode);
						this.m_ObjectList.AddFirst(linkedListNode);
						TMDebug.LogDebugFormat("Object pool respawn object named with [{0}] (type:{1})", new object[]
						{
							this.ObjectType,
							value.Name
						});
						value.OnSpawn();
						return value;
					}
				}
				if (this.m_AllowMultiRef)
				{
					for (LinkedListNode<T> linkedListNode = this.m_ObjectList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
					{
						T value = linkedListNode.Value;
						if (hashCode == value.NameHashCode && objectKey == value.Name)
						{
							TMDebug.LogDebugFormat("Object pool spawn object named with [{0}] (type:{1})", new object[]
							{
								this.ObjectType,
								value.Name
							});
							value.OnSpawn();
							return value;
						}
					}
				}
				return (T)((object)null);
			}

			// Token: 0x0601A218 RID: 107032 RVA: 0x00820124 File Offset: 0x0081E524
			public void Unspawn(T removed)
			{
				if (removed == null)
				{
					TMDebug.AssertFailed("Object can not be null!");
				}
				for (LinkedListNode<T> linkedListNode = this.m_ObjectList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					if (removed.NameHashCode == value.NameHashCode && removed.Name == value.Name)
					{
						TMDebug.LogDebugFormat("Object pool unspawn object named with [{0}] (type:{1})", new object[]
						{
							this.ObjectType,
							value.Name
						});
						value.OnUnspawn();
						if (!value.IsInUse)
						{
							this.m_ObjectList.Remove(linkedListNode);
							this.m_RemovedCacheList.AddFirst(linkedListNode);
						}
						return;
					}
				}
				TMDebug.AssertFailed(string.Format("Can not find target in object pool '{0}'!", removed.Name));
			}

			// Token: 0x0601A219 RID: 107033 RVA: 0x0082022B File Offset: 0x0081E62B
			public void SetPriority(int priority)
			{
				this.m_Priority = priority;
			}

			// Token: 0x0601A21A RID: 107034 RVA: 0x00820234 File Offset: 0x0081E634
			public void SetExpireTime(float seconds)
			{
				this.m_ExpireTime = Utility.Time.SecondsToTicks(seconds);
			}

			// Token: 0x0601A21B RID: 107035 RVA: 0x00820242 File Offset: 0x0081E642
			public void SetCapacity(int capacity)
			{
				this.m_Capacity = capacity;
			}

			// Token: 0x0601A21C RID: 107036 RVA: 0x0082024B File Offset: 0x0081E64B
			public void SetAutoPurgeInterval(float autoPurgeInterval)
			{
				this.m_AutoPurgeInterval = autoPurgeInterval;
			}

			// Token: 0x0601A21D RID: 107037 RVA: 0x00820254 File Offset: 0x0081E654
			public sealed override void PurgePool(ref float timeSlice)
			{
				this._Purge(this.m_ObjectList.Count + this.m_RemovedCacheList.Count - this.m_Capacity, ref timeSlice);
			}

			// Token: 0x0601A21E RID: 107038 RVA: 0x0082027C File Offset: 0x0081E67C
			private void _Purge(int toReleaseCount, ref float remainTime)
			{
				if (this.m_RemovedCacheList.Count == 0 || remainTime <= 0f)
				{
					return;
				}
				long num = DateTime.Now.Ticks - this.m_ExpireTime;
				LinkedListNode<T> linkedListNode = this.m_RemovedCacheList.First;
				long num2 = DateTime.Now.Ticks;
				while (linkedListNode != null)
				{
					T value = linkedListNode.Value;
					LinkedListNode<T> next = linkedListNode.Next;
					if (!value.IsInUse && !value.IsLocked)
					{
						if (value.LastUseTime >= num || toReleaseCount <= 0)
						{
							break;
						}
						this.m_RemovedCacheList.Remove(linkedListNode);
						value.OnRelease();
						toReleaseCount--;
						long ticks = DateTime.Now.Ticks;
						remainTime -= Utility.Time.TicksToSeconds(ticks - num2);
						num2 = ticks;
						if (remainTime < 0f)
						{
							break;
						}
						TMDebug.LogDebugFormat("Asset pool release asset named with [{0}] (type:{1})", new object[]
						{
							this.ObjectType,
							value.Name
						});
					}
					linkedListNode = next;
				}
			}

			// Token: 0x0601A21F RID: 107039 RVA: 0x008203B8 File Offset: 0x0081E7B8
			public sealed override void ReleaseUnusedObject(bool releaseAll)
			{
				LinkedListNode<T> linkedListNode = this.m_ObjectList.First;
				while (linkedListNode != null)
				{
					T value = linkedListNode.Value;
					if (value.IsInUse || value.IsLocked)
					{
						linkedListNode = linkedListNode.Next;
					}
					else
					{
						LinkedListNode<T> next = linkedListNode.Next;
						this.m_ObjectList.Remove(linkedListNode);
						this.m_RemovedCacheList.AddFirst(linkedListNode);
						linkedListNode = next;
					}
				}
				linkedListNode = this.m_RemovedCacheList.First;
				while (linkedListNode != null)
				{
					T value = linkedListNode.Value;
					if (value.IsInUse || value.IsLocked)
					{
						linkedListNode = linkedListNode.Next;
					}
					else
					{
						LinkedListNode<T> next2 = linkedListNode.Next;
						this.m_RemovedCacheList.Remove(linkedListNode);
						T value2 = linkedListNode.Value;
						value2.OnRelease();
						TMDebug.LogDebugFormat("Object pool release object named with [{0}] (type:{1})", new object[]
						{
							this.ObjectType,
							value.Name
						});
						linkedListNode = next2;
					}
				}
			}

			// Token: 0x0601A220 RID: 107040 RVA: 0x008204D5 File Offset: 0x0081E8D5
			internal sealed override void Update(float elapseSeconds, float realElapseSeconds)
			{
			}

			// Token: 0x0601A221 RID: 107041 RVA: 0x008204D8 File Offset: 0x0081E8D8
			internal sealed override void Shutdown()
			{
				for (LinkedListNode<T> linkedListNode = this.m_RemovedCacheList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					LinkedListNode<T> next = linkedListNode.Next;
					this.m_RemovedCacheList.Remove(linkedListNode);
					T value2 = linkedListNode.Value;
					value2.OnRelease();
					TMDebug.LogDebugFormat("Object pool force release object named with [{0}] (type:{1})", new object[]
					{
						this.ObjectType,
						value.Name
					});
				}
				for (LinkedListNode<T> linkedListNode = this.m_ObjectList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					LinkedListNode<T> next2 = linkedListNode.Next;
					this.m_ObjectList.Remove(linkedListNode);
					T value3 = linkedListNode.Value;
					value3.OnRelease();
					TMDebug.LogDebugFormat("Object pool force release object named with [{0}] (type:{1})", new object[]
					{
						this.ObjectType,
						value.Name
					});
				}
			}

			// Token: 0x0601A222 RID: 107042 RVA: 0x008205D4 File Offset: 0x0081E9D4
			public sealed override ObjectDesc[] GetAllObjectInfos()
			{
				int num = 0;
				ObjectDesc[] array = new ObjectDesc[this.m_ObjectList.Count + this.m_RemovedCacheList.Count];
				for (LinkedListNode<T> linkedListNode = this.m_ObjectList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					array[num++] = new ObjectDesc(value.Name, value.IsLocked, value.LastUseTime, value.SpawnCount, true);
				}
				for (LinkedListNode<T> linkedListNode = this.m_RemovedCacheList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value2 = linkedListNode.Value;
					array[num++] = new ObjectDesc(value2.Name, value2.IsLocked, value2.LastUseTime, value2.SpawnCount, false);
				}
				return array;
			}

			// Token: 0x0601A223 RID: 107043 RVA: 0x008206E0 File Offset: 0x0081EAE0
			private void _Release(T obj)
			{
				for (LinkedListNode<T> linkedListNode = this.m_ObjectList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					T value = linkedListNode.Value;
					if (value.NameHashCode == obj.NameHashCode && value.Name == obj.Name)
					{
						if (value.IsLocked)
						{
							TMDebug.LogWarningFormat("Object pool force release asset named with [{0}] (type:{1})", new object[]
							{
								this.ObjectType,
								obj.Name
							});
						}
						this.m_ObjectList.Remove(linkedListNode);
						value.OnRelease();
						TMDebug.LogDebugFormat("Asset pool release asset named with [{0}] (type:{1})", new object[]
						{
							obj.Name,
							this.ObjectType
						});
						return;
					}
				}
			}

			// Token: 0x040125E6 RID: 75238
			private LinkedList<T> m_ObjectList;

			// Token: 0x040125E7 RID: 75239
			private LinkedList<T> m_RemovedCacheList;

			// Token: 0x040125E8 RID: 75240
			private long m_ExpireTime;

			// Token: 0x040125E9 RID: 75241
			private int m_Priority;

			// Token: 0x040125EA RID: 75242
			private float m_CheckTime;

			// Token: 0x040125EB RID: 75243
			private float m_AutoPurgeInterval;

			// Token: 0x040125EC RID: 75244
			private readonly bool m_AllowMultiRef;

			// Token: 0x040125ED RID: 75245
			private int m_Capacity;
		}
	}
}
