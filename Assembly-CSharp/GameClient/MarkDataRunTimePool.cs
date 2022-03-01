using System;
using GamePool;

namespace GameClient
{
	// Token: 0x020046B7 RID: 18103
	internal class MarkDataRunTimePool
	{
		// Token: 0x06019A69 RID: 105065 RVA: 0x00813E41 File Offset: 0x00812241
		public static MarkDataRunTime Get()
		{
			return MarkDataRunTimePool.m_EventPool.Get();
		}

		// Token: 0x06019A6A RID: 105066 RVA: 0x00813E4D File Offset: 0x0081224D
		public static void Release(MarkDataRunTime inst)
		{
			inst.Recycle();
			MarkDataRunTimePool.m_EventPool.Release(inst);
		}

		// Token: 0x06019A6B RID: 105067 RVA: 0x00813E60 File Offset: 0x00812260
		public static void Clear()
		{
			MarkDataRunTimePool.m_EventPool.Clear();
		}

		// Token: 0x04012476 RID: 74870
		private static readonly ObjectPool<MarkDataRunTime> m_EventPool = new ObjectPool<MarkDataRunTime>(null, null);
	}
}
