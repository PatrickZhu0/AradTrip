using System;
using GamePool;

namespace GameClient
{
	// Token: 0x020041EB RID: 16875
	public static class DataStructPool
	{
		// Token: 0x020041EC RID: 16876
		public static class EventParamPool
		{
			// Token: 0x06017551 RID: 95569 RVA: 0x0072DC85 File Offset: 0x0072C085
			public static BeEvent.BeEventParam Get()
			{
				return DataStructPool.EventParamPool.m_EventPool.Get();
			}

			// Token: 0x06017552 RID: 95570 RVA: 0x0072DC91 File Offset: 0x0072C091
			public static void Release(BeEvent.BeEventParam eventParam)
			{
				eventParam.Reset();
				DataStructPool.EventParamPool.m_EventPool.Release(eventParam);
			}

			// Token: 0x04010C56 RID: 68694
			private static readonly ObjectPool<BeEvent.BeEventParam> m_EventPool = new ObjectPool<BeEvent.BeEventParam>(null, null);
		}

		// Token: 0x020041ED RID: 16877
		public static class UIEventParamPool
		{
			// Token: 0x06017554 RID: 95572 RVA: 0x0072DCB2 File Offset: 0x0072C0B2
			public static UIEventNew.UIEventParamNew Get()
			{
				return DataStructPool.UIEventParamPool.m_EventPool.Get();
			}

			// Token: 0x06017555 RID: 95573 RVA: 0x0072DCBE File Offset: 0x0072C0BE
			public static void Release(UIEventNew.UIEventParamNew eventParam)
			{
				eventParam.Reset();
				DataStructPool.UIEventParamPool.m_EventPool.Release(eventParam);
			}

			// Token: 0x04010C57 RID: 68695
			private static readonly ObjectPool<UIEventNew.UIEventParamNew> m_EventPool = new ObjectPool<UIEventNew.UIEventParamNew>(null, null);
		}
	}
}
