using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Spine
{
	// Token: 0x020049C0 RID: 18880
	[DebuggerDisplay("Count={Count}")]
	[Serializable]
	public class ExposedList<T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x0601B2A0 RID: 111264 RVA: 0x00858F84 File Offset: 0x00857384
		public ExposedList()
		{
			this.Items = ExposedList<T>.EmptyArray;
		}

		// Token: 0x0601B2A1 RID: 111265 RVA: 0x00858F98 File Offset: 0x00857398
		public ExposedList(IEnumerable<T> collection)
		{
			this.CheckCollection(collection);
			ICollection<T> collection2 = collection as ICollection<T>;
			if (collection2 == null)
			{
				this.Items = ExposedList<T>.EmptyArray;
				this.AddEnumerable(collection);
			}
			else
			{
				this.Items = new T[collection2.Count];
				this.AddCollection(collection2);
			}
		}

		// Token: 0x0601B2A2 RID: 111266 RVA: 0x00858FEE File Offset: 0x008573EE
		public ExposedList(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			this.Items = new T[capacity];
		}

		// Token: 0x0601B2A3 RID: 111267 RVA: 0x00859014 File Offset: 0x00857414
		internal ExposedList(T[] data, int size)
		{
			this.Items = data;
			this.Count = size;
		}

		// Token: 0x0601B2A4 RID: 111268 RVA: 0x0085902C File Offset: 0x0085742C
		public void Add(T item)
		{
			if (this.Count == this.Items.Length)
			{
				this.GrowIfNeeded(1);
			}
			this.Items[this.Count++] = item;
			this.version++;
		}

		// Token: 0x0601B2A5 RID: 111269 RVA: 0x00859080 File Offset: 0x00857480
		public void GrowIfNeeded(int newCount)
		{
			int num = this.Count + newCount;
			if (num > this.Items.Length)
			{
				this.Capacity = Math.Max(Math.Max(this.Capacity * 2, 4), num);
			}
		}

		// Token: 0x0601B2A6 RID: 111270 RVA: 0x008590C0 File Offset: 0x008574C0
		public ExposedList<T> Resize(int newSize)
		{
			int num = this.Items.Length;
			T[] items = this.Items;
			if (newSize > num)
			{
				Array.Resize<T>(ref this.Items, newSize);
			}
			else if (newSize < num)
			{
				for (int i = newSize; i < num; i++)
				{
					items[i] = default(T);
				}
			}
			this.Count = newSize;
			return this;
		}

		// Token: 0x0601B2A7 RID: 111271 RVA: 0x00859128 File Offset: 0x00857528
		public void EnsureCapacity(int min)
		{
			if (this.Items.Length < min)
			{
				int num = (this.Items.Length != 0) ? (this.Items.Length * 2) : 4;
				if (num < min)
				{
					num = min;
				}
				this.Capacity = num;
			}
		}

		// Token: 0x0601B2A8 RID: 111272 RVA: 0x00859171 File Offset: 0x00857571
		private void CheckRange(int index, int count)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index + count > this.Count)
			{
				throw new ArgumentException("index and count exceed length of list");
			}
		}

		// Token: 0x0601B2A9 RID: 111273 RVA: 0x008591B0 File Offset: 0x008575B0
		private void AddCollection(ICollection<T> collection)
		{
			int count = collection.Count;
			if (count == 0)
			{
				return;
			}
			this.GrowIfNeeded(count);
			collection.CopyTo(this.Items, this.Count);
			this.Count += count;
		}

		// Token: 0x0601B2AA RID: 111274 RVA: 0x008591F4 File Offset: 0x008575F4
		private void AddEnumerable(IEnumerable<T> enumerable)
		{
			foreach (T item in enumerable)
			{
				this.Add(item);
			}
		}

		// Token: 0x0601B2AB RID: 111275 RVA: 0x00859248 File Offset: 0x00857648
		public void AddRange(IEnumerable<T> collection)
		{
			this.CheckCollection(collection);
			ICollection<T> collection2 = collection as ICollection<T>;
			if (collection2 != null)
			{
				this.AddCollection(collection2);
			}
			else
			{
				this.AddEnumerable(collection);
			}
			this.version++;
		}

		// Token: 0x0601B2AC RID: 111276 RVA: 0x0085928A File Offset: 0x0085768A
		public int BinarySearch(T item)
		{
			return Array.BinarySearch<T>(this.Items, 0, this.Count, item);
		}

		// Token: 0x0601B2AD RID: 111277 RVA: 0x0085929F File Offset: 0x0085769F
		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return Array.BinarySearch<T>(this.Items, 0, this.Count, item, comparer);
		}

		// Token: 0x0601B2AE RID: 111278 RVA: 0x008592B5 File Offset: 0x008576B5
		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			this.CheckRange(index, count);
			return Array.BinarySearch<T>(this.Items, index, count, item, comparer);
		}

		// Token: 0x0601B2AF RID: 111279 RVA: 0x008592CF File Offset: 0x008576CF
		public void Clear(bool clearArray = true)
		{
			if (clearArray)
			{
				Array.Clear(this.Items, 0, this.Items.Length);
			}
			this.Count = 0;
			this.version++;
		}

		// Token: 0x0601B2B0 RID: 111280 RVA: 0x00859300 File Offset: 0x00857700
		public bool Contains(T item)
		{
			return Array.IndexOf<T>(this.Items, item, 0, this.Count) != -1;
		}

		// Token: 0x0601B2B1 RID: 111281 RVA: 0x0085931C File Offset: 0x0085771C
		public ExposedList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			if (converter == null)
			{
				throw new ArgumentNullException("converter");
			}
			ExposedList<TOutput> exposedList = new ExposedList<TOutput>(this.Count);
			for (int i = 0; i < this.Count; i++)
			{
				exposedList.Items[i] = converter(this.Items[i]);
			}
			exposedList.Count = this.Count;
			return exposedList;
		}

		// Token: 0x0601B2B2 RID: 111282 RVA: 0x00859388 File Offset: 0x00857788
		public void CopyTo(T[] array)
		{
			Array.Copy(this.Items, 0, array, 0, this.Count);
		}

		// Token: 0x0601B2B3 RID: 111283 RVA: 0x0085939E File Offset: 0x0085779E
		public void CopyTo(T[] array, int arrayIndex)
		{
			Array.Copy(this.Items, 0, array, arrayIndex, this.Count);
		}

		// Token: 0x0601B2B4 RID: 111284 RVA: 0x008593B4 File Offset: 0x008577B4
		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			this.CheckRange(index, count);
			Array.Copy(this.Items, index, array, arrayIndex, count);
		}

		// Token: 0x0601B2B5 RID: 111285 RVA: 0x008593CF File Offset: 0x008577CF
		public bool Exists(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.GetIndex(0, this.Count, match) != -1;
		}

		// Token: 0x0601B2B6 RID: 111286 RVA: 0x008593EC File Offset: 0x008577EC
		public T Find(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int index = this.GetIndex(0, this.Count, match);
			return (index == -1) ? default(T) : this.Items[index];
		}

		// Token: 0x0601B2B7 RID: 111287 RVA: 0x0085942F File Offset: 0x0085782F
		private static void CheckMatch(Predicate<T> match)
		{
			if (match == null)
			{
				throw new ArgumentNullException("match");
			}
		}

		// Token: 0x0601B2B8 RID: 111288 RVA: 0x00859442 File Offset: 0x00857842
		public ExposedList<T> FindAll(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.FindAllList(match);
		}

		// Token: 0x0601B2B9 RID: 111289 RVA: 0x00859454 File Offset: 0x00857854
		private ExposedList<T> FindAllList(Predicate<T> match)
		{
			ExposedList<T> exposedList = new ExposedList<T>();
			for (int i = 0; i < this.Count; i++)
			{
				if (match(this.Items[i]))
				{
					exposedList.Add(this.Items[i]);
				}
			}
			return exposedList;
		}

		// Token: 0x0601B2BA RID: 111290 RVA: 0x008594A8 File Offset: 0x008578A8
		public int FindIndex(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.GetIndex(0, this.Count, match);
		}

		// Token: 0x0601B2BB RID: 111291 RVA: 0x008594BE File Offset: 0x008578BE
		public int FindIndex(int startIndex, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			this.CheckIndex(startIndex);
			return this.GetIndex(startIndex, this.Count - startIndex, match);
		}

		// Token: 0x0601B2BC RID: 111292 RVA: 0x008594DD File Offset: 0x008578DD
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			this.CheckRange(startIndex, count);
			return this.GetIndex(startIndex, count, match);
		}

		// Token: 0x0601B2BD RID: 111293 RVA: 0x008594F8 File Offset: 0x008578F8
		private int GetIndex(int startIndex, int count, Predicate<T> match)
		{
			int num = startIndex + count;
			for (int i = startIndex; i < num; i++)
			{
				if (match(this.Items[i]))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0601B2BE RID: 111294 RVA: 0x00859538 File Offset: 0x00857938
		public T FindLast(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int lastIndex = this.GetLastIndex(0, this.Count, match);
			return (lastIndex != -1) ? this.Items[lastIndex] : default(T);
		}

		// Token: 0x0601B2BF RID: 111295 RVA: 0x0085957B File Offset: 0x0085797B
		public int FindLastIndex(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			return this.GetLastIndex(0, this.Count, match);
		}

		// Token: 0x0601B2C0 RID: 111296 RVA: 0x00859591 File Offset: 0x00857991
		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			this.CheckIndex(startIndex);
			return this.GetLastIndex(0, startIndex + 1, match);
		}

		// Token: 0x0601B2C1 RID: 111297 RVA: 0x008595AC File Offset: 0x008579AC
		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int num = startIndex - count + 1;
			this.CheckRange(num, count);
			return this.GetLastIndex(num, count, match);
		}

		// Token: 0x0601B2C2 RID: 111298 RVA: 0x008595D8 File Offset: 0x008579D8
		private int GetLastIndex(int startIndex, int count, Predicate<T> match)
		{
			int num = startIndex + count;
			while (num != startIndex)
			{
				if (match(this.Items[--num]))
				{
					return num;
				}
			}
			return -1;
		}

		// Token: 0x0601B2C3 RID: 111299 RVA: 0x00859614 File Offset: 0x00857A14
		public void ForEach(Action<T> action)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			for (int i = 0; i < this.Count; i++)
			{
				action(this.Items[i]);
			}
		}

		// Token: 0x0601B2C4 RID: 111300 RVA: 0x0085965B File Offset: 0x00857A5B
		public ExposedList<T>.Enumerator GetEnumerator()
		{
			return new ExposedList<T>.Enumerator(this);
		}

		// Token: 0x0601B2C5 RID: 111301 RVA: 0x00859664 File Offset: 0x00857A64
		public ExposedList<T> GetRange(int index, int count)
		{
			this.CheckRange(index, count);
			T[] array = new T[count];
			Array.Copy(this.Items, index, array, 0, count);
			return new ExposedList<T>(array, count);
		}

		// Token: 0x0601B2C6 RID: 111302 RVA: 0x00859696 File Offset: 0x00857A96
		public int IndexOf(T item)
		{
			return Array.IndexOf<T>(this.Items, item, 0, this.Count);
		}

		// Token: 0x0601B2C7 RID: 111303 RVA: 0x008596AB File Offset: 0x00857AAB
		public int IndexOf(T item, int index)
		{
			this.CheckIndex(index);
			return Array.IndexOf<T>(this.Items, item, index, this.Count - index);
		}

		// Token: 0x0601B2C8 RID: 111304 RVA: 0x008596CC File Offset: 0x00857ACC
		public int IndexOf(T item, int index, int count)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index + count > this.Count)
			{
				throw new ArgumentOutOfRangeException("index and count exceed length of list");
			}
			return Array.IndexOf<T>(this.Items, item, index, count);
		}

		// Token: 0x0601B2C9 RID: 111305 RVA: 0x00859724 File Offset: 0x00857B24
		private void Shift(int start, int delta)
		{
			if (delta < 0)
			{
				start -= delta;
			}
			if (start < this.Count)
			{
				Array.Copy(this.Items, start, this.Items, start + delta, this.Count - start);
			}
			this.Count += delta;
			if (delta < 0)
			{
				Array.Clear(this.Items, this.Count, -delta);
			}
		}

		// Token: 0x0601B2CA RID: 111306 RVA: 0x0085978E File Offset: 0x00857B8E
		private void CheckIndex(int index)
		{
			if (index < 0 || index > this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
		}

		// Token: 0x0601B2CB RID: 111307 RVA: 0x008597B0 File Offset: 0x00857BB0
		public void Insert(int index, T item)
		{
			this.CheckIndex(index);
			if (this.Count == this.Items.Length)
			{
				this.GrowIfNeeded(1);
			}
			this.Shift(index, 1);
			this.Items[index] = item;
			this.version++;
		}

		// Token: 0x0601B2CC RID: 111308 RVA: 0x00859801 File Offset: 0x00857C01
		private void CheckCollection(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
		}

		// Token: 0x0601B2CD RID: 111309 RVA: 0x00859814 File Offset: 0x00857C14
		public void InsertRange(int index, IEnumerable<T> collection)
		{
			this.CheckCollection(collection);
			this.CheckIndex(index);
			if (collection == this)
			{
				T[] array = new T[this.Count];
				this.CopyTo(array, 0);
				this.GrowIfNeeded(this.Count);
				this.Shift(index, array.Length);
				Array.Copy(array, 0, this.Items, index, array.Length);
			}
			else
			{
				ICollection<T> collection2 = collection as ICollection<T>;
				if (collection2 != null)
				{
					this.InsertCollection(index, collection2);
				}
				else
				{
					this.InsertEnumeration(index, collection);
				}
			}
			this.version++;
		}

		// Token: 0x0601B2CE RID: 111310 RVA: 0x008598A8 File Offset: 0x00857CA8
		private void InsertCollection(int index, ICollection<T> collection)
		{
			int count = collection.Count;
			this.GrowIfNeeded(count);
			this.Shift(index, count);
			collection.CopyTo(this.Items, index);
		}

		// Token: 0x0601B2CF RID: 111311 RVA: 0x008598D8 File Offset: 0x00857CD8
		private void InsertEnumeration(int index, IEnumerable<T> enumerable)
		{
			foreach (T item in enumerable)
			{
				this.Insert(index++, item);
			}
		}

		// Token: 0x0601B2D0 RID: 111312 RVA: 0x00859934 File Offset: 0x00857D34
		public int LastIndexOf(T item)
		{
			return Array.LastIndexOf<T>(this.Items, item, this.Count - 1, this.Count);
		}

		// Token: 0x0601B2D1 RID: 111313 RVA: 0x00859950 File Offset: 0x00857D50
		public int LastIndexOf(T item, int index)
		{
			this.CheckIndex(index);
			return Array.LastIndexOf<T>(this.Items, item, index, index + 1);
		}

		// Token: 0x0601B2D2 RID: 111314 RVA: 0x0085996C File Offset: 0x00857D6C
		public int LastIndexOf(T item, int index, int count)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", index, "index is negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, "count is negative");
			}
			if (index - count + 1 < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, "count is too large");
			}
			return Array.LastIndexOf<T>(this.Items, item, index, count);
		}

		// Token: 0x0601B2D3 RID: 111315 RVA: 0x008599E4 File Offset: 0x00857DE4
		public bool Remove(T item)
		{
			int num = this.IndexOf(item);
			if (num != -1)
			{
				this.RemoveAt(num);
			}
			return num != -1;
		}

		// Token: 0x0601B2D4 RID: 111316 RVA: 0x00859A10 File Offset: 0x00857E10
		public int RemoveAll(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			int i;
			for (i = 0; i < this.Count; i++)
			{
				if (match(this.Items[i]))
				{
					break;
				}
			}
			if (i == this.Count)
			{
				return 0;
			}
			this.version++;
			int j;
			for (j = i + 1; j < this.Count; j++)
			{
				if (!match(this.Items[j]))
				{
					this.Items[i++] = this.Items[j];
				}
			}
			if (j - i > 0)
			{
				Array.Clear(this.Items, i, j - i);
			}
			this.Count = i;
			return j - i;
		}

		// Token: 0x0601B2D5 RID: 111317 RVA: 0x00859AE4 File Offset: 0x00857EE4
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.Shift(index, -1);
			Array.Clear(this.Items, this.Count, 1);
			this.version++;
		}

		// Token: 0x0601B2D6 RID: 111318 RVA: 0x00859B38 File Offset: 0x00857F38
		public T Pop()
		{
			if (this.Count == 0)
			{
				throw new InvalidOperationException("List is empty. Nothing to pop.");
			}
			int num = this.Count - 1;
			T result = this.Items[num];
			this.Items[num] = default(T);
			this.Count--;
			this.version++;
			return result;
		}

		// Token: 0x0601B2D7 RID: 111319 RVA: 0x00859BA3 File Offset: 0x00857FA3
		public void RemoveRange(int index, int count)
		{
			this.CheckRange(index, count);
			if (count > 0)
			{
				this.Shift(index, -count);
				Array.Clear(this.Items, this.Count, count);
				this.version++;
			}
		}

		// Token: 0x0601B2D8 RID: 111320 RVA: 0x00859BDD File Offset: 0x00857FDD
		public void Reverse()
		{
			Array.Reverse(this.Items, 0, this.Count);
			this.version++;
		}

		// Token: 0x0601B2D9 RID: 111321 RVA: 0x00859BFF File Offset: 0x00857FFF
		public void Reverse(int index, int count)
		{
			this.CheckRange(index, count);
			Array.Reverse(this.Items, index, count);
			this.version++;
		}

		// Token: 0x0601B2DA RID: 111322 RVA: 0x00859C24 File Offset: 0x00858024
		public void Sort()
		{
			Array.Sort<T>(this.Items, 0, this.Count, Comparer<T>.Default);
			this.version++;
		}

		// Token: 0x0601B2DB RID: 111323 RVA: 0x00859C4B File Offset: 0x0085804B
		public void Sort(IComparer<T> comparer)
		{
			Array.Sort<T>(this.Items, 0, this.Count, comparer);
			this.version++;
		}

		// Token: 0x0601B2DC RID: 111324 RVA: 0x00859C6E File Offset: 0x0085806E
		public void Sort(Comparison<T> comparison)
		{
			Array.Sort<T>(this.Items, comparison);
			this.version++;
		}

		// Token: 0x0601B2DD RID: 111325 RVA: 0x00859C8A File Offset: 0x0085808A
		public void Sort(int index, int count, IComparer<T> comparer)
		{
			this.CheckRange(index, count);
			Array.Sort<T>(this.Items, index, count, comparer);
			this.version++;
		}

		// Token: 0x0601B2DE RID: 111326 RVA: 0x00859CB0 File Offset: 0x008580B0
		public T[] ToArray()
		{
			T[] array = new T[this.Count];
			Array.Copy(this.Items, array, this.Count);
			return array;
		}

		// Token: 0x0601B2DF RID: 111327 RVA: 0x00859CDC File Offset: 0x008580DC
		public void TrimExcess()
		{
			this.Capacity = this.Count;
		}

		// Token: 0x0601B2E0 RID: 111328 RVA: 0x00859CEC File Offset: 0x008580EC
		public bool TrueForAll(Predicate<T> match)
		{
			ExposedList<T>.CheckMatch(match);
			for (int i = 0; i < this.Count; i++)
			{
				if (!match(this.Items[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x17002383 RID: 9091
		// (get) Token: 0x0601B2E1 RID: 111329 RVA: 0x00859D30 File Offset: 0x00858130
		// (set) Token: 0x0601B2E2 RID: 111330 RVA: 0x00859D3A File Offset: 0x0085813A
		public int Capacity
		{
			get
			{
				return this.Items.Length;
			}
			set
			{
				if (value < this.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				Array.Resize<T>(ref this.Items, value);
			}
		}

		// Token: 0x0601B2E3 RID: 111331 RVA: 0x00859D5A File Offset: 0x0085815A
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0601B2E4 RID: 111332 RVA: 0x00859D67 File Offset: 0x00858167
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04012F24 RID: 77604
		public T[] Items;

		// Token: 0x04012F25 RID: 77605
		public int Count;

		// Token: 0x04012F26 RID: 77606
		private const int DefaultCapacity = 4;

		// Token: 0x04012F27 RID: 77607
		private static readonly T[] EmptyArray = new T[0];

		// Token: 0x04012F28 RID: 77608
		private int version;

		// Token: 0x020049C1 RID: 18881
		[Serializable]
		public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			// Token: 0x0601B2E6 RID: 111334 RVA: 0x00859D81 File Offset: 0x00858181
			internal Enumerator(ExposedList<T> l)
			{
				this = default(ExposedList<T>.Enumerator);
				this.l = l;
				this.ver = l.version;
			}

			// Token: 0x0601B2E7 RID: 111335 RVA: 0x00859D9D File Offset: 0x0085819D
			public void Dispose()
			{
				this.l = null;
			}

			// Token: 0x0601B2E8 RID: 111336 RVA: 0x00859DA8 File Offset: 0x008581A8
			private void VerifyState()
			{
				if (this.l == null)
				{
					throw new ObjectDisposedException(base.GetType().FullName);
				}
				if (this.ver != this.l.version)
				{
					throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
			}

			// Token: 0x0601B2E9 RID: 111337 RVA: 0x00859DFC File Offset: 0x008581FC
			public bool MoveNext()
			{
				this.VerifyState();
				if (this.next < 0)
				{
					return false;
				}
				if (this.next < this.l.Count)
				{
					this.current = this.l.Items[this.next++];
					return true;
				}
				this.next = -1;
				return false;
			}

			// Token: 0x17002385 RID: 9093
			// (get) Token: 0x0601B2EA RID: 111338 RVA: 0x00859E64 File Offset: 0x00858264
			public T Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x0601B2EB RID: 111339 RVA: 0x00859E6C File Offset: 0x0085826C
			void IEnumerator.Reset()
			{
				this.VerifyState();
				this.next = 0;
			}

			// Token: 0x17002384 RID: 9092
			// (get) Token: 0x0601B2EC RID: 111340 RVA: 0x00859E7B File Offset: 0x0085827B
			object IEnumerator.Current
			{
				get
				{
					this.VerifyState();
					if (this.next <= 0)
					{
						throw new InvalidOperationException();
					}
					return this.current;
				}
			}

			// Token: 0x04012F29 RID: 77609
			private ExposedList<T> l;

			// Token: 0x04012F2A RID: 77610
			private int next;

			// Token: 0x04012F2B RID: 77611
			private int ver;

			// Token: 0x04012F2C RID: 77612
			private T current;
		}
	}
}
