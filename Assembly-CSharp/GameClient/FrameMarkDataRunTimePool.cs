using System;
using GamePool;

namespace GameClient
{
	// Token: 0x020046B5 RID: 18101
	internal class FrameMarkDataRunTimePool
	{
		// Token: 0x06019A5F RID: 105055 RVA: 0x00813DBF File Offset: 0x008121BF
		public static FrameMarkDataRunTime Get()
		{
			return FrameMarkDataRunTimePool.m_EventPool.Get();
		}

		// Token: 0x06019A60 RID: 105056 RVA: 0x00813DCB File Offset: 0x008121CB
		public static void Release(FrameMarkDataRunTime inst)
		{
			inst.Recycle();
			FrameMarkDataRunTimePool.m_EventPool.Release(inst);
		}

		// Token: 0x06019A61 RID: 105057 RVA: 0x00813DDE File Offset: 0x008121DE
		public static void Clear()
		{
			FrameMarkDataRunTimePool.m_EventPool.Clear();
		}

		// Token: 0x04012474 RID: 74868
		private static readonly ObjectPool<FrameMarkDataRunTime> m_EventPool = new ObjectPool<FrameMarkDataRunTime>(null, null);
	}
}
