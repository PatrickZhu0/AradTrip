using System;

namespace Protocol
{
	// Token: 0x02000A50 RID: 2640
	[Protocol]
	public class SceneSyncPet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007426 RID: 29734 RVA: 0x00150F58 File Offset: 0x0014F358
		public uint GetMsgID()
		{
			return 502202U;
		}

		// Token: 0x06007427 RID: 29735 RVA: 0x00150F5F File Offset: 0x0014F35F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007428 RID: 29736 RVA: 0x00150F67 File Offset: 0x0014F367
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007429 RID: 29737 RVA: 0x00150F70 File Offset: 0x0014F370
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600742A RID: 29738 RVA: 0x00150F72 File Offset: 0x0014F372
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600742B RID: 29739 RVA: 0x00150F74 File Offset: 0x0014F374
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600742C RID: 29740 RVA: 0x00150F76 File Offset: 0x0014F376
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600742D RID: 29741 RVA: 0x00150F78 File Offset: 0x0014F378
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040035F2 RID: 13810
		public const uint MsgID = 502202U;

		// Token: 0x040035F3 RID: 13811
		public uint Sequence;
	}
}
