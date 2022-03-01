using System;
using GamePool;

namespace GameClient
{
	// Token: 0x020046B6 RID: 18102
	internal class FrameMarkDataPool
	{
		// Token: 0x06019A64 RID: 105060 RVA: 0x00813E00 File Offset: 0x00812200
		public static FrameMarkData Get()
		{
			return FrameMarkDataPool.m_EventPool.Get();
		}

		// Token: 0x06019A65 RID: 105061 RVA: 0x00813E0C File Offset: 0x0081220C
		public static void Release(FrameMarkData inst)
		{
			inst.Recycle();
			FrameMarkDataPool.m_EventPool.Release(inst);
		}

		// Token: 0x06019A66 RID: 105062 RVA: 0x00813E1F File Offset: 0x0081221F
		public static void Clear()
		{
			FrameMarkDataPool.m_EventPool.Clear();
		}

		// Token: 0x04012475 RID: 74869
		private static readonly ObjectPool<FrameMarkData> m_EventPool = new ObjectPool<FrameMarkData>(null, null);
	}
}
