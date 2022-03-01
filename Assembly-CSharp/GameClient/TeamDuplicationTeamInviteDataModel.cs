using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001321 RID: 4897
	public class TeamDuplicationTeamInviteDataModel
	{
		// Token: 0x04006B7A RID: 27514
		public uint TeamId;

		// Token: 0x04006B7B RID: 27515
		public TeamCopyTeamModel TeamModel;

		// Token: 0x04006B7C RID: 27516
		public TeamCopyType TeamType;

		// Token: 0x04006B7D RID: 27517
		public string TeamLeaderName;

		// Token: 0x04006B7E RID: 27518
		public int TeamLeaderProfessionId;

		// Token: 0x04006B7F RID: 27519
		public int HeadFrameId;

		// Token: 0x04006B80 RID: 27520
		public int TeamLeaderAwakeState;

		// Token: 0x04006B81 RID: 27521
		public int TeamLeaderLevel;

		// Token: 0x04006B82 RID: 27522
		public uint TeamDifficultyLevel;
	}
}
