using System;
using System.Collections.Generic;

namespace GamePool
{
	// Token: 0x02000149 RID: 329
	internal static class ListPool<T>
	{
		// Token: 0x0600097E RID: 2430 RVA: 0x0003212E File Offset: 0x0003052E
		public static List<T> Get()
		{
			return ListPool<T>.s_ListPool.Get();
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0003213A File Offset: 0x0003053A
		public static void Release(List<T> toRelease)
		{
			ListPool<T>.s_ListPool.Release(toRelease);
		}

		// Token: 0x04000735 RID: 1845
		private static readonly ObjectPool<List<T>> s_ListPool = new ObjectPool<List<T>>(null, delegate(List<T> l)
		{
			l.Clear();
		});
	}
}
