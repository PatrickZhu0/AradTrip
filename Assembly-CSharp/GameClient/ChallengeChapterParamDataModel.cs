using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001200 RID: 4608
	public class ChallengeChapterParamDataModel
	{
		// Token: 0x04006343 RID: 25411
		public DungeonModelTable.eType ModelType;

		// Token: 0x04006344 RID: 25412
		public int BaseChapterId;

		// Token: 0x04006345 RID: 25413
		public int SelectedChapterId;

		// Token: 0x04006346 RID: 25414
		public List<int> ChapterIdList;
	}
}
