using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001330 RID: 4912
	public class TeamDuplicationGridObjectDataModel
	{
		// Token: 0x04006BBE RID: 27582
		public uint GridObjectId;

		// Token: 0x04006BBF RID: 27583
		public uint GridId;

		// Token: 0x04006BC0 RID: 27584
		public uint GridType;

		// Token: 0x04006BC1 RID: 27585
		public uint GridStatus;

		// Token: 0x04006BC2 RID: 27586
		public List<TeamDuplicationGridPropertyDataModel> GridPropertyDataModelList = new List<TeamDuplicationGridPropertyDataModel>();
	}
}
