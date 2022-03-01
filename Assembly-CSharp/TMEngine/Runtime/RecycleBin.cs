using System;
using System.Collections.Generic;

namespace TMEngine.Runtime
{
	// Token: 0x02004710 RID: 18192
	internal class RecycleBin : ITMRecycleBin
	{
		// Token: 0x0601A189 RID: 106889 RVA: 0x0081EF35 File Offset: 0x0081D335
		public RecycleBin(RecyclePoolManager recycablePoolManager)
		{
			if (recycablePoolManager == null)
			{
				TMDebug.AssertFailed("Recyclable pool manager can not be null!");
			}
			this.m_RecycablePoolManager = recycablePoolManager;
			this.m_RecycablePoolTable = new Dictionary<Type, RecyclePoolBase>();
		}

		// Token: 0x0601A18A RID: 106890 RVA: 0x0081EF60 File Offset: 0x0081D360
		public void SetReserveCountOfType(Type type, int reserveCount)
		{
			if (type == null)
			{
				TMDebug.LogWarningFormat("Type can not be null!", new object[0]);
				return;
			}
			if (type == this.m_CachedObjectType)
			{
				this.m_CachedObjectPool.SetReserveCount(reserveCount);
				return;
			}
			RecyclePoolBase recyclePoolBase = null;
			if (this.m_RecycablePoolTable.TryGetValue(type, out recyclePoolBase))
			{
				this.m_CachedObjectType = type;
				this.m_CachedObjectPool = recyclePoolBase;
				recyclePoolBase.SetReserveCount(reserveCount);
				return;
			}
			TMDebug.LogWarningFormat("Can not find pool for type '{0}'!", new object[]
			{
				type.Name
			});
		}

		// Token: 0x0601A18B RID: 106891 RVA: 0x0081EFE4 File Offset: 0x0081D3E4
		public int GetResserveCountOfType(Type type)
		{
			if (type == null)
			{
				TMDebug.LogWarningFormat("Type can not be null!", new object[0]);
				return 0;
			}
			if (type == this.m_CachedObjectType)
			{
				return this.m_CachedObjectPool.ReserveCount;
			}
			RecyclePoolBase recyclePoolBase = null;
			if (this.m_RecycablePoolTable.TryGetValue(type, out recyclePoolBase))
			{
				this.m_CachedObjectType = type;
				this.m_CachedObjectPool = recyclePoolBase;
				return recyclePoolBase.RecycleCount;
			}
			TMDebug.LogWarningFormat("Can not find pool for type '{0}'!", new object[]
			{
				type.Name
			});
			return 0;
		}

		// Token: 0x0601A18C RID: 106892 RVA: 0x0081F068 File Offset: 0x0081D468
		public T Acquire<T>() where T : Recyclable, new()
		{
			Type typeFromHandle = typeof(T);
			RecyclePoolBase recyclePoolBase = null;
			if (typeFromHandle == this.m_CachedObjectType && this.m_CachedObjectPool != null)
			{
				return this.m_CachedObjectPool.QureyInterface<ITMRecyclePool<T>>().Acquire();
			}
			if (this.m_RecycablePoolTable.TryGetValue(typeFromHandle, out recyclePoolBase))
			{
				this.m_CachedObjectType = typeFromHandle;
				this.m_CachedObjectPool = recyclePoolBase;
				return recyclePoolBase.QureyInterface<ITMRecyclePool<T>>().Acquire();
			}
			recyclePoolBase = this.m_RecycablePoolManager.CreateRecyclePool<T>(null);
			if (recyclePoolBase != null)
			{
				this.m_CachedObjectType = typeFromHandle;
				this.m_CachedObjectPool = recyclePoolBase;
				this.m_RecycablePoolTable.Add(typeFromHandle, recyclePoolBase);
				return recyclePoolBase.QureyInterface<ITMRecyclePool<T>>().Acquire();
			}
			TMDebug.LogErrorFormat("Create recyclable object pool has failed!", new object[0]);
			return (T)((object)null);
		}

		// Token: 0x0601A18D RID: 106893 RVA: 0x0081F128 File Offset: 0x0081D528
		public void Recycle<T>(T obj) where T : Recyclable, new()
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == this.m_CachedObjectType)
			{
				this.m_CachedObjectPool.QureyInterface<ITMRecyclePool<T>>().Recycle(obj);
				return;
			}
			RecyclePoolBase recyclePoolBase = null;
			if (this.m_RecycablePoolTable.TryGetValue(typeFromHandle, out recyclePoolBase))
			{
				this.m_CachedObjectType = typeFromHandle;
				this.m_CachedObjectPool = recyclePoolBase;
				recyclePoolBase.QureyInterface<ITMRecyclePool<T>>().Recycle(obj);
				return;
			}
			TMDebug.AssertFailed(string.Format("Can not find recyclable object pool with type '{0}'!", typeFromHandle.Name));
		}

		// Token: 0x0601A18E RID: 106894 RVA: 0x0081F1A4 File Offset: 0x0081D5A4
		public void ClearAllObjectOfType<T>() where T : Recyclable, new()
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == this.m_CachedObjectType)
			{
				this.m_CachedObjectPool.PurgePool(true);
				return;
			}
			RecyclePoolBase recyclePoolBase = null;
			if (this.m_RecycablePoolTable.TryGetValue(typeFromHandle, out recyclePoolBase))
			{
				this.m_CachedObjectType = typeFromHandle;
				this.m_CachedObjectPool = recyclePoolBase;
				recyclePoolBase.PurgePool(true);
				return;
			}
			TMDebug.AssertFailed(string.Format("Can not find recyclable object pool with type '{0}'!", typeFromHandle.Name));
		}

		// Token: 0x0601A18F RID: 106895 RVA: 0x0081F218 File Offset: 0x0081D618
		public void Purge(bool clearAll)
		{
			foreach (KeyValuePair<Type, RecyclePoolBase> keyValuePair in this.m_RecycablePoolTable)
			{
				RecyclePoolBase value = keyValuePair.Value;
				if (value != null)
				{
					value.PurgePool(clearAll);
				}
			}
		}

		// Token: 0x0601A190 RID: 106896 RVA: 0x0081F260 File Offset: 0x0081D660
		public void Shutdown()
		{
			foreach (KeyValuePair<Type, RecyclePoolBase> keyValuePair in this.m_RecycablePoolTable)
			{
				RecyclePoolBase value = keyValuePair.Value;
				if (value != null)
				{
					this.m_RecycablePoolManager.DestroyRecyclePool(value);
				}
			}
			this.m_RecycablePoolTable.Clear();
			this.m_CachedObjectType = null;
			this.m_CachedObjectPool = null;
		}

		// Token: 0x040125CA RID: 75210
		private readonly Dictionary<Type, RecyclePoolBase> m_RecycablePoolTable;

		// Token: 0x040125CB RID: 75211
		private readonly RecyclePoolManager m_RecycablePoolManager;

		// Token: 0x040125CC RID: 75212
		private Type m_CachedObjectType;

		// Token: 0x040125CD RID: 75213
		private RecyclePoolBase m_CachedObjectPool;
	}
}
