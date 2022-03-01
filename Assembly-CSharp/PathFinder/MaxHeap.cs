using System;

namespace PathFinder
{
	// Token: 0x020001DF RID: 479
	public class MaxHeap<T> where T : class, IComparable<T>
	{
		// Token: 0x06000F36 RID: 3894 RVA: 0x0004DDD8 File Offset: 0x0004C1D8
		public MaxHeap(int capacity)
		{
			this._array = new T[capacity];
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x0004DDEC File Offset: 0x0004C1EC
		public MaxHeap(T[] array)
		{
			this._array = new T[array.Length];
			foreach (T item in array)
			{
				this.Add(item);
			}
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0004DE34 File Offset: 0x0004C234
		public void Add(T item)
		{
			if (this._array.Length <= this._count)
			{
				Array.Resize<T>(ref this._array, this._count * 2);
			}
			this._array[this._count] = item;
			this.Up(this._count++);
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x0004DE91 File Offset: 0x0004C291
		public void Clear()
		{
			this._count = 0;
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x0004DE9C File Offset: 0x0004C29C
		public bool Contains(T item)
		{
			if (this._array != null)
			{
				for (int i = 0; i < this._count; i++)
				{
					if (item == this._array[i])
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0004DEEC File Offset: 0x0004C2EC
		public T Pop()
		{
			if (this._count == 0)
			{
				return (T)((object)null);
			}
			if (this._count == 1)
			{
				this._count = 0;
				return this._array[0];
			}
			T result = this._array[0];
			this.Swap(0, --this._count);
			this.Down(0);
			return result;
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000F3C RID: 3900 RVA: 0x0004DF59 File Offset: 0x0004C359
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x0004DF61 File Offset: 0x0004C361
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000F3E RID: 3902 RVA: 0x0004DF64 File Offset: 0x0004C364
		public bool Remove(T item)
		{
			for (int i = 0; i < this._count; i++)
			{
				if (item == this._array[i])
				{
					this.Swap(i, --this._count);
					int num = this.Up(i);
					if (num == i)
					{
						this.Down(i);
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F3F RID: 3903 RVA: 0x0004DFD8 File Offset: 0x0004C3D8
		public void RebuildElement(T item)
		{
			for (int i = 0; i < this._count; i++)
			{
				T t = this._array[i];
				if (item == t)
				{
					int num = this.Up(i);
					if (num == i)
					{
						this.Down(i);
						return;
					}
				}
			}
		}

		// Token: 0x06000F40 RID: 3904 RVA: 0x0004E034 File Offset: 0x0004C434
		private int Down(int index)
		{
			while (index * 2 + 1 < this._count)
			{
				int num = index * 2 + 1;
				int num2 = index * 2 + 2;
				int num3 = num;
				if (num2 < this._count && this._array[num2].CompareTo(this._array[num]) > 0)
				{
					num3 = num2;
				}
				if (this._array[num3].CompareTo(this._array[index]) <= 0)
				{
					break;
				}
				this.Swap(index, num3);
				index = num3;
			}
			return index;
		}

		// Token: 0x06000F41 RID: 3905 RVA: 0x0004E0E4 File Offset: 0x0004C4E4
		private int Up(int index)
		{
			while (index > 0)
			{
				int num = (index - 1) / 2;
				if (this._array[index].CompareTo(this._array[num]) <= 0)
				{
					break;
				}
				this.Swap(index, num);
				index = num;
				num = (num - 1) / 2;
			}
			return index;
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x0004E14C File Offset: 0x0004C54C
		private void Swap(int indexA, int indexB)
		{
			T t = this._array[indexA];
			this._array[indexA] = this._array[indexB];
			this._array[indexB] = t;
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x0004E18C File Offset: 0x0004C58C
		private bool IsMax(int index)
		{
			if (index >= this._count)
			{
				return true;
			}
			int num = index * 2 + 1;
			int num2 = index * 2 + 2;
			return (num >= this._count || this._array[num].CompareTo(this._array[index]) <= 0) && (num2 >= this._count || this._array[num2].CompareTo(this._array[index]) <= 0) && this.IsMax(num) && this.IsMax(num2);
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0004E23B File Offset: 0x0004C63B
		public bool IsValid()
		{
			return this.IsMax(0);
		}

		// Token: 0x04000A81 RID: 2689
		private T[] _array;

		// Token: 0x04000A82 RID: 2690
		private int _count;
	}
}
