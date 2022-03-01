using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200010F RID: 271
public class DictionaryView<TKey, TValue> : IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>> where TValue : class
{
	// Token: 0x060005E1 RID: 1505 RVA: 0x000252D4 File Offset: 0x000236D4
	public DictionaryView()
	{
		this.Context = new Dictionary<TKey, object>();
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x000252E7 File Offset: 0x000236E7
	public DictionaryView(int capacity)
	{
		this.Context = new Dictionary<TKey, object>(capacity);
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x000252FB File Offset: 0x000236FB
	public void Add(TKey key, TValue value)
	{
		this.Context.Add(key, value);
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x0002530F File Offset: 0x0002370F
	public void Clear()
	{
		this.Context.Clear();
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x0002531C File Offset: 0x0002371C
	public bool ContainsKey(TKey key)
	{
		return this.Context.ContainsKey(key);
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x0002532A File Offset: 0x0002372A
	public DictionaryView<TKey, TValue>.Enumerator GetEnumerator()
	{
		return new DictionaryView<TKey, TValue>.Enumerator(this.Context);
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x00025337 File Offset: 0x00023737
	public bool Remove(TKey key)
	{
		return this.Context.Remove(key);
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x00025345 File Offset: 0x00023745
	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x00025352 File Offset: 0x00023752
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x0002535C File Offset: 0x0002375C
	public bool TryGetValue(TKey key, out TValue value)
	{
		object obj = null;
		bool result = this.Context.TryGetValue(key, out obj);
		value = ((obj != null) ? ((TValue)((object)obj)) : ((TValue)((object)null)));
		return result;
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060005EB RID: 1515 RVA: 0x00025398 File Offset: 0x00023798
	public int Count
	{
		get
		{
			return this.Context.Count;
		}
	}

	// Token: 0x17000060 RID: 96
	public TValue this[TKey key]
	{
		get
		{
			object obj = this.Context[key];
			return (obj != null) ? ((TValue)((object)obj)) : ((TValue)((object)null));
		}
		set
		{
			this.Context[key] = value;
		}
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060005EE RID: 1518 RVA: 0x000253ED File Offset: 0x000237ED
	public Dictionary<TKey, object>.KeyCollection Keys
	{
		get
		{
			return this.Context.Keys;
		}
	}

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x060005EF RID: 1519 RVA: 0x000253FA File Offset: 0x000237FA
	public Dictionary<TKey, object>.ValueCollection Values
	{
		get
		{
			return this.Context.Values;
		}
	}

	// Token: 0x04000508 RID: 1288
	protected Dictionary<TKey, object> Context;

	// Token: 0x02000110 RID: 272
	public struct Enumerator : IDisposable, IEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
	{
		// Token: 0x060005F0 RID: 1520 RVA: 0x00025407 File Offset: 0x00023807
		public Enumerator(Dictionary<TKey, object> InReference)
		{
			this.Reference = InReference;
			this.Iter = this.Reference.GetEnumerator();
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00025421 File Offset: 0x00023821
		object IEnumerator.Current
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00025428 File Offset: 0x00023828
		public KeyValuePair<TKey, TValue> Current
		{
			get
			{
				KeyValuePair<TKey, object> keyValuePair = this.Iter.Current;
				TKey key = keyValuePair.Key;
				KeyValuePair<TKey, object> keyValuePair2 = this.Iter.Current;
				object obj;
				if (keyValuePair2.Value == null)
				{
					obj = null;
				}
				else
				{
					KeyValuePair<TKey, object> keyValuePair3 = this.Iter.Current;
					obj = keyValuePair3.Value;
				}
				return new KeyValuePair<TKey, TValue>(key, obj as TValue);
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00025488 File Offset: 0x00023888
		public void Reset()
		{
			this.Iter = this.Reference.GetEnumerator();
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0002549B File Offset: 0x0002389B
		public void Dispose()
		{
			this.Iter.Dispose();
			this.Reference = null;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x000254AF File Offset: 0x000238AF
		public bool MoveNext()
		{
			return this.Iter.MoveNext();
		}

		// Token: 0x04000509 RID: 1289
		private Dictionary<TKey, object> Reference;

		// Token: 0x0400050A RID: 1290
		private Dictionary<TKey, object>.Enumerator Iter;
	}
}
