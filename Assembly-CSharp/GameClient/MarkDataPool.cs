using System;
using GamePool;

namespace GameClient
{
	// Token: 0x020046B8 RID: 18104
	internal class MarkDataPool
	{
		// Token: 0x06019A6E RID: 105070 RVA: 0x00813E82 File Offset: 0x00812282
		public static MarkData Get()
		{
			return MarkDataPool.m_EventPool.Get();
		}

		// Token: 0x06019A6F RID: 105071 RVA: 0x00813E8E File Offset: 0x0081228E
		public static void Release(MarkData inst)
		{
			inst.Recycle();
			MarkDataPool.m_EventPool.Release(inst);
		}

		// Token: 0x06019A70 RID: 105072 RVA: 0x00813EA1 File Offset: 0x008122A1
		public static void Clear()
		{
			MarkDataPool.m_EventPool.Clear();
		}

		// Token: 0x04012477 RID: 74871
		private static readonly ObjectPool<MarkData> m_EventPool = new ObjectPool<MarkData>(null, null);
	}
}
