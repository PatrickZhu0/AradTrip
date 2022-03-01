using System;
using System.Collections.Generic;

// Token: 0x0200010C RID: 268
public class ClassObjListPool<T> : IObjectPool where T : PooledClassObj, new()
{
	// Token: 0x060005CD RID: 1485 RVA: 0x00024EA1 File Offset: 0x000232A1
	public string GetPoolName()
	{
		return this.poolName;
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x00024EA9 File Offset: 0x000232A9
	public string GetPoolInfo()
	{
		return string.Format("{0}/{1}", this.remainInst, this.totalInst);
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x00024ECB File Offset: 0x000232CB
	public string GetPoolDetailInfo()
	{
		return "detailInfo";
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x00024ED4 File Offset: 0x000232D4
	public virtual void Init()
	{
		this.poolKey = base.GetType().ToString();
		this.poolName = string.Format("{0}Pool", typeof(T).ToString());
		Singleton<CPoolManager>.GetInstance().RegisterPool(this.poolKey, this);
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x00024F24 File Offset: 0x00023324
	public T GetPooledObject()
	{
		T result = (T)((object)null);
		if (this.m_ClassObjectListPool.Count > 0)
		{
			int index = this.m_ClassObjectListPool.Count - 1;
			result = this.m_ClassObjectListPool[index];
			this.m_ClassObjectListPool.RemoveAt(index);
			result.OnReused();
			return result;
		}
		return Activator.CreateInstance<T>();
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x00024F84 File Offset: 0x00023384
	public void RecyclePooledObject(T obj)
	{
		obj.OnRecycle();
		this.m_ClassObjectListPool.Add(obj);
	}

	// Token: 0x040004F8 RID: 1272
	private List<T> m_ClassObjectListPool = new List<T>();

	// Token: 0x040004F9 RID: 1273
	private string poolKey = "Invalid";

	// Token: 0x040004FA RID: 1274
	private string poolName = "UnknownPool";

	// Token: 0x040004FB RID: 1275
	private int totalInst;

	// Token: 0x040004FC RID: 1276
	private int remainInst;
}
