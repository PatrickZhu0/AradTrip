using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

// Token: 0x02000CEE RID: 3310
public class GeEffectPool : Singleton<GeEffectPool>, IObjectPool
{
	// Token: 0x060087A5 RID: 34725 RVA: 0x0017F51F File Offset: 0x0017D91F
	public string GetPoolName()
	{
		return this.poolName;
	}

	// Token: 0x060087A6 RID: 34726 RVA: 0x0017F527 File Offset: 0x0017D927
	public string GetPoolInfo()
	{
		return string.Format("{0}/{1}", this.remainInst, this.totalInst);
	}

	// Token: 0x060087A7 RID: 34727 RVA: 0x0017F549 File Offset: 0x0017D949
	public string GetPoolDetailInfo()
	{
		return "detailInfo";
	}

	// Token: 0x060087A8 RID: 34728 RVA: 0x0017F550 File Offset: 0x0017D950
	public override void Init()
	{
		base.Init();
		this.CreateRoot();
		this.totalInst = 0;
		this.remainInst = 0;
		Singleton<CPoolManager>.GetInstance().RegisterPool(this.poolKey, this);
	}

	// Token: 0x060087A9 RID: 34729 RVA: 0x0017F57D File Offset: 0x0017D97D
	public override void UnInit()
	{
		base.UnInit();
	}

	// Token: 0x060087AA RID: 34730 RVA: 0x0017F588 File Offset: 0x0017D988
	public GeEffectEx CreateEffect(string effectRes, EffectsFrames info, float time, Vector3 initPos, bool bFaceLeft, GameObject parentObj = null, bool useCube = false)
	{
		List<GeEffectPool.SEffectDesc> effectPool = this.m_EffectPool;
		string value = effectRes;
		if (useCube)
		{
			effectPool = this.useCubeEffectPool;
			value = GeEffectPool.m_CubeEffectName;
		}
		int i = 0;
		int count = effectPool.Count;
		GeEffectEx geEffectEx;
		while (i < count)
		{
			GeEffectPool.SEffectDesc seffectDesc = effectPool[i];
			if (seffectDesc.m_Key.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				Queue<GeEffectEx> effectQueue = seffectDesc.m_EffectQueue;
				while (effectQueue.Count > 0)
				{
					geEffectEx = effectQueue.Dequeue();
					if (geEffectEx != null && geEffectEx.OnReuse(info, time, initPos, bFaceLeft, parentObj, useCube))
					{
						geEffectEx.SetVisible(true);
						this.remainInst--;
						return geEffectEx;
					}
				}
			}
			i++;
		}
		geEffectEx = new GeEffectEx();
		if (!geEffectEx.Init(effectRes, info, time, initPos, bFaceLeft, parentObj, useCube))
		{
			geEffectEx = null;
		}
		else
		{
			this.totalInst++;
		}
		return geEffectEx;
	}

	// Token: 0x060087AB RID: 34731 RVA: 0x0017F674 File Offset: 0x0017DA74
	public void RecycleEffect(GeEffectEx effect)
	{
		if (effect == null)
		{
			return;
		}
		if (effect.GetRootNode() == null)
		{
			return;
		}
		effect.OnRecycle();
		this.AttachToRoot(effect);
		this.remainInst++;
		List<GeEffectPool.SEffectDesc> effectPool = this.m_EffectPool;
		string text = effect.GetEffectName();
		if (effect.useCube)
		{
			effectPool = this.useCubeEffectPool;
			text = GeEffectPool.m_CubeEffectName;
		}
		int i = 0;
		int count = effectPool.Count;
		while (i < count)
		{
			GeEffectPool.SEffectDesc seffectDesc = effectPool[i];
			if (seffectDesc.m_Key.Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				Queue<GeEffectEx> effectQueue = seffectDesc.m_EffectQueue;
				effectQueue.Enqueue(effect);
				effect.SetVisible(false);
				return;
			}
			i++;
		}
		GeEffectPool.SEffectDesc seffectDesc2 = new GeEffectPool.SEffectDesc();
		seffectDesc2.m_Key = text;
		effect.SetVisible(false);
		seffectDesc2.m_EffectQueue.Enqueue(effect);
		effectPool.Add(seffectDesc2);
	}

	// Token: 0x060087AC RID: 34732 RVA: 0x0017F754 File Offset: 0x0017DB54
	protected void SubClear(List<GeEffectPool.SEffectDesc> pool)
	{
		int i = 0;
		int count = pool.Count;
		while (i < count)
		{
			GeEffectPool.SEffectDesc seffectDesc = pool[i];
			while (seffectDesc.m_EffectQueue.Count > 0)
			{
				GeEffectEx geEffectEx = seffectDesc.m_EffectQueue.Dequeue();
				geEffectEx.Deinit();
			}
			seffectDesc.m_EffectQueue = null;
			i++;
		}
		pool.Clear();
	}

	// Token: 0x060087AD RID: 34733 RVA: 0x0017F7BC File Offset: 0x0017DBBC
	public void ClearAll()
	{
		this.SubClear(this.m_EffectPool);
		this.SubClear(this.useCubeEffectPool);
		if (this.poolRoot != null)
		{
			Object.Destroy(this.poolRoot);
			this.poolRoot = null;
		}
		this.remainInst = 0;
		this.totalInst = 0;
	}

	// Token: 0x060087AE RID: 34734 RVA: 0x0017F812 File Offset: 0x0017DC12
	private void CreateRoot()
	{
		if (null == this.poolRoot)
		{
			this.poolRoot = new GameObject("GeEffectPool");
		}
	}

	// Token: 0x060087AF RID: 34735 RVA: 0x0017F835 File Offset: 0x0017DC35
	private void AttachToRoot(GeEffectEx effect)
	{
		this.CreateRoot();
		GeUtility.AttachTo(effect.GetRootNode(), this.poolRoot, false);
	}

	// Token: 0x04004156 RID: 16726
	private string poolKey = "GeEffectPool";

	// Token: 0x04004157 RID: 16727
	private string poolName = "特效池";

	// Token: 0x04004158 RID: 16728
	private int totalInst;

	// Token: 0x04004159 RID: 16729
	private int remainInst;

	// Token: 0x0400415A RID: 16730
	private List<GeEffectPool.SEffectDesc> m_EffectPool = new List<GeEffectPool.SEffectDesc>();

	// Token: 0x0400415B RID: 16731
	private List<GeEffectPool.SEffectDesc> useCubeEffectPool = new List<GeEffectPool.SEffectDesc>();

	// Token: 0x0400415C RID: 16732
	private GameObject poolRoot;

	// Token: 0x0400415D RID: 16733
	private static string m_CubeEffectName = "Effects/DummyEffect/DummyEffect";

	// Token: 0x02000CEF RID: 3311
	public class SEffectDesc
	{
		// Token: 0x0400415E RID: 16734
		public string m_Key;

		// Token: 0x0400415F RID: 16735
		public Queue<GeEffectEx> m_EffectQueue = new Queue<GeEffectEx>();
	}
}
