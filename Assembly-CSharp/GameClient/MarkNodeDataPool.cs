using System;
using GamePool;

namespace GameClient
{
	// Token: 0x020046B9 RID: 18105
	internal class MarkNodeDataPool
	{
		// Token: 0x06019A73 RID: 105075 RVA: 0x00813EC3 File Offset: 0x008122C3
		public static NodeData Get()
		{
			return MarkNodeDataPool.m_EventPool.Get();
		}

		// Token: 0x06019A74 RID: 105076 RVA: 0x00813ECF File Offset: 0x008122CF
		public static void Release(NodeData inst)
		{
			inst.Recycle();
			MarkNodeDataPool.m_EventPool.Release(inst);
		}

		// Token: 0x06019A75 RID: 105077 RVA: 0x00813EE2 File Offset: 0x008122E2
		public static void Clear()
		{
			MarkNodeDataPool.m_EventPool.Clear();
		}

		// Token: 0x04012478 RID: 74872
		private static readonly ObjectPool<NodeData> m_EventPool = new ObjectPool<NodeData>(null, null);
	}
}
