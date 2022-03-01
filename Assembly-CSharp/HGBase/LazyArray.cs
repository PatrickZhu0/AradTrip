using System;

namespace HGBase
{
	// Token: 0x02000D0A RID: 3338
	public class LazyArray<T>
	{
		// Token: 0x06008830 RID: 34864 RVA: 0x00184212 File Offset: 0x00182612
		public LazyArray(int initSize, T invalid_Value)
		{
			if (initSize != 0)
			{
				this.m_Array = new T[initSize];
			}
			this.m_ArrayLen = initSize;
			this.m_InvalidValue = invalid_Value;
		}

		// Token: 0x06008831 RID: 34865 RVA: 0x0018423C File Offset: 0x0018263C
		public void Resize(int newSize)
		{
			if (newSize > this.m_Array.Length)
			{
				T[] array = new T[newSize];
				if (array != null)
				{
					for (int i = 0; i < this.m_ArrayLen; i++)
					{
						array[i] = this.m_Array[i];
					}
					this.m_Array = array;
				}
			}
			this.m_ArrayLen = newSize;
		}

		// Token: 0x06008832 RID: 34866 RVA: 0x0018429C File Offset: 0x0018269C
		public int Size()
		{
			return this.m_ArrayLen;
		}

		// Token: 0x06008833 RID: 34867 RVA: 0x001842A4 File Offset: 0x001826A4
		public void Add(T elem)
		{
			int arrayLen = this.m_ArrayLen;
			this.Resize(this.m_ArrayLen + 1);
			this.m_Array[arrayLen] = elem;
		}

		// Token: 0x06008834 RID: 34868 RVA: 0x001842D3 File Offset: 0x001826D3
		public T At(int index)
		{
			if (0 <= index && index < this.m_ArrayLen)
			{
				return this.m_Array[index];
			}
			return this.INVALID_VALUE;
		}

		// Token: 0x1700182B RID: 6187
		public T this[int index]
		{
			get
			{
				if (0 <= index && index < this.m_ArrayLen)
				{
					return this.m_Array[index];
				}
				return this.INVALID_VALUE;
			}
			set
			{
				if (0 <= index && index < this.m_ArrayLen)
				{
					this.m_Array[index] = value;
				}
			}
		}

		// Token: 0x1700182C RID: 6188
		// (get) Token: 0x06008837 RID: 34871 RVA: 0x00184345 File Offset: 0x00182745
		public T INVALID_VALUE
		{
			get
			{
				return this.m_InvalidValue;
			}
		}

		// Token: 0x0400420C RID: 16908
		protected T m_InvalidValue;

		// Token: 0x0400420D RID: 16909
		protected T[] m_Array;

		// Token: 0x0400420E RID: 16910
		protected int m_ArrayLen;
	}
}
