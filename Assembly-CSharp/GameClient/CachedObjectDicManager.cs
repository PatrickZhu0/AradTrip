using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000DB7 RID: 3511
	public class CachedObjectDicManager<Tkey, TValue> where TValue : CachedObject, new()
	{
		// Token: 0x06008DE3 RID: 36323 RVA: 0x001A6358 File Offset: 0x001A4758
		public TValue Create(Tkey key, object[] param)
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
			this.m_akActivedObject.Add(key, tvalue);
			return tvalue;
		}

		// Token: 0x06008DE4 RID: 36324 RVA: 0x001A63CB File Offset: 0x001A47CB
		public bool HasObject(Tkey key)
		{
			return this.m_akActivedObject.Count > 0 && this.m_akActivedObject.ContainsKey(key);
		}

		// Token: 0x06008DE5 RID: 36325 RVA: 0x001A63F0 File Offset: 0x001A47F0
		public TValue RefreshObject(Tkey key, object[] param = null)
		{
			TValue result = (TValue)((object)null);
			if (this.m_akActivedObject.TryGetValue(key, out result))
			{
				result.OnRefresh(param);
			}
			return result;
		}

		// Token: 0x06008DE6 RID: 36326 RVA: 0x001A6428 File Offset: 0x001A4828
		public void RefreshAllObjects(object[] param = null)
		{
			foreach (KeyValuePair<Tkey, TValue> keyValuePair in this.m_akActivedObject)
			{
				TValue value = keyValuePair.Value;
				value.OnRefresh(param);
			}
		}

		// Token: 0x06008DE7 RID: 36327 RVA: 0x001A6470 File Offset: 0x001A4870
		public void RecycleObjectByFilter(Predicate<TValue> match)
		{
			List<Tkey> list = this.m_akActivedObject.Keys.ToList<Tkey>();
			List<TValue> list2 = this.m_akActivedObject.Values.ToList<TValue>();
			for (int i = 0; i < list2.Count; i++)
			{
				if (match(list2[i]))
				{
					this.RecycleObject(list[i]);
				}
			}
			list.Clear();
			list2.Clear();
		}

		// Token: 0x06008DE8 RID: 36328 RVA: 0x001A64E4 File Offset: 0x001A48E4
		public List<TValue> GetObjectListByFilter(object[] param = null)
		{
			List<TValue> list = new List<TValue>();
			List<TValue> list2 = this.m_akActivedObject.Values.ToList<TValue>();
			for (int i = 0; i < list2.Count; i++)
			{
				TValue tvalue = list2[i];
				if (!tvalue.NeedFilter(param))
				{
					list.Add(list2[i]);
				}
			}
			return list;
		}

		// Token: 0x06008DE9 RID: 36329 RVA: 0x001A6548 File Offset: 0x001A4948
		public bool HasObject(object[] param)
		{
			List<TValue> list = this.m_akActivedObject.Values.ToList<TValue>();
			for (int i = 0; i < list.Count; i++)
			{
				TValue tvalue = list[i];
				if (!tvalue.NeedFilter(param))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06008DEA RID: 36330 RVA: 0x001A659C File Offset: 0x001A499C
		public TValue GetObject(Tkey key)
		{
			TValue result = (TValue)((object)null);
			this.m_akActivedObject.TryGetValue(key, out result);
			return result;
		}

		// Token: 0x06008DEB RID: 36331 RVA: 0x001A65C0 File Offset: 0x001A49C0
		public void FilterObject(Tkey key, object[] param = null)
		{
			TValue tvalue = (TValue)((object)null);
			if (this.m_akActivedObject.TryGetValue(key, out tvalue))
			{
				if (tvalue.NeedFilter(param))
				{
					tvalue.Disable();
				}
				else
				{
					tvalue.Enable();
				}
			}
		}

		// Token: 0x06008DEC RID: 36332 RVA: 0x001A661C File Offset: 0x001A4A1C
		public void DestroyObject(Tkey key)
		{
			TValue tvalue = (TValue)((object)null);
			if (this.m_akActivedObject.TryGetValue(key, out tvalue))
			{
				this.m_akActivedObject.Remove(key);
				tvalue.OnDestroy();
			}
		}

		// Token: 0x06008DED RID: 36333 RVA: 0x001A6660 File Offset: 0x001A4A60
		public void DestroyAllObjects()
		{
			List<TValue> list = this.m_akActivedObject.Values.ToList<TValue>();
			for (int i = 0; i < list.Count; i++)
			{
				TValue tvalue = list[i];
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

		// Token: 0x06008DEE RID: 36334 RVA: 0x001A66F8 File Offset: 0x001A4AF8
		public TValue RebuildOrCreate(Tkey kRecycled, Tkey key, object[] param)
		{
			if (!this.m_akActivedObject.ContainsKey(kRecycled))
			{
				return this.Create(key, param);
			}
			TValue tvalue = this.m_akActivedObject[kRecycled];
			this.m_akActivedObject.Remove(kRecycled);
			this.m_akActivedObject.Add(key, tvalue);
			tvalue.OnCreate(param);
			return tvalue;
		}

		// Token: 0x06008DEF RID: 36335 RVA: 0x001A6758 File Offset: 0x001A4B58
		public void RecycleObject(Tkey key)
		{
			TValue item = (TValue)((object)null);
			if (this.m_akActivedObject.TryGetValue(key, out item))
			{
				this.m_akActivedObject.Remove(key);
				this.m_akCachedObject.Add(item);
				item.OnRecycle();
			}
		}

		// Token: 0x06008DF0 RID: 36336 RVA: 0x001A67A8 File Offset: 0x001A4BA8
		public void RecycleAllObject()
		{
			List<TValue> list = this.m_akActivedObject.Values.ToList<TValue>();
			for (int i = 0; i < list.Count; i++)
			{
				this.m_akCachedObject.Add(list[i]);
				TValue tvalue = list[i];
				tvalue.OnRecycle();
			}
			this.m_akActivedObject.Clear();
		}

		// Token: 0x06008DF1 RID: 36337 RVA: 0x001A6810 File Offset: 0x001A4C10
		public void Filter(object[] param)
		{
			List<TValue> list = this.m_akActivedObject.Values.ToList<TValue>();
			for (int i = 0; i < list.Count; i++)
			{
				TValue tvalue = list[i];
				if (tvalue.NeedFilter(param))
				{
					TValue tvalue2 = list[i];
					tvalue2.Disable();
				}
				else
				{
					TValue tvalue3 = list[i];
					tvalue3.Enable();
				}
			}
		}

		// Token: 0x170018CC RID: 6348
		// (get) Token: 0x06008DF2 RID: 36338 RVA: 0x001A6890 File Offset: 0x001A4C90
		public Dictionary<Tkey, TValue> ActiveObjects
		{
			get
			{
				return this.m_akActivedObject;
			}
		}

		// Token: 0x06008DF3 RID: 36339 RVA: 0x001A6898 File Offset: 0x001A4C98
		public void Clear()
		{
			this.m_akActivedObject.Clear();
			this.m_akCachedObject.Clear();
		}

		// Token: 0x0400467A RID: 18042
		private Dictionary<Tkey, TValue> m_akActivedObject = new Dictionary<Tkey, TValue>();

		// Token: 0x0400467B RID: 18043
		private List<TValue> m_akCachedObject = new List<TValue>();
	}
}
