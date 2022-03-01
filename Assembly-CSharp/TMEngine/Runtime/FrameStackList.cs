using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TMEngine.Runtime
{
	// Token: 0x020046F9 RID: 18169
	public static class FrameStackList<T>
	{
		// Token: 0x0601A0ED RID: 106733 RVA: 0x0081E378 File Offset: 0x0081C778
		public static List<T> Acquire()
		{
			return FrameStackList<T>.sm_ListFrameStack.Acquire();
		}

		// Token: 0x0601A0EE RID: 106734 RVA: 0x0081E384 File Offset: 0x0081C784
		public static void Recycle(List<T> elemet)
		{
			FrameStackList<T>.sm_ListFrameStack.Recycle(elemet);
		}

		// Token: 0x0601A0EF RID: 106735 RVA: 0x0081E391 File Offset: 0x0081C791
		private static void _ClearList(List<T> list)
		{
			list.Clear();
		}

		// Token: 0x0601A0F0 RID: 106736 RVA: 0x0081E399 File Offset: 0x0081C799
		// Note: this type is marked as 'beforefieldinit'.
		static FrameStackList()
		{
			FrameStackCache<List<T>>.OnAquiredAction onAquired = null;
			if (FrameStackList<T>.<>f__mg$cache0 == null)
			{
				FrameStackList<T>.<>f__mg$cache0 = new FrameStackCache<List<T>>.OnReleasedAction(FrameStackList<T>._ClearList);
			}
			FrameStackList<T>.sm_ListFrameStack = new FrameStackCache<List<T>>(onAquired, FrameStackList<T>.<>f__mg$cache0);
		}

		// Token: 0x040125A5 RID: 75173
		private static readonly FrameStackCache<List<T>> sm_ListFrameStack;

		// Token: 0x040125A6 RID: 75174
		[CompilerGenerated]
		private static FrameStackCache<List<T>>.OnReleasedAction <>f__mg$cache0;
	}
}
