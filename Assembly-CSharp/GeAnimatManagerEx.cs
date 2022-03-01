using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CD2 RID: 3282
public class GeAnimatManagerEx
{
	// Token: 0x060086C3 RID: 34499 RVA: 0x0017A2A1 File Offset: 0x001786A1
	public bool Init()
	{
		return true;
	}

	// Token: 0x060086C4 RID: 34500 RVA: 0x0017A2A4 File Offset: 0x001786A4
	public void Deinit()
	{
		this.ClearAll();
		this.m_AnimatDescList.RemoveAll(delegate(GeAnimatManagerEx.GeAnimatDescEx f)
		{
			if (f != null && f.animatProxy != null)
			{
				int i = 0;
				int num = f.animatProxy.Length;
				while (i < num)
				{
					if (null != f.animatProxy[i])
					{
						f.animatProxy[i].Recover();
					}
					i++;
				}
			}
			return true;
		});
	}

	// Token: 0x060086C5 RID: 34501 RVA: 0x0017A2D8 File Offset: 0x001786D8
	public void AppendObject(GameObject[] obj)
	{
		if (obj == null)
		{
			return;
		}
		int i = 0;
		int num = obj.Length;
		while (i < num)
		{
			if (!(null == obj[i]))
			{
				this.m_AnimatDescList.Add(new GeAnimatManagerEx.GeAnimatDescEx(obj[i], obj[i].GetComponentsInChildren<GeMeshDescProxy>()));
			}
			i++;
		}
	}

	// Token: 0x060086C6 RID: 34502 RVA: 0x0017A330 File Offset: 0x00178730
	public void RemoveObject(GameObject[] obj)
	{
		if (obj == null)
		{
			return;
		}
		this.m_AnimatDescList.RemoveAll(delegate(GeAnimatManagerEx.GeAnimatDescEx f)
		{
			if (f == null)
			{
				return true;
			}
			GeMeshDescProxy[] array = null;
			if (null == f.obj)
			{
				if (f.animatProxy != null)
				{
					array = f.animatProxy;
				}
			}
			else
			{
				int i = 0;
				int num = obj.Length;
				while (i < num)
				{
					GameObject gameObject = obj[i];
					if (!(null == gameObject))
					{
						if (gameObject == f.obj)
						{
							array = f.animatProxy;
							break;
						}
					}
					i++;
				}
			}
			if (array != null)
			{
				int j = 0;
				int num2 = array.Length;
				while (j < num2)
				{
					if (null != array[j])
					{
						array[j].Recover();
					}
					j++;
				}
				return true;
			}
			return null == f.obj;
		});
	}

	// Token: 0x060086C7 RID: 34503 RVA: 0x0017A370 File Offset: 0x00178770
	public uint PushAnimat(string animatName, float time, bool enableAnim, bool needRecover)
	{
		if (!string.IsNullOrEmpty(animatName))
		{
			uint num = this._AllocHandle();
			this.m_AnimatStack.Add(new GeAnimatManagerEx.GeAnimatCacheEx(animatName, num, time, enableAnim, needRecover));
			this._ApplyAnimat(animatName, time, enableAnim);
			return num;
		}
		return uint.MaxValue;
	}

	// Token: 0x060086C8 RID: 34504 RVA: 0x0017A3B4 File Offset: 0x001787B4
	public void RemoveAnimat(uint handle)
	{
		for (int i = 0; i < this.m_AnimatStack.Count; i++)
		{
			GeAnimatManagerEx.GeAnimatCacheEx geAnimatCacheEx = this.m_AnimatStack[i];
			if (geAnimatCacheEx != null)
			{
				if (handle == geAnimatCacheEx.handle)
				{
					if (this.m_AnimatStack.Count == 1)
					{
						this._RecoverAnimat();
						this.m_AnimatStack.RemoveAt(i);
					}
					else if (i == this.m_AnimatStack.Count - 1)
					{
						this.m_AnimatStack.RemoveAt(this.m_AnimatStack.Count - 1);
						while (this.m_AnimatStack.Count > 0)
						{
							GeAnimatManagerEx.GeAnimatCacheEx geAnimatCacheEx2 = this.m_AnimatStack[this.m_AnimatStack.Count - 1];
							this.m_AnimatStack.RemoveAt(this.m_AnimatStack.Count - 1);
							if (geAnimatCacheEx2 != null)
							{
								if (!geAnimatCacheEx2.isFinished)
								{
									this._ApplyAnimat(geAnimatCacheEx2.name, geAnimatCacheEx2.timeLen, geAnimatCacheEx2.enableAnim);
									this.m_AnimatStack.Add(geAnimatCacheEx2);
									break;
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

	// Token: 0x060086C9 RID: 34505 RVA: 0x0017A4F5 File Offset: 0x001788F5
	public void Pause()
	{
	}

	// Token: 0x060086CA RID: 34506 RVA: 0x0017A4F7 File Offset: 0x001788F7
	public void Resume()
	{
	}

	// Token: 0x060086CB RID: 34507 RVA: 0x0017A4FC File Offset: 0x001788FC
	public void Update(int deltaTime, GameObject obj)
	{
		int count = this.m_AnimatStack.Count;
		int num = count - 1;
		for (int i = 0; i < count; i++)
		{
			GeAnimatManagerEx.GeAnimatCacheEx geAnimatCacheEx = this.m_AnimatStack[i];
			if (geAnimatCacheEx != null)
			{
				geAnimatCacheEx.Update((float)deltaTime);
				if (geAnimatCacheEx.isFinished)
				{
					this.m_IsDirty = true;
				}
				else
				{
					this._UpdateAnimat(geAnimatCacheEx.timePos, obj.transform.position);
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
			GeAnimatManagerEx.GeAnimatCacheEx geAnimatCacheEx2 = this._GetTopAnimatCache();
			if (geAnimatCacheEx2 != null)
			{
				this._ApplyAnimat(geAnimatCacheEx2.name, geAnimatCacheEx2.timeLen, geAnimatCacheEx2.enableAnim);
			}
			else
			{
				this._RecoverAnimat();
			}
		}
	}

	// Token: 0x060086CC RID: 34508 RVA: 0x0017A5D7 File Offset: 0x001789D7
	protected void _RemoveDeadAnimat()
	{
		this.m_AnimatStack.RemoveAll((GeAnimatManagerEx.GeAnimatCacheEx cache) => cache == null || cache.isFinished);
		this.m_IsDirty = false;
	}

	// Token: 0x060086CD RID: 34509 RVA: 0x0017A609 File Offset: 0x00178A09
	public void ClearAll()
	{
		this._RecoverAnimat();
		this.m_AnimatStack.Clear();
	}

	// Token: 0x060086CE RID: 34510 RVA: 0x0017A61C File Offset: 0x00178A1C
	protected uint _AllocHandle()
	{
		if (this.m_CurAnimHandleCnt + 1U == 4294967295U)
		{
			this.m_CurAnimHandleCnt = 0U;
		}
		return this.m_CurAnimHandleCnt++;
	}

	// Token: 0x060086CF RID: 34511 RVA: 0x0017A650 File Offset: 0x00178A50
	protected void _ApplyAnimat(string name, float timeLen, bool enableAnim)
	{
		int i = 0;
		int count = this.m_AnimatDescList.Count;
		while (i < count)
		{
			GeAnimatManagerEx.GeAnimatDescEx geAnimatDescEx = this.m_AnimatDescList[i];
			if (geAnimatDescEx != null)
			{
				int j = 0;
				int num = geAnimatDescEx.animatProxy.Length;
				while (j < num)
				{
					GeMeshDescProxy geMeshDescProxy = geAnimatDescEx.animatProxy[j];
					if (!(null == geMeshDescProxy))
					{
						geMeshDescProxy.Apply(name, timeLen, enableAnim);
					}
					j++;
				}
			}
			i++;
		}
	}

	// Token: 0x060086D0 RID: 34512 RVA: 0x0017A6D8 File Offset: 0x00178AD8
	protected void _RecoverAnimat()
	{
		int i = 0;
		int count = this.m_AnimatDescList.Count;
		while (i < count)
		{
			GeAnimatManagerEx.GeAnimatDescEx geAnimatDescEx = this.m_AnimatDescList[i];
			if (geAnimatDescEx != null)
			{
				int j = 0;
				int num = geAnimatDescEx.animatProxy.Length;
				while (j < num)
				{
					GeMeshDescProxy geMeshDescProxy = geAnimatDescEx.animatProxy[j];
					if (!(null == geMeshDescProxy))
					{
						geMeshDescProxy.Recover();
					}
					j++;
				}
			}
			i++;
		}
	}

	// Token: 0x060086D1 RID: 34513 RVA: 0x0017A75C File Offset: 0x00178B5C
	protected void _UpdateAnimat(float timePos, Vector3 pos)
	{
		this.m_CurParamDesc.m_ElapsedTime = timePos;
		this.m_CurParamDesc.m_WorldPos = pos;
		int i = 0;
		int count = this.m_AnimatDescList.Count;
		while (i < count)
		{
			GeAnimatManagerEx.GeAnimatDescEx geAnimatDescEx = this.m_AnimatDescList[i];
			if (geAnimatDescEx != null)
			{
				int j = 0;
				int num = geAnimatDescEx.animatProxy.Length;
				while (j < num)
				{
					GeMeshDescProxy geMeshDescProxy = geAnimatDescEx.animatProxy[j];
					if (!(null == geMeshDescProxy))
					{
						geMeshDescProxy.DoUpdate(this.m_CurParamDesc);
					}
					j++;
				}
			}
			i++;
		}
	}

	// Token: 0x060086D2 RID: 34514 RVA: 0x0017A800 File Offset: 0x00178C00
	protected GeAnimatManagerEx.GeAnimatCacheEx _GetTopAnimatCache()
	{
		for (int i = this.m_AnimatStack.Count - 1; i >= 0; i--)
		{
			GeAnimatManagerEx.GeAnimatCacheEx geAnimatCacheEx = this.m_AnimatStack[i];
			if (geAnimatCacheEx != null)
			{
				return geAnimatCacheEx;
			}
		}
		return null;
	}

	// Token: 0x040040AB RID: 16555
	protected List<GeAnimatManagerEx.GeAnimatDescEx> m_AnimatDescList = new List<GeAnimatManagerEx.GeAnimatDescEx>();

	// Token: 0x040040AC RID: 16556
	protected List<GeAnimatManagerEx.GeAnimatCacheEx> m_AnimatStack = new List<GeAnimatManagerEx.GeAnimatCacheEx>();

	// Token: 0x040040AD RID: 16557
	public GeAnimatManagerEx.GeAnimatDescEx sInvalidAnimatDesc = new GeAnimatManagerEx.GeAnimatDescEx(null, null);

	// Token: 0x040040AE RID: 16558
	protected uint m_CurAnimHandleCnt;

	// Token: 0x040040AF RID: 16559
	protected GeSurfParamDesc m_CurParamDesc;

	// Token: 0x040040B0 RID: 16560
	protected bool m_IsDirty;

	// Token: 0x02000CD3 RID: 3283
	public class GeAnimatDescEx
	{
		// Token: 0x060086D5 RID: 34517 RVA: 0x0017A8B2 File Offset: 0x00178CB2
		public GeAnimatDescEx(GameObject o, GeMeshDescProxy[] a)
		{
			this.animatProxy = a;
			this.obj = o;
		}

		// Token: 0x040040B3 RID: 16563
		public GameObject obj;

		// Token: 0x040040B4 RID: 16564
		public GeMeshDescProxy[] animatProxy;
	}

	// Token: 0x02000CD4 RID: 3284
	public class GeAnimatCacheEx
	{
		// Token: 0x060086D6 RID: 34518 RVA: 0x0017A8C8 File Offset: 0x00178CC8
		public GeAnimatCacheEx(string n, uint h, float tl, bool ea, bool nr)
		{
			this.name = n;
			this.handle = h;
			this.timeLen = tl;
			this.enableAnim = ea;
			this.needRecover = nr;
			this.timePos = 0f;
			this.isPlaying = true;
			this.isFinished = false;
		}

		// Token: 0x060086D7 RID: 34519 RVA: 0x0017A91C File Offset: 0x00178D1C
		public void Update(float delta)
		{
			if (this.isPlaying)
			{
				this.timePos += delta * 0.001f;
				if (this.timeLen > 0f && this.timePos > this.timeLen)
				{
					this.isPlaying = false;
					this.isFinished = true;
				}
			}
		}

		// Token: 0x040040B5 RID: 16565
		public string name;

		// Token: 0x040040B6 RID: 16566
		public uint handle;

		// Token: 0x040040B7 RID: 16567
		public float timeLen;

		// Token: 0x040040B8 RID: 16568
		public float timePos;

		// Token: 0x040040B9 RID: 16569
		public bool enableAnim;

		// Token: 0x040040BA RID: 16570
		public bool needRecover;

		// Token: 0x040040BB RID: 16571
		public bool isPlaying;

		// Token: 0x040040BC RID: 16572
		public bool isFinished;
	}
}
