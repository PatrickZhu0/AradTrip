using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x02004712 RID: 18194
	internal class RecyclePoolManager : BaseModule, ITMRecyclePoolManager
	{
		// Token: 0x0601A1A2 RID: 106914 RVA: 0x0081F3A2 File Offset: 0x0081D7A2
		public RecyclePoolManager()
		{
			this.m_RecyclePoolList = new LinkedList<RecyclePoolManager.RecyclePoolDesc>();
		}

		// Token: 0x170021F3 RID: 8691
		// (get) Token: 0x0601A1A3 RID: 106915 RVA: 0x0081F3B5 File Offset: 0x0081D7B5
		internal override int Priority
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0601A1A4 RID: 106916 RVA: 0x0081F3B8 File Offset: 0x0081D7B8
		public RecyclePoolBase CreateRecyclePool<T>(CreateRecyclable onCreateAction) where T : Recyclable, new()
		{
			Type typeFromHandle = typeof(T);
			RecyclePoolBase recyclePoolBase = new RecyclePoolManager.RecyclePool<T>(this.m_RecyclePoolAllocCount++, onCreateAction, 3);
			this.m_RecyclePoolList.AddLast(new RecyclePoolManager.RecyclePoolDesc(recyclePoolBase, typeFromHandle, recyclePoolBase.GetType()));
			return recyclePoolBase;
		}

		// Token: 0x0601A1A5 RID: 106917 RVA: 0x0081F404 File Offset: 0x0081D804
		public void DestroyRecyclePool(RecyclePoolBase objPoolBase)
		{
			if (objPoolBase == null)
			{
				TMDebug.LogWarningFormat("Pool instance can not be null!", new object[0]);
				return;
			}
			for (LinkedListNode<RecyclePoolManager.RecyclePoolDesc> linkedListNode = this.m_RecyclePoolList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				RecyclePoolManager.RecyclePoolDesc value = linkedListNode.Value;
				if (value.m_RecyclePool.PoolID == objPoolBase.PoolID)
				{
					value.m_RecyclePool.Shutdown();
					this.m_RecyclePoolList.Remove(linkedListNode);
					return;
				}
			}
			TMDebug.AssertFailed(string.Format("Can not find pool instance of specific pool!(ID:{0})", objPoolBase.PoolID));
		}

		// Token: 0x0601A1A6 RID: 106918 RVA: 0x0081F495 File Offset: 0x0081D895
		internal override void Update(float elapseSeconds, float realElapseSeconds)
		{
		}

		// Token: 0x0601A1A7 RID: 106919 RVA: 0x0081F498 File Offset: 0x0081D898
		internal override void Shutdown()
		{
			LinkedListNode<RecyclePoolManager.RecyclePoolDesc> next;
			for (LinkedListNode<RecyclePoolManager.RecyclePoolDesc> linkedListNode = this.m_RecyclePoolList.First; linkedListNode != null; linkedListNode = next)
			{
				RecyclePoolManager.RecyclePoolDesc value = linkedListNode.Value;
				next = linkedListNode.Next;
				value.m_RecyclePool.Shutdown();
				this.m_RecyclePoolList.Remove(linkedListNode);
			}
		}

		// Token: 0x0601A1A8 RID: 106920 RVA: 0x0081F4E4 File Offset: 0x0081D8E4
		private RecyclePoolBase _GetRecyclePool<T>(int poolID, CreateRecyclable onCreateAction) where T : Recyclable, new()
		{
			RecyclePoolBase recyclePoolBase = null;
			Type typeFromHandle = typeof(T);
			LinkedListNode<RecyclePoolManager.RecyclePoolDesc> linkedListNode = this.m_RecyclePoolList.First;
			while (linkedListNode != null)
			{
				RecyclePoolManager.RecyclePoolDesc value = linkedListNode.Value;
				if (value.m_RecyclableType == typeFromHandle && (poolID == -1 || value.m_RecyclePool.PoolID == poolID))
				{
					recyclePoolBase = value.m_RecyclePool;
					if (recyclePoolBase == null)
					{
						TMDebug.LogErrorFormat("Recycle pool type cast error! Required type:'{0}' Source type:'{1}'!", new object[]
						{
							typeFromHandle.Name,
							recyclePoolBase.GetType().Name
						});
						return null;
					}
					return recyclePoolBase;
				}
				else
				{
					linkedListNode = linkedListNode.Next;
				}
			}
			if (poolID == -1)
			{
				return this.CreateRecyclePool<T>(onCreateAction);
			}
			TMDebug.LogErrorFormat("Can not find recycle pool with ID '{0}' type '{1}'!", new object[]
			{
				poolID,
				recyclePoolBase.GetType().Name
			});
			return null;
		}

		// Token: 0x040125D7 RID: 75223
		public const int CONST_INVALID_POOL_ID = -1;

		// Token: 0x040125D8 RID: 75224
		private readonly LinkedList<RecyclePoolManager.RecyclePoolDesc> m_RecyclePoolList;

		// Token: 0x040125D9 RID: 75225
		private int m_RecyclePoolAllocCount;

		// Token: 0x02004713 RID: 18195
		private class RecyclePool<T> : RecyclePoolBase, ITMRecyclePool<T> where T : Recyclable, new()
		{
			// Token: 0x0601A1A9 RID: 106921 RVA: 0x0081F5B6 File Offset: 0x0081D9B6
			public RecyclePool(int poolID, CreateRecyclable createAction, int reserveCount = 3) : base(poolID, reserveCount)
			{
				this.m_RecyclableObjects = new Queue<T>();
				this.m_CreateAction = createAction;
			}

			// Token: 0x170021F4 RID: 8692
			// (get) Token: 0x0601A1AA RID: 106922 RVA: 0x0081F5D2 File Offset: 0x0081D9D2
			public sealed override int UnusedObjectCount
			{
				get
				{
					return this.m_RecyclableObjects.Count;
				}
			}

			// Token: 0x0601A1AB RID: 106923 RVA: 0x0081F5E0 File Offset: 0x0081D9E0
			public T Acquire()
			{
				T t = this._AquireRecycledObject();
				if (t != null)
				{
					TMDebug.Assert(t.IsRecycled, "Recyclable object '{0}' recycle state [Unrecycled] is wrong!", new object[]
					{
						t.Name
					});
					t.OnReuse();
					return t;
				}
				this.m_CreateCount++;
				if (this.m_CreateAction != null)
				{
					t = (this.m_CreateAction() as T);
				}
				else
				{
					t = Activator.CreateInstance<T>();
				}
				if (t != null)
				{
					t.OnCreate();
				}
				return t;
			}

			// Token: 0x0601A1AC RID: 106924 RVA: 0x0081F690 File Offset: 0x0081DA90
			public void Recycle(T obj)
			{
				if (obj == null)
				{
					TMDebug.LogWarningFormat("Recycle object can not be null!", new object[0]);
					return;
				}
				if (typeof(T) != obj.GetType())
				{
					TMDebug.LogWarningFormat("Recycle object type '{0}' miss-match pool type '{1}'!", new object[]
					{
						obj.GetType(),
						typeof(T)
					});
					return;
				}
				if (!obj.IsRecycled)
				{
					this.m_UsingObjectCount--;
					this.m_RecycleCount++;
					obj.OnRecycle();
					object recyclableObjects = this.m_RecyclableObjects;
					lock (recyclableObjects)
					{
						this.m_RecyclableObjects.Enqueue(obj);
					}
				}
				else
				{
					TMDebug.LogWarningFormat("Recyclable object '{0}' recycle state [Recycled] is wrong! (Maybe it has been recycled twice)", new object[]
					{
						obj.Name
					});
				}
			}

			// Token: 0x0601A1AD RID: 106925 RVA: 0x0081F798 File Offset: 0x0081DB98
			public sealed override void PurgePool(bool clearAll)
			{
				int num = 0;
				object recyclableObjects = this.m_RecyclableObjects;
				lock (recyclableObjects)
				{
					num = this.m_RecyclableObjects.Count;
				}
				num -= ((!clearAll) ? this.m_ReserveCount : 0);
				num = ((num >= 0) ? num : 0);
				this._ReleaseUnusedObject(num);
			}

			// Token: 0x0601A1AE RID: 106926 RVA: 0x0081F808 File Offset: 0x0081DC08
			internal sealed override I QureyInterface<I>()
			{
				return this as I;
			}

			// Token: 0x0601A1AF RID: 106927 RVA: 0x0081F81A File Offset: 0x0081DC1A
			internal sealed override void Shutdown()
			{
				this.PurgePool(true);
			}

			// Token: 0x0601A1B0 RID: 106928 RVA: 0x0081F824 File Offset: 0x0081DC24
			private T _AquireRecycledObject()
			{
				this.m_UsingObjectCount++;
				this.m_AcquireCount++;
				object recyclableObjects = this.m_RecyclableObjects;
				lock (recyclableObjects)
				{
					if (this.m_RecyclableObjects.Count > 0)
					{
						return this.m_RecyclableObjects.Dequeue();
					}
				}
				return (T)((object)null);
			}

			// Token: 0x0601A1B1 RID: 106929 RVA: 0x0081F8A0 File Offset: 0x0081DCA0
			private void _ReleaseUnusedObject(int releaseCount)
			{
				object recyclableObjects = this.m_RecyclableObjects;
				lock (recyclableObjects)
				{
					if (releaseCount > this.m_RecyclableObjects.Count)
					{
						releaseCount = this.m_RecyclableObjects.Count;
					}
					this.m_ReleaseCount += releaseCount;
					while (releaseCount-- > 0)
					{
						T t = this.m_RecyclableObjects.Dequeue();
						t.OnRelease();
					}
				}
			}

			// Token: 0x040125DA RID: 75226
			private readonly Queue<T> m_RecyclableObjects;

			// Token: 0x040125DB RID: 75227
			private readonly CreateRecyclable m_CreateAction;
		}

		// Token: 0x02004714 RID: 18196
		private class RecyclePoolDesc
		{
			// Token: 0x0601A1B2 RID: 106930 RVA: 0x0081F92C File Offset: 0x0081DD2C
			public RecyclePoolDesc(RecyclePoolBase pool, Type objType, Type poolType)
			{
				this.m_RecyclePool = pool;
				this.m_RecyclableType = objType;
				this.m_RecyclePoolType = poolType;
			}

			// Token: 0x040125DC RID: 75228
			public RecyclePoolBase m_RecyclePool;

			// Token: 0x040125DD RID: 75229
			public Type m_RecyclableType;

			// Token: 0x040125DE RID: 75230
			public Type m_RecyclePoolType;
		}
	}
}
