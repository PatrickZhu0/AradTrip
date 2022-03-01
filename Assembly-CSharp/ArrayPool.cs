using System;
using System.Collections.Generic;

// Token: 0x0200009F RID: 159
public class ArrayPool<T> : Singleton<ArrayPool<T>>
{
	// Token: 0x0600034B RID: 843 RVA: 0x000193D4 File Offset: 0x000177D4
	public T[] AllocateArray(int len)
	{
		T[] array = null;
		Stack<T[]> stack = null;
		if (this.m_ArrayPoolTbl.TryGetValue(len, out stack))
		{
			array = stack.Pop();
		}
		if (array == null)
		{
			array = new T[len];
		}
		return array;
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00019410 File Offset: 0x00017810
	public void ReleaseArray(T[] array)
	{
		if (array != null)
		{
			Stack<T[]> stack = null;
			if (!this.m_ArrayPoolTbl.TryGetValue(array.Length, out stack))
			{
				stack = new Stack<T[]>();
				this.m_ArrayPoolTbl.Add(array.Length, stack);
			}
			stack.Push(array);
		}
	}

	// Token: 0x0400033F RID: 831
	private Dictionary<int, Stack<T[]>> m_ArrayPoolTbl = new Dictionary<int, Stack<T[]>>();
}
