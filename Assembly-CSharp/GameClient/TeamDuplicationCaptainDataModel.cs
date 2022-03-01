using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001318 RID: 4888
	public class TeamDuplicationCaptainDataModel
	{
		// Token: 0x04006B40 RID: 27456
		public int CaptainId;

		// Token: 0x04006B41 RID: 27457
		public List<TeamDuplicationPlayerDataModel> PlayerList = new List<TeamDuplicationPlayerDataModel>();

		// Token: 0x04006B42 RID: 27458
		public int CaptainStatus;
	}
}
