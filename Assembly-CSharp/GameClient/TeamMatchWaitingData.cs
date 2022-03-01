using System;

namespace GameClient
{
	// Token: 0x02001C16 RID: 7190
	public class TeamMatchWaitingData
	{
		// Token: 0x060119E5 RID: 72165 RVA: 0x00525E09 File Offset: 0x00524209
		public void Clear()
		{
			this.matchState = MatchState.None;
			this.TeamDungeonTableID = 0;
		}

		// Token: 0x0400B782 RID: 46978
		public MatchState matchState;

		// Token: 0x0400B783 RID: 46979
		public int TeamDungeonTableID;
	}
}
