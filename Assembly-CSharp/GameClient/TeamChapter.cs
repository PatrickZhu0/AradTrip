using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200130C RID: 4876
	internal class TeamChapter
	{
		// Token: 0x04006A7C RID: 27260
		public uint id;

		// Token: 0x04006A7D RID: 27261
		public bool isOpened;

		// Token: 0x04006A7E RID: 27262
		public string name;

		// Token: 0x04006A7F RID: 27263
		public string dataPath;

		// Token: 0x04006A80 RID: 27264
		public List<TeamDungeon> dungeons = new List<TeamDungeon>();
	}
}
