using System;

namespace Network
{
	// Token: 0x020001BD RID: 445
	public class MsgDATA
	{
		// Token: 0x06000E34 RID: 3636 RVA: 0x000491C2 File Offset: 0x000475C2
		public MsgDATA(int length)
		{
			this.bytes = new byte[length];
		}

		// Token: 0x040009D7 RID: 2519
		public ServerType serverType;

		// Token: 0x040009D8 RID: 2520
		public uint id;

		// Token: 0x040009D9 RID: 2521
		public uint sequence;

		// Token: 0x040009DA RID: 2522
		public byte[] bytes;
	}
}
