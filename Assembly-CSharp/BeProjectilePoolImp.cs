using System;
using System.Collections.Generic;

// Token: 0x020041A0 RID: 16800
public class BeProjectilePoolImp : IObjectPool
{
	// Token: 0x060170C2 RID: 94402 RVA: 0x007117E9 File Offset: 0x0070FBE9
	public string GetPoolName()
	{
		return this.poolName;
	}

	// Token: 0x060170C3 RID: 94403 RVA: 0x007117F1 File Offset: 0x0070FBF1
	public string GetPoolInfo()
	{
		return string.Format("{0}/{1}", this.remainInst, this.totalInst);
	}

	// Token: 0x060170C4 RID: 94404 RVA: 0x00711813 File Offset: 0x0070FC13
	public string GetPoolDetailInfo()
	{
		return "detailInfo";
	}

	// Token: 0x060170C5 RID: 94405 RVA: 0x0071181A File Offset: 0x0070FC1A
	public void Init()
	{
		Singleton<CPoolManager>.GetInstance().RegisterPool(this.poolKey, this);
	}

	// Token: 0x060170C6 RID: 94406 RVA: 0x00711830 File Offset: 0x0070FC30
	public BeProjectile GetProjectile(int iResID, int iCamp, int iID, bool useCube = false)
	{
		BeProjectile beProjectile = null;
		Dictionary<int, Queue<BeProjectile>> dictionary = this.pooledObj;
		if (useCube)
		{
			dictionary = this.useCubePooledObj;
		}
		if (!dictionary.ContainsKey(iResID))
		{
			dictionary.Add(iResID, new Queue<BeProjectile>());
		}
		if (dictionary[iResID].Count > 0)
		{
			this.remainInst--;
			beProjectile = dictionary[iResID].Dequeue();
		}
		if (beProjectile == null)
		{
			this.totalInst++;
			beProjectile = new BeProjectile(iResID, iCamp, iID);
		}
		beProjectile.InitReset(iResID, iCamp, iID);
		return beProjectile;
	}

	// Token: 0x060170C7 RID: 94407 RVA: 0x007118C0 File Offset: 0x0070FCC0
	public void PutProjectile(BeProjectile obj)
	{
		if (obj.m_pkGeActor == null)
		{
			return;
		}
		this.remainInst++;
		Dictionary<int, Queue<BeProjectile>> dictionary = this.pooledObj;
		if (obj.m_pkGeActor.GetUseCube())
		{
			dictionary = this.useCubePooledObj;
		}
		dictionary[obj.m_iResID].Enqueue(obj);
	}

	// Token: 0x060170C8 RID: 94408 RVA: 0x00711918 File Offset: 0x0070FD18
	protected void SubClear(Dictionary<int, Queue<BeProjectile>> pool)
	{
		if (pool == null)
		{
			return;
		}
		foreach (KeyValuePair<int, Queue<BeProjectile>> keyValuePair in pool)
		{
			Queue<BeProjectile> value = keyValuePair.Value;
			while (value.Count > 0)
			{
				BeProjectile beProjectile = value.Dequeue();
				beProjectile.OnRemove(true);
			}
			value.Clear();
		}
		pool.Clear();
	}

	// Token: 0x060170C9 RID: 94409 RVA: 0x0071197F File Offset: 0x0070FD7F
	public void Clear()
	{
		this.SubClear(this.pooledObj);
		this.SubClear(this.useCubePooledObj);
		this.remainInst = 0;
		this.totalInst = 0;
	}

	// Token: 0x040109A0 RID: 68000
	private Dictionary<int, Queue<BeProjectile>> pooledObj = new Dictionary<int, Queue<BeProjectile>>();

	// Token: 0x040109A1 RID: 68001
	private Dictionary<int, Queue<BeProjectile>> useCubePooledObj = new Dictionary<int, Queue<BeProjectile>>();

	// Token: 0x040109A2 RID: 68002
	private int newCount;

	// Token: 0x040109A3 RID: 68003
	private int refCount;

	// Token: 0x040109A4 RID: 68004
	private string poolKey = "BeProjectilePool";

	// Token: 0x040109A5 RID: 68005
	private string poolName = "投射物池";

	// Token: 0x040109A6 RID: 68006
	private int totalInst;

	// Token: 0x040109A7 RID: 68007
	private int remainInst;
}
