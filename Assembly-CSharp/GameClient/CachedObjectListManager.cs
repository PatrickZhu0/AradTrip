using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000DB8 RID: 3512
	public class CachedObjectListManager<TValue> where TValue : CachedObject, new()
	{
		// Token: 0x06008DF4 RID: 36340 RVA: 0x001A68B0 File Offset: 0x001A4CB0
		public CachedObjectListManager()
		{
			this.m_akCachedObject.Clear();
			this.m_akActivedObject.Clear();
		}

		// Token: 0x06008DF5 RID: 36341 RVA: 0x001A68E4 File Offset: 0x001A4CE4
		public TValue Find(Predicate<TValue> match)
		{
			return this.m_akActivedObject.Find(match);
		}

		// Token: 0x06008DF6 RID: 36342 RVA: 0x001A68F4 File Offset: 0x001A4CF4
		public void Recycle(Predicate<TValue> match)
		{
			TValue tvalue = this.m_akActivedObject.Find(match);
			if (tvalue != null)
			{
				this.RecycleObject(tvalue);
			}
		}

		// Token: 0x06008DF7 RID: 36343 RVA: 0x001A6920 File Offset: 0x001A4D20
		public void RefreshAllObjects(object[] param)
		{
			for (int i = 0; i < this.m_akActivedObject.Count; i++)
			{
				TValue tvalue = this.m_akActivedObject[i];
				tvalue.OnRefresh(param);
			}
		}

		// Token: 0x06008DF8 RID: 36344 RVA: 0x001A6964 File Offset: 0x001A4D64
		public TValue Create(object[] param)
		{
			TValue tvalue = (TValue)((object)null);
			if (this.m_akCachedObject.Count > 0)
			{
				tvalue = this.m_akCachedObject[0];
				this.m_akCachedObject.RemoveAt(0);
				tvalue.OnDecycle(param);
			}
			else
			{
				tvalue = Activator.CreateInstance<TValue>();
				tvalue.OnCreate(param);
			}
			this.m_akActivedObject.Add(tvalue);
			return tvalue;
		}

		// Token: 0x06008DF9 RID: 36345 RVA: 0x001A69D6 File Offset: 0x001A4DD6
		public void RecycleObject(TValue current)
		{
			if (current != null)
			{
				this.m_akActivedObject.Remove(current);
				this.m_akCachedObject.Add(current);
				current.OnRecycle();
			}
		}

		// Token: 0x06008DFA RID: 36346 RVA: 0x001A6A0C File Offset: 0x001A4E0C
		public void DestroyAllObjects()
		{
			for (int i = 0; i < this.m_akActivedObject.Count; i++)
			{
				TValue tvalue = this.m_akActivedObject[i];
				tvalue.OnDestroy();
			}
			this.m_akActivedObject.Clear();
			for (int j = 0; j < this.m_akCachedObject.Count; j++)
			{
				TValue tvalue2 = this.m_akCachedObject[j];
				tvalue2.OnDestroy();
			}
			this.m_akCachedObject.Clear();
		}

		// Token: 0x06008DFB RID: 36347 RVA: 0x001A6A9C File Offset: 0x001A4E9C
		public void RecycleAllObject()
		{
			while (this.m_akActivedObject.Count > 0)
			{
				TValue tvalue = this.m_akActivedObject[this.m_akActivedObject.Count - 1];
				if (tvalue != null)
				{
					this.m_akCachedObject.Add(tvalue);
					tvalue.OnRecycle();
				}
				this.m_akActivedObject.RemoveAt(this.m_akActivedObject.Count - 1);
			}
		}

		// Token: 0x06008DFC RID: 36348 RVA: 0x001A6B14 File Offset: 0x001A4F14
		public void Filter(object[] param = null)
		{
			for (int i = 0; i < this.m_akActivedObject.Count; i++)
			{
				TValue tvalue = this.m_akActivedObject[i];
				if (tvalue.NeedFilter(param))
				{
					TValue tvalue2 = this.m_akActivedObject[i];
					tvalue2.Disable();
				}
				else
				{
					TValue tvalue3 = this.m_akActivedObject[i];
					tvalue3.Enable();
				}
			}
		}

		// Token: 0x06008DFD RID: 36349 RVA: 0x001A6B96 File Offset: 0x001A4F96
		public void FilterObject(TValue current, object[] param = null)
		{
			if (current.NeedFilter(param))
			{
				current.Disable();
			}
			else
			{
				current.Enable();
			}
		}

		// Token: 0x06008DFE RID: 36350 RVA: 0x001A6BCA File Offset: 0x001A4FCA
		public void Clear()
		{
			this.m_akCachedObject.Clear();
			this.m_akActivedObject.Clear();
		}

		// Token: 0x06008DFF RID: 36351 RVA: 0x001A6BE2 File Offset: 0x001A4FE2
		public TValue GetChild(int iIndex)
		{
			if (iIndex >= 0 && iIndex < this.m_akActivedObject.Count)
			{
				return this.m_akActivedObject[iIndex];
			}
			return (TValue)((object)null);
		}

		// Token: 0x170018CD RID: 6349
		// (get) Token: 0x06008E00 RID: 36352 RVA: 0x001A6C0F File Offset: 0x001A500F
		public int ChildCount
		{
			get
			{
				return this.m_akActivedObject.Count;
			}
		}

		// Token: 0x170018CE RID: 6350
		// (get) Token: 0x06008E01 RID: 36353 RVA: 0x001A6C1C File Offset: 0x001A501C
		public List<TValue> ActiveObjects
		{
			get
			{
				return this.m_akActivedObject;
			}
		}

		// Token: 0x0400467C RID: 18044
		private List<TValue> m_akCachedObject = new List<TValue>();

		// Token: 0x0400467D RID: 18045
		private List<TValue> m_akActivedObject = new List<TValue>();
	}
}
