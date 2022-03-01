using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000113 RID: 275
public class ListView<T> : ListViewBase, IEnumerable, IEnumerable<T>
{
	// Token: 0x0600060A RID: 1546 RVA: 0x0002573C File Offset: 0x00023B3C
	public ListView()
	{
		this.Context = new List<object>();
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x0002574F File Offset: 0x00023B4F
	public ListView(int capacity)
	{
		this.Context = new List<object>(capacity);
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x00025764 File Offset: 0x00023B64
	public ListView(IEnumerable<T> collection)
	{
		this.Context = new List<object>();
		foreach (T t in collection)
		{
			this.Context.Add(t);
		}
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x000257AF File Offset: 0x00023BAF
	public void Add(T item)
	{
		this.Context.Add(item);
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x000257C4 File Offset: 0x00023BC4
	public void AddRange(IEnumerable<T> collection)
	{
		if (collection != null)
		{
			foreach (T t in collection)
			{
				this.Context.Add(t);
			}
		}
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x00025804 File Offset: 0x00023C04
	public int BinarySearch(T item, IComparer<T> comparer)
	{
		return this.Context.BinarySearch(item, new ListView<T>.ComparerConverter(comparer));
	}

	// Token: 0x06000610 RID: 1552 RVA: 0x00025822 File Offset: 0x00023C22
	public bool Contains(T item)
	{
		return this.Context.Contains(item);
	}

	// Token: 0x06000611 RID: 1553 RVA: 0x00025835 File Offset: 0x00023C35
	public ListView<T>.Enumerator GetEnumerator()
	{
		return new ListView<T>.Enumerator(this.Context);
	}

	// Token: 0x06000612 RID: 1554 RVA: 0x00025842 File Offset: 0x00023C42
	public int IndexOf(T item)
	{
		return this.Context.IndexOf(item);
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x00025855 File Offset: 0x00023C55
	public void Insert(int index, T item)
	{
		this.Context.Insert(index, item);
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x00025869 File Offset: 0x00023C69
	public int LastIndexOf(T item)
	{
		return this.Context.LastIndexOf(item);
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x0002587C File Offset: 0x00023C7C
	public bool Remove(T item)
	{
		return this.Context.Remove(item);
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x0002588F File Offset: 0x00023C8F
	public void Sort(IComparer<T> comparer)
	{
		this.Context.Sort(new ListView<T>.ComparerConverter(comparer));
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x000258A7 File Offset: 0x00023CA7
	public void Sort(Comparison<T> comparison)
	{
		this.Context.Sort(new ListView<T>.ComparisonConverter(comparison));
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x000258BF File Offset: 0x00023CBF
	IEnumerator<T> IEnumerable<!0>.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x000258CC File Offset: 0x00023CCC
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}

	// Token: 0x1700006B RID: 107
	public T this[int index]
	{
		get
		{
			return (T)((object)this.Context[index]);
		}
		set
		{
			this.Context[index] = value;
		}
	}

	// Token: 0x02000114 RID: 276
	private struct ComparerConverter : IComparer<object>
	{
		// Token: 0x0600061C RID: 1564 RVA: 0x000258FA File Offset: 0x00023CFA
		public ComparerConverter(IComparer<T> comparer)
		{
			this.ComparerRef = comparer;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00025903 File Offset: 0x00023D03
		public int Compare(object x, object y)
		{
			return this.ComparerRef.Compare((T)((object)x), (T)((object)y));
		}

		// Token: 0x0400050E RID: 1294
		private IComparer<T> ComparerRef;
	}

	// Token: 0x02000115 RID: 277
	private struct ComparisonConverter : IComparer<object>
	{
		// Token: 0x0600061E RID: 1566 RVA: 0x0002591C File Offset: 0x00023D1C
		public ComparisonConverter(Comparison<T> comparer)
		{
			this.ComparerRef = comparer;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00025925 File Offset: 0x00023D25
		public int Compare(object x, object y)
		{
			return this.ComparerRef((T)((object)x), (T)((object)y));
		}

		// Token: 0x0400050F RID: 1295
		private Comparison<T> ComparerRef;
	}

	// Token: 0x02000116 RID: 278
	public struct Enumerator : IDisposable, IEnumerator, IEnumerator<T>
	{
		// Token: 0x06000620 RID: 1568 RVA: 0x0002593E File Offset: 0x00023D3E
		public Enumerator(List<object> InReference)
		{
			this.Reference = InReference;
			this.Iter = this.Reference.GetEnumerator();
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x00025958 File Offset: 0x00023D58
		object IEnumerator.Current
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x0002595F File Offset: 0x00023D5F
		public T Current
		{
			get
			{
				return (T)((object)this.Iter.Current);
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00025971 File Offset: 0x00023D71
		public void Reset()
		{
			this.Iter = this.Reference.GetEnumerator();
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00025984 File Offset: 0x00023D84
		public void Dispose()
		{
			this.Iter.Dispose();
			this.Reference = null;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00025998 File Offset: 0x00023D98
		public bool MoveNext()
		{
			return this.Iter.MoveNext();
		}

		// Token: 0x04000510 RID: 1296
		private List<object> Reference;

		// Token: 0x04000511 RID: 1297
		private List<object>.Enumerator Iter;
	}
}
