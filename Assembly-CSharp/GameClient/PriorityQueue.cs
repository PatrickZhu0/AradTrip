using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000DDC RID: 3548
	public class PriorityQueue<T>
	{
		// Token: 0x06008F2A RID: 36650 RVA: 0x001A801C File Offset: 0x001A641C
		public PriorityQueue(int capacity, IComparer<T> comparer)
		{
			this.m_comparer = ((comparer != null) ? comparer : Comparer<T>.Default);
			this.m_arrData = new T[capacity];
		}

		// Token: 0x06008F2B RID: 36651 RVA: 0x001A8047 File Offset: 0x001A6447
		public PriorityQueue() : this(64, null)
		{
		}

		// Token: 0x06008F2C RID: 36652 RVA: 0x001A8052 File Offset: 0x001A6452
		public PriorityQueue(int capacity) : this(capacity, null)
		{
		}

		// Token: 0x06008F2D RID: 36653 RVA: 0x001A805C File Offset: 0x001A645C
		public PriorityQueue(IComparer<T> comparer) : this(64, comparer)
		{
		}

		// Token: 0x170018D7 RID: 6359
		// (get) Token: 0x06008F2E RID: 36654 RVA: 0x001A8067 File Offset: 0x001A6467
		// (set) Token: 0x06008F2F RID: 36655 RVA: 0x001A806F File Offset: 0x001A646F
		public int Count { get; private set; }

		// Token: 0x170018D8 RID: 6360
		public T this[int index]
		{
			get
			{
				if (index >= 0 && index < this.Count)
				{
					return this.m_arrData[index];
				}
				throw new InvalidOperationException(string.Format("优先队列越界 索引：{0}", index));
			}
			set
			{
				if (index >= 0 && index < this.Count)
				{
					this.m_arrData[index] = value;
					return;
				}
				throw new InvalidOperationException(string.Format("优先队列越界 索引：{0}", index));
			}
		}

		// Token: 0x06008F32 RID: 36658 RVA: 0x001A80EC File Offset: 0x001A64EC
		public T Top()
		{
			if (this.Count > 0)
			{
				return this.m_arrData[0];
			}
			throw new InvalidOperationException("优先队列为空");
		}

		// Token: 0x06008F33 RID: 36659 RVA: 0x001A8114 File Offset: 0x001A6514
		public T TakeTop()
		{
			T result = this.Top();
			this.m_arrData[0] = this.m_arrData[--this.Count];
			if (this.Count > 0)
			{
				this._Sink(0);
			}
			return result;
		}

		// Token: 0x06008F34 RID: 36660 RVA: 0x001A8164 File Offset: 0x001A6564
		public void Add(T v)
		{
			if (this.Count >= this.m_arrData.Length)
			{
				Array.Resize<T>(ref this.m_arrData, this.Count * 2);
			}
			this.m_arrData[this.Count] = v;
			this._Floating(this.Count);
			this.Count++;
		}

		// Token: 0x06008F35 RID: 36661 RVA: 0x001A81C4 File Offset: 0x001A65C4
		public int FindIndex(Predicate<T> match)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (match(this.m_arrData[i]))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06008F36 RID: 36662 RVA: 0x001A8202 File Offset: 0x001A6602
		public void Clear()
		{
			this.Count = 0;
		}

		// Token: 0x06008F37 RID: 36663 RVA: 0x001A820C File Offset: 0x001A660C
		protected void _Floating(int a_nIdx)
		{
			T t = this.m_arrData[a_nIdx];
			int num = (a_nIdx + 1) / 2 - 1;
			while (a_nIdx > 0)
			{
				if (this.m_comparer.Compare(t, this.m_arrData[num]) <= 0)
				{
					break;
				}
				this.m_arrData[a_nIdx] = this.m_arrData[num];
				a_nIdx = num;
				num = (a_nIdx + 1) / 2 - 1;
			}
			this.m_arrData[a_nIdx] = t;
		}

		// Token: 0x06008F38 RID: 36664 RVA: 0x001A8290 File Offset: 0x001A6690
		protected void _Sink(int a_nIdx)
		{
			T t = this.m_arrData[a_nIdx];
			for (int i = (a_nIdx + 1) * 2 - 1; i < this.Count; i = (a_nIdx + 1) * 2 - 1)
			{
				if (i < this.Count - 1 && this.m_comparer.Compare(this.m_arrData[i], this.m_arrData[i + 1]) <= 0)
				{
					i++;
				}
				if (this.m_comparer.Compare(t, this.m_arrData[i]) >= 0)
				{
					break;
				}
				this.m_arrData[a_nIdx] = this.m_arrData[i];
				a_nIdx = i;
			}
			this.m_arrData[a_nIdx] = t;
		}

		// Token: 0x04004707 RID: 18183
		private IComparer<T> m_comparer;

		// Token: 0x04004708 RID: 18184
		private T[] m_arrData;
	}
}
