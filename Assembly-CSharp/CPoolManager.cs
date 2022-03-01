using System;
using System.Collections.Generic;

// Token: 0x02000108 RID: 264
public class CPoolManager : Singleton<CPoolManager>
{
	// Token: 0x060005C2 RID: 1474 RVA: 0x00024B64 File Offset: 0x00022F64
	private bool HasPool(string name)
	{
		for (int i = 0; i < this.pools.Count; i++)
		{
			if (this.pools[i].name == name)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x00024BAC File Offset: 0x00022FAC
	public void RegisterPool(string name, IObjectPool pool)
	{
		if (!this.HasPool(name))
		{
			CPoolManager.PoolDesc poolDesc = new CPoolManager.PoolDesc();
			poolDesc.name = name;
			poolDesc.pool = pool;
			this.pools.Add(poolDesc);
		}
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x00024BE8 File Offset: 0x00022FE8
	public string GetPoolsInfo()
	{
		string text = string.Empty;
		for (int i = 0; i < this.pools.Count; i++)
		{
			CPoolManager.PoolDesc poolDesc = this.pools[i];
			text += string.Format("{0}:{1}\n", poolDesc.pool.GetPoolName(), poolDesc.pool.GetPoolInfo());
		}
		return text;
	}

	// Token: 0x040004F2 RID: 1266
	private List<CPoolManager.PoolDesc> pools = new List<CPoolManager.PoolDesc>();

	// Token: 0x02000109 RID: 265
	private class PoolDesc
	{
		// Token: 0x040004F3 RID: 1267
		public string name;

		// Token: 0x040004F4 RID: 1268
		public IObjectPool pool;
	}
}
