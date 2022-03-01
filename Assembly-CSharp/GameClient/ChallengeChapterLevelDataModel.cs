using System;

namespace GameClient
{
	// Token: 0x02001201 RID: 4609
	public class ChallengeChapterLevelDataModel
	{
		// Token: 0x0600B14C RID: 45388 RVA: 0x00272B4C File Offset: 0x00270F4C
		public ChallengeChapterLevelDataModel(int index, int dungeonId, bool isSelected)
		{
			this.Index = index;
			this.DungeonId = dungeonId;
			this.IsSelected = isSelected;
		}

		// Token: 0x04006347 RID: 25415
		public int Index;

		// Token: 0x04006348 RID: 25416
		public int DungeonId;

		// Token: 0x04006349 RID: 25417
		public bool IsSelected;
	}
}
