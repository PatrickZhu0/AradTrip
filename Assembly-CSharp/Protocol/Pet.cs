using System;

namespace Protocol
{
	// Token: 0x02000637 RID: 1591
	public class Pet : StreamObject
	{
		// Token: 0x04001F95 RID: 8085
		public ulong id;

		// Token: 0x04001F96 RID: 8086
		public uint dataId;

		// Token: 0x04001F97 RID: 8087
		[SProperty(1)]
		public ushort level;

		// Token: 0x04001F98 RID: 8088
		[SProperty(2)]
		public uint exp;

		// Token: 0x04001F99 RID: 8089
		[SProperty(3)]
		public ushort hunger;

		// Token: 0x04001F9A RID: 8090
		[SProperty(4)]
		public byte skillIndex;

		// Token: 0x04001F9B RID: 8091
		[SProperty(5)]
		public byte goldFeedCount;

		// Token: 0x04001F9C RID: 8092
		[SProperty(6)]
		public byte pointFeedCount;

		// Token: 0x04001F9D RID: 8093
		[SProperty(7)]
		public byte selectSkillCount;

		// Token: 0x04001F9E RID: 8094
		[SProperty(8)]
		public uint petScore;
	}
}
