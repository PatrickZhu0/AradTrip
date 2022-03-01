using System;
using System.Collections.Generic;

// Token: 0x02000204 RID: 516
public static class FixK
{
	// Token: 0x06001086 RID: 4230 RVA: 0x0005563A File Offset: 0x00053A3A
	public static List<T> ToList<T>(this IList<T> list)
	{
		return new List<T>(list);
	}

	// Token: 0x06001087 RID: 4231 RVA: 0x00055644 File Offset: 0x00053A44
	public static List<T> ToList<T>(this IEnumerable<T> collection)
	{
		List<T> list = new List<T>();
		if (collection != null)
		{
			foreach (T t in collection)
			{
				if (t != null)
				{
					list.Add(t);
				}
			}
		}
		return list;
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x00055694 File Offset: 0x00053A94
	public static T[] ToArray<T>(this IList<T> list)
	{
		if (list == null || list.Count <= 0)
		{
			return null;
		}
		T[] array = new T[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = list[i];
		}
		return array;
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x000556E8 File Offset: 0x00053AE8
	public static List<T> Distinct<T>(this IList<T> list)
	{
		List<T> list2 = new List<T>();
		if (list != null && list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				T item = list[i];
				if (!list2.Contains(item))
				{
					list2.Add(item);
				}
			}
		}
		return list2;
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x00055740 File Offset: 0x00053B40
	public static List<T> Intersect<T>(this IList<T> a, IList<T> b)
	{
		List<T> list = new List<T>();
		if (a != null && b != null)
		{
			for (int i = 0; i < a.Count; i++)
			{
				T item = a[i];
				if (b.Contains(item) && !list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x000557A0 File Offset: 0x00053BA0
	public static List<T> Except<T>(this IList<T> a, IList<T> b)
	{
		List<T> list = new List<T>();
		if (a != null && b != null)
		{
			for (int i = 0; i < a.Count; i++)
			{
				T item = a[i];
				if (!b.Contains(item) && !list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}
}
