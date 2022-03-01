using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CCF RID: 3279
public class GeAnimatManager
{
	// Token: 0x060086AF RID: 34479 RVA: 0x00179AE1 File Offset: 0x00177EE1
	public bool Init()
	{
		return true;
	}

	// Token: 0x060086B0 RID: 34480 RVA: 0x00179AE4 File Offset: 0x00177EE4
	public void Deinit()
	{
		this.ClearAll();
		this.m_AnimatDescList.RemoveAll(delegate(GeAnimatManager.GeAnimatDesc a)
		{
			if (a != null && a.animat != null)
			{
				a.animat.Clear(true);
			}
			return true;
		});
	}

	// Token: 0x060086B1 RID: 34481 RVA: 0x00179B18 File Offset: 0x00177F18
	public void AddEffectMaterial(string animatName, string shaderName, DAnimatParamDesc[] param, GameObject[] meshes)
	{
		GeAnimatManager.GeAnimatDesc effectMaterialDesc = this.GetEffectMaterialDesc(animatName);
		if (effectMaterialDesc.animat == null)
		{
			GeAnimat geAnimat = new GeAnimat();
			geAnimat.Init(animatName, shaderName, param, meshes);
			this.m_AnimatDescList.Add(new GeAnimatManager.GeAnimatDesc(geAnimat, animatName));
		}
	}

	// Token: 0x060086B2 RID: 34482 RVA: 0x00179B5C File Offset: 0x00177F5C
	public GeAnimatManager.GeAnimatDesc GetEffectMaterialDesc(string animatName)
	{
		int i = 0;
		int count = this.m_AnimatDescList.Count;
		while (i < count)
		{
			if (this.m_AnimatDescList[i].name.CompareTo(animatName) == 0)
			{
				return this.m_AnimatDescList[i];
			}
			i++;
		}
		return this.sInvalidAnimatDesc;
	}

	// Token: 0x060086B3 RID: 34483 RVA: 0x00179BB8 File Offset: 0x00177FB8
	public void AppendObject(GameObject[] obj)
	{
		for (int i = 0; i < this.m_AnimatDescList.Count; i++)
		{
			this.m_AnimatDescList[i].animat.AppendObject(obj);
		}
		GeAnimatManager.GeAnimatCache geAnimatCache = this._GetTopAnimatCache();
		if (geAnimatCache != null)
		{
			geAnimatCache.animatDesc.animat.Apply(geAnimatCache.animatDesc.animat.GetTimeLen(), geAnimatCache.animatDesc.animat.GetElapsedTime(), geAnimatCache.animatDesc.animat.IsAnimate(), geAnimatCache.animatDesc.animat.IsRecover());
		}
	}

	// Token: 0x060086B4 RID: 34484 RVA: 0x00179C58 File Offset: 0x00178058
	public void RemoveObject(GameObject[] obj)
	{
		for (int i = 0; i < this.m_AnimatDescList.Count; i++)
		{
			this.m_AnimatDescList[i].animat.RemoveObject(obj);
		}
	}

	// Token: 0x060086B5 RID: 34485 RVA: 0x00179C98 File Offset: 0x00178098
	public uint PushAnimat(string animatName, float time, bool enableAnim, bool recover)
	{
		if (!string.IsNullOrEmpty(animatName))
		{
			GeAnimatManager.GeAnimatDesc effectMaterialDesc = this.GetEffectMaterialDesc(animatName);
			if (effectMaterialDesc.animat != null)
			{
				uint num = this._AllocHandle();
				this.m_AnimatStack.Add(new GeAnimatManager.GeAnimatCache(num, effectMaterialDesc));
				effectMaterialDesc.animat.Apply(time, 0f, enableAnim, recover);
				return num;
			}
		}
		return uint.MaxValue;
	}

	// Token: 0x060086B6 RID: 34486 RVA: 0x00179CF4 File Offset: 0x001780F4
	public void RemoveAnimat(uint handle)
	{
		for (int i = 0; i < this.m_AnimatStack.Count; i++)
		{
			GeAnimatManager.GeAnimatCache geAnimatCache = this.m_AnimatStack[i];
			if (geAnimatCache != null)
			{
				if (handle == geAnimatCache.handle)
				{
					if (this.m_AnimatStack.Count == 1)
					{
						if (geAnimatCache.animatDesc != null && geAnimatCache.animatDesc.animat != null)
						{
							geAnimatCache.animatDesc.animat.Recover();
						}
						this.m_AnimatStack.RemoveAt(i);
					}
					else if (i == this.m_AnimatStack.Count - 1)
					{
						this.m_AnimatStack.RemoveAt(this.m_AnimatStack.Count - 1);
						while (this.m_AnimatStack.Count > 0)
						{
							GeAnimatManager.GeAnimatCache geAnimatCache2 = this.m_AnimatStack[this.m_AnimatStack.Count - 1];
							this.m_AnimatStack.RemoveAt(this.m_AnimatStack.Count - 1);
							if (geAnimatCache2 != null)
							{
								if (!geAnimatCache2.animatDesc.animat.IsFinished())
								{
									if (geAnimatCache2.animatDesc != null && geAnimatCache2.animatDesc.animat != null)
									{
										GeAnimat animat = geAnimatCache2.animatDesc.animat;
										animat.Apply(animat.GetTimeLen(), animat.GetElapsedTime(), animat.IsAnimate(), animat.IsRecover());
										this.m_AnimatStack.Add(geAnimatCache2);
										break;
									}
								}
							}
						}
					}
					else
					{
						this.m_AnimatStack.RemoveAt(i);
					}
					return;
				}
			}
		}
	}

	// Token: 0x060086B7 RID: 34487 RVA: 0x00179E98 File Offset: 0x00178298
	public void Pause()
	{
		for (int i = 0; i < this.m_AnimatStack.Count; i++)
		{
			if (this.m_AnimatStack[i] != null && this.m_AnimatStack[i].animatDesc != null && this.m_AnimatStack[i].animatDesc.animat != null)
			{
				this.m_AnimatStack[i].animatDesc.animat.Pause();
			}
		}
	}

	// Token: 0x060086B8 RID: 34488 RVA: 0x00179F20 File Offset: 0x00178320
	public void Resume()
	{
		for (int i = 0; i < this.m_AnimatStack.Count; i++)
		{
			if (this.m_AnimatStack[i] != null && this.m_AnimatStack[i].animatDesc != null && this.m_AnimatStack[i].animatDesc.animat != null)
			{
				this.m_AnimatStack[i].animatDesc.animat.Resume();
			}
		}
	}

	// Token: 0x060086B9 RID: 34489 RVA: 0x00179FA8 File Offset: 0x001783A8
	public void Update(int deltaTime, GameObject obj)
	{
		GeAnimatManager.GeAnimatCache geAnimatCache = this._GetTopAnimatCache();
		int count = this.m_AnimatStack.Count;
		int num = count - 1;
		for (int i = 0; i < count; i++)
		{
			GeAnimatManager.GeAnimatCache geAnimatCache2 = this.m_AnimatStack[i];
			if (geAnimatCache2 != null && geAnimatCache2.animatDesc != null && geAnimatCache2.animatDesc.animat != null)
			{
				geAnimatCache2.animatDesc.animat.Update(i != num, (float)deltaTime, obj);
				if (geAnimatCache2.animatDesc.animat.IsFinished())
				{
					this.m_IsDirty = true;
				}
			}
			else
			{
				this.m_IsDirty = true;
			}
		}
		if (this.m_IsDirty)
		{
			this._RemoveDeadAnimat();
		}
		if (this.m_AnimatStack.Count != count)
		{
			GeAnimatManager.GeAnimatCache geAnimatCache3 = this._GetTopAnimatCache();
			if (geAnimatCache3 != null)
			{
				geAnimatCache3.animatDesc.animat.Apply(geAnimatCache3.animatDesc.animat.GetTimeLen(), geAnimatCache3.animatDesc.animat.GetElapsedTime(), geAnimatCache3.animatDesc.animat.IsAnimate(), geAnimatCache3.animatDesc.animat.IsRecover());
			}
			else if (geAnimatCache != null)
			{
				geAnimatCache.animatDesc.animat.Recover();
			}
		}
	}

	// Token: 0x060086BA RID: 34490 RVA: 0x0017A0F5 File Offset: 0x001784F5
	protected void _RemoveDeadAnimat()
	{
		this.m_AnimatStack.RemoveAll((GeAnimatManager.GeAnimatCache cache) => cache == null || cache.animatDesc == null || cache.animatDesc.animat == null || cache.animatDesc.animat.IsFinished());
		this.m_IsDirty = false;
	}

	// Token: 0x060086BB RID: 34491 RVA: 0x0017A128 File Offset: 0x00178528
	public void ClearAll()
	{
		GeAnimatManager.GeAnimatCache geAnimatCache = this._GetTopAnimatCache();
		if (geAnimatCache != null)
		{
			geAnimatCache.animatDesc.animat.Recover();
		}
		this.m_AnimatStack.Clear();
	}

	// Token: 0x060086BC RID: 34492 RVA: 0x0017A160 File Offset: 0x00178560
	protected uint _AllocHandle()
	{
		if (this.m_CurAnimHandleCnt + 1U == 4294967295U)
		{
			this.m_CurAnimHandleCnt = 0U;
		}
		return this.m_CurAnimHandleCnt++;
	}

	// Token: 0x060086BD RID: 34493 RVA: 0x0017A194 File Offset: 0x00178594
	protected GeAnimatManager.GeAnimatCache _GetTopAnimatCache()
	{
		for (int i = this.m_AnimatStack.Count - 1; i >= 0; i--)
		{
			GeAnimatManager.GeAnimatCache geAnimatCache = this.m_AnimatStack[i];
			if (geAnimatCache != null)
			{
				if (geAnimatCache.animatDesc != null && geAnimatCache.animatDesc.animat != null)
				{
					return geAnimatCache;
				}
			}
		}
		return null;
	}

	// Token: 0x040040A0 RID: 16544
	protected List<GeAnimatManager.GeAnimatCache> m_AnimatStack = new List<GeAnimatManager.GeAnimatCache>();

	// Token: 0x040040A1 RID: 16545
	public GeAnimatManager.GeAnimatDesc sInvalidAnimatDesc = new GeAnimatManager.GeAnimatDesc(null, string.Empty);

	// Token: 0x040040A2 RID: 16546
	protected List<GeAnimatManager.GeAnimatDesc> m_AnimatDescList = new List<GeAnimatManager.GeAnimatDesc>();

	// Token: 0x040040A3 RID: 16547
	protected uint m_CurAnimHandleCnt;

	// Token: 0x040040A4 RID: 16548
	protected bool m_IsDirty;

	// Token: 0x02000CD0 RID: 3280
	public class GeAnimatDesc
	{
		// Token: 0x060086C0 RID: 34496 RVA: 0x0017A24A File Offset: 0x0017864A
		public GeAnimatDesc(GeAnimat a, string n)
		{
			this.animat = a;
			this.name = n;
		}

		// Token: 0x040040A7 RID: 16551
		public string name;

		// Token: 0x040040A8 RID: 16552
		public GeAnimat animat;
	}

	// Token: 0x02000CD1 RID: 3281
	public class GeAnimatCache
	{
		// Token: 0x060086C1 RID: 34497 RVA: 0x0017A260 File Offset: 0x00178660
		public GeAnimatCache(uint h, GeAnimatManager.GeAnimatDesc a)
		{
			this.animatDesc = a;
			this.handle = h;
		}

		// Token: 0x040040A9 RID: 16553
		public uint handle;

		// Token: 0x040040AA RID: 16554
		public GeAnimatManager.GeAnimatDesc animatDesc;
	}
}
