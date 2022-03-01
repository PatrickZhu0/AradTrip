using System;

namespace GameClient
{
	// Token: 0x02000F57 RID: 3927
	public interface ICommonConsume
	{
		// Token: 0x0600989F RID: 39071
		void OnChange();

		// Token: 0x060098A0 RID: 39072
		void OnAdd();

		// Token: 0x060098A1 RID: 39073
		EUIEventID[] WatchEvents();

		// Token: 0x060098A2 RID: 39074
		ulong GetCount();

		// Token: 0x060098A3 RID: 39075
		ulong GetSumCount();
	}
}
