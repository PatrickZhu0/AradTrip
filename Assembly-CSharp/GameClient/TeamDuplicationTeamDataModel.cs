using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001317 RID: 4887
	public class TeamDuplicationTeamDataModel
	{
		// Token: 0x04006B34 RID: 27444
		public int TeamId;

		// Token: 0x04006B35 RID: 27445
		public string TeamName;

		// Token: 0x04006B36 RID: 27446
		public int TotalCommission;

		// Token: 0x04006B37 RID: 27447
		public int BonusCommission;

		// Token: 0x04006B38 RID: 27448
		public bool AutoAgreeGold;

		// Token: 0x04006B39 RID: 27449
		public int TeamModel;

		// Token: 0x04006B3A RID: 27450
		public TeamCopyType TeamType;

		// Token: 0x04006B3B RID: 27451
		public TeamCopyTeamStatus TeamStatus;

		// Token: 0x04006B3C RID: 27452
		public uint TeamDifficultyLevel;

		// Token: 0x04006B3D RID: 27453
		public int TeamEquipScore;

		// Token: 0x04006B3E RID: 27454
		public List<TeamDuplicationCaptainDataModel> CaptainDataModelList = new List<TeamDuplicationCaptainDataModel>();

		// Token: 0x04006B3F RID: 27455
		public string VoiceTalkRoomId;
	}
}
