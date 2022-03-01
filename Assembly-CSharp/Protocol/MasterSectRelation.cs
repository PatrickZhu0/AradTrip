using System;

namespace Protocol
{
	// Token: 0x02000634 RID: 1588
	public class MasterSectRelation : StreamObject
	{
		// Token: 0x04001F82 RID: 8066
		public ulong uid;

		// Token: 0x04001F83 RID: 8067
		[SProperty(1)]
		public string name;

		// Token: 0x04001F84 RID: 8068
		[SProperty(2)]
		public ushort level;

		// Token: 0x04001F85 RID: 8069
		[SProperty(3)]
		public byte occu;

		// Token: 0x04001F86 RID: 8070
		[SProperty(4)]
		public byte type;

		// Token: 0x04001F87 RID: 8071
		[SProperty(5)]
		public byte vipLv;

		// Token: 0x04001F88 RID: 8072
		[SProperty(6)]
		public byte status;

		// Token: 0x04001F89 RID: 8073
		[SProperty(7)]
		public byte isFinSch;

		// Token: 0x04001F8A RID: 8074
		public byte isOnline;
	}
}
