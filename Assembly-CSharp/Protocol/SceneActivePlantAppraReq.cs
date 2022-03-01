using System;

namespace Protocol
{
	// Token: 0x020009B1 RID: 2481
	[Protocol]
	public class SceneActivePlantAppraReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F82 RID: 28546 RVA: 0x00141F54 File Offset: 0x00140354
		public uint GetMsgID()
		{
			return 501096U;
		}

		// Token: 0x06006F83 RID: 28547 RVA: 0x00141F5B File Offset: 0x0014035B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F84 RID: 28548 RVA: 0x00141F63 File Offset: 0x00140363
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F85 RID: 28549 RVA: 0x00141F6C File Offset: 0x0014036C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006F86 RID: 28550 RVA: 0x00141F6E File Offset: 0x0014036E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006F87 RID: 28551 RVA: 0x00141F70 File Offset: 0x00140370
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006F88 RID: 28552 RVA: 0x00141F72 File Offset: 0x00140372
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006F89 RID: 28553 RVA: 0x00141F74 File Offset: 0x00140374
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400329A RID: 12954
		public const uint MsgID = 501096U;

		// Token: 0x0400329B RID: 12955
		public uint Sequence;
	}
}
