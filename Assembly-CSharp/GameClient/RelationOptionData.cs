using System;

namespace GameClient
{
	// Token: 0x02001A09 RID: 6665
	internal class RelationOptionData
	{
		// Token: 0x0400A5CA RID: 42442
		public RelationOptionType eRelationOptionType;

		// Token: 0x0400A5CB RID: 42443
		public RelationTabType eRelationTabType = RelationTabType.RTT_COUNT;

		// Token: 0x0400A5CC RID: 42444
		public RelationData eCurrentRelationData;

		// Token: 0x0400A5CD RID: 42445
		public string mTalk = string.Empty;
	}
}
