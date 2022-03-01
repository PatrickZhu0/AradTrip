using System;

namespace GamePool
{
	// Token: 0x02000157 RID: 343
	public class MutexObjectPool<T> where T : new()
	{
		// Token: 0x060009E7 RID: 2535 RVA: 0x00034236 File Offset: 0x00032636
		public void Init(int maxCacheObjNum_)
		{
			this.maxCacheObjNum = maxCacheObjNum_;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0003423F File Offset: 0x0003263F
		public int GetCachedNum()
		{
			return this.cachedObjNum;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00034247 File Offset: 0x00032647
		public int GetMaxCacheObjNum()
		{
			return this.maxCacheObjNum;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00034250 File Offset: 0x00032650
		public T Get()
		{
			object obj = this.poolLockObj;
			T result;
			lock (obj)
			{
				result = this.pool.Get();
			}
			if (this.cachedObjNum > 0)
			{
				this.cachedObjNum--;
			}
			return result;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x000342B0 File Offset: 0x000326B0
		public void Release(T obj)
		{
			if (this.GetCachedNum() >= this.GetMaxCacheObjNum())
			{
				return;
			}
			object obj2 = this.poolLockObj;
			lock (obj2)
			{
				this.pool.Release(obj);
			}
			this.cachedObjNum++;
		}

		// Token: 0x04000763 RID: 1891
		private ObjectPool<T> pool = new ObjectPool<T>(null, null);

		// Token: 0x04000764 RID: 1892
		private object poolLockObj = new object();

		// Token: 0x04000765 RID: 1893
		private int maxCacheObjNum = 10;

		// Token: 0x04000766 RID: 1894
		private int cachedObjNum;
	}
}
