using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001282 RID: 4738
	public interface IDataManager
	{
		// Token: 0x0600B64C RID: 46668
		EEnterGameOrder GetOrder();

		// Token: 0x0600B64D RID: 46669
		void InitiallizeSystem();

		// Token: 0x0600B64E RID: 46670
		void ProcessInitNetMessage(WaitNetMessageManager.NetMessages a_msgEvent);

		// Token: 0x0600B64F RID: 46671
		void ClearAll();

		// Token: 0x0600B650 RID: 46672
		void Update(float a_fTime);

		// Token: 0x0600B651 RID: 46673
		void BindEnterGameMsg(List<uint> a_msgEvent);

		// Token: 0x0600B652 RID: 46674
		void OnEnterSystem();

		// Token: 0x0600B653 RID: 46675
		void OnExitSystem();

		// Token: 0x0600B654 RID: 46676
		void OnApplicationStart();

		// Token: 0x0600B655 RID: 46677
		void OnApplicationQuit();
	}
}
