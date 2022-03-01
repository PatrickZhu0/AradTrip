using System;

namespace Protocol
{
	// Token: 0x0200094A RID: 2378
	[Protocol]
	public class GambingItemQueryReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BFE RID: 27646 RVA: 0x0013B19A File Offset: 0x0013959A
		public uint GetMsgID()
		{
			return 707903U;
		}

		// Token: 0x06006BFF RID: 27647 RVA: 0x0013B1A1 File Offset: 0x001395A1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C00 RID: 27648 RVA: 0x0013B1A9 File Offset: 0x001395A9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C01 RID: 27649 RVA: 0x0013B1B2 File Offset: 0x001395B2
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006C02 RID: 27650 RVA: 0x0013B1B4 File Offset: 0x001395B4
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006C03 RID: 27651 RVA: 0x0013B1B6 File Offset: 0x001395B6
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006C04 RID: 27652 RVA: 0x0013B1B8 File Offset: 0x001395B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006C05 RID: 27653 RVA: 0x0013B1BC File Offset: 0x001395BC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040030EB RID: 12523
		public const uint MsgID = 707903U;

		// Token: 0x040030EC RID: 12524
		public uint Sequence;
	}
}
