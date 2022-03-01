using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000111 RID: 273
public class DictionaryObjectView<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	// Token: 0x060005F6 RID: 1526 RVA: 0x000254BC File Offset: 0x000238BC
	public DictionaryObjectView()
	{
		this.Context = new Dictionary<object, object>();
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060005F7 RID: 1527 RVA: 0x000254CF File Offset: 0x000238CF
	public int Count
	{
		get
		{
			return this.Context.Count;
		}
	}

	// Token: 0x17000066 RID: 102
	public TValue this[TKey key]
	{
		get
		{
			object obj = this.Context[key];
			return (obj == null) ? default(TValue) : ((TValue)((object)obj));
		}
		set
		{
			this.Context[key] = value;
		}
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x0002552E File Offset: 0x0002392E
	public void Add(TKey key, TValue value)
	{
		this.Context.Add(key, value);
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00025547 File Offset: 0x00023947
	public void Clear()
	{
		this.Context.Clear();
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x00025554 File Offset: 0x00023954
	public bool ContainsKey(TKey key)
	{
		return this.Context.ContainsKey(key);
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x00025567 File Offset: 0x00023967
	public bool Remove(TKey key)
	{
		return this.Context.Remove(key);
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x0002557C File Offset: 0x0002397C
	public bool TryGetValue(TKey key, out TValue value)
	{
		object obj = null;
		bool result = this.Context.TryGetValue(key, out obj);
		value = ((obj == null) ? default(TValue) : ((TValue)((object)obj)));
		return result;
	}

	// Token: 0x17000067 RID: 103
	// (get) Token: 0x060005FF RID: 1535 RVA: 0x000255C0 File Offset: 0x000239C0
	public Dictionary<object, object>.KeyCollection Keys
	{
		get
		{
			return this.Context.Keys;
		}
	}

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x06000600 RID: 1536 RVA: 0x000255CD File Offset: 0x000239CD
	public Dictionary<object, object>.ValueCollection Values
	{
		get
		{
			return this.Context.Values;
		}
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x000255DA File Offset: 0x000239DA
	public DictionaryObjectView<TKey, TValue>.Enumerator GetEnumerator()
	{
		return new DictionaryObjectView<TKey, TValue>.Enumerator(this.Context);
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x000255E7 File Offset: 0x000239E7
	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x000255F4 File Offset: 0x000239F4
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}

	// Token: 0x0400050B RID: 1291
	protected Dictionary<object, object> Context;

	// Token: 0x02000112 RID: 274
	public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator
	{
		// Token: 0x06000604 RID: 1540 RVA: 0x000255FB File Offset: 0x000239FB
		public Enumerator(Dictionary<object, object> InReference)
		{
			this.Reference = InReference;
			this.Iter = this.Reference.GetEnumerator();
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000605 RID: 1541 RVA: 0x00025618 File Offset: 0x00023A18
		public KeyValuePair<TKey, TValue> Current
		{
			get
			{
				KeyValuePair<object, object> keyValuePair = this.Iter.Current;
				TKey key;
				if (keyValuePair.Key != null)
				{
					KeyValuePair<object, object> keyValuePair2 = this.Iter.Current;
					key = (TKey)((object)keyValuePair2.Key);
				}
				else
				{
					key = default(TKey);
				}
				KeyValuePair<object, object> keyValuePair3 = this.Iter.Current;
				TValue value;
				if (keyValuePair3.Value != null)
				{
					KeyValuePair<object, object> keyValuePair4 = this.Iter.Current;
					value = (TValue)((object)keyValuePair4.Value);
				}
				else
				{
					value = default(TValue);
				}
				return new KeyValuePair<TKey, TValue>(key, value);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x000256A8 File Offset: 0x00023AA8
		object IEnumerator.Current
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000256AF File Offset: 0x00023AAF
		public void Reset()
		{
			this.Iter = this.Reference.GetEnumerator();
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000256C2 File Offset: 0x00023AC2
		public void Dispose()
		{
			this.Iter.Dispose();
			this.Reference = null;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x000256D6 File Offset: 0x00023AD6
		public bool MoveNext()
		{
			return this.Iter.MoveNext();
		}

		// Token: 0x0400050C RID: 1292
		private Dictionary<object, object> Reference;

		// Token: 0x0400050D RID: 1293
		private Dictionary<object, object>.Enumerator Iter;
	}
}
