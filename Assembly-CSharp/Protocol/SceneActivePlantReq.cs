using System;

namespace Protocol
{
	// Token: 0x020009AF RID: 2479
	[Protocol]
	public class SceneActivePlantReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F70 RID: 28528 RVA: 0x00141EA8 File Offset: 0x001402A8
		public uint GetMsgID()
		{
			return 501094U;
		}

		// Token: 0x06006F71 RID: 28529 RVA: 0x00141EAF File Offset: 0x001402AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F72 RID: 28530 RVA: 0x00141EB7 File Offset: 0x001402B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F73 RID: 28531 RVA: 0x00141EC0 File Offset: 0x001402C0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006F74 RID: 28532 RVA: 0x00141EC2 File Offset: 0x001402C2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006F75 RID: 28533 RVA: 0x00141EC4 File Offset: 0x001402C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006F76 RID: 28534 RVA: 0x00141EC6 File Offset: 0x001402C6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006F77 RID: 28535 RVA: 0x00141EC8 File Offset: 0x001402C8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003295 RID: 12949
		public const uint MsgID = 501094U;

		// Token: 0x04003296 RID: 12950
		public uint Sequence;
	}
}
