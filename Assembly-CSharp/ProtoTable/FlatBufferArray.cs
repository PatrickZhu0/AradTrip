using System;
using System.Collections;
using System.Collections.Generic;

namespace ProtoTable
{
	// Token: 0x0200025B RID: 603
	public sealed class FlatBufferArray<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x0600138E RID: 5006 RVA: 0x00068DBC File Offset: 0x000671BC
		public FlatBufferArray(Func<int, T> fun, int count)
		{
			this._fun = fun;
			this._count = count;
		}

		// Token: 0x17000222 RID: 546
		public T this[int index]
		{
			get
			{
				return this._fun(index);
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x00068DE7 File Offset: 0x000671E7
		public int Length
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06001392 RID: 5010 RVA: 0x00068DEF File Offset: 0x000671EF
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06001393 RID: 5011 RVA: 0x00068DF7 File Offset: 0x000671F7
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x00068DFC File Offset: 0x000671FC
		public bool Contains(T other)
		{
			for (int i = 0; i < this._count; i++)
			{
				T t = this._fun(i);
				if (t.Equals(other))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x00068E48 File Offset: 0x00067248
		int IList<!0>.IndexOf(T item)
		{
			for (int i = 0; i < this._count; i++)
			{
				if (item.Equals(this._fun(i)))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x00068E92 File Offset: 0x00067292
		void IList<!0>.Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x00068E99 File Offset: 0x00067299
		void IList<!0>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x00068EA0 File Offset: 0x000672A0
		void ICollection<!0>.Add(T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x00068EA7 File Offset: 0x000672A7
		void ICollection<!0>.Clear()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x00068EB0 File Offset: 0x000672B0
		void ICollection<!0>.CopyTo(T[] array, int arrayIndex)
		{
			for (int i = 0; i < this._count; i++)
			{
				if (arrayIndex + i >= array.Length)
				{
					break;
				}
				array[arrayIndex + i] = this._fun(i);
			}
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x00068EF9 File Offset: 0x000672F9
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x00068F00 File Offset: 0x00067300
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return new FlatBufferArray<T>.Enumerator(this);
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x00068F0D File Offset: 0x0006730D
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new FlatBufferArray<T>.Enumerator(this);
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x00068F1C File Offset: 0x0006731C
		public int FindIndex(Predicate<T> match)
		{
			for (int i = 0; i < this._count; i++)
			{
				if (match(this._fun(i)))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x00068F5C File Offset: 0x0006735C
		public void ForEach(Action<T> action)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			for (int i = 0; i < this.Count; i++)
			{
				action(this._fun(i));
			}
		}

		// Token: 0x04000D41 RID: 3393
		private Func<int, T> _fun;

		// Token: 0x04000D42 RID: 3394
		private int _count;

		// Token: 0x0200025C RID: 604
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			// Token: 0x060013A0 RID: 5024 RVA: 0x00068FA4 File Offset: 0x000673A4
			public Enumerator(FlatBufferArray<T> fbarray)
			{
				this._current = default(T);
				this._index = 0;
				this._fbarray = fbarray;
			}

			// Token: 0x17000227 RID: 551
			// (get) Token: 0x060013A1 RID: 5025 RVA: 0x00068FCE File Offset: 0x000673CE
			public T Current
			{
				get
				{
					return this._current;
				}
			}

			// Token: 0x17000225 RID: 549
			// (get) Token: 0x060013A2 RID: 5026 RVA: 0x00068FD6 File Offset: 0x000673D6
			object IEnumerator.Current
			{
				get
				{
					return this._current;
				}
			}

			// Token: 0x17000226 RID: 550
			// (get) Token: 0x060013A3 RID: 5027 RVA: 0x00068FE3 File Offset: 0x000673E3
			T IEnumerator<!0>.Current
			{
				get
				{
					return this._current;
				}
			}

			// Token: 0x060013A4 RID: 5028 RVA: 0x00068FEB File Offset: 0x000673EB
			void IDisposable.Dispose()
			{
			}

			// Token: 0x060013A5 RID: 5029 RVA: 0x00068FF0 File Offset: 0x000673F0
			bool IEnumerator.MoveNext()
			{
				if (this._index < this._fbarray.Count)
				{
					this._current = this._fbarray[this._index];
					this._index++;
					return true;
				}
				this._current = default(T);
				this._index = 0;
				return false;
			}

			// Token: 0x060013A6 RID: 5030 RVA: 0x00069054 File Offset: 0x00067454
			void IEnumerator.Reset()
			{
				this._current = default(T);
				this._index = 0;
			}

			// Token: 0x04000D43 RID: 3395
			private T _current;

			// Token: 0x04000D44 RID: 3396
			private int _index;

			// Token: 0x04000D45 RID: 3397
			private FlatBufferArray<T> _fbarray;
		}
	}
}
